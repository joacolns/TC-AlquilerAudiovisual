using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using BE;
using BLL;
using SERVICE;

namespace GUI
{
	public partial class DevolucionesForm : Form
	{
		private readonly DevolucionBLL bll = new DevolucionBLL();
		private readonly ReservaBLL reservas = new ReservaBLL();
		private readonly Seguridad seguridad = new Seguridad();
		private bool cargando;

		public DevolucionesForm()
		{
			InitializeComponent();
		}

		public void RegistrarDevolucion()
		{
			try
			{
				Reserva seleccionada = reserva.SelectedItem as Reserva;

				if (seleccionada == null || !cotejo.Checked)
				{
					throw new ArgumentException("Seleccioná un remito y confirmá el cotejo de todas las unidades.");
				}

				Devolucion devolucion = new Devolucion
				{
					Reserva = seleccionada,
					ReservaId = seleccionada.Id,
					Fecha = fecha.Value,
					Conforme = conforme.Checked,
					ClientePresente = presente.Checked,
					Observaciones = observaciones.Text
				};
				int id = bll.Registrar(devolucion);

				if (devolucion.Conforme)
				{
					MessageBox.Show(
						this,
						"Devolución " + id + " cerrada. Garantía a devolver: ARS " + devolucion.GarantiaDevuelta.ToString("N2")
					);
				}
				else
				{
					MessageBox.Show(
						this,
						"Devolución "
							+ id
							+ " registrada. Completá los hallazgos y finalizá la inspección antes de devolver la garantía."
					);
				}

				cotejo.Checked = false;
				observaciones.Clear();
				Cargar(id);

				if (!devolucion.Conforme)
				{
					tabs.SelectedTab = inspeccionTab;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Devolución");
			}
		}

		public void RegistrarIncidencia()
		{
			try
			{
				int id = bll.RegistrarIncidencia(LeerIncidencia());
				MessageBox.Show(
					this,
					"Incidencia " + id + " registrada. La garantía sigue pendiente hasta finalizar la inspección."
				);
				descripcion.Clear();
				Cargar(IdSeleccionado());
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Incidencia");
			}
		}

		public void FinalizarInspeccion()
		{
			try
			{
				int id = IdSeleccionado();

				if (id == 0)
				{
					throw new ArgumentException("Seleccioná una devolución.");
				}

				DialogResult respuesta = MessageBox.Show(
					this,
					"¿Registraste todos los hallazgos y los atrasos de cada unidad? Al finalizar no se podrán agregar incidencias.",
					"Finalizar inspección",
					MessageBoxButtons.OKCancel
				);

				if (respuesta != DialogResult.OK)
				{
					return;
				}

				if (!bll.Finalizar(id))
				{
					throw new InvalidOperationException("La inspección ya estaba finalizada. La liquidación no se volvió a registrar.");
				}

				Cargar(id);
				MessageBox.Show(
					this,
					"Inspección finalizada. Revisá la liquidación definitiva y entregá el remanente una sola vez."
				);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Inspección");
			}
		}

		public void DarAltaTecnica()
		{
			try
			{
				Incidencia seleccionada = null;

				if (tecnicas.CurrentRow != null)
				{
					seleccionada = tecnicas.CurrentRow.DataBoundItem as Incidencia;
				}

				if (seleccionada == null || !apta.Checked)
				{
					throw new ArgumentException("Seleccioná una incidencia y confirmá que la unidad fue recuperada o reparada y está apta.");
				}

				if (!bll.DarAltaTecnica(seleccionada.Id))
				{
					throw new InvalidOperationException("La incidencia no existe o ya estaba cerrada.");
				}

				apta.Checked = false;
				Cargar(IdSeleccionado());
				MessageBox.Show(this, "Alta técnica registrada. La unidad se habilita cuando no quedan otros bloqueos.");
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Alta técnica");
			}
		}

		private Incidencia LeerIncidencia()
		{
			Devolucion seleccionada = devolucion.SelectedItem as Devolucion;
			Equipo unidad = equipo.SelectedItem as Equipo;
			return new Incidencia
			{
				Devolucion = seleccionada,
				Equipo = unidad,
				Tipo = Convert.ToString(tipo.SelectedItem),
				Descripcion = descripcion.Text
			};
		}

		private int IdSeleccionado()
		{
			Devolucion seleccionada = devolucion.SelectedItem as Devolucion;

			if (seleccionada == null)
			{
				return 0;
			}

			return seleccionada.Id;
		}

		private void Cargar(int devolucionId)
		{
			cargando = true;

			try
			{
				if (seguridad.TienePermiso("Devolucion.Registrar"))
				{
					List<Reserva> entregadas = new List<Reserva>();

					foreach (Reserva actual in reservas.Listar())
					{
						if (actual.Estado == "Entregada")
						{
							entregadas.Add(actual);
						}
					}

					reserva.DataSource = entregadas;
					devolucion.DataSource = bll.Listar();

					for (int i = 0; i < devolucion.Items.Count; i++)
					{
						if (((Devolucion)devolucion.Items[i]).Id == devolucionId)
						{
							devolucion.SelectedIndex = i;
							break;
						}
					}
				}

				if (seguridad.TienePermiso("Incidencia.AltaTecnica"))
				{
					tecnicas.DataSource = bll.ListarIncidencias(null);
				}
			}
			finally
			{
				cargando = false;
			}

			MostrarRemito();

			if (seguridad.TienePermiso("Incidencia.Registrar"))
			{
				CargarInspeccion();
			}

			MostrarTecnica();
		}

		private void MostrarRemito()
		{
			Reserva seleccionada = reserva.SelectedItem as Reserva;
			remito.Clear();

			if (seleccionada == null)
			{
				return;
			}

			StringBuilder texto = new StringBuilder();
			texto.AppendLine("REMITO " + seleccionada.NumeroRemito + " · Cliente: " + seleccionada.Cliente.Nombre);
			texto.AppendLine(
				"Hasta: "
					+ seleccionada.Hasta.ToString("dd/MM/yyyy HH:mm")
					+ " · Garantía ARS "
					+ seleccionada.Garantia.ToString("N2")
			);
			texto.AppendLine("Cotejá físicamente todas estas unidades. Estado registrado al entregar: Disponible.");

			foreach (Equipo unidad in seleccionada.Equipos)
			{
				texto.AppendLine(unidad.CodigoInventario + " · " + unidad.Marca + " " + unidad.Modelo + " · serie " + unidad.Serie);
			}

			remito.Text = texto.ToString();
		}

		private void CargarInspeccion()
		{
			Devolucion seleccionada = devolucion.SelectedItem as Devolucion;

			if (seleccionada == null)
			{
				equipo.DataSource = new List<Equipo>();
				incidencias.DataSource = new List<Incidencia>();
				liquidacion.Text = "Seleccioná una devolución para registrar los hallazgos.";
				incidenciaBoton.Enabled = false;
				finalizarBoton.Enabled = false;
				cargoBoton.Enabled = false;
				return;
			}

			equipo.DataSource = seleccionada.Reserva.Equipos;

			if (seleccionada.Reserva.Equipos.Count > 1)
			{
				equipo.SelectedIndex = -1;
			}

			incidencias.DataSource = bll.ListarIncidencias(seleccionada.Id);
			incidenciaBoton.Enabled = !seleccionada.Finalizada;
			finalizarBoton.Enabled = !seleccionada.Finalizada;
			cargoBoton.Enabled = !seleccionada.Finalizada;
			string estado;

			if (seleccionada.Finalizada)
			{
				estado = "LIQUIDACIÓN DEFINITIVA · Inspección finalizada. ";
			}
			else
			{
				estado = "PROVISORIO · No devolver garantía hasta completar todos los hallazgos y finalizar. ";
			}

			liquidacion.Text = estado
				+ "Aplicada ARS "
				+ seleccionada.GarantiaAplicada.ToString("N2")
				+ " · A devolver ARS "
				+ seleccionada.GarantiaDevuelta.ToString("N2")
				+ " · Deuda ARS "
				+ seleccionada.SaldoPendiente.ToString("N2")
				+ " · Fecha de devolución "
				+ seleccionada.Fecha.ToString("dd/MM/yyyy HH:mm");
			CargoCambio(this, EventArgs.Empty);
		}

		private void MostrarTecnica()
		{
			apta.Checked = false;
			detalleTecnico.Clear();

			if (tecnicas.CurrentRow == null)
			{
				return;
			}

			Incidencia seleccionada = tecnicas.CurrentRow.DataBoundItem as Incidencia;

			if (seleccionada == null)
			{
				return;
			}

			StringBuilder texto = new StringBuilder();
			texto.AppendLine(
				seleccionada.Equipo.CodigoInventario + " · serie " + seleccionada.Equipo.Serie + " · " + seleccionada.Tipo
			);
			texto.AppendLine(seleccionada.Descripcion);
			texto.AppendLine("Devolución: " + seleccionada.Devolucion.Fecha.ToString("dd/MM/yyyy HH:mm"));
			texto.AppendLine("Podés dar el alta en cuanto la unidad esté recuperada o reparada y apta, sin esperar días.");

			if (!seleccionada.Devolucion.Finalizada)
			{
				texto.AppendLine("Stock todavía debe finalizar la inspección.");
			}

			detalleTecnico.Text = texto.ToString();
		}

		private bool EnDiseno()
		{
			return DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime;
		}

		private void PrepararPantalla(object sender, EventArgs e)
		{
			if (EnDiseno())
			{
				return;
			}

			fecha.Value = DateTime.Now;

			if (!seguridad.TienePermiso("Devolucion.Registrar"))
			{
				tabs.TabPages.Remove(devolucionTab);
				tabs.TabPages.Remove(inspeccionTab);
			}

			if (!seguridad.TienePermiso("Incidencia.AltaTecnica"))
			{
				tabs.TabPages.Remove(tecnicaTab);
			}
		}

		private void CargarClick(object sender, EventArgs e)
		{
			if (EnDiseno())
			{
				return;
			}

			try
			{
				Cargar(IdSeleccionado());
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "No se pudo actualizar");
			}
		}

