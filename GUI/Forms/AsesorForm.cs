using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using BE;
using BLL;
using SERVICE;

namespace GUI
{
	// N03: el cliente cuenta su producción y recibe propuestas con equipos disponibles en sus fechas.
	public partial class AsesorForm : Form
	{
		private readonly AsesorBLL bll = new AsesorBLL();
		private ResultadoAsesoramiento resultado;
		private BriefProduccion consulta;
		private bool iniciando = true;
		private readonly Font negrita = new Font("Segoe UI", 9F, FontStyle.Bold);

		public AsesorForm()
		{
			InitializeComponent();
		}

		private BriefProduccion LeerBrief()
		{
			return new BriefProduccion
			{
				TipoPieza = Convert.ToString(tipoPieza.SelectedItem),
				Presupuesto = presupuesto.Value,
				Desde = desdeAsesor.Value,
				Hasta = hastaAsesor.Value,
				Personas = (int)personas.Value,
				Camaras = (int)camaras.Value,
				Locacion = Convert.ToString(locacion.SelectedItem),
				Luz = Convert.ToString(luz.SelectedItem),
				HorasJornada = (int)horas.Value,
				CamaraEnMovimiento = movimiento.Checked,
				SonidoDirecto = sonido.Checked,
				Monitoreo = monitoreo.Checked,
				LookCinematografico = cine.Checked
			};
		}

		private void Calcular()
		{
			try
			{
				consulta = LeerBrief();
				resultado = bll.Proponer(consulta);
				Mostrar();
			}
			catch (Exception ex)
			{
				resultado = null;
				resumen.ForeColor = Color.FromArgb(185, 28, 28);
				resumen.Text = ex.Message;
				propuestaRec.DataSource = new List<LineaPropuesta>();
				propuestaEco.DataSource = new List<LineaPropuesta>();
				complementos.DataSource = new List<LineaPropuesta>();
				notasRec.Text = "";
				notasEco.Text = "";
				lectura.Text = "";
				usarBoton.Enabled = false;
				imprimirBoton.Enabled = false;
				guardarPropuestaBoton.Enabled = false;
			}
		}

		private void Mostrar()
		{
			Propuesta rec = resultado.Recomendada;
			Propuesta eco = resultado.Economica;
			propuestaRec.DataSource = ConSecciones(rec.Lineas);
			propuestaEco.DataSource = ConSecciones(eco.Lineas);
			complementos.DataSource = ConSecciones(resultado.Complementos);
			complementos.ClearSelection();
			notasRec.Text = string.Join(Environment.NewLine, rec.Notas.ToArray());
			notasEco.Text = string.Join(Environment.NewLine, eco.Notas.ToArray());
			lectura.Text = string.Join(Environment.NewLine + Environment.NewLine, resultado.Lectura.ToArray());
			ActualizarResumen();
			recomendadaTab.Text = EtiquetaPestana("Configuración recomendada", rec);
			economicaTab.Text = EtiquetaPestana("Alternativa económica", eco);
			complementosTab.Text = "Complementos opcionales (" + resultado.Complementos.Count + ")";
			usarBoton.Enabled = rec.Lineas.Count > 0 || eco.Lineas.Count > 0;
			imprimirBoton.Enabled = usarBoton.Enabled;
			guardarPropuestaBoton.Enabled = usarBoton.Enabled;
		}

		// Una fila de encabezado por sección (Cámaras, Lentes, Iluminación...) para leer la lista más fácil.
		private List<LineaPropuesta> ConSecciones(List<LineaPropuesta> lineas)
		{
			List<LineaPropuesta> lista = new List<LineaPropuesta>();
			string seccion = null;

			foreach (LineaPropuesta l in lineas)
			{
				if (l.Seccion != seccion)
				{
					seccion = l.Seccion;
					lista.Add(new LineaPropuesta { Rol = "", Detalle = seccion.ToUpper(), Gama = "", Aporta = "", Resigna = "" });
				}

				lista.Add(l);
			}

			return lista;
		}

