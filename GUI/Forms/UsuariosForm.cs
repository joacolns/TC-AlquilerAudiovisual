using System;
using System.Windows.Forms;
using BE;
using BLL;
using SERVICE;

namespace GUI
{
	public partial class UsuariosForm : Form
	{
		private readonly UsuarioBLL bll = new UsuarioBLL();

		public UsuariosForm()
		{
			InitializeComponent();
		}

		public void GuardarUsuario()
		{
			try
			{
				int id = bll.Guardar(
					new Usuario
					{
						NombreUsuario = nombre.Text,
						Nombre = nombreCompleto.Text,
						Email = correo.Text,
						Telefono = telefonoUsuario.Text,
						DniCuit = dniUsuario.Text,
						Rol = Convert.ToString(rol.SelectedItem),
						Activo = activo.Checked,
						TipoSeguro = Convert.ToString(tipoSeguroAlta.SelectedItem)
					},
					clave.Text
				);
				clave.Clear();
				nombre.Clear();
				nombreCompleto.Clear();
				correo.Clear();
				telefonoUsuario.Clear();
				dniUsuario.Clear();
				Cargar();
				MessageBox.Show(this, "Usuario creado: " + id);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "No se guardó el usuario");
			}
		}

		public void AsignarRol()
		{
			try
			{
				Usuario seleccionado = UsuarioSeleccionado();

				if (seleccionado == null)
				{
					throw new ArgumentException("Seleccioná un usuario.");
				}

				if (!bll.AsignarRol(seleccionado.Id, Convert.ToString(rolAsignar.SelectedItem)))
				{
					throw new InvalidOperationException("El usuario no existe.");
				}

				if (SesionSingleton.Instancia.UsuarioActual == null)
				{
					MessageBox.Show(this, "Tu rol cambió. Volvé a ingresar.");
					Close();
					return;
				}

				Cargar();
				MessageBox.Show(this, "Rol asignado. Se aplica al próximo ingreso del usuario.");
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "No se asignó el rol");
			}
		}

		public void ConfigurarSeguro()
		{
			try
			{
				Usuario seleccionado = UsuarioSeleccionado();

				if (seleccionado == null || (seleccionado.Rol != "Cliente" && seleccionado.Rol != "Administrador"))
				{
					throw new ArgumentException("Seleccioná un usuario con rol Cliente o Administrador.");
				}

				if (!bll.ConfigurarSeguro(seleccionado.Id, Convert.ToString(tipoSeguroActual.SelectedItem)))
				{
					throw new InvalidOperationException("No se actualizó el seguro.");
				}

				Cargar();
				MessageBox.Show(this, "Seguro actualizado. Se aplica a las nuevas reservas; las aceptadas conservan lo pactado.");
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Seguro del usuario");
			}
		}

		public void CambiarClave()
		{
			try
			{
				Usuario seleccionado = UsuarioSeleccionado();

				if (seleccionado == null)
				{
					throw new ArgumentException("Seleccioná el usuario al que querés cambiarle la contraseña.");
				}

				if (nuevaClave.Text != repetirClave.Text)
				{
					throw new ArgumentException("Las contraseñas no coinciden.");
				}

				if (!bll.CambiarClave(seleccionado.Id, nuevaClave.Text))
				{
					throw new InvalidOperationException("El usuario no existe.");
				}

				nuevaClave.Clear();
				repetirClave.Clear();
				MessageBox.Show(this, "Contraseña actualizada para " + seleccionado.NombreUsuario + ". Se usa al próximo ingreso.");
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "No se cambió la contraseña");
			}
		}

		private Usuario UsuarioSeleccionado()
		{
			if (grilla.CurrentRow == null)
			{
				return null;
			}

			return grilla.CurrentRow.DataBoundItem as Usuario;
		}

		private void Cargar()
		{
			grilla.DataSource = bll.Listar();
		}

		private void UsuarioSeleccionadoCambio(object sender, EventArgs e)
		{
			Usuario seleccionado = UsuarioSeleccionado();
			bool hay = seleccionado != null;
			bool esCliente = hay && (seleccionado.Rol == "Cliente" || seleccionado.Rol == "Administrador");

			nuevaClave.Clear();
			repetirClave.Clear();
			rolAsignar.Enabled = hay;
			rolBoton.Enabled = hay;
			nuevaClave.Enabled = hay;
			repetirClave.Enabled = hay;
			cambiarClaveBoton.Enabled = hay;
			tipoSeguroActual.Enabled = esCliente;
			guardarSeguroUsuarioBoton.Enabled = esCliente;

			if (!hay)
			{
				claveUsuarioLabel.Text = "Seleccioná un usuario de la lista.";
				return;
			}

			claveUsuarioLabel.Text = "Usuario seleccionado: " + seleccionado.NombreUsuario;
			rolAsignar.SelectedItem = seleccionado.Rol;

			if (esCliente)
			{
				tipoSeguroActual.SelectedItem = seleccionado.TipoSeguro;
			}
			else
			{
				tipoSeguroActual.SelectedIndex = 0;
			}
		}

		private void RolAltaCambio(object sender, EventArgs e)
		{
			string elegido = Convert.ToString(rol.SelectedItem);
			tipoSeguroAlta.Enabled = elegido == "Cliente" || elegido == "Administrador";

			if (!tipoSeguroAlta.Enabled)
			{
				tipoSeguroAlta.SelectedIndex = 0;
			}
		}

		private void FormatearRol(object sender, ListControlConvertEventArgs e)
		{
			e.Value = NombreRol(Convert.ToString(e.ListItem));
		}

		private void FormatearTipoSeguro(object sender, ListControlConvertEventArgs e)
		{
			e.Value = NombreSeguro(Convert.ToString(e.ListItem));
		}

		private void FormatearGrilla(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex < 0)
			{
				return;
			}

			string propiedad = grilla.Columns[e.ColumnIndex].DataPropertyName;

			if (propiedad == "Rol")
			{
				e.Value = NombreRol(Convert.ToString(e.Value));
				e.FormattingApplied = true;
			}
			else if (propiedad == "TipoSeguro")
			{
				e.Value = NombreSeguro(Convert.ToString(e.Value));
				e.FormattingApplied = true;
			}
			else if (propiedad == "Activo")
			{
				if (Convert.ToBoolean(e.Value))
				{
					e.Value = "Sí";
				}
				else
				{
					e.Value = "No";
				}

				e.FormattingApplied = true;
			}
		}

		private string NombreRol(string codigo)
		{
			if (codigo == "EncargadoStock")
			{
				return "Encargado de stock";
			}

			if (codigo == "Tecnico")
			{
				return "Técnico";
			}

			return codigo;
		}

		private string NombreSeguro(string tipo)
		{
			if (tipo == "SinSeguro")
			{
				return "Sin seguro";
			}

			if (tipo == "Basico")
			{
				return "Básico";
			}

			return tipo;
		}

		private void GuardarClick(object sender, EventArgs e)
		{
			GuardarUsuario();
		}

		private void AsignarClick(object sender, EventArgs e)
		{
			AsignarRol();
		}

		private void CambiarClaveClick(object sender, EventArgs e)
		{
			CambiarClave();
		}

		private void ConfigurarSeguroClick(object sender, EventArgs e)
		{
			ConfigurarSeguro();
		}

		private void UsuariosForm_Load(object sender, EventArgs e)
		{
			CargarPantalla();
		}

		private void CargarPantalla()
		{
			try
			{
				tipoSeguroAlta.SelectedIndex = 0;
				rol.SelectedIndex = 0;
				Cargar();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "No se pudo abrir la pantalla", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
