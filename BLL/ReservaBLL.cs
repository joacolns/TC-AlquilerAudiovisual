using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using BE;
using DAL;
using SERVICE;

namespace BLL
{
	public class ReservaBLL
	{
		private readonly ReservaMapper mapper = new ReservaMapper();
		private readonly Seguridad seguridad = new Seguridad();
		private readonly ClienteBLL clientes = new ClienteBLL();
		private readonly EquipoBLL equipos = new EquipoBLL();
		private readonly ClienteMapper fichas = new ClienteMapper();
		private readonly UsuarioMapper usuarios = new UsuarioMapper();

		// El período se maneja al minuto: así el cálculo de días del programa y el de la base coinciden siempre.
		private void NormalizarFechas(Reserva reserva)
		{
			if (reserva != null)
			{
				reserva.Desde = new DateTime(reserva.Desde.Ticks - reserva.Desde.Ticks % TimeSpan.TicksPerMinute);
				reserva.Hasta = new DateTime(reserva.Hasta.Ticks - reserva.Hasta.Ticks % TimeSpan.TicksPerMinute);
			}
		}

		public decimal Cotizar(Reserva reserva)
		{
			Autorizar("Reserva.Cotizar");
			NormalizarFechas(reserva);

			if (reserva == null
				|| reserva.Hasta <= reserva.Desde
				|| reserva.Equipos == null
				|| reserva.Equipos.Count == 0)
			{
				throw new ArgumentException("Elegí fechas y al menos una unidad.");
			}

			List<Equipo> disponibles = equipos.ListarDisponibles(reserva.Desde, reserva.Hasta);
			List<Equipo> seleccion = new List<Equipo>();

			foreach (Equipo solicitado in reserva.Equipos)
			{
				if (solicitado == null)
				{
					throw new ArgumentException("La selección contiene una unidad inválida.");
				}

				foreach (Equipo repetido in seleccion)
				{
					if (repetido.Id == solicitado.Id)
					{
						throw new ArgumentException("Una unidad está repetida.");
					}
				}

				Equipo encontrado = null;

				foreach (Equipo disponible in disponibles)
				{
					if (disponible.Id == solicitado.Id)
					{
						encontrado = disponible;
						break;
					}
				}

				if (encontrado == null)
				{
					throw new InvalidOperationException("Una unidad ya no está disponible para esas fechas.");
				}

				seleccion.Add(encontrado);
			}

			reserva.Equipos = seleccion;
			AplicarSeguro(reserva);
			AsignarImportes(reserva);
			return reserva.Importe;
		}

		private void AplicarSeguro(Reserva reserva)
		{
			Usuario sesion = SesionSingleton.Instancia.UsuarioActual;
			int usuarioId = 0;

			if (reserva.ClienteId > 0)
			{
				Cliente cliente = fichas.Buscar(reserva.ClienteId);

				if (cliente == null)
				{
					throw new ArgumentException("El cliente no existe.");
				}

				if (sesion.Rol == "Cliente" && cliente.UsuarioId != sesion.Id)
				{
					throw new UnauthorizedAccessException("Solo podés cotizar con tu propio seguro.");
				}

				usuarioId = cliente.UsuarioId;
			}
			else if (sesion.Rol == "Cliente")
			{
				usuarioId = sesion.Id;
			}

			Seguro seguro = null;

			if (usuarioId > 0)
			{
				seguro = usuarios.BuscarSeguro(usuarioId);

				if (seguro != null && (seguro.Desde > reserva.Desde || seguro.Hasta < reserva.Hasta))
				{
					seguro = null;
				}
			}

			foreach (Equipo equipo in reserva.Equipos)
			{
				equipo.Seguro = seguro;
			}
		}

		public decimal CalcularImportes(Reserva reserva)
		{
			Autorizar("Reserva.Cotizar");
			NormalizarFechas(reserva);

			if (reserva == null
				|| reserva.Hasta <= reserva.Desde
				|| reserva.Equipos == null
				|| reserva.Equipos.Count == 0)
			{
				throw new ArgumentException("Elegí fechas y al menos una unidad para ver los importes requeridos.");
			}

			foreach (Equipo equipo in reserva.Equipos)
			{
				if (equipo == null || equipo.TarifaDiaria <= 0 || equipo.ValorReposicion <= 0)
				{
					throw new ArgumentException("La unidad debe tener tarifa y valor de reposición válidos.");
				}
			}

			// Previsualiza los valores consultados; Cotizar y Confirmar revalidan disponibilidad.
			AsignarImportes(reserva);
			return reserva.Importe;
		}

