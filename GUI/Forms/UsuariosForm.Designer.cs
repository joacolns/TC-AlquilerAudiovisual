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
			this.alta = new System.Windows.Forms.FlowLayoutPanel();
			this.altaLabel = new System.Windows.Forms.Label();
			this.nombre = new System.Windows.Forms.TextBox();
			this.clave = new System.Windows.Forms.TextBox();
			this.rol = new System.Windows.Forms.ComboBox();
			this.activo = new System.Windows.Forms.CheckBox();
			this.crearBoton = new System.Windows.Forms.Button();
			this.rolBoton = new System.Windows.Forms.Button();
			this.grilla = new System.Windows.Forms.DataGridView();
			this.cambioClavePanel = new System.Windows.Forms.Panel();
			this.claveUsuarioLabel = new System.Windows.Forms.Label();
			this.nuevaClaveCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.nuevaClaveLabel = new System.Windows.Forms.Label();
			this.nuevaClave = new System.Windows.Forms.TextBox();
			this.repetirClaveCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.repetirClaveLabel = new System.Windows.Forms.Label();
			this.repetirClave = new System.Windows.Forms.TextBox();
			this.cambiarClaveBoton = new System.Windows.Forms.Button();
			this.altaSeguroCampo = new System.Windows.Forms.FlowLayoutPanel();
			this.altaSeguroLabel = new System.Windows.Forms.Label();
			this.tipoSeguroAlta = new System.Windows.Forms.ComboBox();
			this.seguroUsuarioPanel = new System.Windows.Forms.Panel();
			this.seguroUsuarioLabel = new System.Windows.Forms.Label();
			this.tipoSeguroActual = new System.Windows.Forms.ComboBox();
			this.guardarSeguroUsuarioBoton = new System.Windows.Forms.Button();
			this.alta.SuspendLayout();
			this.cambioClavePanel.SuspendLayout();
			this.nuevaClaveCampo.SuspendLayout();
			this.repetirClaveCampo.SuspendLayout();
			this.altaSeguroCampo.SuspendLayout();
			this.seguroUsuarioPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grilla)).BeginInit();
			this.SuspendLayout();
			//
			// alta
			//
			this.alta.Controls.Add(this.altaLabel);
			this.alta.Controls.Add(this.nombre);
			this.alta.Controls.Add(this.clave);
			this.alta.Controls.Add(this.rol);
			this.alta.Controls.Add(this.activo);
			this.alta.Controls.Add(this.crearBoton);
			this.alta.Controls.Add(this.rolBoton);
			this.alta.Controls.Add(this.altaSeguroCampo);
			this.alta.Dock = System.Windows.Forms.DockStyle.Top;
			this.alta.Location = new System.Drawing.Point(0, 0);
			this.alta.Name = "alta";
			this.alta.Padding = new System.Windows.Forms.Padding(12);
			this.alta.Size = new System.Drawing.Size(900, 150);
			this.alta.TabIndex = 1;
			//
			// altaLabel
			//
			this.altaLabel.AutoSize = true;
			this.altaLabel.Location = new System.Drawing.Point(15, 12);
			this.altaLabel.Name = "altaLabel";
			this.altaLabel.Size = new System.Drawing.Size(194, 19);
			this.altaLabel.TabIndex = 0;
			this.altaLabel.Text = "Alta: usuario / contraseña / rol";
			//
			// nombre
			//
			this.nombre.Location = new System.Drawing.Point(215, 15);
			this.nombre.MaxLength = 50;
			this.nombre.Name = "nombre";
			this.nombre.Size = new System.Drawing.Size(160, 25);
			this.nombre.TabIndex = 1;
			//
			// clave
			//
			this.clave.Location = new System.Drawing.Point(381, 15);
			this.clave.MaxLength = 128;
			this.clave.Name = "clave";
			this.clave.Size = new System.Drawing.Size(160, 25);
			this.clave.TabIndex = 2;
			this.clave.UseSystemPasswordChar = true;
			//
			// rol
			//
			this.rol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.rol.FormattingEnabled = true;
			this.rol.Items.AddRange(new object[] { "Cliente", "EncargadoStock", "Administrador", "Tecnico" });
			this.rol.Location = new System.Drawing.Point(547, 15);
			this.rol.Name = "rol";
			this.rol.Size = new System.Drawing.Size(160, 25);
			this.rol.TabIndex = 3;
			this.rol.SelectedIndex = 0;
			this.rol.SelectedIndexChanged += new System.EventHandler(this.RolAltaCambio);
			//
			// activo
			//
			this.activo.AutoSize = true;
			this.activo.Checked = true;
			this.activo.CheckState = System.Windows.Forms.CheckState.Checked;
			this.activo.Location = new System.Drawing.Point(713, 15);
			this.activo.Name = "activo";
			this.activo.Size = new System.Drawing.Size(66, 23);
			this.activo.TabIndex = 4;
			this.activo.Text = "Activo";
			//
			// crearBoton
			//
			this.crearBoton.AutoSize = true;
			this.crearBoton.Location = new System.Drawing.Point(15, 46);
			this.crearBoton.Name = "crearBoton";
			this.crearBoton.Size = new System.Drawing.Size(120, 36);
			this.crearBoton.TabIndex = 5;
			this.crearBoton.Text = "Crear usuario";
			this.crearBoton.UseVisualStyleBackColor = true;
			this.crearBoton.Click += new System.EventHandler(this.GuardarClick);
			//
			// rolBoton
			//
			this.rolBoton.AutoSize = true;
			this.rolBoton.Location = new System.Drawing.Point(141, 46);
			this.rolBoton.Name = "rolBoton";
			this.rolBoton.Size = new System.Drawing.Size(177, 36);
			this.rolBoton.TabIndex = 6;
			this.rolBoton.Text = "Asignar rol a seleccionado";
			this.rolBoton.UseVisualStyleBackColor = true;
			this.rolBoton.Click += new System.EventHandler(this.AsignarClick);
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
			this.grilla.Location = new System.Drawing.Point(0, 120);
			this.grilla.MultiSelect = false;
			this.grilla.Name = "grilla";
			this.grilla.ReadOnly = true;
			this.grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grilla.Size = new System.Drawing.Size(900, 350);
			this.grilla.TabIndex = 0;
			this.grilla.SelectionChanged += new System.EventHandler(this.UsuarioSeleccionadoCambio);
			this.grilla.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.FormatearSeguroGrilla);
			//
			// cambioClavePanel
			//
			this.cambioClavePanel.Name = "cambioClavePanel";
			this.cambioClavePanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.cambioClavePanel.Padding = new System.Windows.Forms.Padding(12);
			this.cambioClavePanel.Size = new System.Drawing.Size(900, 130);
			this.cambioClavePanel.TabIndex = 2;
			this.cambioClavePanel.Controls.Add(this.claveUsuarioLabel);
			this.cambioClavePanel.Controls.Add(this.nuevaClaveCampo);
			this.cambioClavePanel.Controls.Add(this.repetirClaveCampo);
			this.cambioClavePanel.Controls.Add(this.cambiarClaveBoton);
			this.claveUsuarioLabel.Name = "claveUsuarioLabel";
			this.claveUsuarioLabel.Location = new System.Drawing.Point(12, 12);
			this.claveUsuarioLabel.AutoSize = true;
			this.claveUsuarioLabel.Text = "Seleccioná un usuario de la lista para cambiar su contraseña.";
			this.nuevaClaveCampo.Name = "nuevaClaveCampo";
			this.nuevaClaveCampo.Location = new System.Drawing.Point(12, 42);
			this.nuevaClaveCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.nuevaClaveCampo.Size = new System.Drawing.Size(240, 65);
			this.nuevaClaveCampo.Controls.Add(this.nuevaClaveLabel);
			this.nuevaClaveCampo.Controls.Add(this.nuevaClave);
			this.nuevaClaveLabel.Name = "nuevaClaveLabel";
			this.nuevaClaveLabel.Text = "Nueva contraseña (8 a 128)";
			this.nuevaClaveLabel.AutoSize = true;
			this.nuevaClave.Name = "nuevaClave";
			this.nuevaClave.Size = new System.Drawing.Size(220, 25);
			this.nuevaClave.MaxLength = 128;
			this.nuevaClave.UseSystemPasswordChar = true;
			this.nuevaClave.TabIndex = 0;
			this.repetirClaveCampo.Name = "repetirClaveCampo";
			this.repetirClaveCampo.Location = new System.Drawing.Point(258, 42);
			this.repetirClaveCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.repetirClaveCampo.Size = new System.Drawing.Size(240, 65);
			this.repetirClaveCampo.Controls.Add(this.repetirClaveLabel);
			this.repetirClaveCampo.Controls.Add(this.repetirClave);
			this.repetirClaveLabel.Name = "repetirClaveLabel";
			this.repetirClaveLabel.Text = "Repetir contraseña";
			this.repetirClaveLabel.AutoSize = true;
			this.repetirClave.Name = "repetirClave";
			this.repetirClave.Size = new System.Drawing.Size(220, 25);
			this.repetirClave.MaxLength = 128;
			this.repetirClave.UseSystemPasswordChar = true;
			this.repetirClave.TabIndex = 1;
			this.cambiarClaveBoton.Name = "cambiarClaveBoton";
			this.cambiarClaveBoton.Location = new System.Drawing.Point(516, 60);
			this.cambiarClaveBoton.AutoSize = true;
			this.cambiarClaveBoton.Size = new System.Drawing.Size(170, 36);
			this.cambiarClaveBoton.Margin = new System.Windows.Forms.Padding(12, 25, 3, 3);
			this.cambiarClaveBoton.Text = "Cambiar contraseña";
			this.cambiarClaveBoton.TabIndex = 2;
			this.cambiarClaveBoton.UseVisualStyleBackColor = true;
			this.cambiarClaveBoton.Click += new System.EventHandler(this.CambiarClaveClick);
			//
			// Seguro del usuario: selección en alta y edición de cliente
			//
			this.altaSeguroCampo.Name = "altaSeguroCampo";
			this.altaSeguroCampo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.altaSeguroCampo.Size = new System.Drawing.Size(255, 65);
			this.altaSeguroCampo.Controls.Add(this.altaSeguroLabel);
			this.altaSeguroCampo.Controls.Add(this.tipoSeguroAlta);
			this.altaSeguroLabel.Name = "altaSeguroLabel";
			this.altaSeguroLabel.AutoSize = true;
			this.altaSeguroLabel.Text = "Seguro al crear (cliente)";
			this.tipoSeguroAlta.Name = "tipoSeguroAlta";
			this.tipoSeguroAlta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tipoSeguroAlta.Size = new System.Drawing.Size(235, 25);
			this.tipoSeguroAlta.FormattingEnabled = true;
			this.tipoSeguroAlta.Items.AddRange(new object[] { "SinSeguro", "Basico", "Intermedio", "Completo" });
			this.tipoSeguroAlta.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.FormatearTipoSeguro);
			this.tipoSeguroAlta.SelectedIndex = 0;
			this.seguroUsuarioPanel.Name = "seguroUsuarioPanel";
			this.seguroUsuarioPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.seguroUsuarioPanel.Size = new System.Drawing.Size(900, 110);
			this.seguroUsuarioPanel.Controls.Add(this.seguroUsuarioLabel);
			this.seguroUsuarioPanel.Controls.Add(this.tipoSeguroActual);
			this.seguroUsuarioPanel.Controls.Add(this.guardarSeguroUsuarioBoton);
			this.seguroUsuarioLabel.Name = "seguroUsuarioLabel";
			this.seguroUsuarioLabel.Location = new System.Drawing.Point(12, 12);
			this.seguroUsuarioLabel.AutoSize = true;
			this.seguroUsuarioLabel.Text = "Seleccioná un cliente de la lista para cambiar su seguro.";
			this.tipoSeguroActual.Name = "tipoSeguroActual";
			this.tipoSeguroActual.Location = new System.Drawing.Point(12, 42);
			this.tipoSeguroActual.Size = new System.Drawing.Size(235, 25);
			this.tipoSeguroActual.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tipoSeguroActual.FormattingEnabled = true;
			this.tipoSeguroActual.Items.AddRange(new object[] { "SinSeguro", "Basico", "Intermedio", "Completo" });
			this.tipoSeguroActual.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.FormatearTipoSeguro);
			this.tipoSeguroActual.SelectedIndex = 0;
			this.guardarSeguroUsuarioBoton.Name = "guardarSeguroUsuarioBoton";
			this.guardarSeguroUsuarioBoton.Location = new System.Drawing.Point(258, 38);
			this.guardarSeguroUsuarioBoton.Size = new System.Drawing.Size(160, 36);
			this.guardarSeguroUsuarioBoton.Text = "Guardar seguro";
			this.guardarSeguroUsuarioBoton.UseVisualStyleBackColor = true;
			this.guardarSeguroUsuarioBoton.Click += new System.EventHandler(this.ConfigurarSeguroClick);
			//
			// UsuariosForm
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(900, 720);
			this.Controls.Add(this.grilla);
			this.Controls.Add(this.seguroUsuarioPanel);
			this.Controls.Add(this.cambioClavePanel);
			this.Controls.Add(this.alta);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.Name = "UsuariosForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Usuarios y roles";
			this.Shown += new System.EventHandler(this.CargarClick);
			this.alta.ResumeLayout(false);
			this.alta.PerformLayout();
			this.nuevaClaveCampo.ResumeLayout(false);
			this.nuevaClaveCampo.PerformLayout();
			this.repetirClaveCampo.ResumeLayout(false);
			this.repetirClaveCampo.PerformLayout();
			this.cambioClavePanel.ResumeLayout(false);
			this.cambioClavePanel.PerformLayout();
			this.altaSeguroCampo.ResumeLayout(false);
			this.altaSeguroCampo.PerformLayout();
			this.seguroUsuarioPanel.ResumeLayout(false);
			this.seguroUsuarioPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grilla)).EndInit();
			this.ResumeLayout(false);
		}

