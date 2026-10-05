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
						Activo = activo.Checked
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

		private void Cargar()
		{
			grilla.DataSource = bll.Listar();
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
