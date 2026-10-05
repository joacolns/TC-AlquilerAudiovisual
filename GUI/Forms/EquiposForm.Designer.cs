namespace GUI
{
	partial class EquiposForm
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
			this.filtro = new System.Windows.Forms.FlowLayoutPanel();
			this.desdeCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.desdeCampoLabel = new System.Windows.Forms.Label();
			this.desde = new System.Windows.Forms.DateTimePicker();
			this.hastaCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.hastaCampoLabel = new System.Windows.Forms.Label();
			this.hasta = new System.Windows.Forms.DateTimePicker();
			this.disponiblesBoton = new System.Windows.Forms.Button();
			this.catalogoBoton = new System.Windows.Forms.Button();
			this.mantenimiento = new System.Windows.Forms.FlowLayoutPanel();
			this.codigoCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.codigoCampoLabel = new System.Windows.Forms.Label();
			this.codigo = new System.Windows.Forms.TextBox();
			this.serieCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.serieCampoLabel = new System.Windows.Forms.Label();
			this.serie = new System.Windows.Forms.TextBox();
			this.categoriaCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.categoriaCampoLabel = new System.Windows.Forms.Label();
			this.categoria = new System.Windows.Forms.TextBox();
			this.marcaCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.marcaCampoLabel = new System.Windows.Forms.Label();
			this.marca = new System.Windows.Forms.TextBox();
			this.modeloCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.modeloCampoLabel = new System.Windows.Forms.Label();
			this.modelo = new System.Windows.Forms.TextBox();
			this.descripcionCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.descripcionCampoLabel = new System.Windows.Forms.Label();
			this.descripcion = new System.Windows.Forms.TextBox();
			this.tarifaCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.tarifaCampoLabel = new System.Windows.Forms.Label();
			this.tarifa = new System.Windows.Forms.NumericUpDown();
			this.reposicionCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.reposicionCampoLabel = new System.Windows.Forms.Label();
			this.reposicion = new System.Windows.Forms.NumericUpDown();
			this.diasCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.diasCampoLabel = new System.Windows.Forms.Label();
			this.dias = new System.Windows.Forms.NumericUpDown();
			this.estadoCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.estadoCampoLabel = new System.Windows.Forms.Label();
			this.estado = new System.Windows.Forms.ComboBox();
			this.clienteCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.clienteCampoLabel = new System.Windows.Forms.Label();
			this.cliente = new System.Windows.Forms.ComboBox();
			this.seguroCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.seguroCampoLabel = new System.Windows.Forms.Label();
			this.seguro = new System.Windows.Forms.ComboBox();
			this.guardarBoton = new System.Windows.Forms.Button();
			this.nuevoBoton = new System.Windows.Forms.Button();
			this.polizaNota = new System.Windows.Forms.Label();
			this.grilla = new System.Windows.Forms.DataGridView();
			this.filtro.SuspendLayout();
			this.desdeCampo.SuspendLayout();
			this.hastaCampo.SuspendLayout();
			this.mantenimiento.SuspendLayout();
			this.codigoCampo.SuspendLayout();
			this.serieCampo.SuspendLayout();
			this.categoriaCampo.SuspendLayout();
			this.marcaCampo.SuspendLayout();
			this.modeloCampo.SuspendLayout();
			this.descripcionCampo.SuspendLayout();
			this.tarifaCampo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tarifa)).BeginInit();
			this.reposicionCampo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.reposicion)).BeginInit();
			this.diasCampo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dias)).BeginInit();
			this.estadoCampo.SuspendLayout();
			this.clienteCampo.SuspendLayout();
			this.seguroCampo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grilla)).BeginInit();
			this.SuspendLayout();
			//
			// filtro
			//
			this.filtro.Controls.Add(this.desdeCampo);
			this.filtro.Controls.Add(this.hastaCampo);
			this.filtro.Controls.Add(this.disponiblesBoton);
			this.filtro.Controls.Add(this.catalogoBoton);
			this.filtro.Dock = System.Windows.Forms.DockStyle.Top;
			this.filtro.Location = new System.Drawing.Point(0, 0);
			this.filtro.Name = "filtro";
			this.filtro.Padding = new System.Windows.Forms.Padding(10);
			this.filtro.Size = new System.Drawing.Size(1180, 90);
			this.filtro.TabIndex = 2;
			//
			// desdeCampo
			//
			this.desdeCampo.Controls.Add(this.desdeCampoLabel);
			this.desdeCampo.Controls.Add(this.desde);
			this.desdeCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.desdeCampo.Location = new System.Drawing.Point(13, 13);
			this.desdeCampo.Name = "desdeCampo";
			this.desdeCampo.Size = new System.Drawing.Size(185, 68);
			this.desdeCampo.TabIndex = 0;
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
			this.desde.Size = new System.Drawing.Size(175, 25);
			this.desde.TabIndex = 1;
			//
			// hastaCampo
			//
			this.hastaCampo.Controls.Add(this.hastaCampoLabel);
			this.hastaCampo.Controls.Add(this.hasta);
			this.hastaCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.hastaCampo.Location = new System.Drawing.Point(204, 13);
			this.hastaCampo.Name = "hastaCampo";
			this.hastaCampo.Size = new System.Drawing.Size(185, 68);
			this.hastaCampo.TabIndex = 1;
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
			this.hasta.Size = new System.Drawing.Size(175, 25);
			this.hasta.TabIndex = 1;
			//
			// disponiblesBoton
			//
			this.disponiblesBoton.AutoSize = true;
			this.disponiblesBoton.Location = new System.Drawing.Point(395, 13);
			this.disponiblesBoton.Name = "disponiblesBoton";
			this.disponiblesBoton.Size = new System.Drawing.Size(150, 36);
			this.disponiblesBoton.TabIndex = 2;
			this.disponiblesBoton.Text = "Consultar disponibles";
			this.disponiblesBoton.UseVisualStyleBackColor = true;
			this.disponiblesBoton.Click += new System.EventHandler(this.DisponiblesClick);
			//
			// catalogoBoton
			//
			this.catalogoBoton.AutoSize = true;
			this.catalogoBoton.Location = new System.Drawing.Point(551, 13);
			this.catalogoBoton.Name = "catalogoBoton";
			this.catalogoBoton.Size = new System.Drawing.Size(142, 36);
			this.catalogoBoton.TabIndex = 3;
			this.catalogoBoton.Text = "Ver todo el catálogo";
			this.catalogoBoton.UseVisualStyleBackColor = true;
			this.catalogoBoton.Click += new System.EventHandler(this.TodoClick);
			//
			// mantenimiento
			//
			this.mantenimiento.Controls.Add(this.codigoCampo);
			this.mantenimiento.Controls.Add(this.serieCampo);
			this.mantenimiento.Controls.Add(this.categoriaCampo);
			this.mantenimiento.Controls.Add(this.marcaCampo);
			this.mantenimiento.Controls.Add(this.modeloCampo);
			this.mantenimiento.Controls.Add(this.descripcionCampo);
			this.mantenimiento.Controls.Add(this.tarifaCampo);
			this.mantenimiento.Controls.Add(this.reposicionCampo);
			this.mantenimiento.Controls.Add(this.diasCampo);
			this.mantenimiento.Controls.Add(this.estadoCampo);
			this.mantenimiento.Controls.Add(this.clienteCampo);
			this.mantenimiento.Controls.Add(this.seguroCampo);
			this.mantenimiento.Controls.Add(this.guardarBoton);
			this.mantenimiento.Controls.Add(this.nuevoBoton);
			this.mantenimiento.Controls.Add(this.polizaNota);
			this.mantenimiento.Dock = System.Windows.Forms.DockStyle.Top;
			this.mantenimiento.Location = new System.Drawing.Point(0, 90);
			this.mantenimiento.Name = "mantenimiento";
			this.mantenimiento.Padding = new System.Windows.Forms.Padding(10);
			this.mantenimiento.Size = new System.Drawing.Size(1180, 260);
			this.mantenimiento.TabIndex = 1;
			//
			// codigoCampo
			//
			this.codigoCampo.Controls.Add(this.codigoCampoLabel);
			this.codigoCampo.Controls.Add(this.codigo);
			this.codigoCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.codigoCampo.Location = new System.Drawing.Point(13, 13);
			this.codigoCampo.Name = "codigoCampo";
			this.codigoCampo.Size = new System.Drawing.Size(185, 68);
			this.codigoCampo.TabIndex = 0;
			//
			// codigoCampoLabel
			//
			this.codigoCampoLabel.AutoSize = true;
			this.codigoCampoLabel.Location = new System.Drawing.Point(3, 0);
			this.codigoCampoLabel.Name = "codigoCampoLabel";
			this.codigoCampoLabel.Size = new System.Drawing.Size(118, 19);
			this.codigoCampoLabel.TabIndex = 0;
			this.codigoCampoLabel.Text = "Código inventario";
			//
			// codigo
			//
			this.codigo.Location = new System.Drawing.Point(3, 22);
			this.codigo.MaxLength = 30;
			this.codigo.Name = "codigo";
			this.codigo.Size = new System.Drawing.Size(175, 25);
			this.codigo.TabIndex = 1;
			//
			// serieCampo
			//
			this.serieCampo.Controls.Add(this.serieCampoLabel);
			this.serieCampo.Controls.Add(this.serie);
			this.serieCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.serieCampo.Location = new System.Drawing.Point(204, 13);
			this.serieCampo.Name = "serieCampo";
			this.serieCampo.Size = new System.Drawing.Size(185, 68);
			this.serieCampo.TabIndex = 1;
			//
			// serieCampoLabel
			//
			this.serieCampoLabel.AutoSize = true;
			this.serieCampoLabel.Location = new System.Drawing.Point(3, 0);
			this.serieCampoLabel.Name = "serieCampoLabel";
			this.serieCampoLabel.Size = new System.Drawing.Size(38, 19);
			this.serieCampoLabel.TabIndex = 0;
			this.serieCampoLabel.Text = "Serie";
			//
			// serie
			//
			this.serie.Location = new System.Drawing.Point(3, 22);
			this.serie.MaxLength = 80;
			this.serie.Name = "serie";
			this.serie.Size = new System.Drawing.Size(175, 25);
			this.serie.TabIndex = 1;
			//
			// categoriaCampo
			//
			this.categoriaCampo.Controls.Add(this.categoriaCampoLabel);
			this.categoriaCampo.Controls.Add(this.categoria);
			this.categoriaCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.categoriaCampo.Location = new System.Drawing.Point(395, 13);
			this.categoriaCampo.Name = "categoriaCampo";
			this.categoriaCampo.Size = new System.Drawing.Size(185, 68);
			this.categoriaCampo.TabIndex = 2;
			//
			// categoriaCampoLabel
			//
			this.categoriaCampoLabel.AutoSize = true;
			this.categoriaCampoLabel.Location = new System.Drawing.Point(3, 0);
			this.categoriaCampoLabel.Name = "categoriaCampoLabel";
			this.categoriaCampoLabel.Size = new System.Drawing.Size(68, 19);
			this.categoriaCampoLabel.TabIndex = 0;
			this.categoriaCampoLabel.Text = "Categoría";
			//
			// categoria
			//
			this.categoria.Location = new System.Drawing.Point(3, 22);
			this.categoria.MaxLength = 50;
			this.categoria.Name = "categoria";
			this.categoria.Size = new System.Drawing.Size(175, 25);
			this.categoria.TabIndex = 1;
			//
			// marcaCampo
			//
			this.marcaCampo.Controls.Add(this.marcaCampoLabel);
			this.marcaCampo.Controls.Add(this.marca);
			this.marcaCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.marcaCampo.Location = new System.Drawing.Point(586, 13);
			this.marcaCampo.Name = "marcaCampo";
			this.marcaCampo.Size = new System.Drawing.Size(185, 68);
			this.marcaCampo.TabIndex = 3;
			//
			// marcaCampoLabel
			//
			this.marcaCampoLabel.AutoSize = true;
			this.marcaCampoLabel.Location = new System.Drawing.Point(3, 0);
			this.marcaCampoLabel.Name = "marcaCampoLabel";
			this.marcaCampoLabel.Size = new System.Drawing.Size(47, 19);
			this.marcaCampoLabel.TabIndex = 0;
			this.marcaCampoLabel.Text = "Marca";
			//
			// marca
			//
			this.marca.Location = new System.Drawing.Point(3, 22);
			this.marca.MaxLength = 50;
			this.marca.Name = "marca";
			this.marca.Size = new System.Drawing.Size(175, 25);
			this.marca.TabIndex = 1;
			//
			// modeloCampo
			//
			this.modeloCampo.Controls.Add(this.modeloCampoLabel);
			this.modeloCampo.Controls.Add(this.modelo);
			this.modeloCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.modeloCampo.Location = new System.Drawing.Point(777, 13);
			this.modeloCampo.Name = "modeloCampo";
			this.modeloCampo.Size = new System.Drawing.Size(185, 68);
			this.modeloCampo.TabIndex = 4;
			//
			// modeloCampoLabel
			//
			this.modeloCampoLabel.AutoSize = true;
			this.modeloCampoLabel.Location = new System.Drawing.Point(3, 0);
			this.modeloCampoLabel.Name = "modeloCampoLabel";
			this.modeloCampoLabel.Size = new System.Drawing.Size(56, 19);
			this.modeloCampoLabel.TabIndex = 0;
			this.modeloCampoLabel.Text = "Modelo";
			//
			// modelo
			//
			this.modelo.Location = new System.Drawing.Point(3, 22);
			this.modelo.MaxLength = 80;
			this.modelo.Name = "modelo";
			this.modelo.Size = new System.Drawing.Size(175, 25);
			this.modelo.TabIndex = 1;
			//
			// descripcionCampo
			//
			this.descripcionCampo.Controls.Add(this.descripcionCampoLabel);
			this.descripcionCampo.Controls.Add(this.descripcion);
			this.descripcionCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.descripcionCampo.Location = new System.Drawing.Point(968, 13);
			this.descripcionCampo.Name = "descripcionCampo";
			this.descripcionCampo.Size = new System.Drawing.Size(185, 68);
			this.descripcionCampo.TabIndex = 5;
			//
			// descripcionCampoLabel
			//
			this.descripcionCampoLabel.AutoSize = true;
			this.descripcionCampoLabel.Location = new System.Drawing.Point(3, 0);
			this.descripcionCampoLabel.Name = "descripcionCampoLabel";
			this.descripcionCampoLabel.Size = new System.Drawing.Size(79, 19);
			this.descripcionCampoLabel.TabIndex = 0;
			this.descripcionCampoLabel.Text = "Descripción";
			//
			// descripcion
			//
			this.descripcion.Location = new System.Drawing.Point(3, 22);
			this.descripcion.MaxLength = 300;
			this.descripcion.Name = "descripcion";
			this.descripcion.Size = new System.Drawing.Size(175, 25);
			this.descripcion.TabIndex = 1;
			//
			// tarifaCampo
			//
			this.tarifaCampo.Controls.Add(this.tarifaCampoLabel);
			this.tarifaCampo.Controls.Add(this.tarifa);
			this.tarifaCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.tarifaCampo.Location = new System.Drawing.Point(13, 87);
			this.tarifaCampo.Name = "tarifaCampo";
			this.tarifaCampo.Size = new System.Drawing.Size(185, 68);
			this.tarifaCampo.TabIndex = 6;
			//
			// tarifaCampoLabel
			//
			this.tarifaCampoLabel.AutoSize = true;
			this.tarifaCampoLabel.Location = new System.Drawing.Point(3, 0);
			this.tarifaCampoLabel.Name = "tarifaCampoLabel";
			this.tarifaCampoLabel.Size = new System.Drawing.Size(105, 19);
			this.tarifaCampoLabel.TabIndex = 0;
			this.tarifaCampoLabel.Text = "Tarifa diaria ARS";
			//
			// tarifa
			//
			this.tarifa.DecimalPlaces = 2;
			this.tarifa.Location = new System.Drawing.Point(3, 22);
			this.tarifa.Maximum = new decimal (new int[] { -727379968, 232, 0, 0 });
			this.tarifa.Name = "tarifa";
			this.tarifa.Size = new System.Drawing.Size(175, 25);
			this.tarifa.TabIndex = 1;
			this.tarifa.ThousandsSeparator = true;
			//
			// reposicionCampo
			//
			this.reposicionCampo.Controls.Add(this.reposicionCampoLabel);
			this.reposicionCampo.Controls.Add(this.reposicion);
			this.reposicionCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.reposicionCampo.Location = new System.Drawing.Point(204, 87);
			this.reposicionCampo.Name = "reposicionCampo";
			this.reposicionCampo.Size = new System.Drawing.Size(185, 68);
			this.reposicionCampo.TabIndex = 7;
			//
			// reposicionCampoLabel
			//
			this.reposicionCampoLabel.AutoSize = true;
			this.reposicionCampoLabel.Location = new System.Drawing.Point(3, 0);
			this.reposicionCampoLabel.Name = "reposicionCampoLabel";
			this.reposicionCampoLabel.Size = new System.Drawing.Size(102, 19);
			this.reposicionCampoLabel.TabIndex = 0;
			this.reposicionCampoLabel.Text = "Reposición ARS";
			//
			// reposicion
			//
			this.reposicion.DecimalPlaces = 2;
			this.reposicion.Location = new System.Drawing.Point(3, 22);
			this.reposicion.Maximum = new decimal (new int[] { -727379968, 232, 0, 0 });
			this.reposicion.Name = "reposicion";
			this.reposicion.Size = new System.Drawing.Size(175, 25);
			this.reposicion.TabIndex = 1;
			this.reposicion.ThousandsSeparator = true;
			//
			// diasCampo
			//
			this.diasCampo.Controls.Add(this.diasCampoLabel);
			this.diasCampo.Controls.Add(this.dias);
			this.diasCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.diasCampo.Location = new System.Drawing.Point(395, 87);
			this.diasCampo.Name = "diasCampo";
			this.diasCampo.Size = new System.Drawing.Size(185, 68);
			this.diasCampo.TabIndex = 8;
			//
			// diasCampoLabel
			//
			this.diasCampoLabel.AutoSize = true;
			this.diasCampoLabel.Location = new System.Drawing.Point(3, 0);
			this.diasCampoLabel.Name = "diasCampoLabel";
			this.diasCampoLabel.Size = new System.Drawing.Size(166, 19);
			this.diasCampoLabel.TabIndex = 0;
			this.diasCampoLabel.Text = "Días reacondicionamiento";
			//
			// dias
			//
			this.dias.Location = new System.Drawing.Point(3, 22);
			this.dias.Maximum = new decimal (new int[] { 365, 0, 0, 0 });
			this.dias.Name = "dias";
			this.dias.Size = new System.Drawing.Size(175, 25);
			this.dias.TabIndex = 1;
			this.dias.Value = new decimal (new int[] { 1, 0, 0, 0 });
			//
			// estadoCampo
			//
			this.estadoCampo.Controls.Add(this.estadoCampoLabel);
			this.estadoCampo.Controls.Add(this.estado);
			this.estadoCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.estadoCampo.Location = new System.Drawing.Point(586, 87);
			this.estadoCampo.Name = "estadoCampo";
			this.estadoCampo.Size = new System.Drawing.Size(185, 68);
			this.estadoCampo.TabIndex = 9;
			//
			// estadoCampoLabel
			//
			this.estadoCampoLabel.AutoSize = true;
			this.estadoCampoLabel.Location = new System.Drawing.Point(3, 0);
			this.estadoCampoLabel.Name = "estadoCampoLabel";
			this.estadoCampoLabel.Size = new System.Drawing.Size(50, 19);
			this.estadoCampoLabel.TabIndex = 0;
			this.estadoCampoLabel.Text = "Estado";
			//
			// estado
			//
			this.estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.estado.FormattingEnabled = true;
			this.estado.Items.AddRange(new object[] { "Disponible", "Baja" });
			this.estado.Location = new System.Drawing.Point(3, 22);
			this.estado.Name = "estado";
			this.estado.Size = new System.Drawing.Size(175, 25);
			this.estado.TabIndex = 1;
			//
			// clienteCampo
			//
			this.clienteCampo.Controls.Add(this.clienteCampoLabel);
			this.clienteCampo.Controls.Add(this.cliente);
			this.clienteCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.clienteCampo.Location = new System.Drawing.Point(777, 87);
			this.clienteCampo.Name = "clienteCampo";
			this.clienteCampo.Size = new System.Drawing.Size(185, 68);
			this.clienteCampo.TabIndex = 10;
			//
			// clienteCampoLabel
			//
			this.clienteCampoLabel.AutoSize = true;
			this.clienteCampoLabel.Location = new System.Drawing.Point(3, 0);
			this.clienteCampoLabel.Name = "clienteCampoLabel";
			this.clienteCampoLabel.Size = new System.Drawing.Size(123, 19);
			this.clienteCampoLabel.TabIndex = 0;
			this.clienteCampoLabel.Text = "Cliente de la póliza";
			//
			// cliente
			//
			this.cliente.DisplayMember = "Nombre";
			this.cliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cliente.FormattingEnabled = true;
			this.cliente.Location = new System.Drawing.Point(3, 22);
			this.cliente.Name = "cliente";
			this.cliente.Size = new System.Drawing.Size(175, 25);
			this.cliente.TabIndex = 1;
			this.cliente.SelectedIndexChanged += new System.EventHandler(this.ClienteCambio);
			//
			// seguroCampo
			//
			this.seguroCampo.Controls.Add(this.seguroCampoLabel);
			this.seguroCampo.Controls.Add(this.seguro);
			this.seguroCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.seguroCampo.Location = new System.Drawing.Point(968, 87);
			this.seguroCampo.Name = "seguroCampo";
			this.seguroCampo.Size = new System.Drawing.Size(185, 68);
			this.seguroCampo.TabIndex = 11;
			//
			// seguroCampoLabel
			//
			this.seguroCampoLabel.AutoSize = true;
			this.seguroCampoLabel.Location = new System.Drawing.Point(3, 0);
			this.seguroCampoLabel.Name = "seguroCampoLabel";
			this.seguroCampoLabel.Size = new System.Drawing.Size(115, 19);
			this.seguroCampoLabel.TabIndex = 0;
			this.seguroCampoLabel.Text = "Seguro (opcional)";
			//
			// seguro
			//
			this.seguro.DisplayMember = "Poliza";
			this.seguro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.seguro.FormattingEnabled = true;
			this.seguro.Location = new System.Drawing.Point(3, 22);
			this.seguro.Name = "seguro";
			this.seguro.Size = new System.Drawing.Size(175, 25);
			this.seguro.TabIndex = 1;
			//
			// guardarBoton
			//
			this.guardarBoton.AutoSize = true;
			this.guardarBoton.Location = new System.Drawing.Point(13, 161);
			this.guardarBoton.Name = "guardarBoton";
			this.guardarBoton.Size = new System.Drawing.Size(120, 36);
			this.guardarBoton.TabIndex = 12;
			this.guardarBoton.Text = "Guardar unidad";
			this.guardarBoton.UseVisualStyleBackColor = true;
			this.guardarBoton.Click += new System.EventHandler(this.GuardarClick);
			//
			// nuevoBoton
			//
			this.nuevoBoton.AutoSize = true;
			this.nuevoBoton.Location = new System.Drawing.Point(139, 161);
			this.nuevoBoton.Name = "nuevoBoton";
			this.nuevoBoton.Size = new System.Drawing.Size(120, 36);
			this.nuevoBoton.TabIndex = 13;
			this.nuevoBoton.Text = "Nueva unidad";
			this.nuevoBoton.UseVisualStyleBackColor = true;
			this.nuevoBoton.Click += new System.EventHandler(this.NuevoClick);
			//
			// polizaNota
			//
			this.polizaNota.AutoSize = true;
			this.polizaNota.Location = new System.Drawing.Point(265, 158);
			this.polizaNota.Name = "polizaNota";
			this.polizaNota.Size = new System.Drawing.Size(461, 19);
			this.polizaNota.TabIndex = 14;
			this.polizaNota.Text = "Una póliza puede asignarse a varias unidades. Su cobertura es por unidad.";
			//
			// grilla
			//
			this.grilla.AllowUserToAddRows = false;
			this.grilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grilla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grilla.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grilla.Location = new System.Drawing.Point(0, 350);
			this.grilla.MultiSelect = false;
			this.grilla.Name = "grilla";
			this.grilla.ReadOnly = true;
			this.grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grilla.Size = new System.Drawing.Size(1180, 300);
			this.grilla.TabIndex = 0;
			this.grilla.SelectionChanged += new System.EventHandler(this.EquipoCambio);
			//
			// EquiposForm
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1180, 650);
			this.Controls.Add(this.grilla);
			this.Controls.Add(this.mantenimiento);
			this.Controls.Add(this.filtro);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.Name = "EquiposForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Equipos · catálogo y disponibilidad";
			this.Load += new System.EventHandler(this.PrepararPantalla);
			this.Shown += new System.EventHandler(this.CargarClick);
			this.filtro.ResumeLayout(false);
			this.filtro.PerformLayout();
			this.desdeCampo.ResumeLayout(false);
			this.desdeCampo.PerformLayout();
			this.hastaCampo.ResumeLayout(false);
			this.hastaCampo.PerformLayout();
			this.mantenimiento.ResumeLayout(false);
			this.mantenimiento.PerformLayout();
			this.codigoCampo.ResumeLayout(false);
			this.codigoCampo.PerformLayout();
			this.serieCampo.ResumeLayout(false);
			this.serieCampo.PerformLayout();
			this.categoriaCampo.ResumeLayout(false);
			this.categoriaCampo.PerformLayout();
			this.marcaCampo.ResumeLayout(false);
			this.marcaCampo.PerformLayout();
			this.modeloCampo.ResumeLayout(false);
			this.modeloCampo.PerformLayout();
			this.descripcionCampo.ResumeLayout(false);
			this.descripcionCampo.PerformLayout();
			this.tarifaCampo.ResumeLayout(false);
			this.tarifaCampo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tarifa)).EndInit();
			this.reposicionCampo.ResumeLayout(false);
			this.reposicionCampo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.reposicion)).EndInit();
			this.diasCampo.ResumeLayout(false);
			this.diasCampo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dias)).EndInit();
			this.estadoCampo.ResumeLayout(false);
			this.estadoCampo.PerformLayout();
			this.clienteCampo.ResumeLayout(false);
			this.clienteCampo.PerformLayout();
			this.seguroCampo.ResumeLayout(false);
			this.seguroCampo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grilla)).EndInit();
			this.ResumeLayout(false);
		}