		private void FormatearSeccion(object sender, DataGridViewCellFormattingEventArgs e)
		{
			DataGridView grilla = (DataGridView)sender;

			if (e.RowIndex < 0)
			{
				return;
			}

			LineaPropuesta linea = grilla.Rows[e.RowIndex].DataBoundItem as LineaPropuesta;

			if (linea == null || linea.Equipo != null)
			{
				return;
			}

			e.CellStyle.BackColor = Color.FromArgb(219, 234, 254);
			e.CellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
			e.CellStyle.ForeColor = Color.FromArgb(15, 23, 42);
			e.CellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
			e.CellStyle.Font = negrita;

			if (grilla.Columns[e.ColumnIndex].DataPropertyName != "Detalle")
			{
				e.Value = "";
				e.FormattingApplied = true;
			}
		}

		private void ActualizarResumen()
		{
			if (resultado == null)
			{
				return;
			}

			Propuesta mostrada = PropuestaElegida();
			resumen.ForeColor = Color.FromArgb(15, 23, 42);
			resumen.Text = "Recomendada ARS "
				+ resultado.Recomendada.Total.ToString("N2")
				+ " · Económica ARS "
				+ resultado.Economica.Total.ToString("N2")
				+ " · Presupuesto ARS "
				+ mostrada.Presupuesto.ToString("N2")
				+ " · " + mostrada.Dias + " día(s)"
				+ Environment.NewLine
				+ "Para reservar esta propuesta: seña ARS "
				+ mostrada.SenaRequerida.ToString("N2")
				+ " (se descuenta del alquiler)"
				+ " · " + mostrada.Seguro.Split(':')[0];
		}

		private string EtiquetaPestana(string titulo, Propuesta propuesta)
		{
			if (propuesta.DentroDePresupuesto)
			{
				return titulo;
			}

			return titulo + " (excede)";
		}

		private void UsarClick(object sender, EventArgs e)
		{
			if (resultado == null)
			{
				return;
			}

			Propuesta elegida = PropuestaElegida();
			List<int> ids = new List<int>();

			foreach (LineaPropuesta linea in elegida.Lineas)
			{
				ids.Add(linea.Equipo.Id);
			}

			foreach (LineaPropuesta extra in ComplementosElegidos())
			{
				ids.Add(extra.Equipo.Id);
			}

			MenuPrincipalForm menu = null;

			if (Parent != null)
			{
				menu = Parent.FindForm() as MenuPrincipalForm;
			}

			if (menu == null)
			{
				MessageBox.Show(this, "No se pudo abrir la solicitud desde esta pantalla.", "Asesor de rodaje");
				return;
			}

			menu.IrASolicitud(consulta.Desde, consulta.Hasta, ids);
		}

		private Propuesta PropuestaElegida()
		{
			if (tabs.SelectedTab == economicaTab)
			{
				return resultado.Economica;
			}

			return resultado.Recomendada;
		}

		private List<LineaPropuesta> ComplementosElegidos()
		{
			List<LineaPropuesta> elegidos = new List<LineaPropuesta>();

			foreach (DataGridViewRow fila in complementos.SelectedRows)
			{
				LineaPropuesta extra = fila.DataBoundItem as LineaPropuesta;

				if (extra != null && extra.Equipo != null)
				{
					elegidos.Add(extra);
				}
			}

			return elegidos;
		}

