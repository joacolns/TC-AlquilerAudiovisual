namespace GUI
{
	partial class LoginForm
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
			this.vistas = new System.Windows.Forms.TabControl();
			this.accesoTab = new System.Windows.Forms.TabPage();
			this.acceso = new System.Windows.Forms.FlowLayoutPanel();
			this.usuarioLabel = new System.Windows.Forms.Label();
			this.nombre = new System.Windows.Forms.TextBox();
			this.claveLabel = new System.Windows.Forms.Label();
			this.clave = new System.Windows.Forms.TextBox();
			this.ingresarBoton = new System.Windows.Forms.Button();
			this.menuTab = new System.Windows.Forms.TabPage();
			this.menu = new System.Windows.Forms.FlowLayoutPanel();
			this.estado = new System.Windows.Forms.Label();
			this.equiposBoton = new System.Windows.Forms.Button();
			this.reservasBoton = new System.Windows.Forms.Button();
			this.clientesBoton = new System.Windows.Forms.Button();
			this.usuariosBoton = new System.Windows.Forms.Button();
			this.cerrarBoton = new System.Windows.Forms.Button();
			this.vistas.SuspendLayout();
			this.accesoTab.SuspendLayout();
			this.acceso.SuspendLayout();
			this.menuTab.SuspendLayout();
			this.menu.SuspendLayout();
			this.SuspendLayout();
			//
			// vistas
			//
			this.vistas.Controls.Add(this.accesoTab);
			this.vistas.Controls.Add(this.menuTab);
			this.vistas.Dock = System.Windows.Forms.DockStyle.Fill;
			this.vistas.Location = new System.Drawing.Point(0, 0);
			this.vistas.Name = "vistas";
			this.vistas.SelectedIndex = 0;
			this.vistas.Size = new System.Drawing.Size(520, 440);
			this.vistas.TabIndex = 0;
			//
			// accesoTab
			//
			this.accesoTab.Controls.Add(this.acceso);
			this.accesoTab.Location = new System.Drawing.Point(4, 26);
			this.accesoTab.Name = "accesoTab";
			this.accesoTab.Padding = new System.Windows.Forms.Padding(3);
			this.accesoTab.Size = new System.Drawing.Size(512, 410);
			this.accesoTab.TabIndex = 0;
			this.accesoTab.Text = "Acceso";
			this.accesoTab.UseVisualStyleBackColor = true;
			//
			// acceso
			//
			this.acceso.Controls.Add(this.usuarioLabel);
			this.acceso.Controls.Add(this.nombre);
			this.acceso.Controls.Add(this.claveLabel);
			this.acceso.Controls.Add(this.clave);
			this.acceso.Controls.Add(this.ingresarBoton);
			this.acceso.Dock = System.Windows.Forms.DockStyle.Fill;
			this.acceso.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.acceso.Location = new System.Drawing.Point(3, 3);
			this.acceso.Name = "acceso";
			this.acceso.Padding = new System.Windows.Forms.Padding(24);
			this.acceso.Size = new System.Drawing.Size(506, 404);
			this.acceso.TabIndex = 0;
			//
			// usuarioLabel
			//
			this.usuarioLabel.AutoSize = true;
			this.usuarioLabel.Location = new System.Drawing.Point(27, 24);
			this.usuarioLabel.Name = "usuarioLabel";
			this.usuarioLabel.Size = new System.Drawing.Size(56, 19);
			this.usuarioLabel.TabIndex = 0;
			this.usuarioLabel.Text = "Usuario";
			//
			// nombre
			//
			this.nombre.Location = new System.Drawing.Point(27, 46);
			this.nombre.MaxLength = 50;
			this.nombre.Name = "nombre";
			this.nombre.Size = new System.Drawing.Size(240, 25);
			this.nombre.TabIndex = 1;
			//
			// claveLabel
			//
			this.claveLabel.AutoSize = true;
			this.claveLabel.Location = new System.Drawing.Point(27, 74);
			this.claveLabel.Name = "claveLabel";
			this.claveLabel.Size = new System.Drawing.Size(79, 19);
			this.claveLabel.TabIndex = 2;
			this.claveLabel.Text = "Contraseña";
			//
			// clave
			//
			this.clave.Location = new System.Drawing.Point(27, 96);
			this.clave.MaxLength = 128;
			this.clave.Name = "clave";
			this.clave.Size = new System.Drawing.Size(240, 25);
			this.clave.TabIndex = 3;
			this.clave.UseSystemPasswordChar = true;
			//
			// ingresarBoton
			//
			this.ingresarBoton.Location = new System.Drawing.Point(27, 127);
			this.ingresarBoton.Name = "ingresarBoton";
			this.ingresarBoton.Size = new System.Drawing.Size(400, 38);
			this.ingresarBoton.TabIndex = 4;
			this.ingresarBoton.Text = "Ingresar";
			this.ingresarBoton.UseVisualStyleBackColor = true;
			this.ingresarBoton.Click += new System.EventHandler(this.IngresarClick);
			//
			// menuTab
			//
			this.menuTab.Controls.Add(this.menu);
			this.menuTab.Location = new System.Drawing.Point(4, 26);
			this.menuTab.Name = "menuTab";
			this.menuTab.Padding = new System.Windows.Forms.Padding(3);
			this.menuTab.Size = new System.Drawing.Size(512, 410);
			this.menuTab.TabIndex = 1;
			this.menuTab.Text = "Menú";
			this.menuTab.UseVisualStyleBackColor = true;
			//
			// menu
			//
			this.menu.Controls.Add(this.estado);
			this.menu.Controls.Add(this.equiposBoton);
			this.menu.Controls.Add(this.reservasBoton);
			this.menu.Controls.Add(this.clientesBoton);
			this.menu.Controls.Add(this.usuariosBoton);
			this.menu.Controls.Add(this.cerrarBoton);
			this.menu.Dock = System.Windows.Forms.DockStyle.Fill;
			this.menu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.menu.Location = new System.Drawing.Point(3, 3);
			this.menu.Name = "menu";
			this.menu.Padding = new System.Windows.Forms.Padding(24);
			this.menu.Size = new System.Drawing.Size(506, 404);
			this.menu.TabIndex = 0;
			//
			// estado
			//
			this.estado.AutoSize = true;
			this.estado.Location = new System.Drawing.Point(27, 24);
			this.estado.Name = "estado";
			this.estado.Size = new System.Drawing.Size(97, 19);
			this.estado.TabIndex = 0;
			this.estado.Text = "Sesión iniciada";
			//
			// equiposBoton
			//
			this.equiposBoton.Location = new System.Drawing.Point(27, 46);
			this.equiposBoton.Name = "equiposBoton";
			this.equiposBoton.Size = new System.Drawing.Size(400, 38);
			this.equiposBoton.TabIndex = 1;
			this.equiposBoton.Text = "Consultar y gestionar equipos";
			this.equiposBoton.UseVisualStyleBackColor = true;
			this.equiposBoton.Click += new System.EventHandler(this.EquiposClick);
			//
			// reservasBoton
			//
			this.reservasBoton.Location = new System.Drawing.Point(27, 90);
			this.reservasBoton.Name = "reservasBoton";
			this.reservasBoton.Size = new System.Drawing.Size(400, 38);
			this.reservasBoton.TabIndex = 2;
			this.reservasBoton.Text = "Solicitudes, reservas y entrega";
			this.reservasBoton.UseVisualStyleBackColor = true;
			this.reservasBoton.Click += new System.EventHandler(this.ReservasClick);
			//
			// clientesBoton
			//
			this.clientesBoton.Location = new System.Drawing.Point(27, 134);
			this.clientesBoton.Name = "clientesBoton";
			this.clientesBoton.Size = new System.Drawing.Size(400, 38);
			this.clientesBoton.TabIndex = 3;
			this.clientesBoton.Text = "Clientes y seguros";
			this.clientesBoton.UseVisualStyleBackColor = true;
			this.clientesBoton.Click += new System.EventHandler(this.ClientesClick);
			//
			// usuariosBoton
			//
			this.usuariosBoton.Location = new System.Drawing.Point(27, 178);
			this.usuariosBoton.Name = "usuariosBoton";
			this.usuariosBoton.Size = new System.Drawing.Size(400, 38);
			this.usuariosBoton.TabIndex = 4;
			this.usuariosBoton.Text = "Usuarios y roles";
			this.usuariosBoton.UseVisualStyleBackColor = true;
			this.usuariosBoton.Click += new System.EventHandler(this.UsuariosClick);
			//
			// cerrarBoton
			//
			this.cerrarBoton.Location = new System.Drawing.Point(27, 222);
			this.cerrarBoton.Name = "cerrarBoton";
			this.cerrarBoton.Size = new System.Drawing.Size(400, 38);
			this.cerrarBoton.TabIndex = 5;
			this.cerrarBoton.Text = "Cerrar sesión";
			this.cerrarBoton.UseVisualStyleBackColor = true;
			this.cerrarBoton.Click += new System.EventHandler(this.CerrarClick);
			//
			// LoginForm
			//
			this.AcceptButton = this.ingresarBoton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(520, 440);
			this.Controls.Add(this.vistas);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.Name = "LoginForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Alquiler audiovisual · ENTREGA1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Salir);
			this.Load += new System.EventHandler(this.PrepararPantalla);
			this.vistas.ResumeLayout(false);
			this.accesoTab.ResumeLayout(false);
			this.acceso.ResumeLayout(false);
			this.acceso.PerformLayout();
			this.menuTab.ResumeLayout(false);
			this.menu.ResumeLayout(false);
			this.menu.PerformLayout();
			this.ResumeLayout(false);
		}

#endregion
		private System.Windows.Forms.TabControl vistas;
		private System.Windows.Forms.TabPage accesoTab;
		private System.Windows.Forms.TabPage menuTab;
		private System.Windows.Forms.FlowLayoutPanel acceso;
		private System.Windows.Forms.FlowLayoutPanel menu;
		private System.Windows.Forms.Label usuarioLabel;
		private System.Windows.Forms.Label claveLabel;
		private System.Windows.Forms.TextBox nombre;
		private System.Windows.Forms.TextBox clave;
		private System.Windows.Forms.Button ingresarBoton;
		private System.Windows.Forms.Label estado;
		private System.Windows.Forms.Button equiposBoton;
		private System.Windows.Forms.Button reservasBoton;
		private System.Windows.Forms.Button clientesBoton;
		private System.Windows.Forms.Button usuariosBoton;
		private System.Windows.Forms.Button cerrarBoton;
	}
}
