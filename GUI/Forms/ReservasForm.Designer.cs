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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			this.tabs = new System.Windows.Forms.TabControl();
			this.gestionTab = new System.Windows.Forms.TabPage();
			this.gestionTabLayout = new System.Windows.Forms.TableLayoutPanel();
			this.barra = new System.Windows.Forms.TableLayoutPanel();
			this.avisoActualizacion = new System.Windows.Forms.Label();
			this.actualizarBoton = new System.Windows.Forms.Button();
			this.reservas = new System.Windows.Forms.DataGridView();
			this.reservasIdColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.reservasClienteColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.reservasEstadoColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.reservasDesdeColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.reservasHastaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.reservasImporteColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.reservasAntecedentesColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.datos = new System.Windows.Forms.TableLayoutPanel();
			this.detalle = new System.Windows.Forms.TextBox();
			this.acciones = new System.Windows.Forms.FlowLayoutPanel();
			this.accionesNota = new System.Windows.Forms.Label();
			this.aprobacion = new System.Windows.Forms.FlowLayoutPanel();
			this.aprobacionTitulo = new System.Windows.Forms.Label();
			this.revision = new System.Windows.Forms.Label();
			this.revisarBoton = new System.Windows.Forms.Button();
			this.aceptarBoton = new System.Windows.Forms.Button();
			this.rechazarBoton = new System.Windows.Forms.Button();
			this.pagoPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.pagoTitulo = new System.Windows.Forms.Label();
			this.pagoEstado = new System.Windows.Forms.Label();
			this.pagarBoton = new System.Windows.Forms.Button();
			this.entrega = new System.Windows.Forms.FlowLayoutPanel();
			this.entregaTitulo = new System.Windows.Forms.Label();
			this.cotejo = new System.Windows.Forms.CheckBox();
			this.firma = new System.Windows.Forms.CheckBox();
			this.registrarBoton = new System.Windows.Forms.Button();
			this.cancelacion = new System.Windows.Forms.FlowLayoutPanel();
			this.cancelacionTitulo = new System.Windows.Forms.Label();
			this.cancelacionTexto = new System.Windows.Forms.Label();
			this.cancelarBoton = new System.Windows.Forms.Button();
			this.documentos = new System.Windows.Forms.FlowLayoutPanel();
			this.documentosTitulo = new System.Windows.Forms.Label();
			this.remitoBoton = new System.Windows.Forms.Button();
			this.solicitudTab = new System.Windows.Forms.TabPage();
			this.solicitudTabLayout = new System.Windows.Forms.TableLayoutPanel();
			this.fechas = new System.Windows.Forms.TableLayoutPanel();
			this.clienteLabel = new System.Windows.Forms.Label();
			this.cliente = new System.Windows.Forms.ComboBox();
			this.desdeLabel = new System.Windows.Forms.Label();
			this.desde = new System.Windows.Forms.DateTimePicker();
			this.hastaLabel = new System.Windows.Forms.Label();
			this.hasta = new System.Windows.Forms.DateTimePicker();
			this.disponiblesBoton = new System.Windows.Forms.Button();
			this.unidades = new System.Windows.Forms.ListView();
			this.unidadesEquipoColumna = new System.Windows.Forms.ColumnHeader();
			this.unidadesTarifaColumna = new System.Windows.Forms.ColumnHeader();
			this.importes = new System.Windows.Forms.TableLayoutPanel();
			this.cotizacion = new System.Windows.Forms.Label();
			this.solicitarBoton = new System.Windows.Forms.Button();
			this.solicitudNota = new System.Windows.Forms.Label();
			this.inventarioTab = new System.Windows.Forms.TabPage();
			this.inventarioTabLayout = new System.Windows.Forms.TableLayoutPanel();
			this.editorInventario = new System.Windows.Forms.TableLayoutPanel();
			this.codigoLabel = new System.Windows.Forms.Label();
			this.codigo = new System.Windows.Forms.TextBox();
			this.serieLabel = new System.Windows.Forms.Label();
			this.serie = new System.Windows.Forms.TextBox();
			this.categoriaLabel = new System.Windows.Forms.Label();
			this.categoria = new System.Windows.Forms.TextBox();
			this.marcaLabel = new System.Windows.Forms.Label();
			this.marca = new System.Windows.Forms.TextBox();
			this.modeloLabel = new System.Windows.Forms.Label();
			this.modelo = new System.Windows.Forms.TextBox();
			this.tarifaLabel = new System.Windows.Forms.Label();
			this.tarifa = new System.Windows.Forms.NumericUpDown();
			this.reposicionLabel = new System.Windows.Forms.Label();
			this.reposicion = new System.Windows.Forms.NumericUpDown();
			this.estadoLabel = new System.Windows.Forms.Label();
			this.estado = new System.Windows.Forms.ComboBox();
			this.descripcionLabel = new System.Windows.Forms.Label();
			this.descripcion = new System.Windows.Forms.TextBox();
			this.accionesInventario = new System.Windows.Forms.FlowLayoutPanel();
			this.guardarEquipoBoton = new System.Windows.Forms.Button();
			this.nuevoEquipoBoton = new System.Windows.Forms.Button();
			this.actualizarInventarioBoton = new System.Windows.Forms.Button();
			this.unidadNota = new System.Windows.Forms.Label();
			this.inventario = new System.Windows.Forms.DataGridView();
			this.inventarioCodigoColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.inventarioMarcaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.inventarioModeloColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.inventarioSerieColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.inventarioCategoriaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.inventarioEstadoColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.inventarioTarifaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.inventarioReposicionColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.inventarioReacondColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cuentaTab = new System.Windows.Forms.TabPage();
			this.cuentaTabLayout = new System.Windows.Forms.TableLayoutPanel();
			this.cuentaDatos = new System.Windows.Forms.TableLayoutPanel();
			this.cuentaUsuarioLabel = new System.Windows.Forms.Label();
			this.cuentaUsuario = new System.Windows.Forms.Label();
			this.cuentaNombreLabel = new System.Windows.Forms.Label();
			this.cuentaNombre = new System.Windows.Forms.Label();
			this.cuentaDocumentoLabel = new System.Windows.Forms.Label();
			this.cuentaDocumento = new System.Windows.Forms.Label();
			this.cuentaCorreoLabel = new System.Windows.Forms.Label();
			this.cuentaCorreo = new System.Windows.Forms.Label();
			this.cuentaTelefonoLabel = new System.Windows.Forms.Label();
			this.cuentaTelefono = new System.Windows.Forms.Label();
			this.cuentaSeguroLabel = new System.Windows.Forms.Label();
			this.cuentaSeguro = new System.Windows.Forms.Label();
			this.cuentaSegurosTitulo = new System.Windows.Forms.Label();
			this.cuentaSeguros = new System.Windows.Forms.DataGridView();
			this.cuentaSegurosTipoColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cuentaSegurosPolizaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cuentaSegurosAseguradoraColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cuentaSegurosDesdeColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cuentaSegurosHastaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cuentaSegurosCoberturaColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cuentaAntecedentesTitulo = new System.Windows.Forms.Label();
			this.cuentaAntecedentes = new System.Windows.Forms.TextBox();
			this.actualizacionTimer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			this.tabs.SuspendLayout();
			this.gestionTab.SuspendLayout();
			this.gestionTabLayout.SuspendLayout();
			this.barra.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.reservas)).BeginInit();
			this.datos.SuspendLayout();
			this.acciones.SuspendLayout();
			this.aprobacion.SuspendLayout();
			this.pagoPanel.SuspendLayout();
			this.entrega.SuspendLayout();
			this.cancelacion.SuspendLayout();
			this.documentos.SuspendLayout();
			this.solicitudTab.SuspendLayout();
			this.solicitudTabLayout.SuspendLayout();
			this.fechas.SuspendLayout();
			this.importes.SuspendLayout();
			this.inventarioTab.SuspendLayout();
			this.inventarioTabLayout.SuspendLayout();
			this.editorInventario.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tarifa)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.reposicion)).BeginInit();
			this.accionesInventario.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.inventario)).BeginInit();
			this.cuentaTab.SuspendLayout();
			this.cuentaTabLayout.SuspendLayout();
			this.cuentaDatos.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cuentaSeguros)).BeginInit();
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
			dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
			dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(15, 23, 42);
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
			dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254);
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
			// 
			// ReservasForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.ClientSize = new System.Drawing.Size(870, 640);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Controls.Add(this.tabs);
			this.Load += new System.EventHandler(this.ReservasForm_Load);
			// 
			// tabs
			// 
			this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabs.SelectedIndex = 0;
			this.tabs.ItemSize = new System.Drawing.Size(0, 34);
			this.tabs.Padding = new System.Drawing.Point(20, 6);
			this.tabs.TabIndex = 0;
			this.tabs.Name = "tabs";
			this.tabs.Controls.Add(this.gestionTab);
			this.tabs.Controls.Add(this.solicitudTab);
			this.tabs.Controls.Add(this.inventarioTab);
			this.tabs.Controls.Add(this.cuentaTab);
			this.tabs.SelectedIndexChanged += new System.EventHandler(this.TabCambio);
			// 
			// gestionTab
			// 
			this.gestionTab.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.gestionTab.Padding = new System.Windows.Forms.Padding(16, 16, 16, 16);
			this.gestionTab.Text = "Solicitudes";
			this.gestionTab.UseVisualStyleBackColor = false;
			this.gestionTab.TabIndex = 0;
			this.gestionTab.Name = "gestionTab";
			this.gestionTab.Controls.Add(this.gestionTabLayout);
			// 
			// gestionTabLayout
			// 
			this.gestionTabLayout.ColumnCount = 1;
			this.gestionTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.gestionTabLayout.RowCount = 3;
			this.gestionTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.gestionTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42F));
			this.gestionTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58F));
			this.gestionTabLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gestionTabLayout.BackColor = System.Drawing.Color.Transparent;
			this.gestionTabLayout.TabIndex = 0;
			this.gestionTabLayout.Name = "gestionTabLayout";
			this.gestionTabLayout.Controls.Add(this.barra, 0, 0);
			this.gestionTabLayout.Controls.Add(this.reservas, 0, 1);
			this.gestionTabLayout.Controls.Add(this.datos, 0, 2);
			// 
			// barra
			// 
			this.barra.ColumnCount = 2;
			this.barra.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.barra.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
			this.barra.RowCount = 1;
			this.barra.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.barra.Dock = System.Windows.Forms.DockStyle.Fill;
			this.barra.AutoSize = true;
			this.barra.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.barra.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
			this.barra.TabIndex = 0;
			this.barra.Name = "barra";
			this.barra.Controls.Add(this.avisoActualizacion, 0, 0);
			this.barra.Controls.Add(this.actualizarBoton, 1, 0);
			// 
			// avisoActualizacion
			// 
			this.avisoActualizacion.AutoSize = false;
			this.avisoActualizacion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.avisoActualizacion.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
			this.avisoActualizacion.Size = new System.Drawing.Size(0, 36);
			this.avisoActualizacion.Text = "La lista se actualiza automáticamente cada 10 segundos.";
			this.avisoActualizacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.avisoActualizacion.TabIndex = 0;
			this.avisoActualizacion.Name = "avisoActualizacion";
			// 
			// actualizarBoton
			// 
			this.actualizarBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.actualizarBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.actualizarBoton.Size = new System.Drawing.Size(170, 38);
			this.actualizarBoton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
			this.actualizarBoton.Text = "Actualizar lista";
			this.actualizarBoton.UseVisualStyleBackColor = false;
			this.actualizarBoton.BackColor = System.Drawing.Color.White;
			this.actualizarBoton.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.actualizarBoton.FlatAppearance.BorderSize = 1;
			this.actualizarBoton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
			this.actualizarBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.actualizarBoton.TabIndex = 1;
			this.actualizarBoton.Name = "actualizarBoton";
			this.actualizarBoton.Click += new System.EventHandler(this.ActualizarClick);
			// 
			// reservas
			// 
			this.reservas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
				this.reservasIdColumna,
	this.reservasClienteColumna,
	this.reservasEstadoColumna,
	this.reservasDesdeColumna,
	this.reservasHastaColumna,
	this.reservasImporteColumna,
	this.reservasAntecedentesColumna});
			this.reservas.AllowUserToAddRows = false;
			this.reservas.AllowUserToDeleteRows = false;
			this.reservas.AllowUserToResizeRows = false;
			this.reservas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.reservas.BackgroundColor = System.Drawing.Color.White;
			this.reservas.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.reservas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.reservas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.reservas.ColumnHeadersHeight = 38;
			this.reservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.reservas.Dock = System.Windows.Forms.DockStyle.Fill;
			this.reservas.EnableHeadersVisualStyles = false;
			this.reservas.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
			this.reservas.MultiSelect = false;
			this.reservas.ReadOnly = true;
			this.reservas.RowHeadersVisible = false;
			this.reservas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.reservas.RowTemplate.Height = 34;
			this.reservas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.reservas.DefaultCellStyle = dataGridViewCellStyle2;
			this.reservas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.reservas.AutoGenerateColumns = false;
			this.reservas.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
			this.reservas.TabIndex = 1;
			this.reservas.Name = "reservas";
			this.reservas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.FormatearCliente);
			this.reservas.SelectionChanged += new System.EventHandler(this.ReservaCambio);
			// 
			// reservasIdColumna
			// 
			this.reservasIdColumna.HeaderText = "N°";
			this.reservasIdColumna.MinimumWidth = 40;
			this.reservasIdColumna.Name = "reservasIdColumna";
			this.reservasIdColumna.ReadOnly = true;
			this.reservasIdColumna.DataPropertyName = "Id";
			// 
			// reservasClienteColumna
			// 
			this.reservasClienteColumna.HeaderText = "Cliente";
			this.reservasClienteColumna.MinimumWidth = 120;
			this.reservasClienteColumna.Name = "reservasClienteColumna";
			this.reservasClienteColumna.ReadOnly = true;
			this.reservasClienteColumna.DataPropertyName = "ClienteId";
			// 
			// reservasEstadoColumna
			// 
			this.reservasEstadoColumna.HeaderText = "Estado del pedido";
			this.reservasEstadoColumna.MinimumWidth = 175;
			this.reservasEstadoColumna.Name = "reservasEstadoColumna";
			this.reservasEstadoColumna.ReadOnly = true;
			this.reservasEstadoColumna.DataPropertyName = "Estado";
			// 
			// reservasDesdeColumna
			// 
			this.reservasDesdeColumna.HeaderText = "Desde";
			this.reservasDesdeColumna.MinimumWidth = 115;
			this.reservasDesdeColumna.Name = "reservasDesdeColumna";
			this.reservasDesdeColumna.ReadOnly = true;
			this.reservasDesdeColumna.DataPropertyName = "Desde";
			this.reservasDesdeColumna.DefaultCellStyle.Format = "dd/MM/yy HH:mm";
			// 
			// reservasHastaColumna
			// 
			this.reservasHastaColumna.HeaderText = "Hasta";
			this.reservasHastaColumna.MinimumWidth = 115;
			this.reservasHastaColumna.Name = "reservasHastaColumna";
			this.reservasHastaColumna.ReadOnly = true;
			this.reservasHastaColumna.DataPropertyName = "Hasta";
			this.reservasHastaColumna.DefaultCellStyle.Format = "dd/MM/yy HH:mm";
			// 
			// reservasImporteColumna
			// 
			this.reservasImporteColumna.HeaderText = "Alquiler ARS";
			this.reservasImporteColumna.MinimumWidth = 90;
			this.reservasImporteColumna.Name = "reservasImporteColumna";
			this.reservasImporteColumna.ReadOnly = true;
			this.reservasImporteColumna.DataPropertyName = "Importe";
			this.reservasImporteColumna.DefaultCellStyle.Format = "N2";
			// 
			// reservasAntecedentesColumna
			// 
			this.reservasAntecedentesColumna.HeaderText = "Antecedentes";
			this.reservasAntecedentesColumna.MinimumWidth = 100;
			this.reservasAntecedentesColumna.Name = "reservasAntecedentesColumna";
			this.reservasAntecedentesColumna.ReadOnly = true;
			this.reservasAntecedentesColumna.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// datos
			// 
			this.datos.ColumnCount = 2;
			this.datos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.datos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 316F));
			this.datos.RowCount = 1;
			this.datos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.datos.Dock = System.Windows.Forms.DockStyle.Fill;
			this.datos.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
			this.datos.TabIndex = 2;
			this.datos.Name = "datos";
			this.datos.Controls.Add(this.detalle, 0, 0);
			this.datos.Controls.Add(this.acciones, 1, 0);
			// 
			// detalle
			// 
			this.detalle.BackColor = System.Drawing.Color.White;
			this.detalle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.detalle.Multiline = true;
			this.detalle.ReadOnly = true;
			this.detalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.detalle.Margin = new System.Windows.Forms.Padding(0, 12, 12, 0);
			this.detalle.TabIndex = 0;
			this.detalle.Name = "detalle";
			// 
			// acciones
			// 
			this.acciones.AutoScroll = true;
			this.acciones.Dock = System.Windows.Forms.DockStyle.Fill;
			this.acciones.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.acciones.WrapContents = false;
			this.acciones.Margin = new System.Windows.Forms.Padding(0, 12, 0, 0);
			this.acciones.TabIndex = 1;
			this.acciones.Name = "acciones";
			this.acciones.Controls.Add(this.accionesNota);
			this.acciones.Controls.Add(this.aprobacion);
			this.acciones.Controls.Add(this.pagoPanel);
			this.acciones.Controls.Add(this.entrega);
			this.acciones.Controls.Add(this.cancelacion);
			this.acciones.Controls.Add(this.documentos);
			// 
			// accionesNota
			// 
			this.accionesNota.AutoSize = true;
			this.accionesNota.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
			this.accionesNota.MaximumSize = new System.Drawing.Size(290, 0);
			this.accionesNota.Text = "Seleccioná un pedido para ver las acciones disponibles.";
			this.accionesNota.Margin = new System.Windows.Forms.Padding(4, 8, 0, 0);
			this.accionesNota.TabIndex = 0;
			this.accionesNota.Name = "accionesNota";
			// 
			// aprobacion
			// 
			this.aprobacion.AutoSize = true;
			this.aprobacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.aprobacion.BackColor = System.Drawing.Color.White;
			this.aprobacion.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.aprobacion.WrapContents = false;
			this.aprobacion.Padding = new System.Windows.Forms.Padding(12, 12, 12, 4);
			this.aprobacion.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
			this.aprobacion.Visible = false;
			this.aprobacion.TabIndex = 1;
			this.aprobacion.Name = "aprobacion";
			this.aprobacion.Controls.Add(this.aprobacionTitulo);
			this.aprobacion.Controls.Add(this.revision);
			this.aprobacion.Controls.Add(this.revisarBoton);
			this.aprobacion.Controls.Add(this.aceptarBoton);
			this.aprobacion.Controls.Add(this.rechazarBoton);
			// 
			// aprobacionTitulo
			// 
			this.aprobacionTitulo.AutoSize = true;
			this.aprobacionTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.aprobacionTitulo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.aprobacionTitulo.Text = "Revisión de stock";
			this.aprobacionTitulo.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
			this.aprobacionTitulo.TabIndex = 0;
			this.aprobacionTitulo.Name = "aprobacionTitulo";
			// 
			// revision
			// 
			this.revision.AutoSize = true;
			this.revision.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.revision.Text = "Seleccioná una solicitud pendiente y cotizala antes de aceptar.";
			this.revision.MaximumSize = new System.Drawing.Size(264, 0);
			this.revision.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
			this.revision.TabIndex = 1;
			this.revision.Name = "revision";
			// 
			// revisarBoton
			// 
			this.revisarBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.revisarBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.revisarBoton.Size = new System.Drawing.Size(264, 38);
			this.revisarBoton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
			this.revisarBoton.Text = "Cotizar solicitud";
			this.revisarBoton.UseVisualStyleBackColor = false;
			this.revisarBoton.BackColor = System.Drawing.Color.White;
			this.revisarBoton.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.revisarBoton.FlatAppearance.BorderSize = 1;
			this.revisarBoton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
			this.revisarBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.revisarBoton.Enabled = false;
			this.revisarBoton.TabIndex = 2;
			this.revisarBoton.Name = "revisarBoton";
			this.revisarBoton.Click += new System.EventHandler(this.CotizarClick);
			// 
			// aceptarBoton
			// 
			this.aceptarBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.aceptarBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.aceptarBoton.Size = new System.Drawing.Size(264, 38);
			this.aceptarBoton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
			this.aceptarBoton.Text = "Aceptar solicitud";
			this.aceptarBoton.UseVisualStyleBackColor = false;
			this.aceptarBoton.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
			this.aceptarBoton.ForeColor = System.Drawing.Color.White;
			this.aceptarBoton.FlatAppearance.BorderSize = 0;
			this.aceptarBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(29, 78, 216);
			this.aceptarBoton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.aceptarBoton.Enabled = false;
			this.aceptarBoton.TabIndex = 3;
			this.aceptarBoton.Name = "aceptarBoton";
			this.aceptarBoton.Click += new System.EventHandler(this.ConfirmarClick);
			// 
			// rechazarBoton
			// 
			this.rechazarBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.rechazarBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rechazarBoton.Size = new System.Drawing.Size(264, 38);
			this.rechazarBoton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
			this.rechazarBoton.Text = "Rechazar solicitud";
			this.rechazarBoton.UseVisualStyleBackColor = false;
			this.rechazarBoton.BackColor = System.Drawing.Color.White;
			this.rechazarBoton.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.rechazarBoton.FlatAppearance.BorderSize = 1;
			this.rechazarBoton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
			this.rechazarBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.rechazarBoton.Enabled = false;
			this.rechazarBoton.TabIndex = 4;
			this.rechazarBoton.Name = "rechazarBoton";
			this.rechazarBoton.Click += new System.EventHandler(this.RechazarClick);
			// 
			// pagoPanel
			// 
			this.pagoPanel.AutoSize = true;
			this.pagoPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.pagoPanel.BackColor = System.Drawing.Color.White;
			this.pagoPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.pagoPanel.WrapContents = false;
			this.pagoPanel.Padding = new System.Windows.Forms.Padding(12, 12, 12, 4);
			this.pagoPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
			this.pagoPanel.Visible = false;
			this.pagoPanel.TabIndex = 2;
			this.pagoPanel.Name = "pagoPanel";
			this.pagoPanel.Controls.Add(this.pagoTitulo);
			this.pagoPanel.Controls.Add(this.pagoEstado);
			this.pagoPanel.Controls.Add(this.pagarBoton);
			// 
			// pagoTitulo
			// 
			this.pagoTitulo.AutoSize = true;
			this.pagoTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.pagoTitulo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.pagoTitulo.Text = "Pago del cliente";
			this.pagoTitulo.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
			this.pagoTitulo.TabIndex = 0;
			this.pagoTitulo.Name = "pagoTitulo";
			// 
			// pagoEstado
			// 
			this.pagoEstado.AutoSize = true;
			this.pagoEstado.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.pagoEstado.Text = "Seleccioná una solicitud aceptada para pagar la seña.";
			this.pagoEstado.MaximumSize = new System.Drawing.Size(264, 0);
			this.pagoEstado.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
			this.pagoEstado.TabIndex = 1;
			this.pagoEstado.Name = "pagoEstado";
			// 
			// pagarBoton
			// 
			this.pagarBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pagarBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.pagarBoton.Size = new System.Drawing.Size(264, 38);
			this.pagarBoton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
			this.pagarBoton.Text = "Pagar seña";
			this.pagarBoton.UseVisualStyleBackColor = false;
			this.pagarBoton.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
			this.pagarBoton.ForeColor = System.Drawing.Color.White;
			this.pagarBoton.FlatAppearance.BorderSize = 0;
			this.pagarBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(29, 78, 216);
			this.pagarBoton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.pagarBoton.Enabled = false;
			this.pagarBoton.TabIndex = 2;
			this.pagarBoton.Name = "pagarBoton";
			this.pagarBoton.Click += new System.EventHandler(this.PagarClick);
			// 
			// entrega
			// 
			this.entrega.AutoSize = true;
			this.entrega.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.entrega.BackColor = System.Drawing.Color.White;
			this.entrega.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.entrega.WrapContents = false;
			this.entrega.Padding = new System.Windows.Forms.Padding(12, 12, 12, 4);
			this.entrega.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
			this.entrega.Visible = false;
			this.entrega.TabIndex = 3;
			this.entrega.Name = "entrega";
			this.entrega.Controls.Add(this.entregaTitulo);
			this.entrega.Controls.Add(this.cotejo);
			this.entrega.Controls.Add(this.firma);
			this.entrega.Controls.Add(this.registrarBoton);
			// 
			// entregaTitulo
			// 
			this.entregaTitulo.AutoSize = true;
			this.entregaTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.entregaTitulo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.entregaTitulo.Text = "Entrega de equipos";
			this.entregaTitulo.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
			this.entregaTitulo.TabIndex = 0;
			this.entregaTitulo.Name = "entregaTitulo";
			// 
			// cotejo
			// 
			this.cotejo.AutoSize = true;
			this.cotejo.Text = "Revisamos cada unidad con el cliente";
			this.cotejo.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.cotejo.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
			this.cotejo.UseVisualStyleBackColor = true;
			this.cotejo.MaximumSize = new System.Drawing.Size(264, 0);
			this.cotejo.TabIndex = 1;
			this.cotejo.Name = "cotejo";
			// 
			// firma
			// 
			this.firma.AutoSize = true;
			this.firma.Text = "Contrato y remito firmados";
			this.firma.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.firma.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
			this.firma.UseVisualStyleBackColor = true;
			this.firma.MaximumSize = new System.Drawing.Size(264, 0);
			this.firma.TabIndex = 2;
			this.firma.Name = "firma";
			// 
			// registrarBoton
			// 
			this.registrarBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.registrarBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.registrarBoton.Size = new System.Drawing.Size(264, 38);
			this.registrarBoton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
			this.registrarBoton.Text = "Registrar entrega";
			this.registrarBoton.UseVisualStyleBackColor = false;
			this.registrarBoton.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
			this.registrarBoton.ForeColor = System.Drawing.Color.White;
			this.registrarBoton.FlatAppearance.BorderSize = 0;
			this.registrarBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(29, 78, 216);
			this.registrarBoton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.registrarBoton.Enabled = false;
			this.registrarBoton.TabIndex = 3;
			this.registrarBoton.Name = "registrarBoton";
			this.registrarBoton.Click += new System.EventHandler(this.EntregaClick);
			// 
			// cancelacion
			// 
			this.cancelacion.AutoSize = true;
			this.cancelacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cancelacion.BackColor = System.Drawing.Color.White;
			this.cancelacion.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.cancelacion.WrapContents = false;
			this.cancelacion.Padding = new System.Windows.Forms.Padding(12, 12, 12, 4);
			this.cancelacion.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
			this.cancelacion.Visible = false;
			this.cancelacion.TabIndex = 4;
			this.cancelacion.Name = "cancelacion";
			this.cancelacion.Controls.Add(this.cancelacionTitulo);
			this.cancelacion.Controls.Add(this.cancelacionTexto);
			this.cancelacion.Controls.Add(this.cancelarBoton);
			// 
			// cancelacionTitulo
			// 
			this.cancelacionTitulo.AutoSize = true;
			this.cancelacionTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.cancelacionTitulo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.cancelacionTitulo.Text = "Cancelar pedido";
			this.cancelacionTitulo.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
			this.cancelacionTitulo.TabIndex = 0;
			this.cancelacionTitulo.Name = "cancelacionTitulo";
			// 
			// cancelacionTexto
			// 
			this.cancelacionTexto.AutoSize = true;
			this.cancelacionTexto.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.cancelacionTexto.Text = "Mientras no esté pagado, podés cancelarlo y liberar los equipos.";
			this.cancelacionTexto.MaximumSize = new System.Drawing.Size(264, 0);
			this.cancelacionTexto.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
			this.cancelacionTexto.TabIndex = 1;
			this.cancelacionTexto.Name = "cancelacionTexto";
			// 
			// cancelarBoton
			// 
			this.cancelarBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cancelarBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cancelarBoton.Size = new System.Drawing.Size(264, 38);
			this.cancelarBoton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
			this.cancelarBoton.Text = "Cancelar pedido";
			this.cancelarBoton.UseVisualStyleBackColor = false;
			this.cancelarBoton.BackColor = System.Drawing.Color.White;
			this.cancelarBoton.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.cancelarBoton.FlatAppearance.BorderSize = 1;
			this.cancelarBoton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
			this.cancelarBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.cancelarBoton.TabIndex = 2;
			this.cancelarBoton.Name = "cancelarBoton";
			this.cancelarBoton.Click += new System.EventHandler(this.CancelarClick);
			// 
			// documentos
			// 
			this.documentos.AutoSize = true;
			this.documentos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.documentos.BackColor = System.Drawing.Color.White;
			this.documentos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.documentos.WrapContents = false;
			this.documentos.Padding = new System.Windows.Forms.Padding(12, 12, 12, 4);
			this.documentos.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
			this.documentos.Visible = false;
			this.documentos.TabIndex = 5;
			this.documentos.Name = "documentos";
			this.documentos.Controls.Add(this.documentosTitulo);
			this.documentos.Controls.Add(this.remitoBoton);
			// 
			// documentosTitulo
			// 
			this.documentosTitulo.AutoSize = true;
			this.documentosTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.documentosTitulo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.documentosTitulo.Text = "Documentos";
			this.documentosTitulo.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
			this.documentosTitulo.TabIndex = 0;
			this.documentosTitulo.Name = "documentosTitulo";
			// 
			// remitoBoton
			// 
			this.remitoBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.remitoBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.remitoBoton.Size = new System.Drawing.Size(264, 38);
			this.remitoBoton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
			this.remitoBoton.Text = "Remito en PDF";
			this.remitoBoton.UseVisualStyleBackColor = false;
			this.remitoBoton.BackColor = System.Drawing.Color.White;
			this.remitoBoton.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.remitoBoton.FlatAppearance.BorderSize = 1;
			this.remitoBoton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
			this.remitoBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.remitoBoton.TabIndex = 1;
			this.remitoBoton.Name = "remitoBoton";
			this.remitoBoton.Click += new System.EventHandler(this.RemitoClick);
			// 
			// solicitudTab
			// 
			this.solicitudTab.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.solicitudTab.Padding = new System.Windows.Forms.Padding(16, 16, 16, 16);
			this.solicitudTab.Text = "Nueva solicitud";
			this.solicitudTab.UseVisualStyleBackColor = false;
			this.solicitudTab.TabIndex = 1;
			this.solicitudTab.Name = "solicitudTab";
			this.solicitudTab.Controls.Add(this.solicitudTabLayout);
			// 
			// solicitudTabLayout
			// 
			this.solicitudTabLayout.ColumnCount = 1;
			this.solicitudTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.solicitudTabLayout.RowCount = 3;
			this.solicitudTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.solicitudTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.solicitudTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.solicitudTabLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.solicitudTabLayout.BackColor = System.Drawing.Color.Transparent;
			this.solicitudTabLayout.TabIndex = 0;
			this.solicitudTabLayout.Name = "solicitudTabLayout";
			this.solicitudTabLayout.Controls.Add(this.fechas, 0, 0);
			this.solicitudTabLayout.Controls.Add(this.unidades, 0, 1);
			this.solicitudTabLayout.Controls.Add(this.importes, 0, 2);
			// 
			// fechas
			// 
			this.fechas.ColumnCount = 4;
			this.fechas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.fechas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.fechas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.fechas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
			this.fechas.RowCount = 2;
			this.fechas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.fechas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.fechas.AutoSize = true;
			this.fechas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.fechas.BackColor = System.Drawing.Color.White;
			this.fechas.Dock = System.Windows.Forms.DockStyle.Fill;
			this.fechas.Padding = new System.Windows.Forms.Padding(18, 18, 18, 8);
			this.fechas.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
			this.fechas.TabIndex = 0;
			this.fechas.Name = "fechas";
			this.fechas.Controls.Add(this.clienteLabel, 0, 0);
			this.fechas.Controls.Add(this.cliente, 0, 1);
			this.fechas.Controls.Add(this.desdeLabel, 1, 0);
			this.fechas.Controls.Add(this.desde, 1, 1);
			this.fechas.Controls.Add(this.hastaLabel, 2, 0);
			this.fechas.Controls.Add(this.hasta, 2, 1);
			this.fechas.Controls.Add(this.disponiblesBoton, 3, 1);
			// 
			// clienteLabel
			// 
			this.clienteLabel.AutoSize = true;
			this.clienteLabel.Text = "Cliente";
			this.clienteLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.clienteLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.clienteLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.clienteLabel.TabIndex = 0;
			this.clienteLabel.Name = "clienteLabel";
			// 
			// cliente
			// 
			this.cliente.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cliente.FormattingEnabled = true;
			this.cliente.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.cliente.DisplayMember = "Nombre";
			this.cliente.TabIndex = 1;
			this.cliente.Name = "cliente";
			this.cliente.SelectedIndexChanged += new System.EventHandler(this.ClienteSolicitudCambio);
			// 
			// desdeLabel
			// 
			this.desdeLabel.AutoSize = true;
			this.desdeLabel.Text = "Desde";
			this.desdeLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.desdeLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.desdeLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.desdeLabel.TabIndex = 2;
			this.desdeLabel.Name = "desdeLabel";
			// 
			// desde
			// 
			this.desde.Dock = System.Windows.Forms.DockStyle.Fill;
			this.desde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.desde.CustomFormat = "dd/MM/yyyy HH:mm";
			this.desde.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.desde.TabIndex = 3;
			this.desde.Name = "desde";
			// 
			// hastaLabel
			// 
			this.hastaLabel.AutoSize = true;
			this.hastaLabel.Text = "Hasta";
			this.hastaLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.hastaLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.hastaLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.hastaLabel.TabIndex = 4;
			this.hastaLabel.Name = "hastaLabel";
			// 
			// hasta
			// 
			this.hasta.Dock = System.Windows.Forms.DockStyle.Fill;
			this.hasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.hasta.CustomFormat = "dd/MM/yyyy HH:mm";
			this.hasta.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.hasta.TabIndex = 5;
			this.hasta.Name = "hasta";
			// 
			// disponiblesBoton
			// 
			this.disponiblesBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.disponiblesBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.disponiblesBoton.Size = new System.Drawing.Size(180, 30);
			this.disponiblesBoton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
			this.disponiblesBoton.Text = "Actualizar lista";
			this.disponiblesBoton.UseVisualStyleBackColor = false;
			this.disponiblesBoton.BackColor = System.Drawing.Color.White;
			this.disponiblesBoton.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.disponiblesBoton.FlatAppearance.BorderSize = 1;
			this.disponiblesBoton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
			this.disponiblesBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.disponiblesBoton.TabIndex = 6;
			this.disponiblesBoton.Name = "disponiblesBoton";
			this.disponiblesBoton.Click += new System.EventHandler(this.DisponiblesClick);
			// 
			// unidades
			// 
			this.unidades.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
				this.unidadesEquipoColumna,this.unidadesTarifaColumna});
			this.unidades.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.unidades.CheckBoxes = true;
			this.unidades.Dock = System.Windows.Forms.DockStyle.Fill;
			this.unidades.FullRowSelect = true;
			this.unidades.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.unidades.HideSelection = false;
			this.unidades.MultiSelect = false;
			this.unidades.ShowGroups = true;
			this.unidades.UseCompatibleStateImageBehavior = false;
			this.unidades.View = System.Windows.Forms.View.Details;
			this.unidades.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
			this.unidades.TabIndex = 1;
			this.unidades.Name = "unidades";
			this.unidades.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.UnidadCambio);
			// 
			// unidadesEquipoColumna
			// 
			this.unidadesEquipoColumna.Text = "Equipo";
			this.unidadesEquipoColumna.Width = 430;
			this.unidadesEquipoColumna.Name = "unidadesEquipoColumna";
			// 
			// unidadesTarifaColumna
			// 
			this.unidadesTarifaColumna.Text = "Precio por día ARS";
			this.unidadesTarifaColumna.Width = 150;
			this.unidadesTarifaColumna.Name = "unidadesTarifaColumna";
			// 
			// importes
			// 
			this.importes.ColumnCount = 2;
			this.importes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.importes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
			this.importes.RowCount = 2;
			this.importes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.importes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.importes.AutoSize = true;
			this.importes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.importes.BackColor = System.Drawing.Color.White;
			this.importes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.importes.Padding = new System.Windows.Forms.Padding(18, 18, 18, 8);
			this.importes.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
			this.importes.TabIndex = 2;
			this.importes.Name = "importes";
			this.importes.Controls.Add(this.cotizacion, 0, 0);
			this.importes.Controls.Add(this.solicitarBoton, 1, 0);
			this.importes.Controls.Add(this.solicitudNota, 0, 1);
			this.importes.SetColumnSpan(this.solicitudNota, 2);
			// 
			// cotizacion
			// 
			this.cotizacion.Text = "Elegí unidades y cotizá. La cotización no bloquea equipos.";
			this.cotizacion.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.cotizacion.AutoSize = false;
			this.cotizacion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cotizacion.Size = new System.Drawing.Size(0, 44);
			this.cotizacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cotizacion.TabIndex = 0;
			this.cotizacion.Name = "cotizacion";
			// 
			// solicitarBoton
			// 
			this.solicitarBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.solicitarBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.solicitarBoton.Size = new System.Drawing.Size(210, 38);
			this.solicitarBoton.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.solicitarBoton.Text = "Enviar solicitud a stock";
			this.solicitarBoton.UseVisualStyleBackColor = false;
			this.solicitarBoton.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
			this.solicitarBoton.ForeColor = System.Drawing.Color.White;
			this.solicitarBoton.FlatAppearance.BorderSize = 0;
			this.solicitarBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(29, 78, 216);
			this.solicitarBoton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.solicitarBoton.Enabled = false;
			this.solicitarBoton.TabIndex = 1;
			this.solicitarBoton.Name = "solicitarBoton";
			this.solicitarBoton.Click += new System.EventHandler(this.SolicitarClick);
			// 
			// solicitudNota
			// 
			this.solicitudNota.Text = "Queda pendiente hasta que stock la acepte. Podés ver su estado en la pestaña de pedidos.";
			this.solicitudNota.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
			this.solicitudNota.AutoSize = true;
			this.solicitudNota.TabIndex = 2;
			this.solicitudNota.Name = "solicitudNota";
			// 
			// inventarioTab
			// 
			this.inventarioTab.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.inventarioTab.Padding = new System.Windows.Forms.Padding(16, 16, 16, 16);
			this.inventarioTab.Text = "Inventario";
			this.inventarioTab.UseVisualStyleBackColor = false;
			this.inventarioTab.TabIndex = 2;
			this.inventarioTab.Name = "inventarioTab";
			this.inventarioTab.Controls.Add(this.inventarioTabLayout);
			// 
			// inventarioTabLayout
			// 
			this.inventarioTabLayout.ColumnCount = 1;
			this.inventarioTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.inventarioTabLayout.RowCount = 2;
			this.inventarioTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.inventarioTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.inventarioTabLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.inventarioTabLayout.BackColor = System.Drawing.Color.Transparent;
			this.inventarioTabLayout.TabIndex = 0;
			this.inventarioTabLayout.Name = "inventarioTabLayout";
			this.inventarioTabLayout.Controls.Add(this.editorInventario, 0, 0);
			this.inventarioTabLayout.Controls.Add(this.inventario, 0, 1);
			// 
			// editorInventario
			// 
			this.editorInventario.ColumnCount = 4;
			this.editorInventario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.editorInventario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.editorInventario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.editorInventario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.editorInventario.RowCount = 7;
			this.editorInventario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.editorInventario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.editorInventario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.editorInventario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.editorInventario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.editorInventario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.editorInventario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.editorInventario.AutoSize = true;
			this.editorInventario.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.editorInventario.BackColor = System.Drawing.Color.White;
			this.editorInventario.Dock = System.Windows.Forms.DockStyle.Fill;
			this.editorInventario.Padding = new System.Windows.Forms.Padding(18, 18, 18, 8);
			this.editorInventario.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
			this.editorInventario.TabIndex = 0;
			this.editorInventario.Name = "editorInventario";
			this.editorInventario.Controls.Add(this.codigoLabel, 0, 0);
			this.editorInventario.Controls.Add(this.codigo, 0, 1);
			this.editorInventario.Controls.Add(this.serieLabel, 1, 0);
			this.editorInventario.Controls.Add(this.serie, 1, 1);
			this.editorInventario.Controls.Add(this.categoriaLabel, 2, 0);
			this.editorInventario.Controls.Add(this.categoria, 2, 1);
			this.editorInventario.Controls.Add(this.marcaLabel, 3, 0);
			this.editorInventario.Controls.Add(this.marca, 3, 1);
			this.editorInventario.Controls.Add(this.modeloLabel, 0, 2);
			this.editorInventario.Controls.Add(this.modelo, 0, 3);
			this.editorInventario.Controls.Add(this.tarifaLabel, 1, 2);
			this.editorInventario.Controls.Add(this.tarifa, 1, 3);
			this.editorInventario.Controls.Add(this.reposicionLabel, 2, 2);
			this.editorInventario.Controls.Add(this.reposicion, 2, 3);
			this.editorInventario.Controls.Add(this.estadoLabel, 3, 2);
			this.editorInventario.Controls.Add(this.estado, 3, 3);
			this.editorInventario.Controls.Add(this.descripcionLabel, 0, 4);
			this.editorInventario.SetColumnSpan(this.descripcionLabel, 4);
			this.editorInventario.Controls.Add(this.descripcion, 0, 5);
			this.editorInventario.SetColumnSpan(this.descripcion, 4);
			this.editorInventario.Controls.Add(this.accionesInventario, 0, 6);
			this.editorInventario.SetColumnSpan(this.accionesInventario, 4);
			// 
			// codigoLabel
			// 
			this.codigoLabel.AutoSize = true;
			this.codigoLabel.Text = "Código de inventario";
			this.codigoLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.codigoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.codigoLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.codigoLabel.TabIndex = 0;
			this.codigoLabel.Name = "codigoLabel";
			// 
			// codigo
			// 
			this.codigo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.codigo.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.codigo.MaxLength = 30;
			this.codigo.TabIndex = 1;
			this.codigo.Name = "codigo";
			// 
			// serieLabel
			// 
			this.serieLabel.AutoSize = true;
			this.serieLabel.Text = "Serie";
			this.serieLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.serieLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.serieLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.serieLabel.TabIndex = 2;
			this.serieLabel.Name = "serieLabel";
			// 
			// serie
			// 
			this.serie.Dock = System.Windows.Forms.DockStyle.Fill;
			this.serie.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.serie.MaxLength = 80;
			this.serie.TabIndex = 3;
			this.serie.Name = "serie";
			// 
			// categoriaLabel
			// 
			this.categoriaLabel.AutoSize = true;
			this.categoriaLabel.Text = "Categoría";
			this.categoriaLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.categoriaLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.categoriaLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.categoriaLabel.TabIndex = 4;
			this.categoriaLabel.Name = "categoriaLabel";
			// 
			// categoria
			// 
			this.categoria.Dock = System.Windows.Forms.DockStyle.Fill;
			this.categoria.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.categoria.MaxLength = 50;
			this.categoria.TabIndex = 5;
			this.categoria.Name = "categoria";
			// 
			// marcaLabel
			// 
			this.marcaLabel.AutoSize = true;
			this.marcaLabel.Text = "Marca";
			this.marcaLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.marcaLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.marcaLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.marcaLabel.TabIndex = 6;
			this.marcaLabel.Name = "marcaLabel";
			// 
			// marca
			// 
			this.marca.Dock = System.Windows.Forms.DockStyle.Fill;
			this.marca.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.marca.MaxLength = 50;
			this.marca.TabIndex = 7;
			this.marca.Name = "marca";
			// 
			// modeloLabel
			// 
			this.modeloLabel.AutoSize = true;
			this.modeloLabel.Text = "Modelo";
			this.modeloLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.modeloLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.modeloLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.modeloLabel.TabIndex = 8;
			this.modeloLabel.Name = "modeloLabel";
			// 
			// modelo
			// 
			this.modelo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.modelo.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.modelo.MaxLength = 80;
			this.modelo.TabIndex = 9;
			this.modelo.Name = "modelo";
			// 
			// tarifaLabel
			// 
			this.tarifaLabel.AutoSize = true;
			this.tarifaLabel.Text = "Tarifa diaria ARS";
			this.tarifaLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.tarifaLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.tarifaLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.tarifaLabel.TabIndex = 10;
			this.tarifaLabel.Name = "tarifaLabel";
			// 
			// tarifa
			// 
			this.tarifa.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tarifa.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.tarifa.DecimalPlaces = 2;
			this.tarifa.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
			this.tarifa.ThousandsSeparator = true;
			this.tarifa.TabIndex = 11;
			this.tarifa.Name = "tarifa";
			// 
			// reposicionLabel
			// 
			this.reposicionLabel.AutoSize = true;
			this.reposicionLabel.Text = "Reposición ARS";
			this.reposicionLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.reposicionLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.reposicionLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.reposicionLabel.TabIndex = 12;
			this.reposicionLabel.Name = "reposicionLabel";
			// 
			// reposicion
			// 
			this.reposicion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.reposicion.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.reposicion.DecimalPlaces = 2;
			this.reposicion.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
			this.reposicion.ThousandsSeparator = true;
			this.reposicion.TabIndex = 13;
			this.reposicion.Name = "reposicion";
			// 
			// estadoLabel
			// 
			this.estadoLabel.AutoSize = true;
			this.estadoLabel.Text = "Estado";
			this.estadoLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.estadoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.estadoLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.estadoLabel.TabIndex = 14;
			this.estadoLabel.Name = "estadoLabel";
			// 
			// estado
			// 
			this.estado.Items.AddRange(new object[] {
				"Disponible",
	"Baja"});
			this.estado.Dock = System.Windows.Forms.DockStyle.Fill;
			this.estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.estado.FormattingEnabled = true;
			this.estado.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.estado.TabIndex = 15;
			this.estado.Name = "estado";
			// 
			// descripcionLabel
			// 
			this.descripcionLabel.AutoSize = true;
			this.descripcionLabel.Text = "Descripción";
			this.descripcionLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.descripcionLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.descripcionLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.descripcionLabel.TabIndex = 16;
			this.descripcionLabel.Name = "descripcionLabel";
			// 
			// descripcion
			// 
			this.descripcion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.descripcion.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.descripcion.MaxLength = 300;
			this.descripcion.TabIndex = 17;
			this.descripcion.Name = "descripcion";
			// 
			// accionesInventario
			// 
			this.accionesInventario.AutoSize = true;
			this.accionesInventario.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.accionesInventario.Dock = System.Windows.Forms.DockStyle.Fill;
			this.accionesInventario.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.accionesInventario.TabIndex = 18;
			this.accionesInventario.Name = "accionesInventario";
			this.accionesInventario.Controls.Add(this.guardarEquipoBoton);
			this.accionesInventario.Controls.Add(this.nuevoEquipoBoton);
			this.accionesInventario.Controls.Add(this.actualizarInventarioBoton);
			this.accionesInventario.Controls.Add(this.unidadNota);
			// 
			// guardarEquipoBoton
			// 
			this.guardarEquipoBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.guardarEquipoBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.guardarEquipoBoton.Size = new System.Drawing.Size(170, 38);
			this.guardarEquipoBoton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.guardarEquipoBoton.Text = "Agregar unidad";
			this.guardarEquipoBoton.UseVisualStyleBackColor = false;
			this.guardarEquipoBoton.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
			this.guardarEquipoBoton.ForeColor = System.Drawing.Color.White;
			this.guardarEquipoBoton.FlatAppearance.BorderSize = 0;
			this.guardarEquipoBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(29, 78, 216);
			this.guardarEquipoBoton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.guardarEquipoBoton.TabIndex = 0;
			this.guardarEquipoBoton.Name = "guardarEquipoBoton";
			this.guardarEquipoBoton.Click += new System.EventHandler(this.GuardarEquipoClick);
			// 
			// nuevoEquipoBoton
			// 
			this.nuevoEquipoBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.nuevoEquipoBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.nuevoEquipoBoton.Size = new System.Drawing.Size(170, 38);
			this.nuevoEquipoBoton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.nuevoEquipoBoton.Text = "Nueva unidad";
			this.nuevoEquipoBoton.UseVisualStyleBackColor = false;
			this.nuevoEquipoBoton.BackColor = System.Drawing.Color.White;
			this.nuevoEquipoBoton.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.nuevoEquipoBoton.FlatAppearance.BorderSize = 1;
			this.nuevoEquipoBoton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
			this.nuevoEquipoBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.nuevoEquipoBoton.TabIndex = 1;
			this.nuevoEquipoBoton.Name = "nuevoEquipoBoton";
			this.nuevoEquipoBoton.Click += new System.EventHandler(this.NuevoEquipoClick);
			// 
			// actualizarInventarioBoton
			// 
			this.actualizarInventarioBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.actualizarInventarioBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.actualizarInventarioBoton.Size = new System.Drawing.Size(170, 38);
			this.actualizarInventarioBoton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.actualizarInventarioBoton.Text = "Actualizar";
			this.actualizarInventarioBoton.UseVisualStyleBackColor = false;
			this.actualizarInventarioBoton.BackColor = System.Drawing.Color.White;
			this.actualizarInventarioBoton.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.actualizarInventarioBoton.FlatAppearance.BorderSize = 1;
			this.actualizarInventarioBoton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
			this.actualizarInventarioBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.actualizarInventarioBoton.TabIndex = 2;
			this.actualizarInventarioBoton.Name = "actualizarInventarioBoton";
			this.actualizarInventarioBoton.Click += new System.EventHandler(this.ActualizarInventarioClick);
			// 
			// unidadNota
			// 
			this.unidadNota.Text = "Completá los datos para agregar una unidad.";
			this.unidadNota.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
			this.unidadNota.AutoSize = true;
			this.unidadNota.Margin = new System.Windows.Forms.Padding(8, 10, 0, 0);
			this.unidadNota.TabIndex = 3;
			this.unidadNota.Name = "unidadNota";
			// 
			// inventario
			// 
			this.inventario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
				this.inventarioCodigoColumna,
	this.inventarioMarcaColumna,
	this.inventarioModeloColumna,
	this.inventarioSerieColumna,
	this.inventarioCategoriaColumna,
	this.inventarioEstadoColumna,
	this.inventarioTarifaColumna,
	this.inventarioReposicionColumna,
	this.inventarioReacondColumna});
			this.inventario.AllowUserToAddRows = false;
			this.inventario.AllowUserToDeleteRows = false;
			this.inventario.AllowUserToResizeRows = false;
			this.inventario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.inventario.BackgroundColor = System.Drawing.Color.White;
			this.inventario.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.inventario.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.inventario.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.inventario.ColumnHeadersHeight = 38;
			this.inventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.inventario.Dock = System.Windows.Forms.DockStyle.Fill;
			this.inventario.EnableHeadersVisualStyles = false;
			this.inventario.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
			this.inventario.MultiSelect = false;
			this.inventario.ReadOnly = true;
			this.inventario.RowHeadersVisible = false;
			this.inventario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.inventario.RowTemplate.Height = 34;
			this.inventario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.inventario.DefaultCellStyle = dataGridViewCellStyle5;
			this.inventario.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
			this.inventario.AutoGenerateColumns = false;
			this.inventario.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
			this.inventario.TabIndex = 1;
			this.inventario.Name = "inventario";
			this.inventario.SelectionChanged += new System.EventHandler(this.EquipoInventarioCambio);
			// 
			// inventarioCodigoColumna
			// 
			this.inventarioCodigoColumna.HeaderText = "Código";
			this.inventarioCodigoColumna.MinimumWidth = 80;
			this.inventarioCodigoColumna.Name = "inventarioCodigoColumna";
			this.inventarioCodigoColumna.ReadOnly = true;
			this.inventarioCodigoColumna.DataPropertyName = "CodigoInventario";
			// 
			// inventarioMarcaColumna
			// 
			this.inventarioMarcaColumna.HeaderText = "Marca";
			this.inventarioMarcaColumna.MinimumWidth = 70;
			this.inventarioMarcaColumna.Name = "inventarioMarcaColumna";
			this.inventarioMarcaColumna.ReadOnly = true;
			this.inventarioMarcaColumna.DataPropertyName = "Marca";
			// 
			// inventarioModeloColumna
			// 
			this.inventarioModeloColumna.HeaderText = "Modelo";
			this.inventarioModeloColumna.MinimumWidth = 90;
			this.inventarioModeloColumna.Name = "inventarioModeloColumna";
			this.inventarioModeloColumna.ReadOnly = true;
			this.inventarioModeloColumna.DataPropertyName = "Modelo";
			// 
			// inventarioSerieColumna
			// 
			this.inventarioSerieColumna.HeaderText = "Serie";
			this.inventarioSerieColumna.MinimumWidth = 80;
			this.inventarioSerieColumna.Name = "inventarioSerieColumna";
			this.inventarioSerieColumna.ReadOnly = true;
			this.inventarioSerieColumna.DataPropertyName = "Serie";
			// 
			// inventarioCategoriaColumna
			// 
			this.inventarioCategoriaColumna.HeaderText = "Categoría";
			this.inventarioCategoriaColumna.MinimumWidth = 80;
			this.inventarioCategoriaColumna.Name = "inventarioCategoriaColumna";
			this.inventarioCategoriaColumna.ReadOnly = true;
			this.inventarioCategoriaColumna.DataPropertyName = "Categoria";
			// 
			// inventarioEstadoColumna
			// 
			this.inventarioEstadoColumna.HeaderText = "Estado";
			this.inventarioEstadoColumna.MinimumWidth = 90;
			this.inventarioEstadoColumna.Name = "inventarioEstadoColumna";
			this.inventarioEstadoColumna.ReadOnly = true;
			this.inventarioEstadoColumna.DataPropertyName = "Estado";
			// 
			// inventarioTarifaColumna
			// 
			this.inventarioTarifaColumna.HeaderText = "Tarifa ARS";
			this.inventarioTarifaColumna.MinimumWidth = 80;
			this.inventarioTarifaColumna.Name = "inventarioTarifaColumna";
			this.inventarioTarifaColumna.ReadOnly = true;
			this.inventarioTarifaColumna.DataPropertyName = "TarifaDiaria";
			this.inventarioTarifaColumna.DefaultCellStyle.Format = "N2";
			// 
			// inventarioReposicionColumna
			// 
			this.inventarioReposicionColumna.HeaderText = "Reposición ARS";
			this.inventarioReposicionColumna.MinimumWidth = 95;
			this.inventarioReposicionColumna.Name = "inventarioReposicionColumna";
			this.inventarioReposicionColumna.ReadOnly = true;
			this.inventarioReposicionColumna.DataPropertyName = "ValorReposicion";
			this.inventarioReposicionColumna.DefaultCellStyle.Format = "N2";
			// 
			// inventarioReacondColumna
			// 
			this.inventarioReacondColumna.HeaderText = "Reacond. (días)";
			this.inventarioReacondColumna.MinimumWidth = 80;
			this.inventarioReacondColumna.Name = "inventarioReacondColumna";
			this.inventarioReacondColumna.ReadOnly = true;
			this.inventarioReacondColumna.DataPropertyName = "DiasReacondicionamiento";
			// 
			// cuentaTab
			// 
			this.cuentaTab.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.cuentaTab.Padding = new System.Windows.Forms.Padding(16, 16, 16, 16);
			this.cuentaTab.Text = "Mi cuenta";
			this.cuentaTab.UseVisualStyleBackColor = false;
			this.cuentaTab.TabIndex = 3;
			this.cuentaTab.Name = "cuentaTab";
			this.cuentaTab.Controls.Add(this.cuentaTabLayout);
			// 
			// cuentaTabLayout
			// 
			this.cuentaTabLayout.ColumnCount = 1;
			this.cuentaTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.cuentaTabLayout.RowCount = 5;
			this.cuentaTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.cuentaTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.cuentaTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.cuentaTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.cuentaTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.cuentaTabLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cuentaTabLayout.BackColor = System.Drawing.Color.Transparent;
			this.cuentaTabLayout.TabIndex = 0;
			this.cuentaTabLayout.Name = "cuentaTabLayout";
			this.cuentaTabLayout.Controls.Add(this.cuentaDatos, 0, 0);
			this.cuentaTabLayout.Controls.Add(this.cuentaSegurosTitulo, 0, 1);
			this.cuentaTabLayout.Controls.Add(this.cuentaSeguros, 0, 2);
			this.cuentaTabLayout.Controls.Add(this.cuentaAntecedentesTitulo, 0, 3);
			this.cuentaTabLayout.Controls.Add(this.cuentaAntecedentes, 0, 4);
			// 
			// cuentaDatos
			// 
			this.cuentaDatos.ColumnCount = 3;
			this.cuentaDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
			this.cuentaDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
			this.cuentaDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
			this.cuentaDatos.RowCount = 4;
			this.cuentaDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.cuentaDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.cuentaDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.cuentaDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.cuentaDatos.AutoSize = true;
			this.cuentaDatos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cuentaDatos.BackColor = System.Drawing.Color.White;
			this.cuentaDatos.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cuentaDatos.Padding = new System.Windows.Forms.Padding(18, 18, 18, 8);
			this.cuentaDatos.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
			this.cuentaDatos.TabIndex = 0;
			this.cuentaDatos.Name = "cuentaDatos";
			this.cuentaDatos.Controls.Add(this.cuentaUsuarioLabel, 0, 0);
			this.cuentaDatos.Controls.Add(this.cuentaUsuario, 0, 1);
			this.cuentaDatos.Controls.Add(this.cuentaNombreLabel, 1, 0);
			this.cuentaDatos.Controls.Add(this.cuentaNombre, 1, 1);
			this.cuentaDatos.Controls.Add(this.cuentaDocumentoLabel, 2, 0);
			this.cuentaDatos.Controls.Add(this.cuentaDocumento, 2, 1);
			this.cuentaDatos.Controls.Add(this.cuentaCorreoLabel, 0, 2);
			this.cuentaDatos.Controls.Add(this.cuentaCorreo, 0, 3);
			this.cuentaDatos.Controls.Add(this.cuentaTelefonoLabel, 1, 2);
			this.cuentaDatos.Controls.Add(this.cuentaTelefono, 1, 3);
			this.cuentaDatos.Controls.Add(this.cuentaSeguroLabel, 2, 2);
			this.cuentaDatos.Controls.Add(this.cuentaSeguro, 2, 3);
			// 
			// cuentaUsuarioLabel
			// 
			this.cuentaUsuarioLabel.AutoSize = true;
			this.cuentaUsuarioLabel.Text = "Usuario";
			this.cuentaUsuarioLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.cuentaUsuarioLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.cuentaUsuarioLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.cuentaUsuarioLabel.TabIndex = 0;
			this.cuentaUsuarioLabel.Name = "cuentaUsuarioLabel";
			// 
			// cuentaUsuario
			// 
			this.cuentaUsuario.AutoSize = true;
			this.cuentaUsuario.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
			this.cuentaUsuario.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.cuentaUsuario.Text = "-";
			this.cuentaUsuario.Margin = new System.Windows.Forms.Padding(0, 0, 12, 14);
			this.cuentaUsuario.TabIndex = 1;
			this.cuentaUsuario.Name = "cuentaUsuario";
			// 
			// cuentaNombreLabel
			// 
			this.cuentaNombreLabel.AutoSize = true;
			this.cuentaNombreLabel.Text = "Nombre";
			this.cuentaNombreLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.cuentaNombreLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.cuentaNombreLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.cuentaNombreLabel.TabIndex = 2;
			this.cuentaNombreLabel.Name = "cuentaNombreLabel";
			// 
			// cuentaNombre
			// 
			this.cuentaNombre.AutoSize = true;
			this.cuentaNombre.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
			this.cuentaNombre.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.cuentaNombre.Text = "-";
			this.cuentaNombre.Margin = new System.Windows.Forms.Padding(0, 0, 12, 14);
			this.cuentaNombre.TabIndex = 3;
			this.cuentaNombre.Name = "cuentaNombre";
			// 
			// cuentaDocumentoLabel
			// 
			this.cuentaDocumentoLabel.AutoSize = true;
			this.cuentaDocumentoLabel.Text = "DNI / CUIT";
			this.cuentaDocumentoLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.cuentaDocumentoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.cuentaDocumentoLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.cuentaDocumentoLabel.TabIndex = 4;
			this.cuentaDocumentoLabel.Name = "cuentaDocumentoLabel";
			// 
			// cuentaDocumento
			// 
			this.cuentaDocumento.AutoSize = true;
			this.cuentaDocumento.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
			this.cuentaDocumento.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.cuentaDocumento.Text = "-";
			this.cuentaDocumento.Margin = new System.Windows.Forms.Padding(0, 0, 12, 14);
			this.cuentaDocumento.TabIndex = 5;
			this.cuentaDocumento.Name = "cuentaDocumento";
			// 
			// cuentaCorreoLabel
			// 
			this.cuentaCorreoLabel.AutoSize = true;
			this.cuentaCorreoLabel.Text = "Correo";
			this.cuentaCorreoLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.cuentaCorreoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.cuentaCorreoLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.cuentaCorreoLabel.TabIndex = 6;
			this.cuentaCorreoLabel.Name = "cuentaCorreoLabel";
			// 
			// cuentaCorreo
			// 
			this.cuentaCorreo.AutoSize = true;
			this.cuentaCorreo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
			this.cuentaCorreo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.cuentaCorreo.Text = "-";
			this.cuentaCorreo.Margin = new System.Windows.Forms.Padding(0, 0, 12, 14);
			this.cuentaCorreo.TabIndex = 7;
			this.cuentaCorreo.Name = "cuentaCorreo";
			// 
			// cuentaTelefonoLabel
			// 
			this.cuentaTelefonoLabel.AutoSize = true;
			this.cuentaTelefonoLabel.Text = "Teléfono";
			this.cuentaTelefonoLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.cuentaTelefonoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.cuentaTelefonoLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.cuentaTelefonoLabel.TabIndex = 8;
			this.cuentaTelefonoLabel.Name = "cuentaTelefonoLabel";
			// 
			// cuentaTelefono
			// 
			this.cuentaTelefono.AutoSize = true;
			this.cuentaTelefono.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
			this.cuentaTelefono.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.cuentaTelefono.Text = "-";
			this.cuentaTelefono.Margin = new System.Windows.Forms.Padding(0, 0, 12, 14);
			this.cuentaTelefono.TabIndex = 9;
			this.cuentaTelefono.Name = "cuentaTelefono";
			// 
			// cuentaSeguroLabel
			// 
			this.cuentaSeguroLabel.AutoSize = true;
			this.cuentaSeguroLabel.Text = "Seguro actual";
			this.cuentaSeguroLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.cuentaSeguroLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.cuentaSeguroLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.cuentaSeguroLabel.TabIndex = 10;
			this.cuentaSeguroLabel.Name = "cuentaSeguroLabel";
			// 
			// cuentaSeguro
			// 
			this.cuentaSeguro.AutoSize = true;
			this.cuentaSeguro.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
			this.cuentaSeguro.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.cuentaSeguro.Text = "-";
			this.cuentaSeguro.Margin = new System.Windows.Forms.Padding(0, 0, 12, 14);
			this.cuentaSeguro.TabIndex = 11;
			this.cuentaSeguro.Name = "cuentaSeguro";
			// 
			// cuentaSegurosTitulo
			// 
			this.cuentaSegurosTitulo.AutoSize = true;
			this.cuentaSegurosTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.cuentaSegurosTitulo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.cuentaSegurosTitulo.Text = "Mis pólizas";
			this.cuentaSegurosTitulo.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
			this.cuentaSegurosTitulo.TabIndex = 1;
			this.cuentaSegurosTitulo.Name = "cuentaSegurosTitulo";
			// 
			// cuentaSeguros
			// 
			this.cuentaSeguros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
				this.cuentaSegurosTipoColumna,
	this.cuentaSegurosPolizaColumna,
	this.cuentaSegurosAseguradoraColumna,
	this.cuentaSegurosDesdeColumna,
	this.cuentaSegurosHastaColumna,
	this.cuentaSegurosCoberturaColumna});
			this.cuentaSeguros.AllowUserToAddRows = false;
			this.cuentaSeguros.AllowUserToDeleteRows = false;
			this.cuentaSeguros.AllowUserToResizeRows = false;
			this.cuentaSeguros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.cuentaSeguros.BackgroundColor = System.Drawing.Color.White;
			this.cuentaSeguros.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.cuentaSeguros.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.cuentaSeguros.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.cuentaSeguros.ColumnHeadersHeight = 38;
			this.cuentaSeguros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.cuentaSeguros.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cuentaSeguros.EnableHeadersVisualStyles = false;
			this.cuentaSeguros.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
			this.cuentaSeguros.MultiSelect = false;
			this.cuentaSeguros.ReadOnly = true;
			this.cuentaSeguros.RowHeadersVisible = false;
			this.cuentaSeguros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.cuentaSeguros.RowTemplate.Height = 34;
			this.cuentaSeguros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
			this.cuentaSeguros.DefaultCellStyle = dataGridViewCellStyle8;
			this.cuentaSeguros.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
			this.cuentaSeguros.AutoGenerateColumns = false;
			this.cuentaSeguros.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
			this.cuentaSeguros.TabIndex = 2;
			this.cuentaSeguros.Name = "cuentaSeguros";
			this.cuentaSeguros.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.FormatearSeguroCuenta);
			// 
			// cuentaSegurosTipoColumna
			// 
			this.cuentaSegurosTipoColumna.HeaderText = "Tipo";
			this.cuentaSegurosTipoColumna.MinimumWidth = 90;
			this.cuentaSegurosTipoColumna.Name = "cuentaSegurosTipoColumna";
			this.cuentaSegurosTipoColumna.ReadOnly = true;
			this.cuentaSegurosTipoColumna.DataPropertyName = "Tipo";
			// 
			// cuentaSegurosPolizaColumna
			// 
			this.cuentaSegurosPolizaColumna.HeaderText = "Póliza";
			this.cuentaSegurosPolizaColumna.MinimumWidth = 100;
			this.cuentaSegurosPolizaColumna.Name = "cuentaSegurosPolizaColumna";
			this.cuentaSegurosPolizaColumna.ReadOnly = true;
			this.cuentaSegurosPolizaColumna.DataPropertyName = "Poliza";
			// 
			// cuentaSegurosAseguradoraColumna
			// 
			this.cuentaSegurosAseguradoraColumna.HeaderText = "Aseguradora";
			this.cuentaSegurosAseguradoraColumna.MinimumWidth = 120;
			this.cuentaSegurosAseguradoraColumna.Name = "cuentaSegurosAseguradoraColumna";
			this.cuentaSegurosAseguradoraColumna.ReadOnly = true;
			this.cuentaSegurosAseguradoraColumna.DataPropertyName = "Aseguradora";
			// 
			// cuentaSegurosDesdeColumna
			// 
			this.cuentaSegurosDesdeColumna.HeaderText = "Vigente desde";
			this.cuentaSegurosDesdeColumna.MinimumWidth = 100;
			this.cuentaSegurosDesdeColumna.Name = "cuentaSegurosDesdeColumna";
			this.cuentaSegurosDesdeColumna.ReadOnly = true;
			this.cuentaSegurosDesdeColumna.DataPropertyName = "Desde";
			this.cuentaSegurosDesdeColumna.DefaultCellStyle.Format = "dd/MM/yyyy";
			// 
			// cuentaSegurosHastaColumna
			// 
			this.cuentaSegurosHastaColumna.HeaderText = "Vigente hasta";
			this.cuentaSegurosHastaColumna.MinimumWidth = 100;
			this.cuentaSegurosHastaColumna.Name = "cuentaSegurosHastaColumna";
			this.cuentaSegurosHastaColumna.ReadOnly = true;
			this.cuentaSegurosHastaColumna.DataPropertyName = "Hasta";
			this.cuentaSegurosHastaColumna.DefaultCellStyle.Format = "dd/MM/yyyy";
			// 
			// cuentaSegurosCoberturaColumna
			// 
			this.cuentaSegurosCoberturaColumna.HeaderText = "Tope ARS";
			this.cuentaSegurosCoberturaColumna.MinimumWidth = 100;
			this.cuentaSegurosCoberturaColumna.Name = "cuentaSegurosCoberturaColumna";
			this.cuentaSegurosCoberturaColumna.ReadOnly = true;
			this.cuentaSegurosCoberturaColumna.DataPropertyName = "Cobertura";
			this.cuentaSegurosCoberturaColumna.DefaultCellStyle.Format = "N2";
			// 
			// cuentaAntecedentesTitulo
			// 
			this.cuentaAntecedentesTitulo.AutoSize = true;
			this.cuentaAntecedentesTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.cuentaAntecedentesTitulo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.cuentaAntecedentesTitulo.Text = "Antecedentes";
			this.cuentaAntecedentesTitulo.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
			this.cuentaAntecedentesTitulo.TabIndex = 3;
			this.cuentaAntecedentesTitulo.Name = "cuentaAntecedentesTitulo";
			// 
			// cuentaAntecedentes
			// 
			this.cuentaAntecedentes.BackColor = System.Drawing.Color.White;
			this.cuentaAntecedentes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cuentaAntecedentes.Multiline = true;
			this.cuentaAntecedentes.ReadOnly = true;
			this.cuentaAntecedentes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.cuentaAntecedentes.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
			this.cuentaAntecedentes.TabIndex = 4;
			this.cuentaAntecedentes.Name = "cuentaAntecedentes";
			// 
			// actualizacionTimer
			// 
			this.actualizacionTimer.Interval = 10000;
			this.actualizacionTimer.Tick += new System.EventHandler(this.ActualizacionAutomatica);
			((System.ComponentModel.ISupportInitialize)(this.cuentaSeguros)).EndInit();
			this.cuentaDatos.ResumeLayout(false);
			this.cuentaDatos.PerformLayout();
			this.cuentaTabLayout.ResumeLayout(false);
			this.cuentaTabLayout.PerformLayout();
			this.cuentaTab.ResumeLayout(false);
			this.cuentaTab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.inventario)).EndInit();
			this.accionesInventario.ResumeLayout(false);
			this.accionesInventario.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.reposicion)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tarifa)).EndInit();
			this.editorInventario.ResumeLayout(false);
			this.editorInventario.PerformLayout();
			this.inventarioTabLayout.ResumeLayout(false);
			this.inventarioTabLayout.PerformLayout();
			this.inventarioTab.ResumeLayout(false);
			this.inventarioTab.PerformLayout();
			this.importes.ResumeLayout(false);
			this.importes.PerformLayout();
			this.fechas.ResumeLayout(false);
			this.fechas.PerformLayout();
			this.solicitudTabLayout.ResumeLayout(false);
			this.solicitudTabLayout.PerformLayout();
			this.solicitudTab.ResumeLayout(false);
			this.solicitudTab.PerformLayout();
			this.documentos.ResumeLayout(false);
			this.documentos.PerformLayout();
			this.cancelacion.ResumeLayout(false);
			this.cancelacion.PerformLayout();
			this.entrega.ResumeLayout(false);
			this.entrega.PerformLayout();
			this.pagoPanel.ResumeLayout(false);
			this.pagoPanel.PerformLayout();
			this.aprobacion.ResumeLayout(false);
			this.aprobacion.PerformLayout();
			this.acciones.ResumeLayout(false);
			this.acciones.PerformLayout();
			this.datos.ResumeLayout(false);
			this.datos.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.reservas)).EndInit();
			this.barra.ResumeLayout(false);
			this.barra.PerformLayout();
			this.gestionTabLayout.ResumeLayout(false);
			this.gestionTabLayout.PerformLayout();
			this.gestionTab.ResumeLayout(false);
			this.gestionTab.PerformLayout();
			this.tabs.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