#endregion
		private System.Windows.Forms.FlowLayoutPanel filtro;
		private System.Windows.Forms.FlowLayoutPanel mantenimiento;
		private System.Windows.Forms.DateTimePicker desde;
		private System.Windows.Forms.DateTimePicker hasta;
		private System.Windows.Forms.FlowLayoutPanel desdeCampo;
		private System.Windows.Forms.Label desdeCampoLabel;
		private System.Windows.Forms.FlowLayoutPanel hastaCampo;
		private System.Windows.Forms.Label hastaCampoLabel;
		private System.Windows.Forms.Button disponiblesBoton;
		private System.Windows.Forms.Button catalogoBoton;
		private System.Windows.Forms.TextBox codigo;
		private System.Windows.Forms.TextBox serie;
		private System.Windows.Forms.TextBox categoria;
		private System.Windows.Forms.TextBox marca;
		private System.Windows.Forms.TextBox modelo;
		private System.Windows.Forms.TextBox descripcion;
		private System.Windows.Forms.NumericUpDown tarifa;
		private System.Windows.Forms.NumericUpDown reposicion;
		private System.Windows.Forms.NumericUpDown dias;
		private System.Windows.Forms.ComboBox estado;
		private System.Windows.Forms.ComboBox cliente;
		private System.Windows.Forms.ComboBox seguro;
		private System.Windows.Forms.FlowLayoutPanel codigoCampo;
		private System.Windows.Forms.Label codigoCampoLabel;
		private System.Windows.Forms.FlowLayoutPanel serieCampo;
		private System.Windows.Forms.Label serieCampoLabel;
		private System.Windows.Forms.FlowLayoutPanel categoriaCampo;
		private System.Windows.Forms.Label categoriaCampoLabel;
		private System.Windows.Forms.FlowLayoutPanel marcaCampo;
		private System.Windows.Forms.Label marcaCampoLabel;
		private System.Windows.Forms.FlowLayoutPanel modeloCampo;
		private System.Windows.Forms.Label modeloCampoLabel;
		private System.Windows.Forms.FlowLayoutPanel descripcionCampo;
		private System.Windows.Forms.Label descripcionCampoLabel;
		private System.Windows.Forms.FlowLayoutPanel tarifaCampo;
		private System.Windows.Forms.Label tarifaCampoLabel;
		private System.Windows.Forms.FlowLayoutPanel reposicionCampo;
		private System.Windows.Forms.Label reposicionCampoLabel;
		private System.Windows.Forms.FlowLayoutPanel diasCampo;
		private System.Windows.Forms.Label diasCampoLabel;
		private System.Windows.Forms.FlowLayoutPanel estadoCampo;
		private System.Windows.Forms.Label estadoCampoLabel;
		private System.Windows.Forms.FlowLayoutPanel clienteCampo;
		private System.Windows.Forms.Label clienteCampoLabel;
		private System.Windows.Forms.FlowLayoutPanel seguroCampo;
		private System.Windows.Forms.Label seguroCampoLabel;
		private System.Windows.Forms.Button guardarBoton;
		private System.Windows.Forms.Button nuevoBoton;
		private System.Windows.Forms.Label polizaNota;
		private System.Windows.Forms.DataGridView grilla;
		private System.Windows.Forms.DataGridViewTextBoxColumn grillaIdColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn grillaCodigoInventarioColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn grillaCategoriaColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn grillaMarcaColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn grillaModeloColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn grillaSerieColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn grillaEstadoColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn grillaTarifaDiariaColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn grillaValorReposicionColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn grillaDiasReacondicionamientoColumna;
	}
}
