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
			this.contenido = new System.Windows.Forms.Panel();
			this.lateral = new System.Windows.Forms.Panel();
			this.lateralLayout = new System.Windows.Forms.TableLayoutPanel();
			this.marca = new System.Windows.Forms.Label();
			this.navegacion = new System.Windows.Forms.FlowLayoutPanel();
			this.reservasBoton = new System.Windows.Forms.Button();
			this.asesorBoton = new System.Windows.Forms.Button();
			this.devolucionesBoton = new System.Windows.Forms.Button();
			this.clientesBoton = new System.Windows.Forms.Button();
			this.usuariosBoton = new System.Windows.Forms.Button();
			this.usuario = new System.Windows.Forms.Label();
			this.rolLabel = new System.Windows.Forms.Label();
			this.cerrarBoton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			this.contenido.SuspendLayout();
			this.lateral.SuspendLayout();
			this.lateralLayout.SuspendLayout();
			this.navegacion.SuspendLayout();
			// 
			// MenuPrincipalForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.ClientSize = new System.Drawing.Size(1100, 680);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.MinimumSize = new System.Drawing.Size(980, 620);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FOCO · Alquiler audiovisual";
			this.Controls.Add(this.contenido);
			this.Controls.Add(this.lateral);
			this.Load += new System.EventHandler(this.MenuPrincipalForm_Load);
			// 
			// contenido
			// 
			this.contenido.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
			this.contenido.Dock = System.Windows.Forms.DockStyle.Fill;
			this.contenido.Padding = new System.Windows.Forms.Padding(24, 24, 24, 24);
			this.contenido.TabIndex = 0;
			this.contenido.Name = "contenido";
			// 
			// lateral
			// 
			this.lateral.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.lateral.Dock = System.Windows.Forms.DockStyle.Left;
			this.lateral.Size = new System.Drawing.Size(230, 680);
			this.lateral.TabIndex = 1;
			this.lateral.Name = "lateral";
			this.lateral.Controls.Add(this.lateralLayout);
			// 
			// lateralLayout
			// 
			this.lateralLayout.ColumnCount = 1;
			this.lateralLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.lateralLayout.RowCount = 5;
			this.lateralLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.lateralLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.lateralLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.lateralLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.lateralLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
			this.lateralLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lateralLayout.TabIndex = 0;
			this.lateralLayout.Name = "lateralLayout";
			this.lateralLayout.Controls.Add(this.marca, 0, 0);
			this.lateralLayout.Controls.Add(this.navegacion, 0, 1);
			this.lateralLayout.Controls.Add(this.usuario, 0, 2);
			this.lateralLayout.Controls.Add(this.rolLabel, 0, 3);
			this.lateralLayout.Controls.Add(this.cerrarBoton, 0, 4);
			// 
			// marca
			// 
			this.marca.AutoSize = true;
			this.marca.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
			this.marca.ForeColor = System.Drawing.Color.White;
			this.marca.Text = "FOCO";
			this.marca.Margin = new System.Windows.Forms.Padding(20, 28, 0, 24);
			this.marca.TabIndex = 0;
			this.marca.Name = "marca";
			// 
			// navegacion
			// 
			this.navegacion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.navegacion.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.navegacion.WrapContents = false;
			this.navegacion.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
			this.navegacion.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
			this.navegacion.TabIndex = 1;
			this.navegacion.Name = "navegacion";
			this.navegacion.Controls.Add(this.reservasBoton);
			this.navegacion.Controls.Add(this.asesorBoton);
			this.navegacion.Controls.Add(this.devolucionesBoton);
			this.navegacion.Controls.Add(this.clientesBoton);
			this.navegacion.Controls.Add(this.usuariosBoton);
			// 
			// reservasBoton
			// 
			this.reservasBoton.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.reservasBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.reservasBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.reservasBoton.FlatAppearance.BorderSize = 0;
			this.reservasBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 41, 59);
			this.reservasBoton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(30, 41, 59);
			this.reservasBoton.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
			this.reservasBoton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
			this.reservasBoton.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
			this.reservasBoton.Size = new System.Drawing.Size(206, 44);
			this.reservasBoton.Text = "Reservas";
			this.reservasBoton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.reservasBoton.UseVisualStyleBackColor = false;
			this.reservasBoton.TabIndex = 0;
			this.reservasBoton.Name = "reservasBoton";
			this.reservasBoton.Click += new System.EventHandler(this.ReservasClick);
			// 
			// asesorBoton
			// 
			this.asesorBoton.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.asesorBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.asesorBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.asesorBoton.FlatAppearance.BorderSize = 0;
			this.asesorBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 41, 59);
			this.asesorBoton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(30, 41, 59);
			this.asesorBoton.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
			this.asesorBoton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
			this.asesorBoton.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
			this.asesorBoton.Size = new System.Drawing.Size(206, 44);
			this.asesorBoton.Text = "Asesor de rodaje";
			this.asesorBoton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.asesorBoton.UseVisualStyleBackColor = false;
			this.asesorBoton.TabIndex = 1;
			this.asesorBoton.Name = "asesorBoton";
			this.asesorBoton.Click += new System.EventHandler(this.AsesorClick);
			// 
			// devolucionesBoton
			// 
			this.devolucionesBoton.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.devolucionesBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.devolucionesBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.devolucionesBoton.FlatAppearance.BorderSize = 0;
			this.devolucionesBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 41, 59);
			this.devolucionesBoton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(30, 41, 59);
			this.devolucionesBoton.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
			this.devolucionesBoton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
			this.devolucionesBoton.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
			this.devolucionesBoton.Size = new System.Drawing.Size(206, 44);
			this.devolucionesBoton.Text = "Devoluciones";
			this.devolucionesBoton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.devolucionesBoton.UseVisualStyleBackColor = false;
			this.devolucionesBoton.TabIndex = 2;
			this.devolucionesBoton.Name = "devolucionesBoton";
			this.devolucionesBoton.Click += new System.EventHandler(this.DevolucionesClick);
			// 
			// clientesBoton
			// 
			this.clientesBoton.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.clientesBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.clientesBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.clientesBoton.FlatAppearance.BorderSize = 0;
			this.clientesBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 41, 59);
			this.clientesBoton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(30, 41, 59);
			this.clientesBoton.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
			this.clientesBoton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
			this.clientesBoton.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
			this.clientesBoton.Size = new System.Drawing.Size(206, 44);
			this.clientesBoton.Text = "Antecedentes y seguros";
			this.clientesBoton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.clientesBoton.UseVisualStyleBackColor = false;
			this.clientesBoton.TabIndex = 3;
			this.clientesBoton.Name = "clientesBoton";
			this.clientesBoton.Click += new System.EventHandler(this.ClientesClick);
			// 
			// usuariosBoton
			// 
			this.usuariosBoton.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.usuariosBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.usuariosBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.usuariosBoton.FlatAppearance.BorderSize = 0;
			this.usuariosBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 41, 59);
			this.usuariosBoton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(30, 41, 59);
			this.usuariosBoton.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
			this.usuariosBoton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
			this.usuariosBoton.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
			this.usuariosBoton.Size = new System.Drawing.Size(206, 44);
			this.usuariosBoton.Text = "Usuarios y roles";
			this.usuariosBoton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.usuariosBoton.UseVisualStyleBackColor = false;
			this.usuariosBoton.TabIndex = 4;
			this.usuariosBoton.Name = "usuariosBoton";
			this.usuariosBoton.Click += new System.EventHandler(this.UsuariosClick);
			// 
			// usuario
			// 
			this.usuario.AutoSize = true;
			this.usuario.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
			this.usuario.ForeColor = System.Drawing.Color.White;
			this.usuario.Text = "Usuario";
			this.usuario.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
			this.usuario.TabIndex = 2;
			this.usuario.Name = "usuario";
			// 
			// rolLabel
			// 
			this.rolLabel.AutoSize = true;
			this.rolLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.rolLabel.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250);
			this.rolLabel.Text = "Rol";
			this.rolLabel.Margin = new System.Windows.Forms.Padding(20, 2, 0, 14);
			this.rolLabel.TabIndex = 3;
			this.rolLabel.Name = "rolLabel";
			// 
			// cerrarBoton
			// 
			this.cerrarBoton.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
			this.cerrarBoton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cerrarBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cerrarBoton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(71, 85, 105);
			this.cerrarBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 41, 59);
			this.cerrarBoton.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
			this.cerrarBoton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cerrarBoton.Margin = new System.Windows.Forms.Padding(12, 0, 12, 16);
			this.cerrarBoton.Size = new System.Drawing.Size(206, 40);
			this.cerrarBoton.Text = "Cerrar sesión";
			this.cerrarBoton.UseVisualStyleBackColor = false;
			this.cerrarBoton.TabIndex = 4;
			this.cerrarBoton.Name = "cerrarBoton";
			this.cerrarBoton.Click += new System.EventHandler(this.CerrarClick);
			this.navegacion.ResumeLayout(false);
			this.navegacion.PerformLayout();
			this.lateralLayout.ResumeLayout(false);
			this.lateralLayout.PerformLayout();
			this.lateral.ResumeLayout(false);
			this.lateral.PerformLayout();
			this.contenido.ResumeLayout(false);
			this.contenido.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
#endregion

		private System.Windows.Forms.Panel contenido;
		private System.Windows.Forms.Panel lateral;
		private System.Windows.Forms.TableLayoutPanel lateralLayout;
		private System.Windows.Forms.Label marca;
		private System.Windows.Forms.FlowLayoutPanel navegacion;
		private System.Windows.Forms.Button reservasBoton;
		private System.Windows.Forms.Button asesorBoton;
		private System.Windows.Forms.Button devolucionesBoton;
		private System.Windows.Forms.Button clientesBoton;
		private System.Windows.Forms.Button usuariosBoton;
		private System.Windows.Forms.Label usuario;
		private System.Windows.Forms.Label rolLabel;
		private System.Windows.Forms.Button cerrarBoton;
	}
}
