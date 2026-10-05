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
			System.Windows.Forms.DataGridViewCellStyle incidenciasEncabezado = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle tecnicasEncabezado = new System.Windows.Forms.DataGridViewCellStyle();
			this.tabs = new System.Windows.Forms.TabControl();
			this.devolucionTab = new System.Windows.Forms.TabPage();
			this.inspeccionTab = new System.Windows.Forms.TabPage();
			this.tecnicaTab = new System.Windows.Forms.TabPage();
			this.cabecera = new System.Windows.Forms.FlowLayoutPanel();
			this.reserva = new System.Windows.Forms.ComboBox();
			this.fecha = new System.Windows.Forms.DateTimePicker();
			this.reservaCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.reservaCampoLabel = new System.Windows.Forms.Label();
			this.fechaCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.fechaCampoLabel = new System.Windows.Forms.Label();
			this.presente = new System.Windows.Forms.CheckBox();
			this.conforme = new System.Windows.Forms.CheckBox();
			this.cotejo = new System.Windows.Forms.CheckBox();
			this.remito = new System.Windows.Forms.TextBox();
			this.cierreDevolucion = new System.Windows.Forms.FlowLayoutPanel();
			this.observaciones = new System.Windows.Forms.TextBox();
			this.observacionesCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.observacionesCampoLabel = new System.Windows.Forms.Label();
			this.registrarBoton = new System.Windows.Forms.Button();
			this.actualizarDevolucionBoton = new System.Windows.Forms.Button();
			this.hallazgos = new System.Windows.Forms.FlowLayoutPanel();
			this.devolucion = new System.Windows.Forms.ComboBox();
			this.equipo = new System.Windows.Forms.ComboBox();
			this.tipo = new System.Windows.Forms.ComboBox();
			this.devolucionCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.devolucionCampoLabel = new System.Windows.Forms.Label();
			this.equipoCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.equipoCampoLabel = new System.Windows.Forms.Label();
			this.tipoCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.tipoCampoLabel = new System.Windows.Forms.Label();
			this.descripcion = new System.Windows.Forms.TextBox();
			this.descripcionCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.descripcionCampoLabel = new System.Windows.Forms.Label();
			this.cargoBoton = new System.Windows.Forms.Button();
			this.cargo = new System.Windows.Forms.Label();
			this.incidencias = new System.Windows.Forms.DataGridView();
			this.incidenciasIdColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.incidenciasEquipoIdColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.incidenciasTipoColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.incidenciasDescripcionColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.incidenciasCargoColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.incidenciasEstadoColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.incidenciasFechaAltaTecnicaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cierreInspeccion = new System.Windows.Forms.FlowLayoutPanel();
			this.liquidacion = new System.Windows.Forms.Label();
			this.incidenciaBoton = new System.Windows.Forms.Button();
			this.finalizarBoton = new System.Windows.Forms.Button();
			this.actualizarInspeccionBoton = new System.Windows.Forms.Button();
			this.tecnicas = new System.Windows.Forms.DataGridView();
			this.tecnicasIdColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tecnicasEquipoIdColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tecnicasTipoColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tecnicasEstadoColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tecnicasFechaAltaTecnicaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.altaTecnica = new System.Windows.Forms.FlowLayoutPanel();
			this.detalleTecnico = new System.Windows.Forms.TextBox();
			this.apta = new System.Windows.Forms.CheckBox();
			this.altaBoton = new System.Windows.Forms.Button();
			this.actualizarTecnicaBoton = new System.Windows.Forms.Button();
			this.tabs.SuspendLayout();
			this.devolucionTab.SuspendLayout();
			this.inspeccionTab.SuspendLayout();
			this.tecnicaTab.SuspendLayout();
			this.cabecera.SuspendLayout();
			this.reservaCampo.SuspendLayout();
			this.fechaCampo.SuspendLayout();
			this.cierreDevolucion.SuspendLayout();
			this.observacionesCampo.SuspendLayout();
			this.hallazgos.SuspendLayout();
			this.devolucionCampo.SuspendLayout();
			this.equipoCampo.SuspendLayout();
			this.tipoCampo.SuspendLayout();
			this.descripcionCampo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.incidencias)).BeginInit();
			this.cierreInspeccion.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tecnicas)).BeginInit();
			this.altaTecnica.SuspendLayout();
			this.SuspendLayout();
			// tabs
			this.tabs.Name = "tabs";
			// devolucionTab
			this.devolucionTab.Name = "devolucionTab";
			// inspeccionTab
			this.inspeccionTab.Name = "inspeccionTab";
			// tecnicaTab
			this.tecnicaTab.Name = "tecnicaTab";
			// cabecera
			this.cabecera.Name = "cabecera";
			// reserva
			this.reserva.Name = "reserva";
			// fecha
			this.fecha.Name = "fecha";
			// reservaCampo
			this.reservaCampo.Name = "reservaCampo";
			// reservaCampoLabel
			this.reservaCampoLabel.Name = "reservaCampoLabel";
			// fechaCampo
			this.fechaCampo.Name = "fechaCampo";
			// fechaCampoLabel
			this.fechaCampoLabel.Name = "fechaCampoLabel";
			// presente
			this.presente.Name = "presente";
			// conforme
			this.conforme.Name = "conforme";
			// cotejo
			this.cotejo.Name = "cotejo";
			// remito
			this.remito.Name = "remito";
			// cierreDevolucion
			this.cierreDevolucion.Name = "cierreDevolucion";
			// observaciones
			this.observaciones.Name = "observaciones";
			// observacionesCampo
			this.observacionesCampo.Name = "observacionesCampo";
			// observacionesCampoLabel
			this.observacionesCampoLabel.Name = "observacionesCampoLabel";
			// registrarBoton
			this.registrarBoton.Name = "registrarBoton";
			// actualizarDevolucionBoton
			this.actualizarDevolucionBoton.Name = "actualizarDevolucionBoton";
			// hallazgos
			this.hallazgos.Name = "hallazgos";
			// devolucion
			this.devolucion.Name = "devolucion";
			// equipo
			this.equipo.Name = "equipo";
			// tipo
			this.tipo.Name = "tipo";
			// devolucionCampo
			this.devolucionCampo.Name = "devolucionCampo";
			// devolucionCampoLabel
			this.devolucionCampoLabel.Name = "devolucionCampoLabel";
			// equipoCampo
			this.equipoCampo.Name = "equipoCampo";
			// equipoCampoLabel
			this.equipoCampoLabel.Name = "equipoCampoLabel";
			// tipoCampo
			this.tipoCampo.Name = "tipoCampo";
			// tipoCampoLabel
			this.tipoCampoLabel.Name = "tipoCampoLabel";
			// descripcion
			this.descripcion.Name = "descripcion";
			// descripcionCampo
			this.descripcionCampo.Name = "descripcionCampo";
			// descripcionCampoLabel
			this.descripcionCampoLabel.Name = "descripcionCampoLabel";
			// cargoBoton
			this.cargoBoton.Name = "cargoBoton";
			// cargo
			this.cargo.Name = "cargo";
			// incidencias
			this.incidencias.Name = "incidencias";
			// incidenciasIdColumna
			this.incidenciasIdColumna.Name = "incidenciasIdColumna";
			// incidenciasEquipoIdColumna
			this.incidenciasEquipoIdColumna.Name = "incidenciasEquipoIdColumna";
			// incidenciasTipoColumna
			this.incidenciasTipoColumna.Name = "incidenciasTipoColumna";
			// incidenciasDescripcionColumna
			this.incidenciasDescripcionColumna.Name = "incidenciasDescripcionColumna";
			// incidenciasCargoColumna
			this.incidenciasCargoColumna.Name = "incidenciasCargoColumna";
			// incidenciasEstadoColumna
			this.incidenciasEstadoColumna.Name = "incidenciasEstadoColumna";
			// incidenciasFechaAltaTecnicaColumna
			this.incidenciasFechaAltaTecnicaColumna.Name = "incidenciasFechaAltaTecnicaColumna";
			// cierreInspeccion
			this.cierreInspeccion.Name = "cierreInspeccion";
			// liquidacion
			this.liquidacion.Name = "liquidacion";
			// incidenciaBoton
			this.incidenciaBoton.Name = "incidenciaBoton";
			// finalizarBoton
			this.finalizarBoton.Name = "finalizarBoton";
			// actualizarInspeccionBoton
			this.actualizarInspeccionBoton.Name = "actualizarInspeccionBoton";
			// tecnicas
			this.tecnicas.Name = "tecnicas";
			// tecnicasIdColumna
			this.tecnicasIdColumna.Name = "tecnicasIdColumna";
			// tecnicasEquipoIdColumna
			this.tecnicasEquipoIdColumna.Name = "tecnicasEquipoIdColumna";
			// tecnicasTipoColumna
			this.tecnicasTipoColumna.Name = "tecnicasTipoColumna";
			// tecnicasEstadoColumna
			this.tecnicasEstadoColumna.Name = "tecnicasEstadoColumna";
			// tecnicasFechaAltaTecnicaColumna
			this.tecnicasFechaAltaTecnicaColumna.Name = "tecnicasFechaAltaTecnicaColumna";
			// altaTecnica
			this.altaTecnica.Name = "altaTecnica";
			// detalleTecnico
			this.detalleTecnico.Name = "detalleTecnico";
			// apta
			this.apta.Name = "apta";
			// altaBoton
			this.altaBoton.Name = "altaBoton";
			// actualizarTecnicaBoton
			this.actualizarTecnicaBoton.Name = "actualizarTecnicaBoton";
			this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabs.SelectedIndex = 0;
			this.devolucionTab.Text = "Registrar devolución";
			this.devolucionTab.UseVisualStyleBackColor = true;
			this.devolucionTab.Padding = new System.Windows.Forms.Padding(3);
			this.inspeccionTab.Text = "Inspección y garantía";
			this.inspeccionTab.UseVisualStyleBackColor = true;
			this.inspeccionTab.Padding = new System.Windows.Forms.Padding(3);
			this.tecnicaTab.Text = "Alta técnica";
			this.tecnicaTab.UseVisualStyleBackColor = true;
			this.tecnicaTab.Padding = new System.Windows.Forms.Padding(3);
			this.cabecera.Padding = new System.Windows.Forms.Padding(10);
			this.cabecera.Dock = System.Windows.Forms.DockStyle.Top;
			this.cabecera.Size = new System.Drawing.Size(1180, 125);
			this.reserva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.reserva.Size = new System.Drawing.Size(330, 25);
			this.reserva.FormattingEnabled = true;
			this.reserva.DisplayMember = "NumeroRemito";
			this.fecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.fecha.Size = new System.Drawing.Size(205, 25);
			this.fecha.CustomFormat = "dd/MM/yyyy HH:mm";
			this.reservaCampo.Padding = new System.Windows.Forms.Padding(0);
			this.reservaCampo.Size = new System.Drawing.Size(345, 66);
			this.reservaCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.reservaCampoLabel.Text = "Remito entregado";
			this.reservaCampoLabel.AutoSize = true;
			this.fechaCampo.Padding = new System.Windows.Forms.Padding(0);
			this.fechaCampo.Size = new System.Drawing.Size(220, 66);
			this.fechaCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.fechaCampoLabel.Text = "Fecha y hora de devolución";
			this.fechaCampoLabel.AutoSize = true;
			this.presente.Text = "Cliente presente";
			this.presente.AutoSize = true;
			this.conforme.Text = "Todas las unidades conformes y sin atraso";
			this.conforme.AutoSize = true;
			this.conforme.Checked = true;
			this.cotejo.Text = "Cotejé todas las unidades con el remito";
			this.cotejo.AutoSize = true;
			this.remito.Dock = System.Windows.Forms.DockStyle.Fill;
			this.remito.Multiline = true;
			this.remito.ReadOnly = true;
			this.remito.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.cierreDevolucion.Padding = new System.Windows.Forms.Padding(10);
			this.cierreDevolucion.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.cierreDevolucion.Size = new System.Drawing.Size(1180, 130);
			this.observaciones.Multiline = true;
			this.observaciones.MaxLength = 500;
			this.observaciones.Size = new System.Drawing.Size(680, 65);
			this.observacionesCampo.Padding = new System.Windows.Forms.Padding(0);
			this.observacionesCampo.Size = new System.Drawing.Size(690, 98);
			this.observacionesCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.observacionesCampoLabel.Text = "Observaciones de inspección";
			this.observacionesCampoLabel.AutoSize = true;
			this.registrarBoton.Text = "Registrar devolución";
			this.registrarBoton.AutoSize = true;
			this.registrarBoton.Size = new System.Drawing.Size(120, 36);
			this.registrarBoton.UseVisualStyleBackColor = true;
			this.actualizarDevolucionBoton.Text = "Actualizar";
			this.actualizarDevolucionBoton.AutoSize = true;
			this.actualizarDevolucionBoton.Size = new System.Drawing.Size(120, 36);
			this.actualizarDevolucionBoton.UseVisualStyleBackColor = true;
			this.hallazgos.Padding = new System.Windows.Forms.Padding(10);
			this.hallazgos.Dock = System.Windows.Forms.DockStyle.Top;
			this.hallazgos.Size = new System.Drawing.Size(1180, 300);
			this.hallazgos.AutoScroll = true;
			this.devolucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.devolucion.Size = new System.Drawing.Size(335, 25);
			this.devolucion.FormattingEnabled = true;
			this.devolucion.DisplayMember = "Id";
			this.equipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.equipo.Size = new System.Drawing.Size(280, 25);
			this.equipo.DropDownWidth = 600;
			this.equipo.FormattingEnabled = true;
			this.equipo.DisplayMember = "CodigoInventario";
			this.tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tipo.Size = new System.Drawing.Size(190, 25);
			this.tipo.FormattingEnabled = true;
			this.tipo.Items.AddRange(new object[] { "Atraso", "Faltante", "DañoReparable", "DañoTotal" });
			this.tipo.SelectedIndex = 0;
			this.devolucionCampo.Padding = new System.Windows.Forms.Padding(0);
			this.devolucionCampo.Size = new System.Drawing.Size(350, 66);
			this.devolucionCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.devolucionCampoLabel.Text = "Devolución";
			this.devolucionCampoLabel.AutoSize = true;
			this.equipoCampo.Padding = new System.Windows.Forms.Padding(0);
			this.equipoCampo.Size = new System.Drawing.Size(295, 66);
			this.equipoCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.equipoCampoLabel.Text = "Equipo afectado del remito";
			this.equipoCampoLabel.AutoSize = true;
			this.tipoCampo.Padding = new System.Windows.Forms.Padding(0);
			this.tipoCampo.Size = new System.Drawing.Size(205, 66);
			this.tipoCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.tipoCampoLabel.Text = "Tipo de incidencia";
			this.tipoCampoLabel.AutoSize = true;
			this.descripcion.Multiline = true;
			this.descripcion.MaxLength = 500;
			this.descripcion.Size = new System.Drawing.Size(580, 62);
			this.descripcionCampo.Padding = new System.Windows.Forms.Padding(0);
			this.descripcionCampo.Size = new System.Drawing.Size(600, 92);
			this.descripcionCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.descripcionCampoLabel.Text = "Descripción del hallazgo";
			this.descripcionCampoLabel.AutoSize = true;
			this.cargoBoton.Text = "Calcular cargo";
			this.cargoBoton.AutoSize = true;
			this.cargoBoton.Size = new System.Drawing.Size(120, 36);
			this.cargoBoton.UseVisualStyleBackColor = true;
			this.cargo.Text = "Elegí unidad y tipo para calcular el cargo.";
			this.cargo.AutoSize = true;
			this.cargo.MaximumSize = new System.Drawing.Size(1100, 0);
			this.incidencias.Dock = System.Windows.Forms.DockStyle.Fill;
			this.incidencias.ReadOnly = true;
			this.incidencias.AutoGenerateColumns = false;
			this.incidencias.AllowUserToAddRows = false;
			this.incidencias.MultiSelect = false;
			this.incidencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.incidencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.incidencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			incidenciasEncabezado.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.incidencias.ColumnHeadersDefaultCellStyle = incidenciasEncabezado;
			this.incidenciasIdColumna.DataPropertyName = "Id";
			this.incidenciasIdColumna.HeaderText = "Id";
			this.incidenciasIdColumna.ReadOnly = true;
			this.incidenciasEquipoIdColumna.DataPropertyName = "EquipoId";
			this.incidenciasEquipoIdColumna.HeaderText = "Inventario";
			this.incidenciasEquipoIdColumna.ReadOnly = true;
			this.incidenciasTipoColumna.DataPropertyName = "Tipo";
			this.incidenciasTipoColumna.HeaderText = "Tipo";
			this.incidenciasTipoColumna.ReadOnly = true;
			this.incidenciasDescripcionColumna.DataPropertyName = "Descripcion";
			this.incidenciasDescripcionColumna.HeaderText = "Hallazgo";
			this.incidenciasDescripcionColumna.ReadOnly = true;
			this.incidenciasCargoColumna.DataPropertyName = "Cargo";
			this.incidenciasCargoColumna.HeaderText = "Cargo ARS";
			this.incidenciasCargoColumna.ReadOnly = true;
			this.incidenciasEstadoColumna.DataPropertyName = "Estado";
			this.incidenciasEstadoColumna.HeaderText = "Estado";
			this.incidenciasEstadoColumna.ReadOnly = true;
			this.incidenciasFechaAltaTecnicaColumna.DataPropertyName = "FechaAltaTecnica";
			this.incidenciasFechaAltaTecnicaColumna.HeaderText = "Alta técnica";
			this.incidenciasFechaAltaTecnicaColumna.ReadOnly = true;
			this.incidencias.Columns.AddRange(
				new System.Windows.Forms.DataGridViewColumn[] { this.incidenciasIdColumna, this.incidenciasEquipoIdColumna, this.incidenciasTipoColumna, this.incidenciasDescripcionColumna, this.incidenciasCargoColumna, this.incidenciasEstadoColumna, this.incidenciasFechaAltaTecnicaColumna }
			);
			this.cierreInspeccion.Padding = new System.Windows.Forms.Padding(10);
			this.cierreInspeccion.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.cierreInspeccion.Size = new System.Drawing.Size(1180, 140);
			this.liquidacion.Text = "La garantía queda pendiente hasta finalizar la inspección.";
			this.liquidacion.AutoSize = true;
			this.liquidacion.MaximumSize = new System.Drawing.Size(1090, 0);
			this.cierreInspeccion.SetFlowBreak(this.liquidacion, true);
			this.incidenciaBoton.Text = "Registrar incidencia";
			this.incidenciaBoton.AutoSize = true;
			this.incidenciaBoton.Size = new System.Drawing.Size(120, 36);
			this.incidenciaBoton.UseVisualStyleBackColor = true;
			this.finalizarBoton.Text = "Finalizar inspección";
			this.finalizarBoton.AutoSize = true;
			this.finalizarBoton.Size = new System.Drawing.Size(120, 36);
			this.finalizarBoton.UseVisualStyleBackColor = true;
			this.actualizarInspeccionBoton.Text = "Actualizar";
			this.actualizarInspeccionBoton.AutoSize = true;
			this.actualizarInspeccionBoton.Size = new System.Drawing.Size(120, 36);
			this.actualizarInspeccionBoton.UseVisualStyleBackColor = true;
			this.tecnicas.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tecnicas.ReadOnly = true;
			this.tecnicas.AutoGenerateColumns = false;
			this.tecnicas.AllowUserToAddRows = false;
			this.tecnicas.MultiSelect = false;
			this.tecnicas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.tecnicas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.tecnicas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			tecnicasEncabezado.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.tecnicas.ColumnHeadersDefaultCellStyle = tecnicasEncabezado;
			this.tecnicasIdColumna.DataPropertyName = "Id";
			this.tecnicasIdColumna.HeaderText = "Id";
			this.tecnicasIdColumna.ReadOnly = true;
			this.tecnicasEquipoIdColumna.DataPropertyName = "EquipoId";
			this.tecnicasEquipoIdColumna.HeaderText = "Inventario";
			this.tecnicasEquipoIdColumna.ReadOnly = true;
			this.tecnicasTipoColumna.DataPropertyName = "Tipo";
			this.tecnicasTipoColumna.HeaderText = "Tipo";
			this.tecnicasTipoColumna.ReadOnly = true;
			this.tecnicasEstadoColumna.DataPropertyName = "Estado";
			this.tecnicasEstadoColumna.HeaderText = "Estado";
			this.tecnicasEstadoColumna.ReadOnly = true;
			this.tecnicasFechaAltaTecnicaColumna.DataPropertyName = "FechaAltaTecnica";
			this.tecnicasFechaAltaTecnicaColumna.HeaderText = "Alta técnica";
			this.tecnicasFechaAltaTecnicaColumna.ReadOnly = true;
			this.tecnicas.Columns.AddRange(
				new System.Windows.Forms.DataGridViewColumn[] { this.tecnicasIdColumna, this.tecnicasEquipoIdColumna, this.tecnicasTipoColumna, this.tecnicasEstadoColumna, this.tecnicasFechaAltaTecnicaColumna }
			);
			this.altaTecnica.Padding = new System.Windows.Forms.Padding(10);
			this.altaTecnica.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.altaTecnica.Size = new System.Drawing.Size(1180, 245);
			this.detalleTecnico.ReadOnly = true;
			this.detalleTecnico.Multiline = true;
			this.detalleTecnico.Size = new System.Drawing.Size(1090, 130);
			this.detalleTecnico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.altaTecnica.SetFlowBreak(this.detalleTecnico, true);
			this.apta.Text = "Unidad recuperada / reparada, revisada y apta para volver al stock";
			this.apta.AutoSize = true;
			this.altaBoton.Text = "Dar alta técnica";
			this.altaBoton.AutoSize = true;
			this.altaBoton.Size = new System.Drawing.Size(120, 36);
			this.altaBoton.UseVisualStyleBackColor = true;
			this.actualizarTecnicaBoton.Text = "Actualizar";
			this.actualizarTecnicaBoton.AutoSize = true;
			this.actualizarTecnicaBoton.Size = new System.Drawing.Size(120, 36);
			this.actualizarTecnicaBoton.UseVisualStyleBackColor = true;
			this.tabs.Controls.Add(this.devolucionTab);
			this.tabs.Controls.Add(this.inspeccionTab);
			this.tabs.Controls.Add(this.tecnicaTab);
			this.Controls.Add(this.tabs);
			this.reservaCampo.Controls.Add(this.reservaCampoLabel);
			this.reservaCampo.Controls.Add(this.reserva);
			this.cabecera.Controls.Add(this.reservaCampo);
			this.fechaCampo.Controls.Add(this.fechaCampoLabel);
			this.fechaCampo.Controls.Add(this.fecha);
			this.cabecera.Controls.Add(this.fechaCampo);
			this.cabecera.Controls.Add(this.presente);
			this.cabecera.Controls.Add(this.conforme);
			this.cabecera.Controls.Add(this.cotejo);
			this.observacionesCampo.Controls.Add(this.observacionesCampoLabel);
			this.observacionesCampo.Controls.Add(this.observaciones);
			this.cierreDevolucion.Controls.Add(this.observacionesCampo);
			this.cierreDevolucion.Controls.Add(this.registrarBoton);
			this.cierreDevolucion.Controls.Add(this.actualizarDevolucionBoton);
			this.devolucionTab.Controls.Add(this.remito);
			this.devolucionTab.Controls.Add(this.cierreDevolucion);
			this.devolucionTab.Controls.Add(this.cabecera);
			this.devolucionCampo.Controls.Add(this.devolucionCampoLabel);
			this.devolucionCampo.Controls.Add(this.devolucion);
			this.hallazgos.Controls.Add(this.devolucionCampo);
			this.equipoCampo.Controls.Add(this.equipoCampoLabel);
			this.equipoCampo.Controls.Add(this.equipo);
			this.hallazgos.Controls.Add(this.equipoCampo);
			this.tipoCampo.Controls.Add(this.tipoCampoLabel);
			this.tipoCampo.Controls.Add(this.tipo);
			this.hallazgos.Controls.Add(this.tipoCampo);
			this.descripcionCampo.Controls.Add(this.descripcionCampoLabel);
			this.descripcionCampo.Controls.Add(this.descripcion);
			this.hallazgos.Controls.Add(this.descripcionCampo);
			this.hallazgos.Controls.Add(this.cargoBoton);
			this.hallazgos.Controls.Add(this.cargo);
			this.hallazgos.SetFlowBreak(this.cargoBoton, true);
			this.cierreInspeccion.Controls.Add(this.liquidacion);
			this.cierreInspeccion.Controls.Add(this.incidenciaBoton);
			this.cierreInspeccion.Controls.Add(this.finalizarBoton);
			this.cierreInspeccion.Controls.Add(this.actualizarInspeccionBoton);
			this.inspeccionTab.Controls.Add(this.incidencias);
			this.inspeccionTab.Controls.Add(this.cierreInspeccion);
			this.inspeccionTab.Controls.Add(this.hallazgos);
			this.altaTecnica.Controls.Add(this.detalleTecnico);
			this.altaTecnica.Controls.Add(this.apta);
			this.altaTecnica.Controls.Add(this.altaBoton);
			this.altaTecnica.Controls.Add(this.actualizarTecnicaBoton);
			this.tecnicaTab.Controls.Add(this.tecnicas);
			this.tecnicaTab.Controls.Add(this.altaTecnica);
			this.registrarBoton.Click += new System.EventHandler(this.RegistrarClick);
			this.actualizarDevolucionBoton.Click += new System.EventHandler(this.CargarClick);
			this.cargoBoton.Click += new System.EventHandler(this.CargoClick);
			this.incidenciaBoton.Click += new System.EventHandler(this.IncidenciaClick);
			this.finalizarBoton.Click += new System.EventHandler(this.FinalizarClick);
			this.actualizarInspeccionBoton.Click += new System.EventHandler(this.CargarClick);
			this.altaBoton.Click += new System.EventHandler(this.AltaClick);
			this.actualizarTecnicaBoton.Click += new System.EventHandler(this.CargarClick);
			this.reserva.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.FormatearReserva);
			this.devolucion.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.FormatearDevolucion);
			this.equipo.SelectedIndexChanged += new System.EventHandler(this.CargoCambio);
			this.tipo.SelectedIndexChanged += new System.EventHandler(this.CargoCambio);
			this.equipo.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.FormatearEquipo);
			this.reserva.SelectedIndexChanged += new System.EventHandler(this.ReservaCambio);
			this.devolucion.SelectedIndexChanged += new System.EventHandler(this.DevolucionCambio);
			this.tecnicas.SelectionChanged += new System.EventHandler(this.TecnicaCambio);
			this.incidencias.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.FormatearUnidad);
			this.tecnicas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.FormatearUnidad);
			this.Load += new System.EventHandler(this.PrepararPantalla);
			this.Shown += new System.EventHandler(this.CargarClick);
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1180, 720);
			this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Name = "DevolucionesForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "N02 · Devolución, incidencias y alta técnica";
			this.tabs.ResumeLayout(false);
			this.tabs.PerformLayout();
			this.devolucionTab.ResumeLayout(false);
			this.devolucionTab.PerformLayout();
			this.inspeccionTab.ResumeLayout(false);
			this.inspeccionTab.PerformLayout();
			this.tecnicaTab.ResumeLayout(false);
			this.tecnicaTab.PerformLayout();
			this.cabecera.ResumeLayout(false);
			this.cabecera.PerformLayout();
			this.reservaCampo.ResumeLayout(false);
			this.reservaCampo.PerformLayout();
			this.fechaCampo.ResumeLayout(false);
			this.fechaCampo.PerformLayout();
			this.cierreDevolucion.ResumeLayout(false);
			this.cierreDevolucion.PerformLayout();
			this.observacionesCampo.ResumeLayout(false);
			this.observacionesCampo.PerformLayout();
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
			((System.ComponentModel.ISupportInitialize)(this.incidencias)).EndInit();
			this.cierreInspeccion.ResumeLayout(false);
			this.cierreInspeccion.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tecnicas)).EndInit();
			this.altaTecnica.ResumeLayout(false);
			this.altaTecnica.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
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
