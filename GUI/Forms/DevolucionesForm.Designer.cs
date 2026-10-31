namespace GUI
{
	partial class DevolucionesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabs = new System.Windows.Forms.TabControl();
            this.devolucionTab = new System.Windows.Forms.TabPage();
            this.remito = new System.Windows.Forms.TextBox();
            this.cierreDevolucion = new System.Windows.Forms.FlowLayoutPanel();
            this.observacionesCampo = new System.Windows.Forms.FlowLayoutPanel();
            this.observacionesCampoLabel = new System.Windows.Forms.Label();
            this.observaciones = new System.Windows.Forms.TextBox();
            this.registrarBoton = new System.Windows.Forms.Button();
            this.actualizarDevolucionBoton = new System.Windows.Forms.Button();
            this.cabecera = new System.Windows.Forms.FlowLayoutPanel();
            this.reservaCampo = new System.Windows.Forms.FlowLayoutPanel();
            this.reservaCampoLabel = new System.Windows.Forms.Label();
            this.reserva = new System.Windows.Forms.ComboBox();
            this.fechaCampo = new System.Windows.Forms.FlowLayoutPanel();
            this.fechaCampoLabel = new System.Windows.Forms.Label();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.presente = new System.Windows.Forms.CheckBox();
            this.conforme = new System.Windows.Forms.CheckBox();
            this.cotejo = new System.Windows.Forms.CheckBox();
            this.inspeccionTab = new System.Windows.Forms.TabPage();
            this.incidencias = new System.Windows.Forms.DataGridView();
            this.cierreInspeccion = new System.Windows.Forms.FlowLayoutPanel();
            this.liquidacion = new System.Windows.Forms.Label();
            this.incidenciaBoton = new System.Windows.Forms.Button();
            this.finalizarBoton = new System.Windows.Forms.Button();
            this.actualizarInspeccionBoton = new System.Windows.Forms.Button();
            this.hallazgos = new System.Windows.Forms.FlowLayoutPanel();
            this.devolucionCampo = new System.Windows.Forms.FlowLayoutPanel();
            this.devolucionCampoLabel = new System.Windows.Forms.Label();
            this.devolucion = new System.Windows.Forms.ComboBox();
            this.equipoCampo = new System.Windows.Forms.FlowLayoutPanel();
            this.equipoCampoLabel = new System.Windows.Forms.Label();
            this.equipo = new System.Windows.Forms.ComboBox();
            this.tipoCampo = new System.Windows.Forms.FlowLayoutPanel();
            this.tipoCampoLabel = new System.Windows.Forms.Label();
            this.tipo = new System.Windows.Forms.ComboBox();
            this.descripcionCampo = new System.Windows.Forms.FlowLayoutPanel();
            this.descripcionCampoLabel = new System.Windows.Forms.Label();
            this.descripcion = new System.Windows.Forms.TextBox();
            this.cargoBoton = new System.Windows.Forms.Button();
            this.cargo = new System.Windows.Forms.Label();
            this.tecnicaTab = new System.Windows.Forms.TabPage();
            this.tecnicas = new System.Windows.Forms.DataGridView();
            this.altaTecnica = new System.Windows.Forms.FlowLayoutPanel();
            this.detalleTecnico = new System.Windows.Forms.TextBox();
            this.apta = new System.Windows.Forms.CheckBox();
            this.altaBoton = new System.Windows.Forms.Button();
            this.actualizarTecnicaBoton = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.devolucionTab.SuspendLayout();
            this.cierreDevolucion.SuspendLayout();
            this.observacionesCampo.SuspendLayout();
            this.cabecera.SuspendLayout();
            this.reservaCampo.SuspendLayout();
            this.fechaCampo.SuspendLayout();
            this.inspeccionTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.incidencias)).BeginInit();
            this.cierreInspeccion.SuspendLayout();
            this.hallazgos.SuspendLayout();
            this.devolucionCampo.SuspendLayout();
            this.equipoCampo.SuspendLayout();
            this.tipoCampo.SuspendLayout();
            this.descripcionCampo.SuspendLayout();
            this.tecnicaTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tecnicas)).BeginInit();
            this.altaTecnica.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.devolucionTab);
            this.tabs.Controls.Add(this.inspeccionTab);
            this.tabs.Controls.Add(this.tecnicaTab);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1180, 720);
            this.tabs.TabIndex = 0;
            // 
            // devolucionTab
            // 
            this.devolucionTab.Controls.Add(this.remito);
            this.devolucionTab.Controls.Add(this.cierreDevolucion);
            this.devolucionTab.Controls.Add(this.cabecera);
            this.devolucionTab.Location = new System.Drawing.Point(8, 51);
            this.devolucionTab.Name = "devolucionTab";
            this.devolucionTab.Padding = new System.Windows.Forms.Padding(3);
            this.devolucionTab.Size = new System.Drawing.Size(1164, 661);
            this.devolucionTab.TabIndex = 0;
            this.devolucionTab.Text = "Registrar devolución";
            this.devolucionTab.UseVisualStyleBackColor = true;
            // 
            // remito
            // 
            this.remito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.remito.Location = new System.Drawing.Point(3, 128);
            this.remito.Multiline = true;
            this.remito.Name = "remito";
            this.remito.ReadOnly = true;
            this.remito.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.remito.Size = new System.Drawing.Size(1158, 400);
            this.remito.TabIndex = 0;
            // 
            // cierreDevolucion
            // 
            this.cierreDevolucion.Controls.Add(this.observacionesCampo);
            this.cierreDevolucion.Controls.Add(this.registrarBoton);
            this.cierreDevolucion.Controls.Add(this.actualizarDevolucionBoton);
            this.cierreDevolucion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cierreDevolucion.Location = new System.Drawing.Point(3, 528);
            this.cierreDevolucion.Name = "cierreDevolucion";
            this.cierreDevolucion.Padding = new System.Windows.Forms.Padding(10);
            this.cierreDevolucion.Size = new System.Drawing.Size(1158, 130);
            this.cierreDevolucion.TabIndex = 1;
            // 
            // observacionesCampo
            // 
            this.observacionesCampo.Controls.Add(this.observacionesCampoLabel);
            this.observacionesCampo.Controls.Add(this.observaciones);
            this.observacionesCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.observacionesCampo.Location = new System.Drawing.Point(13, 13);
            this.observacionesCampo.Name = "observacionesCampo";
            this.observacionesCampo.Size = new System.Drawing.Size(690, 98);
            this.observacionesCampo.TabIndex = 0;
            // 
            // observacionesCampoLabel
            // 
            this.observacionesCampoLabel.AutoSize = true;
            this.observacionesCampoLabel.Location = new System.Drawing.Point(3, 0);
            this.observacionesCampoLabel.Name = "observacionesCampoLabel";
            this.observacionesCampoLabel.Size = new System.Drawing.Size(358, 37);
            this.observacionesCampoLabel.TabIndex = 0;
            this.observacionesCampoLabel.Text = "Observaciones de inspección";
            // 
            // observaciones
            // 
            this.observaciones.Location = new System.Drawing.Point(367, 3);
            this.observaciones.MaxLength = 500;
            this.observaciones.Multiline = true;
            this.observaciones.Name = "observaciones";
            this.observaciones.Size = new System.Drawing.Size(680, 65);
            this.observaciones.TabIndex = 1;
            // 
            // registrarBoton
            // 
            this.registrarBoton.AutoSize = true;
            this.registrarBoton.Location = new System.Drawing.Point(709, 13);
            this.registrarBoton.Name = "registrarBoton";
            this.registrarBoton.Size = new System.Drawing.Size(269, 47);
            this.registrarBoton.TabIndex = 1;
            this.registrarBoton.Text = "Registrar devolución";
            this.registrarBoton.UseVisualStyleBackColor = true;
            this.registrarBoton.Click += new System.EventHandler(this.RegistrarClick);
            // 
            // actualizarDevolucionBoton
            // 
            this.actualizarDevolucionBoton.AutoSize = true;
            this.actualizarDevolucionBoton.Location = new System.Drawing.Point(984, 13);
            this.actualizarDevolucionBoton.Name = "actualizarDevolucionBoton";
            this.actualizarDevolucionBoton.Size = new System.Drawing.Size(143, 47);
            this.actualizarDevolucionBoton.TabIndex = 2;
            this.actualizarDevolucionBoton.Text = "Actualizar";
            this.actualizarDevolucionBoton.UseVisualStyleBackColor = true;
            this.actualizarDevolucionBoton.Click += new System.EventHandler(this.CargarClick);
            // 
            // cabecera
            // 
            this.cabecera.Controls.Add(this.reservaCampo);
            this.cabecera.Controls.Add(this.fechaCampo);
            this.cabecera.Controls.Add(this.presente);
            this.cabecera.Controls.Add(this.conforme);
            this.cabecera.Controls.Add(this.cotejo);
            this.cabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.cabecera.Location = new System.Drawing.Point(3, 3);
            this.cabecera.Name = "cabecera";
            this.cabecera.Padding = new System.Windows.Forms.Padding(10);
            this.cabecera.Size = new System.Drawing.Size(1158, 125);
            this.cabecera.TabIndex = 2;
            // 
            // reservaCampo
            // 
            this.reservaCampo.Controls.Add(this.reservaCampoLabel);
            this.reservaCampo.Controls.Add(this.reserva);
            this.reservaCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.reservaCampo.Location = new System.Drawing.Point(13, 13);
            this.reservaCampo.Name = "reservaCampo";
            this.reservaCampo.Size = new System.Drawing.Size(345, 66);
            this.reservaCampo.TabIndex = 0;
            // 
            // reservaCampoLabel
            // 
            this.reservaCampoLabel.AutoSize = true;
            this.reservaCampoLabel.Location = new System.Drawing.Point(3, 0);
            this.reservaCampoLabel.Name = "reservaCampoLabel";
            this.reservaCampoLabel.Size = new System.Drawing.Size(231, 37);
            this.reservaCampoLabel.TabIndex = 0;
            this.reservaCampoLabel.Text = "Remito entregado";
            // 
            // reserva
            // 
            this.reserva.DisplayMember = "NumeroRemito";
            this.reserva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reserva.FormattingEnabled = true;
            this.reserva.Location = new System.Drawing.Point(240, 3);
            this.reserva.Name = "reserva";
            this.reserva.Size = new System.Drawing.Size(330, 45);
            this.reserva.TabIndex = 1;
            this.reserva.SelectedIndexChanged += new System.EventHandler(this.ReservaCambio);
            this.reserva.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.FormatearReserva);
            // 
            // fechaCampo
            // 
            this.fechaCampo.Controls.Add(this.fechaCampoLabel);
            this.fechaCampo.Controls.Add(this.fecha);
            this.fechaCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fechaCampo.Location = new System.Drawing.Point(364, 13);
            this.fechaCampo.Name = "fechaCampo";
            this.fechaCampo.Size = new System.Drawing.Size(220, 66);
            this.fechaCampo.TabIndex = 1;
            // 
            // fechaCampoLabel
            // 
            this.fechaCampoLabel.AutoSize = true;
            this.fechaCampoLabel.Location = new System.Drawing.Point(3, 0);
            this.fechaCampoLabel.Name = "fechaCampoLabel";
            this.fechaCampoLabel.Size = new System.Drawing.Size(210, 74);
            this.fechaCampoLabel.TabIndex = 0;
            this.fechaCampoLabel.Text = "Fecha y hora de devolución";
            // 
            // fecha
            // 
            this.fecha.CustomFormat = "dd/MM/yyyy HH:mm";
            this.fecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fecha.Location = new System.Drawing.Point(219, 3);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(205, 43);
            this.fecha.TabIndex = 1;
            // 
            // presente
            // 
            this.presente.AutoSize = true;
            this.presente.Location = new System.Drawing.Point(590, 13);
            this.presente.Name = "presente";
            this.presente.Size = new System.Drawing.Size(241, 41);
            this.presente.TabIndex = 2;
            this.presente.Text = "Cliente presente";
            // 
            // conforme
            // 
            this.conforme.AutoSize = true;
            this.conforme.Checked = true;
            this.conforme.CheckState = System.Windows.Forms.CheckState.Checked;
            this.conforme.Location = new System.Drawing.Point(13, 85);
            this.conforme.Name = "conforme";
            this.conforme.Size = new System.Drawing.Size(542, 41);
            this.conforme.TabIndex = 3;
            this.conforme.Text = "Todas las unidades conformes y sin atraso";
            // 
            // cotejo
            // 
            this.cotejo.AutoSize = true;
            this.cotejo.Location = new System.Drawing.Point(561, 85);
            this.cotejo.Name = "cotejo";
            this.cotejo.Size = new System.Drawing.Size(516, 41);
            this.cotejo.TabIndex = 4;
            this.cotejo.Text = "Cotejé todas las unidades con el remito";
            // 
            // inspeccionTab
            // 
            this.inspeccionTab.Controls.Add(this.incidencias);
            this.inspeccionTab.Controls.Add(this.cierreInspeccion);
            this.inspeccionTab.Controls.Add(this.hallazgos);
            this.inspeccionTab.Location = new System.Drawing.Point(8, 51);
            this.inspeccionTab.Name = "inspeccionTab";
            this.inspeccionTab.Padding = new System.Windows.Forms.Padding(3);
            this.inspeccionTab.Size = new System.Drawing.Size(184, 41);
            this.inspeccionTab.TabIndex = 1;
            this.inspeccionTab.Text = "Inspección y garantía";
            this.inspeccionTab.UseVisualStyleBackColor = true;
            // 
            // incidencias
            // 
            this.incidencias.AllowUserToAddRows = false;
            this.incidencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.incidencias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.incidencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.incidencias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.incidencias.Location = new System.Drawing.Point(3, 303);
            this.incidencias.MultiSelect = false;
            this.incidencias.Name = "incidencias";
            this.incidencias.ReadOnly = true;
            this.incidencias.RowHeadersWidth = 82;
            this.incidencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.incidencias.Size = new System.Drawing.Size(178, 0);
            this.incidencias.TabIndex = 0;
            this.incidencias.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.FormatearUnidad);
            // 
            // cierreInspeccion
            // 
            this.cierreInspeccion.Controls.Add(this.liquidacion);
            this.cierreInspeccion.Controls.Add(this.incidenciaBoton);
            this.cierreInspeccion.Controls.Add(this.finalizarBoton);
            this.cierreInspeccion.Controls.Add(this.actualizarInspeccionBoton);
            this.cierreInspeccion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cierreInspeccion.Location = new System.Drawing.Point(3, -102);
            this.cierreInspeccion.Name = "cierreInspeccion";
            this.cierreInspeccion.Padding = new System.Windows.Forms.Padding(10);
            this.cierreInspeccion.Size = new System.Drawing.Size(178, 140);
            this.cierreInspeccion.TabIndex = 1;
            // 
            // liquidacion
            // 
            this.liquidacion.AutoSize = true;
            this.cierreInspeccion.SetFlowBreak(this.liquidacion, true);
            this.liquidacion.Location = new System.Drawing.Point(13, 10);
            this.liquidacion.MaximumSize = new System.Drawing.Size(1090, 0);
            this.liquidacion.Name = "liquidacion";
            this.liquidacion.Size = new System.Drawing.Size(149, 222);
            this.liquidacion.TabIndex = 0;
            this.liquidacion.Text = "La garantía queda pendiente hasta finalizar la inspección.";
            // 
            // incidenciaBoton
            // 
            this.incidenciaBoton.AutoSize = true;
            this.incidenciaBoton.Location = new System.Drawing.Point(13, 235);
            this.incidenciaBoton.Name = "incidenciaBoton";
            this.incidenciaBoton.Size = new System.Drawing.Size(257, 47);
            this.incidenciaBoton.TabIndex = 1;
            this.incidenciaBoton.Text = "Registrar incidencia";
            this.incidenciaBoton.UseVisualStyleBackColor = true;
            this.incidenciaBoton.Click += new System.EventHandler(this.IncidenciaClick);
            // 
            // finalizarBoton
            // 
            this.finalizarBoton.AutoSize = true;
            this.finalizarBoton.Location = new System.Drawing.Point(13, 288);
            this.finalizarBoton.Name = "finalizarBoton";
            this.finalizarBoton.Size = new System.Drawing.Size(257, 47);
            this.finalizarBoton.TabIndex = 2;
            this.finalizarBoton.Text = "Finalizar inspección";
            this.finalizarBoton.UseVisualStyleBackColor = true;
            this.finalizarBoton.Click += new System.EventHandler(this.FinalizarClick);
            // 
            // actualizarInspeccionBoton
            // 
            this.actualizarInspeccionBoton.AutoSize = true;
            this.actualizarInspeccionBoton.Location = new System.Drawing.Point(13, 341);
            this.actualizarInspeccionBoton.Name = "actualizarInspeccionBoton";
            this.actualizarInspeccionBoton.Size = new System.Drawing.Size(143, 47);
            this.actualizarInspeccionBoton.TabIndex = 3;
            this.actualizarInspeccionBoton.Text = "Actualizar";
            this.actualizarInspeccionBoton.UseVisualStyleBackColor = true;
            this.actualizarInspeccionBoton.Click += new System.EventHandler(this.CargarClick);
            // 
            // hallazgos
            // 
            this.hallazgos.AutoScroll = true;
            this.hallazgos.Controls.Add(this.devolucionCampo);
            this.hallazgos.Controls.Add(this.equipoCampo);
            this.hallazgos.Controls.Add(this.tipoCampo);
            this.hallazgos.Controls.Add(this.descripcionCampo);
            this.hallazgos.Controls.Add(this.cargoBoton);
            this.hallazgos.Controls.Add(this.cargo);
            this.hallazgos.Dock = System.Windows.Forms.DockStyle.Top;
            this.hallazgos.Location = new System.Drawing.Point(3, 3);
            this.hallazgos.Name = "hallazgos";
            this.hallazgos.Padding = new System.Windows.Forms.Padding(10);
            this.hallazgos.Size = new System.Drawing.Size(178, 300);
            this.hallazgos.TabIndex = 2;
            // 
            // devolucionCampo
            // 
            this.devolucionCampo.Controls.Add(this.devolucionCampoLabel);
            this.devolucionCampo.Controls.Add(this.devolucion);
            this.devolucionCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.devolucionCampo.Location = new System.Drawing.Point(13, 13);
            this.devolucionCampo.Name = "devolucionCampo";
            this.devolucionCampo.Size = new System.Drawing.Size(350, 66);
            this.devolucionCampo.TabIndex = 0;
            // 
            // devolucionCampoLabel
            // 
            this.devolucionCampoLabel.AutoSize = true;
            this.devolucionCampoLabel.Location = new System.Drawing.Point(3, 0);
            this.devolucionCampoLabel.Name = "devolucionCampoLabel";
            this.devolucionCampoLabel.Size = new System.Drawing.Size(151, 37);
            this.devolucionCampoLabel.TabIndex = 0;
            this.devolucionCampoLabel.Text = "Devolución";
            // 
            // devolucion
            // 
            this.devolucion.DisplayMember = "Id";
            this.devolucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.devolucion.FormattingEnabled = true;
            this.devolucion.Location = new System.Drawing.Point(160, 3);
            this.devolucion.Name = "devolucion";
            this.devolucion.Size = new System.Drawing.Size(335, 45);
            this.devolucion.TabIndex = 1;
            this.devolucion.SelectedIndexChanged += new System.EventHandler(this.DevolucionCambio);
            this.devolucion.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.FormatearDevolucion);
            // 
            // equipoCampo
            // 
            this.equipoCampo.Controls.Add(this.equipoCampoLabel);
            this.equipoCampo.Controls.Add(this.equipo);
            this.equipoCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.equipoCampo.Location = new System.Drawing.Point(13, 85);
            this.equipoCampo.Name = "equipoCampo";
            this.equipoCampo.Size = new System.Drawing.Size(295, 66);
            this.equipoCampo.TabIndex = 1;
            // 
            // equipoCampoLabel
            // 
            this.equipoCampoLabel.AutoSize = true;
            this.equipoCampoLabel.Location = new System.Drawing.Point(3, 0);
            this.equipoCampoLabel.Name = "equipoCampoLabel";
            this.equipoCampoLabel.Size = new System.Drawing.Size(262, 74);
            this.equipoCampoLabel.TabIndex = 0;
            this.equipoCampoLabel.Text = "Equipo afectado del remito";
            // 
            // equipo
            // 
            this.equipo.DisplayMember = "CodigoInventario";
            this.equipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.equipo.DropDownWidth = 600;
            this.equipo.FormattingEnabled = true;
            this.equipo.Location = new System.Drawing.Point(271, 3);
            this.equipo.Name = "equipo";
            this.equipo.Size = new System.Drawing.Size(280, 45);
            this.equipo.TabIndex = 1;
            this.equipo.SelectedIndexChanged += new System.EventHandler(this.CargoCambio);
            this.equipo.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.FormatearEquipo);
            // 
            // tipoCampo
            // 
            this.tipoCampo.Controls.Add(this.tipoCampoLabel);
            this.tipoCampo.Controls.Add(this.tipo);
            this.tipoCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.tipoCampo.Location = new System.Drawing.Point(314, 85);
            this.tipoCampo.Name = "tipoCampo";
            this.tipoCampo.Size = new System.Drawing.Size(205, 66);
            this.tipoCampo.TabIndex = 2;
            // 
            // tipoCampoLabel
            // 
            this.tipoCampoLabel.AutoSize = true;
            this.tipoCampoLabel.Location = new System.Drawing.Point(3, 0);
            this.tipoCampoLabel.Name = "tipoCampoLabel";
            this.tipoCampoLabel.Size = new System.Drawing.Size(136, 74);
            this.tipoCampoLabel.TabIndex = 0;
            this.tipoCampoLabel.Text = "Tipo de incidencia";
            // 
            // tipo
            // 
            this.tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipo.FormattingEnabled = true;
            this.tipo.Items.AddRange(new object[] {
            "Atraso",
            "Faltante",
            "DañoReparable",
            "DañoTotal"});
            this.tipo.Location = new System.Drawing.Point(145, 3);
            this.tipo.Name = "tipo";
            this.tipo.Size = new System.Drawing.Size(190, 45);
            this.tipo.TabIndex = 1;
            this.tipo.SelectedIndexChanged += new System.EventHandler(this.CargoCambio);
            // 
            // descripcionCampo
            // 
            this.descripcionCampo.Controls.Add(this.descripcionCampoLabel);
            this.descripcionCampo.Controls.Add(this.descripcion);
            this.descripcionCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.descripcionCampo.Location = new System.Drawing.Point(13, 157);
            this.descripcionCampo.Name = "descripcionCampo";
            this.descripcionCampo.Size = new System.Drawing.Size(600, 92);
            this.descripcionCampo.TabIndex = 3;
            // 
            // descripcionCampoLabel
            // 
            this.descripcionCampoLabel.AutoSize = true;
            this.descripcionCampoLabel.Location = new System.Drawing.Point(3, 0);
            this.descripcionCampoLabel.Name = "descripcionCampoLabel";
            this.descripcionCampoLabel.Size = new System.Drawing.Size(307, 37);
            this.descripcionCampoLabel.TabIndex = 0;
            this.descripcionCampoLabel.Text = "Descripción del hallazgo";
            // 
            // descripcion
            // 
            this.descripcion.Location = new System.Drawing.Point(316, 3);
            this.descripcion.MaxLength = 500;
            this.descripcion.Multiline = true;
            this.descripcion.Name = "descripcion";
            this.descripcion.Size = new System.Drawing.Size(580, 62);
            this.descripcion.TabIndex = 1;
            // 
            // cargoBoton
            // 
            this.cargoBoton.AutoSize = true;
            this.hallazgos.SetFlowBreak(this.cargoBoton, true);
            this.cargoBoton.Location = new System.Drawing.Point(13, 255);
            this.cargoBoton.Name = "cargoBoton";
            this.cargoBoton.Size = new System.Drawing.Size(196, 47);
            this.cargoBoton.TabIndex = 4;
            this.cargoBoton.Text = "Calcular cargo";
            this.cargoBoton.UseVisualStyleBackColor = true;
            this.cargoBoton.Click += new System.EventHandler(this.CargoClick);
            // 
            // cargo
            // 
            this.cargo.AutoSize = true;
            this.cargo.Location = new System.Drawing.Point(13, 305);
            this.cargo.MaximumSize = new System.Drawing.Size(1100, 0);
            this.cargo.Name = "cargo";
            this.cargo.Size = new System.Drawing.Size(505, 37);
            this.cargo.TabIndex = 5;
            this.cargo.Text = "Elegí unidad y tipo para calcular el cargo.";
            // 
            // tecnicaTab
            // 
            this.tecnicaTab.Controls.Add(this.tecnicas);
            this.tecnicaTab.Controls.Add(this.altaTecnica);
            this.tecnicaTab.Location = new System.Drawing.Point(8, 51);
            this.tecnicaTab.Name = "tecnicaTab";
            this.tecnicaTab.Padding = new System.Windows.Forms.Padding(3);
            this.tecnicaTab.Size = new System.Drawing.Size(184, 41);
            this.tecnicaTab.TabIndex = 2;
            this.tecnicaTab.Text = "Alta técnica";
            this.tecnicaTab.UseVisualStyleBackColor = true;
            // 
            // tecnicas
            // 
            this.tecnicas.AllowUserToAddRows = false;
            this.tecnicas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tecnicas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tecnicas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tecnicas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tecnicas.Location = new System.Drawing.Point(3, 3);
            this.tecnicas.MultiSelect = false;
            this.tecnicas.Name = "tecnicas";
            this.tecnicas.ReadOnly = true;
            this.tecnicas.RowHeadersWidth = 82;
            this.tecnicas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tecnicas.Size = new System.Drawing.Size(178, 0);
            this.tecnicas.TabIndex = 0;
            this.tecnicas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.FormatearUnidad);
            this.tecnicas.SelectionChanged += new System.EventHandler(this.TecnicaCambio);
            // 
            // altaTecnica
            // 
            this.altaTecnica.Controls.Add(this.detalleTecnico);
            this.altaTecnica.Controls.Add(this.apta);
            this.altaTecnica.Controls.Add(this.altaBoton);
            this.altaTecnica.Controls.Add(this.actualizarTecnicaBoton);
            this.altaTecnica.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.altaTecnica.Location = new System.Drawing.Point(3, -207);
            this.altaTecnica.Name = "altaTecnica";
            this.altaTecnica.Padding = new System.Windows.Forms.Padding(10);
            this.altaTecnica.Size = new System.Drawing.Size(178, 245);
            this.altaTecnica.TabIndex = 1;
            // 
            // detalleTecnico
            // 
            this.altaTecnica.SetFlowBreak(this.detalleTecnico, true);
            this.detalleTecnico.Location = new System.Drawing.Point(13, 13);
            this.detalleTecnico.Multiline = true;
            this.detalleTecnico.Name = "detalleTecnico";
            this.detalleTecnico.ReadOnly = true;
            this.detalleTecnico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.detalleTecnico.Size = new System.Drawing.Size(1090, 130);
            this.detalleTecnico.TabIndex = 0;
            // 
            // apta
            // 
            this.apta.AutoSize = true;
            this.apta.Location = new System.Drawing.Point(13, 149);
            this.apta.Name = "apta";
            this.apta.Size = new System.Drawing.Size(833, 41);
            this.apta.TabIndex = 1;
            this.apta.Text = "Unidad recuperada / reparada, revisada y apta para volver al stock";
            // 
            // altaBoton
            // 
            this.altaBoton.AutoSize = true;
            this.altaBoton.Location = new System.Drawing.Point(13, 196);
            this.altaBoton.Name = "altaBoton";
            this.altaBoton.Size = new System.Drawing.Size(210, 47);
            this.altaBoton.TabIndex = 2;
            this.altaBoton.Text = "Dar alta técnica";
            this.altaBoton.UseVisualStyleBackColor = true;
            this.altaBoton.Click += new System.EventHandler(this.AltaClick);
            // 
            // actualizarTecnicaBoton
            // 
            this.actualizarTecnicaBoton.AutoSize = true;
            this.actualizarTecnicaBoton.Location = new System.Drawing.Point(13, 249);
            this.actualizarTecnicaBoton.Name = "actualizarTecnicaBoton";
            this.actualizarTecnicaBoton.Size = new System.Drawing.Size(143, 47);
            this.actualizarTecnicaBoton.TabIndex = 3;
            this.actualizarTecnicaBoton.Text = "Actualizar";
            this.actualizarTecnicaBoton.UseVisualStyleBackColor = true;
            this.actualizarTecnicaBoton.Click += new System.EventHandler(this.CargarClick);
            // 
            // DevolucionesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 720);
            this.Controls.Add(this.tabs);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "DevolucionesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "N02 · Devolución, incidencias y alta técnica";
            this.Load += new System.EventHandler(this.PrepararPantalla);
            this.Shown += new System.EventHandler(this.CargarClick);
            this.tabs.ResumeLayout(false);
            this.devolucionTab.ResumeLayout(false);
            this.devolucionTab.PerformLayout();
            this.cierreDevolucion.ResumeLayout(false);
            this.cierreDevolucion.PerformLayout();
            this.observacionesCampo.ResumeLayout(false);
            this.observacionesCampo.PerformLayout();
            this.cabecera.ResumeLayout(false);
            this.cabecera.PerformLayout();
            this.reservaCampo.ResumeLayout(false);
            this.reservaCampo.PerformLayout();
            this.fechaCampo.ResumeLayout(false);
            this.fechaCampo.PerformLayout();
            this.inspeccionTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.incidencias)).EndInit();
            this.cierreInspeccion.ResumeLayout(false);
            this.cierreInspeccion.PerformLayout();
            this.hallazgos.ResumeLayout(false);
            this.hallazgos.PerformLayout();
            this.devolucionCampo.ResumeLayout(false);
            this.devolucionCampo.PerformLayout();
            this.equipoCampo.ResumeLayout(false);
            this.equipoCampo.PerformLayout();
            this.tipoCampo.ResumeLayout(false);
            this.tipoCampo.PerformLayout();
            this.descripcionCampo.ResumeLayout(false);
            this.descripcionCampo.PerformLayout();
            this.tecnicaTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tecnicas)).EndInit();
            this.altaTecnica.ResumeLayout(false);
            this.altaTecnica.PerformLayout();
            this.ResumeLayout(false);

		}

