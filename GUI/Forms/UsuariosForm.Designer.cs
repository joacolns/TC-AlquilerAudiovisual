namespace GUI
{
	partial class UsuariosForm
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
			this.tabs = new System.Windows.Forms.TabControl();
			this.usuariosTab = new System.Windows.Forms.TabPage();
			this.usuariosTabLayout = new System.Windows.Forms.TableLayoutPanel();
			this.grilla = new System.Windows.Forms.DataGridView();
			this.grillaIdColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.grillaNombreUsuarioColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.grillaNombreColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.grillaCorreoColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.grillaRolColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.grillaActivoColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.grillaSeguroColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.seleccion = new System.Windows.Forms.TableLayoutPanel();
			this.claveUsuarioLabel = new System.Windows.Forms.Label();
			this.rolAsignarLabel = new System.Windows.Forms.Label();
			this.rolAsignar = new System.Windows.Forms.ComboBox();
			this.tipoSeguroActualLabel = new System.Windows.Forms.Label();
			this.tipoSeguroActual = new System.Windows.Forms.ComboBox();
			this.nuevaClaveLabel = new System.Windows.Forms.Label();
			this.nuevaClave = new System.Windows.Forms.TextBox();
			this.repetirClaveLabel = new System.Windows.Forms.Label();
			this.repetirClave = new System.Windows.Forms.TextBox();
			this.rolBoton = new System.Windows.Forms.Button();
			this.guardarSeguroUsuarioBoton = new System.Windows.Forms.Button();
			this.cambiarClaveBoton = new System.Windows.Forms.Button();
			this.altaTab = new System.Windows.Forms.TabPage();
			this.alta = new System.Windows.Forms.TableLayoutPanel();
			this.nombreLabel = new System.Windows.Forms.Label();
			this.nombre = new System.Windows.Forms.TextBox();
			this.claveLabel = new System.Windows.Forms.Label();
			this.clave = new System.Windows.Forms.TextBox();
			this.nombreCompletoLabel = new System.Windows.Forms.Label();
			this.nombreCompleto = new System.Windows.Forms.TextBox();
			this.correoLabel = new System.Windows.Forms.Label();
			this.correo = new System.Windows.Forms.TextBox();
			this.telefonoUsuarioLabel = new System.Windows.Forms.Label();
			this.telefonoUsuario = new System.Windows.Forms.TextBox();
			this.dniUsuarioLabel = new System.Windows.Forms.Label();
			this.dniUsuario = new System.Windows.Forms.TextBox();
			this.rolLabel = new System.Windows.Forms.Label();
			this.rol = new System.Windows.Forms.ComboBox();
			this.tipoSeguroAltaLabel = new System.Windows.Forms.Label();
			this.tipoSeguroAlta = new System.Windows.Forms.ComboBox();
			this.activo = new System.Windows.Forms.CheckBox();
			this.crearBoton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			this.tabs.SuspendLayout();
			this.usuariosTab.SuspendLayout();
			this.usuariosTabLayout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grilla)).BeginInit();
			this.seleccion.SuspendLayout();
			this.altaTab.SuspendLayout();
			this.alta.SuspendLayout();
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
			// 
			// UsuariosForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.ClientSize = new System.Drawing.Size(870, 640);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Controls.Add(this.tabs);
			this.Load += new System.EventHandler(this.UsuariosForm_Load);
			// 
			// tabs
			// 
			this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabs.SelectedIndex = 0;
			this.tabs.ItemSize = new System.Drawing.Size(0, 34);
			this.tabs.Padding = new System.Drawing.Point(20, 6);
			this.tabs.TabIndex = 0;
			this.tabs.Name = "tabs";
			this.tabs.Controls.Add(this.usuariosTab);
			this.tabs.Controls.Add(this.altaTab);
			// 
			// usuariosTab
			// 
			this.usuariosTab.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.usuariosTab.Padding = new System.Windows.Forms.Padding(16, 16, 16, 16);
			this.usuariosTab.Text = "Usuarios";
			this.usuariosTab.UseVisualStyleBackColor = false;
			this.usuariosTab.TabIndex = 0;
			this.usuariosTab.Name = "usuariosTab";
			this.usuariosTab.Controls.Add(this.usuariosTabLayout);
			// 
			// usuariosTabLayout
			// 
			this.usuariosTabLayout.ColumnCount = 1;
			this.usuariosTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.usuariosTabLayout.RowCount = 2;
			this.usuariosTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.usuariosTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.usuariosTabLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.usuariosTabLayout.BackColor = System.Drawing.Color.Transparent;
			this.usuariosTabLayout.TabIndex = 0;
			this.usuariosTabLayout.Name = "usuariosTabLayout";
			this.usuariosTabLayout.Controls.Add(this.grilla, 0, 0);
			this.usuariosTabLayout.Controls.Add(this.seleccion, 0, 1);
			// 
			// grilla
			// 
			this.grilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
				this.grillaIdColumna,
	this.grillaNombreUsuarioColumna,
	this.grillaNombreColumna,
	this.grillaCorreoColumna,
	this.grillaRolColumna,
	this.grillaActivoColumna,
	this.grillaSeguroColumna});
			this.grilla.AllowUserToAddRows = false;
			this.grilla.AllowUserToDeleteRows = false;
			this.grilla.AllowUserToResizeRows = false;
			this.grilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.grilla.BackgroundColor = System.Drawing.Color.White;
			this.grilla.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.grilla.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.grilla.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.grilla.ColumnHeadersHeight = 38;
			this.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.grilla.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grilla.EnableHeadersVisualStyles = false;
			this.grilla.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
			this.grilla.MultiSelect = false;
			this.grilla.ReadOnly = true;
			this.grilla.RowHeadersVisible = false;
			this.grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grilla.RowTemplate.Height = 34;
			this.grilla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.grilla.DefaultCellStyle = dataGridViewCellStyle2;
			this.grilla.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.grilla.AutoGenerateColumns = false;
			this.grilla.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
			this.grilla.TabIndex = 0;
			this.grilla.Name = "grilla";
			this.grilla.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.FormatearGrilla);
			this.grilla.SelectionChanged += new System.EventHandler(this.UsuarioSeleccionadoCambio);
			// 
			// grillaIdColumna
			// 
			this.grillaIdColumna.HeaderText = "N°";
			this.grillaIdColumna.MinimumWidth = 50;
			this.grillaIdColumna.Name = "grillaIdColumna";
			this.grillaIdColumna.ReadOnly = true;
			this.grillaIdColumna.DataPropertyName = "Id";
			// 
			// grillaNombreUsuarioColumna
			// 
			this.grillaNombreUsuarioColumna.HeaderText = "Usuario";
			this.grillaNombreUsuarioColumna.MinimumWidth = 140;
			this.grillaNombreUsuarioColumna.Name = "grillaNombreUsuarioColumna";
			this.grillaNombreUsuarioColumna.ReadOnly = true;
			this.grillaNombreUsuarioColumna.DataPropertyName = "NombreUsuario";
			// 
			// grillaNombreColumna
			// 
			this.grillaNombreColumna.HeaderText = "Nombre";
			this.grillaNombreColumna.MinimumWidth = 130;
			this.grillaNombreColumna.Name = "grillaNombreColumna";
			this.grillaNombreColumna.ReadOnly = true;
			this.grillaNombreColumna.DataPropertyName = "Nombre";
			// 
			// grillaCorreoColumna
			// 
			this.grillaCorreoColumna.HeaderText = "Correo";
			this.grillaCorreoColumna.MinimumWidth = 150;
			this.grillaCorreoColumna.Name = "grillaCorreoColumna";
			this.grillaCorreoColumna.ReadOnly = true;
			this.grillaCorreoColumna.DataPropertyName = "Email";
			// 
			// grillaRolColumna
			// 
			this.grillaRolColumna.HeaderText = "Rol";
			this.grillaRolColumna.MinimumWidth = 120;
			this.grillaRolColumna.Name = "grillaRolColumna";
			this.grillaRolColumna.ReadOnly = true;
			this.grillaRolColumna.DataPropertyName = "Rol";
			// 
			// grillaActivoColumna
			// 
			this.grillaActivoColumna.HeaderText = "Activo";
			this.grillaActivoColumna.MinimumWidth = 70;
			this.grillaActivoColumna.Name = "grillaActivoColumna";
			this.grillaActivoColumna.ReadOnly = true;
			this.grillaActivoColumna.DataPropertyName = "Activo";
			// 
			// grillaSeguroColumna
			// 
			this.grillaSeguroColumna.HeaderText = "Seguro";
			this.grillaSeguroColumna.MinimumWidth = 100;
			this.grillaSeguroColumna.Name = "grillaSeguroColumna";
			this.grillaSeguroColumna.ReadOnly = true;
			this.grillaSeguroColumna.DataPropertyName = "TipoSeguro";
			// 
			// seleccion
			// 
			this.seleccion.ColumnCount = 4;
			this.seleccion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.seleccion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.seleccion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.seleccion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.seleccion.RowCount = 4;
			this.seleccion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.seleccion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.seleccion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.seleccion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.seleccion.AutoSize = true;
			this.seleccion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.seleccion.BackColor = System.Drawing.Color.White;
			this.seleccion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.seleccion.Padding = new System.Windows.Forms.Padding(18, 18, 18, 8);
			this.seleccion.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
			this.seleccion.TabIndex = 1;
			this.seleccion.Name = "seleccion";
			this.seleccion.Controls.Add(this.claveUsuarioLabel, 0, 0);
			this.seleccion.SetColumnSpan(this.claveUsuarioLabel, 4);
			this.seleccion.Controls.Add(this.rolAsignarLabel, 0, 1);
			this.seleccion.Controls.Add(this.rolAsignar, 0, 2);
			this.seleccion.Controls.Add(this.tipoSeguroActualLabel, 1, 1);
			this.seleccion.Controls.Add(this.tipoSeguroActual, 1, 2);
			this.seleccion.Controls.Add(this.nuevaClaveLabel, 2, 1);
			this.seleccion.Controls.Add(this.nuevaClave, 2, 2);
			this.seleccion.Controls.Add(this.repetirClaveLabel, 3, 1);
			this.seleccion.Controls.Add(this.repetirClave, 3, 2);
			this.seleccion.Controls.Add(this.rolBoton, 0, 3);
			this.seleccion.Controls.Add(this.guardarSeguroUsuarioBoton, 1, 3);
			this.seleccion.Controls.Add(this.cambiarClaveBoton, 2, 3);
			this.seleccion.SetColumnSpan(this.cambiarClaveBoton, 2);
			// 
			// claveUsuarioLabel
			// 
			this.claveUsuarioLabel.AutoSize = true;
			this.claveUsuarioLabel.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
			this.claveUsuarioLabel.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.claveUsuarioLabel.Text = "Seleccioná un usuario de la lista.";
			this.claveUsuarioLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
			this.claveUsuarioLabel.TabIndex = 0;
			this.claveUsuarioLabel.Name = "claveUsuarioLabel";
			// 
			// rolAsignarLabel
			// 
			this.rolAsignarLabel.AutoSize = true;
			this.rolAsignarLabel.Text = "Rol";
			this.rolAsignarLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.rolAsignarLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.rolAsignarLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.rolAsignarLabel.TabIndex = 1;
			this.rolAsignarLabel.Name = "rolAsignarLabel";
			// 
			// rolAsignar
			// 
			this.rolAsignar.Items.AddRange(new object[] {
				"Cliente",
	"EncargadoStock",
	"Administrador",
	"Tecnico"});
			this.rolAsignar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rolAsignar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.rolAsignar.FormattingEnabled = true;
			this.rolAsignar.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.rolAsignar.TabIndex = 2;
			this.rolAsignar.Name = "rolAsignar";
			this.rolAsignar.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.FormatearRol);
			// 
			// tipoSeguroActualLabel
			// 
			this.tipoSeguroActualLabel.AutoSize = true;
			this.tipoSeguroActualLabel.Text = "Seguro (clientes y administradores)";
			this.tipoSeguroActualLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.tipoSeguroActualLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.tipoSeguroActualLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.tipoSeguroActualLabel.TabIndex = 3;
			this.tipoSeguroActualLabel.Name = "tipoSeguroActualLabel";
			// 
			// tipoSeguroActual
			// 
			this.tipoSeguroActual.Items.AddRange(new object[] {
				"SinSeguro",
	"Basico",
	"Intermedio",
	"Completo"});
			this.tipoSeguroActual.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tipoSeguroActual.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tipoSeguroActual.FormattingEnabled = true;
			this.tipoSeguroActual.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.tipoSeguroActual.Enabled = false;
			this.tipoSeguroActual.TabIndex = 4;
			this.tipoSeguroActual.Name = "tipoSeguroActual";
			this.tipoSeguroActual.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.FormatearTipoSeguro);
			// 
			// nuevaClaveLabel
			// 
			this.nuevaClaveLabel.AutoSize = true;
			this.nuevaClaveLabel.Text = "Nueva contraseña (8 a 128)";
			this.nuevaClaveLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.nuevaClaveLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.nuevaClaveLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.nuevaClaveLabel.TabIndex = 5;
			this.nuevaClaveLabel.Name = "nuevaClaveLabel";
			// 
			// nuevaClave
			// 
			this.nuevaClave.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nuevaClave.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.nuevaClave.MaxLength = 128;
			this.nuevaClave.UseSystemPasswordChar = true;
			this.nuevaClave.TabIndex = 6;
			this.nuevaClave.Name = "nuevaClave";
			// 
			// repetirClaveLabel
			// 
			this.repetirClaveLabel.AutoSize = true;
			this.repetirClaveLabel.Text = "Repetir contraseña";
			this.repetirClaveLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.repetirClaveLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.repetirClaveLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.repetirClaveLabel.TabIndex = 7;
			this.repetirClaveLabel.Name = "repetirClaveLabel";
			// 
			// repetirClave
			// 
			this.repetirClave.Dock = System.Windows.Forms.DockStyle.Fill;
			this.repetirClave.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.repetirClave.MaxLength = 128;
			this.repetirClave.UseSystemPasswordChar = true;
			this.repetirClave.TabIndex = 8;
			this.repetirClave.Name = "repetirClave";
			// 
			// rolBoton
			// 
			this.rolBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.rolBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rolBoton.Size = new System.Drawing.Size(100, 38);
			this.rolBoton.Margin = new System.Windows.Forms.Padding(0, 0, 12, 8);
			this.rolBoton.Text = "Asignar rol";
			this.rolBoton.UseVisualStyleBackColor = false;
			this.rolBoton.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
			this.rolBoton.ForeColor = System.Drawing.Color.White;
			this.rolBoton.FlatAppearance.BorderSize = 0;
			this.rolBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(29, 78, 216);
			this.rolBoton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.rolBoton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rolBoton.TabIndex = 9;
			this.rolBoton.Name = "rolBoton";
			this.rolBoton.Click += new System.EventHandler(this.AsignarClick);
			// 
			// guardarSeguroUsuarioBoton
			// 
			this.guardarSeguroUsuarioBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.guardarSeguroUsuarioBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.guardarSeguroUsuarioBoton.Size = new System.Drawing.Size(100, 38);
			this.guardarSeguroUsuarioBoton.Margin = new System.Windows.Forms.Padding(0, 0, 12, 8);
			this.guardarSeguroUsuarioBoton.Text = "Guardar seguro";
			this.guardarSeguroUsuarioBoton.UseVisualStyleBackColor = false;
			this.guardarSeguroUsuarioBoton.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
			this.guardarSeguroUsuarioBoton.ForeColor = System.Drawing.Color.White;
			this.guardarSeguroUsuarioBoton.FlatAppearance.BorderSize = 0;
			this.guardarSeguroUsuarioBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(29, 78, 216);
			this.guardarSeguroUsuarioBoton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.guardarSeguroUsuarioBoton.Enabled = false;
			this.guardarSeguroUsuarioBoton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.guardarSeguroUsuarioBoton.TabIndex = 10;
			this.guardarSeguroUsuarioBoton.Name = "guardarSeguroUsuarioBoton";
			this.guardarSeguroUsuarioBoton.Click += new System.EventHandler(this.ConfigurarSeguroClick);
			// 
			// cambiarClaveBoton
			// 
			this.cambiarClaveBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cambiarClaveBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cambiarClaveBoton.Size = new System.Drawing.Size(100, 38);
			this.cambiarClaveBoton.Margin = new System.Windows.Forms.Padding(0, 0, 12, 8);
			this.cambiarClaveBoton.Text = "Cambiar contraseña";
			this.cambiarClaveBoton.UseVisualStyleBackColor = false;
			this.cambiarClaveBoton.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
			this.cambiarClaveBoton.ForeColor = System.Drawing.Color.White;
			this.cambiarClaveBoton.FlatAppearance.BorderSize = 0;
			this.cambiarClaveBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(29, 78, 216);
			this.cambiarClaveBoton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.cambiarClaveBoton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cambiarClaveBoton.TabIndex = 11;
			this.cambiarClaveBoton.Name = "cambiarClaveBoton";
			this.cambiarClaveBoton.Click += new System.EventHandler(this.CambiarClaveClick);
			// 
			// altaTab
			// 
			this.altaTab.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.altaTab.Padding = new System.Windows.Forms.Padding(16, 16, 16, 16);
			this.altaTab.Text = "Nuevo usuario";
			this.altaTab.UseVisualStyleBackColor = false;
			this.altaTab.TabIndex = 1;
			this.altaTab.Name = "altaTab";
			this.altaTab.Controls.Add(this.alta);
			// 
			// alta
			// 
			this.alta.ColumnCount = 2;
			this.alta.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270F));
			this.alta.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270F));
			this.alta.RowCount = 10;
			this.alta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.alta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.alta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.alta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.alta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.alta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.alta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.alta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.alta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.alta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.alta.AutoSize = true;
			this.alta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.alta.BackColor = System.Drawing.Color.White;
			this.alta.Dock = System.Windows.Forms.DockStyle.None;
			this.alta.Padding = new System.Windows.Forms.Padding(18, 18, 18, 8);
			this.alta.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
			this.alta.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
			this.alta.Location = new System.Drawing.Point(0, 0);
			this.alta.TabIndex = 0;
			this.alta.Name = "alta";
			this.alta.Controls.Add(this.nombreLabel, 0, 0);
			this.alta.Controls.Add(this.nombre, 0, 1);
			this.alta.Controls.Add(this.claveLabel, 1, 0);
			this.alta.Controls.Add(this.clave, 1, 1);
			this.alta.Controls.Add(this.nombreCompletoLabel, 0, 2);
			this.alta.Controls.Add(this.nombreCompleto, 0, 3);
			this.alta.Controls.Add(this.correoLabel, 1, 2);
			this.alta.Controls.Add(this.correo, 1, 3);
			this.alta.Controls.Add(this.telefonoUsuarioLabel, 0, 4);
			this.alta.Controls.Add(this.telefonoUsuario, 0, 5);
			this.alta.Controls.Add(this.dniUsuarioLabel, 1, 4);
			this.alta.Controls.Add(this.dniUsuario, 1, 5);
			this.alta.Controls.Add(this.rolLabel, 0, 6);
			this.alta.Controls.Add(this.rol, 0, 7);
			this.alta.Controls.Add(this.tipoSeguroAltaLabel, 1, 6);
			this.alta.Controls.Add(this.tipoSeguroAlta, 1, 7);
			this.alta.Controls.Add(this.activo, 0, 8);
			this.alta.SetColumnSpan(this.activo, 2);
			this.alta.Controls.Add(this.crearBoton, 0, 9);
			this.alta.SetColumnSpan(this.crearBoton, 2);
			// 
			// nombreLabel
			// 
			this.nombreLabel.AutoSize = true;
			this.nombreLabel.Text = "Usuario *";
			this.nombreLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.nombreLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.nombreLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.nombreLabel.TabIndex = 0;
			this.nombreLabel.Name = "nombreLabel";
			// 
			// nombre
			// 
			this.nombre.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nombre.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.nombre.MaxLength = 50;
			this.nombre.TabIndex = 1;
			this.nombre.Name = "nombre";
			// 
			// claveLabel
			// 
			this.claveLabel.AutoSize = true;
			this.claveLabel.Text = "Contraseña * (8 a 128 caracteres)";
			this.claveLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.claveLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.claveLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.claveLabel.TabIndex = 2;
			this.claveLabel.Name = "claveLabel";
			// 
			// clave
			// 
			this.clave.Dock = System.Windows.Forms.DockStyle.Fill;
			this.clave.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.clave.MaxLength = 128;
			this.clave.UseSystemPasswordChar = true;
			this.clave.TabIndex = 3;
			this.clave.Name = "clave";
			// 
			// nombreCompletoLabel
			// 
			this.nombreCompletoLabel.AutoSize = true;
			this.nombreCompletoLabel.Text = "Nombre completo *";
			this.nombreCompletoLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.nombreCompletoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.nombreCompletoLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.nombreCompletoLabel.TabIndex = 4;
			this.nombreCompletoLabel.Name = "nombreCompletoLabel";
			// 
			// nombreCompleto
			// 
			this.nombreCompleto.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nombreCompleto.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.nombreCompleto.MaxLength = 100;
			this.nombreCompleto.TabIndex = 5;
			this.nombreCompleto.Name = "nombreCompleto";
			// 
			// correoLabel
			// 
			this.correoLabel.AutoSize = true;
			this.correoLabel.Text = "Correo *";
			this.correoLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.correoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.correoLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.correoLabel.TabIndex = 6;
			this.correoLabel.Name = "correoLabel";
			// 
			// correo
			// 
			this.correo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.correo.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.correo.MaxLength = 150;
			this.correo.TabIndex = 7;
			this.correo.Name = "correo";
			// 
			// telefonoUsuarioLabel
			// 
			this.telefonoUsuarioLabel.AutoSize = true;
			this.telefonoUsuarioLabel.Text = "Teléfono *";
			this.telefonoUsuarioLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.telefonoUsuarioLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.telefonoUsuarioLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.telefonoUsuarioLabel.TabIndex = 8;
			this.telefonoUsuarioLabel.Name = "telefonoUsuarioLabel";
			// 
			// telefonoUsuario
			// 
			this.telefonoUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
			this.telefonoUsuario.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.telefonoUsuario.MaxLength = 30;
			this.telefonoUsuario.TabIndex = 9;
			this.telefonoUsuario.Name = "telefonoUsuario";
			// 
			// dniUsuarioLabel
			// 
			this.dniUsuarioLabel.AutoSize = true;
			this.dniUsuarioLabel.Text = "DNI / CUIT *";
			this.dniUsuarioLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.dniUsuarioLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.dniUsuarioLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.dniUsuarioLabel.TabIndex = 10;
			this.dniUsuarioLabel.Name = "dniUsuarioLabel";
			// 
			// dniUsuario
			// 
			this.dniUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dniUsuario.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.dniUsuario.MaxLength = 13;
			this.dniUsuario.TabIndex = 11;
			this.dniUsuario.Name = "dniUsuario";
			// 
			// rolLabel
			// 
			this.rolLabel.AutoSize = true;
			this.rolLabel.Text = "Rol *";
			this.rolLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.rolLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.rolLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.rolLabel.TabIndex = 12;
			this.rolLabel.Name = "rolLabel";
			// 
			// rol
			// 
			this.rol.Items.AddRange(new object[] {
				"Cliente",
	"EncargadoStock",
	"Administrador",
	"Tecnico"});
			this.rol.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.rol.FormattingEnabled = true;
			this.rol.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.rol.TabIndex = 13;
			this.rol.Name = "rol";
			this.rol.SelectedIndexChanged += new System.EventHandler(this.RolAltaCambio);
			this.rol.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.FormatearRol);
			// 
			// tipoSeguroAltaLabel
			// 
			this.tipoSeguroAltaLabel.AutoSize = true;
			this.tipoSeguroAltaLabel.Text = "Seguro inicial";
			this.tipoSeguroAltaLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.tipoSeguroAltaLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.tipoSeguroAltaLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.tipoSeguroAltaLabel.TabIndex = 14;
			this.tipoSeguroAltaLabel.Name = "tipoSeguroAltaLabel";
			// 
			// tipoSeguroAlta
			// 
			this.tipoSeguroAlta.Items.AddRange(new object[] {
				"SinSeguro",
	"Basico",
	"Intermedio",
	"Completo"});
			this.tipoSeguroAlta.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tipoSeguroAlta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tipoSeguroAlta.FormattingEnabled = true;
			this.tipoSeguroAlta.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
			this.tipoSeguroAlta.TabIndex = 15;
			this.tipoSeguroAlta.Name = "tipoSeguroAlta";
			this.tipoSeguroAlta.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.FormatearTipoSeguro);
			// 
			// activo
			// 
			this.activo.AutoSize = true;
			this.activo.Text = "Usuario activo";
			this.activo.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.activo.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
			this.activo.UseVisualStyleBackColor = true;
			this.activo.Checked = true;
			this.activo.TabIndex = 16;
			this.activo.Name = "activo";
			// 
			// crearBoton
			// 
			this.crearBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.crearBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.crearBoton.Size = new System.Drawing.Size(200, 38);
			this.crearBoton.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
			this.crearBoton.Text = "Crear usuario";
			this.crearBoton.UseVisualStyleBackColor = false;
			this.crearBoton.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
			this.crearBoton.ForeColor = System.Drawing.Color.White;
			this.crearBoton.FlatAppearance.BorderSize = 0;
			this.crearBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(29, 78, 216);
			this.crearBoton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.crearBoton.TabIndex = 17;
			this.crearBoton.Name = "crearBoton";
			this.crearBoton.Click += new System.EventHandler(this.GuardarClick);
			this.alta.ResumeLayout(false);
			this.alta.PerformLayout();
			this.altaTab.ResumeLayout(false);
			this.altaTab.PerformLayout();
			this.seleccion.ResumeLayout(false);
			this.seleccion.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grilla)).EndInit();
			this.usuariosTabLayout.ResumeLayout(false);
			this.usuariosTabLayout.PerformLayout();
			this.usuariosTab.ResumeLayout(false);
			this.usuariosTab.PerformLayout();
			this.tabs.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
