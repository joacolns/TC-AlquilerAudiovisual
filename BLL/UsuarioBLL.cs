using System;
using System.Collections.Generic;
using BE;
using DAL;
using SERVICE;

namespace BLL
{
	public class UsuarioBLL
	{
		private readonly UsuarioMapper mapper = new UsuarioMapper();
		private readonly Seguridad seguridad = new Seguridad();

		public bool IniciarSesion(string nombre, string clave)
		{
			SesionSingleton.Instancia.Cerrar();

			if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrEmpty(clave))
			{
				return false;
			}

			Usuario usuario = mapper.Buscar(nombre.Trim());

			if (usuario == null || !usuario.Activo || !seguridad.Verificar(clave, usuario))
			{
				return false;
			}

			ValidarRol(usuario.Rol);
			Rol permisos = new Rol
			{
				Codigo = usuario.Rol
			};
			string[] codigos;

			if (usuario.Rol == "Administrador")
			{
				codigos = new[]
				{
					"Usuario.Gestionar",
					"Cliente.Gestionar",
					"Cliente.Consultar",
					"Seguro.Gestionar",
					"Equipo.Consultar",
					"Equipo.Guardar",
					"Reserva.Cotizar",
					"Reserva.Consultar",
					"Reserva.Solicitar",
					"Reserva.Confirmar",
					"Reserva.Pagar",
					"Reserva.Cancelar",
					"Reserva.Entregar",
					"Devolucion.Registrar",
					"Incidencia.Registrar",
					"Incidencia.AltaTecnica",
					"Asesoramiento.Consultar"
				};
			}
			else if (usuario.Rol == "EncargadoStock")
			{
				codigos = new[]
				{
					"Cliente.Consultar",
					"Equipo.Consultar",
					"Equipo.Guardar",
					"Reserva.Cotizar",
					"Reserva.Consultar",
					"Reserva.Confirmar",
					"Reserva.Entregar",
					"Devolucion.Registrar",
					"Incidencia.Registrar"
				};
			}
			else if (usuario.Rol == "Cliente")
			{
				codigos = new[]
				{
					"Cliente.Consultar",
					"Equipo.Consultar",
					"Reserva.Cotizar",
					"Reserva.Solicitar",
					"Reserva.Pagar",
					"Reserva.Cancelar",
					"Reserva.Consultar",
					"Asesoramiento.Consultar"
				};
			}
			else
			{
				codigos = new[]
				{
					"Equipo.Consultar",
					"Incidencia.AltaTecnica"
				};
			}

			foreach (string codigo in codigos)
			{
				permisos.Agregar(new Permiso
				{
					Codigo = codigo
				});
			}

			SesionSingleton.Instancia.Iniciar(usuario, permisos);
			return true;
		}

		public int Guardar(Usuario usuario, string clave)
		{
			Autorizar();

			if (usuario == null
				|| usuario.Id != 0
				|| string.IsNullOrWhiteSpace(usuario.NombreUsuario)
				|| usuario.NombreUsuario.Trim().Length > 50)
			{
				throw new ArgumentException("Completá un nombre de usuario de hasta 50 caracteres para el alta.");
			}

			if (string.IsNullOrEmpty(clave) || clave.Length < 8 || clave.Length > 128)
			{
				throw new ArgumentException("La contraseña debe tener entre 8 y 128 caracteres.");
			}

			ValidarRol(usuario.Rol);
			ValidarDatosPersonales(usuario);
			usuario.NombreUsuario = usuario.NombreUsuario.Trim();

			foreach (Usuario existente in mapper.Listar())
			{
				if (string.Equals(existente.NombreUsuario, usuario.NombreUsuario, StringComparison.OrdinalIgnoreCase))
				{
					throw new ArgumentException("Ya existe un usuario llamado " + existente.NombreUsuario + ". Elegí otro nombre de usuario.");
				}

				if (existente.DniCuit == usuario.DniCuit)
				{
					throw new ArgumentException("El DNI/CUIT " + usuario.DniCuit + " ya pertenece al usuario " + existente.NombreUsuario + ".");
				}
			}
			ValidarSeguro(usuario.Rol, usuario.TipoSeguro);
			usuario.Sal = seguridad.CrearSal();
			usuario.Hash = seguridad.Hashear(clave, usuario.Sal);
			usuario.Id = mapper.Insertar(usuario);
			return usuario.Id;
		}

