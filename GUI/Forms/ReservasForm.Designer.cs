namespace GUI
{
	partial class ReservasForm
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}

			base.Dispose(disposing);
		}

#region Código generado por el Diseñador de Windows Forms
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.tabs = new System.Windows.Forms.TabControl();
			this.solicitudTab = new System.Windows.Forms.TabPage();
			this.unidades = new System.Windows.Forms.CheckedListBox();
			this.importes = new System.Windows.Forms.FlowLayoutPanel();
			this.cotizacion = new System.Windows.Forms.Label();
			this.cotizarBoton = new System.Windows.Forms.Button();
			this.solicitarBoton = new System.Windows.Forms.Button();
			this.solicitudNota = new System.Windows.Forms.Label();
			this.fechas = new System.Windows.Forms.FlowLayoutPanel();
			this.clienteCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.clienteCampoLabel = new System.Windows.Forms.Label();
			this.cliente = new System.Windows.Forms.ComboBox();
			this.desdeCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.desdeCampoLabel = new System.Windows.Forms.Label();
			this.desde = new System.Windows.Forms.DateTimePicker();
			this.hastaCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.hastaCampoLabel = new System.Windows.Forms.Label();
			this.hasta = new System.Windows.Forms.DateTimePicker();
			this.disponiblesBoton = new System.Windows.Forms.Button();
			this.gestionTab = new System.Windows.Forms.TabPage();
			this.datos = new System.Windows.Forms.TableLayoutPanel();
			this.reservas = new System.Windows.Forms.DataGridView();
			this.reservasSenaRequeridaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.reservasGarantiaRequeridaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.reservasSeguroColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.reservasAntecedentesColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.detalle = new System.Windows.Forms.TextBox();
			this.entrega = new System.Windows.Forms.FlowLayoutPanel();
			this.actualizarBoton = new System.Windows.Forms.Button();
			this.cotejo = new System.Windows.Forms.CheckBox();
			this.firma = new System.Windows.Forms.CheckBox();
			this.registrarBoton = new System.Windows.Forms.Button();
			this.aprobacion = new System.Windows.Forms.FlowLayoutPanel();
			this.revision = new System.Windows.Forms.Label();
			this.revisarBoton = new System.Windows.Forms.Button();
			this.aceptarBoton = new System.Windows.Forms.Button();
			this.rechazarBoton = new System.Windows.Forms.Button();
			this.pagoPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.pagarBoton = new System.Windows.Forms.Button();
			this.pagoEstado = new System.Windows.Forms.Label();
			this.avisoActualizacion = new System.Windows.Forms.Label();
			this.actualizacionTimer = new System.Windows.Forms.Timer(this.components);
			this.tabs.SuspendLayout();
			this.solicitudTab.SuspendLayout();
			this.importes.SuspendLayout();
			this.fechas.SuspendLayout();
			this.clienteCampo.SuspendLayout();
			this.desdeCampo.SuspendLayout();
			this.hastaCampo.SuspendLayout();
			this.gestionTab.SuspendLayout();
			this.datos.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.reservas)).BeginInit();
			this.entrega.SuspendLayout();
			this.aprobacion.SuspendLayout();
			this.pagoPanel.SuspendLayout();
			this.SuspendLayout();
			//
			// tabs
			//
			this.tabs.Controls.Add(this.solicitudTab);
			this.tabs.Controls.Add(this.gestionTab);
			this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabs.Location = new System.Drawing.Point(0, 0);
			this.tabs.Name = "tabs";
			this.tabs.SelectedIndex = 0;
			this.tabs.Size = new System.Drawing.Size(1180, 680);
			this.tabs.TabIndex = 0;
			//
			// solicitudTab
			//
			this.solicitudTab.Controls.Add(this.unidades);
			this.solicitudTab.Controls.Add(this.importes);
			this.solicitudTab.Controls.Add(this.fechas);
			this.solicitudTab.Location = new System.Drawing.Point(4, 26);
			this.solicitudTab.Name = "solicitudTab";
			this.solicitudTab.Padding = new System.Windows.Forms.Padding(3);
			this.solicitudTab.Size = new System.Drawing.Size(1172, 650);
			this.solicitudTab.TabIndex = 0;
			this.solicitudTab.Text = "Elegir equipos y enviar";
			this.solicitudTab.UseVisualStyleBackColor = true;
			//
			// unidades
			//
			this.unidades.CheckOnClick = true;
			this.unidades.DisplayMember = "";
			this.unidades.Dock = System.Windows.Forms.DockStyle.Fill;
			this.unidades.FormattingEnabled = true;
			this.unidades.HorizontalScrollbar = true;
			this.unidades.Location = new System.Drawing.Point(3, 103);
			this.unidades.Name = "unidades";
			this.unidades.Size = new System.Drawing.Size(1166, 429);
			this.unidades.TabIndex = 0;
			this.unidades.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.FormatearEquipo);
			this.unidades.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.UnidadCambio);
			//
			// importes
			//
			this.importes.Controls.Add(this.cotizarBoton);
			this.importes.Controls.Add(this.cotizacion);
			this.importes.Controls.Add(this.solicitarBoton);
			this.importes.Controls.Add(this.solicitudNota);
			this.importes.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.importes.Location = new System.Drawing.Point(3, 532);
			this.importes.Name = "importes";
			this.importes.Padding = new System.Windows.Forms.Padding(10);
			this.importes.Size = new System.Drawing.Size(1166, 115);
			this.importes.TabIndex = 1;
			//
			// cotizacion
			//
			this.cotizacion.AutoSize = true;
			this.importes.SetFlowBreak(this.cotizacion, true);
			this.cotizacion.Location = new System.Drawing.Point(139, 10);
			this.cotizacion.Name = "cotizacion";
			this.cotizacion.Size = new System.Drawing.Size(359, 19);
			this.cotizacion.TabIndex = 1;
			this.cotizacion.Text = "Elegí unidades y cotizá. La cotización no bloquea equipos.";
			//
			// cotizarBoton
			//
			this.cotizarBoton.AutoSize = true;
			this.cotizarBoton.Location = new System.Drawing.Point(13, 13);
			this.cotizarBoton.Name = "cotizarBoton";
			this.cotizarBoton.Size = new System.Drawing.Size(120, 36);
			this.cotizarBoton.TabIndex = 0;
			this.cotizarBoton.Text = "Cotizar";
			this.cotizarBoton.UseVisualStyleBackColor = true;
			this.cotizarBoton.Click += new System.EventHandler(this.CotizarClick);
			//
			// solicitarBoton
			//
			this.solicitarBoton.AutoSize = true;
			this.solicitarBoton.Location = new System.Drawing.Point(13, 55);
			this.solicitarBoton.Name = "solicitarBoton";
			this.solicitarBoton.Size = new System.Drawing.Size(157, 36);
			this.solicitarBoton.TabIndex = 2;
			this.solicitarBoton.Text = "Enviar solicitud a stock";
			this.solicitarBoton.UseVisualStyleBackColor = true;
			this.solicitarBoton.Click += new System.EventHandler(this.SolicitarClick);
			//
			// solicitudNota
			//
			this.solicitudNota.AutoSize = true;
			this.solicitudNota.Location = new System.Drawing.Point(176, 52);
			this.solicitudNota.Name = "solicitudNota";
			this.solicitudNota.Size = new System.Drawing.Size(557, 19);
			this.solicitudNota.TabIndex = 3;
			this.solicitudNota.Text = "Queda pendiente hasta que stock la acepte. Podés ver su estado en Solicitudes y r" + "eservas.";
			//
			// fechas
			//
			this.fechas.Controls.Add(this.clienteCampo);
			this.fechas.Controls.Add(this.desdeCampo);
			this.fechas.Controls.Add(this.hastaCampo);
			this.fechas.Controls.Add(this.disponiblesBoton);
			this.fechas.Dock = System.Windows.Forms.DockStyle.Top;
			this.fechas.Location = new System.Drawing.Point(3, 3);
			this.fechas.Name = "fechas";
			this.fechas.Padding = new System.Windows.Forms.Padding(10);
			this.fechas.Size = new System.Drawing.Size(1166, 100);
			this.fechas.TabIndex = 2;
			//
			// clienteCampo
			//
			this.clienteCampo.Controls.Add(this.clienteCampoLabel);
			this.clienteCampo.Controls.Add(this.cliente);
			this.clienteCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.clienteCampo.Location = new System.Drawing.Point(13, 13);
			this.clienteCampo.Name = "clienteCampo";
			this.clienteCampo.Size = new System.Drawing.Size(260, 70);
			this.clienteCampo.TabIndex = 0;
			//
			// clienteCampoLabel
			//
			this.clienteCampoLabel.AutoSize = true;
			this.clienteCampoLabel.Location = new System.Drawing.Point(3, 0);
			this.clienteCampoLabel.Name = "clienteCampoLabel";
			this.clienteCampoLabel.Size = new System.Drawing.Size(51, 19);
			this.clienteCampoLabel.TabIndex = 0;
			this.clienteCampoLabel.Text = "Cliente";
			//
			// cliente
			//
			this.cliente.DisplayMember = "Nombre";
			this.cliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cliente.Enabled = false;
			this.cliente.FormattingEnabled = true;
			this.cliente.Location = new System.Drawing.Point(3, 22);
			this.cliente.Name = "cliente";
			this.cliente.Size = new System.Drawing.Size(250, 25);
			this.cliente.TabIndex = 1;
			//
			// desdeCampo
			//
			this.desdeCampo.Controls.Add(this.desdeCampoLabel);
			this.desdeCampo.Controls.Add(this.desde);
			this.desdeCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.desdeCampo.Location = new System.Drawing.Point(279, 13);
			this.desdeCampo.Name = "desdeCampo";
			this.desdeCampo.Size = new System.Drawing.Size(230, 70);
			this.desdeCampo.TabIndex = 1;
			//
			// desdeCampoLabel
			//
			this.desdeCampoLabel.AutoSize = true;
			this.desdeCampoLabel.Location = new System.Drawing.Point(3, 0);
			this.desdeCampoLabel.Name = "desdeCampoLabel";
			this.desdeCampoLabel.Size = new System.Drawing.Size(47, 19);
			this.desdeCampoLabel.TabIndex = 0;
			this.desdeCampoLabel.Text = "Desde";
			//
			// desde
			//
			this.desde.CustomFormat = "dd/MM/yyyy HH:mm";
			this.desde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.desde.Location = new System.Drawing.Point(3, 22);
			this.desde.Name = "desde";
			this.desde.Size = new System.Drawing.Size(220, 25);
			this.desde.TabIndex = 1;
			this.desde.ValueChanged += new System.EventHandler(this.FechasCambio);
			//
			// hastaCampo
			//
			this.hastaCampo.Controls.Add(this.hastaCampoLabel);
			this.hastaCampo.Controls.Add(this.hasta);
			this.hastaCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.hastaCampo.Location = new System.Drawing.Point(515, 13);
			this.hastaCampo.Name = "hastaCampo";
			this.hastaCampo.Size = new System.Drawing.Size(230, 70);
			this.hastaCampo.TabIndex = 2;
			//
			// hastaCampoLabel
			//
			this.hastaCampoLabel.AutoSize = true;
			this.hastaCampoLabel.Location = new System.Drawing.Point(3, 0);
			this.hastaCampoLabel.Name = "hastaCampoLabel";
			this.hastaCampoLabel.Size = new System.Drawing.Size(44, 19);
			this.hastaCampoLabel.TabIndex = 0;
			this.hastaCampoLabel.Text = "Hasta";
			//
			// hasta
			//
			this.hasta.CustomFormat = "dd/MM/yyyy HH:mm";
			this.hasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.hasta.Location = new System.Drawing.Point(3, 22);
			this.hasta.Name = "hasta";
			this.hasta.Size = new System.Drawing.Size(220, 25);
			this.hasta.TabIndex = 1;
			this.hasta.ValueChanged += new System.EventHandler(this.FechasCambio);
			//
			// disponiblesBoton
			//
			this.disponiblesBoton.AutoSize = true;
			this.disponiblesBoton.Location = new System.Drawing.Point(751, 13);
			this.disponiblesBoton.Name = "disponiblesBoton";
			this.disponiblesBoton.Size = new System.Drawing.Size(150, 36);
			this.disponiblesBoton.TabIndex = 3;
			this.disponiblesBoton.Text = "Consultar disponibles";
			this.disponiblesBoton.UseVisualStyleBackColor = true;
			this.disponiblesBoton.Click += new System.EventHandler(this.DisponiblesClick);
			//
			// gestionTab
			//
			this.gestionTab.Controls.Add(this.datos);
			this.gestionTab.Controls.Add(this.entrega);
			this.gestionTab.Controls.Add(this.aprobacion);
			this.gestionTab.Controls.Add(this.pagoPanel);
			this.gestionTab.Location = new System.Drawing.Point(4, 26);
			this.gestionTab.Name = "gestionTab";
			this.gestionTab.Padding = new System.Windows.Forms.Padding(3);
			this.gestionTab.Size = new System.Drawing.Size(1172, 650);
			this.gestionTab.TabIndex = 1;
			this.gestionTab.Text = "Solicitudes y reservas";
			this.gestionTab.UseVisualStyleBackColor = true;
			//
			// datos
			//
			this.datos.ColumnCount = 1;
			this.datos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.datos.Controls.Add(this.reservas, 0, 0);
			this.datos.Controls.Add(this.detalle, 0, 1);
			this.datos.Dock = System.Windows.Forms.DockStyle.Fill;
			this.datos.Location = new System.Drawing.Point(3, 163);
			this.datos.Name = "datos";
			this.datos.RowCount = 2;
			this.datos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.datos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.datos.Size = new System.Drawing.Size(1166, 389);
			this.datos.TabIndex = 0;
			//
			// reservas
			//
			this.reservas.AllowUserToAddRows = false;
			this.reservas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.reservas.Columns.AddRange(
				new System.Windows.Forms.DataGridViewColumn[] { this.reservasSenaRequeridaColumna, this.reservasGarantiaRequeridaColumna, this.reservasSeguroColumna, this.reservasAntecedentesColumna }
			);
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.reservas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.reservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.reservas.Dock = System.Windows.Forms.DockStyle.Fill;
			this.reservas.Location = new System.Drawing.Point(3, 3);
			this.reservas.MultiSelect = false;
			this.reservas.Name = "reservas";
			this.reservas.ReadOnly = true;
			this.reservas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.reservas.Size = new System.Drawing.Size(1160, 188);
			this.reservas.TabIndex = 0;
			this.reservas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.FormatearCliente);
			this.reservas.SelectionChanged += new System.EventHandler(this.ReservaCambio);
			//
			// reservasSenaRequeridaColumna
			//
			this.reservasSenaRequeridaColumna.DataPropertyName = "SenaRequerida";
			this.reservasSenaRequeridaColumna.DefaultCellStyle.Format = "N2";
			this.reservasSenaRequeridaColumna.HeaderText = "Seña requerida ARS";
			this.reservasSenaRequeridaColumna.MinimumWidth = 115;
			this.reservasSenaRequeridaColumna.Name = "SenaRequerida";
			this.reservasSenaRequeridaColumna.ReadOnly = true;
			//
			// reservasGarantiaRequeridaColumna
			//
			this.reservasGarantiaRequeridaColumna.DataPropertyName = "GarantiaRequerida";
			this.reservasGarantiaRequeridaColumna.DefaultCellStyle.Format = "N2";
			this.reservasGarantiaRequeridaColumna.HeaderText = "Garantía requerida ARS";
			this.reservasGarantiaRequeridaColumna.MinimumWidth = 115;
			this.reservasGarantiaRequeridaColumna.Name = "GarantiaRequerida";
			this.reservasGarantiaRequeridaColumna.ReadOnly = true;
			//
			// reservasSeguroColumna
			//
			this.reservasSeguroColumna.HeaderText = "Tipo de seguro";
			this.reservasSeguroColumna.MinimumWidth = 110;
			this.reservasSeguroColumna.Name = "TipoSeguro";
			this.reservasSeguroColumna.ReadOnly = true;
			this.reservasSeguroColumna.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			//
			// reservasAntecedentesColumna
			//
			this.reservasAntecedentesColumna.HeaderText = "Antecedentes del cliente";
			this.reservasAntecedentesColumna.MinimumWidth = 180;
			this.reservasAntecedentesColumna.Name = "Antecedentes";
			this.reservasAntecedentesColumna.ReadOnly = true;
			this.reservasAntecedentesColumna.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			//
			// detalle
			//
			this.detalle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.detalle.Font = new System.Drawing.Font("Consolas", 10F);
			this.detalle.Location = new System.Drawing.Point(3, 197);
			this.detalle.Multiline = true;
			this.detalle.Name = "detalle";
			this.detalle.ReadOnly = true;
			this.detalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.detalle.Size = new System.Drawing.Size(1160, 189);
			this.detalle.TabIndex = 1;
			//
			// entrega
			//
			this.entrega.Controls.Add(this.actualizarBoton);
			this.entrega.Controls.Add(this.avisoActualizacion);
			this.entrega.Controls.Add(this.cotejo);
			this.entrega.Controls.Add(this.firma);
			this.entrega.Controls.Add(this.registrarBoton);
			this.entrega.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.entrega.Location = new System.Drawing.Point(3, 552);
			this.entrega.Name = "entrega";
			this.entrega.Padding = new System.Windows.Forms.Padding(10);
			this.entrega.Size = new System.Drawing.Size(1166, 95);
			this.entrega.TabIndex = 1;
			//
			// actualizarBoton
			//
			this.actualizarBoton.AutoSize = true;
			this.actualizarBoton.Location = new System.Drawing.Point(13, 13);
			this.actualizarBoton.Name = "actualizarBoton";
			this.actualizarBoton.Size = new System.Drawing.Size(120, 36);
			this.actualizarBoton.TabIndex = 0;
			this.actualizarBoton.Text = "Actualizar lista";
			this.actualizarBoton.UseVisualStyleBackColor = true;
			this.actualizarBoton.Click += new System.EventHandler(this.ActualizarClick);
			//
			// avisoActualizacion
			//
			this.avisoActualizacion.Name = "avisoActualizacion";
			this.avisoActualizacion.AutoSize = true;
			this.avisoActualizacion.MaximumSize = new System.Drawing.Size(950, 0);
			this.avisoActualizacion.Margin = new System.Windows.Forms.Padding(10, 8, 3, 3);
			this.avisoActualizacion.Text = "La lista se actualiza automáticamente cada 10 segundos.";
			this.entrega.SetFlowBreak(this.avisoActualizacion, true);
			//
			// cotejo
			//
			this.cotejo.AutoSize = true;
			this.cotejo.Location = new System.Drawing.Point(139, 13);
			this.cotejo.Name = "cotejo";
			this.cotejo.Size = new System.Drawing.Size(253, 23);
			this.cotejo.TabIndex = 1;
			this.cotejo.Text = "Revisamos cada unidad con el cliente";
			//
			// firma
			//
			this.firma.AutoSize = true;
			this.firma.Location = new System.Drawing.Point(398, 13);
			this.firma.Name = "firma";
			this.firma.Size = new System.Drawing.Size(195, 23);
			this.firma.TabIndex = 2;
			this.firma.Text = "Contrato y remito firmados";
			//
			// registrarBoton
			//
			this.registrarBoton.AutoSize = true;
			this.registrarBoton.Location = new System.Drawing.Point(599, 13);
			this.registrarBoton.Name = "registrarBoton";
			this.registrarBoton.Size = new System.Drawing.Size(124, 36);
			this.registrarBoton.TabIndex = 3;
			this.registrarBoton.Text = "Registrar entrega";
			this.registrarBoton.UseVisualStyleBackColor = true;
			this.registrarBoton.Click += new System.EventHandler(this.EntregaClick);
			//
			// aprobacion
			//
			this.aprobacion.Controls.Add(this.revisarBoton);
			this.aprobacion.Controls.Add(this.revision);
			this.aprobacion.Controls.Add(this.aceptarBoton);
			this.aprobacion.Controls.Add(this.rechazarBoton);
			this.aprobacion.Dock = System.Windows.Forms.DockStyle.Top;
			this.aprobacion.Location = new System.Drawing.Point(3, 3);
			this.aprobacion.Name = "aprobacion";
			this.aprobacion.Padding = new System.Windows.Forms.Padding(10);
			this.aprobacion.Size = new System.Drawing.Size(1166, 100);
			this.aprobacion.TabIndex = 2;
			//
			// revision
			//
			this.revision.AutoSize = true;
			this.aprobacion.SetFlowBreak(this.revision, true);
			this.revision.Location = new System.Drawing.Point(139, 10);
			this.revision.Name = "revision";
			this.revision.Size = new System.Drawing.Size(385, 19);
			this.revision.TabIndex = 1;
			this.revision.Text = "Seleccioná una solicitud pendiente y cotizala antes de aceptar.";
			//
			// revisarBoton
			//
			this.revisarBoton.AutoSize = true;
			this.revisarBoton.Location = new System.Drawing.Point(13, 13);
			this.revisarBoton.Name = "revisarBoton";
			this.revisarBoton.Size = new System.Drawing.Size(120, 36);
			this.revisarBoton.TabIndex = 0;
			this.revisarBoton.Text = "Cotizar solicitud";
			this.revisarBoton.UseVisualStyleBackColor = true;
			this.revisarBoton.Click += new System.EventHandler(this.CotizarClick);
			//
			// aceptarBoton
			//
			this.aceptarBoton.AutoSize = true;
			this.aceptarBoton.Location = new System.Drawing.Point(445, 55);
			this.aceptarBoton.Name = "aceptarBoton";
			this.aceptarBoton.Size = new System.Drawing.Size(120, 36);
			this.aceptarBoton.TabIndex = 4;
			this.aceptarBoton.Text = "Aceptar solicitud";
			this.aceptarBoton.UseVisualStyleBackColor = true;
			this.aceptarBoton.Click += new System.EventHandler(this.ConfirmarClick);
			//
			// rechazarBoton
			//
			this.rechazarBoton.Name = "rechazarBoton";
			this.rechazarBoton.Text = "Rechazar solicitud";
			this.rechazarBoton.AutoSize = true;
			this.rechazarBoton.Size = new System.Drawing.Size(140, 36);
			this.rechazarBoton.TabIndex = 5;
			this.rechazarBoton.Enabled = false;
			this.rechazarBoton.UseVisualStyleBackColor = true;
			this.rechazarBoton.Click += new System.EventHandler(this.RechazarClick);
			//
			// pagoPanel
			//
			this.pagoPanel.Name = "pagoPanel";
			this.pagoPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.pagoPanel.Size = new System.Drawing.Size(1166, 85);
			this.pagoPanel.Padding = new System.Windows.Forms.Padding(10);
			this.pagoPanel.Controls.Add(this.pagarBoton);
			this.pagoPanel.Controls.Add(this.pagoEstado);
			this.pagarBoton.Name = "pagarBoton";
			this.pagarBoton.Text = "Pagar seña y garantía";
			this.pagarBoton.Size = new System.Drawing.Size(185, 36);
			this.pagarBoton.Enabled = false;
			this.pagarBoton.UseVisualStyleBackColor = true;
			this.pagarBoton.Click += new System.EventHandler(this.PagarClick);
			this.pagoEstado.Name = "pagoEstado";
			this.pagoEstado.AutoSize = true;
			this.pagoEstado.MaximumSize = new System.Drawing.Size(890, 0);
			this.pagoEstado.Margin = new System.Windows.Forms.Padding(10, 8, 3, 3);
			this.pagoEstado.Text = "Seleccioná una solicitud aceptada para pagar la seña y la garantía.";
			this.actualizacionTimer.Interval = 10000;
			this.actualizacionTimer.Tick += new System.EventHandler(this.ActualizacionAutomatica);
			//
			// ReservasForm
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1180, 680);
			this.Controls.Add(this.tabs);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.Name = "ReservasForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "N01 · Solicitudes, reservas y entrega";
			this.Load += new System.EventHandler(this.PrepararPantalla);
			this.Shown += new System.EventHandler(this.CargarClick);
			this.tabs.ResumeLayout(false);
			this.solicitudTab.ResumeLayout(false);
			this.importes.ResumeLayout(false);
			this.importes.PerformLayout();
			this.fechas.ResumeLayout(false);
			this.fechas.PerformLayout();
			this.clienteCampo.ResumeLayout(false);
			this.clienteCampo.PerformLayout();
			this.desdeCampo.ResumeLayout(false);
			this.desdeCampo.PerformLayout();
			this.hastaCampo.ResumeLayout(false);
			this.hastaCampo.PerformLayout();
			this.gestionTab.ResumeLayout(false);
			this.datos.ResumeLayout(false);
			this.datos.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.reservas)).EndInit();
			this.entrega.ResumeLayout(false);
			this.entrega.PerformLayout();
			this.aprobacion.ResumeLayout(false);
			this.aprobacion.PerformLayout();
			this.pagoPanel.ResumeLayout(false);
			this.pagoPanel.PerformLayout();
			this.ResumeLayout(false);
		}

