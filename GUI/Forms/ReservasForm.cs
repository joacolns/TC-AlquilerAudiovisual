using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
		private bool iniciando = true;
		private List<Reserva> reservasActuales = new List<Reserva>();

		public ReservasForm()
		{
			InitializeComponent();
		}

		public void Cotizar()
		{
			try
			{
				Reserva seleccionada = SeleccionarPendiente();
				Reserva consulta = new Reserva
				{
					Cliente = seleccionada.Cliente,
					ClienteId = seleccionada.ClienteId,
					Desde = seleccionada.Desde,
					Hasta = seleccionada.Hasta,
					Equipos = seleccionada.Equipos
				};
				bll.Cotizar(consulta);
				revision.Text = ResumenImportes(consulta);
			}
			catch (Exception ex)
			{
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
				cotizacion.Text = "Solicitud " + id + " enviada. Consultá su estado en Mis pedidos.";
				Actualizar();
				Disponibles();
				tabs.SelectedTab = gestionTab;
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Resultado de la solicitud");
				RefrescarTrasError();
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
				MessageBox.Show(this, "Solicitud " + id + " aceptada. El cliente debe pagar la seña.", "Aceptación");
				Actualizar();
				avisoActualizacion.Text = "Solicitud " + id + " aceptada. Pendiente del pago del cliente.";
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Resultado de la operación");
				RefrescarTrasError();
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

				Actualizar();
				string aviso = "Seña pagada. Stock ya puede entregar los equipos.";

				// Con el pago completo el remito se emite en PDF.
				try
				{
					Reserva pagada = reservasActuales.Find(delegate(Reserva r) { return r.Id == actual.Id; });
					string ruta = GenerarRemito(pagada ?? actual);
					aviso += Environment.NewLine + "Remito guardado en: " + ruta;
					Process.Start(ruta);
				}
				catch (Exception ex)
				{
					aviso += Environment.NewLine + "No se pudo generar el remito en PDF: " + ex.Message;
				}

				MessageBox.Show(this, aviso, "Pago registrado");
				avisoActualizacion.Text = "Pago de la solicitud " + actual.Id + " registrado. Pendiente de entrega por stock.";
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Pagar seña");
				RefrescarTrasError();
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
				RefrescarTrasError();
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
				RefrescarTrasError();
			}
		}

		private Reserva LeerReserva()
		{
			ValidarFechasAlquiler();
			Cliente seleccionado = cliente.SelectedItem as Cliente;
			List<Equipo> seleccion = new List<Equipo>();

			foreach (ListViewItem item in unidades.CheckedItems)
			{
				seleccion.Add(((Reserva)item.Tag).Equipos[0]);
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

		private void ValidarFechasAlquiler()
		{
			if (desde.Value.Date < DateTime.Today)
			{
				throw new ArgumentException("La fecha de inicio no puede ser anterior a hoy.");
			}

			if (hasta.Value <= desde.Value)
			{
				throw new ArgumentException("La fecha de finalización debe ser posterior a la fecha de inicio.");
			}
		}

		private void Disponibles()
		{
			ValidarFechasAlquiler();
			List<Reserva> cotizaciones = new List<Reserva>();

			foreach (Equipo equipo in equipos.ListarLibres(desde.Value, hasta.Value))
			{
				cotizaciones.Add(CotizacionEquipo(equipo, desde.Value, hasta.Value));
			}

			cargandoUnidades = true;

			try
			{
				unidades.Items.Clear();
				unidades.Groups.Clear();
				cotizaciones.Sort(
					delegate(Reserva a, Reserva b)
					{
						Equipo x = a.Equipos[0];
						Equipo y = b.Equipos[0];
						int orden = OrdenSeccion(x.Categoria).CompareTo(OrdenSeccion(y.Categoria));
						return orden != 0 ? orden : string.Compare(x.CodigoInventario, y.CodigoInventario, StringComparison.Ordinal);
					}
				);
				ListViewGroup grupo = null;
				string categoriaActual = null;
				int enGrupo = 0;

				foreach (Reserva consulta in cotizaciones)
				{
					Equipo equipo = consulta.Equipos[0];

					if (grupo == null || equipo.Categoria != categoriaActual)
					{
						if (grupo != null)
						{
							grupo.Header = NombreSeccion(categoriaActual) + " (" + enGrupo + ")";
						}

						categoriaActual = equipo.Categoria;
						grupo = new ListViewGroup(NombreSeccion(categoriaActual));
						unidades.Groups.Add(grupo);
						enGrupo = 0;
					}

					ListViewItem fila = new ListViewItem(equipo.Marca + " " + equipo.Modelo + " (" + equipo.CodigoInventario + ")");
					fila.Tag = consulta;
					fila.Group = grupo;
					fila.SubItems.Add(equipo.TarifaDiaria.ToString("N2"));
					unidades.Items.Add(fila);
					enGrupo++;
				}

				if (grupo != null)
				{
					grupo.Header = NombreSeccion(categoriaActual) + " (" + enGrupo + ")";
				}
			}
			finally
			{
				cargandoUnidades = false;
			}

			cotizacion.ForeColor = Color.FromArgb(71, 85, 105);
			cotizacion.Text = "Cada equipo muestra el precio por día; al elegir equipos verás el total del alquiler y la seña.";
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
			decimal porDia = 0;

			foreach (Equipo equipo in consulta.Equipos)
			{
				porDia += equipo.TarifaDiaria;
			}

			int dias = (int)Math.Ceiling((consulta.Hasta - consulta.Desde).TotalDays);

			if (dias < 1)
			{
				dias = 1;
			}

			return "Total del alquiler ARS "
				+ consulta.Importe.ToString("N2")
				+ " (" + dias + " día(s) × ARS " + porDia.ToString("N2") + " por día)"
				+ " · seña requerida ARS "
				+ consulta.SenaRequerida.ToString("N2");
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

			if (seleccionada != null)
			{
				foreach (DataGridViewRow fila in reservas.Rows)
				{
					Reserva actual = fila.DataBoundItem as Reserva;

					if (actual != null && actual.Id == seleccionada.Id)
					{
						reservas.CurrentCell = fila.Cells[reservasIdColumna.Index];
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

			// Solo se muestra la acción que corresponde al estado del pedido seleccionado.
			bool esCliente = SesionSingleton.Instancia.UsuarioActual != null && SesionSingleton.Instancia.UsuarioActual.Rol == "Cliente";
			bool verPago = actual != null && actual.Estado == "Aceptada" && seguridad.TienePermiso("Reserva.Pagar");
			bool verEntrega = actual != null && actual.Estado == "Firme" && seguridad.TienePermiso("Reserva.Entregar");
			aprobacion.Visible = puedeRevisar;
			pagoPanel.Visible = verPago;
			entrega.Visible = verEntrega;
			bool verCancelar = actual != null
				&& (actual.Estado == "Pendiente" || actual.Estado == "Aceptada")
				&& seguridad.TienePermiso("Reserva.Cancelar")
				&& actual.Cliente != null
				&& SesionSingleton.Instancia.UsuarioActual != null
				&& actual.Cliente.UsuarioId == SesionSingleton.Instancia.UsuarioActual.Id;
			cancelacion.Visible = verCancelar;
			bool verRemito = actual != null && (actual.Estado == "Firme" || actual.Estado == "Entregada" || actual.Estado == "ConIncidencia" || actual.Estado == "Cerrada");
			documentos.Visible = verRemito;
			accionesNota.Visible = !esCliente && !puedeRevisar && !verPago && !verEntrega && !verRemito && !verCancelar;
			pagoEstado.Text = "Seleccioná una solicitud aceptada para pagar la seña.";

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
					+ " · saldo del alquiler ARS "
					+ (actual.Importe - actual.SenaRequerida).ToString("N2");
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
			else if (actual.Estado == "Cancelada")
			{
				pagoEstado.Text = "El pedido fue cancelado.";
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
			else if (actual.Estado == "Cancelada")
			{
				texto.AppendLine("PEDIDO CANCELADO · No reserva ni bloquea equipos.");
			}
			else if (actual.Estado == "Aceptada")
			{
				texto.AppendLine("SOLICITUD ACEPTADA · Pendiente del pago de la seña por el cliente.");
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
				texto.AppendLine("Seña pendiente de pago. Stock entregará los equipos después del pago.");
			}
			else
			{
				texto.AppendLine(
					"Seña pagada ARS " + actual.Sena.ToString("N2")
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

		private int OrdenSeccion(string categoria)
		{
			int indice = Array.IndexOf(new[] { "Cámara", "Lente", "Estabilizador", "Soporte", "Iluminación", "Audio", "Monitor", "Energía" }, categoria);

			if (indice < 0)
			{
				return 99;
			}

			return indice;
		}

		private string NombreSeccion(string categoria)
		{
			switch (categoria)
			{
				case "Cámara":
					return "Cámaras";
				case "Lente":
					return "Lentes";
				case "Estabilizador":
					return "Estabilizadores";
				case "Soporte":
					return "Soportes";
				case "Monitor":
					return "Monitores";
				default:
					return categoria;
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
					bool marcada = unidades.Items[i].Checked;

					if (i == e.Index)
					{
						marcada = e.NewValue == CheckState.Checked;
					}

					if (marcada)
					{
						consulta.Equipos.Add(((Reserva)unidades.Items[i].Tag).Equipos[0]);
					}
				}

				solicitarBoton.Enabled = consulta.Equipos.Count > 0;

				if (consulta.Equipos.Count == 0)
				{
					cotizacion.Text = "Elegí equipos para ver el alquiler, la seña totales.";
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
					|| nueva.SenaRequerida != anterior.SenaRequerida
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
							aviso = "Stock aceptó la solicitud " + nueva.Id + ". Seleccionala para pagar la seña.";
						}
						else if (!esCliente && nueva.Estado == "Firme")
						{
							aviso = "El cliente pagó la solicitud " + nueva.Id + ". Ya podés entregar los equipos.";
						}
						else if (!esCliente && nueva.Estado == "Cancelada")
						{
							aviso = "El cliente canceló la solicitud " + nueva.Id + ".";
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

			solicitarBoton.Enabled = false;

			if (hasta.Value <= desde.Value)
			{
				cotizacion.ForeColor = Color.FromArgb(185, 28, 28);
				cotizacion.Text = "La fecha de finalización debe ser posterior a la fecha de inicio.";
			}
			else if (desde.Value.Date < DateTime.Today)
			{
				cotizacion.ForeColor = Color.FromArgb(185, 28, 28);
				cotizacion.Text = "La fecha de inicio no puede ser anterior a hoy.";
			}
			else
			{
				if (!iniciando)
				{
					try
					{
						Disponibles();
					}
					catch (Exception ex)
					{
						cotizacion.Text = ex.Message;
					}
				}
			}
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

			if (reservas.Columns[e.ColumnIndex].DataPropertyName == "Estado")
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

		private void ReservasForm_Load(object sender, EventArgs e)
		{
			CargarPantalla();
		}

		private void CargarPantalla()
		{
			iniciando = true;

			try
			{
				bool esCliente = SesionSingleton.Instancia.UsuarioActual.Rol == "Cliente";
				bool esAdministrador = SesionSingleton.Instancia.UsuarioActual.Rol == "Administrador";
				bool puedeSolicitar = seguridad.TienePermiso("Reserva.Solicitar");

				desde.Value = DateTime.Now;
				hasta.Value = DateTime.Now.AddDays(1);
				cliente.Enabled = !esCliente;
				solicitarBoton.Visible = puedeSolicitar;
				accionesNota.Visible = !esCliente;
				solicitudNota.Visible = puedeSolicitar;

				if (esCliente)
				{
					reservas.Columns.Remove(reservasAntecedentesColumna);
				}

				if (!seguridad.TienePermiso("Equipo.Guardar"))
				{
					tabs.TabPages.Remove(inventarioTab);
				}

				// El cliente empieza por pedir equipos; stock y administración, por la bandeja de solicitudes.
				if (esCliente)
				{
					// El cliente no ve la revisión de stock ni la entrega, ni el detalle interno del pedido.
					gestionTab.Text = "Mis pedidos";
					tabs.SelectedTab = solicitudTab;
					detalle.Visible = false;
					acciones.FlowDirection = FlowDirection.LeftToRight;
					gestionTabLayout.RowStyles[1] = new RowStyle(SizeType.Percent, 100F);
					gestionTabLayout.RowStyles[2] = new RowStyle(SizeType.Absolute, 190F);
					datos.SetCellPosition(acciones, new TableLayoutPanelCellPosition(0, 0));
					datos.SetColumnSpan(acciones, 2);
				}
				else
				{
					if (!esAdministrador)
					{
						tabs.TabPages.Remove(cuentaTab);
					}

					if (!puedeSolicitar)
					{
						solicitudTab.Text = "Disponibilidad";
					}
				}

				cliente.DataSource = clientes.Listar();

				// El administrador, que también alquila, arranca con su propia ficha seleccionada.
				if (esAdministrador)
				{
					foreach (Cliente ficha in cliente.Items)
					{
						if (ficha.UsuarioId == SesionSingleton.Instancia.UsuarioActual.Id)
						{
							cliente.SelectedItem = ficha;
							break;
						}
					}
				}

				if (tabs.TabPages.Contains(inventarioTab))
				{
					CargarInventario();
				}

				Disponibles();
				Actualizar();

				if (esCliente || esAdministrador)
				{
					CargarCuenta();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "No se pudo abrir la pantalla", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				iniciando = false;
			}
		}

		private void CargarCuenta()
		{
			Usuario perfil = new UsuarioBLL().PerfilActual();
			List<Cliente> propios = clientes.ListarPropios();
			cuentaUsuario.Text = perfil.NombreUsuario;
			cuentaNombre.Text = perfil.Nombre;
			cuentaDocumento.Text = perfil.DniCuit;
			cuentaCorreo.Text = perfil.Email;
			cuentaTelefono.Text = perfil.Telefono;
			cuentaSeguro.Text = NombreSeguro(perfil.TipoSeguro);

			if (propios.Count == 0)
			{
				cuentaAntecedentes.Text = "Tu cuenta todavía no tiene una ficha de cliente registrada.";
				cuentaSeguros.DataSource = new List<Seguro>();
				return;
			}

			cuentaAntecedentes.Text = AntecedentesCliente(propios[0]);
			cuentaSeguros.DataSource = clientes.ListarSeguros(propios[0].Id);
		}

		// Recibe una propuesta del asesor: fija las fechas, lista lo disponible y tilda los equipos propuestos.
		public void PrepararSolicitud(DateTime inicio, DateTime fin, List<int> equipoIds)
		{
			try
			{
				iniciando = true;

				try
				{
					desde.Value = inicio;
					hasta.Value = fin;
				}
				finally
				{
					iniciando = false;
				}

				tabs.SelectedTab = solicitudTab;
				Disponibles();
				int faltantes = equipoIds.Count;

				for (int i = 0; i < unidades.Items.Count; i++)
				{
					Reserva item = unidades.Items[i].Tag as Reserva;

					if (item != null && equipoIds.Contains(item.Equipos[0].Id))
					{
						unidades.Items[i].Checked = true;
						faltantes--;
					}
				}

				if (faltantes > 0)
				{
					cotizacion.Text = faltantes + " equipo(s) de la propuesta ya no están disponibles para esas fechas. " + cotizacion.Text;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Nueva solicitud");
			}
		}

		// Si una acción falló porque los datos estaban viejos, se recarga todo para no repetir el error.
		private void RefrescarTrasError()
		{
			try
			{
				Actualizar();
				Disponibles();
			}
			catch (Exception)
			{
				avisoActualizacion.Text = "No se pudo actualizar la lista. Pulsá Actualizar lista para reintentar.";
			}
		}

		public void CancelarPedido()
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
					throw new ArgumentException("Seleccioná el pedido que querés cancelar.");
				}

				if (MessageBox.Show(
					this,
					"¿Cancelar el pedido " + actual.Id + "? Los equipos quedan libres para otras personas.",
					"Cancelar pedido",
					MessageBoxButtons.OKCancel
				) != DialogResult.OK)
				{
					return;
				}

				bll.Cancelar(actual.Id);
				Actualizar();
				Disponibles();
				MessageBox.Show(this, "Pedido " + actual.Id + " cancelado.", "Cancelar pedido");
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Cancelar pedido");
				RefrescarTrasError();
			}
		}

		private void CancelarClick(object sender, EventArgs e)
		{
			CancelarPedido();
		}

		private string GenerarRemito(Reserva reserva)
		{
			string numero = string.IsNullOrEmpty(reserva.NumeroRemito) ? "R-" + reserva.Id : reserva.NumeroRemito;
			string carpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "FOCO", "Remitos");
			string ruta = Path.Combine(carpeta, "Remito-" + numero + ".pdf");
			return new GeneradorPdf().Remito(reserva, ruta);
		}

		private void RemitoClick(object sender, EventArgs e)
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
					throw new ArgumentException("Seleccioná un pedido.");
				}

				Process.Start(GenerarRemito(actual));
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Remito en PDF");
			}
		}

		private void ClienteSolicitudCambio(object sender, EventArgs e)
		{
			if (iniciando)
			{
				return;
			}

			try
			{
				Disponibles();
			}
			catch (Exception ex)
			{
				cotizacion.Text = ex.Message;
			}
		}

		private void TabCambio(object sender, EventArgs e)
		{
			if (!iniciando && tabs.SelectedTab == cuentaTab)
			{
				try
				{
					CargarCuenta();
				}
				catch (Exception ex)
				{
					MessageBox.Show(this, ex.Message, "Mi cuenta");
				}
			}
		}

		private void FormatearSeguroCuenta(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex >= 0 && cuentaSeguros.Columns[e.ColumnIndex].DataPropertyName == "Tipo")
			{
				e.Value = NombreSeguro(Convert.ToString(e.Value));
				e.FormattingApplied = true;
			}
		}
	}
}
