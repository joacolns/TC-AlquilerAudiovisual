using System;
using System.Collections.Generic;
using System.IO;
using BE;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace SERVICE
{
	// Genera los PDF del sistema (remito de alquiler y propuesta del asesor) con PDFsharp.
	public class GeneradorPdf
	{
		private const double Margen = 40;
		private static readonly XColor Oscuro = XColor.FromArgb(15, 23, 42);
		private static readonly XColor Azul = XColor.FromArgb(37, 99, 235);
		private static readonly XColor Gris = XColor.FromArgb(100, 116, 139);
		private static readonly XColor Linea = XColor.FromArgb(203, 213, 225);
		private static readonly XColor Fondo = XColor.FromArgb(241, 245, 249);

		// Hoja A4 con cursor vertical, saltos de página automáticos y numeración.
		private class Hoja
		{
			public PdfDocument Documento = new PdfDocument();
			public PdfPage Pagina;
			public XGraphics Gfx;
			public double Y;
			public string Titulo;
			public int Numero;

			public Hoja(string titulo)
			{
				Titulo = titulo;
				Documento.Info.Title = titulo;
				Documento.Info.Author = "FOCO";
				NuevaPagina();
			}

			public double Ancho
			{
				get
				{
					return Pagina.Width.Point - 2 * Margen;
				}
			}

			public void NuevaPagina()
			{
				if (Gfx != null)
				{
					Gfx.Dispose();
				}

				Pagina = Documento.AddPage();
				Pagina.Size = PdfSharp.PageSize.A4;
				Gfx = XGraphics.FromPdfPage(Pagina);
				Numero++;
				Y = Margen;
				Gfx.DrawRectangle(new XSolidBrush(Oscuro), 0, 0, Pagina.Width.Point, 54);
				Gfx.DrawString("FOCO", new XFont("Arial", 20, XFontStyle.Bold), XBrushes.White, new XPoint(Margen, 35));
				Gfx.DrawString(Titulo, new XFont("Arial", 10, XFontStyle.Regular), new XSolidBrush(XColor.FromArgb(148, 163, 184)),
					new XRect(Margen, 0, Ancho, 54), XStringFormats.CenterRight);
				Y = 74;
			}

			public void Asegurar(double alto)
			{
				if (Y + alto > Pagina.Height.Point - 50)
				{
					NuevaPagina();
				}
			}

			public void Cerrar(string ruta)
			{
				int total = Documento.PageCount;
				Gfx.Dispose();

				for (int i = 0; i < total; i++)
				{
					using (XGraphics g = XGraphics.FromPdfPage(Documento.Pages[i]))
					{
						g.DrawString(
							"Página " + (i + 1) + " de " + total + " · Generado el " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
							new XFont("Arial", 8, XFontStyle.Regular),
							new XSolidBrush(Gris),
							new XRect(Margen, Documento.Pages[i].Height.Point - 34, Ancho, 20),
							XStringFormats.Center
						);
					}
				}

				Documento.Save(ruta);
				Documento.Close();
			}
		}

		// ---- Piezas de dibujo

		private List<string> Ajustar(XGraphics gfx, string texto, XFont fuente, double ancho)
		{
			List<string> lineas = new List<string>();

			if (string.IsNullOrEmpty(texto))
			{
				lineas.Add("");
				return lineas;
			}

			foreach (string parrafo in texto.Replace("\r", "").Split('\n'))
			{
				string actual = "";

				foreach (string palabra in parrafo.Split(' '))
				{
					string prueba = actual.Length == 0 ? palabra : actual + " " + palabra;

					if (gfx.MeasureString(prueba, fuente).Width <= ancho || actual.Length == 0)
					{
						actual = prueba;
					}
					else
					{
						lineas.Add(actual);
						actual = palabra;
					}
				}

				lineas.Add(actual);
			}

			return lineas;
		}

		private void Seccion(Hoja h, string texto)
		{
			h.Asegurar(40);
			h.Y += 10;
			h.Gfx.DrawString(texto, new XFont("Arial", 12, XFontStyle.Bold), new XSolidBrush(Oscuro), new XPoint(Margen, h.Y + 10));
			h.Y += 16;
			h.Gfx.DrawLine(new XPen(Azul, 1.5), Margen, h.Y, Margen + 40, h.Y);
			h.Y += 10;
		}

		private void Parrafo(Hoja h, string texto, bool destacado)
		{
			XFont fuente = new XFont("Arial", 10, destacado ? XFontStyle.Bold : XFontStyle.Regular);

			foreach (string linea in Ajustar(h.Gfx, texto, fuente, h.Ancho))
			{
				h.Asegurar(16);
				h.Gfx.DrawString(linea, fuente, new XSolidBrush(Oscuro), new XPoint(Margen, h.Y + 10));
				h.Y += 14;
			}
		}

		private void DatoPar(Hoja h, string etiqueta, string valor)
		{
			h.Asegurar(16);
			h.Gfx.DrawString(etiqueta, new XFont("Arial", 9, XFontStyle.Regular), new XSolidBrush(Gris), new XPoint(Margen, h.Y + 10));
			h.Gfx.DrawString(valor, new XFont("Arial", 10, XFontStyle.Bold), new XSolidBrush(Oscuro), new XPoint(Margen + 130, h.Y + 10));
			h.Y += 15;
		}

		// Tabla con encabezado repetido, ajuste de texto por celda y filas alternadas.
		private void Tabla(Hoja h, string[] titulos, double[] pesos, List<string[]> filas, bool[] derecha)
		{
			double suma = 0;

			foreach (double p in pesos)
			{
				suma += p;
			}

			double[] anchos = new double[pesos.Length];

			for (int i = 0; i < pesos.Length; i++)
			{
				anchos[i] = h.Ancho * pesos[i] / suma;
			}

			XFont fuenteTitulo = new XFont("Arial", 9, XFontStyle.Bold);
			XFont fuente = new XFont("Arial", 9, XFontStyle.Regular);
			Encabezado(h, titulos, anchos, fuenteTitulo, derecha);
			int n = 0;

			foreach (string[] fila in filas)
			{
				if (fila.Length == 1)
				{
					// Fila de una sola celda: encabezado de sección.
					h.Asegurar(40);
					h.Gfx.DrawRectangle(new XSolidBrush(XColor.FromArgb(219, 234, 254)), Margen, h.Y, h.Ancho, 18);
					h.Gfx.DrawString(fila[0].ToUpper(), new XFont("Arial", 9, XFontStyle.Bold), new XSolidBrush(Oscuro),
						new XRect(Margen + 5, h.Y, h.Ancho - 10, 18), XStringFormats.CenterLeft);
					h.Y += 18;
					n = 0;
					continue;
				}

				List<List<string>> celdas = new List<List<string>>();
				int maximo = 1;

				for (int i = 0; i < fila.Length; i++)
				{
					List<string> lineas = Ajustar(h.Gfx, fila[i], fuente, anchos[i] - 10);
					celdas.Add(lineas);
					maximo = Math.Max(maximo, lineas.Count);
				}

				double alto = maximo * 12 + 10;

				if (h.Y + alto > h.Pagina.Height.Point - 50)
				{
					h.NuevaPagina();
					Encabezado(h, titulos, anchos, fuenteTitulo, derecha);
				}

				if (n % 2 == 1)
				{
					h.Gfx.DrawRectangle(new XSolidBrush(Fondo), Margen, h.Y, h.Ancho, alto);
				}

				double x = Margen;

				for (int i = 0; i < celdas.Count; i++)
				{
					double yy = h.Y + 6;

					foreach (string linea in celdas[i])
					{
						XRect rect = new XRect(x + 5, yy, anchos[i] - 10, 12);
						h.Gfx.DrawString(linea, fuente, new XSolidBrush(Oscuro), rect, derecha != null && derecha[i] ? XStringFormats.TopRight : XStringFormats.TopLeft);
						yy += 12;
					}

					x += anchos[i];
				}

				h.Gfx.DrawLine(new XPen(Linea, 0.5), Margen, h.Y + alto, Margen + h.Ancho, h.Y + alto);
				h.Y += alto;
				n++;
			}

			h.Y += 8;
		}

		private void Encabezado(Hoja h, string[] titulos, double[] anchos, XFont fuente, bool[] derecha)
		{
			h.Asegurar(30);
			h.Gfx.DrawRectangle(new XSolidBrush(Oscuro), Margen, h.Y, h.Ancho, 20);
			double x = Margen;

			for (int i = 0; i < titulos.Length; i++)
			{
				h.Gfx.DrawString(titulos[i], fuente, XBrushes.White, new XRect(x + 5, h.Y, anchos[i] - 10, 20),
					derecha != null && derecha[i] ? XStringFormats.CenterRight : XStringFormats.CenterLeft);
				x += anchos[i];
			}

			h.Y += 20;
		}

		private string Dinero(decimal valor)
		{
			return "ARS " + valor.ToString("N2");
		}

		private string Carpeta(string ruta)
		{
			string carpeta = Path.GetDirectoryName(ruta);

			if (!string.IsNullOrEmpty(carpeta))
			{
				Directory.CreateDirectory(carpeta);
			}

			return ruta;
		}

		// ---- Documentos

		public string Remito(Reserva reserva, string ruta)
		{
			if (reserva == null || reserva.Cliente == null)
			{
				throw new ArgumentException("No hay una reserva para generar el remito.");
			}

			string numero = string.IsNullOrEmpty(reserva.NumeroRemito) ? "R-" + reserva.Id : reserva.NumeroRemito;
			string contrato = string.IsNullOrEmpty(reserva.NumeroContrato) ? "C-" + reserva.Id : reserva.NumeroContrato;
			Hoja h = new Hoja("Remito " + numero);
			h.Gfx.DrawString("REMITO " + numero, new XFont("Arial", 18, XFontStyle.Bold), new XSolidBrush(Oscuro), new XPoint(Margen, h.Y + 14));
			h.Y += 30;
			Parrafo(h, "Alquiler de equipamiento audiovisual · Contrato " + contrato, false);

			Seccion(h, "Cliente");
			DatoPar(h, "Nombre", reserva.Cliente.Nombre);
			DatoPar(h, "DNI / CUIT", reserva.Cliente.DniCuit);
			DatoPar(h, "Contacto", reserva.Cliente.Telefono + " · " + reserva.Cliente.Email);

			Seccion(h, "Período de alquiler");
			DatoPar(h, "Retiro", reserva.Desde.ToString("dd/MM/yyyy HH:mm"));
			DatoPar(h, "Devolución", reserva.Hasta.ToString("dd/MM/yyyy HH:mm"));
			DatoPar(h, "Reserva", reserva.Id + " · " + reserva.Estado);

			Seccion(h, "Equipos incluidos");
			List<string[]> filas = new List<string[]>();

			if (reserva.Equipos != null)
			{
				foreach (Equipo e in reserva.Equipos)
				{
					string poliza = e.Seguro == null ? "Sin póliza" : e.Seguro.Poliza;
					filas.Add(new[] { e.CodigoInventario, e.Marca + " " + e.Modelo, e.Serie, Dinero(e.TarifaDiaria), poliza });
				}
			}

			Tabla(h, new[] { "Código", "Equipo", "Serie", "Tarifa diaria", "Póliza" }, new double[] { 14, 30, 20, 20, 16 },
				filas, new[] { false, false, false, true, false });

			Seccion(h, "Importes");
			DatoPar(h, "Alquiler", Dinero(reserva.Importe));
			DatoPar(h, "Seña pagada", Dinero(reserva.Sena));

			if (reserva.Sena >= reserva.SenaRequerida && reserva.Sena > 0)
			{
				Parrafo(h, "Pago registrado: la reserva está firme.", true);
			}

			Seccion(h, "Conformidad");
			Parrafo(h, "El cliente declara recibir los equipos detallados, haberlos cotejado unidad por unidad y comprometerse a devolverlos en la fecha indicada y en el mismo estado.", false);
			h.Asegurar(90);
			h.Y += 50;
			h.Gfx.DrawLine(new XPen(Oscuro, 0.8), Margen, h.Y, Margen + 200, h.Y);
			h.Gfx.DrawLine(new XPen(Oscuro, 0.8), Margen + h.Ancho - 200, h.Y, Margen + h.Ancho, h.Y);
			h.Gfx.DrawString("Firma del cliente", new XFont("Arial", 9, XFontStyle.Regular), new XSolidBrush(Gris), new XPoint(Margen, h.Y + 14));
			h.Gfx.DrawString("Firma de stock", new XFont("Arial", 9, XFontStyle.Regular), new XSolidBrush(Gris), new XPoint(Margen + h.Ancho - 200, h.Y + 14));
			h.Cerrar(Carpeta(ruta));
			return ruta;
		}

		public string PropuestaEquipos(BriefProduccion brief, Propuesta propuesta, string ruta)
		{
			if (brief == null || propuesta == null)
			{
				throw new ArgumentException("No hay una propuesta para imprimir.");
			}

			Hoja h = new Hoja("Propuesta de equipamiento");
			h.Gfx.DrawString(propuesta.Nombre, new XFont("Arial", 18, XFontStyle.Bold), new XSolidBrush(Oscuro), new XPoint(Margen, h.Y + 14));
			h.Y += 30;

			Seccion(h, "Producción");
			DatoPar(h, "Tipo", brief.TipoPieza);
			DatoPar(h, "Fechas", brief.Desde.ToString("dd/MM/yyyy HH:mm") + " a " + brief.Hasta.ToString("dd/MM/yyyy HH:mm") + " (" + propuesta.Dias + " día(s))");
			DatoPar(h, "Equipo humano", brief.Personas + " persona(s) en cámara · " + brief.Camaras + " cámara(s)");
			DatoPar(h, "Locación y luz", brief.Locacion + " · luz " + brief.Luz.ToLower() + " · jornada de " + brief.HorasJornada + " h");
			DatoPar(h, "Presupuesto", Dinero(brief.Presupuesto));

			Seccion(h, "Equipos");
			List<string[]> filas = new List<string[]>();
			decimal total = propuesta.Total;
			string seccion = null;

			foreach (LineaPropuesta l in propuesta.Lineas)
			{
				if (l.Seccion != seccion)
				{
					seccion = l.Seccion;
					filas.Add(new[] { seccion });
				}

				filas.Add(new[] { l.Rol, l.Detalle, l.Gama, l.Subtotal.ToString("N2"), l.Aporta, l.Resigna });
			}

			Tabla(h, new[] { "Rol", "Equipo", "Gama", "Subtotal ARS", "Qué ganás", "Qué resignás" }, new double[] { 12, 20, 10, 12, 23, 23 },
				filas, new[] { false, false, false, true, false, false });

			h.Asegurar(60);
			DatoPar(h, "Total del alquiler", Dinero(total));
			decimal diferencia = total - brief.Presupuesto;

			if (diferencia <= 0)
			{
				DatoPar(h, "Presupuesto", "Dentro del presupuesto (sobran " + Dinero(-diferencia) + ")");
			}
			else
			{
				DatoPar(h, "Presupuesto", "Excede en " + Dinero(diferencia));
			}

			Seccion(h, "Seña y seguro");
			DatoPar(h, "Seña requerida", Dinero(propuesta.SenaRequerida));
			DatoPar(h, "Saldo restante del alquiler", Dinero(propuesta.Total - propuesta.SenaRequerida));
			Parrafo(h, propuesta.Seguro, false);

			if (propuesta.Notas != null && propuesta.Notas.Count > 0)
			{
				Seccion(h, "Observaciones");

				foreach (string nota in propuesta.Notas)
				{
					Parrafo(h, "· " + nota, false);
				}
			}

			Parrafo(h, "Los equipos están sujetos a disponibilidad al momento de enviar la solicitud de alquiler.", false);
			h.Cerrar(Carpeta(ruta));
			return ruta;
		}
	}
}
