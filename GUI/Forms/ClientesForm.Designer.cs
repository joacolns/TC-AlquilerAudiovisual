namespace GUI
{
	partial class ClientesForm
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
			this.ficha = new System.Windows.Forms.TabPage();
			this.fichaLayout = new System.Windows.Forms.TableLayoutPanel();
			this.alta = new System.Windows.Forms.TableLayoutPanel();
			this.altaAcciones = new System.Windows.Forms.FlowLayoutPanel();
			this.actualizarClientesBoton = new System.Windows.Forms.Button();
			this.eliminarAntecedentesBoton = new System.Windows.Forms.Button();
			this.clientes = new System.Windows.Forms.DataGridView();
			this.clientesIdColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clientesDniCuitColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clientesNombreColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clientesTelefonoColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clientesEmailColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clientesAntecedentesColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.coberturaTab = new System.Windows.Forms.TabPage();
			this.coberturaTabLayout = new System.Windows.Forms.TableLayoutPanel();
			this.formulario = new System.Windows.Forms.TableLayoutPanel();
			this.clienteSeguroLabel = new System.Windows.Forms.Label();
			this.clienteSeguro = new System.Windows.Forms.ComboBox();
			this.tipoSeguroLabel = new System.Windows.Forms.Label();
			this.tipoSeguro = new System.Windows.Forms.ComboBox();
			this.coberturaLabel = new System.Windows.Forms.Label();
			this.cobertura = new System.Windows.Forms.NumericUpDown();
			this.polizaLabel = new System.Windows.Forms.Label();
			this.poliza = new System.Windows.Forms.TextBox();
			this.aseguradoraLabel = new System.Windows.Forms.Label();
			this.aseguradora = new System.Windows.Forms.TextBox();
			this.desdeLabel = new System.Windows.Forms.Label();
			this.desde = new System.Windows.Forms.DateTimePicker();
			this.hastaLabel = new System.Windows.Forms.Label();
			this.hasta = new System.Windows.Forms.DateTimePicker();
			this.detalleSeguroLabel = new System.Windows.Forms.Label();
			this.detalleSeguro = new System.Windows.Forms.TextBox();
			this.seguroAcciones = new System.Windows.Forms.FlowLayoutPanel();
			this.guardarSeguroBoton = new System.Windows.Forms.Button();
			this.nuevoSeguroBoton = new System.Windows.Forms.Button();
			this.seguroNota = new System.Windows.Forms.Label();
			this.seguros = new System.Windows.Forms.DataGridView();
			this.segurosTipoColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.segurosPolizaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.segurosAseguradoraColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.segurosDesdeColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.segurosHastaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.segurosCoberturaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.segurosDetalleColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.SuspendLayout();
			this.tabs.SuspendLayout();
			this.ficha.SuspendLayout();
			this.fichaLayout.SuspendLayout();
			this.alta.SuspendLayout();
			this.altaAcciones.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.clientes)).BeginInit();
			this.coberturaTab.SuspendLayout();
			this.coberturaTabLayout.SuspendLayout();
			this.formulario.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cobertura)).BeginInit();
			this.seguroAcciones.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.seguros)).BeginInit();
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
			// ClientesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.ClientSize = new System.Drawing.Size(870, 640);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Controls.Add(this.tabs);
			this.Load += new System.EventHandler(this.ClientesForm_Load);
			// 
			// tabs
			// 
			this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabs.SelectedIndex = 0;
			this.tabs.ItemSize = new System.Drawing.Size(0, 34);
			this.tabs.Padding = new System.Drawing.Point(20, 6);
			this.tabs.TabIndex = 0;
			this.tabs.Name = "tabs";
			this.tabs.Controls.Add(this.ficha);
			this.tabs.Controls.Add(this.coberturaTab);
			// 
			// ficha
			// 
			this.ficha.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.ficha.Padding = new System.Windows.Forms.Padding(16, 16, 16, 16);
			this.ficha.Text = "Antecedentes";
			this.ficha.UseVisualStyleBackColor = false;
			this.ficha.TabIndex = 0;
			this.ficha.Name = "ficha";
			this.ficha.Controls.Add(this.fichaLayout);
			// 
			// fichaLayout
			// 
			this.fichaLayout.ColumnCount = 1;
			this.fichaLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.fichaLayout.RowCount = 2;
			this.fichaLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.fichaLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.fichaLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.fichaLayout.BackColor = System.Drawing.Color.Transparent;
			this.fichaLayout.TabIndex = 0;
			this.fichaLayout.Name = "fichaLayout";
			this.fichaLayout.Controls.Add(this.alta, 0, 0);
			this.fichaLayout.Controls.Add(this.clientes, 0, 1);
			// 
			// alta
			// 
			this.alta.ColumnCount = 1;
			this.alta.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.alta.RowCount = 1;
			this.alta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.alta.AutoSize = true;
			this.alta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.alta.BackColor = System.Drawing.Color.White;
			this.alta.Dock = System.Windows.Forms.DockStyle.Fill;
			this.alta.Padding = new System.Windows.Forms.Padding(18, 14, 18, 14);
			this.alta.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
			this.alta.TabIndex = 0;
			this.alta.Name = "alta";
			this.alta.Controls.Add(this.altaAcciones, 0, 0);
			// 
			// altaAcciones
			// 
			this.altaAcciones.AutoSize = true;
			this.altaAcciones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.altaAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
			this.altaAcciones.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.altaAcciones.TabIndex = 0;
			this.altaAcciones.Name = "altaAcciones";
			this.altaAcciones.Controls.Add(this.actualizarClientesBoton);
			this.altaAcciones.Controls.Add(this.eliminarAntecedentesBoton);
			// 
			// actualizarClientesBoton
			// 
			this.actualizarClientesBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.actualizarClientesBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.actualizarClientesBoton.Size = new System.Drawing.Size(170, 38);
			this.actualizarClientesBoton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.actualizarClientesBoton.Text = "Actualizar";
			this.actualizarClientesBoton.UseVisualStyleBackColor = false;
			this.actualizarClientesBoton.BackColor = System.Drawing.Color.White;
			this.actualizarClientesBoton.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.actualizarClientesBoton.FlatAppearance.BorderSize = 1;
			this.actualizarClientesBoton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
			this.actualizarClientesBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.actualizarClientesBoton.TabIndex = 0;
			this.actualizarClientesBoton.Name = "actualizarClientesBoton";
			this.actualizarClientesBoton.Click += new System.EventHandler(this.ActualizarClientesClick);
			// 
			// eliminarAntecedentesBoton
			// 
			this.eliminarAntecedentesBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.eliminarAntecedentesBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.eliminarAntecedentesBoton.Size = new System.Drawing.Size(190, 38);
			this.eliminarAntecedentesBoton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.eliminarAntecedentesBoton.Text = "Eliminar antecedentes";
			this.eliminarAntecedentesBoton.UseVisualStyleBackColor = false;
			this.eliminarAntecedentesBoton.BackColor = System.Drawing.Color.White;
			this.eliminarAntecedentesBoton.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.eliminarAntecedentesBoton.FlatAppearance.BorderSize = 1;
			this.eliminarAntecedentesBoton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
			this.eliminarAntecedentesBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.eliminarAntecedentesBoton.Enabled = false;
			this.eliminarAntecedentesBoton.TabIndex = 1;
			this.eliminarAntecedentesBoton.Name = "eliminarAntecedentesBoton";
			this.eliminarAntecedentesBoton.Click += new System.EventHandler(this.EliminarAntecedentesClick);
			// 
			// clientes
			// 
			this.clientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
				this.clientesIdColumna,
	this.clientesDniCuitColumna,
	this.clientesNombreColumna,
	this.clientesTelefonoColumna,
	this.clientesEmailColumna,
	this.clientesAntecedentesColumna});
			this.clientes.AllowUserToAddRows = false;
			this.clientes.AllowUserToDeleteRows = false;
			this.clientes.AllowUserToResizeRows = false;
			this.clientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.clientes.BackgroundColor = System.Drawing.Color.White;
			this.clientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.clientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.clientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.clientes.ColumnHeadersHeight = 38;
			this.clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.clientes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.clientes.EnableHeadersVisualStyles = false;
			this.clientes.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
			this.clientes.MultiSelect = false;
			this.clientes.ReadOnly = true;
			this.clientes.RowHeadersVisible = false;
			this.clientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.clientes.RowTemplate.Height = 34;
			this.clientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.clientes.DefaultCellStyle = dataGridViewCellStyle2;
			this.clientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.clientes.AutoGenerateColumns = false;
			this.clientes.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
			this.clientes.TabIndex = 1;
			this.clientes.Name = "clientes";
			this.clientes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.FormatearAntecedentes);
			this.clientes.SelectionChanged += new System.EventHandler(this.SeleccionarCliente);
			// 
			// clientesIdColumna
			// 
			this.clientesIdColumna.HeaderText = "N°";
			this.clientesIdColumna.MinimumWidth = 50;
			this.clientesIdColumna.Name = "clientesIdColumna";
			this.clientesIdColumna.ReadOnly = true;
			this.clientesIdColumna.DataPropertyName = "Id";
			// 
			// clientesDniCuitColumna
			// 
			this.clientesDniCuitColumna.HeaderText = "DNI / CUIT";
			this.clientesDniCuitColumna.MinimumWidth = 110;
			this.clientesDniCuitColumna.Name = "clientesDniCuitColumna";
			this.clientesDniCuitColumna.ReadOnly = true;
			this.clientesDniCuitColumna.DataPropertyName = "DniCuit";
			// 
			// clientesNombreColumna
			// 
			this.clientesNombreColumna.HeaderText = "Nombre";
			this.clientesNombreColumna.MinimumWidth = 140;
			this.clientesNombreColumna.Name = "clientesNombreColumna";
			this.clientesNombreColumna.ReadOnly = true;
			this.clientesNombreColumna.DataPropertyName = "Nombre";
			// 
			// clientesTelefonoColumna
			// 
			this.clientesTelefonoColumna.HeaderText = "Teléfono";
			this.clientesTelefonoColumna.MinimumWidth = 110;
			this.clientesTelefonoColumna.Name = "clientesTelefonoColumna";
			this.clientesTelefonoColumna.ReadOnly = true;
			this.clientesTelefonoColumna.DataPropertyName = "Telefono";
			// 
			// clientesEmailColumna
			// 
			this.clientesEmailColumna.HeaderText = "Correo";
			this.clientesEmailColumna.MinimumWidth = 160;
			this.clientesEmailColumna.Name = "clientesEmailColumna";
			this.clientesEmailColumna.ReadOnly = true;
			this.clientesEmailColumna.DataPropertyName = "Email";
			// 
			// clientesAntecedentesColumna
			// 
			this.clientesAntecedentesColumna.HeaderText = "Antecedentes (historial de incidentes)";
			this.clientesAntecedentesColumna.MinimumWidth = 220;
			this.clientesAntecedentesColumna.Name = "clientesAntecedentesColumna";
			this.clientesAntecedentesColumna.ReadOnly = true;
			this.clientesAntecedentesColumna.DataPropertyName = "Antecedentes";
			this.clientesAntecedentesColumna.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// coberturaTab
			// 
			this.coberturaTab.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.coberturaTab.Padding = new System.Windows.Forms.Padding(16, 16, 16, 16);
			this.coberturaTab.Text = "Seguros";
			this.coberturaTab.UseVisualStyleBackColor = false;
			this.coberturaTab.TabIndex = 1;
			this.coberturaTab.Name = "coberturaTab";
			this.coberturaTab.Controls.Add(this.coberturaTabLayout);
			// 
			// coberturaTabLayout
			// 
			this.coberturaTabLayout.ColumnCount = 1;
			this.coberturaTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.coberturaTabLayout.RowCount = 2;
			this.coberturaTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.coberturaTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.coberturaTabLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.coberturaTabLayout.BackColor = System.Drawing.Color.Transparent;
			this.coberturaTabLayout.TabIndex = 0;
			this.coberturaTabLayout.Name = "coberturaTabLayout";
			this.coberturaTabLayout.Controls.Add(this.formulario, 0, 0);
			this.coberturaTabLayout.Controls.Add(this.seguros, 0, 1);
			// 
			// formulario
			// 
			this.formulario.ColumnCount = 4;
			this.formulario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.formulario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.formulario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.formulario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.formulario.RowCount = 8;
			this.formulario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.formulario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.formulario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.formulario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.formulario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.formulario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.formulario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.formulario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
			this.formulario.AutoSize = true;
			this.formulario.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.formulario.BackColor = System.Drawing.Color.White;
			this.formulario.Dock = System.Windows.Forms.DockStyle.Fill;
			this.formulario.Padding = new System.Windows.Forms.Padding(18, 18, 18, 8);
			this.formulario.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
			this.formulario.TabIndex = 0;
			this.formulario.Name = "formulario";
			this.formulario.Controls.Add(this.clienteSeguroLabel, 0, 0);
			this.formulario.SetColumnSpan(this.clienteSeguroLabel, 2);
			this.formulario.Controls.Add(this.clienteSeguro, 0, 1);
			this.formulario.SetColumnSpan(this.clienteSeguro, 2);
			this.formulario.Controls.Add(this.tipoSeguroLabel, 2, 0);
			this.formulario.Controls.Add(this.tipoSeguro, 2, 1);
			this.formulario.Controls.Add(this.coberturaLabel, 3, 0);
			this.formulario.Controls.Add(this.cobertura, 3, 1);
			this.formulario.Controls.Add(this.polizaLabel, 0, 2);
			this.formulario.Controls.Add(this.poliza, 0, 3);
			this.formulario.Controls.Add(this.aseguradoraLabel, 1, 2);
			this.formulario.Controls.Add(this.aseguradora, 1, 3);
			this.formulario.Controls.Add(this.desdeLabel, 2, 2);
			this.formulario.Controls.Add(this.desde, 2, 3);
			this.formulario.Controls.Add(this.hastaLabel, 3, 2);
			this.formulario.Controls.Add(this.hasta, 3, 3);
			this.formulario.Controls.Add(this.detalleSeguroLabel, 0, 4);
			this.formulario.SetColumnSpan(this.detalleSeguroLabel, 4);
			this.formulario.Controls.Add(this.detalleSeguro, 0, 5);
			this.formulario.SetColumnSpan(this.detalleSeguro, 4);
			this.formulario.Controls.Add(this.seguroAcciones, 0, 6);
			this.formulario.SetColumnSpan(this.seguroAcciones, 4);
			this.formulario.Controls.Add(this.seguroNota, 0, 7);
			this.formulario.SetColumnSpan(this.seguroNota, 4);
			// 
			// clienteSeguroLabel
			// 
			this.clienteSeguroLabel.AutoSize = true;
			this.clienteSeguroLabel.Text = "Cliente";
			this.clienteSeguroLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.clienteSeguroLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.clienteSeguroLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.clienteSeguroLabel.TabIndex = 0;
			this.clienteSeguroLabel.Name = "clienteSeguroLabel";
			// 
			// clienteSeguro
			// 
			this.clienteSeguro.Dock = System.Windows.Forms.DockStyle.Fill;
			this.clienteSeguro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.clienteSeguro.FormattingEnabled = true;
			this.clienteSeguro.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.clienteSeguro.DisplayMember = "Nombre";
			this.clienteSeguro.TabIndex = 1;
			this.clienteSeguro.Name = "clienteSeguro";
			this.clienteSeguro.SelectedIndexChanged += new System.EventHandler(this.ClienteCambio);
			// 
			// tipoSeguroLabel
			// 
			this.tipoSeguroLabel.AutoSize = true;
			this.tipoSeguroLabel.Text = "Tipo de seguro";
			this.tipoSeguroLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.tipoSeguroLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.tipoSeguroLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.tipoSeguroLabel.TabIndex = 2;
			this.tipoSeguroLabel.Name = "tipoSeguroLabel";
			// 
			// tipoSeguro
			// 
			this.tipoSeguro.Items.AddRange(new object[] {
				"Basico",
	"Intermedio",
	"Completo"});
			this.tipoSeguro.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tipoSeguro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tipoSeguro.FormattingEnabled = true;
			this.tipoSeguro.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.tipoSeguro.TabIndex = 3;
			this.tipoSeguro.Name = "tipoSeguro";
			this.tipoSeguro.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.FormatearTipoSeguro);
			// 
			// coberturaLabel
			// 
			this.coberturaLabel.AutoSize = true;
			this.coberturaLabel.Text = "Tope ARS por unidad";
			this.coberturaLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.coberturaLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.coberturaLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.coberturaLabel.TabIndex = 4;
			this.coberturaLabel.Name = "coberturaLabel";
			// 
			// cobertura
			// 
			this.cobertura.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cobertura.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.cobertura.DecimalPlaces = 2;
			this.cobertura.Maximum = new decimal(new int[] { -727379968, 232, 0, 0 });
			this.cobertura.ThousandsSeparator = true;
			this.cobertura.TabIndex = 5;
			this.cobertura.Name = "cobertura";
			// 
			// polizaLabel
			// 
			this.polizaLabel.AutoSize = true;
			this.polizaLabel.Text = "Póliza";
			this.polizaLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.polizaLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.polizaLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.polizaLabel.TabIndex = 6;
			this.polizaLabel.Name = "polizaLabel";
			// 
			// poliza
			// 
			this.poliza.Dock = System.Windows.Forms.DockStyle.Fill;
			this.poliza.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.poliza.MaxLength = 50;
			this.poliza.TabIndex = 7;
			this.poliza.Name = "poliza";
			// 
			// aseguradoraLabel
			// 
			this.aseguradoraLabel.AutoSize = true;
			this.aseguradoraLabel.Text = "Aseguradora";
			this.aseguradoraLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.aseguradoraLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.aseguradoraLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.aseguradoraLabel.TabIndex = 8;
			this.aseguradoraLabel.Name = "aseguradoraLabel";
			// 
			// aseguradora
			// 
			this.aseguradora.Dock = System.Windows.Forms.DockStyle.Fill;
			this.aseguradora.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.aseguradora.MaxLength = 100;
			this.aseguradora.TabIndex = 9;
			this.aseguradora.Name = "aseguradora";
			// 
			// desdeLabel
			// 
			this.desdeLabel.AutoSize = true;
			this.desdeLabel.Text = "Vigente desde";
			this.desdeLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.desdeLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.desdeLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.desdeLabel.TabIndex = 10;
			this.desdeLabel.Name = "desdeLabel";
			// 
			// desde
			// 
			this.desde.Dock = System.Windows.Forms.DockStyle.Fill;
			this.desde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.desde.CustomFormat = "dd/MM/yyyy";
			this.desde.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.desde.TabIndex = 11;
			this.desde.Name = "desde";
			// 
			// hastaLabel
			// 
			this.hastaLabel.AutoSize = true;
			this.hastaLabel.Text = "Vigente hasta";
			this.hastaLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.hastaLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.hastaLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.hastaLabel.TabIndex = 12;
			this.hastaLabel.Name = "hastaLabel";
			// 
			// hasta
			// 
			this.hasta.Dock = System.Windows.Forms.DockStyle.Fill;
			this.hasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.hasta.CustomFormat = "dd/MM/yyyy";
			this.hasta.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.hasta.TabIndex = 13;
			this.hasta.Name = "hasta";
			// 
			// detalleSeguroLabel
			// 
			this.detalleSeguroLabel.AutoSize = true;
			this.detalleSeguroLabel.Text = "Detalle de la póliza (obligatorio)";
			this.detalleSeguroLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.detalleSeguroLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.detalleSeguroLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.detalleSeguroLabel.TabIndex = 14;
			this.detalleSeguroLabel.Name = "detalleSeguroLabel";
			// 
			// detalleSeguro
			// 
			this.detalleSeguro.Dock = System.Windows.Forms.DockStyle.Fill;
			this.detalleSeguro.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.detalleSeguro.Multiline = true;
			this.detalleSeguro.MaxLength = 500;
			this.detalleSeguro.MinimumSize = new System.Drawing.Size(0, 56);
			this.detalleSeguro.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.detalleSeguro.TabIndex = 15;
			this.detalleSeguro.Name = "detalleSeguro";
			// 
			// seguroAcciones
			// 
			this.seguroAcciones.AutoSize = true;
			this.seguroAcciones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.seguroAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
			this.seguroAcciones.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.seguroAcciones.TabIndex = 16;
			this.seguroAcciones.Name = "seguroAcciones";
			this.seguroAcciones.Controls.Add(this.guardarSeguroBoton);
			this.seguroAcciones.Controls.Add(this.nuevoSeguroBoton);
			// 
			// guardarSeguroBoton
			// 
			this.guardarSeguroBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.guardarSeguroBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.guardarSeguroBoton.Size = new System.Drawing.Size(170, 38);
			this.guardarSeguroBoton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.guardarSeguroBoton.Text = "Crear seguro";
			this.guardarSeguroBoton.UseVisualStyleBackColor = false;
			this.guardarSeguroBoton.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
			this.guardarSeguroBoton.ForeColor = System.Drawing.Color.White;
			this.guardarSeguroBoton.FlatAppearance.BorderSize = 0;
			this.guardarSeguroBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(29, 78, 216);
			this.guardarSeguroBoton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.guardarSeguroBoton.TabIndex = 0;
			this.guardarSeguroBoton.Name = "guardarSeguroBoton";
			this.guardarSeguroBoton.Click += new System.EventHandler(this.GuardarSeguroClick);
			// 
			// nuevoSeguroBoton
			// 
			this.nuevoSeguroBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.nuevoSeguroBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.nuevoSeguroBoton.Size = new System.Drawing.Size(170, 38);
			this.nuevoSeguroBoton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.nuevoSeguroBoton.Text = "Nueva póliza";
			this.nuevoSeguroBoton.UseVisualStyleBackColor = false;
			this.nuevoSeguroBoton.BackColor = System.Drawing.Color.White;
			this.nuevoSeguroBoton.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.nuevoSeguroBoton.FlatAppearance.BorderSize = 1;
			this.nuevoSeguroBoton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
			this.nuevoSeguroBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.nuevoSeguroBoton.TabIndex = 1;
			this.nuevoSeguroBoton.Name = "nuevoSeguroBoton";
			this.nuevoSeguroBoton.Click += new System.EventHandler(this.NuevoSeguroClick);
			// 
			// seguroNota
			// 
			this.seguroNota.Text = "";
			this.seguroNota.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
			this.seguroNota.AutoSize = false;
			this.seguroNota.Dock = System.Windows.Forms.DockStyle.Fill;
			this.seguroNota.Size = new System.Drawing.Size(0, 44);
			this.seguroNota.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
			this.seguroNota.TabIndex = 17;
			this.seguroNota.Name = "seguroNota";
			// 
			// seguros
			// 
			this.seguros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
				this.segurosTipoColumna,
	this.segurosPolizaColumna,
	this.segurosAseguradoraColumna,
	this.segurosDesdeColumna,
	this.segurosHastaColumna,
	this.segurosCoberturaColumna,
	this.segurosDetalleColumna});
			this.seguros.AllowUserToAddRows = false;
			this.seguros.AllowUserToDeleteRows = false;
			this.seguros.AllowUserToResizeRows = false;
			this.seguros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.seguros.BackgroundColor = System.Drawing.Color.White;
			this.seguros.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.seguros.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.seguros.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.seguros.ColumnHeadersHeight = 38;
			this.seguros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.seguros.Dock = System.Windows.Forms.DockStyle.Fill;
			this.seguros.EnableHeadersVisualStyles = false;
			this.seguros.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
			this.seguros.MultiSelect = false;
			this.seguros.ReadOnly = true;
			this.seguros.RowHeadersVisible = false;
			this.seguros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.seguros.RowTemplate.Height = 34;
			this.seguros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.seguros.DefaultCellStyle = dataGridViewCellStyle5;
			this.seguros.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
			this.seguros.AutoGenerateColumns = false;
			this.seguros.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
			this.seguros.TabIndex = 1;
			this.seguros.Name = "seguros";
			this.seguros.SelectionChanged += new System.EventHandler(this.SeguroCambio);
			this.seguros.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.FormatearSeguro);
			// 
			// segurosTipoColumna
			// 
			this.segurosTipoColumna.HeaderText = "Tipo";
			this.segurosTipoColumna.MinimumWidth = 90;
			this.segurosTipoColumna.Name = "segurosTipoColumna";
			this.segurosTipoColumna.ReadOnly = true;
			this.segurosTipoColumna.DataPropertyName = "Tipo";
			// 
			// segurosPolizaColumna
			// 
			this.segurosPolizaColumna.HeaderText = "Póliza";
			this.segurosPolizaColumna.MinimumWidth = 100;
			this.segurosPolizaColumna.Name = "segurosPolizaColumna";
			this.segurosPolizaColumna.ReadOnly = true;
			this.segurosPolizaColumna.DataPropertyName = "Poliza";
			// 
			// segurosAseguradoraColumna
			// 
			this.segurosAseguradoraColumna.HeaderText = "Aseguradora";
			this.segurosAseguradoraColumna.MinimumWidth = 120;
			this.segurosAseguradoraColumna.Name = "segurosAseguradoraColumna";
			this.segurosAseguradoraColumna.ReadOnly = true;
			this.segurosAseguradoraColumna.DataPropertyName = "Aseguradora";
			// 
			// segurosDesdeColumna
			// 
			this.segurosDesdeColumna.HeaderText = "Vigente desde";
			this.segurosDesdeColumna.MinimumWidth = 100;
			this.segurosDesdeColumna.Name = "segurosDesdeColumna";
			this.segurosDesdeColumna.ReadOnly = true;
			this.segurosDesdeColumna.DataPropertyName = "Desde";
			this.segurosDesdeColumna.DefaultCellStyle.Format = "dd/MM/yyyy";
			// 
			// segurosHastaColumna
			// 
			this.segurosHastaColumna.HeaderText = "Vigente hasta";
			this.segurosHastaColumna.MinimumWidth = 100;
			this.segurosHastaColumna.Name = "segurosHastaColumna";
			this.segurosHastaColumna.ReadOnly = true;
			this.segurosHastaColumna.DataPropertyName = "Hasta";
			this.segurosHastaColumna.DefaultCellStyle.Format = "dd/MM/yyyy";
			// 
			// segurosCoberturaColumna
			// 
			this.segurosCoberturaColumna.HeaderText = "Tope ARS por unidad";
			this.segurosCoberturaColumna.MinimumWidth = 120;
			this.segurosCoberturaColumna.Name = "segurosCoberturaColumna";
			this.segurosCoberturaColumna.ReadOnly = true;
			this.segurosCoberturaColumna.DataPropertyName = "Cobertura";
			this.segurosCoberturaColumna.DefaultCellStyle.Format = "N2";
			// 
			// segurosDetalleColumna
			// 
			this.segurosDetalleColumna.HeaderText = "Detalle";
			this.segurosDetalleColumna.MinimumWidth = 180;
			this.segurosDetalleColumna.Name = "segurosDetalleColumna";
			this.segurosDetalleColumna.ReadOnly = true;
			this.segurosDetalleColumna.DataPropertyName = "Detalle";
			((System.ComponentModel.ISupportInitialize)(this.seguros)).EndInit();
			this.seguroAcciones.ResumeLayout(false);
			this.seguroAcciones.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cobertura)).EndInit();
			this.formulario.ResumeLayout(false);
			this.formulario.PerformLayout();
			this.coberturaTabLayout.ResumeLayout(false);
			this.coberturaTabLayout.PerformLayout();
			this.coberturaTab.ResumeLayout(false);
			this.coberturaTab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.clientes)).EndInit();
			this.altaAcciones.ResumeLayout(false);
			this.altaAcciones.PerformLayout();
			this.alta.ResumeLayout(false);
			this.alta.PerformLayout();
			this.fichaLayout.ResumeLayout(false);
			this.fichaLayout.PerformLayout();
			this.ficha.ResumeLayout(false);
			this.ficha.PerformLayout();
			this.tabs.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
