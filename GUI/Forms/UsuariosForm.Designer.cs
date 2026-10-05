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
            this.alta.SuspendLayout();
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
            this.alta.Dock = System.Windows.Forms.DockStyle.Top;
            this.alta.Location = new System.Drawing.Point(0, 0);
            this.alta.Name = "alta";
            this.alta.Padding = new System.Windows.Forms.Padding(12);
            this.alta.Size = new System.Drawing.Size(900, 120);
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
            this.rol.Items.AddRange(new object[] {
            "Cliente",
            "EncargadoStock",
            "Administrador",
            "Tecnico"});
            this.rol.Location = new System.Drawing.Point(547, 15);
            this.rol.Name = "rol";
            this.rol.Size = new System.Drawing.Size(160, 25);
            this.rol.TabIndex = 3;
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
            // 
            // UsuariosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 470);
            this.Controls.Add(this.grilla);
            this.Controls.Add(this.alta);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UsuariosForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Usuarios y roles";
            this.Shown += new System.EventHandler(this.CargarClick);
            this.alta.ResumeLayout(false);
            this.alta.PerformLayout();
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
		private System.Windows.Forms.DataGridViewTextBoxColumn grillaIdColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn grillaNombreUsuarioColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn grillaRolColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn grillaActivoColumna;
	}
}
