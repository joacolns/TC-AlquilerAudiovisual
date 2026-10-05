using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BE;
using BLL;
using SERVICE;

namespace GUI
{
	public partial class ReservasForm : Form
	{
		private readonly ReservaBLL bll = new ReservaBLL();
		private readonly ClienteBLL clientes = new ClienteBLL();
		private readonly EquipoBLL equipos = new EquipoBLL();
		private readonly Seguridad seguridad = new Seguridad();

		public ReservasForm()
		{
			InitializeComponent();
		}

		public void Cotizar()
		{
			try
			{
				Reserva consulta;

				if (tabs.SelectedTab == gestionTab)
				{
					Reserva seleccionada = SeleccionarPendiente();
					consulta = new Reserva
					{
						Cliente = seleccionada.Cliente,
						ClienteId = seleccionada.ClienteId,
						Desde = seleccionada.Desde,
						Hasta = seleccionada.Hasta,
						Equipos = seleccionada.Equipos
					};
				}
				else
				{
					consulta = LeerReserva();
				}

				bll.Cotizar(consulta);
				string resumen = "Total ARS "
					+ consulta.Importe.ToString("N2")
					+ " · seña requerida "
					+ consulta.Sena.ToString("N2")
					+ " · garantía requerida "
					+ consulta.Garantia.ToString("N2");

				if (tabs.SelectedTab == gestionTab)
				{
					revision.Text = resumen;
				}
				else
				{
					cotizacion.Text = resumen;
				}
			}
			catch (Exception ex)
			{
				cotizacion.Text = "No se pudo cotizar.";
				MessageBox.Show(this, ex.Message, "Cotización");
			}
		}

		public void Solicitar()
		{
			try
			{
				int id = bll.Solicitar(LeerReserva());
				MessageBox.Show(
					this,
					"Solicitud " + id + " enviada a stock. Estado: Pendiente. Todavía no es una reserva firme.",
					"Solicitud enviada"
				);
				cotizacion.Text = "Solicitud " + id + " enviada. Consultá su estado en Solicitudes y reservas.";
				Actualizar();
				Disponibles();
				tabs.SelectedTab = gestionTab;
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Resultado de la solicitud");
			}
		}

		public void Confirmar()
		{
			try
			{
				Reserva seleccionada = SeleccionarPendiente();
				Reserva reserva = new Reserva
				{
					Id = seleccionada.Id,
					Sena = sena.Value,
					Garantia = garantia.Value
				};
				int id = bll.Confirmar(reserva);
				// Informar el éxito confirmado antes de recargar consultas independientes.
				MessageBox.Show(this, "Solicitud " + id + " aceptada. La reserva quedó Firme.", "Confirmación");
				sena.Value = 0;
				garantia.Value = 0;
				revision.Text = "Reserva " + id + " confirmada.";
				Actualizar();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Resultado de la operación");
			}
		}

		public void RegistrarEntrega()
		{
			try
			{
				Reserva actual = null;

				if (reservas.CurrentRow != null)
				{
					actual = reservas.CurrentRow.DataBoundItem as Reserva;
				}

				if (actual == null)
				{
					throw new ArgumentException("Seleccioná una reserva.");
				}

				if (!cotejo.Checked || !firma.Checked)
				{
					throw new ArgumentException("Completá la revisión física con el cliente y la firma de ambos documentos.");
				}

				if (!bll.RegistrarEntrega(actual.Id))
				{
					throw new InvalidOperationException("La reserva no está firme o ya fue entregada.");
				}

				MessageBox.Show(this, "Entrega registrada. Contrato C-" + actual.Id + " · remito R-" + actual.Id);
				cotejo.Checked = false;
				firma.Checked = false;
				Actualizar();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Resultado de la entrega");
			}
		}

		private Reserva LeerReserva()
		{
			Cliente seleccionado = cliente.SelectedItem as Cliente;
			List<Equipo> seleccion = new List<Equipo>();

			foreach (object item in unidades.CheckedItems)
			{
				seleccion.Add((Equipo)item);
			}

			int clienteId;

			if (seleccionado == null)
			{
				clienteId = 0;
			}
			else
			{
				clienteId = seleccionado.Id;
			}

			return new Reserva
			{
				Cliente = seleccionado,
				ClienteId = clienteId,
				Desde = desde.Value,
				Hasta = hasta.Value,
				Equipos = seleccion
			};
		}

		private void Disponibles()
		{
			unidades.Items.Clear();

			foreach (Equipo equipo in equipos.ListarDisponibles(desde.Value, hasta.Value))
			{
				unidades.Items.Add(equipo);
			}
		}

		private void Actualizar()
		{
			reservas.DataSource = bll.Listar();
		}

		private Reserva SeleccionarPendiente()
		{
			Reserva actual = null;

			if (reservas.CurrentRow != null)
			{
				actual = reservas.CurrentRow.DataBoundItem as Reserva;
			}

			if (actual == null || actual.Estado != "Pendiente")
			{
				throw new ArgumentException("Seleccioná una solicitud con estado Pendiente.");
			}

			return actual;
		}

