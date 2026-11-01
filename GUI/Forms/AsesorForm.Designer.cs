namespace GUI
{
	partial class AsesorForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			this.desplazable = new System.Windows.Forms.Panel();
			this.asesorLayout = new System.Windows.Forms.TableLayoutPanel();
			this.brief = new System.Windows.Forms.TableLayoutPanel();
			this.tipoPiezaLabel = new System.Windows.Forms.Label();
			this.tipoPieza = new System.Windows.Forms.ComboBox();
			this.presupuestoLabel = new System.Windows.Forms.Label();
			this.presupuesto = new System.Windows.Forms.NumericUpDown();
			this.horasLabel = new System.Windows.Forms.Label();
			this.horas = new System.Windows.Forms.NumericUpDown();
			this.desdeAsesorLabel = new System.Windows.Forms.Label();
			this.desdeAsesor = new System.Windows.Forms.DateTimePicker();
			this.hastaAsesorLabel = new System.Windows.Forms.Label();
			this.hastaAsesor = new System.Windows.Forms.DateTimePicker();
			this.personasLabel = new System.Windows.Forms.Label();
			this.personas = new System.Windows.Forms.NumericUpDown();
			this.camarasLabel = new System.Windows.Forms.Label();
			this.camaras = new System.Windows.Forms.NumericUpDown();
			this.locacionLabel = new System.Windows.Forms.Label();
			this.locacion = new System.Windows.Forms.ComboBox();
			this.luzLabel = new System.Windows.Forms.Label();
			this.luz = new System.Windows.Forms.ComboBox();
			this.movimiento = new System.Windows.Forms.CheckBox();
			this.sonido = new System.Windows.Forms.CheckBox();
			this.monitoreo = new System.Windows.Forms.CheckBox();
			this.cine = new System.Windows.Forms.CheckBox();
			this.resumenCard = new System.Windows.Forms.TableLayoutPanel();
			this.resumen = new System.Windows.Forms.Label();
			this.tabs = new System.Windows.Forms.TabControl();
			this.recomendadaTab = new System.Windows.Forms.TabPage();
			this.recomendadaTabLayout = new System.Windows.Forms.TableLayoutPanel();
			this.propuestaRec = new System.Windows.Forms.DataGridView();
			this.propuestaRecRolColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.propuestaRecDetalleColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.propuestaRecGamaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.propuestaRecSubtotalColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.propuestaRecAportaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.propuestaRecResignaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.notasRec = new System.Windows.Forms.Label();
			this.economicaTab = new System.Windows.Forms.TabPage();
			this.economicaTabLayout = new System.Windows.Forms.TableLayoutPanel();
			this.propuestaEco = new System.Windows.Forms.DataGridView();
			this.propuestaEcoRolColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.propuestaEcoDetalleColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.propuestaEcoGamaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.propuestaEcoSubtotalColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.propuestaEcoAportaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.propuestaEcoResignaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.notasEco = new System.Windows.Forms.Label();
			this.complementosTab = new System.Windows.Forms.TabPage();
			this.complementosTabLayout = new System.Windows.Forms.TableLayoutPanel();
			this.complementos = new System.Windows.Forms.DataGridView();
			this.complementosRolColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.complementosDetalleColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.complementosGamaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.complementosSubtotalColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.complementosAportaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.complementosResignaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.complementosNota = new System.Windows.Forms.Label();
			this.lecturaTab = new System.Windows.Forms.TabPage();
			this.lectura = new System.Windows.Forms.TextBox();
			this.guardadasTab = new System.Windows.Forms.TabPage();
			this.guardadasTabLayout = new System.Windows.Forms.TableLayoutPanel();
			this.guardadas = new System.Windows.Forms.DataGridView();
			this.guardadasNombreColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.guardadasCreadaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.guardadasResumenColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.guardadasVarianteColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.guardadasTotalColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.guardadasAcciones = new System.Windows.Forms.FlowLayoutPanel();
			this.abrirGuardadaBoton = new System.Windows.Forms.Button();
			this.eliminarGuardadaBoton = new System.Windows.Forms.Button();
			this.guardadasNota = new System.Windows.Forms.Label();
			this.asesorAcciones = new System.Windows.Forms.FlowLayoutPanel();
			this.usarBoton = new System.Windows.Forms.Button();
			this.imprimirBoton = new System.Windows.Forms.Button();
			this.actualizarAsesorBoton = new System.Windows.Forms.Button();
			this.guardarComoLabel = new System.Windows.Forms.Label();
			this.nombrePropuesta = new System.Windows.Forms.TextBox();
			this.guardarPropuestaBoton = new System.Windows.Forms.Button();
			this.usarNota = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.desplazable.SuspendLayout();
			this.asesorLayout.SuspendLayout();
			this.brief.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.presupuesto)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.horas)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.personas)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.camaras)).BeginInit();
			this.resumenCard.SuspendLayout();
			this.tabs.SuspendLayout();
			this.recomendadaTab.SuspendLayout();
			this.recomendadaTabLayout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.propuestaRec)).BeginInit();
			this.economicaTab.SuspendLayout();
			this.economicaTabLayout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.propuestaEco)).BeginInit();
			this.complementosTab.SuspendLayout();
			this.complementosTabLayout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.complementos)).BeginInit();
			this.lecturaTab.SuspendLayout();
			this.guardadasTab.SuspendLayout();
			this.guardadasTabLayout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.guardadas)).BeginInit();
			this.guardadasAcciones.SuspendLayout();
			this.asesorAcciones.SuspendLayout();
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(15, 23, 42);
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
			dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(6, 5, 4, 5);
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
			dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(6, 5, 4, 5);
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254);
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
			dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
			dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(15, 23, 42);
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
			dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(6, 5, 4, 5);
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254);
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
			dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
			dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
			dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(15, 23, 42);
			dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
			dataGridViewCellStyle11.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
			dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254);
			dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
			// 
			// AsesorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.ClientSize = new System.Drawing.Size(870, 640);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Controls.Add(this.desplazable);
			this.Load += new System.EventHandler(this.AsesorForm_Load);
			// 
			// desplazable
			// 
			this.desplazable.AutoScroll = true;
			this.desplazable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.desplazable.TabIndex = 0;
			this.desplazable.Name = "desplazable";
			this.desplazable.Controls.Add(this.asesorLayout);
			// 
			// asesorLayout
			// 
			this.asesorLayout.ColumnCount = 1;
			this.asesorLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.asesorLayout.RowCount = 4;
			this.asesorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.asesorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.asesorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.asesorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.asesorLayout.Dock = System.Windows.Forms.DockStyle.Top;
			this.asesorLayout.AutoSize = true;
			this.asesorLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.asesorLayout.BackColor = System.Drawing.Color.Transparent;
			this.asesorLayout.TabIndex = 0;
			this.asesorLayout.Name = "asesorLayout";
			this.asesorLayout.Controls.Add(this.brief, 0, 0);
			this.asesorLayout.Controls.Add(this.resumenCard, 0, 1);
			this.asesorLayout.Controls.Add(this.tabs, 0, 2);
			this.asesorLayout.Controls.Add(this.asesorAcciones, 0, 3);
			// 
			// brief
			// 
			this.brief.ColumnCount = 4;
			this.brief.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
			this.brief.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
			this.brief.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
			this.brief.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
			this.brief.RowCount = 7;
			this.brief.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.brief.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.brief.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.brief.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.brief.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.brief.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.brief.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.brief.AutoSize = true;
			this.brief.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.brief.BackColor = System.Drawing.Color.White;
			this.brief.Dock = System.Windows.Forms.DockStyle.Fill;
			this.brief.Padding = new System.Windows.Forms.Padding(18, 14, 18, 2);
			this.brief.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
			this.brief.TabIndex = 0;
			this.brief.Name = "brief";
			this.brief.Controls.Add(this.tipoPiezaLabel, 0, 0);
			this.brief.SetColumnSpan(this.tipoPiezaLabel, 2);
			this.brief.Controls.Add(this.tipoPieza, 0, 1);
			this.brief.SetColumnSpan(this.tipoPieza, 2);
			this.brief.Controls.Add(this.presupuestoLabel, 2, 0);
			this.brief.Controls.Add(this.presupuesto, 2, 1);
			this.brief.Controls.Add(this.horasLabel, 3, 0);
			this.brief.Controls.Add(this.horas, 3, 1);
			this.brief.Controls.Add(this.desdeAsesorLabel, 0, 2);
			this.brief.Controls.Add(this.desdeAsesor, 0, 3);
			this.brief.Controls.Add(this.hastaAsesorLabel, 1, 2);
			this.brief.Controls.Add(this.hastaAsesor, 1, 3);
			this.brief.Controls.Add(this.personasLabel, 2, 2);
			this.brief.Controls.Add(this.personas, 2, 3);
			this.brief.Controls.Add(this.camarasLabel, 3, 2);
			this.brief.Controls.Add(this.camaras, 3, 3);
			this.brief.Controls.Add(this.locacionLabel, 0, 4);
			this.brief.Controls.Add(this.locacion, 0, 5);
			this.brief.Controls.Add(this.luzLabel, 1, 4);
			this.brief.Controls.Add(this.luz, 1, 5);
			this.brief.Controls.Add(this.movimiento, 2, 5);
			this.brief.Controls.Add(this.sonido, 3, 5);
			this.brief.Controls.Add(this.monitoreo, 2, 6);
			this.brief.Controls.Add(this.cine, 3, 6);
			// 
			// tipoPiezaLabel
			// 
			this.tipoPiezaLabel.AutoSize = true;
			this.tipoPiezaLabel.Text = "Tipo de producción";
			this.tipoPiezaLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.tipoPiezaLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.tipoPiezaLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.tipoPiezaLabel.TabIndex = 0;
			this.tipoPiezaLabel.Name = "tipoPiezaLabel";
			// 
			// tipoPieza
			// 
			this.tipoPieza.Items.AddRange(new object[] {
				"Entrevista / documental",
	"Publicidad / spot",
	"Videoclip",
	"Ficción / cortometraje",
	"Evento / social",
	"Streaming / podcast"});
			this.tipoPieza.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tipoPieza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tipoPieza.FormattingEnabled = true;
			this.tipoPieza.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.tipoPieza.TabIndex = 1;
			this.tipoPieza.Name = "tipoPieza";
			this.tipoPieza.SelectedIndexChanged += new System.EventHandler(this.BriefCambio);
			// 
			// presupuestoLabel
			// 
			this.presupuestoLabel.AutoSize = true;
			this.presupuestoLabel.Text = "Presupuesto ARS (total)";
			this.presupuestoLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.presupuestoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.presupuestoLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.presupuestoLabel.TabIndex = 2;
			this.presupuestoLabel.Name = "presupuestoLabel";
			// 
			// presupuesto
			// 
			this.presupuesto.Dock = System.Windows.Forms.DockStyle.Fill;
			this.presupuesto.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.presupuesto.DecimalPlaces = 0;
			this.presupuesto.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			this.presupuesto.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
			this.presupuesto.Value = new decimal(new int[] { 300000, 0, 0, 0 });
			this.presupuesto.ThousandsSeparator = true;
			this.presupuesto.TabIndex = 3;
			this.presupuesto.Name = "presupuesto";
			this.presupuesto.ValueChanged += new System.EventHandler(this.BriefCambio);
			// 
			// horasLabel
			// 
			this.horasLabel.AutoSize = true;
			this.horasLabel.Text = "Horas de jornada";
			this.horasLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.horasLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.horasLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.horasLabel.TabIndex = 4;
			this.horasLabel.Name = "horasLabel";
			// 
			// horas
			// 
			this.horas.Dock = System.Windows.Forms.DockStyle.Fill;
			this.horas.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.horas.DecimalPlaces = 0;
			this.horas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			this.horas.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
			this.horas.Value = new decimal(new int[] { 8, 0, 0, 0 });
			this.horas.ThousandsSeparator = true;
			this.horas.TabIndex = 5;
			this.horas.Name = "horas";
			this.horas.ValueChanged += new System.EventHandler(this.BriefCambio);
			// 
			// desdeAsesorLabel
			// 
			this.desdeAsesorLabel.AutoSize = true;
			this.desdeAsesorLabel.Text = "Desde";
			this.desdeAsesorLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.desdeAsesorLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.desdeAsesorLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.desdeAsesorLabel.TabIndex = 6;
			this.desdeAsesorLabel.Name = "desdeAsesorLabel";
			// 
			// desdeAsesor
			// 
			this.desdeAsesor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.desdeAsesor.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.desdeAsesor.CustomFormat = "dd/MM/yyyy HH:mm";
			this.desdeAsesor.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.desdeAsesor.TabIndex = 7;
			this.desdeAsesor.Name = "desdeAsesor";
			this.desdeAsesor.ValueChanged += new System.EventHandler(this.BriefCambio);
			// 
			// hastaAsesorLabel
			// 
			this.hastaAsesorLabel.AutoSize = true;
			this.hastaAsesorLabel.Text = "Hasta";
			this.hastaAsesorLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.hastaAsesorLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.hastaAsesorLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.hastaAsesorLabel.TabIndex = 8;
			this.hastaAsesorLabel.Name = "hastaAsesorLabel";
			// 
			// hastaAsesor
			// 
			this.hastaAsesor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.hastaAsesor.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.hastaAsesor.CustomFormat = "dd/MM/yyyy HH:mm";
			this.hastaAsesor.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.hastaAsesor.TabIndex = 9;
			this.hastaAsesor.Name = "hastaAsesor";
			this.hastaAsesor.ValueChanged += new System.EventHandler(this.BriefCambio);
			// 
			// personasLabel
			// 
			this.personasLabel.AutoSize = true;
			this.personasLabel.Text = "Personas en cámara";
			this.personasLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.personasLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.personasLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.personasLabel.TabIndex = 10;
			this.personasLabel.Name = "personasLabel";
			// 
			// personas
			// 
			this.personas.Dock = System.Windows.Forms.DockStyle.Fill;
			this.personas.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.personas.DecimalPlaces = 0;
			this.personas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			this.personas.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
			this.personas.Value = new decimal(new int[] { 2, 0, 0, 0 });
			this.personas.ThousandsSeparator = true;
			this.personas.TabIndex = 11;
			this.personas.Name = "personas";
			this.personas.ValueChanged += new System.EventHandler(this.BriefCambio);
			// 
			// camarasLabel
			// 
			this.camarasLabel.AutoSize = true;
			this.camarasLabel.Text = "Cámaras";
			this.camarasLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.camarasLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.camarasLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.camarasLabel.TabIndex = 12;
			this.camarasLabel.Name = "camarasLabel";
			// 
			// camaras
			// 
			this.camaras.Dock = System.Windows.Forms.DockStyle.Fill;
			this.camaras.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.camaras.DecimalPlaces = 0;
			this.camaras.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			this.camaras.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
			this.camaras.Value = new decimal(new int[] { 1, 0, 0, 0 });
			this.camaras.ThousandsSeparator = true;
			this.camaras.TabIndex = 13;
			this.camaras.Name = "camaras";
			this.camaras.ValueChanged += new System.EventHandler(this.BriefCambio);
			// 
			// locacionLabel
			// 
			this.locacionLabel.AutoSize = true;
			this.locacionLabel.Text = "Locación";
			this.locacionLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.locacionLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.locacionLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.locacionLabel.TabIndex = 14;
			this.locacionLabel.Name = "locacionLabel";
			// 
			// locacion
			// 
			this.locacion.Items.AddRange(new object[] {
				"Interior",
	"Exterior",
	"Mixta"});
			this.locacion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.locacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.locacion.FormattingEnabled = true;
			this.locacion.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.locacion.TabIndex = 15;
			this.locacion.Name = "locacion";
			this.locacion.SelectedIndexChanged += new System.EventHandler(this.BriefCambio);
			// 
			// luzLabel
			// 
			this.luzLabel.AutoSize = true;
			this.luzLabel.Text = "Luz disponible";
			this.luzLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.luzLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.luzLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.luzLabel.TabIndex = 16;
			this.luzLabel.Name = "luzLabel";
			// 
			// luz
			// 
			this.luz.Items.AddRange(new object[] {
				"Escasa",
	"Media",
	"Buena"});
			this.luz.Dock = System.Windows.Forms.DockStyle.Fill;
			this.luz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.luz.FormattingEnabled = true;
			this.luz.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.luz.TabIndex = 17;
			this.luz.Name = "luz";
			this.luz.SelectedIndexChanged += new System.EventHandler(this.BriefCambio);
			// 
			// movimiento
			// 
			this.movimiento.AutoSize = true;
			this.movimiento.Text = "Cámara móvil";
			this.movimiento.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.movimiento.Margin = new System.Windows.Forms.Padding(0, 4, 12, 6);
			this.movimiento.UseVisualStyleBackColor = true;
			this.movimiento.TabIndex = 18;
			this.movimiento.Name = "movimiento";
			this.movimiento.CheckedChanged += new System.EventHandler(this.BriefCambio);
			// 
			// sonido
			// 
			this.sonido.AutoSize = true;
			this.sonido.Text = "Sonido directo";
			this.sonido.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.sonido.Margin = new System.Windows.Forms.Padding(0, 4, 12, 6);
			this.sonido.UseVisualStyleBackColor = true;
			this.sonido.TabIndex = 19;
			this.sonido.Name = "sonido";
			this.sonido.CheckedChanged += new System.EventHandler(this.BriefCambio);
			// 
			// monitoreo
			// 
			this.monitoreo.AutoSize = true;
			this.monitoreo.Text = "Monitoreo en set";
			this.monitoreo.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.monitoreo.Margin = new System.Windows.Forms.Padding(0, 4, 12, 6);
			this.monitoreo.UseVisualStyleBackColor = true;
			this.monitoreo.TabIndex = 20;
			this.monitoreo.Name = "monitoreo";
			this.monitoreo.CheckedChanged += new System.EventHandler(this.BriefCambio);
			// 
			// cine
			// 
			this.cine.AutoSize = true;
			this.cine.Text = "Look cinematográfico";
			this.cine.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.cine.Margin = new System.Windows.Forms.Padding(0, 4, 12, 6);
			this.cine.UseVisualStyleBackColor = true;
			this.cine.TabIndex = 21;
			this.cine.Name = "cine";
			this.cine.CheckedChanged += new System.EventHandler(this.BriefCambio);
			// 
			// resumenCard
			// 
			this.resumenCard.ColumnCount = 1;
			this.resumenCard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.resumenCard.RowCount = 1;
			this.resumenCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.resumenCard.AutoSize = true;
			this.resumenCard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.resumenCard.BackColor = System.Drawing.Color.White;
			this.resumenCard.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resumenCard.Padding = new System.Windows.Forms.Padding(18, 4, 18, 4);
			this.resumenCard.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
			this.resumenCard.TabIndex = 1;
			this.resumenCard.Name = "resumenCard";
			this.resumenCard.Controls.Add(this.resumen, 0, 0);
			// 
			// resumen
			// 
			this.resumen.Text = "";
			this.resumen.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.resumen.AutoSize = false;
			this.resumen.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resumen.Size = new System.Drawing.Size(0, 50);
			this.resumen.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
			this.resumen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.resumen.TabIndex = 0;
			this.resumen.Name = "resumen";
			// 
			// tabs
			// 
			this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabs.SelectedIndex = 0;
			this.tabs.ItemSize = new System.Drawing.Size(0, 34);
			this.tabs.Padding = new System.Drawing.Point(20, 6);
			this.tabs.MinimumSize = new System.Drawing.Size(0, 440);
			this.tabs.TabIndex = 2;
			this.tabs.Name = "tabs";
			this.tabs.Controls.Add(this.recomendadaTab);
			this.tabs.Controls.Add(this.economicaTab);
			this.tabs.Controls.Add(this.complementosTab);
			this.tabs.Controls.Add(this.lecturaTab);
			this.tabs.Controls.Add(this.guardadasTab);
			this.tabs.SelectedIndexChanged += new System.EventHandler(this.TabCambio);
			// 
			// recomendadaTab
			// 
			this.recomendadaTab.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.recomendadaTab.Padding = new System.Windows.Forms.Padding(16, 16, 16, 16);
			this.recomendadaTab.Text = "Configuración recomendada";
			this.recomendadaTab.UseVisualStyleBackColor = false;
			this.recomendadaTab.TabIndex = 0;
			this.recomendadaTab.Name = "recomendadaTab";
			this.recomendadaTab.Controls.Add(this.recomendadaTabLayout);
			// 
			// recomendadaTabLayout
			// 
			this.recomendadaTabLayout.ColumnCount = 1;
			this.recomendadaTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.recomendadaTabLayout.RowCount = 2;
			this.recomendadaTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.recomendadaTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.recomendadaTabLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.recomendadaTabLayout.BackColor = System.Drawing.Color.Transparent;
			this.recomendadaTabLayout.TabIndex = 0;
			this.recomendadaTabLayout.Name = "recomendadaTabLayout";
			this.recomendadaTabLayout.Controls.Add(this.propuestaRec, 0, 0);
			this.recomendadaTabLayout.Controls.Add(this.notasRec, 0, 1);
			// 
			// propuestaRec
			// 
			this.propuestaRec.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
				this.propuestaRecRolColumna,
	this.propuestaRecDetalleColumna,
	this.propuestaRecGamaColumna,
	this.propuestaRecSubtotalColumna,
	this.propuestaRecAportaColumna,
	this.propuestaRecResignaColumna});
			this.propuestaRec.AllowUserToAddRows = false;
			this.propuestaRec.AllowUserToDeleteRows = false;
			this.propuestaRec.AllowUserToResizeRows = false;
			this.propuestaRec.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.propuestaRec.BackgroundColor = System.Drawing.Color.White;
			this.propuestaRec.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.propuestaRec.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.propuestaRec.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.propuestaRec.ColumnHeadersHeight = 38;
			this.propuestaRec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.propuestaRec.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propuestaRec.EnableHeadersVisualStyles = false;
			this.propuestaRec.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
			this.propuestaRec.MultiSelect = false;
			this.propuestaRec.ReadOnly = true;
			this.propuestaRec.RowHeadersVisible = false;
			this.propuestaRec.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.propuestaRec.RowTemplate.Height = 34;
			this.propuestaRec.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.propuestaRec.DefaultCellStyle = dataGridViewCellStyle2;
			this.propuestaRec.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.propuestaRec.AutoGenerateColumns = false;
			this.propuestaRec.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.propuestaRec.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
			this.propuestaRec.TabIndex = 0;
			this.propuestaRec.Name = "propuestaRec";
			this.propuestaRec.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.FormatearSeccion);
			// 
			// propuestaRecRolColumna
			// 
			this.propuestaRecRolColumna.HeaderText = "Rol";
			this.propuestaRecRolColumna.MinimumWidth = 85;
			this.propuestaRecRolColumna.Name = "propuestaRecRolColumna";
			this.propuestaRecRolColumna.ReadOnly = true;
			this.propuestaRecRolColumna.DataPropertyName = "Rol";
			// 
			// propuestaRecDetalleColumna
			// 
			this.propuestaRecDetalleColumna.HeaderText = "Equipo";
			this.propuestaRecDetalleColumna.MinimumWidth = 150;
			this.propuestaRecDetalleColumna.Name = "propuestaRecDetalleColumna";
			this.propuestaRecDetalleColumna.ReadOnly = true;
			this.propuestaRecDetalleColumna.DataPropertyName = "Detalle";
			this.propuestaRecDetalleColumna.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			// 
			// propuestaRecGamaColumna
			// 
			this.propuestaRecGamaColumna.HeaderText = "Gama";
			this.propuestaRecGamaColumna.MinimumWidth = 85;
			this.propuestaRecGamaColumna.Name = "propuestaRecGamaColumna";
			this.propuestaRecGamaColumna.ReadOnly = true;
			this.propuestaRecGamaColumna.DataPropertyName = "Gama";
			// 
			// propuestaRecSubtotalColumna
			// 
			this.propuestaRecSubtotalColumna.HeaderText = "Subtotal ARS";
			this.propuestaRecSubtotalColumna.MinimumWidth = 95;
			this.propuestaRecSubtotalColumna.Name = "propuestaRecSubtotalColumna";
			this.propuestaRecSubtotalColumna.ReadOnly = true;
			this.propuestaRecSubtotalColumna.DataPropertyName = "Subtotal";
			this.propuestaRecSubtotalColumna.DefaultCellStyle.Format = "N2";
			// 
			// propuestaRecAportaColumna
			// 
			this.propuestaRecAportaColumna.HeaderText = "Qué ganás";
			this.propuestaRecAportaColumna.MinimumWidth = 170;
			this.propuestaRecAportaColumna.Name = "propuestaRecAportaColumna";
			this.propuestaRecAportaColumna.ReadOnly = true;
			this.propuestaRecAportaColumna.DataPropertyName = "Aporta";
			this.propuestaRecAportaColumna.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.propuestaRecAportaColumna.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
			// 
			// propuestaRecResignaColumna
			// 
			this.propuestaRecResignaColumna.HeaderText = "Qué resignás";
			this.propuestaRecResignaColumna.MinimumWidth = 170;
			this.propuestaRecResignaColumna.Name = "propuestaRecResignaColumna";
			this.propuestaRecResignaColumna.ReadOnly = true;
			this.propuestaRecResignaColumna.DataPropertyName = "Resigna";
			this.propuestaRecResignaColumna.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.propuestaRecResignaColumna.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
			// 
			// notasRec
			// 
			this.notasRec.Text = "";
			this.notasRec.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.notasRec.AutoSize = false;
			this.notasRec.Dock = System.Windows.Forms.DockStyle.Fill;
			this.notasRec.Size = new System.Drawing.Size(0, 56);
			this.notasRec.TabIndex = 1;
			this.notasRec.Name = "notasRec";
			// 
			// economicaTab
			// 
			this.economicaTab.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.economicaTab.Padding = new System.Windows.Forms.Padding(16, 16, 16, 16);
			this.economicaTab.Text = "Alternativa económica";
			this.economicaTab.UseVisualStyleBackColor = false;
			this.economicaTab.TabIndex = 1;
			this.economicaTab.Name = "economicaTab";
			this.economicaTab.Controls.Add(this.economicaTabLayout);
			// 
			// economicaTabLayout
			// 
			this.economicaTabLayout.ColumnCount = 1;
			this.economicaTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.economicaTabLayout.RowCount = 2;
			this.economicaTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.economicaTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.economicaTabLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.economicaTabLayout.BackColor = System.Drawing.Color.Transparent;
			this.economicaTabLayout.TabIndex = 0;
			this.economicaTabLayout.Name = "economicaTabLayout";
			this.economicaTabLayout.Controls.Add(this.propuestaEco, 0, 0);
			this.economicaTabLayout.Controls.Add(this.notasEco, 0, 1);
			// 
			// propuestaEco
			// 
			this.propuestaEco.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
				this.propuestaEcoRolColumna,
	this.propuestaEcoDetalleColumna,
	this.propuestaEcoGamaColumna,
	this.propuestaEcoSubtotalColumna,
	this.propuestaEcoAportaColumna,
	this.propuestaEcoResignaColumna});
			this.propuestaEco.AllowUserToAddRows = false;
			this.propuestaEco.AllowUserToDeleteRows = false;
			this.propuestaEco.AllowUserToResizeRows = false;
			this.propuestaEco.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.propuestaEco.BackgroundColor = System.Drawing.Color.White;
			this.propuestaEco.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.propuestaEco.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.propuestaEco.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.propuestaEco.ColumnHeadersHeight = 38;
			this.propuestaEco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.propuestaEco.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propuestaEco.EnableHeadersVisualStyles = false;
			this.propuestaEco.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
			this.propuestaEco.MultiSelect = false;
			this.propuestaEco.ReadOnly = true;
			this.propuestaEco.RowHeadersVisible = false;
			this.propuestaEco.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.propuestaEco.RowTemplate.Height = 34;
			this.propuestaEco.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.propuestaEco.DefaultCellStyle = dataGridViewCellStyle5;
			this.propuestaEco.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
			this.propuestaEco.AutoGenerateColumns = false;
			this.propuestaEco.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.propuestaEco.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
			this.propuestaEco.TabIndex = 0;
			this.propuestaEco.Name = "propuestaEco";
			this.propuestaEco.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.FormatearSeccion);
			// 
			// propuestaEcoRolColumna
			// 
			this.propuestaEcoRolColumna.HeaderText = "Rol";
			this.propuestaEcoRolColumna.MinimumWidth = 85;
			this.propuestaEcoRolColumna.Name = "propuestaEcoRolColumna";
			this.propuestaEcoRolColumna.ReadOnly = true;
			this.propuestaEcoRolColumna.DataPropertyName = "Rol";
			// 
			// propuestaEcoDetalleColumna
			// 
			this.propuestaEcoDetalleColumna.HeaderText = "Equipo";
			this.propuestaEcoDetalleColumna.MinimumWidth = 150;
			this.propuestaEcoDetalleColumna.Name = "propuestaEcoDetalleColumna";
			this.propuestaEcoDetalleColumna.ReadOnly = true;
			this.propuestaEcoDetalleColumna.DataPropertyName = "Detalle";
			this.propuestaEcoDetalleColumna.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			// 
			// propuestaEcoGamaColumna
			// 
			this.propuestaEcoGamaColumna.HeaderText = "Gama";
			this.propuestaEcoGamaColumna.MinimumWidth = 85;
			this.propuestaEcoGamaColumna.Name = "propuestaEcoGamaColumna";
			this.propuestaEcoGamaColumna.ReadOnly = true;
			this.propuestaEcoGamaColumna.DataPropertyName = "Gama";
			// 
			// propuestaEcoSubtotalColumna
			// 
			this.propuestaEcoSubtotalColumna.HeaderText = "Subtotal ARS";
			this.propuestaEcoSubtotalColumna.MinimumWidth = 95;
			this.propuestaEcoSubtotalColumna.Name = "propuestaEcoSubtotalColumna";
			this.propuestaEcoSubtotalColumna.ReadOnly = true;
			this.propuestaEcoSubtotalColumna.DataPropertyName = "Subtotal";
			this.propuestaEcoSubtotalColumna.DefaultCellStyle.Format = "N2";
			// 
			// propuestaEcoAportaColumna
			// 
			this.propuestaEcoAportaColumna.HeaderText = "Qué ganás";
			this.propuestaEcoAportaColumna.MinimumWidth = 170;
			this.propuestaEcoAportaColumna.Name = "propuestaEcoAportaColumna";
			this.propuestaEcoAportaColumna.ReadOnly = true;
			this.propuestaEcoAportaColumna.DataPropertyName = "Aporta";
			this.propuestaEcoAportaColumna.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.propuestaEcoAportaColumna.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
			// 
			// propuestaEcoResignaColumna
			// 
			this.propuestaEcoResignaColumna.HeaderText = "Qué resignás";
			this.propuestaEcoResignaColumna.MinimumWidth = 170;
			this.propuestaEcoResignaColumna.Name = "propuestaEcoResignaColumna";
			this.propuestaEcoResignaColumna.ReadOnly = true;
			this.propuestaEcoResignaColumna.DataPropertyName = "Resigna";
			this.propuestaEcoResignaColumna.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.propuestaEcoResignaColumna.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
			// 
			// notasEco
			// 
			this.notasEco.Text = "";
			this.notasEco.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.notasEco.AutoSize = false;
			this.notasEco.Dock = System.Windows.Forms.DockStyle.Fill;
			this.notasEco.Size = new System.Drawing.Size(0, 56);
			this.notasEco.TabIndex = 1;
			this.notasEco.Name = "notasEco";
			// 
			// complementosTab
			// 
			this.complementosTab.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.complementosTab.Padding = new System.Windows.Forms.Padding(16, 16, 16, 16);
			this.complementosTab.Text = "Complementos opcionales";
			this.complementosTab.UseVisualStyleBackColor = false;
			this.complementosTab.TabIndex = 2;
			this.complementosTab.Name = "complementosTab";
			this.complementosTab.Controls.Add(this.complementosTabLayout);
			// 
			// complementosTabLayout
			// 
			this.complementosTabLayout.ColumnCount = 1;
			this.complementosTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.complementosTabLayout.RowCount = 2;
			this.complementosTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.complementosTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.complementosTabLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.complementosTabLayout.BackColor = System.Drawing.Color.Transparent;
			this.complementosTabLayout.TabIndex = 0;
			this.complementosTabLayout.Name = "complementosTabLayout";
			this.complementosTabLayout.Controls.Add(this.complementos, 0, 0);
			this.complementosTabLayout.Controls.Add(this.complementosNota, 0, 1);
			// 
			// complementos
			// 
			this.complementos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
				this.complementosRolColumna,
	this.complementosDetalleColumna,
	this.complementosGamaColumna,
	this.complementosSubtotalColumna,
	this.complementosAportaColumna,
	this.complementosResignaColumna});
			this.complementos.AllowUserToAddRows = false;
			this.complementos.AllowUserToDeleteRows = false;
			this.complementos.AllowUserToResizeRows = false;
			this.complementos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.complementos.BackgroundColor = System.Drawing.Color.White;
			this.complementos.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.complementos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.complementos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.complementos.ColumnHeadersHeight = 38;
			this.complementos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.complementos.Dock = System.Windows.Forms.DockStyle.Fill;
			this.complementos.EnableHeadersVisualStyles = false;
			this.complementos.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
			this.complementos.MultiSelect = true;
			this.complementos.ReadOnly = true;
			this.complementos.RowHeadersVisible = false;
			this.complementos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.complementos.RowTemplate.Height = 34;
			this.complementos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
			this.complementos.DefaultCellStyle = dataGridViewCellStyle8;
			this.complementos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
			this.complementos.AutoGenerateColumns = false;
			this.complementos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.complementos.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
			this.complementos.TabIndex = 0;
			this.complementos.Name = "complementos";
			this.complementos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.FormatearSeccion);
			// 
			// complementosRolColumna
			// 
			this.complementosRolColumna.HeaderText = "Rol";
			this.complementosRolColumna.MinimumWidth = 85;
			this.complementosRolColumna.Name = "complementosRolColumna";
			this.complementosRolColumna.ReadOnly = true;
			this.complementosRolColumna.DataPropertyName = "Rol";
			// 
			// complementosDetalleColumna
			// 
			this.complementosDetalleColumna.HeaderText = "Equipo";
			this.complementosDetalleColumna.MinimumWidth = 150;
			this.complementosDetalleColumna.Name = "complementosDetalleColumna";
			this.complementosDetalleColumna.ReadOnly = true;
			this.complementosDetalleColumna.DataPropertyName = "Detalle";
			this.complementosDetalleColumna.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			// 
			// complementosGamaColumna
			// 
			this.complementosGamaColumna.HeaderText = "Gama";
			this.complementosGamaColumna.MinimumWidth = 85;
			this.complementosGamaColumna.Name = "complementosGamaColumna";
			this.complementosGamaColumna.ReadOnly = true;
			this.complementosGamaColumna.DataPropertyName = "Gama";
			// 
			// complementosSubtotalColumna
			// 
			this.complementosSubtotalColumna.HeaderText = "Subtotal ARS";
			this.complementosSubtotalColumna.MinimumWidth = 95;
			this.complementosSubtotalColumna.Name = "complementosSubtotalColumna";
			this.complementosSubtotalColumna.ReadOnly = true;
			this.complementosSubtotalColumna.DataPropertyName = "Subtotal";
			this.complementosSubtotalColumna.DefaultCellStyle.Format = "N2";
			// 
			// complementosAportaColumna
			// 
			this.complementosAportaColumna.HeaderText = "Qué ganás";
			this.complementosAportaColumna.MinimumWidth = 170;
			this.complementosAportaColumna.Name = "complementosAportaColumna";
			this.complementosAportaColumna.ReadOnly = true;
			this.complementosAportaColumna.DataPropertyName = "Aporta";
			this.complementosAportaColumna.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.complementosAportaColumna.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
			// 
			// complementosResignaColumna
			// 
			this.complementosResignaColumna.HeaderText = "Qué resignás";
			this.complementosResignaColumna.MinimumWidth = 170;
			this.complementosResignaColumna.Name = "complementosResignaColumna";
			this.complementosResignaColumna.ReadOnly = true;
			this.complementosResignaColumna.DataPropertyName = "Resigna";
			this.complementosResignaColumna.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.complementosResignaColumna.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
			// 
			// complementosNota
			// 
			this.complementosNota.Text = "Seleccioná los que quieras sumar (Ctrl + clic para varios): se agregan a la propuesta que uses.";
			this.complementosNota.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
			this.complementosNota.AutoSize = false;
			this.complementosNota.Dock = System.Windows.Forms.DockStyle.Fill;
			this.complementosNota.Size = new System.Drawing.Size(0, 40);
			this.complementosNota.TabIndex = 1;
			this.complementosNota.Name = "complementosNota";
			// 
			// lecturaTab
			// 
			this.lecturaTab.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.lecturaTab.Padding = new System.Windows.Forms.Padding(16, 16, 16, 16);
			this.lecturaTab.Text = "Lectura técnica";
			this.lecturaTab.UseVisualStyleBackColor = false;
			this.lecturaTab.TabIndex = 3;
			this.lecturaTab.Name = "lecturaTab";
			this.lecturaTab.Controls.Add(this.lectura);
			// 
			// lectura
			// 
			this.lectura.BackColor = System.Drawing.Color.White;
			this.lectura.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lectura.Multiline = true;
			this.lectura.ReadOnly = true;
			this.lectura.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.lectura.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
			this.lectura.TabIndex = 0;
			this.lectura.Name = "lectura";
			// 
			// guardadasTab
			// 
			this.guardadasTab.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.guardadasTab.Padding = new System.Windows.Forms.Padding(16, 16, 16, 16);
			this.guardadasTab.Text = "Mis propuestas";
			this.guardadasTab.UseVisualStyleBackColor = false;
			this.guardadasTab.TabIndex = 4;
			this.guardadasTab.Name = "guardadasTab";
			this.guardadasTab.Controls.Add(this.guardadasTabLayout);
			// 
			// guardadasTabLayout
			// 
			this.guardadasTabLayout.ColumnCount = 1;
			this.guardadasTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.guardadasTabLayout.RowCount = 2;
			this.guardadasTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.guardadasTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.guardadasTabLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.guardadasTabLayout.BackColor = System.Drawing.Color.Transparent;
			this.guardadasTabLayout.TabIndex = 0;
			this.guardadasTabLayout.Name = "guardadasTabLayout";
			this.guardadasTabLayout.Controls.Add(this.guardadas, 0, 0);
			this.guardadasTabLayout.Controls.Add(this.guardadasAcciones, 0, 1);
			// 
			// guardadas
			// 
			this.guardadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
				this.guardadasNombreColumna,
	this.guardadasCreadaColumna,
	this.guardadasResumenColumna,
	this.guardadasVarianteColumna,
	this.guardadasTotalColumna});
			this.guardadas.AllowUserToAddRows = false;
			this.guardadas.AllowUserToDeleteRows = false;
			this.guardadas.AllowUserToResizeRows = false;
			this.guardadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.guardadas.BackgroundColor = System.Drawing.Color.White;
			this.guardadas.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.guardadas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.guardadas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.guardadas.ColumnHeadersHeight = 38;
			this.guardadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.guardadas.Dock = System.Windows.Forms.DockStyle.Fill;
			this.guardadas.EnableHeadersVisualStyles = false;
			this.guardadas.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
			this.guardadas.MultiSelect = false;
			this.guardadas.ReadOnly = true;
			this.guardadas.RowHeadersVisible = false;
			this.guardadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.guardadas.RowTemplate.Height = 34;
			this.guardadas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
			this.guardadas.DefaultCellStyle = dataGridViewCellStyle11;
			this.guardadas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle12;
			this.guardadas.AutoGenerateColumns = false;
			this.guardadas.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
			this.guardadas.TabIndex = 0;
			this.guardadas.Name = "guardadas";
			this.guardadas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AbrirGuardadaDoble);
			this.guardadas.SelectionChanged += new System.EventHandler(this.GuardadaSeleccionCambio);
			// 
			// guardadasNombreColumna
			// 
			this.guardadasNombreColumna.HeaderText = "Nombre";
			this.guardadasNombreColumna.MinimumWidth = 150;
			this.guardadasNombreColumna.Name = "guardadasNombreColumna";
			this.guardadasNombreColumna.ReadOnly = true;
			this.guardadasNombreColumna.DataPropertyName = "Nombre";
			// 
			// guardadasCreadaColumna
			// 
			this.guardadasCreadaColumna.HeaderText = "Guardada";
			this.guardadasCreadaColumna.MinimumWidth = 110;
			this.guardadasCreadaColumna.Name = "guardadasCreadaColumna";
			this.guardadasCreadaColumna.ReadOnly = true;
			this.guardadasCreadaColumna.DataPropertyName = "Creada";
			this.guardadasCreadaColumna.DefaultCellStyle.Format = "dd/MM/yy HH:mm";
			// 
			// guardadasResumenColumna
			// 
			this.guardadasResumenColumna.HeaderText = "Producción";
			this.guardadasResumenColumna.MinimumWidth = 200;
			this.guardadasResumenColumna.Name = "guardadasResumenColumna";
			this.guardadasResumenColumna.ReadOnly = true;
			this.guardadasResumenColumna.DataPropertyName = "Resumen";
			// 
			// guardadasVarianteColumna
			// 
			this.guardadasVarianteColumna.HeaderText = "Variante";
			this.guardadasVarianteColumna.MinimumWidth = 100;
			this.guardadasVarianteColumna.Name = "guardadasVarianteColumna";
			this.guardadasVarianteColumna.ReadOnly = true;
			this.guardadasVarianteColumna.DataPropertyName = "Variante";
			// 
			// guardadasTotalColumna
			// 
			this.guardadasTotalColumna.HeaderText = "Total ARS";
			this.guardadasTotalColumna.MinimumWidth = 100;
			this.guardadasTotalColumna.Name = "guardadasTotalColumna";
			this.guardadasTotalColumna.ReadOnly = true;
			this.guardadasTotalColumna.DataPropertyName = "Total";
			this.guardadasTotalColumna.DefaultCellStyle.Format = "N2";
			// 
			// guardadasAcciones
			// 
			this.guardadasAcciones.AutoSize = true;
			this.guardadasAcciones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.guardadasAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
			this.guardadasAcciones.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.guardadasAcciones.TabIndex = 1;
			this.guardadasAcciones.Name = "guardadasAcciones";
			this.guardadasAcciones.Controls.Add(this.abrirGuardadaBoton);
			this.guardadasAcciones.Controls.Add(this.eliminarGuardadaBoton);
			this.guardadasAcciones.Controls.Add(this.guardadasNota);
			// 
			// abrirGuardadaBoton
			// 
			this.abrirGuardadaBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.abrirGuardadaBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.abrirGuardadaBoton.Size = new System.Drawing.Size(140, 38);
			this.abrirGuardadaBoton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.abrirGuardadaBoton.Text = "Abrir";
			this.abrirGuardadaBoton.UseVisualStyleBackColor = false;
			this.abrirGuardadaBoton.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
			this.abrirGuardadaBoton.ForeColor = System.Drawing.Color.White;
			this.abrirGuardadaBoton.FlatAppearance.BorderSize = 0;
			this.abrirGuardadaBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(29, 78, 216);
			this.abrirGuardadaBoton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.abrirGuardadaBoton.Enabled = false;
			this.abrirGuardadaBoton.TabIndex = 0;
			this.abrirGuardadaBoton.Name = "abrirGuardadaBoton";
			this.abrirGuardadaBoton.Click += new System.EventHandler(this.AbrirGuardadaClick);
			// 
			// eliminarGuardadaBoton
			// 
			this.eliminarGuardadaBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.eliminarGuardadaBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.eliminarGuardadaBoton.Size = new System.Drawing.Size(140, 38);
			this.eliminarGuardadaBoton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.eliminarGuardadaBoton.Text = "Eliminar";
			this.eliminarGuardadaBoton.UseVisualStyleBackColor = false;
			this.eliminarGuardadaBoton.BackColor = System.Drawing.Color.White;
			this.eliminarGuardadaBoton.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.eliminarGuardadaBoton.FlatAppearance.BorderSize = 1;
			this.eliminarGuardadaBoton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
			this.eliminarGuardadaBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.eliminarGuardadaBoton.Enabled = false;
			this.eliminarGuardadaBoton.TabIndex = 1;
			this.eliminarGuardadaBoton.Name = "eliminarGuardadaBoton";
			this.eliminarGuardadaBoton.Click += new System.EventHandler(this.EliminarGuardadaClick);
			// 
			// guardadasNota
			// 
			this.guardadasNota.Text = "Abrir carga el brief y recalcula con los equipos disponibles hoy.";
			this.guardadasNota.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
			this.guardadasNota.AutoSize = true;
			this.guardadasNota.Margin = new System.Windows.Forms.Padding(6, 10, 0, 0);
			this.guardadasNota.TabIndex = 2;
			this.guardadasNota.Name = "guardadasNota";
			// 
			// asesorAcciones
			// 
			this.asesorAcciones.AutoSize = true;
			this.asesorAcciones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.asesorAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
			this.asesorAcciones.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.asesorAcciones.TabIndex = 3;
			this.asesorAcciones.Name = "asesorAcciones";
			this.asesorAcciones.Controls.Add(this.usarBoton);
			this.asesorAcciones.Controls.Add(this.imprimirBoton);
			this.asesorAcciones.Controls.Add(this.actualizarAsesorBoton);
			this.asesorAcciones.Controls.Add(this.guardarComoLabel);
			this.asesorAcciones.Controls.Add(this.nombrePropuesta);
			this.asesorAcciones.Controls.Add(this.guardarPropuestaBoton);
			this.asesorAcciones.Controls.Add(this.usarNota);
			// 
			// usarBoton
			// 
			this.usarBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.usarBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.usarBoton.Size = new System.Drawing.Size(220, 38);
			this.usarBoton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.usarBoton.Text = "Usar en una solicitud";
			this.usarBoton.UseVisualStyleBackColor = false;
			this.usarBoton.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
			this.usarBoton.ForeColor = System.Drawing.Color.White;
			this.usarBoton.FlatAppearance.BorderSize = 0;
			this.usarBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(29, 78, 216);
			this.usarBoton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.usarBoton.Enabled = false;
			this.usarBoton.TabIndex = 0;
			this.usarBoton.Name = "usarBoton";
			this.usarBoton.Click += new System.EventHandler(this.UsarClick);
			// 
			// imprimirBoton
			// 
			this.imprimirBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.imprimirBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.imprimirBoton.Size = new System.Drawing.Size(170, 38);
			this.imprimirBoton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.imprimirBoton.Text = "Imprimir (PDF)";
			this.imprimirBoton.UseVisualStyleBackColor = false;
			this.imprimirBoton.BackColor = System.Drawing.Color.White;
			this.imprimirBoton.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.imprimirBoton.FlatAppearance.BorderSize = 1;
			this.imprimirBoton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
			this.imprimirBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.imprimirBoton.Enabled = false;
			this.imprimirBoton.TabIndex = 1;
			this.imprimirBoton.Name = "imprimirBoton";
			this.imprimirBoton.Click += new System.EventHandler(this.ImprimirClick);
			// 
			// actualizarAsesorBoton
			// 
			this.actualizarAsesorBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.actualizarAsesorBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.actualizarAsesorBoton.Size = new System.Drawing.Size(170, 38);
			this.actualizarAsesorBoton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.actualizarAsesorBoton.Text = "Actualizar";
			this.actualizarAsesorBoton.UseVisualStyleBackColor = false;
			this.actualizarAsesorBoton.BackColor = System.Drawing.Color.White;
			this.actualizarAsesorBoton.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.actualizarAsesorBoton.FlatAppearance.BorderSize = 1;
			this.actualizarAsesorBoton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
			this.actualizarAsesorBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.actualizarAsesorBoton.TabIndex = 2;
			this.actualizarAsesorBoton.Name = "actualizarAsesorBoton";
			this.actualizarAsesorBoton.Click += new System.EventHandler(this.BriefCambio);
			// 
			// guardarComoLabel
			// 
			this.guardarComoLabel.Text = "Guardar como:";
			this.guardarComoLabel.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
			this.guardarComoLabel.AutoSize = true;
			this.guardarComoLabel.Margin = new System.Windows.Forms.Padding(14, 10, 0, 0);
			this.guardarComoLabel.TabIndex = 3;
			this.guardarComoLabel.Name = "guardarComoLabel";
			// 
			// nombrePropuesta
			// 
			this.nombrePropuesta.Size = new System.Drawing.Size(210, 27);
			this.nombrePropuesta.MaxLength = 100;
			this.nombrePropuesta.Margin = new System.Windows.Forms.Padding(6, 6, 8, 0);
			this.nombrePropuesta.TabIndex = 4;
			this.nombrePropuesta.Name = "nombrePropuesta";
			// 
			// guardarPropuestaBoton
			// 
			this.guardarPropuestaBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.guardarPropuestaBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.guardarPropuestaBoton.Size = new System.Drawing.Size(170, 38);
			this.guardarPropuestaBoton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.guardarPropuestaBoton.Text = "Guardar propuesta";
			this.guardarPropuestaBoton.UseVisualStyleBackColor = false;
			this.guardarPropuestaBoton.BackColor = System.Drawing.Color.White;
			this.guardarPropuestaBoton.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.guardarPropuestaBoton.FlatAppearance.BorderSize = 1;
			this.guardarPropuestaBoton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
			this.guardarPropuestaBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.guardarPropuestaBoton.Enabled = false;
			this.guardarPropuestaBoton.TabIndex = 5;
			this.guardarPropuestaBoton.Name = "guardarPropuestaBoton";
			this.guardarPropuestaBoton.Click += new System.EventHandler(this.GuardarPropuestaClick);
			// 
			// usarNota
			// 
			this.usarNota.Text = "Reserva los equipos de la propuesta elegida (más los complementos seleccionados) en Nueva solicitud.";
			this.usarNota.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
			this.usarNota.AutoSize = true;
			this.usarNota.Margin = new System.Windows.Forms.Padding(6, 10, 0, 0);
			this.usarNota.TabIndex = 6;
			this.usarNota.Name = "usarNota";
			this.asesorAcciones.ResumeLayout(false);
			this.asesorAcciones.PerformLayout();
			this.guardadasAcciones.ResumeLayout(false);
			this.guardadasAcciones.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.guardadas)).EndInit();
			this.guardadasTabLayout.ResumeLayout(false);
			this.guardadasTabLayout.PerformLayout();
			this.guardadasTab.ResumeLayout(false);
			this.guardadasTab.PerformLayout();
			this.lecturaTab.ResumeLayout(false);
			this.lecturaTab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.complementos)).EndInit();
			this.complementosTabLayout.ResumeLayout(false);
			this.complementosTabLayout.PerformLayout();
			this.complementosTab.ResumeLayout(false);
			this.complementosTab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.propuestaEco)).EndInit();
			this.economicaTabLayout.ResumeLayout(false);
			this.economicaTabLayout.PerformLayout();
			this.economicaTab.ResumeLayout(false);
			this.economicaTab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.propuestaRec)).EndInit();
			this.recomendadaTabLayout.ResumeLayout(false);
			this.recomendadaTabLayout.PerformLayout();
			this.recomendadaTab.ResumeLayout(false);
			this.recomendadaTab.PerformLayout();
			this.tabs.ResumeLayout(false);
			this.resumenCard.ResumeLayout(false);
			this.resumenCard.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.camaras)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.personas)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.horas)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.presupuesto)).EndInit();
			this.brief.ResumeLayout(false);
			this.brief.PerformLayout();
			this.asesorLayout.ResumeLayout(false);
			this.asesorLayout.PerformLayout();
			this.desplazable.ResumeLayout(false);
			this.desplazable.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
