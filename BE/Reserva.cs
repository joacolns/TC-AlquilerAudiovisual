using System;
using System.Collections.Generic;

namespace BE
{
	public class Reserva
	{
		public int Id { get; set; }
		public int ClienteId { get; set; }
		public Cliente Cliente { get; set; }
		public List<Equipo> Equipos { get; set; }
		public DateTime Desde { get; set; }
		public DateTime Hasta { get; set; }
		public decimal Importe { get; set; }
		public decimal SenaRequerida { get; set; }
		public decimal Sena { get; set; }
		public string Estado { get; set; }
		public string NumeroContrato { get; set; }
		public string NumeroRemito { get; set; }
		public bool ContratoFirmado { get; set; }
	}
}