		public int Solicitar(Reserva reserva)
		{
			Autorizar("Reserva.Solicitar");
			NormalizarFechas(reserva);

			if (reserva == null || reserva.Id != 0)
			{
				throw new ArgumentException("Elegí equipos y fechas para una nueva solicitud.");
			}

			// La identidad procede de la sesión, nunca del cliente enviado por el formulario.
			List<Cliente> propios = clientes.ListarPropios();

			if (propios.Count != 1)
			{
				throw new InvalidOperationException("Tu cuenta debe tener una ficha de cliente registrada.");
			}

			reserva.Cliente = propios[0];
			reserva.ClienteId = propios[0].Id;
			Cotizar(reserva);
			DirectorReserva director = new DirectorReserva(new ReservaBuilderConcreto());
			Reserva solicitud = director.Construir(reserva);
			solicitud.Importe = reserva.Importe;
			solicitud.SenaRequerida = reserva.SenaRequerida;
			solicitud.Estado = "Pendiente";
			solicitud.Id = mapper.Insertar(solicitud);
			reserva.Id = solicitud.Id;
			reserva.Estado = "Pendiente";
			reserva.Sena = 0;
			return solicitud.Id;
		}

		private string NombreEstado(string estado)
		{
			switch (estado)
			{
				case "Pendiente":
					return "pendiente de revisión";
				case "Aceptada":
					return "aceptada y pendiente de pago";
				case "Firme":
					return "pagada y pendiente de entrega";
				case "Entregada":
					return "entregada";
				case "ConIncidencia":
					return "con incidencias";
				case "Cerrada":
					return "cerrada";
				case "Rechazada":
					return "rechazada por stock";
				case "Cancelada":
					return "cancelada";
				default:
					return estado;
			}
		}

		// Los datos de la pantalla pueden estar viejos: se informa el estado real y se pide actualizar.
		private InvalidOperationException Desactualizado(Reserva reserva, string esperado)
		{
			if (reserva == null)
			{
				return new InvalidOperationException("La solicitud ya no existe. Actualizá la lista antes de continuar.");
			}

			return new InvalidOperationException(
				"La solicitud " + reserva.Id + " cambió: ahora está " + NombreEstado(reserva.Estado)
					+ " y esta acción requiere que esté " + esperado + ". Actualizá la lista antes de continuar."
			);
		}

		public bool Cancelar(int reservaId)
		{
			Autorizar("Reserva.Cancelar");
			Usuario usuario = SesionSingleton.Instancia.UsuarioActual;
			Reserva reserva = mapper.Buscar(reservaId);

			if (reserva != null && (reserva.Cliente == null || reserva.Cliente.UsuarioId != usuario.Id))
			{
				throw new UnauthorizedAccessException("Solo podés cancelar tus propios pedidos.");
			}

			if (reserva == null || (reserva.Estado != "Pendiente" && reserva.Estado != "Aceptada"))
			{
				throw Desactualizado(reserva, "pendiente de revisión o aceptada sin pagar");
			}

			if (!mapper.Cancelar(reservaId, usuario.Id))
			{
				throw new InvalidOperationException("El pedido cambió mientras lo cancelabas (stock o el pago se adelantaron). Actualizá la lista.");
			}

			return true;
		}

		public int Confirmar(Reserva reserva)
		{
			Autorizar("Reserva.Confirmar");

			if (reserva == null || reserva.Id <= 0)
			{
				throw new ArgumentException("Seleccioná una solicitud pendiente.");
			}

			Reserva solicitud = mapper.Buscar(reserva.Id);

			if (solicitud == null || solicitud.Estado != "Pendiente")
			{
				throw Desactualizado(solicitud, "pendiente de revisión");
			}

			if (!clientes.ValidarCliente(solicitud.ClienteId, solicitud.Desde, solicitud.Hasta))
			{
				throw new InvalidOperationException("El cliente no está habilitado: verificá su cuenta y las fechas.");
			}

			Cotizar(solicitud);

			foreach (Equipo equipo in solicitud.Equipos)
			{
				Seguro seguro = equipo.Seguro;

				if (seguro != null
					&& (seguro.ClienteId != solicitud.ClienteId
						|| seguro.Desde > solicitud.Desde
						|| seguro.Hasta < solicitud.Hasta))
				{
					equipo.Seguro = null;
				}
			}

			DirectorReserva director = new DirectorReserva(new ReservaBuilderConcreto());
			Reserva nueva = director.Construir(solicitud);
			nueva.Id = solicitud.Id;
			nueva.Estado = "Aceptada";
			nueva.Importe = solicitud.Importe;
			nueva.SenaRequerida = solicitud.SenaRequerida;
			nueva.Sena = 0;

			if (!mapper.Confirmar(nueva))
			{
				throw new InvalidOperationException("La solicitud cambió mientras la aceptabas (otra persona la procesó o el cliente la canceló). Actualizá la lista.");
			}

			reserva.Id = nueva.Id;
			reserva.Estado = nueva.Estado;
			return nueva.Id;
		}

