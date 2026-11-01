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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.tabs = new System.Windows.Forms.TabControl();
			this.devolucionTab = new System.Windows.Forms.TabPage();
			this.devolucionTabLayout = new System.Windows.Forms.TableLayoutPanel();
			this.cabecera = new System.Windows.Forms.TableLayoutPanel();
			this.reservaLabel = new System.Windows.Forms.Label();
			this.reserva = new System.Windows.Forms.ComboBox();
			this.fechaLabel = new System.Windows.Forms.Label();
			this.fecha = new System.Windows.Forms.DateTimePicker();
			this.fechaAyuda = new System.Windows.Forms.Label();
			this.controles = new System.Windows.Forms.FlowLayoutPanel();
			this.presente = new System.Windows.Forms.CheckBox();
			this.conforme = new System.Windows.Forms.CheckBox();
			this.cotejo = new System.Windows.Forms.CheckBox();
			this.remito = new System.Windows.Forms.TextBox();
			this.cierreDevolucion = new System.Windows.Forms.TableLayoutPanel();
			this.observacionesLabel = new System.Windows.Forms.Label();
			this.observaciones = new System.Windows.Forms.TextBox();
			this.devolucionAcciones = new System.Windows.Forms.FlowLayoutPanel();
			this.registrarBoton = new System.Windows.Forms.Button();
			this.actualizarDevolucionBoton = new System.Windows.Forms.Button();
			this.inspeccionTab = new System.Windows.Forms.TabPage();
			this.inspeccionTabLayout = new System.Windows.Forms.TableLayoutPanel();
			this.hallazgos = new System.Windows.Forms.TableLayoutPanel();
			this.devolucionLabel = new System.Windows.Forms.Label();
			this.devolucion = new System.Windows.Forms.ComboBox();
			this.equipoLabel = new System.Windows.Forms.Label();
			this.equipo = new System.Windows.Forms.ComboBox();
			this.tipoLabel = new System.Windows.Forms.Label();
			this.tipo = new System.Windows.Forms.ComboBox();
			this.descripcionLabel = new System.Windows.Forms.Label();
			this.descripcion = new System.Windows.Forms.TextBox();
			this.hallazgoAcciones = new System.Windows.Forms.FlowLayoutPanel();
			this.cargoBoton = new System.Windows.Forms.Button();
			this.incidenciaBoton = new System.Windows.Forms.Button();
			this.cargo = new System.Windows.Forms.Label();
			this.incidencias = new System.Windows.Forms.DataGridView();
			this.incidenciasIdColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.incidenciasEquipoIdColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.incidenciasTipoColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.incidenciasDescripcionColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.incidenciasCargoBaseColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.incidenciasDescuentoColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.incidenciasCargoColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.incidenciasEstadoColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cierreInspeccion = new System.Windows.Forms.TableLayoutPanel();
			this.liquidacion = new System.Windows.Forms.Label();
			this.inspeccionAcciones = new System.Windows.Forms.FlowLayoutPanel();
			this.finalizarBoton = new System.Windows.Forms.Button();
			this.actualizarInspeccionBoton = new System.Windows.Forms.Button();
			this.tecnicaTab = new System.Windows.Forms.TabPage();
			this.tecnicaTabLayout = new System.Windows.Forms.TableLayoutPanel();
			this.tecnicas = new System.Windows.Forms.DataGridView();
			this.tecnicasIdColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tecnicasEquipoIdColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tecnicasTipoColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tecnicasDescripcionColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tecnicasEstadoColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tecnicasFechaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.altaTecnica = new System.Windows.Forms.TableLayoutPanel();
			this.detalleTecnico = new System.Windows.Forms.TextBox();
			this.apta = new System.Windows.Forms.CheckBox();
			this.tecnicaAcciones = new System.Windows.Forms.FlowLayoutPanel();
			this.altaBoton = new System.Windows.Forms.Button();
			this.actualizarTecnicaBoton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			this.tabs.SuspendLayout();
			this.devolucionTab.SuspendLayout();
			this.devolucionTabLayout.SuspendLayout();
			this.cabecera.SuspendLayout();
			this.controles.SuspendLayout();
			this.cierreDevolucion.SuspendLayout();
			this.devolucionAcciones.SuspendLayout();
			this.inspeccionTab.SuspendLayout();
			this.inspeccionTabLayout.SuspendLayout();
			this.hallazgos.SuspendLayout();
			this.hallazgoAcciones.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.incidencias)).BeginInit();
			this.cierreInspeccion.SuspendLayout();
			this.inspeccionAcciones.SuspendLayout();
			this.tecnicaTab.SuspendLayout();
			this.tecnicaTabLayout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tecnicas)).BeginInit();
			this.altaTecnica.SuspendLayout();
			this.tecnicaAcciones.SuspendLayout();
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(15, 23, 42);
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
			dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254);
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
			dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(15, 23, 42);
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
			dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254);
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
			// 
			// DevolucionesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.ClientSize = new System.Drawing.Size(870, 640);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Controls.Add(this.tabs);
			this.Load += new System.EventHandler(this.DevolucionesForm_Load);
			// 
			// tabs
			// 
			this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabs.SelectedIndex = 0;
			this.tabs.ItemSize = new System.Drawing.Size(0, 34);
			this.tabs.Padding = new System.Drawing.Point(20, 6);
			this.tabs.TabIndex = 0;
			this.tabs.Name = "tabs";
			this.tabs.Controls.Add(this.devolucionTab);
			this.tabs.Controls.Add(this.inspeccionTab);
			this.tabs.Controls.Add(this.tecnicaTab);
			// 
			// devolucionTab
			// 
			this.devolucionTab.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.devolucionTab.Padding = new System.Windows.Forms.Padding(16, 16, 16, 16);
			this.devolucionTab.Text = "Registrar devolución";
			this.devolucionTab.UseVisualStyleBackColor = false;
			this.devolucionTab.TabIndex = 0;
			this.devolucionTab.Name = "devolucionTab";
			this.devolucionTab.Controls.Add(this.devolucionTabLayout);
			// 
			// devolucionTabLayout
			// 
			this.devolucionTabLayout.ColumnCount = 1;
			this.devolucionTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.devolucionTabLayout.RowCount = 3;
			this.devolucionTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.devolucionTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.devolucionTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.devolucionTabLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.devolucionTabLayout.BackColor = System.Drawing.Color.Transparent;
			this.devolucionTabLayout.TabIndex = 0;
			this.devolucionTabLayout.Name = "devolucionTabLayout";
			this.devolucionTabLayout.Controls.Add(this.cabecera, 0, 0);
			this.devolucionTabLayout.Controls.Add(this.remito, 0, 1);
			this.devolucionTabLayout.Controls.Add(this.cierreDevolucion, 0, 2);
			// 
			// cabecera
			// 
			this.cabecera.ColumnCount = 2;
			this.cabecera.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
			this.cabecera.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.cabecera.RowCount = 4;
			this.cabecera.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.cabecera.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.cabecera.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.cabecera.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.cabecera.AutoSize = true;
			this.cabecera.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cabecera.BackColor = System.Drawing.Color.White;
			this.cabecera.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cabecera.Padding = new System.Windows.Forms.Padding(18, 18, 18, 8);
			this.cabecera.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
			this.cabecera.TabIndex = 0;
			this.cabecera.Name = "cabecera";
			this.cabecera.Controls.Add(this.reservaLabel, 0, 0);
			this.cabecera.Controls.Add(this.reserva, 0, 1);
			this.cabecera.Controls.Add(this.fechaLabel, 1, 0);
			this.cabecera.Controls.Add(this.fecha, 1, 1);
			this.cabecera.Controls.Add(this.fechaAyuda, 1, 2);
			this.cabecera.Controls.Add(this.controles, 0, 3);
			this.cabecera.SetColumnSpan(this.controles, 2);
			// 
			// reservaLabel
			// 
			this.reservaLabel.AutoSize = true;
			this.reservaLabel.Text = "Remito entregado";
			this.reservaLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.reservaLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.reservaLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.reservaLabel.TabIndex = 0;
			this.reservaLabel.Name = "reservaLabel";
			// 
			// reserva
			// 
			this.reserva.Dock = System.Windows.Forms.DockStyle.Fill;
			this.reserva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.reserva.FormattingEnabled = true;
			this.reserva.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.reserva.DisplayMember = "NumeroRemito";
			this.reserva.TabIndex = 1;
			this.reserva.Name = "reserva";
			this.reserva.SelectedIndexChanged += new System.EventHandler(this.ReservaCambio);
			this.reserva.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.FormatearReserva);
			// 
			// fechaLabel
			// 
			this.fechaLabel.AutoSize = true;
			this.fechaLabel.Text = "Fecha y hora de devolución";
			this.fechaLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.fechaLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.fechaLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.fechaLabel.TabIndex = 2;
			this.fechaLabel.Name = "fechaLabel";
			// 
			// fecha
			// 
			this.fecha.Dock = System.Windows.Forms.DockStyle.Fill;
			this.fecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.fecha.CustomFormat = "dd/MM/yyyy HH:mm";
			this.fecha.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.fecha.TabIndex = 3;
			this.fecha.Name = "fecha";
			// 
			// fechaAyuda
			// 
			this.fechaAyuda.Text = "";
			this.fechaAyuda.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
			this.fechaAyuda.AutoSize = false;
			this.fechaAyuda.Dock = System.Windows.Forms.DockStyle.Fill;
			this.fechaAyuda.Size = new System.Drawing.Size(0, 36);
			this.fechaAyuda.Font = new System.Drawing.Font("Segoe UI", 8.5F);
			this.fechaAyuda.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
			this.fechaAyuda.TabIndex = 4;
			this.fechaAyuda.Name = "fechaAyuda";
			// 
			// controles
			// 
			this.controles.AutoSize = true;
			this.controles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.controles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controles.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.controles.WrapContents = false;
			this.controles.TabIndex = 5;
			this.controles.Name = "controles";
			this.controles.Controls.Add(this.presente);
			this.controles.Controls.Add(this.conforme);
			this.controles.Controls.Add(this.cotejo);
			// 
			// presente
			// 
			this.presente.AutoSize = true;
			this.presente.Text = "Cliente presente";
			this.presente.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.presente.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
			this.presente.UseVisualStyleBackColor = true;
			this.presente.TabIndex = 0;
			this.presente.Name = "presente";
			// 
			// conforme
			// 
			this.conforme.AutoSize = true;
			this.conforme.Text = "Todas las unidades conformes y sin atraso";
			this.conforme.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.conforme.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
			this.conforme.UseVisualStyleBackColor = true;
			this.conforme.Checked = true;
			this.conforme.TabIndex = 1;
			this.conforme.Name = "conforme";
			// 
			// cotejo
			// 
			this.cotejo.AutoSize = true;
			this.cotejo.Text = "Cotejé todas las unidades con el remito";
			this.cotejo.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.cotejo.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
			this.cotejo.UseVisualStyleBackColor = true;
			this.cotejo.TabIndex = 2;
			this.cotejo.Name = "cotejo";
			// 
			// remito
			// 
			this.remito.BackColor = System.Drawing.Color.White;
			this.remito.Dock = System.Windows.Forms.DockStyle.Fill;
			this.remito.Multiline = true;
			this.remito.ReadOnly = true;
			this.remito.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.remito.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
			this.remito.TabIndex = 1;
			this.remito.Name = "remito";
			// 
			// cierreDevolucion
			// 
			this.cierreDevolucion.ColumnCount = 1;
			this.cierreDevolucion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.cierreDevolucion.RowCount = 3;
			this.cierreDevolucion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.cierreDevolucion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.cierreDevolucion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.cierreDevolucion.AutoSize = true;
			this.cierreDevolucion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cierreDevolucion.BackColor = System.Drawing.Color.White;
			this.cierreDevolucion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cierreDevolucion.Padding = new System.Windows.Forms.Padding(18, 18, 18, 8);
			this.cierreDevolucion.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
			this.cierreDevolucion.TabIndex = 2;
			this.cierreDevolucion.Name = "cierreDevolucion";
			this.cierreDevolucion.Controls.Add(this.observacionesLabel, 0, 0);
			this.cierreDevolucion.Controls.Add(this.observaciones, 0, 1);
			this.cierreDevolucion.Controls.Add(this.devolucionAcciones, 0, 2);
			// 
			// observacionesLabel
			// 
			this.observacionesLabel.AutoSize = true;
			this.observacionesLabel.Text = "Observaciones de inspección";
			this.observacionesLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.observacionesLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.observacionesLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.observacionesLabel.TabIndex = 0;
			this.observacionesLabel.Name = "observacionesLabel";
			// 
			// observaciones
			// 
			this.observaciones.Dock = System.Windows.Forms.DockStyle.Fill;
			this.observaciones.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.observaciones.Multiline = true;
			this.observaciones.MaxLength = 500;
			this.observaciones.MinimumSize = new System.Drawing.Size(0, 56);
			this.observaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.observaciones.TabIndex = 1;
			this.observaciones.Name = "observaciones";
			// 
			// devolucionAcciones
			// 
			this.devolucionAcciones.AutoSize = true;
			this.devolucionAcciones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.devolucionAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
			this.devolucionAcciones.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.devolucionAcciones.TabIndex = 2;
			this.devolucionAcciones.Name = "devolucionAcciones";
			this.devolucionAcciones.Controls.Add(this.registrarBoton);
			this.devolucionAcciones.Controls.Add(this.actualizarDevolucionBoton);
			// 
			// registrarBoton
			// 
			this.registrarBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.registrarBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.registrarBoton.Size = new System.Drawing.Size(200, 38);
			this.registrarBoton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.registrarBoton.Text = "Registrar devolución";
			this.registrarBoton.UseVisualStyleBackColor = false;
			this.registrarBoton.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
			this.registrarBoton.ForeColor = System.Drawing.Color.White;
			this.registrarBoton.FlatAppearance.BorderSize = 0;
			this.registrarBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(29, 78, 216);
			this.registrarBoton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.registrarBoton.TabIndex = 0;
			this.registrarBoton.Name = "registrarBoton";
			this.registrarBoton.Click += new System.EventHandler(this.RegistrarClick);
			// 
			// actualizarDevolucionBoton
			// 
			this.actualizarDevolucionBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.actualizarDevolucionBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.actualizarDevolucionBoton.Size = new System.Drawing.Size(170, 38);
			this.actualizarDevolucionBoton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.actualizarDevolucionBoton.Text = "Actualizar";
			this.actualizarDevolucionBoton.UseVisualStyleBackColor = false;
			this.actualizarDevolucionBoton.BackColor = System.Drawing.Color.White;
			this.actualizarDevolucionBoton.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.actualizarDevolucionBoton.FlatAppearance.BorderSize = 1;
			this.actualizarDevolucionBoton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
			this.actualizarDevolucionBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.actualizarDevolucionBoton.TabIndex = 1;
			this.actualizarDevolucionBoton.Name = "actualizarDevolucionBoton";
			this.actualizarDevolucionBoton.Click += new System.EventHandler(this.CargarClick);
			// 
			// inspeccionTab
			// 
			this.inspeccionTab.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.inspeccionTab.Padding = new System.Windows.Forms.Padding(16, 16, 16, 16);
			this.inspeccionTab.Text = "Inspección y cargos";
			this.inspeccionTab.UseVisualStyleBackColor = false;
			this.inspeccionTab.TabIndex = 1;
			this.inspeccionTab.Name = "inspeccionTab";
			this.inspeccionTab.Controls.Add(this.inspeccionTabLayout);
			// 
			// inspeccionTabLayout
			// 
			this.inspeccionTabLayout.ColumnCount = 1;
			this.inspeccionTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.inspeccionTabLayout.RowCount = 3;
			this.inspeccionTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.inspeccionTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.inspeccionTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.inspeccionTabLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.inspeccionTabLayout.BackColor = System.Drawing.Color.Transparent;
			this.inspeccionTabLayout.TabIndex = 0;
			this.inspeccionTabLayout.Name = "inspeccionTabLayout";
			this.inspeccionTabLayout.Controls.Add(this.hallazgos, 0, 0);
			this.inspeccionTabLayout.Controls.Add(this.incidencias, 0, 1);
			this.inspeccionTabLayout.Controls.Add(this.cierreInspeccion, 0, 2);
			// 
			// hallazgos
			// 
			this.hallazgos.ColumnCount = 3;
			this.hallazgos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
			this.hallazgos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
			this.hallazgos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
			this.hallazgos.RowCount = 6;
			this.hallazgos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.hallazgos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.hallazgos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.hallazgos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.hallazgos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.hallazgos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.hallazgos.AutoSize = true;
			this.hallazgos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.hallazgos.BackColor = System.Drawing.Color.White;
			this.hallazgos.Dock = System.Windows.Forms.DockStyle.Fill;
			this.hallazgos.Padding = new System.Windows.Forms.Padding(18, 18, 18, 8);
			this.hallazgos.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
			this.hallazgos.TabIndex = 0;
			this.hallazgos.Name = "hallazgos";
			this.hallazgos.Controls.Add(this.devolucionLabel, 0, 0);
			this.hallazgos.Controls.Add(this.devolucion, 0, 1);
			this.hallazgos.Controls.Add(this.equipoLabel, 1, 0);
			this.hallazgos.Controls.Add(this.equipo, 1, 1);
			this.hallazgos.Controls.Add(this.tipoLabel, 2, 0);
			this.hallazgos.Controls.Add(this.tipo, 2, 1);
			this.hallazgos.Controls.Add(this.descripcionLabel, 0, 2);
			this.hallazgos.SetColumnSpan(this.descripcionLabel, 3);
			this.hallazgos.Controls.Add(this.descripcion, 0, 3);
			this.hallazgos.SetColumnSpan(this.descripcion, 3);
			this.hallazgos.Controls.Add(this.hallazgoAcciones, 0, 4);
			this.hallazgos.SetColumnSpan(this.hallazgoAcciones, 3);
			this.hallazgos.Controls.Add(this.cargo, 0, 5);
			this.hallazgos.SetColumnSpan(this.cargo, 3);
			// 
			// devolucionLabel
			// 
			this.devolucionLabel.AutoSize = true;
			this.devolucionLabel.Text = "Devolución";
			this.devolucionLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.devolucionLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.devolucionLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.devolucionLabel.TabIndex = 0;
			this.devolucionLabel.Name = "devolucionLabel";
			// 
			// devolucion
			// 
			this.devolucion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.devolucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.devolucion.FormattingEnabled = true;
			this.devolucion.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.devolucion.DisplayMember = "Id";
			this.devolucion.TabIndex = 1;
			this.devolucion.Name = "devolucion";
			this.devolucion.SelectedIndexChanged += new System.EventHandler(this.DevolucionCambio);
			this.devolucion.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.FormatearDevolucion);
			// 
			// equipoLabel
			// 
			this.equipoLabel.AutoSize = true;
			this.equipoLabel.Text = "Equipo afectado del remito";
			this.equipoLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.equipoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.equipoLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.equipoLabel.TabIndex = 2;
			this.equipoLabel.Name = "equipoLabel";
			// 
			// equipo
			// 
			this.equipo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.equipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.equipo.FormattingEnabled = true;
			this.equipo.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.equipo.DisplayMember = "CodigoInventario";
			this.equipo.TabIndex = 3;
			this.equipo.Name = "equipo";
			this.equipo.SelectedIndexChanged += new System.EventHandler(this.CargoCambio);
			this.equipo.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.FormatearEquipo);
			// 
			// tipoLabel
			// 
			this.tipoLabel.AutoSize = true;
			this.tipoLabel.Text = "Tipo de incidencia";
			this.tipoLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.tipoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.tipoLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.tipoLabel.TabIndex = 4;
			this.tipoLabel.Name = "tipoLabel";
			// 
			// tipo
			// 
			this.tipo.Items.AddRange(new object[] {
				"Atraso",
	"Faltante",
	"DañoReparable",
	"DañoTotal"});
			this.tipo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tipo.FormattingEnabled = true;
			this.tipo.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.tipo.TabIndex = 5;
			this.tipo.Name = "tipo";
			this.tipo.SelectedIndexChanged += new System.EventHandler(this.CargoCambio);
			this.tipo.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.FormatearTipo);
			// 
			// descripcionLabel
			// 
			this.descripcionLabel.AutoSize = true;
			this.descripcionLabel.Text = "Descripción del hallazgo";
			this.descripcionLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.descripcionLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.descripcionLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.descripcionLabel.TabIndex = 6;
			this.descripcionLabel.Name = "descripcionLabel";
			// 
			// descripcion
			// 
			this.descripcion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.descripcion.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.descripcion.Multiline = true;
			this.descripcion.MaxLength = 500;
			this.descripcion.MinimumSize = new System.Drawing.Size(0, 56);
			this.descripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.descripcion.TabIndex = 7;
			this.descripcion.Name = "descripcion";
			// 
			// hallazgoAcciones
			// 
			this.hallazgoAcciones.AutoSize = true;
			this.hallazgoAcciones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.hallazgoAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
			this.hallazgoAcciones.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.hallazgoAcciones.TabIndex = 8;
			this.hallazgoAcciones.Name = "hallazgoAcciones";
			this.hallazgoAcciones.Controls.Add(this.cargoBoton);
			this.hallazgoAcciones.Controls.Add(this.incidenciaBoton);
			// 
			// cargoBoton
			// 
			this.cargoBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cargoBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cargoBoton.Size = new System.Drawing.Size(170, 38);
			this.cargoBoton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.cargoBoton.Text = "Calcular cargo";
			this.cargoBoton.UseVisualStyleBackColor = false;
			this.cargoBoton.BackColor = System.Drawing.Color.White;
			this.cargoBoton.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.cargoBoton.FlatAppearance.BorderSize = 1;
			this.cargoBoton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
			this.cargoBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.cargoBoton.TabIndex = 0;
			this.cargoBoton.Name = "cargoBoton";
			this.cargoBoton.Click += new System.EventHandler(this.CargoClick);
			// 
			// incidenciaBoton
			// 
			this.incidenciaBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.incidenciaBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.incidenciaBoton.Size = new System.Drawing.Size(190, 38);
			this.incidenciaBoton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.incidenciaBoton.Text = "Registrar incidencia";
			this.incidenciaBoton.UseVisualStyleBackColor = false;
			this.incidenciaBoton.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
			this.incidenciaBoton.ForeColor = System.Drawing.Color.White;
			this.incidenciaBoton.FlatAppearance.BorderSize = 0;
			this.incidenciaBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(29, 78, 216);
			this.incidenciaBoton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.incidenciaBoton.TabIndex = 1;
			this.incidenciaBoton.Name = "incidenciaBoton";
			this.incidenciaBoton.Click += new System.EventHandler(this.IncidenciaClick);
			// 
			// cargo
			// 
			this.cargo.Text = "Elegí unidad y tipo para calcular el cargo.";
			this.cargo.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.cargo.AutoSize = false;
			this.cargo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cargo.Size = new System.Drawing.Size(0, 48);
			this.cargo.TabIndex = 9;
			this.cargo.Name = "cargo";
			// 
			// incidencias
			// 
			this.incidencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
				this.incidenciasIdColumna,
	this.incidenciasEquipoIdColumna,
	this.incidenciasTipoColumna,
	this.incidenciasDescripcionColumna,
	this.incidenciasCargoBaseColumna,
	this.incidenciasDescuentoColumna,
	this.incidenciasCargoColumna,
	this.incidenciasEstadoColumna});
			this.incidencias.AllowUserToAddRows = false;
			this.incidencias.AllowUserToDeleteRows = false;
			this.incidencias.AllowUserToResizeRows = false;
			this.incidencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.incidencias.BackgroundColor = System.Drawing.Color.White;
			this.incidencias.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.incidencias.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.incidencias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.incidencias.ColumnHeadersHeight = 38;
			this.incidencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.incidencias.Dock = System.Windows.Forms.DockStyle.Fill;
			this.incidencias.EnableHeadersVisualStyles = false;
			this.incidencias.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
			this.incidencias.MultiSelect = false;
			this.incidencias.ReadOnly = true;
			this.incidencias.RowHeadersVisible = false;
			this.incidencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.incidencias.RowTemplate.Height = 34;
			this.incidencias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.incidencias.DefaultCellStyle = dataGridViewCellStyle2;
			this.incidencias.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.incidencias.AutoGenerateColumns = false;
			this.incidencias.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
			this.incidencias.TabIndex = 1;
			this.incidencias.Name = "incidencias";
			this.incidencias.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.FormatearUnidad);
			// 
			// incidenciasIdColumna
			// 
			this.incidenciasIdColumna.HeaderText = "N°";
			this.incidenciasIdColumna.MinimumWidth = 40;
			this.incidenciasIdColumna.Name = "incidenciasIdColumna";
			this.incidenciasIdColumna.ReadOnly = true;
			this.incidenciasIdColumna.DataPropertyName = "Id";
			// 
			// incidenciasEquipoIdColumna
			// 
			this.incidenciasEquipoIdColumna.HeaderText = "Equipo";
			this.incidenciasEquipoIdColumna.MinimumWidth = 90;
			this.incidenciasEquipoIdColumna.Name = "incidenciasEquipoIdColumna";
			this.incidenciasEquipoIdColumna.ReadOnly = true;
			this.incidenciasEquipoIdColumna.DataPropertyName = "EquipoId";
			// 
			// incidenciasTipoColumna
			// 
			this.incidenciasTipoColumna.HeaderText = "Tipo";
			this.incidenciasTipoColumna.MinimumWidth = 115;
			this.incidenciasTipoColumna.Name = "incidenciasTipoColumna";
			this.incidenciasTipoColumna.ReadOnly = true;
			this.incidenciasTipoColumna.DataPropertyName = "Tipo";
			// 
			// incidenciasDescripcionColumna
			// 
			this.incidenciasDescripcionColumna.HeaderText = "Descripción";
			this.incidenciasDescripcionColumna.MinimumWidth = 140;
			this.incidenciasDescripcionColumna.Name = "incidenciasDescripcionColumna";
			this.incidenciasDescripcionColumna.ReadOnly = true;
			this.incidenciasDescripcionColumna.DataPropertyName = "Descripcion";
			// 
			// incidenciasCargoBaseColumna
			// 
			this.incidenciasCargoBaseColumna.HeaderText = "Cargo base";
			this.incidenciasCargoBaseColumna.MinimumWidth = 90;
			this.incidenciasCargoBaseColumna.Name = "incidenciasCargoBaseColumna";
			this.incidenciasCargoBaseColumna.ReadOnly = true;
			this.incidenciasCargoBaseColumna.DataPropertyName = "CargoBase";
			this.incidenciasCargoBaseColumna.DefaultCellStyle.Format = "N2";
			// 
			// incidenciasDescuentoColumna
			// 
			this.incidenciasDescuentoColumna.HeaderText = "Desc. seguro";
			this.incidenciasDescuentoColumna.MinimumWidth = 90;
			this.incidenciasDescuentoColumna.Name = "incidenciasDescuentoColumna";
			this.incidenciasDescuentoColumna.ReadOnly = true;
			this.incidenciasDescuentoColumna.DataPropertyName = "DescuentoSeguro";
			this.incidenciasDescuentoColumna.DefaultCellStyle.Format = "N2";
			// 
			// incidenciasCargoColumna
			// 
			this.incidenciasCargoColumna.HeaderText = "A pagar";
			this.incidenciasCargoColumna.MinimumWidth = 90;
			this.incidenciasCargoColumna.Name = "incidenciasCargoColumna";
			this.incidenciasCargoColumna.ReadOnly = true;
			this.incidenciasCargoColumna.DataPropertyName = "Cargo";
			this.incidenciasCargoColumna.DefaultCellStyle.Format = "N2";
			// 
			// incidenciasEstadoColumna
			// 
			this.incidenciasEstadoColumna.HeaderText = "Estado";
			this.incidenciasEstadoColumna.MinimumWidth = 80;
			this.incidenciasEstadoColumna.Name = "incidenciasEstadoColumna";
			this.incidenciasEstadoColumna.ReadOnly = true;
			this.incidenciasEstadoColumna.DataPropertyName = "Estado";
			// 
			// cierreInspeccion
			// 
			this.cierreInspeccion.ColumnCount = 1;
			this.cierreInspeccion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.cierreInspeccion.RowCount = 2;
			this.cierreInspeccion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.cierreInspeccion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.cierreInspeccion.AutoSize = true;
			this.cierreInspeccion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cierreInspeccion.BackColor = System.Drawing.Color.White;
			this.cierreInspeccion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cierreInspeccion.Padding = new System.Windows.Forms.Padding(18, 18, 18, 8);
			this.cierreInspeccion.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
			this.cierreInspeccion.TabIndex = 2;
			this.cierreInspeccion.Name = "cierreInspeccion";
			this.cierreInspeccion.Controls.Add(this.liquidacion, 0, 0);
			this.cierreInspeccion.Controls.Add(this.inspeccionAcciones, 0, 1);
			// 
			// liquidacion
			// 
			this.liquidacion.Text = "Los cargos se fijan al finalizar la inspección.";
			this.liquidacion.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.liquidacion.AutoSize = false;
			this.liquidacion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.liquidacion.Size = new System.Drawing.Size(0, 44);
			this.liquidacion.TabIndex = 0;
			this.liquidacion.Name = "liquidacion";
			// 
			// inspeccionAcciones
			// 
			this.inspeccionAcciones.AutoSize = true;
			this.inspeccionAcciones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.inspeccionAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
			this.inspeccionAcciones.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.inspeccionAcciones.TabIndex = 1;
			this.inspeccionAcciones.Name = "inspeccionAcciones";
			this.inspeccionAcciones.Controls.Add(this.finalizarBoton);
			this.inspeccionAcciones.Controls.Add(this.actualizarInspeccionBoton);
			// 
			// finalizarBoton
			// 
			this.finalizarBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.finalizarBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.finalizarBoton.Size = new System.Drawing.Size(190, 38);
			this.finalizarBoton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.finalizarBoton.Text = "Finalizar inspección";
			this.finalizarBoton.UseVisualStyleBackColor = false;
			this.finalizarBoton.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
			this.finalizarBoton.ForeColor = System.Drawing.Color.White;
			this.finalizarBoton.FlatAppearance.BorderSize = 0;
			this.finalizarBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(29, 78, 216);
			this.finalizarBoton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.finalizarBoton.TabIndex = 0;
			this.finalizarBoton.Name = "finalizarBoton";
			this.finalizarBoton.Click += new System.EventHandler(this.FinalizarClick);
			// 
			// actualizarInspeccionBoton
			// 
			this.actualizarInspeccionBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.actualizarInspeccionBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.actualizarInspeccionBoton.Size = new System.Drawing.Size(170, 38);
			this.actualizarInspeccionBoton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.actualizarInspeccionBoton.Text = "Actualizar";
			this.actualizarInspeccionBoton.UseVisualStyleBackColor = false;
			this.actualizarInspeccionBoton.BackColor = System.Drawing.Color.White;
			this.actualizarInspeccionBoton.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.actualizarInspeccionBoton.FlatAppearance.BorderSize = 1;
			this.actualizarInspeccionBoton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
			this.actualizarInspeccionBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.actualizarInspeccionBoton.TabIndex = 1;
			this.actualizarInspeccionBoton.Name = "actualizarInspeccionBoton";
			this.actualizarInspeccionBoton.Click += new System.EventHandler(this.CargarClick);
			// 
			// tecnicaTab
			// 
			this.tecnicaTab.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.tecnicaTab.Padding = new System.Windows.Forms.Padding(16, 16, 16, 16);
			this.tecnicaTab.Text = "Alta técnica";
			this.tecnicaTab.UseVisualStyleBackColor = false;
			this.tecnicaTab.TabIndex = 2;
			this.tecnicaTab.Name = "tecnicaTab";
			this.tecnicaTab.Controls.Add(this.tecnicaTabLayout);
			// 
			// tecnicaTabLayout
			// 
			this.tecnicaTabLayout.ColumnCount = 1;
			this.tecnicaTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tecnicaTabLayout.RowCount = 2;
			this.tecnicaTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tecnicaTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.tecnicaTabLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tecnicaTabLayout.BackColor = System.Drawing.Color.Transparent;
			this.tecnicaTabLayout.TabIndex = 0;
			this.tecnicaTabLayout.Name = "tecnicaTabLayout";
			this.tecnicaTabLayout.Controls.Add(this.tecnicas, 0, 0);
			this.tecnicaTabLayout.Controls.Add(this.altaTecnica, 0, 1);
			// 
			// tecnicas
			// 
			this.tecnicas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
				this.tecnicasIdColumna,
	this.tecnicasEquipoIdColumna,
	this.tecnicasTipoColumna,
	this.tecnicasDescripcionColumna,
	this.tecnicasEstadoColumna,
	this.tecnicasFechaColumna});
			this.tecnicas.AllowUserToAddRows = false;
			this.tecnicas.AllowUserToDeleteRows = false;
			this.tecnicas.AllowUserToResizeRows = false;
			this.tecnicas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.tecnicas.BackgroundColor = System.Drawing.Color.White;
			this.tecnicas.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tecnicas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.tecnicas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.tecnicas.ColumnHeadersHeight = 38;
			this.tecnicas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.tecnicas.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tecnicas.EnableHeadersVisualStyles = false;
			this.tecnicas.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
			this.tecnicas.MultiSelect = false;
			this.tecnicas.ReadOnly = true;
			this.tecnicas.RowHeadersVisible = false;
			this.tecnicas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.tecnicas.RowTemplate.Height = 34;
			this.tecnicas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.tecnicas.DefaultCellStyle = dataGridViewCellStyle5;
			this.tecnicas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
			this.tecnicas.AutoGenerateColumns = false;
			this.tecnicas.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
			this.tecnicas.TabIndex = 0;
			this.tecnicas.Name = "tecnicas";
			this.tecnicas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.FormatearUnidad);
			this.tecnicas.SelectionChanged += new System.EventHandler(this.TecnicaCambio);
			// 
			// tecnicasIdColumna
			// 
			this.tecnicasIdColumna.HeaderText = "N°";
			this.tecnicasIdColumna.MinimumWidth = 40;
			this.tecnicasIdColumna.Name = "tecnicasIdColumna";
			this.tecnicasIdColumna.ReadOnly = true;
			this.tecnicasIdColumna.DataPropertyName = "Id";
			// 
			// tecnicasEquipoIdColumna
			// 
			this.tecnicasEquipoIdColumna.HeaderText = "Equipo";
			this.tecnicasEquipoIdColumna.MinimumWidth = 90;
			this.tecnicasEquipoIdColumna.Name = "tecnicasEquipoIdColumna";
			this.tecnicasEquipoIdColumna.ReadOnly = true;
			this.tecnicasEquipoIdColumna.DataPropertyName = "EquipoId";
			// 
			// tecnicasTipoColumna
			// 
			this.tecnicasTipoColumna.HeaderText = "Tipo";
			this.tecnicasTipoColumna.MinimumWidth = 115;
			this.tecnicasTipoColumna.Name = "tecnicasTipoColumna";
			this.tecnicasTipoColumna.ReadOnly = true;
			this.tecnicasTipoColumna.DataPropertyName = "Tipo";
			// 
			// tecnicasDescripcionColumna
			// 
			this.tecnicasDescripcionColumna.HeaderText = "Descripción";
			this.tecnicasDescripcionColumna.MinimumWidth = 180;
			this.tecnicasDescripcionColumna.Name = "tecnicasDescripcionColumna";
			this.tecnicasDescripcionColumna.ReadOnly = true;
			this.tecnicasDescripcionColumna.DataPropertyName = "Descripcion";
			// 
			// tecnicasEstadoColumna
			// 
			this.tecnicasEstadoColumna.HeaderText = "Estado";
			this.tecnicasEstadoColumna.MinimumWidth = 80;
			this.tecnicasEstadoColumna.Name = "tecnicasEstadoColumna";
			this.tecnicasEstadoColumna.ReadOnly = true;
			this.tecnicasEstadoColumna.DataPropertyName = "Estado";
			// 
			// tecnicasFechaColumna
			// 
			this.tecnicasFechaColumna.HeaderText = "Alta técnica";
			this.tecnicasFechaColumna.MinimumWidth = 110;
			this.tecnicasFechaColumna.Name = "tecnicasFechaColumna";
			this.tecnicasFechaColumna.ReadOnly = true;
			this.tecnicasFechaColumna.DataPropertyName = "FechaAltaTecnica";
			this.tecnicasFechaColumna.DefaultCellStyle.Format = "dd/MM/yy HH:mm";
			// 
			// altaTecnica
			// 
			this.altaTecnica.ColumnCount = 1;
			this.altaTecnica.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.altaTecnica.RowCount = 3;
			this.altaTecnica.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.altaTecnica.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.altaTecnica.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.altaTecnica.AutoSize = true;
			this.altaTecnica.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.altaTecnica.BackColor = System.Drawing.Color.White;
			this.altaTecnica.Dock = System.Windows.Forms.DockStyle.Fill;
			this.altaTecnica.Padding = new System.Windows.Forms.Padding(18, 18, 18, 8);
			this.altaTecnica.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
			this.altaTecnica.TabIndex = 1;
			this.altaTecnica.Name = "altaTecnica";
			this.altaTecnica.Controls.Add(this.detalleTecnico, 0, 0);
			this.altaTecnica.Controls.Add(this.apta, 0, 1);
			this.altaTecnica.Controls.Add(this.tecnicaAcciones, 0, 2);
			// 
			// detalleTecnico
			// 
			this.detalleTecnico.BackColor = System.Drawing.Color.White;
			this.detalleTecnico.Dock = System.Windows.Forms.DockStyle.Fill;
			this.detalleTecnico.Multiline = true;
			this.detalleTecnico.ReadOnly = true;
			this.detalleTecnico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.detalleTecnico.MinimumSize = new System.Drawing.Size(0, 100);
			this.detalleTecnico.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
			this.detalleTecnico.TabIndex = 0;
			this.detalleTecnico.Name = "detalleTecnico";
			// 
			// apta
			// 
			this.apta.AutoSize = true;
			this.apta.Text = "Unidad recuperada o reparada, revisada y apta para volver al stock";
			this.apta.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.apta.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
			this.apta.UseVisualStyleBackColor = true;
			this.apta.TabIndex = 1;
			this.apta.Name = "apta";
			// 
			// tecnicaAcciones
			// 
			this.tecnicaAcciones.AutoSize = true;
			this.tecnicaAcciones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tecnicaAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tecnicaAcciones.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.tecnicaAcciones.TabIndex = 2;
			this.tecnicaAcciones.Name = "tecnicaAcciones";
			this.tecnicaAcciones.Controls.Add(this.altaBoton);
			this.tecnicaAcciones.Controls.Add(this.actualizarTecnicaBoton);
			// 
			// altaBoton
			// 
			this.altaBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.altaBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.altaBoton.Size = new System.Drawing.Size(190, 38);
			this.altaBoton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.altaBoton.Text = "Dar alta técnica";
			this.altaBoton.UseVisualStyleBackColor = false;
			this.altaBoton.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
			this.altaBoton.ForeColor = System.Drawing.Color.White;
			this.altaBoton.FlatAppearance.BorderSize = 0;
			this.altaBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(29, 78, 216);
			this.altaBoton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.altaBoton.TabIndex = 0;
			this.altaBoton.Name = "altaBoton";
			this.altaBoton.Click += new System.EventHandler(this.AltaClick);
			// 
			// actualizarTecnicaBoton
			// 
			this.actualizarTecnicaBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.actualizarTecnicaBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.actualizarTecnicaBoton.Size = new System.Drawing.Size(170, 38);
			this.actualizarTecnicaBoton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.actualizarTecnicaBoton.Text = "Actualizar";
			this.actualizarTecnicaBoton.UseVisualStyleBackColor = false;
			this.actualizarTecnicaBoton.BackColor = System.Drawing.Color.White;
			this.actualizarTecnicaBoton.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.actualizarTecnicaBoton.FlatAppearance.BorderSize = 1;
			this.actualizarTecnicaBoton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
			this.actualizarTecnicaBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.actualizarTecnicaBoton.TabIndex = 1;
			this.actualizarTecnicaBoton.Name = "actualizarTecnicaBoton";
			this.actualizarTecnicaBoton.Click += new System.EventHandler(this.CargarClick);
			this.tecnicaAcciones.ResumeLayout(false);
			this.tecnicaAcciones.PerformLayout();
			this.altaTecnica.ResumeLayout(false);
			this.altaTecnica.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tecnicas)).EndInit();
			this.tecnicaTabLayout.ResumeLayout(false);
			this.tecnicaTabLayout.PerformLayout();
			this.tecnicaTab.ResumeLayout(false);
			this.tecnicaTab.PerformLayout();
			this.inspeccionAcciones.ResumeLayout(false);
			this.inspeccionAcciones.PerformLayout();
			this.cierreInspeccion.ResumeLayout(false);
			this.cierreInspeccion.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.incidencias)).EndInit();
			this.hallazgoAcciones.ResumeLayout(false);
			this.hallazgoAcciones.PerformLayout();
			this.hallazgos.ResumeLayout(false);
			this.hallazgos.PerformLayout();
			this.inspeccionTabLayout.ResumeLayout(false);
			this.inspeccionTabLayout.PerformLayout();
			this.inspeccionTab.ResumeLayout(false);
			this.inspeccionTab.PerformLayout();
			this.devolucionAcciones.ResumeLayout(false);
			this.devolucionAcciones.PerformLayout();
			this.cierreDevolucion.ResumeLayout(false);
			this.cierreDevolucion.PerformLayout();
			this.controles.ResumeLayout(false);
			this.controles.PerformLayout();
			this.cabecera.ResumeLayout(false);
			this.cabecera.PerformLayout();
			this.devolucionTabLayout.ResumeLayout(false);
			this.devolucionTabLayout.PerformLayout();
			this.devolucionTab.ResumeLayout(false);
			this.devolucionTab.PerformLayout();
			this.tabs.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
