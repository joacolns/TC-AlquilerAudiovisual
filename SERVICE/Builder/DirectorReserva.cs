using System;
using BE;

namespace SERVICE
{
	public class DirectorReserva
	{
		private readonly ReservaBuilder builder;

		public DirectorReserva(ReservaBuilder builder)
		{
			if (builder == null)
			{
				throw new ArgumentNullException("builder");
			}

			this.builder = builder;
		}

		public Reserva Construir(Reserva datos)
		{
			if (datos == null || datos.Equipos == null)
			{
				throw new ArgumentException("Completá los datos de la reserva.");
			}

			builder.Iniciar();
			builder.ConCliente(datos.Cliente);

			foreach (Equipo equipo in datos.Equipos)
			{
				builder.ConEquipo(equipo);
			}

			builder.ConFechas(datos.Desde, datos.Hasta);
			return builder.ObtenerResultado();
		}
	}
}
