using System;
using System.Drawing;
using System.Windows.Forms;
using SERVICE;

namespace GUI
{
	public partial class MenuPrincipalForm : Form
	{
		private readonly Seguridad seguridad = new Seguridad();

		public MenuPrincipalForm()
		{
			InitializeComponent();
		}

		public bool CerrarSesionSolicitada { get; private set; }

		private void ConfigurarAccesos()
		{
			if (SesionSingleton.Instancia.UsuarioActual == null)
			{
				Close();
				return;
			}

			string rol = SesionSingleton.Instancia.UsuarioActual.Rol;
			bool administrador = rol == "Administrador";
			bienvenida.Text = "Hola, " + SesionSingleton.Instancia.UsuarioActual.NombreUsuario;
			rolLabel.Text = NombreRol(rol);

			equiposReservasBoton.Visible = administrador
				|| seguridad.TienePermiso("Reserva.Consultar")
				|| seguridad.TienePermiso("Reserva.Cotizar");
			devolucionesBoton.Visible = administrador
				|| seguridad.TienePermiso("Devolucion.Registrar")
				|| seguridad.TienePermiso("Incidencia.AltaTecnica");
			clientesBoton.Visible = administrador || seguridad.TienePermiso("Cliente.Gestionar");
			usuariosBoton.Visible = administrador || seguridad.TienePermiso("Usuario.Gestionar");
		}

		private string NombreRol(string rol)
		{
			if (rol == "EncargadoStock")
			{
				return "Encargado de stock";
			}

			if (rol == "Tecnico")
			{
				return "Técnico";
			}

			return rol;
		}

		private void Abrir(Form formulario)
		{
			using (formulario)
			{
				formulario.ShowDialog(this);
			}

			if (SesionSingleton.Instancia.UsuarioActual == null)
			{
				CerrarSesionSolicitada = true;
				Close();
			}
		}

		private void EquiposReservasClick(object sender, EventArgs e)
		{
			Abrir(new ReservasForm());
		}

		private void DevolucionesClick(object sender, EventArgs e)
		{
			Abrir(new DevolucionesForm());
		}

		private void ClientesClick(object sender, EventArgs e)
		{
			Abrir(new ClientesForm());
		}

		private void UsuariosClick(object sender, EventArgs e)
		{
			Abrir(new UsuariosForm());
		}

		private void CerrarClick(object sender, EventArgs e)
		{
			CerrarSesionSolicitada = true;
			SesionSingleton.Instancia.Cerrar();
			Close();
		}

		private void CargarMenu(object sender, EventArgs e)
		{
			ConfigurarAccesos();
		}
	}
}