		private void ReservaCambio(object sender, EventArgs e)
		{
			cotejo.Checked = false;
			firma.Checked = false;
			sena.Value = 0;
			garantia.Value = 0;
			revision.Text = "Seleccioná una solicitud pendiente y cotizala antes de aceptar.";
			Reserva actual = null;

			if (reservas.CurrentRow != null)
			{
				actual = reservas.CurrentRow.DataBoundItem as Reserva;
			}

			if (actual == null)
			{
				detalle.Clear();
				return;
			}

			StringBuilder texto = new StringBuilder();

			if (actual.Estado == "Pendiente")
			{
				texto.AppendLine("SOLICITUD PENDIENTE DE REVISIÓN POR STOCK · Los equipos todavía no están reservados.");
			}
			else if (actual.Estado == "Firme")
			{
				texto.AppendLine("BORRADOR DE CONTRATO / REMITO · Pendiente de firma y entrega");
			}
			else
			{
				texto.AppendLine("CONTRATO " + actual.NumeroContrato + " / REMITO " + actual.NumeroRemito);
			}

			texto.AppendLine("Reserva " + actual.Id + " · " + actual.Estado + " · Firmado: " + actual.ContratoFirmado);
			texto.AppendLine("Cliente: " + actual.Cliente.Nombre + " · DNI/CUIT: " + actual.Cliente.DniCuit);
			texto.AppendLine("Contacto: " + actual.Cliente.Telefono + " · " + actual.Cliente.Email);
			texto.AppendLine(
				"Desde " + actual.Desde.ToString("dd/MM/yyyy HH:mm") + " hasta " + actual.Hasta.ToString("dd/MM/yyyy HH:mm")
			);
			texto.AppendLine(
				"Importe ARS "
					+ actual.Importe.ToString("N2")
					+ " · Seña ARS "
					+ actual.Sena.ToString("N2")
					+ " · Garantía ARS "
					+ actual.Garantia.ToString("N2")
			);

			if (actual.Estado == "Pendiente")
			{
				texto.AppendLine("Unidades solicitadas. El importe es estimado; stock vuelve a cotizar al aceptar:");
			}
			else if (actual.Estado == "Firme")
			{
				texto.AppendLine("Unidades a cotejar antes de entregar:");
			}
			else
			{
				texto.AppendLine("Unidades entregadas (estado de entrega registrado: Disponible):");
			}

			foreach (Equipo equipo in actual.Equipos)
			{
				string poliza;

				if (equipo.Seguro == null)
				{
					poliza = "Sin póliza asignada";
				}
				else
				{
					poliza = equipo.Seguro.Poliza;
				}

				texto.AppendLine(
					equipo.CodigoInventario
						+ " · "
						+ equipo.Marca
						+ " "
						+ equipo.Modelo
						+ " · serie "
						+ equipo.Serie
						+ " · tarifa "
						+ equipo.TarifaDiaria.ToString("N2")
						+ " · póliza "
						+ poliza
				);
			}

			detalle.Text = texto.ToString();
		}

		private void CotizarClick(object sender, EventArgs e)
		{
			Cotizar();
		}

		private void ConfirmarClick(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void SolicitarClick(object sender, EventArgs e)
		{
			Solicitar();
		}

		private void FormatearEquipo(object sender, ListControlConvertEventArgs e)
		{
			Equipo equipo = e.ListItem as Equipo;

			if (equipo != null)
			{
				e.Value = equipo.CodigoInventario
					+ " · "
					+ equipo.Marca
					+ " "
					+ equipo.Modelo
					+ " · ARS "
					+ equipo.TarifaDiaria.ToString("N2")
					+ " por día";
			}
		}

		private void FormatearCliente(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex < 0 || reservas.Columns[e.ColumnIndex].DataPropertyName != "ClienteId")
			{
				return;
			}

			Reserva actual = reservas.Rows[e.RowIndex].DataBoundItem as Reserva;

			if (actual != null && actual.Cliente != null)
			{
				e.Value = actual.Cliente.Nombre;
				e.FormattingApplied = true;
			}
		}

		private void EntregaClick(object sender, EventArgs e)
		{
			RegistrarEntrega();
		}

		private void DisponiblesClick(object sender, EventArgs e)
		{
			try
			{
				Disponibles();
				cotizacion.Text = "Selección nueva: volvé a cotizar.";
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message);
			}
		}

		private void ActualizarClick(object sender, EventArgs e)
		{
			try
			{
				Actualizar();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message);
			}
		}

		private void CargarClick(object sender, EventArgs e)
		{
			if (DesignMode
				|| System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
			{
				return;
			}

			try
			{
				cliente.DataSource = clientes.Listar();
				Disponibles();
				Actualizar();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message);
				Close();
			}
		}

		private void PrepararPantalla(object sender, EventArgs e)
		{
			if (DesignMode
				|| System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
			{
				return;
			}

			desde.Value = DateTime.Today;
			hasta.Value = DateTime.Today.AddDays(1);

			if (!seguridad.TienePermiso("Reserva.Solicitar"))
			{
				tabs.TabPages.Remove(solicitudTab);
			}

			aprobacion.Visible = seguridad.TienePermiso("Reserva.Confirmar");
			bool puedeEntregar = seguridad.TienePermiso("Reserva.Entregar");
			registrarBoton.Enabled = puedeEntregar;
			registrarBoton.Visible = puedeEntregar;
			cotejo.Enabled = puedeEntregar;
			cotejo.Visible = puedeEntregar;
			firma.Enabled = puedeEntregar;
			firma.Visible = puedeEntregar;

			if (!puedeEntregar)
			{
				entrega.Height = 55;
			}
		}
	}
}
