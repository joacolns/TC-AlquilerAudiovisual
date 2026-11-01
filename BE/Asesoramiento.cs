using System;
using System.Collections.Generic;

namespace BE
{
	// Relevamiento de una producción (brief) que el cliente completa para recibir una propuesta de equipamiento.
	public class BriefProduccion
	{
		public string TipoPieza { get; set; }
		public decimal Presupuesto { get; set; }
		public DateTime Desde { get; set; }
		public DateTime Hasta { get; set; }
		public int Personas { get; set; }
		public int Camaras { get; set; }
		public string Locacion { get; set; }
		public string Luz { get; set; }
		public int HorasJornada { get; set; }
		public bool CamaraEnMovimiento { get; set; }
		public bool SonidoDirecto { get; set; }
		public bool Monitoreo { get; set; }
		public bool LookCinematografico { get; set; }
	}

	public class LineaPropuesta
	{
		public string Rol { get; set; }
		public string Seccion { get; set; }
		public Equipo Equipo { get; set; }
		public string Detalle { get; set; }
		public string Gama { get; set; }
		public decimal Tarifa { get; set; }
		public decimal Subtotal { get; set; }
		public string Aporta { get; set; }
		public string Resigna { get; set; }
	}

	public class Propuesta
	{
		public string Nombre { get; set; }
		public List<LineaPropuesta> Lineas { get; set; }
		public List<string> Notas { get; set; }
		public int Dias { get; set; }
		public decimal Total { get; set; }
		public decimal Presupuesto { get; set; }
		public decimal SenaRequerida { get; set; }
		public string Seguro { get; set; }

		public decimal Desvio
		{
			get
			{
				return Total - Presupuesto;
			}
		}

		public bool DentroDePresupuesto
		{
			get
			{
				return Total <= Presupuesto;
			}
		}
	}

	public class PropuestaGuardada
	{
		public int Id { get; set; }
		public int UsuarioId { get; set; }
		public string Nombre { get; set; }
		public DateTime Creada { get; set; }
		public string Variante { get; set; }
		public decimal Total { get; set; }
		public BriefProduccion Brief { get; set; }

		public string Resumen
		{
			get
			{
				return Brief.TipoPieza + " · " + Brief.Desde.ToString("dd/MM/yy") + " a " + Brief.Hasta.ToString("dd/MM/yy");
			}
		}
	}

	public class ResultadoAsesoramiento
	{
		public List<string> Lectura { get; set; }
		public Propuesta Recomendada { get; set; }
		public Propuesta Economica { get; set; }
		public List<LineaPropuesta> Complementos { get; set; }
	}
}
