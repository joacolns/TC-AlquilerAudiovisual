using System;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using SERVICE;

namespace GUI
{
    public class LoginForm : Form
    {
        private readonly UsuarioBLL usuarios = new UsuarioBLL();
        private readonly Seguridad seguridad = new Seguridad();
        private readonly TextBox nombre = new TextBox { Width = 240, MaxLength = 50 };
        private readonly TextBox clave = new TextBox { Width = 240, UseSystemPasswordChar = true, MaxLength = 128 };
        private readonly Label estado = new Label { AutoSize = true };
        private readonly FlowLayoutPanel acceso = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 210, FlowDirection = FlowDirection.TopDown, Padding = new Padding(24) };
        private readonly FlowLayoutPanel menu = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, Padding = new Padding(24), Visible = false };

        public LoginForm()
        {
            Text = "Alquiler audiovisual · ENTREGA1"; ClientSize = new Size(520, 440);
            StartPosition = FormStartPosition.CenterScreen; Font = new Font("Segoe UI", 10);
            acceso.Controls.Add(new Label { Text = "Usuario", AutoSize = true }); acceso.Controls.Add(nombre);
            acceso.Controls.Add(new Label { Text = "Contraseña", AutoSize = true }); acceso.Controls.Add(clave);
            Button ingresar = Boton("Ingresar", IngresarClick); acceso.Controls.Add(ingresar); AcceptButton = ingresar;
            menu.Controls.Add(estado);
            menu.Controls.Add(Boton("Consultar y gestionar equipos", EquiposClick));
            menu.Controls.Add(Boton("Solicitudes, reservas y entrega", ReservasClick));
            menu.Controls.Add(Boton("Clientes y seguros", ClientesClick));
            menu.Controls.Add(Boton("Usuarios y roles", UsuariosClick));
            menu.Controls.Add(Boton("Cerrar sesión", CerrarClick));
            Controls.Add(menu); Controls.Add(acceso);
            FormClosed += Salir;
        }

        public void Ingresar()
        {
            try
            {
                if (!usuarios.IniciarSesion(nombre.Text, clave.Text)) { MessageBox.Show(this, "Usuario o contraseña incorrectos, o cuenta inactiva.", "Acceso"); return; }
                clave.Clear(); acceso.Visible = false; menu.Visible = true; AcceptButton = null;
                estado.Text = SesionSingleton.Instancia.UsuarioActual.NombreUsuario + " · " + SesionSingleton.Instancia.UsuarioActual.Rol;
                menu.Controls[1].Enabled = seguridad.TienePermiso("Equipo.Consultar");
                menu.Controls[2].Enabled = seguridad.TienePermiso("Reserva.Cotizar");
                menu.Controls[3].Enabled = seguridad.TienePermiso("Cliente.Gestionar");
                menu.Controls[4].Enabled = seguridad.TienePermiso("Usuario.Gestionar");
            }
            catch (Exception ex) { MessageBox.Show(this, ex.Message, "No se pudo ingresar"); }
        }

        public void CerrarSesion()
        {
            SesionSingleton.Instancia.Cerrar(); menu.Visible = false; acceso.Visible = true; clave.Clear(); nombre.Focus();
            AcceptButton = (Button)acceso.Controls[4];
        }

        private Button Boton(string texto, EventHandler evento)
        {
            Button boton = new Button { Text = texto, Width = 400, Height = 38 }; boton.Click += evento; return boton;
        }
        private void Abrir(Form formulario)
        {
            using (formulario) formulario.ShowDialog(this);
            if (SesionSingleton.Instancia.UsuarioActual == null) CerrarSesion();
        }
        private void IngresarClick(object sender, EventArgs e) { Ingresar(); }
        private void CerrarClick(object sender, EventArgs e) { CerrarSesion(); }
        private void EquiposClick(object sender, EventArgs e) { Abrir(new EquiposForm()); }
        private void ReservasClick(object sender, EventArgs e) { Abrir(new ReservasForm()); }
        private void ClientesClick(object sender, EventArgs e) { Abrir(new ClientesForm()); }
        private void UsuariosClick(object sender, EventArgs e) { Abrir(new UsuariosForm()); }
        private void Salir(object sender, FormClosedEventArgs e) { SesionSingleton.Instancia.Cerrar(); }
    }
}
