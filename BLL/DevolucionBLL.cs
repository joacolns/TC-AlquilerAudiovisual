using System;
using System.Collections.Generic;
using BE;
using DAL;
using SERVICE;

namespace BLL
{
	public class DevolucionBLL
	{
		private readonly DevolucionMapper mapper = new DevolucionMapper();
		private readonly ReservaMapper reservas = new ReservaMapper();
		private readonly Seguridad seguridad = new Seguridad();

		public int Registrar(Devolucion devolucion)
		{
			Autorizar("Devolucion.Registrar");

			if (devolucion == null || devolucion.Id != 0)
			{
				throw new ArgumentException("Completá una nueva devolución.");
			}

			if (devolucion.Reserva != null)
			{
				devolucion.ReservaId = devolucion.Reserva.Id;
			}

			Reserva reserva = reservas.Buscar(devolucion.ReservaId);

			if (reserva == null || reserva.Estado != "Entregada")
			{
				throw new InvalidOperationException("La reserva ya no está entregada o ya tiene una devolución registrada. Actualizá la pantalla.");
			}

			if (devolucion.Fecha < reserva.Desde || devolucion.Fecha > DateTime.Now.AddMinutes(5))
			{
				throw new ArgumentException("La devolución debe ser posterior al inicio del alquiler y no puede estar en el futuro.");
			}

			if (devolucion.Observaciones == null || devolucion.Observaciones.Length > 500)
			{
				throw new ArgumentException("Ingresá observaciones de hasta 500 caracteres.");
			}

			devolucion.Reserva = reserva;
			devolucion.SaldoPendiente = 0;
			devolucion.Finalizada = false;

			if (devolucion.Conforme)
			{
				if (devolucion.Fecha > reserva.Hasta)
				{
					throw new ArgumentException("La devolución tiene atraso. Registrala con incidencias.");
				}

				devolucion.Finalizada = true;
			}
			else if (!devolucion.ClientePresente)
			{
				throw new ArgumentException("El cliente debe estar presente para registrar una devolución con incidencias.");
			}

			devolucion.Id = mapper.Insertar(devolucion);
			return devolucion.Id;
		}

		public int RegistrarIncidencia(Incidencia incidencia)
		{
			Autorizar("Incidencia.Registrar");
			ValidarIncidencia(incidencia, true);
			incidencia.Cargo = CalcularCargo(incidencia);
			incidencia.Estado = "Abierta";
			incidencia.FechaAltaTecnica = null;
			incidencia.Id = mapper.RegistrarIncidencia(incidencia);
			return incidencia.Id;
		}

		public decimal CalcularCargo(Incidencia incidencia)
		{
			Autorizar("Incidencia.Registrar");
			ValidarIncidencia(incidencia, false);
			Devolucion devolucion = mapper.Buscar(incidencia.DevolucionId);

			if (devolucion == null
				|| devolucion.Conforme
				|| devolucion.Finalizada
				|| !devolucion.ClientePresente)
			{
				throw new InvalidOperationException("Seleccioná una devolución con incidencias y una inspección todavía abierta.");
			}

			Reserva reserva = reservas.Buscar(devolucion.ReservaId);
			Equipo seleccionado = null;

			foreach (Equipo equipo in reserva.Equipos)
			{
				if (equipo.Id == incidencia.EquipoId)
				{
					seleccionado = equipo;
					break;
				}
			}

			if (seleccionado == null)
			{
				throw new ArgumentException("La unidad no pertenece al remito de la reserva.");
			}

			incidencia.Devolucion = devolucion;
			incidencia.Equipo = seleccionado;
			decimal cargoBase;
			decimal descuento = 0;

			if (incidencia.Tipo == "Atraso")
			{
				if (devolucion.Fecha <= reserva.Hasta)
				{
					throw new ArgumentException("No hay atraso para esas fechas.");
				}

				decimal diasAlquiler = decimal.Ceiling((reserva.Hasta - reserva.Desde).Ticks / (decimal)TimeSpan.TicksPerDay);
				decimal diasAtraso = decimal.Ceiling((devolucion.Fecha - reserva.Hasta).Ticks / (decimal)TimeSpan.TicksPerDay);
				decimal alquilerEquipo = decimal.Round(diasAlquiler * seleccionado.TarifaDiaria, 2, MidpointRounding.AwayFromZero);
				cargoBase = alquilerEquipo * 0.10m * diasAtraso;
			}
			else
			{
				if (incidencia.Tipo == "DañoReparable")
				{
					cargoBase = seleccionado.ValorReposicion * 0.20m;
				}
				else if (incidencia.Tipo == "DañoTotal")
				{
					cargoBase = seleccionado.ValorReposicion * 0.80m;
				}
				else
				{
					cargoBase = seleccionado.ValorReposicion;
				}
			}

			cargoBase = decimal.Round(cargoBase, 2, MidpointRounding.AwayFromZero);
			Seguro seguro = seleccionado.Seguro;

			if (incidencia.Tipo != "Atraso"
				&& seguro != null
				&& seguro.ClienteId == reserva.ClienteId
				&& seguro.Desde <= reserva.Desde
				&& seguro.Hasta >= reserva.Hasta)
			{
				decimal porcentaje = 0;

				if (seguro.Tipo == "Basico" && incidencia.Tipo == "DañoReparable")
				{
					porcentaje = 0.25m;
				}
				else if (seguro.Tipo == "Intermedio"
					&& (incidencia.Tipo == "DañoReparable"
						|| incidencia.Tipo == "DañoTotal"))
				{
					porcentaje = 0.50m;
				}
				else if (seguro.Tipo == "Completo")
				{
					porcentaje = 0.80m;
				}

				descuento = decimal.Round(Math.Min(cargoBase * porcentaje, seguro.Cobertura), 2, MidpointRounding.AwayFromZero);
			}

			incidencia.CargoBase = cargoBase;
			incidencia.DescuentoSeguro = descuento;
			incidencia.Cargo = cargoBase - descuento;
			return incidencia.Cargo;
		}

