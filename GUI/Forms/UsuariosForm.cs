using System;
using System.Drawing;
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
						Rol = Convert.ToString(rol.SelectedItem),
						Activo = activo.Checked,
						TipoSeguro = Convert.ToString(tipoSeguroAlta.SelectedItem)
					},
					clave.Text
				);
				clave.Clear();
				nombre.Clear();
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
				Usuario seleccionado = null;

				if (grilla.CurrentRow != null)
				{
					seleccionado = grilla.CurrentRow.DataBoundItem as Usuario;
				}

				if (seleccionado == null)
				{
					throw new ArgumentException("Seleccioná un usuario.");
				}

				if (!bll.AsignarRol(seleccionado.Id, Convert.ToString(rol.SelectedItem)))
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
				Usuario seleccionado = null;

				if (grilla.CurrentRow != null)
				{
					seleccionado = grilla.CurrentRow.DataBoundItem as Usuario;
				}

				if (seleccionado == null || seleccionado.Rol != "Cliente")
				{
					throw new ArgumentException("Seleccioná un usuario con rol Cliente.");
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
				Usuario seleccionado = null;

				if (grilla.CurrentRow != null)
				{
					seleccionado = grilla.CurrentRow.DataBoundItem as Usuario;
				}

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

		private void Cargar()
		{
			grilla.DataSource = bll.Listar();

			if (grilla.Columns.Contains("Hash"))
			{
				grilla.Columns["Hash"].Visible = false;
			}

			if (grilla.Columns.Contains("Sal"))
			{
				grilla.Columns["Sal"].Visible = false;
			}

			grilla.Columns["SeguroId"].Visible = false;
			grilla.Columns["Seguro"].Visible = false;
			grilla.Columns["TipoSeguro"].HeaderText = "Seguro";
		}

		private void CambiarClaveClick(object sender, EventArgs e)
		{
			CambiarClave();
		}

		private void UsuarioSeleccionadoCambio(object sender, EventArgs e)
		{
			if (DesignMode
				|| System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
			{
				return;
			}

			nuevaClave.Clear();
			repetirClave.Clear();
			claveUsuarioLabel.Text = "Seleccioná un usuario de la lista para cambiar su contraseña.";
			seguroUsuarioLabel.Text = "Seleccioná un cliente de la lista para cambiar su seguro.";
			tipoSeguroActual.SelectedIndex = 0;
			tipoSeguroActual.Enabled = false;
			guardarSeguroUsuarioBoton.Enabled = false;

			if (grilla.CurrentRow != null)
			{
				Usuario seleccionado = grilla.CurrentRow.DataBoundItem as Usuario;

				if (seleccionado != null)
				{
					claveUsuarioLabel.Text = "Cambiar contraseña de: " + seleccionado.NombreUsuario;

					if (seleccionado.Rol == "Cliente")
					{
						seguroUsuarioLabel.Text = "Seguro de: " + seleccionado.NombreUsuario;
						tipoSeguroActual.SelectedItem = seleccionado.TipoSeguro;
						tipoSeguroActual.Enabled = true;
						guardarSeguroUsuarioBoton.Enabled = true;
					}
				}
			}
		}

		private void ConfigurarSeguroClick(object sender, EventArgs e)
		{
			ConfigurarSeguro();
		}

		private void RolAltaCambio(object sender, EventArgs e)
		{
			tipoSeguroAlta.Enabled = Convert.ToString(rol.SelectedItem) == "Cliente";

			if (!tipoSeguroAlta.Enabled)
			{
				tipoSeguroAlta.SelectedIndex = 0;
			}
		}

		private void FormatearTipoSeguro(object sender, ListControlConvertEventArgs e)
		{
			if (Convert.ToString(e.ListItem) == "SinSeguro")
			{
				e.Value = "Sin seguro";
			}
			else if (Convert.ToString(e.ListItem) == "Basico")
			{
				e.Value = "Básico";
			}
		}

		private void FormatearSeguroGrilla(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (grilla.Columns[e.ColumnIndex].DataPropertyName != "TipoSeguro")
			{
				return;
			}

			if (Convert.ToString(e.Value) == "SinSeguro")
			{
				e.Value = "Sin seguro";
				e.FormattingApplied = true;
			}
			else if (Convert.ToString(e.Value) == "Basico")
			{
				e.Value = "Básico";
				e.FormattingApplied = true;
			}
		}

		private void GuardarClick(object sender, EventArgs e)
		{
			GuardarUsuario();
		}

		private void AsignarClick(object sender, EventArgs e)
		{
			AsignarRol();
		}

		private void CargarClick(object sender, EventArgs e)
		{
			if (DesignMode
				|| System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
			{
				return;
			}

			try
			{
				Cargar();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message);
				Close();
			}
		}
	}
}
