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
    public class ReservasForm : Form
    {
        private readonly ReservaBLL bll = new ReservaBLL();
        private readonly ClienteBLL clientes = new ClienteBLL();
        private readonly EquipoBLL equipos = new EquipoBLL();
        private readonly Seguridad seguridad = new Seguridad();
        private readonly ComboBox cliente = new ComboBox { Width = 250, DropDownStyle = ComboBoxStyle.DropDownList, DisplayMember = "Nombre" };
        private readonly DateTimePicker desde = Fecha(), hasta = Fecha();
        private readonly CheckedListBox unidades = new CheckedListBox { Dock = DockStyle.Fill, DisplayMember = "CodigoInventario", CheckOnClick = true };
        private readonly NumericUpDown sena = Dinero(), garantia = Dinero();
        private readonly Label cotizacion = new Label { AutoSize = true, Text = "Elegí unidades y cotizá. La cotización no bloquea equipos." };
        private readonly DataGridView reservas = new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, AutoGenerateColumns = false, AllowUserToAddRows = false, MultiSelect = false, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
        private readonly TextBox detalle = new TextBox { Dock = DockStyle.Fill, Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical, Font = new Font("Consolas", 10) };
        private readonly CheckBox cotejo = new CheckBox { Text = "Revisamos cada unidad con el cliente", AutoSize = true }, firma = new CheckBox { Text = "Contrato y remito firmados", AutoSize = true };
        private readonly TabControl tabs = new TabControl { Dock = DockStyle.Fill };
        private readonly TabPage solicitudTab = new TabPage("Elegir equipos y enviar"), gestionTab = new TabPage("Solicitudes y reservas");
        private readonly Label revision = new Label { AutoSize = true, Text = "Seleccioná una solicitud pendiente y cotizala antes de aceptar." };

        public ReservasForm()
        {
            Text = "N01 · Solicitudes, reservas y entrega"; ClientSize = new Size(1180, 680); StartPosition = FormStartPosition.CenterParent; Font = new Font("Segoe UI", 10);
            hasta.Value = DateTime.Today.AddDays(1);
            FlowLayoutPanel fechas = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 100, Padding = new Padding(10) };
            Campo(fechas, "Cliente", cliente); Campo(fechas, "Desde", desde); Campo(fechas, "Hasta", hasta); fechas.Controls.Add(Boton("Consultar disponibles", DisponiblesClick));
            FlowLayoutPanel importes = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 115, Padding = new Padding(10) };
            importes.Controls.Add(Boton("Cotizar", CotizarClick)); importes.Controls.Add(cotizacion); importes.SetFlowBreak(cotizacion, true);
            importes.Controls.Add(Boton("Enviar solicitud a stock", SolicitarClick));
            importes.Controls.Add(new Label { Text = "Queda pendiente hasta que stock la acepte. Podés ver su estado en Solicitudes y reservas.", AutoSize = true });
            solicitudTab.Controls.Add(unidades); solicitudTab.Controls.Add(importes); solicitudTab.Controls.Add(fechas);
            unidades.FormattingEnabled = true; unidades.Format += FormatearEquipo;
            foreach (string campo in new[] { "Id", "ClienteId", "Desde", "Hasta", "Importe", "Sena", "Garantia", "Estado", "NumeroContrato", "NumeroRemito" })
                reservas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = campo, HeaderText = Etiqueta(campo) });
            reservas.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            reservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TableLayoutPanel datos = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 2 };
            datos.RowStyles.Add(new RowStyle(SizeType.Percent, 50)); datos.RowStyles.Add(new RowStyle(SizeType.Percent, 50)); datos.Controls.Add(reservas, 0, 0); datos.Controls.Add(detalle, 0, 1);
            FlowLayoutPanel entrega = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 95, Padding = new Padding(10) };
            entrega.Controls.Add(Boton("Actualizar lista", ActualizarClick)); entrega.Controls.Add(cotejo); entrega.Controls.Add(firma);
            Button registrar = Boton("Registrar entrega", EntregaClick); registrar.Enabled = seguridad.TienePermiso("Reserva.Entregar"); entrega.Controls.Add(registrar);
            cotejo.Enabled = registrar.Enabled; firma.Enabled = registrar.Enabled;
            cotejo.Visible = registrar.Enabled; firma.Visible = registrar.Enabled; registrar.Visible = registrar.Enabled;
            if (!registrar.Enabled) entrega.Height = 55;
            FlowLayoutPanel aprobacion = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 160, Padding = new Padding(10), Visible = seguridad.TienePermiso("Reserva.Confirmar") };
            aprobacion.Controls.Add(Boton("Cotizar solicitud", CotizarClick)); aprobacion.Controls.Add(revision); aprobacion.SetFlowBreak(revision, true);
            Campo(aprobacion, "Seña recibida ARS", sena); Campo(aprobacion, "Garantía recibida ARS", garantia);
            aprobacion.Controls.Add(Boton("Aceptar solicitud", ConfirmarClick));
            gestionTab.Controls.Add(datos); gestionTab.Controls.Add(entrega); gestionTab.Controls.Add(aprobacion);
            if (seguridad.TienePermiso("Reserva.Solicitar")) tabs.TabPages.Add(solicitudTab);
            tabs.TabPages.Add(gestionTab); Controls.Add(tabs);
            reservas.SelectionChanged += ReservaCambio; Shown += CargarClick;
            reservas.CellFormatting += FormatearCliente;
            cliente.Enabled = false;
        }

        public void Cotizar()
        {
            try
            {
                Reserva consulta;
                if (tabs.SelectedTab == gestionTab)
                {
                    Reserva seleccionada = SeleccionarPendiente();
                    consulta = new Reserva { Cliente = seleccionada.Cliente, ClienteId = seleccionada.ClienteId, Desde = seleccionada.Desde, Hasta = seleccionada.Hasta, Equipos = seleccionada.Equipos };
                }
                else consulta = LeerReserva();
                bll.Cotizar(consulta);
                string resumen = "Total ARS " + consulta.Importe.ToString("N2") + " · seña requerida " + consulta.Sena.ToString("N2") + " · garantía requerida " + consulta.Garantia.ToString("N2");
                if (tabs.SelectedTab == gestionTab) revision.Text = resumen;
                else cotizacion.Text = resumen;
            }
            catch (Exception ex) { cotizacion.Text = "No se pudo cotizar."; MessageBox.Show(this, ex.Message, "Cotización"); }
        }

        public void Solicitar()
        {
            try
            {
                int id = bll.Solicitar(LeerReserva());
                MessageBox.Show(this, "Solicitud " + id + " enviada a stock. Estado: Pendiente. Todavía no es una reserva firme.", "Solicitud enviada");
                cotizacion.Text = "Solicitud " + id + " enviada. Consultá su estado en Solicitudes y reservas.";
                Actualizar(); Disponibles(); tabs.SelectedTab = gestionTab;
            }
            catch (Exception ex) { MessageBox.Show(this, ex.Message, "Resultado de la solicitud"); }
        }

        public void Confirmar()
        {
            try
            {
                Reserva seleccionada = SeleccionarPendiente();
                Reserva reserva = new Reserva { Id = seleccionada.Id, Sena = sena.Value, Garantia = garantia.Value };
                int id = bll.Confirmar(reserva);
                // Informar el éxito confirmado antes de recargar consultas independientes.
                MessageBox.Show(this, "Solicitud " + id + " aceptada. La reserva quedó Firme.", "Confirmación");
                sena.Value = 0; garantia.Value = 0; revision.Text = "Reserva " + id + " confirmada.";
                Actualizar();
            }
            catch (Exception ex) { MessageBox.Show(this, ex.Message, "Resultado de la operación"); }
        }

        public void RegistrarEntrega()
        {
            try
            {
                Reserva actual = reservas.CurrentRow == null ? null : reservas.CurrentRow.DataBoundItem as Reserva;
                if (actual == null) throw new ArgumentException("Seleccioná una reserva.");
                if (!cotejo.Checked || !firma.Checked) throw new ArgumentException("Completá la revisión física con el cliente y la firma de ambos documentos.");
                if (!bll.RegistrarEntrega(actual.Id)) throw new InvalidOperationException("La reserva no está firme o ya fue entregada.");
                MessageBox.Show(this, "Entrega registrada. Contrato C-" + actual.Id + " · remito R-" + actual.Id);
                cotejo.Checked = false; firma.Checked = false; Actualizar();
            }
            catch (Exception ex) { MessageBox.Show(this, ex.Message, "Resultado de la entrega"); }
        }

        private Reserva LeerReserva()
        {
            Cliente seleccionado = cliente.SelectedItem as Cliente;
            List<Equipo> seleccion = new List<Equipo>();
            foreach (object item in unidades.CheckedItems) seleccion.Add((Equipo)item);
            return new Reserva { Cliente = seleccionado, ClienteId = seleccionado == null ? 0 : seleccionado.Id, Desde = desde.Value, Hasta = hasta.Value, Equipos = seleccion };
        }
        private void Disponibles()
        {
            unidades.Items.Clear();
            foreach (Equipo equipo in equipos.ListarDisponibles(desde.Value, hasta.Value)) unidades.Items.Add(equipo);
        }
        private void Actualizar() { reservas.DataSource = bll.Listar(); }
        private Reserva SeleccionarPendiente()
        {
            Reserva actual = reservas.CurrentRow == null ? null : reservas.CurrentRow.DataBoundItem as Reserva;
            if (actual == null || actual.Estado != "Pendiente") throw new ArgumentException("Seleccioná una solicitud con estado Pendiente.");
            return actual;
        }
        private void ReservaCambio(object sender, EventArgs e)
        {
            cotejo.Checked = false; firma.Checked = false; sena.Value = 0; garantia.Value = 0;
            revision.Text = "Seleccioná una solicitud pendiente y cotizala antes de aceptar.";
            Reserva actual = reservas.CurrentRow == null ? null : reservas.CurrentRow.DataBoundItem as Reserva;
            if (actual == null) { detalle.Clear(); return; }
            StringBuilder texto = new StringBuilder();
            if (actual.Estado == "Pendiente") texto.AppendLine("SOLICITUD PENDIENTE DE REVISIÓN POR STOCK · Los equipos todavía no están reservados.");
            else texto.AppendLine(actual.Estado == "Firme" ? "BORRADOR DE CONTRATO / REMITO · Pendiente de firma y entrega" : "CONTRATO " + actual.NumeroContrato + " / REMITO " + actual.NumeroRemito);
            texto.AppendLine("Reserva " + actual.Id + " · " + actual.Estado + " · Firmado: " + actual.ContratoFirmado);
            texto.AppendLine("Cliente: " + actual.Cliente.Nombre + " · DNI/CUIT: " + actual.Cliente.DniCuit);
            texto.AppendLine("Contacto: " + actual.Cliente.Telefono + " · " + actual.Cliente.Email);
            texto.AppendLine("Desde " + actual.Desde.ToString("dd/MM/yyyy HH:mm") + " hasta " + actual.Hasta.ToString("dd/MM/yyyy HH:mm"));
            texto.AppendLine("Importe ARS " + actual.Importe.ToString("N2") + " · Seña ARS " + actual.Sena.ToString("N2") + " · Garantía ARS " + actual.Garantia.ToString("N2"));
            if (actual.Estado == "Pendiente") texto.AppendLine("Unidades solicitadas. El importe es estimado; stock vuelve a cotizar al aceptar:");
            else texto.AppendLine(actual.Estado == "Firme" ? "Unidades a cotejar antes de entregar:" : "Unidades entregadas (estado de entrega registrado: Disponible):");
            foreach (Equipo equipo in actual.Equipos)
                texto.AppendLine(equipo.CodigoInventario + " · " + equipo.Marca + " " + equipo.Modelo + " · serie " + equipo.Serie + " · tarifa " + equipo.TarifaDiaria.ToString("N2") + " · póliza " + (equipo.Seguro == null ? "Sin póliza asignada" : equipo.Seguro.Poliza));
            detalle.Text = texto.ToString();
        }
        private static NumericUpDown Dinero() { return new NumericUpDown { DecimalPlaces = 2, Maximum = 1000000000000, ThousandsSeparator = true, Width = 200 }; }
        private string Etiqueta(string campo)
        {
            switch (campo)
            {
                case "ClienteId": return "Cliente";
                case "Sena": return "Seña ARS";
                case "Garantia": return "Garantía ARS";
                case "Importe": return "Importe ARS";
                case "NumeroContrato": return "Contrato";
                case "NumeroRemito": return "Remito";
                default: return campo;
            }
        }
        private static DateTimePicker Fecha() { return new DateTimePicker { Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy HH:mm", Value = DateTime.Today, Width = 220 }; }
        private void Campo(FlowLayoutPanel panel, string etiqueta, Control control) { FlowLayoutPanel grupo = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, Width = control.Width + 10, Height = 70 }; grupo.Controls.Add(new Label { Text = etiqueta, AutoSize = true }); grupo.Controls.Add(control); panel.Controls.Add(grupo); }
        private Button Boton(string texto, EventHandler evento) { Button b = new Button { Text = texto, AutoSize = true, Height = 36 }; b.Click += evento; return b; }
        private void CotizarClick(object sender, EventArgs e) { Cotizar(); }
        private void ConfirmarClick(object sender, EventArgs e) { Confirmar(); }
        private void SolicitarClick(object sender, EventArgs e) { Solicitar(); }
        private void FormatearEquipo(object sender, ListControlConvertEventArgs e)
        {
            Equipo equipo = e.ListItem as Equipo;
            if (equipo != null) e.Value = equipo.CodigoInventario + " · " + equipo.Marca + " " + equipo.Modelo + " · ARS " + equipo.TarifaDiaria.ToString("N2") + " por día";
        }
        private void FormatearCliente(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || reservas.Columns[e.ColumnIndex].DataPropertyName != "ClienteId") return;
            Reserva actual = reservas.Rows[e.RowIndex].DataBoundItem as Reserva;
            if (actual != null && actual.Cliente != null) { e.Value = actual.Cliente.Nombre; e.FormattingApplied = true; }
        }
        private void EntregaClick(object sender, EventArgs e) { RegistrarEntrega(); }
        private void DisponiblesClick(object sender, EventArgs e) { try { Disponibles(); cotizacion.Text = "Selección nueva: volvé a cotizar."; } catch (Exception ex) { MessageBox.Show(this, ex.Message); } }
        private void ActualizarClick(object sender, EventArgs e) { try { Actualizar(); } catch (Exception ex) { MessageBox.Show(this, ex.Message); } }
        private void CargarClick(object sender, EventArgs e) { try { cliente.DataSource = clientes.Listar(); Disponibles(); Actualizar(); } catch (Exception ex) { MessageBox.Show(this, ex.Message); Close(); } }
    }
}
