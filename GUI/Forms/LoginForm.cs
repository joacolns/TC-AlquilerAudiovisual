using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using BLL;
using SERVICE;

namespace GUI
{
	public partial class LoginForm : Form
	{
		private readonly UsuarioBLL usuarios = new UsuarioBLL();
		private readonly Seguridad seguridad = new Seguridad();
		private bool ingresando;
		private string nombreIngreso;
		private string claveIngreso;
		private volatile bool cerrando;

		public LoginForm()
		{
			InitializeComponent();
		}

		public async void Ingresar()
		{
			if (ingresando)
			{
				return;
			}

			ingresando = true;
			nombreIngreso = nombre.Text;
			claveIngreso = clave.Text;
			ingresarBoton.Enabled = false;
			ingresarBoton.Text = "Ingresando...";
			nombre.Enabled = false;
			clave.Enabled = false;
			UseWaitCursor = true;

			try
			{
				bool valido = await Task.Run(Autenticar);

				if (cerrando || IsDisposed)
				{
					SesionSingleton.Instancia.Cerrar();
					return;
				}

				if (!valido)
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
				devolucionesBoton.Enabled = seguridad.TienePermiso("Devolucion.Registrar") || seguridad.TienePermiso("Incidencia.AltaTecnica");
			}
			catch (Exception ex)
			{
				if (!cerrando && !IsDisposed)
				{
					MessageBox.Show(this, ex.Message, "No se pudo ingresar");
				}
			}
			finally
			{
				nombreIngreso = null;
				claveIngreso = null;
				ingresando = false;

				if (!IsDisposed)
				{
					ingresarBoton.Enabled = true;
					ingresarBoton.Text = "Ingresar";
					nombre.Enabled = true;
					clave.Enabled = true;
					UseWaitCursor = false;
				}
			}
		}

		private bool Autenticar()
		{
			bool valido = usuarios.IniciarSesion(nombreIngreso, claveIngreso);

			if (cerrando)
			{
				SesionSingleton.Instancia.Cerrar();
				return false;
			}

			return valido;
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

		private void DevolucionesClick(object sender, EventArgs e)
		{
			Abrir(new DevolucionesForm());
		}

		private void UsuariosClick(object sender, EventArgs e)
		{
			Abrir(new UsuariosForm());
		}

		private void Salir(object sender, FormClosedEventArgs e)
		{
			cerrando = true;
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