		private void ImprimirClick(object sender, EventArgs e)
		{
			if (resultado == null)
			{
				return;
			}

			try
			{
				Propuesta elegida = PropuestaElegida();

				using (SaveFileDialog dialogo = new SaveFileDialog())
				{
					dialogo.Filter = "Documento PDF (*.pdf)|*.pdf";
					dialogo.FileName = "Propuesta-" + (elegida == resultado.Economica ? "economica" : "recomendada") + "-" + consulta.Desde.ToString("yyyyMMdd") + ".pdf";

					if (dialogo.ShowDialog(this) != DialogResult.OK)
					{
						return;
					}

					Propuesta completa = bll.Combinar(consulta, elegida, ComplementosElegidos());
					string ruta = new GeneradorPdf().PropuestaEquipos(consulta, completa, dialogo.FileName);
					Process.Start(ruta);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Imprimir propuesta");
			}
		}

		private void TabCambio(object sender, EventArgs e)
		{
			if (iniciando)
			{
				return;
			}

			ActualizarResumen();

			if (tabs.SelectedTab == guardadasTab)
			{
				CargarGuardadas();
			}
		}

		private void CargarGuardadas()
		{
			try
			{
				guardadas.DataSource = bll.ListarGuardadas();
				guardadas.ClearSelection();
				abrirGuardadaBoton.Enabled = false;
				eliminarGuardadaBoton.Enabled = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Mis propuestas");
			}
		}

		private PropuestaGuardada GuardadaSeleccionada()
		{
			if (guardadas.CurrentRow == null || !guardadas.CurrentRow.Selected)
			{
				return null;
			}

			return guardadas.CurrentRow.DataBoundItem as PropuestaGuardada;
		}

		private void GuardadaSeleccionCambio(object sender, EventArgs e)
		{
			bool hay = GuardadaSeleccionada() != null;
			abrirGuardadaBoton.Enabled = hay;
			eliminarGuardadaBoton.Enabled = hay;
		}

		private void GuardarPropuestaClick(object sender, EventArgs e)
		{
			if (resultado == null)
			{
				return;
			}

			try
			{
				Propuesta elegida = PropuestaElegida();
				string variante = elegida == resultado.Economica ? "Economica" : "Recomendada";
				string nombre = nombrePropuesta.Text;

				if (string.IsNullOrWhiteSpace(nombre))
				{
					nombre = consulta.TipoPieza + " " + consulta.Desde.ToString("dd/MM");
				}

				bll.Guardar(nombre, variante, elegida.Total, consulta);
				nombrePropuesta.Clear();
				MessageBox.Show(this, "Propuesta guardada. La encontrás en la pestaña Mis propuestas.", "Asesor de rodaje");
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Guardar propuesta");
			}
		}

		private void AbrirGuardadaClick(object sender, EventArgs e)
		{
			PropuestaGuardada guardada = GuardadaSeleccionada();

			if (guardada == null)
			{
				return;
			}

			BriefProduccion b = guardada.Brief;
			DateTime inicio = b.Desde;
			DateTime fin = b.Hasta;

			// Si las fechas guardadas ya pasaron, se conserva la duración y se corre al día siguiente.
			if (inicio.Date < DateTime.Today)
			{
				TimeSpan duracion = fin - inicio;
				inicio = DateTime.Today.AddDays(1).AddHours(9);
				fin = inicio + duracion;
			}

			iniciando = true;

			try
			{
				tipoPieza.SelectedItem = b.TipoPieza;
				presupuesto.Value = Math.Min(presupuesto.Maximum, Math.Max(presupuesto.Minimum, b.Presupuesto));
				horas.Value = b.HorasJornada;
				hastaAsesor.Value = fin;
				desdeAsesor.Value = inicio;
				hastaAsesor.Value = fin;
				personas.Value = b.Personas;
				camaras.Value = b.Camaras;
				locacion.SelectedItem = b.Locacion;
				luz.SelectedItem = b.Luz;
				movimiento.Checked = b.CamaraEnMovimiento;
				sonido.Checked = b.SonidoDirecto;
				monitoreo.Checked = b.Monitoreo;
				cine.Checked = b.LookCinematografico;
			}
			finally
			{
				iniciando = false;
			}

			Calcular();
			tabs.SelectedTab = guardada.Variante == "Economica" ? economicaTab : recomendadaTab;
		}

		private void AbrirGuardadaDoble(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				AbrirGuardadaClick(sender, e);
			}
		}

		private void EliminarGuardadaClick(object sender, EventArgs e)
		{
			PropuestaGuardada guardada = GuardadaSeleccionada();

			if (guardada == null)
			{
				return;
			}

			if (MessageBox.Show(this, "¿Eliminar la propuesta " + guardada.Nombre + "?", "Mis propuestas", MessageBoxButtons.OKCancel) != DialogResult.OK)
			{
				return;
			}

			try
			{
				bll.EliminarGuardada(guardada.Id);
				CargarGuardadas();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Mis propuestas");
			}
		}

		private void BriefCambio(object sender, EventArgs e)
		{
			if (!iniciando)
			{
				Calcular();
			}
		}

		private void AsesorForm_Load(object sender, EventArgs e)
		{
			CargarPantalla();
		}

		private void CargarPantalla()
		{
			DateTime inicio = DateTime.Today.AddDays(1).AddHours(9);
			desdeAsesor.Value = inicio;
			hastaAsesor.Value = inicio.AddDays(1);
			tipoPieza.SelectedIndex = 0;
			locacion.SelectedIndex = 0;
			luz.SelectedIndex = 1;
			sonido.Checked = true;
			iniciando = false;
			Calcular();
		}
	}
}