		private void ReservaCambio(object sender, EventArgs e)
		{
			if (!EnDiseno() && !cargando)
			{
				cotejo.Checked = false;
				MostrarRemito();
			}
		}

		private void DevolucionCambio(object sender, EventArgs e)
		{
			if (EnDiseno() || cargando)
			{
				return;
			}

			try
			{
				CargarInspeccion();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Inspección");
			}
		}

		private void CargoCambio(object sender, EventArgs e)
		{
			if (cargo == null)
			{
				return;
			}

			cargo.Text = "Faltante: 100% del valor; reparable: 20%; total: 80%. Atraso: 10% del alquiler del equipo por día. Elegí el equipo afectado y calculá el cargo.";
		}

		private void CargoClick(object sender, EventArgs e)
		{
			try
			{
				Incidencia incidencia = LeerIncidencia();
				decimal importe = bll.CalcularCargo(incidencia);
				string detalle = "Sin seguro válido para este alquiler.";

				Seguro seguro = incidencia.Equipo.Seguro;

				if (seguro != null
					&& seguro.ClienteId == incidencia.Devolucion.Reserva.ClienteId
					&& seguro.Desde <= incidencia.Devolucion.Reserva.Desde
					&& seguro.Hasta >= incidencia.Devolucion.Reserva.Hasta)
				{
					detalle = "Seguro " + seguro.Tipo + ": " + seguro.Detalle;
				}

				if (incidencia.Tipo == "Atraso")
				{
					detalle = "El seguro no cubre atrasos. " + detalle;
				}

				cargo.Text = "Cargo base ARS "
					+ incidencia.CargoBase.ToString("N2")
					+ " · Descuento seguro ARS "
					+ incidencia.DescuentoSeguro.ToString("N2")
					+ " · A pagar ARS "
					+ importe.ToString("N2")
					+ Environment.NewLine
					+ detalle;
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Cargo");
			}
		}