#endregion
		private System.Windows.Forms.FlowLayoutPanel alta;
		private System.Windows.Forms.Label altaLabel;
		private System.Windows.Forms.TextBox nombre;
		private System.Windows.Forms.TextBox clave;
		private System.Windows.Forms.ComboBox rol;
		private System.Windows.Forms.CheckBox activo;
		private System.Windows.Forms.Button crearBoton;
		private System.Windows.Forms.Button rolBoton;
		private System.Windows.Forms.DataGridView grilla;
		private System.Windows.Forms.Panel cambioClavePanel;
		private System.Windows.Forms.Label claveUsuarioLabel;
		private System.Windows.Forms.FlowLayoutPanel nuevaClaveCampo;
		private System.Windows.Forms.Label nuevaClaveLabel;
		private System.Windows.Forms.TextBox nuevaClave;
		private System.Windows.Forms.FlowLayoutPanel repetirClaveCampo;
		private System.Windows.Forms.Label repetirClaveLabel;
		private System.Windows.Forms.TextBox repetirClave;
		private System.Windows.Forms.Button cambiarClaveBoton;
		private System.Windows.Forms.FlowLayoutPanel altaSeguroCampo;
		private System.Windows.Forms.Label altaSeguroLabel;
		private System.Windows.Forms.ComboBox tipoSeguroAlta;
		private System.Windows.Forms.Panel seguroUsuarioPanel;
		private System.Windows.Forms.Label seguroUsuarioLabel;
		private System.Windows.Forms.ComboBox tipoSeguroActual;
		private System.Windows.Forms.Button guardarSeguroUsuarioBoton;
		private System.Windows.Forms.DataGridViewTextBoxColumn grillaIdColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn grillaNombreUsuarioColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn grillaRolColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn grillaActivoColumna;
	}
}
