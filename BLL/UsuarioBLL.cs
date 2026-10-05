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
					"Reserva.Confirmar",
					"Reserva.Entregar",
					"Devolucion.Registrar",
					"Incidencia.Registrar",
					"Incidencia.AltaTecnica"
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
					"Reserva.Consultar"
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
			usuario.NombreUsuario = usuario.NombreUsuario.Trim();
			usuario.Sal = seguridad.CrearSal();
			usuario.Hash = seguridad.Hashear(clave, usuario.Sal);
			usuario.Id = mapper.Insertar(usuario);
			return usuario.Id;
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

		private void ValidarRol(string rol)
		{
			if (rol != "Administrador" && rol != "Cliente" && rol != "EncargadoStock" && rol != "Tecnico")
			{
				throw new ArgumentException("Seleccioná uno de los cuatro roles.");
			}
		}
	}
}
