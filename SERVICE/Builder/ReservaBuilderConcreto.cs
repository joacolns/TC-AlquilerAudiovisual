using System;
using System.Collections.Generic;
using BE;

namespace SERVICE
{
	public class ReservaBuilderConcreto : ReservaBuilder
	{
		private Reserva reserva;

		public override void Iniciar()
		{
			reserva = new Reserva
			{
				Equipos = new List<Equipo>()
			};
		}

		public override void ConCliente(Cliente cliente)
		{
			ExigirInicio();

			if (cliente == null || cliente.Id <= 0)
			{
				throw new ArgumentException("Seleccioná un cliente.");
			}

			reserva.ClienteId = cliente.Id;
			reserva.Cliente = cliente;
		}

		public override void ConEquipo(Equipo equipo)
		{
			ExigirInicio();

			if (equipo == null || equipo.Id <= 0)
			{
				throw new ArgumentException("Seleccioná un equipo válido.");
			}

			foreach (Equipo existente in reserva.Equipos)
			{
				if (existente.Id == equipo.Id)
				{
					throw new ArgumentException("La misma unidad no puede agregarse dos veces.");
				}
			}

			reserva.Equipos.Add(equipo);
		}

		public override void ConFechas(DateTime desde, DateTime hasta)
		{
			ExigirInicio();

			if (hasta <= desde)
			{
				throw new ArgumentException("La fecha final debe ser posterior a la inicial.");
			}

			reserva.Desde = desde;
			reserva.Hasta = hasta;
		}

		public override Reserva ObtenerResultado()
		{
			ExigirInicio();

			if (reserva.ClienteId <= 0 || reserva.Equipos.Count == 0 || reserva.Hasta <= reserva.Desde)
			{
				throw new InvalidOperationException("Completá cliente, equipos y fechas de la reserva.");
			}

			reserva.Estado = "Pendiente";
			Reserva resultado = reserva;
			reserva = null;
			return resultado;
		}

		private void ExigirInicio()
		{
			if (reserva == null)
			{
				throw new InvalidOperationException("Iniciá la construcción de la reserva.");
			}
		}
	}
}
