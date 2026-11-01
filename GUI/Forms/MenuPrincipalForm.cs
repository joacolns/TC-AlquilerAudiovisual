using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BE;
using SERVICE;

namespace GUI
{
	public partial class MenuPrincipalForm : Form
	{
		private readonly Seguridad seguridad = new Seguridad();
		private Form seccion;
		private Button activo;

		public MenuPrincipalForm()
		{
			InitializeComponent();
		}

		public bool CerrarSesionSolicitada { get; private set; }

		private void MenuPrincipalForm_Load(object sender, EventArgs e)
		{
			CargarPantalla();
		}

		private void CargarPantalla()
		{
			Usuario sesion = SesionSingleton.Instancia.UsuarioActual;

			if (sesion == null)
			{
				Close();
				return;
			}

			// El administrador accede a todas las secciones; el resto, según sus permisos.
			bool administrador = sesion.Rol == "Administrador";
			usuario.Text = sesion.NombreUsuario;
			rolLabel.Text = NombreRol(sesion.Rol);

			if (sesion.Rol == "Cliente" || administrador)
			{
				rolLabel.Text += " · " + NombreSeguro(sesion.TipoSeguro);
			}

			reservasBoton.Visible = administrador
				|| seguridad.TienePermiso("Reserva.Consultar")
				|| seguridad.TienePermiso("Reserva.Cotizar");
			asesorBoton.Visible = administrador || seguridad.TienePermiso("Asesoramiento.Consultar");
			devolucionesBoton.Visible = administrador
				|| seguridad.TienePermiso("Devolucion.Registrar")
				|| seguridad.TienePermiso("Incidencia.AltaTecnica");
			clientesBoton.Visible = administrador || seguridad.TienePermiso("Cliente.Gestionar");
			usuariosBoton.Visible = administrador || seguridad.TienePermiso("Usuario.Gestionar");

			if (sesion.Rol == "Cliente")
			{
				reservasBoton.Text = "Mis alquileres";
			}
			else if (administrador || seguridad.TienePermiso("Equipo.Guardar"))
			{
				reservasBoton.Text = "Reservas e inventario";
			}

			if (!administrador && !seguridad.TienePermiso("Devolucion.Registrar"))
			{
				devolucionesBoton.Text = "Altas técnicas";
			}

			foreach (Button boton in navegacion.Controls)
			{
				if (boton.Visible)
				{
					Abrir(boton);
					break;
				}
			}
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

		private string NombreSeguro(string tipo)
		{
			if (tipo == "Basico")
			{
				return "Seguro básico";
			}

			if (tipo == "Intermedio" || tipo == "Completo")
			{
				return "Seguro " + tipo.ToLower();
			}

			return "Sin seguro";
		}

		private void Abrir(Button boton)
		{
			if (boton == activo)
			{
				return;
			}

			Form nueva;

			if (boton == reservasBoton)
			{
				nueva = new ReservasForm();
			}
			else if (boton == asesorBoton)
			{
				nueva = new AsesorForm();
			}
			else if (boton == devolucionesBoton)
			{
				nueva = new DevolucionesForm();
			}
			else if (boton == clientesBoton)
			{
				nueva = new ClientesForm();
			}
			else
			{
				nueva = new UsuariosForm();
			}

			if (seccion != null)
			{
				contenido.Controls.Remove(seccion);
				seccion.Dispose();
			}

			nueva.TopLevel = false;
			nueva.Dock = DockStyle.Fill;
			nueva.FormClosed += SeccionCerrada;
			contenido.Controls.Add(nueva);
			seccion = nueva;
			Resaltar(boton);
			nueva.Show();
		}

		private void Resaltar(Button boton)
		{
			if (activo != null)
			{
				activo.BackColor = Color.FromArgb(15, 23, 42);
				activo.ForeColor = Color.FromArgb(203, 213, 225);
			}

			activo = boton;
			activo.BackColor = Color.FromArgb(30, 41, 59);
			activo.ForeColor = Color.White;
		}

		private void SeccionCerrada(object sender, FormClosedEventArgs e)
		{
			// Una sección se cierra sola cuando la sesión deja de ser válida (por ejemplo, al cambiar el propio rol).
			if (SesionSingleton.Instancia.UsuarioActual == null)
			{
				CerrarSesionSolicitada = true;
				BeginInvoke(new MethodInvoker(Close));
			}
		}

		// Lleva una propuesta del asesor a "Nueva solicitud" con fechas y equipos ya cargados.
		public void IrASolicitud(DateTime desde, DateTime hasta, List<int> equipoIds)
		{
			BeginInvoke(
				new MethodInvoker(
					delegate
					{
						Abrir(reservasBoton);
						ReservasForm reservas = seccion as ReservasForm;

						if (reservas != null)
						{
							reservas.PrepararSolicitud(desde, hasta, equipoIds);
						}
					}
				)
			);
		}

		private void AsesorClick(object sender, EventArgs e)
		{
			Abrir(asesorBoton);
		}

		private void ReservasClick(object sender, EventArgs e)
		{
			Abrir(reservasBoton);
		}

		private void DevolucionesClick(object sender, EventArgs e)
		{
			Abrir(devolucionesBoton);
		}

		private void ClientesClick(object sender, EventArgs e)
		{
			Abrir(clientesBoton);
		}

		private void UsuariosClick(object sender, EventArgs e)
		{
			Abrir(usuariosBoton);
		}

		private void CerrarClick(object sender, EventArgs e)
		{
			CerrarSesionSolicitada = true;
			SesionSingleton.Instancia.Cerrar();
			Close();
		}

	}
}
