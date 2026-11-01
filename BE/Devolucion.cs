using System;

namespace BE
{
	public class Devolucion
	{
		public int Id { get; set; }
		public int ReservaId { get; set; }
		public Reserva Reserva { get; set; }
		public DateTime Fecha { get; set; }
		public bool Conforme { get; set; }
		public bool ClientePresente { get; set; }
		public bool Finalizada { get; set; }
		public string Observaciones { get; set; }
		public decimal SaldoPendiente { get; set; }
	}
}