#endregion

		private System.Windows.Forms.Panel desplazable;
		private System.Windows.Forms.TableLayoutPanel asesorLayout;
		private System.Windows.Forms.TableLayoutPanel brief;
		private System.Windows.Forms.Label tipoPiezaLabel;
		private System.Windows.Forms.ComboBox tipoPieza;
		private System.Windows.Forms.Label presupuestoLabel;
		private System.Windows.Forms.NumericUpDown presupuesto;
		private System.Windows.Forms.Label horasLabel;
		private System.Windows.Forms.NumericUpDown horas;
		private System.Windows.Forms.Label desdeAsesorLabel;
		private System.Windows.Forms.DateTimePicker desdeAsesor;
		private System.Windows.Forms.Label hastaAsesorLabel;
		private System.Windows.Forms.DateTimePicker hastaAsesor;
		private System.Windows.Forms.Label personasLabel;
		private System.Windows.Forms.NumericUpDown personas;
		private System.Windows.Forms.Label camarasLabel;
		private System.Windows.Forms.NumericUpDown camaras;
		private System.Windows.Forms.Label locacionLabel;
		private System.Windows.Forms.ComboBox locacion;
		private System.Windows.Forms.Label luzLabel;
		private System.Windows.Forms.ComboBox luz;
		private System.Windows.Forms.CheckBox movimiento;
		private System.Windows.Forms.CheckBox sonido;
		private System.Windows.Forms.CheckBox monitoreo;
		private System.Windows.Forms.CheckBox cine;
		private System.Windows.Forms.TableLayoutPanel resumenCard;
		private System.Windows.Forms.Label resumen;
		private System.Windows.Forms.TabControl tabs;
		private System.Windows.Forms.TabPage recomendadaTab;
		private System.Windows.Forms.TableLayoutPanel recomendadaTabLayout;
		private System.Windows.Forms.DataGridView propuestaRec;
		private System.Windows.Forms.DataGridViewTextBoxColumn propuestaRecRolColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn propuestaRecDetalleColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn propuestaRecGamaColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn propuestaRecSubtotalColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn propuestaRecAportaColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn propuestaRecResignaColumna;
		private System.Windows.Forms.Label notasRec;
		private System.Windows.Forms.TabPage economicaTab;
		private System.Windows.Forms.TableLayoutPanel economicaTabLayout;
		private System.Windows.Forms.DataGridView propuestaEco;
		private System.Windows.Forms.DataGridViewTextBoxColumn propuestaEcoRolColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn propuestaEcoDetalleColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn propuestaEcoGamaColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn propuestaEcoSubtotalColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn propuestaEcoAportaColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn propuestaEcoResignaColumna;
		private System.Windows.Forms.Label notasEco;
		private System.Windows.Forms.TabPage complementosTab;
		private System.Windows.Forms.TableLayoutPanel complementosTabLayout;
		private System.Windows.Forms.DataGridView complementos;
		private System.Windows.Forms.DataGridViewTextBoxColumn complementosRolColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn complementosDetalleColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn complementosGamaColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn complementosSubtotalColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn complementosAportaColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn complementosResignaColumna;
		private System.Windows.Forms.Label complementosNota;
		private System.Windows.Forms.TabPage lecturaTab;
		private System.Windows.Forms.TextBox lectura;
		private System.Windows.Forms.TabPage guardadasTab;
		private System.Windows.Forms.TableLayoutPanel guardadasTabLayout;
		private System.Windows.Forms.DataGridView guardadas;
		private System.Windows.Forms.DataGridViewTextBoxColumn guardadasNombreColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn guardadasCreadaColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn guardadasResumenColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn guardadasVarianteColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn guardadasTotalColumna;
		private System.Windows.Forms.FlowLayoutPanel guardadasAcciones;
		private System.Windows.Forms.Button abrirGuardadaBoton;
		private System.Windows.Forms.Button eliminarGuardadaBoton;
		private System.Windows.Forms.Label guardadasNota;
		private System.Windows.Forms.FlowLayoutPanel asesorAcciones;
		private System.Windows.Forms.Button usarBoton;
		private System.Windows.Forms.Button imprimirBoton;
		private System.Windows.Forms.Button actualizarAsesorBoton;
		private System.Windows.Forms.Label guardarComoLabel;
		private System.Windows.Forms.TextBox nombrePropuesta;
		private System.Windows.Forms.Button guardarPropuestaBoton;
		private System.Windows.Forms.Label usarNota;
	}
}
