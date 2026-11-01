using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using BLL;
using SERVICE;

namespace GUI
{
	public partial class LoginForm : Form
	{
		private readonly UsuarioBLL usuarios = new UsuarioBLL();
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

			if (string.IsNullOrWhiteSpace(nombre.Text) || string.IsNullOrEmpty(clave.Text))
			{
				MessageBox.Show(this, "Ingresá tu usuario y contraseña.", "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
					MessageBox.Show(
						this,
						"Usuario o contraseña incorrectos, o cuenta inactiva.",
						"No se pudo ingresar",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning
					);
					clave.Focus();
					clave.SelectAll();
					return;
				}

				clave.Clear();
				AcceptButton = null;

				using (MenuPrincipalForm menu = new MenuPrincipalForm())
				{
					Hide();
					menu.ShowDialog(this);

					if (menu.CerrarSesionSolicitada)
					{
						RestablecerAcceso();
						Show();
						Activate();
					}
					else
					{
						cerrando = true;
						Close();
					}
				}
			}
			catch (Exception ex)
			{
				if (!cerrando && !IsDisposed)
				{
					Show();
					MessageBox.Show(this, ex.Message, "No se pudo ingresar", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

		private void RestablecerAcceso()
		{
			clave.Clear();
			AcceptButton = ingresarBoton;
			nombre.Focus();
		}

		private void IngresarClick(object sender, EventArgs e)
		{
			Ingresar();
		}

		private void MostrarClaveCambio(object sender, EventArgs e)
		{
			clave.UseSystemPasswordChar = !mostrarClave.Checked;
		}

		private void Salir(object sender, FormClosedEventArgs e)
		{
			cerrando = true;
			SesionSingleton.Instancia.Cerrar();
		}

		private void marca_Click(object sender, EventArgs e)
		{

		}

		private void LoginForm_Load(object sender, EventArgs e)
		{

		}
	}
}