#endregion

		private System.Windows.Forms.TabControl tabs;
		private System.Windows.Forms.TabPage ficha;
		private System.Windows.Forms.TableLayoutPanel fichaLayout;
		private System.Windows.Forms.TableLayoutPanel alta;
		private System.Windows.Forms.FlowLayoutPanel altaAcciones;
		private System.Windows.Forms.Button actualizarClientesBoton;
		private System.Windows.Forms.Button eliminarAntecedentesBoton;
		private System.Windows.Forms.DataGridView clientes;
		private System.Windows.Forms.DataGridViewTextBoxColumn clientesIdColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn clientesDniCuitColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn clientesNombreColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn clientesTelefonoColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn clientesEmailColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn clientesAntecedentesColumna;
		private System.Windows.Forms.TabPage coberturaTab;
		private System.Windows.Forms.TableLayoutPanel coberturaTabLayout;
		private System.Windows.Forms.TableLayoutPanel formulario;
		private System.Windows.Forms.Label clienteSeguroLabel;
		private System.Windows.Forms.ComboBox clienteSeguro;
		private System.Windows.Forms.Label tipoSeguroLabel;
		private System.Windows.Forms.ComboBox tipoSeguro;
		private System.Windows.Forms.Label coberturaLabel;
		private System.Windows.Forms.NumericUpDown cobertura;
		private System.Windows.Forms.Label polizaLabel;
		private System.Windows.Forms.TextBox poliza;
		private System.Windows.Forms.Label aseguradoraLabel;
		private System.Windows.Forms.TextBox aseguradora;
		private System.Windows.Forms.Label desdeLabel;
		private System.Windows.Forms.DateTimePicker desde;
		private System.Windows.Forms.Label hastaLabel;
		private System.Windows.Forms.DateTimePicker hasta;
		private System.Windows.Forms.Label detalleSeguroLabel;
		private System.Windows.Forms.TextBox detalleSeguro;
		private System.Windows.Forms.FlowLayoutPanel seguroAcciones;
		private System.Windows.Forms.Button guardarSeguroBoton;
		private System.Windows.Forms.Button nuevoSeguroBoton;
		private System.Windows.Forms.Label seguroNota;
		private System.Windows.Forms.DataGridView seguros;
		private System.Windows.Forms.DataGridViewTextBoxColumn segurosTipoColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn segurosPolizaColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn segurosAseguradoraColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn segurosDesdeColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn segurosHastaColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn segurosCoberturaColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn segurosDetalleColumna;
	}
}