		public bool Finalizar(int devolucionId)
		{
			Autorizar("Incidencia.Registrar");

			if (devolucionId <= 0)
			{
				throw new ArgumentException("Seleccioná una devolución.");
			}

			return mapper.Finalizar(devolucionId);
		}

		public bool DarAltaTecnica(int incidenciaId)
		{
			Autorizar("Incidencia.AltaTecnica");

			if (incidenciaId <= 0)
			{
				throw new ArgumentException("Seleccioná una incidencia abierta.");
			}

			return mapper.DarAltaTecnica(incidenciaId);
		}

		public List<Devolucion> Listar()
		{
			Autorizar("Devolucion.Registrar");
			return mapper.Listar();
		}

		public List<Incidencia> ListarIncidencias(int? devolucionId)
		{
			if (!seguridad.TienePermiso("Incidencia.Registrar")
				&& !seguridad.TienePermiso("Incidencia.AltaTecnica"))
			{
				throw new UnauthorizedAccessException("No tenés permiso para consultar incidencias.");
			}

			List<Incidencia> lista = mapper.ListarIncidencias(devolucionId);

			if (!seguridad.TienePermiso("Incidencia.Registrar"))
			{
				foreach (Incidencia incidencia in lista)
				{
					// El técnico recibe la unidad y el período, sin pólizas ni datos del cliente.
					incidencia.Devolucion.SaldoPendiente = 0;
					Reserva reserva = incidencia.Devolucion.Reserva;
					reserva.Cliente = null;
					reserva.ClienteId = 0;
					reserva.Importe = 0;
					reserva.Sena = 0;

					foreach (Equipo equipo in reserva.Equipos)
					{
						equipo.Seguro = null;
					}
				}
			}

			return lista;
		}

		private void ValidarIncidencia(Incidencia incidencia, bool exigirDescripcion)
		{
			if (incidencia == null || incidencia.Id != 0)
			{
				throw new ArgumentException("Completá una nueva incidencia.");
			}

			if (incidencia.Devolucion != null)
			{
				incidencia.DevolucionId = incidencia.Devolucion.Id;
			}

			if (incidencia.Equipo != null)
			{
				incidencia.EquipoId = incidencia.Equipo.Id;
			}

			if (incidencia.DevolucionId <= 0
				|| incidencia.EquipoId <= 0
				|| (exigirDescripcion
					&& string.IsNullOrWhiteSpace(incidencia.Descripcion))
				|| (incidencia.Descripcion != null
					&& incidencia.Descripcion.Length > 500))
			{
				throw new ArgumentException("Seleccioná devolución, unidad y una descripción de hasta 500 caracteres.");
			}

			if (incidencia.Tipo != "Atraso"
				&& incidencia.Tipo != "Faltante"
				&& incidencia.Tipo != "DañoReparable"
				&& incidencia.Tipo != "DañoTotal")
			{
				throw new ArgumentException("Elegí uno de los cuatro tipos de incidencia.");
			}
		}

		private void Autorizar(string codigo)
		{
			if (!seguridad.TienePermiso(codigo))
			{
				throw new UnauthorizedAccessException("No tenés permiso para esta operación de devolución.");
			}
		}
	}
}
