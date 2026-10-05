using System;

namespace BE
{
	public class Incidencia
	{
		public int Id { get; set; }
		public int DevolucionId { get; set; }
		public Devolucion Devolucion { get; set; }
		public int EquipoId { get; set; }
		public Equipo Equipo { get; set; }
		public string Tipo { get; set; }
		public string Descripcion { get; set; }
		public decimal CargoBase { get; set; }
		public decimal DescuentoSeguro { get; set; }
		public decimal Cargo { get; set; }
		public string Estado { get; set; }
		public DateTime? FechaAltaTecnica { get; set; }
	}
}