		private void FormatearReserva(object sender, ListControlConvertEventArgs e)
		{
			Reserva actual = e.ListItem as Reserva;

			if (actual != null)
			{
				e.Value = actual.NumeroRemito + " · " + actual.Cliente.Nombre;
			}
		}

		private void FormatearDevolucion(object sender, ListControlConvertEventArgs e)
		{
			Devolucion actual = e.ListItem as Devolucion;

			if (actual != null)
			{
				string estado = "En inspección";

				if (actual.Finalizada)
				{
					estado = "Finalizada";
				}

				e.Value = "Devolución " + actual.Id + " · reserva " + actual.ReservaId + " · " + estado;
			}
		}

		private void FormatearEquipo(object sender, ListControlConvertEventArgs e)
		{
			Equipo actual = e.ListItem as Equipo;

			if (actual != null)
			{
				e.Value = actual.CodigoInventario + " · " + actual.Marca + " " + actual.Modelo + " · serie " + actual.Serie;
			}
		}

		private void FormatearUnidad(object sender, DataGridViewCellFormattingEventArgs e)
		{
			DataGridView grilla = sender as DataGridView;

			if (e.RowIndex < 0 || grilla.Columns[e.ColumnIndex].DataPropertyName != "EquipoId")
			{
				return;
			}

			Incidencia actual = grilla.Rows[e.RowIndex].DataBoundItem as Incidencia;

			if (actual != null && actual.Equipo != null)
			{
				e.Value = actual.Equipo.CodigoInventario;
				e.FormattingApplied = true;
			}
		}

		private void TecnicaCambio(object sender, EventArgs e)
		{
			if (!EnDiseno() && !cargando)
			{
				MostrarTecnica();
			}
		}

		private void RegistrarClick(object sender, EventArgs e)
		{
			RegistrarDevolucion();
		}

		private void IncidenciaClick(object sender, EventArgs e)
		{
			RegistrarIncidencia();
		}

		private void FinalizarClick(object sender, EventArgs e)
		{
			FinalizarInspeccion();
		}

		private void AltaClick(object sender, EventArgs e)
		{
			DarAltaTecnica();
		}
	}
}
