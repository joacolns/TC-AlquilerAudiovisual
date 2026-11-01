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
			this.presentacion = new System.Windows.Forms.Panel();
			this.presentacionDetalle = new System.Windows.Forms.Label();
			this.presentacionTitulo = new System.Windows.Forms.Label();
			this.marcaDetalle = new System.Windows.Forms.Label();
			this.marca = new System.Windows.Forms.Label();
			this.accesoPanel = new System.Windows.Forms.Panel();
			this.mostrarClave = new System.Windows.Forms.CheckBox();
			this.ingresarBoton = new System.Windows.Forms.Button();
			this.clave = new System.Windows.Forms.TextBox();
			this.claveLabel = new System.Windows.Forms.Label();
			this.nombre = new System.Windows.Forms.TextBox();
			this.usuarioLabel = new System.Windows.Forms.Label();
			this.accesoDetalle = new System.Windows.Forms.Label();
			this.accesoTitulo = new System.Windows.Forms.Label();
			this.presentacion.SuspendLayout();
			this.accesoPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// presentacion
			// 
			this.presentacion.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.presentacion.Controls.Add(this.presentacionDetalle);
			this.presentacion.Controls.Add(this.presentacionTitulo);
			this.presentacion.Controls.Add(this.marcaDetalle);
			this.presentacion.Controls.Add(this.marca);
			this.presentacion.Dock = System.Windows.Forms.DockStyle.Left;
			this.presentacion.Location = new System.Drawing.Point(0, 0);
			this.presentacion.Name = "presentacion";
			this.presentacion.Size = new System.Drawing.Size(380, 560);
			this.presentacion.TabIndex = 0;
			// 
			// presentacionDetalle
			// 
			this.presentacionDetalle.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.presentacionDetalle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
			this.presentacionDetalle.Location = new System.Drawing.Point(40, 336);
			this.presentacionDetalle.Name = "presentacionDetalle";
			this.presentacionDetalle.Size = new System.Drawing.Size(294, 96);
			this.presentacionDetalle.TabIndex = 3;
			this.presentacionDetalle.Text = "Disponibilidad, solicitudes, entregas y devoluciones en un sistema simple y ordenado.";
			// 
			// presentacionTitulo
			// 
			this.presentacionTitulo.Font = new System.Drawing.Font("Segoe UI", 23F, System.Drawing.FontStyle.Bold);
			this.presentacionTitulo.ForeColor = System.Drawing.Color.White;
			this.presentacionTitulo.Location = new System.Drawing.Point(36, 214);
			this.presentacionTitulo.Name = "presentacionTitulo";
			this.presentacionTitulo.Size = new System.Drawing.Size(310, 112);
			this.presentacionTitulo.TabIndex = 2;
			this.presentacionTitulo.Text = "Tu próxima producción empieza acá.";
			// 
			// marcaDetalle
			// 
			this.marcaDetalle.AutoSize = true;
			this.marcaDetalle.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.marcaDetalle.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250);
			this.marcaDetalle.Location = new System.Drawing.Point(42, 100);
			this.marcaDetalle.Name = "marcaDetalle";
			this.marcaDetalle.Size = new System.Drawing.Size(139, 15);
			this.marcaDetalle.TabIndex = 1;
			this.marcaDetalle.Text = "ALQUILER AUDIOVISUAL";
			// 
			// marca
			// 
			this.marca.AutoSize = true;
			this.marca.Font = new System.Drawing.Font("Segoe UI", 27F, System.Drawing.FontStyle.Bold);
			this.marca.ForeColor = System.Drawing.Color.White;
			this.marca.Location = new System.Drawing.Point(34, 44);
			this.marca.Name = "marca";
			this.marca.Size = new System.Drawing.Size(128, 50);
			this.marca.TabIndex = 0;
			this.marca.Text = "FOCO";
			// 
			// accesoPanel
			// 
			this.accesoPanel.BackColor = System.Drawing.Color.White;
			this.accesoPanel.Controls.Add(this.mostrarClave);
			this.accesoPanel.Controls.Add(this.ingresarBoton);
			this.accesoPanel.Controls.Add(this.clave);
			this.accesoPanel.Controls.Add(this.claveLabel);
			this.accesoPanel.Controls.Add(this.nombre);
			this.accesoPanel.Controls.Add(this.usuarioLabel);
			this.accesoPanel.Controls.Add(this.accesoDetalle);
			this.accesoPanel.Controls.Add(this.accesoTitulo);
			this.accesoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.accesoPanel.Location = new System.Drawing.Point(380, 0);
			this.accesoPanel.Name = "accesoPanel";
			this.accesoPanel.Size = new System.Drawing.Size(520, 560);
			this.accesoPanel.TabIndex = 0;
			// 
			// mostrarClave
			// 
			this.mostrarClave.AutoSize = true;
			this.mostrarClave.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.mostrarClave.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
			this.mostrarClave.Location = new System.Drawing.Point(80, 348);
			this.mostrarClave.Name = "mostrarClave";
			this.mostrarClave.Size = new System.Drawing.Size(127, 19);
			this.mostrarClave.TabIndex = 3;
			this.mostrarClave.Text = "Mostrar contraseña";
			this.mostrarClave.UseVisualStyleBackColor = true;
			this.mostrarClave.CheckedChanged += new System.EventHandler(this.MostrarClaveCambio);
			// 
			// ingresarBoton
			// 
			this.ingresarBoton.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
			this.ingresarBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ingresarBoton.FlatAppearance.BorderSize = 0;
			this.ingresarBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(29, 78, 216);
			this.ingresarBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ingresarBoton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.ingresarBoton.ForeColor = System.Drawing.Color.White;
			this.ingresarBoton.Location = new System.Drawing.Point(80, 396);
			this.ingresarBoton.Name = "ingresarBoton";
			this.ingresarBoton.Size = new System.Drawing.Size(350, 46);
			this.ingresarBoton.TabIndex = 4;
			this.ingresarBoton.Text = "Ingresar";
			this.ingresarBoton.UseVisualStyleBackColor = false;
			this.ingresarBoton.Click += new System.EventHandler(this.IngresarClick);
			// 
			// clave
			// 
			this.clave.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
			this.clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.clave.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.clave.Location = new System.Drawing.Point(80, 304);
			this.clave.MaxLength = 128;
			this.clave.Name = "clave";
			this.clave.Size = new System.Drawing.Size(350, 27);
			this.clave.TabIndex = 2;
			this.clave.UseSystemPasswordChar = true;
			// 
			// claveLabel
			// 
			this.claveLabel.AutoSize = true;
			this.claveLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.claveLabel.Location = new System.Drawing.Point(76, 274);
			this.claveLabel.Name = "claveLabel";
			this.claveLabel.Size = new System.Drawing.Size(79, 19);
			this.claveLabel.TabIndex = 0;
			this.claveLabel.Text = "Contraseña";
			// 
			// nombre
			// 
			this.nombre.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
			this.nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.nombre.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.nombre.Location = new System.Drawing.Point(80, 218);
			this.nombre.MaxLength = 50;
			this.nombre.Name = "nombre";
			this.nombre.Size = new System.Drawing.Size(350, 27);
			this.nombre.TabIndex = 1;
			// 
			// usuarioLabel
			// 
			this.usuarioLabel.AutoSize = true;
			this.usuarioLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.usuarioLabel.Location = new System.Drawing.Point(76, 188);
			this.usuarioLabel.Name = "usuarioLabel";
			this.usuarioLabel.Size = new System.Drawing.Size(56, 19);
			this.usuarioLabel.TabIndex = 0;
			this.usuarioLabel.Text = "Usuario";
			// 
			// accesoDetalle
			// 
			this.accesoDetalle.AutoSize = true;
			this.accesoDetalle.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.accesoDetalle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
			this.accesoDetalle.Location = new System.Drawing.Point(76, 130);
			this.accesoDetalle.Name = "accesoDetalle";
			this.accesoDetalle.Size = new System.Drawing.Size(195, 19);
			this.accesoDetalle.TabIndex = 0;
			this.accesoDetalle.Text = "Ingresá con tu cuenta de FOCO.";
			// 
			// accesoTitulo
			// 
			this.accesoTitulo.AutoSize = true;
			this.accesoTitulo.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
			this.accesoTitulo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.accesoTitulo.Location = new System.Drawing.Point(72, 76);
			this.accesoTitulo.Name = "accesoTitulo";
			this.accesoTitulo.Size = new System.Drawing.Size(191, 41);
			this.accesoTitulo.TabIndex = 0;
			this.accesoTitulo.Text = "Bienvenido";
			// 
			// LoginForm
			// 
			this.AcceptButton = this.ingresarBoton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(900, 560);
			this.Controls.Add(this.accesoPanel);
			this.Controls.Add(this.presentacion);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "LoginForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FOCO · Ingresar";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Salir);
			this.presentacion.ResumeLayout(false);
			this.presentacion.PerformLayout();
			this.accesoPanel.ResumeLayout(false);
			this.accesoPanel.PerformLayout();
			this.ResumeLayout(false);
		}
#endregion

		private System.Windows.Forms.Panel presentacion;
		private System.Windows.Forms.Panel accesoPanel;
		private System.Windows.Forms.Label marca;
		private System.Windows.Forms.Label marcaDetalle;
		private System.Windows.Forms.Label presentacionTitulo;
		private System.Windows.Forms.Label presentacionDetalle;
		private System.Windows.Forms.Label accesoTitulo;
		private System.Windows.Forms.Label accesoDetalle;
		private System.Windows.Forms.Label usuarioLabel;
		private System.Windows.Forms.Label claveLabel;
		private System.Windows.Forms.TextBox nombre;
		private System.Windows.Forms.TextBox clave;
		private System.Windows.Forms.CheckBox mostrarClave;
		private System.Windows.Forms.Button ingresarBoton;
	}
}