#endregion

		private System.Windows.Forms.TabControl tabs;
		private System.Windows.Forms.TabPage usuariosTab;
		private System.Windows.Forms.TableLayoutPanel usuariosTabLayout;
		private System.Windows.Forms.DataGridView grilla;
		private System.Windows.Forms.DataGridViewTextBoxColumn grillaIdColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn grillaNombreUsuarioColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn grillaNombreColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn grillaCorreoColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn grillaRolColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn grillaActivoColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn grillaSeguroColumna;
		private System.Windows.Forms.TableLayoutPanel seleccion;
		private System.Windows.Forms.Label claveUsuarioLabel;
		private System.Windows.Forms.Label rolAsignarLabel;
		private System.Windows.Forms.ComboBox rolAsignar;
		private System.Windows.Forms.Label tipoSeguroActualLabel;
		private System.Windows.Forms.ComboBox tipoSeguroActual;
		private System.Windows.Forms.Label nuevaClaveLabel;
		private System.Windows.Forms.TextBox nuevaClave;
		private System.Windows.Forms.Label repetirClaveLabel;
		private System.Windows.Forms.TextBox repetirClave;
		private System.Windows.Forms.Button rolBoton;
		private System.Windows.Forms.Button guardarSeguroUsuarioBoton;
		private System.Windows.Forms.Button cambiarClaveBoton;
		private System.Windows.Forms.TabPage altaTab;
		private System.Windows.Forms.TableLayoutPanel alta;
		private System.Windows.Forms.Label nombreLabel;
		private System.Windows.Forms.TextBox nombre;
		private System.Windows.Forms.Label claveLabel;
		private System.Windows.Forms.TextBox clave;
		private System.Windows.Forms.Label nombreCompletoLabel;
		private System.Windows.Forms.TextBox nombreCompleto;
		private System.Windows.Forms.Label correoLabel;
		private System.Windows.Forms.TextBox correo;
		private System.Windows.Forms.Label telefonoUsuarioLabel;
		private System.Windows.Forms.TextBox telefonoUsuario;
		private System.Windows.Forms.Label dniUsuarioLabel;
		private System.Windows.Forms.TextBox dniUsuario;
		private System.Windows.Forms.Label rolLabel;
		private System.Windows.Forms.ComboBox rol;
		private System.Windows.Forms.Label tipoSeguroAltaLabel;
		private System.Windows.Forms.ComboBox tipoSeguroAlta;
		private System.Windows.Forms.CheckBox activo;
		private System.Windows.Forms.Button crearBoton;
	}
}
