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
			this.tabs = new System.Windows.Forms.TabControl();
			this.ficha = new System.Windows.Forms.TabPage();
			this.clientes = new System.Windows.Forms.DataGridView();
			this.alta = new System.Windows.Forms.FlowLayoutPanel();
			this.cuentaCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.cuentaCampoLabel = new System.Windows.Forms.Label();
			this.cuenta = new System.Windows.Forms.ComboBox();
			this.dniCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.dniCampoLabel = new System.Windows.Forms.Label();
			this.dni = new System.Windows.Forms.TextBox();
			this.nombreCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.nombreCampoLabel = new System.Windows.Forms.Label();
			this.nombre = new System.Windows.Forms.TextBox();
			this.telefonoCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.telefonoCampoLabel = new System.Windows.Forms.Label();
			this.telefono = new System.Windows.Forms.TextBox();
			this.emailCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.emailCampoLabel = new System.Windows.Forms.Label();
			this.email = new System.Windows.Forms.TextBox();
			this.antecedente = new System.Windows.Forms.CheckBox();
			this.clienteBoton = new System.Windows.Forms.Button();
			this.coberturaTab = new System.Windows.Forms.TabPage();
			this.seguros = new System.Windows.Forms.DataGridView();
			this.formulario = new System.Windows.Forms.FlowLayoutPanel();
			this.clienteCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.clienteCampoLabel = new System.Windows.Forms.Label();
			this.clienteSeguro = new System.Windows.Forms.ComboBox();
			this.polizaCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.polizaCampoLabel = new System.Windows.Forms.Label();
			this.poliza = new System.Windows.Forms.TextBox();
			this.aseguradoraCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.aseguradoraCampoLabel = new System.Windows.Forms.Label();
			this.aseguradora = new System.Windows.Forms.TextBox();
			this.desdeCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.desdeCampoLabel = new System.Windows.Forms.Label();
			this.desde = new System.Windows.Forms.DateTimePicker();
			this.hastaCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.hastaCampoLabel = new System.Windows.Forms.Label();
			this.hasta = new System.Windows.Forms.DateTimePicker();
			this.coberturaCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.coberturaCampoLabel = new System.Windows.Forms.Label();
			this.cobertura = new System.Windows.Forms.NumericUpDown();
			this.guardarSeguroBoton = new System.Windows.Forms.Button();
			this.nuevoSeguroBoton = new System.Windows.Forms.Button();
			this.seguroNota = new System.Windows.Forms.Label();
			this.tabs.SuspendLayout();
			this.ficha.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.clientes)).BeginInit();
			this.alta.SuspendLayout();
			this.cuentaCampo.SuspendLayout();
			this.dniCampo.SuspendLayout();
			this.nombreCampo.SuspendLayout();
			this.telefonoCampo.SuspendLayout();
			this.emailCampo.SuspendLayout();
			this.coberturaTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.seguros)).BeginInit();
			this.formulario.SuspendLayout();
			this.clienteCampo.SuspendLayout();
			this.polizaCampo.SuspendLayout();
			this.aseguradoraCampo.SuspendLayout();
			this.desdeCampo.SuspendLayout();
			this.hastaCampo.SuspendLayout();
			this.coberturaCampo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cobertura)).BeginInit();
			this.SuspendLayout();
			//
			// tabs
			//
			this.tabs.Controls.Add(this.ficha);
			this.tabs.Controls.Add(this.coberturaTab);
			this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabs.Location = new System.Drawing.Point(0, 0);
			this.tabs.Name = "tabs";
			this.tabs.SelectedIndex = 0;
			this.tabs.Size = new System.Drawing.Size(1030, 600);
			this.tabs.TabIndex = 0;
			//
			// ficha
			//
			this.ficha.Controls.Add(this.clientes);
			this.ficha.Controls.Add(this.alta);
			this.ficha.Location = new System.Drawing.Point(4, 26);
			this.ficha.Name = "ficha";
			this.ficha.Padding = new System.Windows.Forms.Padding(3);
			this.ficha.Size = new System.Drawing.Size(1022, 570);
			this.ficha.TabIndex = 0;
			this.ficha.Text = "Clientes";
			this.ficha.UseVisualStyleBackColor = true;
			//
			// clientes
			//
			this.clientes.AllowUserToAddRows = false;
			this.clientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.clientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.clientes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.clientes.Location = new System.Drawing.Point(3, 163);
			this.clientes.MultiSelect = false;
			this.clientes.Name = "clientes";
			this.clientes.ReadOnly = true;
			this.clientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.clientes.Size = new System.Drawing.Size(1016, 404);
			this.clientes.TabIndex = 0;
			//
			// alta
			//
			this.alta.Controls.Add(this.cuentaCampo);
			this.alta.Controls.Add(this.dniCampo);
			this.alta.Controls.Add(this.nombreCampo);
			this.alta.Controls.Add(this.telefonoCampo);
			this.alta.Controls.Add(this.emailCampo);
			this.alta.Controls.Add(this.antecedente);
			this.alta.Controls.Add(this.clienteBoton);
			this.alta.Dock = System.Windows.Forms.DockStyle.Top;
			this.alta.Location = new System.Drawing.Point(3, 3);
			this.alta.Name = "alta";
			this.alta.Padding = new System.Windows.Forms.Padding(10);
			this.alta.Size = new System.Drawing.Size(1016, 160);
			this.alta.TabIndex = 1;
			//
			// cuentaCampo
			//
			this.cuentaCampo.Controls.Add(this.cuentaCampoLabel);
			this.cuentaCampo.Controls.Add(this.cuenta);
			this.cuentaCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.cuentaCampo.Location = new System.Drawing.Point(13, 13);
			this.cuentaCampo.Name = "cuentaCampo";
			this.cuentaCampo.Size = new System.Drawing.Size(195, 66);
			this.cuentaCampo.TabIndex = 0;
			//
			// cuentaCampoLabel
			//
			this.cuentaCampoLabel.AutoSize = true;
			this.cuentaCampoLabel.Location = new System.Drawing.Point(3, 0);
			this.cuentaCampoLabel.Name = "cuentaCampoLabel";
			this.cuentaCampoLabel.Size = new System.Drawing.Size(145, 19);
			this.cuentaCampoLabel.TabIndex = 0;
			this.cuentaCampoLabel.Text = "Cuenta con rol Cliente";
			//
			// cuenta
			//
			this.cuenta.DisplayMember = "NombreUsuario";
			this.cuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cuenta.FormattingEnabled = true;
			this.cuenta.Location = new System.Drawing.Point(3, 22);
			this.cuenta.Name = "cuenta";
			this.cuenta.Size = new System.Drawing.Size(185, 25);
			this.cuenta.TabIndex = 1;
			//
			// dniCampo
			//
			this.dniCampo.Controls.Add(this.dniCampoLabel);
			this.dniCampo.Controls.Add(this.dni);
			this.dniCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.dniCampo.Location = new System.Drawing.Point(214, 13);
			this.dniCampo.Name = "dniCampo";
			this.dniCampo.Size = new System.Drawing.Size(195, 66);
			this.dniCampo.TabIndex = 1;
			//
			// dniCampoLabel
			//
			this.dniCampoLabel.AutoSize = true;
			this.dniCampoLabel.Location = new System.Drawing.Point(3, 0);
			this.dniCampoLabel.Name = "dniCampoLabel";
			this.dniCampoLabel.Size = new System.Drawing.Size(68, 19);
			this.dniCampoLabel.TabIndex = 0;
			this.dniCampoLabel.Text = "DNI/CUIT";
			//
			// dni
			//
			this.dni.Location = new System.Drawing.Point(3, 22);
			this.dni.MaxLength = 13;
			this.dni.Name = "dni";
			this.dni.Size = new System.Drawing.Size(185, 25);
			this.dni.TabIndex = 1;
			//
			// nombreCampo
			//
			this.nombreCampo.Controls.Add(this.nombreCampoLabel);
			this.nombreCampo.Controls.Add(this.nombre);
			this.nombreCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.nombreCampo.Location = new System.Drawing.Point(415, 13);
			this.nombreCampo.Name = "nombreCampo";
			this.nombreCampo.Size = new System.Drawing.Size(195, 66);
			this.nombreCampo.TabIndex = 2;
			//
			// nombreCampoLabel
			//
			this.nombreCampoLabel.AutoSize = true;
			this.nombreCampoLabel.Location = new System.Drawing.Point(3, 0);
			this.nombreCampoLabel.Name = "nombreCampoLabel";
			this.nombreCampoLabel.Size = new System.Drawing.Size(59, 19);
			this.nombreCampoLabel.TabIndex = 0;
			this.nombreCampoLabel.Text = "Nombre";
			//
			// nombre
			//
			this.nombre.Location = new System.Drawing.Point(3, 22);
			this.nombre.MaxLength = 100;
			this.nombre.Name = "nombre";
			this.nombre.Size = new System.Drawing.Size(185, 25);
			this.nombre.TabIndex = 1;
			//
			// telefonoCampo
			//
			this.telefonoCampo.Controls.Add(this.telefonoCampoLabel);
			this.telefonoCampo.Controls.Add(this.telefono);
			this.telefonoCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.telefonoCampo.Location = new System.Drawing.Point(616, 13);
			this.telefonoCampo.Name = "telefonoCampo";
			this.telefonoCampo.Size = new System.Drawing.Size(195, 66);
			this.telefonoCampo.TabIndex = 3;
			//
			// telefonoCampoLabel
			//
			this.telefonoCampoLabel.AutoSize = true;
			this.telefonoCampoLabel.Location = new System.Drawing.Point(3, 0);
			this.telefonoCampoLabel.Name = "telefonoCampoLabel";
			this.telefonoCampoLabel.Size = new System.Drawing.Size(60, 19);
			this.telefonoCampoLabel.TabIndex = 0;
			this.telefonoCampoLabel.Text = "Teléfono";
			//
			// telefono
			//
			this.telefono.Location = new System.Drawing.Point(3, 22);
			this.telefono.MaxLength = 30;
			this.telefono.Name = "telefono";
			this.telefono.Size = new System.Drawing.Size(185, 25);
			this.telefono.TabIndex = 1;
			//
			// emailCampo
			//
			this.emailCampo.Controls.Add(this.emailCampoLabel);
			this.emailCampo.Controls.Add(this.email);
			this.emailCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.emailCampo.Location = new System.Drawing.Point(13, 85);
			this.emailCampo.Name = "emailCampo";
			this.emailCampo.Size = new System.Drawing.Size(195, 66);
			this.emailCampo.TabIndex = 4;
			//
			// emailCampoLabel
			//
			this.emailCampoLabel.AutoSize = true;
			this.emailCampoLabel.Location = new System.Drawing.Point(3, 0);
			this.emailCampoLabel.Name = "emailCampoLabel";
			this.emailCampoLabel.Size = new System.Drawing.Size(51, 19);
			this.emailCampoLabel.TabIndex = 0;
			this.emailCampoLabel.Text = "Correo";
			//
			// email
			//
			this.email.Location = new System.Drawing.Point(3, 22);
			this.email.MaxLength = 150;
			this.email.Name = "email";
			this.email.Size = new System.Drawing.Size(185, 25);
			this.email.TabIndex = 1;
			//
			// antecedente
			//
			this.antecedente.AutoSize = true;
			this.antecedente.Location = new System.Drawing.Point(214, 85);
			this.antecedente.Name = "antecedente";
			this.antecedente.Size = new System.Drawing.Size(162, 23);
			this.antecedente.TabIndex = 5;
			this.antecedente.Text = "Antecedente negativo";
			//
			// clienteBoton
			//
			this.clienteBoton.AutoSize = true;
			this.clienteBoton.Location = new System.Drawing.Point(382, 85);
			this.clienteBoton.Name = "clienteBoton";
			this.clienteBoton.Size = new System.Drawing.Size(120, 36);
			this.clienteBoton.TabIndex = 6;
			this.clienteBoton.Text = "Crear cliente";
			this.clienteBoton.UseVisualStyleBackColor = true;
			this.clienteBoton.Click += new System.EventHandler(this.GuardarClienteClick);
			//
			// coberturaTab
			//
			this.coberturaTab.Controls.Add(this.seguros);
			this.coberturaTab.Controls.Add(this.formulario);
			this.coberturaTab.Location = new System.Drawing.Point(4, 26);
			this.coberturaTab.Name = "coberturaTab";
			this.coberturaTab.Padding = new System.Windows.Forms.Padding(3);
			this.coberturaTab.Size = new System.Drawing.Size(192, 70);
			this.coberturaTab.TabIndex = 1;
			this.coberturaTab.Text = "Seguros";
			this.coberturaTab.UseVisualStyleBackColor = true;
			//
			// seguros
			//
			this.seguros.AllowUserToAddRows = false;
			this.seguros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.seguros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.seguros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.seguros.Dock = System.Windows.Forms.DockStyle.Fill;
			this.seguros.Location = new System.Drawing.Point(3, 203);
			this.seguros.MultiSelect = false;
			this.seguros.Name = "seguros";
			this.seguros.ReadOnly = true;
			this.seguros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.seguros.Size = new System.Drawing.Size(186, 0);
			this.seguros.TabIndex = 0;
			this.seguros.SelectionChanged += new System.EventHandler(this.SeguroCambio);
			//
			// formulario
			//
			this.formulario.Controls.Add(this.clienteCampo);
			this.formulario.Controls.Add(this.polizaCampo);
			this.formulario.Controls.Add(this.aseguradoraCampo);
			this.formulario.Controls.Add(this.desdeCampo);
			this.formulario.Controls.Add(this.hastaCampo);
			this.formulario.Controls.Add(this.coberturaCampo);
			this.formulario.Controls.Add(this.guardarSeguroBoton);
			this.formulario.Controls.Add(this.nuevoSeguroBoton);
			this.formulario.Controls.Add(this.seguroNota);
			this.formulario.Dock = System.Windows.Forms.DockStyle.Top;
			this.formulario.Location = new System.Drawing.Point(3, 3);
			this.formulario.Name = "formulario";
			this.formulario.Padding = new System.Windows.Forms.Padding(10);
			this.formulario.Size = new System.Drawing.Size(186, 200);
			this.formulario.TabIndex = 1;
			//
			// clienteCampo
			//
			this.clienteCampo.Controls.Add(this.clienteCampoLabel);
			this.clienteCampo.Controls.Add(this.clienteSeguro);
			this.clienteCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.clienteCampo.Location = new System.Drawing.Point(13, 13);
			this.clienteCampo.Name = "clienteCampo";
			this.clienteCampo.Size = new System.Drawing.Size(195, 66);
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
			// clienteSeguro
			//
			this.clienteSeguro.DisplayMember = "Nombre";
			this.clienteSeguro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.clienteSeguro.FormattingEnabled = true;
			this.clienteSeguro.Location = new System.Drawing.Point(3, 22);
			this.clienteSeguro.Name = "clienteSeguro";
			this.clienteSeguro.Size = new System.Drawing.Size(185, 25);
			this.clienteSeguro.TabIndex = 1;
			this.clienteSeguro.SelectedIndexChanged += new System.EventHandler(this.ClienteCambio);
			//
			// polizaCampo
			//
			this.polizaCampo.Controls.Add(this.polizaCampoLabel);
			this.polizaCampo.Controls.Add(this.poliza);
			this.polizaCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.polizaCampo.Location = new System.Drawing.Point(13, 85);
			this.polizaCampo.Name = "polizaCampo";
			this.polizaCampo.Size = new System.Drawing.Size(195, 66);
			this.polizaCampo.TabIndex = 1;
			//
			// polizaCampoLabel
			//
			this.polizaCampoLabel.AutoSize = true;
			this.polizaCampoLabel.Location = new System.Drawing.Point(3, 0);
			this.polizaCampoLabel.Name = "polizaCampoLabel";
			this.polizaCampoLabel.Size = new System.Drawing.Size(43, 19);
			this.polizaCampoLabel.TabIndex = 0;
			this.polizaCampoLabel.Text = "Póliza";
			//
			// poliza
			//
			this.poliza.Location = new System.Drawing.Point(3, 22);
			this.poliza.MaxLength = 50;
			this.poliza.Name = "poliza";
			this.poliza.Size = new System.Drawing.Size(185, 25);
			this.poliza.TabIndex = 1;
			//
			// aseguradoraCampo
			//
			this.aseguradoraCampo.Controls.Add(this.aseguradoraCampoLabel);
			this.aseguradoraCampo.Controls.Add(this.aseguradora);
			this.aseguradoraCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.aseguradoraCampo.Location = new System.Drawing.Point(13, 157);
			this.aseguradoraCampo.Name = "aseguradoraCampo";
			this.aseguradoraCampo.Size = new System.Drawing.Size(195, 66);
			this.aseguradoraCampo.TabIndex = 2;
			//
			// aseguradoraCampoLabel
			//
			this.aseguradoraCampoLabel.AutoSize = true;
			this.aseguradoraCampoLabel.Location = new System.Drawing.Point(3, 0);
			this.aseguradoraCampoLabel.Name = "aseguradoraCampoLabel";
			this.aseguradoraCampoLabel.Size = new System.Drawing.Size(87, 19);
			this.aseguradoraCampoLabel.TabIndex = 0;
			this.aseguradoraCampoLabel.Text = "Aseguradora";
			//
			// aseguradora
			//
			this.aseguradora.Location = new System.Drawing.Point(3, 22);
			this.aseguradora.MaxLength = 100;
			this.aseguradora.Name = "aseguradora";
			this.aseguradora.Size = new System.Drawing.Size(185, 25);
			this.aseguradora.TabIndex = 1;
			//
			// desdeCampo
			//
			this.desdeCampo.Controls.Add(this.desdeCampoLabel);
			this.desdeCampo.Controls.Add(this.desde);
			this.desdeCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.desdeCampo.Location = new System.Drawing.Point(13, 229);
			this.desdeCampo.Name = "desdeCampo";
			this.desdeCampo.Size = new System.Drawing.Size(195, 66);
			this.desdeCampo.TabIndex = 3;
			//
			// desdeCampoLabel
			//
			this.desdeCampoLabel.AutoSize = true;
			this.desdeCampoLabel.Location = new System.Drawing.Point(3, 0);
			this.desdeCampoLabel.Name = "desdeCampoLabel";
			this.desdeCampoLabel.Size = new System.Drawing.Size(96, 19);
			this.desdeCampoLabel.TabIndex = 0;
			this.desdeCampoLabel.Text = "Vigente desde";
			//
			// desde
			//
			this.desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.desde.Location = new System.Drawing.Point(3, 22);
			this.desde.Name = "desde";
			this.desde.Size = new System.Drawing.Size(185, 25);
			this.desde.TabIndex = 1;
			//
			// hastaCampo
			//
			this.hastaCampo.Controls.Add(this.hastaCampoLabel);
			this.hastaCampo.Controls.Add(this.hasta);
			this.hastaCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.hastaCampo.Location = new System.Drawing.Point(13, 301);
			this.hastaCampo.Name = "hastaCampo";
			this.hastaCampo.Size = new System.Drawing.Size(195, 66);
			this.hastaCampo.TabIndex = 4;
			//
			// hastaCampoLabel
			//
			this.hastaCampoLabel.AutoSize = true;
			this.hastaCampoLabel.Location = new System.Drawing.Point(3, 0);
			this.hastaCampoLabel.Name = "hastaCampoLabel";
			this.hastaCampoLabel.Size = new System.Drawing.Size(93, 19);
			this.hastaCampoLabel.TabIndex = 0;
			this.hastaCampoLabel.Text = "Vigente hasta";
			//
			// hasta
			//
			this.hasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.hasta.Location = new System.Drawing.Point(3, 22);
			this.hasta.Name = "hasta";
			this.hasta.Size = new System.Drawing.Size(185, 25);
			this.hasta.TabIndex = 1;
			//
			// coberturaCampo
			//
			this.coberturaCampo.Controls.Add(this.coberturaCampoLabel);
			this.coberturaCampo.Controls.Add(this.cobertura);
			this.coberturaCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.coberturaCampo.Location = new System.Drawing.Point(13, 373);
			this.coberturaCampo.Name = "coberturaCampo";
			this.coberturaCampo.Size = new System.Drawing.Size(195, 66);
			this.coberturaCampo.TabIndex = 5;
			//
			// coberturaCampoLabel
			//
			this.coberturaCampoLabel.AutoSize = true;
			this.coberturaCampoLabel.Location = new System.Drawing.Point(3, 0);
			this.coberturaCampoLabel.Name = "coberturaCampoLabel";
			this.coberturaCampoLabel.Size = new System.Drawing.Size(170, 19);
			this.coberturaCampoLabel.TabIndex = 0;
			this.coberturaCampoLabel.Text = "Cobertura ARS por unidad";
			//
			// cobertura
			//
			this.cobertura.DecimalPlaces = 2;
			this.cobertura.Location = new System.Drawing.Point(3, 22);
			this.cobertura.Maximum = new decimal (new int[] { -727379968, 232, 0, 0 });
			this.cobertura.Name = "cobertura";
			this.cobertura.Size = new System.Drawing.Size(185, 25);
			this.cobertura.TabIndex = 1;
			this.cobertura.ThousandsSeparator = true;
			//
			// guardarSeguroBoton
			//
			this.guardarSeguroBoton.AutoSize = true;
			this.guardarSeguroBoton.Location = new System.Drawing.Point(13, 445);
			this.guardarSeguroBoton.Name = "guardarSeguroBoton";
			this.guardarSeguroBoton.Size = new System.Drawing.Size(120, 36);
			this.guardarSeguroBoton.TabIndex = 6;
			this.guardarSeguroBoton.Text = "Guardar seguro";
			this.guardarSeguroBoton.UseVisualStyleBackColor = true;
			this.guardarSeguroBoton.Click += new System.EventHandler(this.GuardarSeguroClick);
			//
			// nuevoSeguroBoton
			//
			this.nuevoSeguroBoton.AutoSize = true;
			this.nuevoSeguroBoton.Location = new System.Drawing.Point(13, 487);
			this.nuevoSeguroBoton.Name = "nuevoSeguroBoton";
			this.nuevoSeguroBoton.Size = new System.Drawing.Size(120, 36);
			this.nuevoSeguroBoton.TabIndex = 7;
			this.nuevoSeguroBoton.Text = "Nueva póliza";
			this.nuevoSeguroBoton.UseVisualStyleBackColor = true;
			this.nuevoSeguroBoton.Click += new System.EventHandler(this.NuevoSeguroClick);
			//
			// seguroNota
			//
			this.seguroNota.AutoSize = true;
			this.seguroNota.Location = new System.Drawing.Point(13, 526);
			this.seguroNota.Name = "seguroNota";
			this.seguroNota.Size = new System.Drawing.Size(159, 38);
			this.seguroNota.TabIndex = 8;
			this.seguroNota.Text = "La póliza se asigna a las unidades desde Equipos.";
			//
			// ClientesForm
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1030, 600);
			this.Controls.Add(this.tabs);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.Name = "ClientesForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Clientes y seguros";
			this.Load += new System.EventHandler(this.PrepararPantalla);
			this.Shown += new System.EventHandler(this.CargarClick);
			this.tabs.ResumeLayout(false);
			this.ficha.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.clientes)).EndInit();
			this.alta.ResumeLayout(false);
			this.alta.PerformLayout();
			this.cuentaCampo.ResumeLayout(false);
			this.cuentaCampo.PerformLayout();
			this.dniCampo.ResumeLayout(false);
			this.dniCampo.PerformLayout();
			this.nombreCampo.ResumeLayout(false);
			this.nombreCampo.PerformLayout();
			this.telefonoCampo.ResumeLayout(false);
			this.telefonoCampo.PerformLayout();
			this.emailCampo.ResumeLayout(false);
			this.emailCampo.PerformLayout();
			this.coberturaTab.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.seguros)).EndInit();
			this.formulario.ResumeLayout(false);
			this.formulario.PerformLayout();
			this.clienteCampo.ResumeLayout(false);
			this.clienteCampo.PerformLayout();
			this.polizaCampo.ResumeLayout(false);
			this.polizaCampo.PerformLayout();
			this.aseguradoraCampo.ResumeLayout(false);
			this.aseguradoraCampo.PerformLayout();
			this.desdeCampo.ResumeLayout(false);
			this.desdeCampo.PerformLayout();
			this.hastaCampo.ResumeLayout(false);
			this.hastaCampo.PerformLayout();
			this.coberturaCampo.ResumeLayout(false);
			this.coberturaCampo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cobertura)).EndInit();
			this.ResumeLayout(false);
		}