#endregion
		private System.Windows.Forms.TabControl tabs;
		private System.Windows.Forms.TabPage solicitudTab;
		private System.Windows.Forms.TabPage gestionTab;
		private System.Windows.Forms.FlowLayoutPanel fechas;
		private System.Windows.Forms.ComboBox cliente;
		private System.Windows.Forms.DateTimePicker desde;
		private System.Windows.Forms.DateTimePicker hasta;
		private System.Windows.Forms.FlowLayoutPanel clienteCampo;
		private System.Windows.Forms.Label clienteCampoLabel;
		private System.Windows.Forms.FlowLayoutPanel desdeCampo;
		private System.Windows.Forms.Label desdeCampoLabel;
		private System.Windows.Forms.FlowLayoutPanel hastaCampo;
		private System.Windows.Forms.Label hastaCampoLabel;
		private System.Windows.Forms.Button disponiblesBoton;
		private System.Windows.Forms.CheckedListBox unidades;
		private System.Windows.Forms.FlowLayoutPanel importes;
		private System.Windows.Forms.Button cotizarBoton;
		private System.Windows.Forms.Label cotizacion;
		private System.Windows.Forms.Button solicitarBoton;
		private System.Windows.Forms.Label solicitudNota;
		private System.Windows.Forms.DataGridView reservas;
		private System.Windows.Forms.DataGridViewTextBoxColumn reservasSenaRequeridaColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn reservasGarantiaRequeridaColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn reservasSeguroColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn reservasAntecedentesColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn reservasIdColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn reservasClienteIdColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn reservasDesdeColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn reservasHastaColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn reservasImporteColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn reservasSenaColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn reservasGarantiaColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn reservasEstadoColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn reservasNumeroContratoColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn reservasNumeroRemitoColumna;
		private System.Windows.Forms.TextBox detalle;
		private System.Windows.Forms.TableLayoutPanel datos;
		private System.Windows.Forms.FlowLayoutPanel entrega;
		private System.Windows.Forms.Button actualizarBoton;
		private System.Windows.Forms.CheckBox cotejo;
		private System.Windows.Forms.CheckBox firma;
		private System.Windows.Forms.Button registrarBoton;
		private System.Windows.Forms.FlowLayoutPanel aprobacion;
		private System.Windows.Forms.Button revisarBoton;
		private System.Windows.Forms.Label revision;
		private System.Windows.Forms.Button aceptarBoton;
		private System.Windows.Forms.Button rechazarBoton;
		private System.Windows.Forms.FlowLayoutPanel pagoPanel;
		private System.Windows.Forms.Button pagarBoton;
		private System.Windows.Forms.Label pagoEstado;
		private System.Windows.Forms.Label avisoActualizacion;
		private System.Windows.Forms.Timer actualizacionTimer;
	}
}
