using System;
using System.Collections.Generic;
using BE;
using DAL;
using SERVICE;

namespace BLL
{
	public class ClienteBLL
	{
		private readonly ClienteMapper mapper = new ClienteMapper();
		private readonly Seguridad seguridad = new Seguridad();

		public int Guardar(Cliente cliente)
		{
			Autorizar("Cliente.Gestionar");

			if (cliente == null || cliente.Id != 0)
			{
				throw new ArgumentException("El formulario realiza altas de clientes.");
			}

			if (cliente.Usuario != null)
			{
				cliente.UsuarioId = cliente.Usuario.Id;
			}

			if (cliente.UsuarioId <= 0)
			{
				throw new ArgumentException("Seleccioná la cuenta del cliente.");
			}

			if (cliente.DniCuit == null)
			{
				cliente.DniCuit = "";
			}

			cliente.DniCuit = cliente.DniCuit.Trim().Replace("-", "").Replace(".", "");

			if (cliente.DniCuit.Length < 7 || cliente.DniCuit.Length > 11)
			{
				throw new ArgumentException("Ingresá un DNI o CUIT válido.");
			}

			foreach (char digito in cliente.DniCuit)
			{
				if (!char.IsDigit(digito))
				{
					throw new ArgumentException("El DNI/CUIT contiene solo números.");
				}
			}

			if (string.IsNullOrWhiteSpace(cliente.Nombre)
				|| cliente.Nombre.Length > 100
				|| string.IsNullOrWhiteSpace(cliente.Telefono)
				|| cliente.Telefono.Length > 30
				|| string.IsNullOrWhiteSpace(cliente.Email)
				|| cliente.Email.Length > 150
				|| !cliente.Email.Contains("@"))
			{
				throw new ArgumentException("Completá nombre, teléfono y correo del cliente.");
			}

			cliente.Id = mapper.Insertar(cliente);
			return cliente.Id;
		}

		public int GuardarSeguro(Seguro seguro)
		{
			Autorizar("Seguro.Gestionar");

			if (seguro == null)
			{
				throw new ArgumentException("Completá el seguro.");
			}

			if (seguro.Cliente != null)
			{
				seguro.ClienteId = seguro.Cliente.Id;
			}

			if (seguro.ClienteId <= 0
				|| string.IsNullOrWhiteSpace(seguro.Poliza)
				|| seguro.Poliza.Length > 50
				|| string.IsNullOrWhiteSpace(seguro.Aseguradora)
				|| seguro.Aseguradora.Length > 100
				|| seguro.Hasta <= seguro.Desde
				|| seguro.Cobertura <= 0)
			{
				throw new ArgumentException("Completá cliente, póliza, aseguradora, vigencia y cobertura positiva por unidad.");
			}

			seguro.Id = mapper.GuardarSeguro(seguro);
			return seguro.Id;
		}

		public bool ValidarCliente(int clienteId, DateTime desde, DateTime hasta)
		{
			Autorizar("Reserva.Confirmar");
			Cliente cliente = mapper.Buscar(clienteId);

			if (cliente == null
				|| cliente.AntecedenteNegativo
				|| cliente.Usuario == null
				|| !cliente.Usuario.Activo
				|| hasta <= desde)
			{
				return false;
			}

			foreach (Seguro seguro in mapper.ListarSeguros(clienteId))
			{
				if (seguro.Desde <= desde && seguro.Hasta >= hasta && seguro.Cobertura > 0)
				{
					return true;
				}
			}

			return false;
		}

		public List<Cliente> Listar()
		{
			Autorizar("Cliente.Consultar");
			Usuario usuario = SesionSingleton.Instancia.UsuarioActual;

			if (usuario.Rol == "Cliente")
			{
				return mapper.Listar(usuario.Id);
			}
			else
			{
				return mapper.Listar(null);
			}
		}

		public List<Seguro> ListarSeguros(int clienteId)
		{
			Autorizar("Cliente.Consultar");
			Usuario usuario = SesionSingleton.Instancia.UsuarioActual;

			if (usuario.Rol == "Cliente")
			{
				Cliente cliente = mapper.Buscar(clienteId);

				if (cliente == null || cliente.UsuarioId != usuario.Id)
				{
					throw new UnauthorizedAccessException("Solo podés consultar tus seguros.");
				}
			}

			return mapper.ListarSeguros(clienteId);
		}

		private void Autorizar(string codigo)
		{
			if (!seguridad.TienePermiso(codigo))
			{
				throw new UnauthorizedAccessException("No tenés permiso para esta operación de clientes.");
			}
		}
	}
}