#endregion
		private System.Windows.Forms.TabControl tabs;
		private System.Windows.Forms.TabPage ficha;
		private System.Windows.Forms.TabPage coberturaTab;
		private System.Windows.Forms.FlowLayoutPanel alta;
		private System.Windows.Forms.ComboBox cuenta;
		private System.Windows.Forms.TextBox dni;
		private System.Windows.Forms.TextBox nombre;
		private System.Windows.Forms.TextBox telefono;
		private System.Windows.Forms.TextBox email;
		private System.Windows.Forms.TextBox poliza;
		private System.Windows.Forms.TextBox aseguradora;
		private System.Windows.Forms.FlowLayoutPanel cuentaCampo;
		private System.Windows.Forms.Label cuentaCampoLabel;
		private System.Windows.Forms.FlowLayoutPanel dniCampo;
		private System.Windows.Forms.Label dniCampoLabel;
		private System.Windows.Forms.FlowLayoutPanel nombreCampo;
		private System.Windows.Forms.Label nombreCampoLabel;
		private System.Windows.Forms.FlowLayoutPanel telefonoCampo;
		private System.Windows.Forms.Label telefonoCampoLabel;
		private System.Windows.Forms.FlowLayoutPanel emailCampo;
		private System.Windows.Forms.Label emailCampoLabel;
		private System.Windows.Forms.CheckBox antecedente;
		private System.Windows.Forms.Button clienteBoton;
		private System.Windows.Forms.DataGridView clientes;
		private System.Windows.Forms.DataGridViewTextBoxColumn clientesIdColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn clientesUsuarioIdColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn clientesDniCuitColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn clientesNombreColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn clientesTelefonoColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn clientesEmailColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn clientesAntecedenteNegativoColumna;
		private System.Windows.Forms.FlowLayoutPanel formulario;
		private System.Windows.Forms.ComboBox clienteSeguro;
		private System.Windows.Forms.DateTimePicker desde;
		private System.Windows.Forms.DateTimePicker hasta;
		private System.Windows.Forms.NumericUpDown cobertura;
		private System.Windows.Forms.FlowLayoutPanel clienteCampo;
		private System.Windows.Forms.Label clienteCampoLabel;
		private System.Windows.Forms.FlowLayoutPanel polizaCampo;
		private System.Windows.Forms.Label polizaCampoLabel;
		private System.Windows.Forms.FlowLayoutPanel aseguradoraCampo;
		private System.Windows.Forms.Label aseguradoraCampoLabel;
		private System.Windows.Forms.FlowLayoutPanel desdeCampo;
		private System.Windows.Forms.Label desdeCampoLabel;
		private System.Windows.Forms.FlowLayoutPanel hastaCampo;
		private System.Windows.Forms.Label hastaCampoLabel;
		private System.Windows.Forms.FlowLayoutPanel coberturaCampo;
		private System.Windows.Forms.Label coberturaCampoLabel;
		private System.Windows.Forms.Button guardarSeguroBoton;
		private System.Windows.Forms.Button nuevoSeguroBoton;
		private System.Windows.Forms.Label seguroNota;
		private System.Windows.Forms.DataGridView seguros;
		private System.Windows.Forms.DataGridViewTextBoxColumn segurosIdColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn segurosPolizaColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn segurosAseguradoraColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn segurosDesdeColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn segurosHastaColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn segurosCoberturaColumna;
	}
}