		public Usuario PerfilActual()
		{
			Usuario sesion = SesionSingleton.Instancia.UsuarioActual;

			if (sesion == null)
			{
				return null;
			}

			Usuario actual = mapper.Buscar(sesion.NombreUsuario);

			if (actual == null)
			{
				return sesion;
			}

			return actual;
		}

		public bool ConfigurarSeguro(int usuarioId, string tipo)
		{
			Autorizar();

			if (usuarioId <= 0)
			{
				throw new ArgumentException("Seleccioná un usuario.");
			}

			ValidarSeguro("Cliente", tipo);
			return mapper.ConfigurarSeguro(usuarioId, tipo);
		}

		public bool CambiarClave(int usuarioId, string clave)
		{
			Autorizar();

			if (usuarioId <= 0)
			{
				throw new ArgumentException("Seleccioná un usuario.");
			}

			if (string.IsNullOrEmpty(clave) || clave.Length < 8 || clave.Length > 128)
			{
				throw new ArgumentException("La contraseña debe tener entre 8 y 128 caracteres.");
			}

			byte[] sal = seguridad.CrearSal();
			byte[] hash = seguridad.Hashear(clave, sal);
			return mapper.CambiarClave(usuarioId, hash, sal);
		}

		public bool AsignarRol(int usuarioId, string rol)
		{
			Autorizar();
			ValidarRol(rol);
			bool cambio = mapper.AsignarRol(usuarioId, rol);

			if (cambio && SesionSingleton.Instancia.UsuarioActual.Id == usuarioId)
			{
				SesionSingleton.Instancia.Cerrar();
			}

			return cambio;
		}

		public List<Usuario> Listar()
		{
			Autorizar();
			return mapper.Listar();
		}

		private void Autorizar()
		{
			if (!seguridad.TienePermiso("Usuario.Gestionar"))
			{
				throw new UnauthorizedAccessException("No tenés permiso para gestionar usuarios.");
			}
		}

		private void ValidarSeguro(string rol, string tipo)
		{
			if (tipo != "SinSeguro" && tipo != "Basico" && tipo != "Intermedio" && tipo != "Completo")
			{
				throw new ArgumentException("Elegí Sin seguro, Básico, Intermedio o Completo.");
			}

			if (rol != "Cliente" && rol != "Administrador" && tipo != "SinSeguro")
			{
				throw new ArgumentException("El seguro de alquiler corresponde a cuentas con rol Cliente o Administrador.");
			}
		}

		private void ValidarDatosPersonales(Usuario usuario)
		{
			if (string.IsNullOrWhiteSpace(usuario.Nombre)
				|| usuario.Nombre.Trim().Length > 100
				|| string.IsNullOrWhiteSpace(usuario.Telefono)
				|| usuario.Telefono.Trim().Length > 30
				|| string.IsNullOrWhiteSpace(usuario.Email)
				|| usuario.Email.Trim().Length > 150
				|| !usuario.Email.Contains("@")
				|| string.IsNullOrWhiteSpace(usuario.DniCuit))
			{
				throw new ArgumentException("Nombre, correo (con @), teléfono y DNI/CUIT son obligatorios para todo usuario.");
			}

			usuario.DniCuit = usuario.DniCuit.Trim().Replace("-", "").Replace(".", "");

			if (usuario.DniCuit.Length < 7 || usuario.DniCuit.Length > 11)
			{
				throw new ArgumentException("Ingresá un DNI o CUIT válido.");
			}

			foreach (char digito in usuario.DniCuit)
			{
				if (!char.IsDigit(digito))
				{
					throw new ArgumentException("El DNI/CUIT contiene solo números.");
				}
			}

			usuario.Nombre = usuario.Nombre.Trim();
			usuario.Telefono = usuario.Telefono.Trim();
			usuario.Email = usuario.Email.Trim();
		}

		private void ValidarRol(string rol)
		{
			if (rol != "Administrador" && rol != "Cliente" && rol != "EncargadoStock" && rol != "Tecnico")
			{
				throw new ArgumentException("Seleccioná uno de los cuatro roles.");
			}
		}
	}
}
