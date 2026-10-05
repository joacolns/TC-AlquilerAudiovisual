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
		private bool cargandoUnidades;
		private List<Reserva> reservasActuales = new List<Reserva>();

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
				string resumen = ResumenImportes(consulta);

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
				Reserva consulta = LeerReserva();
				int id = bll.Solicitar(consulta);
				MessageBox.Show(
					this,
					"Solicitud "
						+ id
						+ " enviada a stock. Estado: Pendiente."
						+ Environment.NewLine
						+ ResumenImportes(consulta)
						+ Environment.NewLine
						+ "Todavía no se registraron pagos ni una reserva firme.",
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
					Id = seleccionada.Id
				};
				int id = bll.Confirmar(reserva);
				// Informar el éxito confirmado antes de recargar consultas independientes.
				MessageBox.Show(this, "Solicitud " + id + " aceptada. El cliente debe pagar la seña y la garantía.", "Aceptación");
				Actualizar();
				avisoActualizacion.Text = "Solicitud " + id + " aceptada. Pendiente del pago del cliente.";
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Resultado de la operación");
			}
		}

		public void Pagar()
		{
			try
			{
				Reserva actual = null;

				if (reservas.CurrentRow != null)
				{
					actual = reservas.CurrentRow.DataBoundItem as Reserva;
				}

				if (actual == null || actual.Estado != "Aceptada")
				{
					throw new ArgumentException("Seleccioná una solicitud aceptada y pendiente de pago.");
				}

				if (!bll.Pagar(actual.Id))
				{
					throw new InvalidOperationException("No se registró el pago. Actualizá la lista.");
				}

				MessageBox.Show(this, "Seña y garantía pagadas. Stock ya puede entregar los equipos.", "Pago registrado");
				Actualizar();
				avisoActualizacion.Text = "Pago de la solicitud " + actual.Id + " registrado. Pendiente de entrega por stock.";
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Pagar seña y garantía");
			}
		}

		public void Rechazar()
		{
			try
			{
				Reserva seleccionada = SeleccionarPendiente();

				if (!bll.Rechazar(seleccionada.Id))
				{
					throw new InvalidOperationException("La solicitud ya fue procesada. Actualizá la lista.");
				}

				Actualizar();
				reservas.ClearSelection();
				reservas.CurrentCell = null;
				detalle.Clear();
				revision.Text = "Solicitud " + seleccionada.Id + " rechazada. Seleccioná otro pedido de la lista.";
				reservas.Focus();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Rechazar solicitud");
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
					throw new InvalidOperationException("La reserva debe estar pagada y pendiente de entrega.");
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
				seleccion.Add(((Reserva)item).Equipos[0]);
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
			List<Reserva> cotizaciones = new List<Reserva>();

			foreach (Equipo equipo in equipos.ListarDisponibles(desde.Value, hasta.Value))
			{
				cotizaciones.Add(CotizacionEquipo(equipo, desde.Value, hasta.Value));
			}

			cargandoUnidades = true;

			try
			{
				unidades.Items.Clear();

				foreach (Reserva consulta in cotizaciones)
				{
					unidades.Items.Add(consulta);
				}
			}
			finally
			{
				cargandoUnidades = false;
			}

			cotizacion.Text = "Cada equipo muestra el alquiler, la seña y la garantía para las fechas elegidas.";
			cotizarBoton.Enabled = false;
			solicitarBoton.Enabled = false;
		}

		private Reserva CotizacionEquipo(Equipo equipo, DateTime inicio, DateTime fin)
		{
			Reserva consulta = new Reserva
			{
				Desde = inicio,
				Hasta = fin,
				Equipos = new List<Equipo>
				{
					equipo
				}
			};
			bll.CalcularImportes(consulta);
			return consulta;
		}

		private string ResumenImportes(Reserva consulta)
		{
			return "Alquiler ARS "
				+ consulta.Importe.ToString("N2")
				+ " · seña requerida ARS "
				+ consulta.SenaRequerida.ToString("N2")
				+ " · garantía requerida ARS "
				+ consulta.GarantiaRequerida.ToString("N2");
		}

		private void Actualizar()
		{
			MostrarReservas(bll.Listar());
			actualizacionTimer.Start();
		}

		private void MostrarReservas(List<Reserva> lista)
		{
			Reserva seleccionada = null;

			if (reservas.CurrentRow != null)
			{
				seleccionada = reservas.CurrentRow.DataBoundItem as Reserva;
			}

			bool cotejoAnterior = cotejo.Checked;
			bool firmaAnterior = firma.Checked;
			string revisionAnterior = revision.Text;
			reservasActuales = lista;
			reservas.DataSource = lista;
			reservas.Columns["Sena"].HeaderText = "Seña pagada ARS";
			reservas.Columns["Garantia"].HeaderText = "Garantía pagada ARS";
			reservas.Columns["Sena"].DefaultCellStyle.Format = "N2";
			reservas.Columns["Garantia"].DefaultCellStyle.Format = "N2";
			reservas.Columns["Estado"].HeaderText = "Estado del pedido";
			reservas.Columns["Id"].DisplayIndex = 0;
			reservas.Columns["ClienteId"].DisplayIndex = 1;
			reservas.Columns["Estado"].DisplayIndex = 2;

			if (reservas.Columns.Contains("Cliente"))
			{
				reservas.Columns["Cliente"].Visible = false;
			}

			if (reservas.Columns.Contains("Equipos"))
			{
				reservas.Columns["Equipos"].Visible = false;
			}

			if (seleccionada != null)
			{
				foreach (DataGridViewRow fila in reservas.Rows)
				{
					Reserva actual = fila.DataBoundItem as Reserva;

					if (actual != null && actual.Id == seleccionada.Id)
					{
						reservas.CurrentCell = fila.Cells["Id"];
						fila.Selected = true;

						if (actual.Estado == seleccionada.Estado)
						{
							cotejo.Checked = cotejoAnterior;
							firma.Checked = firmaAnterior;
							revision.Text = revisionAnterior;
						}

						break;
					}
				}
			}
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
			revision.Text = "Seleccioná una solicitud pendiente y cotizala antes de aceptar.";
			Reserva actual = null;

			if (reservas.CurrentRow != null)
			{
				actual = reservas.CurrentRow.DataBoundItem as Reserva;
			}

			bool puedeRevisar = actual != null && actual.Estado == "Pendiente" && seguridad.TienePermiso("Reserva.Confirmar");
			revisarBoton.Enabled = puedeRevisar;
			aceptarBoton.Enabled = puedeRevisar;
			rechazarBoton.Enabled = puedeRevisar;
			pagarBoton.Enabled = actual != null && actual.Estado == "Aceptada" && seguridad.TienePermiso("Reserva.Pagar");
			registrarBoton.Enabled = actual != null && actual.Estado == "Firme" && seguridad.TienePermiso("Reserva.Entregar");
			pagoEstado.Text = "Seleccioná una solicitud aceptada para pagar la seña y la garantía.";

			if (actual == null)
			{
				detalle.Clear();
				return;
			}

			StringBuilder texto = new StringBuilder();

			if (actual.Estado == "Aceptada")
			{
				pagoEstado.Text = "Solicitud aceptada. Seña ARS "
					+ actual.SenaRequerida.ToString("N2")
					+ " · garantía ARS "
					+ actual.GarantiaRequerida.ToString("N2")
					+ " · total a pagar ARS "
					+ (actual.SenaRequerida
					+ actual.GarantiaRequerida).ToString("N2");
			}
			else if (actual.Estado == "Pendiente")
			{
				pagoEstado.Text = "Stock está revisando tu solicitud. Podrás pagar cuando la acepte.";
			}
			else if (actual.Estado == "Firme")
			{
				pagoEstado.Text = "Pago registrado. Stock ya puede entregar los equipos.";
			}
			else if (actual.Estado == "Rechazada")
			{
				pagoEstado.Text = "Stock rechazó el pedido. Podés enviar otra solicitud.";
			}
			else
			{
				pagoEstado.Text = "El pago de esta reserva ya fue registrado.";
			}

			if (actual.Estado == "Pendiente")
			{
				texto.AppendLine("SOLICITUD PENDIENTE DE REVISIÓN POR STOCK · Los equipos todavía no están reservados.");
			}
			else if (actual.Estado == "Rechazada")
			{
				texto.AppendLine(
					"SOLICITUD RECHAZADA POR STOCK · No reserva ni bloquea equipos. El cliente puede enviar otro pedido."
				);
			}
			else if (actual.Estado == "Aceptada")
			{
				texto.AppendLine("SOLICITUD ACEPTADA · Pendiente del pago de seña y garantía por el cliente.");
			}
			else if (actual.Estado == "Firme")
			{
				texto.AppendLine("RESERVA PAGADA · Pendiente de cotejo, firma y entrega por stock.");
			}
			else
			{
				texto.AppendLine("CONTRATO " + actual.NumeroContrato + " / REMITO " + actual.NumeroRemito);
			}

			texto.AppendLine("Reserva " + actual.Id + " · " + actual.Estado + " · Firmado: " + actual.ContratoFirmado);
			texto.AppendLine("Cliente: " + actual.Cliente.Nombre + " · DNI/CUIT: " + actual.Cliente.DniCuit);
			texto.AppendLine("Antecedentes del cliente:");
			texto.AppendLine(AntecedentesCliente(actual.Cliente));

			if (actual.Estado == "Pendiente")
			{
				texto.AppendLine(
					"Seguro actual del cliente: " + TipoSeguroReserva(actual) + ". Stock verifica la vigencia al aceptar."
				);
			}
			else if (actual.Estado == "Rechazada")
			{
				texto.AppendLine("Seguro registrado al solicitar: " + TipoSeguroReserva(actual));
			}
			else
			{
				texto.AppendLine("Seguro pactado: " + TipoSeguroReserva(actual));
			}

			texto.AppendLine("Contacto: " + actual.Cliente.Telefono + " · " + actual.Cliente.Email);
			texto.AppendLine(
				"Desde " + actual.Desde.ToString("dd/MM/yyyy HH:mm") + " hasta " + actual.Hasta.ToString("dd/MM/yyyy HH:mm")
			);
			texto.AppendLine(ResumenImportes(actual));

			if (actual.Estado == "Pendiente" || actual.Estado == "Rechazada")
			{
				texto.AppendLine("Todavía no se recibieron pagos. Los importes requeridos se muestran arriba.");
			}
			else if (actual.Estado == "Aceptada")
			{
				texto.AppendLine("Seña y garantía pendientes de pago. Stock entregará los equipos después del pago.");
			}
			else
			{
				texto.AppendLine(
					"Seña pagada ARS " + actual.Sena.ToString("N2") + " · Garantía pagada ARS " + actual.Garantia.ToString("N2")
				);
			}

			if (actual.Estado == "Pendiente")
			{
				texto.AppendLine("Unidades solicitadas. El importe es estimado; stock vuelve a cotizar al aceptar:");
			}
			else if (actual.Estado == "Rechazada")
			{
				texto.AppendLine("Unidades del pedido rechazado:");
			}
			else if (actual.Estado == "Aceptada")
			{
				texto.AppendLine("Unidades reservadas a la espera del pago:");
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
				if (actual.Estado == "Pendiente")
				{
					texto.AppendLine(
						equipo.CodigoInventario + " · " + ResumenImportes(CotizacionEquipo(equipo, actual.Desde, actual.Hasta))
					);
				}

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

		private void PagarClick(object sender, EventArgs e)
		{
			Pagar();
		}

		private void RechazarClick(object sender, EventArgs e)
		{
			Rechazar();
		}

		private void SolicitarClick(object sender, EventArgs e)
		{
			Solicitar();
		}

		private void FormatearEquipo(object sender, ListControlConvertEventArgs e)
		{
			Reserva consulta = e.ListItem as Reserva;

			if (consulta != null)
			{
				Equipo equipo = consulta.Equipos[0];
				e.Value = equipo.CodigoInventario
					+ " · "
					+ equipo.Marca
					+ " "
					+ equipo.Modelo
					+ " · ARS "
					+ equipo.TarifaDiaria.ToString("N2")
					+ " por día · "
					+ ResumenImportes(consulta);
			}
		}

		private void UnidadCambio(object sender, ItemCheckEventArgs e)
		{
			if (EnDiseno() || cargandoUnidades)
			{
				return;
			}

			try
			{
				Reserva consulta = LeerReserva();
				consulta.Equipos.Clear();

				for (int i = 0; i < unidades.Items.Count; i++)
				{
					bool marcada = unidades.GetItemChecked(i);

					if (i == e.Index)
					{
						marcada = e.NewValue == CheckState.Checked;
					}

					if (marcada)
					{
						consulta.Equipos.Add(((Reserva)unidades.Items[i]).Equipos[0]);
					}
				}

				cotizarBoton.Enabled = consulta.Equipos.Count > 0;
				solicitarBoton.Enabled = consulta.Equipos.Count > 0;

				if (consulta.Equipos.Count == 0)
				{
					cotizacion.Text = "Elegí equipos para ver el alquiler, la seña y la garantía totales.";
					return;
				}

				bll.CalcularImportes(consulta);
				cotizacion.Text = ResumenImportes(consulta);
			}
			catch (Exception ex)
			{
				e.NewValue = e.CurrentValue;
				solicitarBoton.Enabled = false;
				MessageBox.Show(this, ex.Message, "Importes requeridos");
			}
		}

		private void ActualizacionAutomatica(object sender, EventArgs e)
		{
			if (EnDiseno() || !Visible || IsDisposed || SesionSingleton.Instancia.UsuarioActual == null)
			{
				return;
			}

			try
			{
				List<Reserva> lista = bll.Listar();

				if (HayCambios(lista))
				{
					string aviso = AvisoCambios(lista);
					MostrarReservas(lista);
					avisoActualizacion.Text = aviso;
				}
			}
			catch (Exception)
			{
				actualizacionTimer.Stop();
				avisoActualizacion.Text = "No se pudo actualizar la lista. Pulsá Actualizar lista para reintentar.";
			}
		}

		private bool HayCambios(List<Reserva> lista)
		{
			if (lista.Count != reservasActuales.Count)
			{
				return true;
			}

			for (int i = 0; i < lista.Count; i++)
			{
				Reserva nueva = lista[i];
				Reserva anterior = reservasActuales[i];

				if (nueva.Id != anterior.Id
					|| nueva.Estado != anterior.Estado
					|| nueva.Importe != anterior.Importe
					|| nueva.Sena != anterior.Sena
					|| nueva.Garantia != anterior.Garantia
					|| nueva.SenaRequerida != anterior.SenaRequerida
					|| nueva.GarantiaRequerida != anterior.GarantiaRequerida
					|| TipoSeguroReserva(nueva) != TipoSeguroReserva(anterior)
					|| AntecedentesCliente(nueva.Cliente) != AntecedentesCliente(anterior.Cliente))
				{
					return true;
				}
			}

			return false;
		}

		private string AvisoCambios(List<Reserva> lista)
		{
			string aviso = "La lista se actualizó. Seleccioná un pedido para ver su estado.";
			bool esCliente = seguridad.TienePermiso("Reserva.Pagar");

			foreach (Reserva nueva in lista)
			{
				foreach (Reserva anterior in reservasActuales)
				{
					if (nueva.Id == anterior.Id && nueva.Estado != anterior.Estado)
					{
						if (esCliente && nueva.Estado == "Aceptada")
						{
							aviso = "Stock aceptó la solicitud " + nueva.Id + ". Seleccionala para pagar la seña y la garantía.";
						}
						else if (!esCliente && nueva.Estado == "Firme")
						{
							aviso = "El cliente pagó la solicitud " + nueva.Id + ". Ya podés entregar los equipos.";
						}
						else if (esCliente && nueva.Estado == "Rechazada")
						{
							aviso = "Stock rechazó la solicitud " + nueva.Id + ". Podés enviar otro pedido.";
						}
					}
				}
			}

			return aviso;
		}

		private bool EnDiseno()
		{
			return DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime;
		}

		private void FechasCambio(object sender, EventArgs e)
		{
			if (EnDiseno())
			{
				return;
			}

			cargandoUnidades = true;

			try
			{
				unidades.Items.Clear();
			}
			finally
			{
				cargandoUnidades = false;
			}

			cotizarBoton.Enabled = false;
			solicitarBoton.Enabled = false;
			cotizacion.Text = "Cambiaste las fechas. Consultá disponibles para ver los importes del nuevo período.";
		}

		private void FormatearCliente(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex < 0)
			{
				return;
			}

			Reserva actual = reservas.Rows[e.RowIndex].DataBoundItem as Reserva;

			if (actual == null)
			{
				return;
			}

			if (reservas.Columns[e.ColumnIndex] == reservasSeguroColumna)
			{
				e.Value = TipoSeguroReserva(actual);
				e.FormattingApplied = true;
			}
			else if (reservas.Columns[e.ColumnIndex].DataPropertyName == "Estado")
			{
				if (actual.Estado == "Aceptada")
				{
					e.Value = "Aceptada · pendiente de pago";
					e.FormattingApplied = true;
				}
				else if (actual.Estado == "Firme")
				{
					e.Value = "Pagada · pendiente de entrega";
					e.FormattingApplied = true;
				}
			}
			else if (reservas.Columns[e.ColumnIndex] == reservasAntecedentesColumna)
			{
				string antecedentes = AntecedentesCliente(actual.Cliente);
				e.Value = antecedentes.Replace(Environment.NewLine, " | ");
				reservas.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = antecedentes;
				e.FormattingApplied = true;
			}
			else if (reservas.Columns[e.ColumnIndex].DataPropertyName == "ClienteId" && actual.Cliente != null)
			{
				e.Value = actual.Cliente.Nombre;
				e.FormattingApplied = true;
			}
		}

		private string AntecedentesCliente(Cliente cliente)
		{
			if (cliente == null || string.IsNullOrWhiteSpace(cliente.Antecedentes))
			{
				return "Sin antecedentes";
			}

			return cliente.Antecedentes;
		}

		private string TipoSeguroReserva(Reserva reserva)
		{
			if (reserva.Estado == "Pendiente" && reserva.Cliente != null && reserva.Cliente.Usuario != null)
			{
				return NombreSeguro(reserva.Cliente.Usuario.TipoSeguro);
			}

			List<string> tipos = new List<string>();

			if (reserva.Equipos != null)
			{
				foreach (Equipo equipo in reserva.Equipos)
				{
					string tipo = "Sin seguro";

					if (equipo.Seguro != null)
					{
						tipo = NombreSeguro(equipo.Seguro.Tipo);
					}

					if (!tipos.Contains(tipo))
					{
						tipos.Add(tipo);
					}
				}
			}

			if (tipos.Count == 0)
			{
				return "Sin seguro";
			}

			return string.Join(" / ", tipos);
		}

		private string NombreSeguro(string tipo)
		{
			if (tipo == "Basico")
			{
				return "Básico";
			}
			else if (tipo == "Intermedio")
			{
				return "Intermedio";
			}
			else if (tipo == "Completo")
			{
				return "Completo";
			}

			return "Sin seguro";
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
			pagoPanel.Visible = seguridad.TienePermiso("Reserva.Pagar");
			bool puedeEntregar = seguridad.TienePermiso("Reserva.Entregar");
			registrarBoton.Enabled = puedeEntregar;
			registrarBoton.Visible = puedeEntregar;
			cotejo.Enabled = puedeEntregar;
			cotejo.Visible = puedeEntregar;
			firma.Enabled = puedeEntregar;
			firma.Visible = puedeEntregar;

			if (!puedeEntregar)
			{
				entrega.Height = 65;
			}
		}
	}
}