#endregion

		private System.Windows.Forms.TabControl tabs;
		private System.Windows.Forms.TabPage gestionTab;
		private System.Windows.Forms.TableLayoutPanel gestionTabLayout;
		private System.Windows.Forms.TableLayoutPanel barra;
		private System.Windows.Forms.Label avisoActualizacion;
		private System.Windows.Forms.Button actualizarBoton;
		private System.Windows.Forms.DataGridView reservas;
		private System.Windows.Forms.DataGridViewTextBoxColumn reservasIdColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn reservasClienteColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn reservasEstadoColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn reservasDesdeColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn reservasHastaColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn reservasImporteColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn reservasAntecedentesColumna;
		private System.Windows.Forms.TableLayoutPanel datos;
		private System.Windows.Forms.TextBox detalle;
		private System.Windows.Forms.FlowLayoutPanel acciones;
		private System.Windows.Forms.Label accionesNota;
		private System.Windows.Forms.FlowLayoutPanel aprobacion;
		private System.Windows.Forms.Label aprobacionTitulo;
		private System.Windows.Forms.Label revision;
		private System.Windows.Forms.Button revisarBoton;
		private System.Windows.Forms.Button aceptarBoton;
		private System.Windows.Forms.Button rechazarBoton;
		private System.Windows.Forms.FlowLayoutPanel pagoPanel;
		private System.Windows.Forms.Label pagoTitulo;
		private System.Windows.Forms.Label pagoEstado;
		private System.Windows.Forms.Button pagarBoton;
		private System.Windows.Forms.FlowLayoutPanel entrega;
		private System.Windows.Forms.Label entregaTitulo;
		private System.Windows.Forms.CheckBox cotejo;
		private System.Windows.Forms.CheckBox firma;
		private System.Windows.Forms.Button registrarBoton;
		private System.Windows.Forms.FlowLayoutPanel cancelacion;
		private System.Windows.Forms.Label cancelacionTitulo;
		private System.Windows.Forms.Label cancelacionTexto;
		private System.Windows.Forms.Button cancelarBoton;
		private System.Windows.Forms.FlowLayoutPanel documentos;
		private System.Windows.Forms.Label documentosTitulo;
		private System.Windows.Forms.Button remitoBoton;
		private System.Windows.Forms.TabPage solicitudTab;
		private System.Windows.Forms.TableLayoutPanel solicitudTabLayout;
		private System.Windows.Forms.TableLayoutPanel fechas;
		private System.Windows.Forms.Label clienteLabel;
		private System.Windows.Forms.ComboBox cliente;
		private System.Windows.Forms.Label desdeLabel;
		private System.Windows.Forms.DateTimePicker desde;
		private System.Windows.Forms.Label hastaLabel;
		private System.Windows.Forms.DateTimePicker hasta;
		private System.Windows.Forms.Button disponiblesBoton;
		private System.Windows.Forms.ListView unidades;
		private System.Windows.Forms.ColumnHeader unidadesEquipoColumna;
		private System.Windows.Forms.ColumnHeader unidadesTarifaColumna;
		private System.Windows.Forms.TableLayoutPanel importes;
		private System.Windows.Forms.Label cotizacion;
		private System.Windows.Forms.Button solicitarBoton;
		private System.Windows.Forms.Label solicitudNota;
		private System.Windows.Forms.TabPage inventarioTab;
		private System.Windows.Forms.TableLayoutPanel inventarioTabLayout;
		private System.Windows.Forms.TableLayoutPanel editorInventario;
		private System.Windows.Forms.Label codigoLabel;
		private System.Windows.Forms.TextBox codigo;
		private System.Windows.Forms.Label serieLabel;
		private System.Windows.Forms.TextBox serie;
		private System.Windows.Forms.Label categoriaLabel;
		private System.Windows.Forms.TextBox categoria;
		private System.Windows.Forms.Label marcaLabel;
		private System.Windows.Forms.TextBox marca;
		private System.Windows.Forms.Label modeloLabel;
		private System.Windows.Forms.TextBox modelo;
		private System.Windows.Forms.Label tarifaLabel;
		private System.Windows.Forms.NumericUpDown tarifa;
		private System.Windows.Forms.Label reposicionLabel;
		private System.Windows.Forms.NumericUpDown reposicion;
		private System.Windows.Forms.Label estadoLabel;
		private System.Windows.Forms.ComboBox estado;
		private System.Windows.Forms.Label descripcionLabel;
		private System.Windows.Forms.TextBox descripcion;
		private System.Windows.Forms.FlowLayoutPanel accionesInventario;
		private System.Windows.Forms.Button guardarEquipoBoton;
		private System.Windows.Forms.Button nuevoEquipoBoton;
		private System.Windows.Forms.Button actualizarInventarioBoton;
		private System.Windows.Forms.Label unidadNota;
		private System.Windows.Forms.DataGridView inventario;
		private System.Windows.Forms.DataGridViewTextBoxColumn inventarioCodigoColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn inventarioMarcaColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn inventarioModeloColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn inventarioSerieColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn inventarioCategoriaColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn inventarioEstadoColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn inventarioTarifaColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn inventarioReposicionColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn inventarioReacondColumna;
		private System.Windows.Forms.TabPage cuentaTab;
		private System.Windows.Forms.TableLayoutPanel cuentaTabLayout;
		private System.Windows.Forms.TableLayoutPanel cuentaDatos;
		private System.Windows.Forms.Label cuentaUsuarioLabel;
		private System.Windows.Forms.Label cuentaUsuario;
		private System.Windows.Forms.Label cuentaNombreLabel;
		private System.Windows.Forms.Label cuentaNombre;
		private System.Windows.Forms.Label cuentaDocumentoLabel;
		private System.Windows.Forms.Label cuentaDocumento;
		private System.Windows.Forms.Label cuentaCorreoLabel;
		private System.Windows.Forms.Label cuentaCorreo;
		private System.Windows.Forms.Label cuentaTelefonoLabel;
		private System.Windows.Forms.Label cuentaTelefono;
		private System.Windows.Forms.Label cuentaSeguroLabel;
		private System.Windows.Forms.Label cuentaSeguro;
		private System.Windows.Forms.Label cuentaSegurosTitulo;
		private System.Windows.Forms.DataGridView cuentaSeguros;
		private System.Windows.Forms.DataGridViewTextBoxColumn cuentaSegurosTipoColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn cuentaSegurosPolizaColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn cuentaSegurosAseguradoraColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn cuentaSegurosDesdeColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn cuentaSegurosHastaColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn cuentaSegurosCoberturaColumna;
		private System.Windows.Forms.Label cuentaAntecedentesTitulo;
		private System.Windows.Forms.TextBox cuentaAntecedentes;
		private System.Windows.Forms.Timer actualizacionTimer;
	}
}