#endregion
		private System.Windows.Forms.TabControl tabs;
		private System.Windows.Forms.TabPage devolucionTab;
		private System.Windows.Forms.TabPage inspeccionTab;
		private System.Windows.Forms.TabPage tecnicaTab;
		private System.Windows.Forms.FlowLayoutPanel cabecera;
		private System.Windows.Forms.ComboBox reserva;
		private System.Windows.Forms.DateTimePicker fecha;
		private System.Windows.Forms.FlowLayoutPanel reservaCampo;
		private System.Windows.Forms.Label reservaCampoLabel;
		private System.Windows.Forms.FlowLayoutPanel fechaCampo;
		private System.Windows.Forms.Label fechaCampoLabel;
		private System.Windows.Forms.CheckBox presente;
		private System.Windows.Forms.CheckBox conforme;
		private System.Windows.Forms.CheckBox cotejo;
		private System.Windows.Forms.TextBox remito;
		private System.Windows.Forms.FlowLayoutPanel cierreDevolucion;
		private System.Windows.Forms.TextBox observaciones;
		private System.Windows.Forms.FlowLayoutPanel observacionesCampo;
		private System.Windows.Forms.Label observacionesCampoLabel;
		private System.Windows.Forms.Button registrarBoton;
		private System.Windows.Forms.Button actualizarDevolucionBoton;
		private System.Windows.Forms.FlowLayoutPanel hallazgos;
		private System.Windows.Forms.ComboBox devolucion;
		private System.Windows.Forms.ComboBox equipo;
		private System.Windows.Forms.ComboBox tipo;
		private System.Windows.Forms.FlowLayoutPanel devolucionCampo;
		private System.Windows.Forms.Label devolucionCampoLabel;
		private System.Windows.Forms.FlowLayoutPanel equipoCampo;
		private System.Windows.Forms.Label equipoCampoLabel;
		private System.Windows.Forms.FlowLayoutPanel tipoCampo;
		private System.Windows.Forms.Label tipoCampoLabel;
		private System.Windows.Forms.TextBox descripcion;
		private System.Windows.Forms.FlowLayoutPanel descripcionCampo;
		private System.Windows.Forms.Label descripcionCampoLabel;
		private System.Windows.Forms.Button cargoBoton;
		private System.Windows.Forms.Label cargo;
		private System.Windows.Forms.DataGridView incidencias;
		private System.Windows.Forms.DataGridViewTextBoxColumn incidenciasIdColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn incidenciasEquipoIdColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn incidenciasTipoColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn incidenciasDescripcionColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn incidenciasCargoColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn incidenciasEstadoColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn incidenciasFechaAltaTecnicaColumna;
		private System.Windows.Forms.FlowLayoutPanel cierreInspeccion;
		private System.Windows.Forms.Label liquidacion;
		private System.Windows.Forms.Button incidenciaBoton;
		private System.Windows.Forms.Button finalizarBoton;
		private System.Windows.Forms.Button actualizarInspeccionBoton;
		private System.Windows.Forms.DataGridView tecnicas;
		private System.Windows.Forms.DataGridViewTextBoxColumn tecnicasIdColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn tecnicasEquipoIdColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn tecnicasTipoColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn tecnicasEstadoColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn tecnicasFechaAltaTecnicaColumna;
		private System.Windows.Forms.FlowLayoutPanel altaTecnica;
		private System.Windows.Forms.TextBox detalleTecnico;
		private System.Windows.Forms.CheckBox apta;
		private System.Windows.Forms.Button altaBoton;
		private System.Windows.Forms.Button actualizarTecnicaBoton;
	}
}