#endregion

		private System.Windows.Forms.TabControl tabs;
		private System.Windows.Forms.TabPage devolucionTab;
		private System.Windows.Forms.TableLayoutPanel devolucionTabLayout;
		private System.Windows.Forms.TableLayoutPanel cabecera;
		private System.Windows.Forms.Label reservaLabel;
		private System.Windows.Forms.ComboBox reserva;
		private System.Windows.Forms.Label fechaLabel;
		private System.Windows.Forms.DateTimePicker fecha;
		private System.Windows.Forms.Label fechaAyuda;
		private System.Windows.Forms.FlowLayoutPanel controles;
		private System.Windows.Forms.CheckBox presente;
		private System.Windows.Forms.CheckBox conforme;
		private System.Windows.Forms.CheckBox cotejo;
		private System.Windows.Forms.TextBox remito;
		private System.Windows.Forms.TableLayoutPanel cierreDevolucion;
		private System.Windows.Forms.Label observacionesLabel;
		private System.Windows.Forms.TextBox observaciones;
		private System.Windows.Forms.FlowLayoutPanel devolucionAcciones;
		private System.Windows.Forms.Button registrarBoton;
		private System.Windows.Forms.Button actualizarDevolucionBoton;
		private System.Windows.Forms.TabPage inspeccionTab;
		private System.Windows.Forms.TableLayoutPanel inspeccionTabLayout;
		private System.Windows.Forms.TableLayoutPanel hallazgos;
		private System.Windows.Forms.Label devolucionLabel;
		private System.Windows.Forms.ComboBox devolucion;
		private System.Windows.Forms.Label equipoLabel;
		private System.Windows.Forms.ComboBox equipo;
		private System.Windows.Forms.Label tipoLabel;
		private System.Windows.Forms.ComboBox tipo;
		private System.Windows.Forms.Label descripcionLabel;
		private System.Windows.Forms.TextBox descripcion;
		private System.Windows.Forms.FlowLayoutPanel hallazgoAcciones;
		private System.Windows.Forms.Button cargoBoton;
		private System.Windows.Forms.Button incidenciaBoton;
		private System.Windows.Forms.Label cargo;
		private System.Windows.Forms.DataGridView incidencias;
		private System.Windows.Forms.DataGridViewTextBoxColumn incidenciasIdColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn incidenciasEquipoIdColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn incidenciasTipoColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn incidenciasDescripcionColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn incidenciasCargoBaseColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn incidenciasDescuentoColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn incidenciasCargoColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn incidenciasEstadoColumna;
		private System.Windows.Forms.TableLayoutPanel cierreInspeccion;
		private System.Windows.Forms.Label liquidacion;
		private System.Windows.Forms.FlowLayoutPanel inspeccionAcciones;
		private System.Windows.Forms.Button finalizarBoton;
		private System.Windows.Forms.Button actualizarInspeccionBoton;
		private System.Windows.Forms.TabPage tecnicaTab;
		private System.Windows.Forms.TableLayoutPanel tecnicaTabLayout;
		private System.Windows.Forms.DataGridView tecnicas;
		private System.Windows.Forms.DataGridViewTextBoxColumn tecnicasIdColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn tecnicasEquipoIdColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn tecnicasTipoColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn tecnicasDescripcionColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn tecnicasEstadoColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn tecnicasFechaColumna;
		private System.Windows.Forms.TableLayoutPanel altaTecnica;
		private System.Windows.Forms.TextBox detalleTecnico;
		private System.Windows.Forms.CheckBox apta;
		private System.Windows.Forms.FlowLayoutPanel tecnicaAcciones;
		private System.Windows.Forms.Button altaBoton;
		private System.Windows.Forms.Button actualizarTecnicaBoton;
	}
}
