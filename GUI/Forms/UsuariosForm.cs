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
			AplicarEstilo();
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

		private void AplicarEstilo()
		{
			BackColor = Color.FromArgb(244, 247, 251);
			ForeColor = Color.FromArgb(15, 23, 42);
			Text = "Usuarios, roles y seguridad";
			alta.BackColor = Color.White;
			cambioClavePanel.BackColor = Color.White;
			seguroUsuarioPanel.BackColor = Color.White;
			altaLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
			EstilizarBotones(this);
			EstiloBotonPrincipal(crearBoton);
			EstiloBotonPrincipal(cambiarClaveBoton);
			EstiloBotonPrincipal(guardarSeguroUsuarioBoton);
			ConfigurarGrilla(grilla);
		}

		private void EstilizarBotones(Control contenedor)
		{
			foreach (Control control in contenedor.Controls)
			{
				Button boton = control as Button;

				if (boton != null)
				{
					boton.FlatStyle = FlatStyle.Flat;
					boton.FlatAppearance.BorderSize = 1;
					boton.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
					boton.BackColor = Color.White;
					boton.ForeColor = Color.FromArgb(51, 65, 85);
					boton.Cursor = Cursors.Hand;
					boton.MinimumSize = new Size(120, 36);
				}

				if (control.HasChildren)
				{
					EstilizarBotones(control);
				}
			}
		}

		private void EstiloBotonPrincipal(Button boton)
		{
			boton.BackColor = Color.FromArgb(37, 99, 235);
			boton.ForeColor = Color.White;
			boton.FlatAppearance.BorderSize = 0;
			boton.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 78, 216);
		}

		private void ConfigurarGrilla(DataGridView grilla)
		{
			grilla.BackgroundColor = Color.White;
			grilla.BorderStyle = BorderStyle.None;
			grilla.RowHeadersVisible = false;
			grilla.EnableHeadersVisualStyles = false;
			grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
			grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
			grilla.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			grilla.ColumnHeadersDefaultCellStyle.Padding = new Padding(4);
			grilla.ColumnHeadersHeight = 38;
			grilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grilla.DefaultCellStyle.BackColor = Color.White;
			grilla.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
			grilla.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
			grilla.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
			grilla.DefaultCellStyle.Padding = new Padding(3);
			grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
			grilla.RowTemplate.Height = 32;
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
