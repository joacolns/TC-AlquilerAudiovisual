namespace GUI
{
	partial class MenuPrincipalForm
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
			this.lateral = new System.Windows.Forms.Panel();
			this.cerrarBoton = new System.Windows.Forms.Button();
			this.navegacion = new System.Windows.Forms.FlowLayoutPanel();
			this.equiposReservasBoton = new System.Windows.Forms.Button();
			this.devolucionesBoton = new System.Windows.Forms.Button();
			this.clientesBoton = new System.Windows.Forms.Button();
			this.usuariosBoton = new System.Windows.Forms.Button();
			this.marca = new System.Windows.Forms.Label();
			this.marcaDetalle = new System.Windows.Forms.Label();
			this.contenido = new System.Windows.Forms.Panel();
			this.flujo = new System.Windows.Forms.Panel();
			this.flujoDetalle = new System.Windows.Forms.Label();
			this.flujoTitulo = new System.Windows.Forms.Label();
			this.ayuda = new System.Windows.Forms.Label();
			this.titulo = new System.Windows.Forms.Label();
			this.rolLabel = new System.Windows.Forms.Label();
			this.bienvenida = new System.Windows.Forms.Label();
			this.lateral.SuspendLayout();
			this.navegacion.SuspendLayout();
			this.contenido.SuspendLayout();
			this.flujo.SuspendLayout();
			this.SuspendLayout();
			// 
			// lateral
			// 
			this.lateral.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.lateral.Controls.Add(this.cerrarBoton);
			this.lateral.Controls.Add(this.navegacion);
			this.lateral.Controls.Add(this.marcaDetalle);
			this.lateral.Controls.Add(this.marca);
			this.lateral.Dock = System.Windows.Forms.DockStyle.Left;
			this.lateral.Location = new System.Drawing.Point(0, 0);
			this.lateral.Name = "lateral";
			this.lateral.Size = new System.Drawing.Size(250, 680);
			this.lateral.TabIndex = 0;
			// 
			// cerrarBoton
			// 
			this.cerrarBoton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.cerrarBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cerrarBoton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(71, 85, 105);
			this.cerrarBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cerrarBoton.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
			this.cerrarBoton.Location = new System.Drawing.Point(20, 608);
			this.cerrarBoton.Name = "cerrarBoton";
			this.cerrarBoton.Size = new System.Drawing.Size(210, 42);
			this.cerrarBoton.TabIndex = 5;
			this.cerrarBoton.Text = "Cerrar sesión";
			this.cerrarBoton.UseVisualStyleBackColor = false;
			this.cerrarBoton.Click += new System.EventHandler(this.CerrarClick);
			// 
			// navegacion
			// 
			this.navegacion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.navegacion.Controls.Add(this.equiposReservasBoton);
			this.navegacion.Controls.Add(this.devolucionesBoton);
			this.navegacion.Controls.Add(this.clientesBoton);
			this.navegacion.Controls.Add(this.usuariosBoton);
			this.navegacion.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.navegacion.Location = new System.Drawing.Point(12, 142);
			this.navegacion.Name = "navegacion";
			this.navegacion.Size = new System.Drawing.Size(226, 330);
			this.navegacion.TabIndex = 1;
			this.navegacion.WrapContents = false;
			// 
			// equiposReservasBoton
			// 
			this.equiposReservasBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.equiposReservasBoton.FlatAppearance.BorderSize = 0;
			this.equiposReservasBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 41, 59);
			this.equiposReservasBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.equiposReservasBoton.ForeColor = System.Drawing.Color.White;
			this.equiposReservasBoton.Location = new System.Drawing.Point(3, 3);
			this.equiposReservasBoton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
			this.equiposReservasBoton.Name = "equiposReservasBoton";
			this.equiposReservasBoton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
			this.equiposReservasBoton.Size = new System.Drawing.Size(214, 52);
			this.equiposReservasBoton.TabIndex = 1;
			this.equiposReservasBoton.Text = "Equipos y reservas";
			this.equiposReservasBoton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.equiposReservasBoton.UseVisualStyleBackColor = false;
			this.equiposReservasBoton.Click += new System.EventHandler(this.EquiposReservasClick);
			// 
			// devolucionesBoton
			// 
			this.devolucionesBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.devolucionesBoton.FlatAppearance.BorderSize = 0;
			this.devolucionesBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 41, 59);
			this.devolucionesBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.devolucionesBoton.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
			this.devolucionesBoton.Location = new System.Drawing.Point(3, 66);
			this.devolucionesBoton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
			this.devolucionesBoton.Name = "devolucionesBoton";
			this.devolucionesBoton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
			this.devolucionesBoton.Size = new System.Drawing.Size(214, 52);
			this.devolucionesBoton.TabIndex = 2;
			this.devolucionesBoton.Text = "Devoluciones";
			this.devolucionesBoton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.devolucionesBoton.UseVisualStyleBackColor = false;
			this.devolucionesBoton.Click += new System.EventHandler(this.DevolucionesClick);
			// 
			// clientesBoton
			// 
			this.clientesBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.clientesBoton.FlatAppearance.BorderSize = 0;
			this.clientesBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 41, 59);
			this.clientesBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.clientesBoton.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
			this.clientesBoton.Location = new System.Drawing.Point(3, 129);
			this.clientesBoton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
			this.clientesBoton.Name = "clientesBoton";
			this.clientesBoton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
			this.clientesBoton.Size = new System.Drawing.Size(214, 52);
			this.clientesBoton.TabIndex = 3;
			this.clientesBoton.Text = "Clientes y seguros";
			this.clientesBoton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.clientesBoton.UseVisualStyleBackColor = false;
			this.clientesBoton.Click += new System.EventHandler(this.ClientesClick);
			// 
			// usuariosBoton
			// 
			this.usuariosBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.usuariosBoton.FlatAppearance.BorderSize = 0;
			this.usuariosBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 41, 59);
			this.usuariosBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.usuariosBoton.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
			this.usuariosBoton.Location = new System.Drawing.Point(3, 192);
			this.usuariosBoton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
			this.usuariosBoton.Name = "usuariosBoton";
			this.usuariosBoton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
			this.usuariosBoton.Size = new System.Drawing.Size(214, 52);
			this.usuariosBoton.TabIndex = 4;
			this.usuariosBoton.Text = "Usuarios y roles";
			this.usuariosBoton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.usuariosBoton.UseVisualStyleBackColor = false;
			this.usuariosBoton.Click += new System.EventHandler(this.UsuariosClick);
			// 
			// marca
			// 
			this.marca.AutoSize = true;
			this.marca.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
			this.marca.ForeColor = System.Drawing.Color.White;
			this.marca.Location = new System.Drawing.Point(20, 34);
			this.marca.Name = "marca";
			this.marca.Size = new System.Drawing.Size(113, 45);
			this.marca.TabIndex = 0;
			this.marca.Text = "FOCO";
			// 
			// marcaDetalle
			// 
			this.marcaDetalle.AutoSize = true;
			this.marcaDetalle.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.marcaDetalle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
			this.marcaDetalle.Location = new System.Drawing.Point(24, 86);
			this.marcaDetalle.Name = "marcaDetalle";
			this.marcaDetalle.Size = new System.Drawing.Size(139, 15);
			this.marcaDetalle.TabIndex = 0;
			this.marcaDetalle.Text = "ALQUILER AUDIOVISUAL";
			// 
			// contenido
			// 
			this.contenido.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.contenido.Controls.Add(this.flujo);
			this.contenido.Controls.Add(this.ayuda);
			this.contenido.Controls.Add(this.titulo);
			this.contenido.Controls.Add(this.rolLabel);
			this.contenido.Controls.Add(this.bienvenida);
			this.contenido.Dock = System.Windows.Forms.DockStyle.Fill;
			this.contenido.Location = new System.Drawing.Point(250, 0);
			this.contenido.Name = "contenido";
			this.contenido.Padding = new System.Windows.Forms.Padding(42);
			this.contenido.Size = new System.Drawing.Size(850, 680);
			this.contenido.TabIndex = 0;
			// 
			// flujo
			// 
			this.flujo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.flujo.BackColor = System.Drawing.Color.White;
			this.flujo.Controls.Add(this.flujoDetalle);
			this.flujo.Controls.Add(this.flujoTitulo);
			this.flujo.Location = new System.Drawing.Point(46, 300);
			this.flujo.Name = "flujo";
			this.flujo.Padding = new System.Windows.Forms.Padding(26);
			this.flujo.Size = new System.Drawing.Size(758, 220);
			this.flujo.TabIndex = 4;
			// 
			// flujoDetalle
			// 
			this.flujoDetalle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.flujoDetalle.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.flujoDetalle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
			this.flujoDetalle.Location = new System.Drawing.Point(28, 76);
			this.flujoDetalle.Name = "flujoDetalle";
			this.flujoDetalle.Size = new System.Drawing.Size(700, 112);
			this.flujoDetalle.TabIndex = 1;
			this.flujoDetalle.Text = "1. Consultá disponibilidad y enviá la solicitud.\r\n2. Stock la revisa; después se registran el pago y la entrega.\r\n3. Al volver el equipo, se inspecciona y se cierra el alquiler.";
			// 
			// flujoTitulo
			// 
			this.flujoTitulo.AutoSize = true;
			this.flujoTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
			this.flujoTitulo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.flujoTitulo.Location = new System.Drawing.Point(24, 24);
			this.flujoTitulo.Name = "flujoTitulo";
			this.flujoTitulo.Size = new System.Drawing.Size(169, 25);
			this.flujoTitulo.TabIndex = 0;
			this.flujoTitulo.Text = "Ciclo del alquiler";
			// 
			// ayuda
			// 
			this.ayuda.AutoSize = true;
			this.ayuda.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.ayuda.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
			this.ayuda.Location = new System.Drawing.Point(44, 234);
			this.ayuda.Name = "ayuda";
			this.ayuda.Size = new System.Drawing.Size(331, 20);
			this.ayuda.TabIndex = 3;
			this.ayuda.Text = "Elegí una opción del menú lateral para comenzar.";
			// 
			// titulo
			// 
			this.titulo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.titulo.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
			this.titulo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.titulo.Location = new System.Drawing.Point(40, 142);
			this.titulo.Name = "titulo";
			this.titulo.Size = new System.Drawing.Size(758, 82);
			this.titulo.TabIndex = 2;
			this.titulo.Text = "Todo tu rental,\r\nen un solo lugar.";
			// 
			// rolLabel
			// 
			this.rolLabel.AutoSize = true;
			this.rolLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.rolLabel.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
			this.rolLabel.Location = new System.Drawing.Point(44, 96);
			this.rolLabel.Name = "rolLabel";
			this.rolLabel.Size = new System.Drawing.Size(28, 19);
			this.rolLabel.TabIndex = 1;
			this.rolLabel.Text = "Rol";
			// 
			// bienvenida
			// 
			this.bienvenida.AutoSize = true;
			this.bienvenida.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.bienvenida.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
			this.bienvenida.Location = new System.Drawing.Point(42, 48);
			this.bienvenida.Name = "bienvenida";
			this.bienvenida.Size = new System.Drawing.Size(58, 21);
			this.bienvenida.TabIndex = 0;
			this.bienvenida.Text = "Hola";
			// 
			// MenuPrincipalForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1100, 680);
			this.Controls.Add(this.contenido);
			this.Controls.Add(this.lateral);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.MinimumSize = new System.Drawing.Size(960, 620);
			this.Name = "MenuPrincipalForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FOCO · Alquiler audiovisual";
			this.Load += new System.EventHandler(this.CargarMenu);
			this.lateral.ResumeLayout(false);
			this.lateral.PerformLayout();
			this.navegacion.ResumeLayout(false);
			this.contenido.ResumeLayout(false);
			this.contenido.PerformLayout();
			this.flujo.ResumeLayout(false);
			this.flujo.PerformLayout();
			this.ResumeLayout(false);
		}
#endregion

		private System.Windows.Forms.Panel lateral;
		private System.Windows.Forms.Panel contenido;
		private System.Windows.Forms.Label marca;
		private System.Windows.Forms.Label marcaDetalle;
		private System.Windows.Forms.FlowLayoutPanel navegacion;
		private System.Windows.Forms.Button equiposReservasBoton;
		private System.Windows.Forms.Button devolucionesBoton;
		private System.Windows.Forms.Button clientesBoton;
		private System.Windows.Forms.Button usuariosBoton;
		private System.Windows.Forms.Button cerrarBoton;
		private System.Windows.Forms.Label bienvenida;
		private System.Windows.Forms.Label rolLabel;
		private System.Windows.Forms.Label titulo;
		private System.Windows.Forms.Label ayuda;
		private System.Windows.Forms.Panel flujo;
		private System.Windows.Forms.Label flujoTitulo;
		private System.Windows.Forms.Label flujoDetalle;
	}
}
