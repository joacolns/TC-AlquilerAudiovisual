using System;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using SERVICE;

namespace GUI
{
	public partial class LoginForm : Form
	{
		private readonly UsuarioBLL usuarios = new UsuarioBLL();
		private readonly Seguridad seguridad = new Seguridad();

		public LoginForm()
		{
			InitializeComponent();
		}

		public void Ingresar()
		{
			try
			{
				if (!usuarios.IniciarSesion(nombre.Text, clave.Text))
				{
					MessageBox.Show(this, "Usuario o contraseña incorrectos, o cuenta inactiva.", "Acceso");
					return;
				}

				clave.Clear();
				vistas.TabPages.Remove(accesoTab);
				vistas.TabPages.Add(menuTab);
				vistas.SelectedTab = menuTab;
				AcceptButton = null;
				estado.Text = SesionSingleton.Instancia.UsuarioActual.NombreUsuario + " · " + SesionSingleton.Instancia.UsuarioActual.Rol;
				equiposBoton.Enabled = seguridad.TienePermiso("Equipo.Consultar");
				reservasBoton.Enabled = seguridad.TienePermiso("Reserva.Cotizar");
				clientesBoton.Enabled = seguridad.TienePermiso("Cliente.Gestionar");
				usuariosBoton.Enabled = seguridad.TienePermiso("Usuario.Gestionar");
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "No se pudo ingresar");
			}
		}

		public void CerrarSesion()
		{
			SesionSingleton.Instancia.Cerrar();
			vistas.TabPages.Remove(menuTab);
			vistas.TabPages.Add(accesoTab);
			vistas.SelectedTab = accesoTab;
			clave.Clear();
			nombre.Focus();
			AcceptButton = ingresarBoton;
		}

		private void Abrir(Form formulario)
		{
			using (formulario)
			{
				formulario.ShowDialog(this);
			}

			if (SesionSingleton.Instancia.UsuarioActual == null)
			{
				CerrarSesion();
			}
		}

		private void IngresarClick(object sender, EventArgs e)
		{
			Ingresar();
		}

		private void CerrarClick(object sender, EventArgs e)
		{
			CerrarSesion();
		}

		private void EquiposClick(object sender, EventArgs e)
		{
			Abrir(new EquiposForm());
		}

		private void ReservasClick(object sender, EventArgs e)
		{
			Abrir(new ReservasForm());
		}

		private void ClientesClick(object sender, EventArgs e)
		{
			Abrir(new ClientesForm());
		}

		private void UsuariosClick(object sender, EventArgs e)
		{
			Abrir(new UsuariosForm());
		}

		private void Salir(object sender, FormClosedEventArgs e)
		{
			SesionSingleton.Instancia.Cerrar();
		}

		private void PrepararPantalla(object sender, EventArgs e)
		{
			if (DesignMode
				|| System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
			{
				return;
			}

			vistas.TabPages.Remove(menuTab);
			vistas.SelectedTab = accesoTab;
		}
	}
}
