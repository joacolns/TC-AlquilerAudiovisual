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
            this.accesoPanel = new System.Windows.Forms.Panel();
            this.accesoCentro = new System.Windows.Forms.TableLayoutPanel();
            this.acceso = new System.Windows.Forms.TableLayoutPanel();
            this.accesoTitulo = new System.Windows.Forms.Label();
            this.usuarioLabel = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.TextBox();
            this.claveLabel = new System.Windows.Forms.Label();
            this.clave = new System.Windows.Forms.TextBox();
            this.mostrarClave = new System.Windows.Forms.CheckBox();
            this.ingresarBoton = new System.Windows.Forms.Button();
            this.presentacion = new System.Windows.Forms.Panel();
            this.marca = new System.Windows.Forms.Label();
            this.accesoPanel.SuspendLayout();
            this.accesoCentro.SuspendLayout();
            this.acceso.SuspendLayout();
            this.presentacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // accesoPanel
            // 
            this.accesoPanel.BackColor = System.Drawing.Color.White;
            this.accesoPanel.Controls.Add(this.accesoCentro);
            this.accesoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accesoPanel.Location = new System.Drawing.Point(340, 0);
            this.accesoPanel.Name = "accesoPanel";
            this.accesoPanel.Size = new System.Drawing.Size(540, 520);
            this.accesoPanel.TabIndex = 0;
            // 
            // accesoCentro
            // 
            this.accesoCentro.BackColor = System.Drawing.Color.White;
            this.accesoCentro.ColumnCount = 3;
            this.accesoCentro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.accesoCentro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 340F));
            this.accesoCentro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.accesoCentro.Controls.Add(this.acceso, 1, 1);
            this.accesoCentro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accesoCentro.Location = new System.Drawing.Point(0, 0);
            this.accesoCentro.Name = "accesoCentro";
            this.accesoCentro.RowCount = 3;
            this.accesoCentro.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.accesoCentro.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.accesoCentro.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.accesoCentro.Size = new System.Drawing.Size(540, 520);
            this.accesoCentro.TabIndex = 0;
            // 
            // acceso
            // 
            this.acceso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.acceso.AutoSize = true;
            this.acceso.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.acceso.BackColor = System.Drawing.Color.White;
            this.acceso.ColumnCount = 1;
            this.acceso.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 340F));
            this.acceso.Controls.Add(this.accesoTitulo, 0, 0);
            this.acceso.Controls.Add(this.usuarioLabel, 0, 1);
            this.acceso.Controls.Add(this.nombre, 0, 2);
            this.acceso.Controls.Add(this.claveLabel, 0, 3);
            this.acceso.Controls.Add(this.clave, 0, 4);
            this.acceso.Controls.Add(this.mostrarClave, 0, 5);
            this.acceso.Controls.Add(this.ingresarBoton, 0, 6);
            this.acceso.Location = new System.Drawing.Point(103, 119);
            this.acceso.MinimumSize = new System.Drawing.Size(340, 0);
            this.acceso.Name = "acceso";
            this.acceso.RowCount = 7;
            this.acceso.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.acceso.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.acceso.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.acceso.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.acceso.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.acceso.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.acceso.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.acceso.Size = new System.Drawing.Size(340, 282);
            this.acceso.TabIndex = 0;
            // 
            // accesoTitulo
            // 
            this.accesoTitulo.AutoSize = true;
            this.accesoTitulo.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.accesoTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.accesoTitulo.Location = new System.Drawing.Point(0, 0);
            this.accesoTitulo.Margin = new System.Windows.Forms.Padding(0, 0, 0, 28);
            this.accesoTitulo.Name = "accesoTitulo";
            this.accesoTitulo.Size = new System.Drawing.Size(201, 41);
            this.accesoTitulo.TabIndex = 0;
            this.accesoTitulo.Text = "Iniciar sesión";
            // 
            // usuarioLabel
            // 
            this.usuarioLabel.AutoSize = true;
            this.usuarioLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.usuarioLabel.Location = new System.Drawing.Point(0, 69);
            this.usuarioLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.usuarioLabel.Name = "usuarioLabel";
            this.usuarioLabel.Size = new System.Drawing.Size(56, 19);
            this.usuarioLabel.TabIndex = 1;
            this.usuarioLabel.Text = "Usuario";
            // 
            // nombre
            // 
            this.nombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nombre.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nombre.Location = new System.Drawing.Point(0, 92);
            this.nombre.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
            this.nombre.MaxLength = 50;
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(340, 27);
            this.nombre.TabIndex = 2;
            // 
            // claveLabel
            // 
            this.claveLabel.AutoSize = true;
            this.claveLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.claveLabel.Location = new System.Drawing.Point(0, 135);
            this.claveLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.claveLabel.Name = "claveLabel";
            this.claveLabel.Size = new System.Drawing.Size(79, 19);
            this.claveLabel.TabIndex = 3;
            this.claveLabel.Text = "Contraseña";
            // 
            // clave
            // 
            this.clave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clave.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.clave.Location = new System.Drawing.Point(0, 158);
            this.clave.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.clave.MaxLength = 128;
            this.clave.Name = "clave";
            this.clave.Size = new System.Drawing.Size(340, 27);
            this.clave.TabIndex = 4;
            this.clave.UseSystemPasswordChar = true;
            // 
            // mostrarClave
            // 
            this.mostrarClave.AutoSize = true;
            this.mostrarClave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mostrarClave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.mostrarClave.Location = new System.Drawing.Point(0, 193);
            this.mostrarClave.Margin = new System.Windows.Forms.Padding(0, 0, 0, 24);
            this.mostrarClave.Name = "mostrarClave";
            this.mostrarClave.Size = new System.Drawing.Size(128, 19);
            this.mostrarClave.TabIndex = 5;
            this.mostrarClave.Text = "Mostrar contraseña";
            this.mostrarClave.UseVisualStyleBackColor = true;
            this.mostrarClave.CheckedChanged += new System.EventHandler(this.MostrarClaveCambio);
            // 
            // ingresarBoton
            // 
            this.ingresarBoton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.ingresarBoton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ingresarBoton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ingresarBoton.FlatAppearance.BorderSize = 0;
            this.ingresarBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            this.ingresarBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ingresarBoton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.ingresarBoton.ForeColor = System.Drawing.Color.White;
            this.ingresarBoton.Location = new System.Drawing.Point(0, 236);
            this.ingresarBoton.Margin = new System.Windows.Forms.Padding(0);
            this.ingresarBoton.Name = "ingresarBoton";
            this.ingresarBoton.Size = new System.Drawing.Size(340, 46);
            this.ingresarBoton.TabIndex = 6;
            this.ingresarBoton.Text = "Ingresar";
            this.ingresarBoton.UseVisualStyleBackColor = false;
            this.ingresarBoton.Click += new System.EventHandler(this.IngresarClick);
            // 
            // presentacion
            // 
            this.presentacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.presentacion.Controls.Add(this.marca);
            this.presentacion.Dock = System.Windows.Forms.DockStyle.Left;
            this.presentacion.Location = new System.Drawing.Point(0, 0);
            this.presentacion.Name = "presentacion";
            this.presentacion.Size = new System.Drawing.Size(340, 520);
            this.presentacion.TabIndex = 1;
            // 
            // marca
            // 
            this.marca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.marca.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
            this.marca.ForeColor = System.Drawing.Color.White;
            this.marca.Location = new System.Drawing.Point(0, 0);
            this.marca.Name = "marca";
            this.marca.Size = new System.Drawing.Size(340, 520);
            this.marca.TabIndex = 0;
            this.marca.Text = "FOCO";
            this.marca.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.ingresarBoton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(880, 520);
            this.Controls.Add(this.accesoPanel);
            this.Controls.Add(this.presentacion);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FOCO · Ingresar";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Salir);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.accesoPanel.ResumeLayout(false);
            this.accesoCentro.ResumeLayout(false);
            this.accesoCentro.PerformLayout();
            this.acceso.ResumeLayout(false);
            this.acceso.PerformLayout();
            this.presentacion.ResumeLayout(false);
            this.ResumeLayout(false);

		}
#endregion

		private System.Windows.Forms.Panel accesoPanel;
		private System.Windows.Forms.TableLayoutPanel accesoCentro;
		private System.Windows.Forms.TableLayoutPanel acceso;
		private System.Windows.Forms.Label accesoTitulo;
		private System.Windows.Forms.Label usuarioLabel;
		private System.Windows.Forms.TextBox nombre;
		private System.Windows.Forms.Label claveLabel;
		private System.Windows.Forms.TextBox clave;
		private System.Windows.Forms.CheckBox mostrarClave;
		private System.Windows.Forms.Button ingresarBoton;
		private System.Windows.Forms.Panel presentacion;
		private System.Windows.Forms.Label marca;
	}
}