		public bool Pagar(int reservaId)
		{
			Autorizar("Reserva.Pagar");
			Usuario usuario = SesionSingleton.Instancia.UsuarioActual;
			Reserva reserva = mapper.Buscar(reservaId);

			if (reserva == null || reserva.Estado != "Aceptada")
			{
				throw Desactualizado(reserva, "aceptada y pendiente de pago");
			}

			if (reserva.Cliente.UsuarioId != usuario.Id)
			{
				throw new UnauthorizedAccessException("Solo podés pagar tus propias solicitudes.");
			}

			return mapper.Pagar(reservaId, usuario.Id);
		}

		public bool Rechazar(int reservaId)
		{
			Autorizar("Reserva.Confirmar");

			if (reservaId <= 0)
			{
				throw new ArgumentException("Seleccioná una solicitud pendiente.");
			}

			Reserva actual = mapper.Buscar(reservaId);

			if (actual == null || actual.Estado != "Pendiente")
			{
				throw Desactualizado(actual, "pendiente de revisión");
			}

			if (!mapper.Rechazar(reservaId))
			{
				throw new InvalidOperationException("La solicitud cambió mientras la rechazabas. Actualizá la lista.");
			}

			return true;
		}

		public bool RegistrarEntrega(int reservaId)
		{
			Autorizar("Reserva.Entregar");
			Reserva reserva = mapper.Buscar(reservaId);

			if (reserva == null || reserva.Estado != "Firme")
			{
				throw Desactualizado(reserva, "pagada y pendiente de entrega");
			}

			if (reserva.Sena != reserva.SenaRequerida)
			{
				return false;
			}

			return mapper.RegistrarEntrega(reservaId);
		}

		public List<Reserva> Listar()
		{
			Autorizar("Reserva.Consultar");
			Usuario usuario = SesionSingleton.Instancia.UsuarioActual;
			List<Reserva> lista;

			if (usuario.Rol != "Cliente")
			{
				lista = mapper.Listar(null);
			}
			else
			{
				List<Cliente> propios = clientes.Listar();

				if (propios.Count == 0)
				{
					return new List<Reserva>();
				}

				lista = mapper.Listar(propios[0].Id);
			}

			foreach (Reserva reserva in lista)
			{
				if (reserva.Estado == "Pendiente" || reserva.Estado == "Rechazada")
				{
					AsignarImportes(reserva);
				}
			}

			return lista;
		}

		private void AsignarImportes(Reserva reserva)
		{
			decimal tarifa = 0;

			foreach (Equipo equipo in reserva.Equipos)
			{
				tarifa += equipo.TarifaDiaria;
			}

			decimal dias = decimal.Ceiling((reserva.Hasta - reserva.Desde).Ticks / (decimal)TimeSpan.TicksPerDay);
			reserva.Importe = decimal.Round(tarifa * dias, 2, MidpointRounding.AwayFromZero);
			reserva.SenaRequerida = decimal.Round(reserva.Importe * Porcentaje("PorcentajeSena"), 2, MidpointRounding.AwayFromZero);
		}

		private decimal Porcentaje(string clave)
		{
			decimal valor;

			if (!decimal.TryParse(
				ConfigurationManager.AppSettings[clave],
				NumberStyles.Number,
				CultureInfo.InvariantCulture,
				out valor
			)
				|| valor < 0
				|| valor > 1)
			{
				throw new InvalidOperationException("Revisá el porcentaje de seña en App.config.");
			}

			return valor;
		}

		private void Autorizar(string codigo)
		{
			if (!seguridad.TienePermiso(codigo))
			{
				throw new UnauthorizedAccessException("No tenés permiso para esta operación de reservas.");
			}
		}
	}
}
