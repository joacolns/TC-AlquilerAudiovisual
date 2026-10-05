using System;
using BE;

namespace SERVICE
{
	public abstract class ReservaBuilder
	{
		public abstract void Iniciar();
		public abstract void ConCliente(Cliente cliente);
		public abstract void ConEquipo(Equipo equipo);
		public abstract void ConFechas(DateTime desde, DateTime hasta);
		public abstract Reserva ObtenerResultado();
	}
}
