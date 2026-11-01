using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BE;
using BLL;
using SERVICE;

namespace GUI
{
	public partial class ClientesForm : Form
	{
		private readonly ClienteBLL bll = new ClienteBLL();
		private readonly UsuarioBLL usuarios = new UsuarioBLL();
		private int seguroId;
		private const string NotaSeguro = "Básico: 25% de daño reparable. Intermedio: 50% de daños. Completo: 80% de daños y faltantes. Hasta el tope por unidad; los atrasos no tienen cobertura.";

		public ClientesForm()
		{
			InitializeComponent();
			desde.ValueChanged += FechasSeguroCambio;
			hasta.ValueChanged += FechasSeguroCambio;
			AplicarEstilo();
		}

		public void GuardarCliente()
		{
			try
			{
				Usuario usuario = cuenta.SelectedItem as Usuario;
				int id = bll.Guardar(
					new Cliente
					{
						Usuario = usuario,
						DniCuit = dni.Text,
						Nombre = nombre.Text,
						Telefono = telefono.Text,
						Email = email.Text
					}
				);
				Cargar();
				MessageBox.Show(this, "Cliente creado: " + id);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "No se guardó el cliente");
			}
		}

		public void GuardarSeguro()
		{
			try
			{
				if (hasta.Value.Date <= desde.Value.Date)
				{
					throw new ArgumentException("La fecha final de la vigencia debe ser posterior a la fecha de inicio.");
				}

				int id = bll.GuardarSeguro(
					new Seguro
					{
						Id = seguroId,
						Cliente = clienteSeguro.SelectedItem as Cliente,
						Tipo = Convert.ToString(tipoSeguro.SelectedItem),
						Detalle = detalleSeguro.Text,
						Poliza = poliza.Text,
						Aseguradora = aseguradora.Text,
						Desde = desde.Value.Date,
						Hasta = hasta.Value.Date.AddDays(1).AddTicks(-1),
						Cobertura = cobertura.Value
					}
				);
				CargarSeguros();
				MessageBox.Show(this, "Seguro guardado: " + id);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "No se guardó el seguro");
			}
		}

		private void Cargar()
		{
			List<Usuario> disponibles = new List<Usuario>();

			foreach (Usuario usuario in usuarios.Listar())
			{
				if (usuario.Rol == "Cliente" && usuario.Activo)
				{
					disponibles.Add(usuario);
				}
			}

			cuenta.DataSource = disponibles;
			clientes.DataSource = bll.Listar();
			clientes.Columns["Antecedentes"].HeaderText = "Antecedentes (historial de incidentes)";
			clientes.Columns["Antecedentes"].MinimumWidth = 220;
			clienteSeguro.DataSource = bll.Listar();
		}

		private void FormatearAntecedentes(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex < 0 || clientes.Columns[e.ColumnIndex] != clientesAntecedentesColumna)
			{
				return;
			}

			string historial = Convert.ToString(e.Value);

			if (string.IsNullOrWhiteSpace(historial))
			{
				historial = "Sin antecedentes";
			}

			e.Value = historial.Replace(Environment.NewLine, " | ");
			clientes.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = historial;
			e.FormattingApplied = true;
		}

		private void SeleccionarCliente(object sender, EventArgs e)
		{
			if (DesignMode
				|| System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
			{
				return;
			}

			Cliente cliente = null;

			if (clientes.CurrentRow != null && clientes.CurrentRow.Selected)
			{
				cliente = clientes.CurrentRow.DataBoundItem as Cliente;
			}

			Usuario usuario = SesionSingleton.Instancia.UsuarioActual;
			eliminarAntecedentesBoton.Enabled = usuario != null && usuario.Rol == "Administrador" && cliente != null && !string.IsNullOrWhiteSpace(cliente.Antecedentes);
		}

		private void EliminarAntecedentesClick(object sender, EventArgs e)
		{
			if (clientes.CurrentRow == null || !clientes.CurrentRow.Selected)
			{
				return;
			}

			Cliente cliente = clientes.CurrentRow.DataBoundItem as Cliente;

			if (cliente == null)
			{
				return;
			}

			try
			{
				bll.EliminarAntecedentes(cliente.Id);
				Cargar();
				SeleccionarCliente(this, EventArgs.Empty);
				MessageBox.Show(this, "Antecedentes eliminados de " + cliente.Nombre + ".");
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "No se eliminaron los antecedentes");
			}
		}

		private void CargarSeguros()
		{
			Cliente cliente = clienteSeguro.SelectedItem as Cliente;

			if (cliente == null)
			{
				seguros.DataSource = new List<Seguro>();
			}
			else
			{
				seguros.DataSource = bll.ListarSeguros(cliente.Id);
			}

			NuevoSeguro();
		}

		private void NuevoSeguro()
		{
			seguros.ClearSelection();
			seguroId = 0;
			guardarSeguroBoton.Text = "Crear seguro";
			tipoSeguro.SelectedIndex = 0;
			detalleSeguro.Clear();
			poliza.Clear();
			aseguradora.Clear();
			cobertura.Value = 0;
			desde.Value = DateTime.Today;
			hasta.Value = DateTime.Today.AddYears(1);
			ActualizarEstadoFechasSeguro();
		}

		private void SeguroCambio(object sender, EventArgs e)
		{
			Seguro seguro = null;

			if (seguros.CurrentRow != null && seguros.CurrentRow.Selected)
			{
				seguro = seguros.CurrentRow.DataBoundItem as Seguro;
			}

			if (seguro == null)
			{
				return;
			}

			seguroId = seguro.Id;
			guardarSeguroBoton.Text = "Guardar cambios";
			tipoSeguro.SelectedItem = seguro.Tipo;
			detalleSeguro.Text = seguro.Detalle;
			poliza.Text = seguro.Poliza;
			aseguradora.Text = seguro.Aseguradora;
			desde.Value = seguro.Desde;
			hasta.Value = seguro.Hasta;
			cobertura.Value = seguro.Cobertura;
		}

		private void FechasSeguroCambio(object sender, EventArgs e)
		{
			if (!DesignMode)
			{
				ActualizarEstadoFechasSeguro();
			}
		}

		private void ActualizarEstadoFechasSeguro()
		{
			if (hasta.Value.Date <= desde.Value.Date)
			{
				seguroNota.ForeColor = Color.FromArgb(185, 28, 28);
				seguroNota.Text = "La fecha final de la vigencia debe ser posterior a la fecha de inicio.";
			}
			else
			{
				seguroNota.ForeColor = Color.FromArgb(100, 116, 139);
				seguroNota.Text = NotaSeguro;
			}
		}

		private void GuardarClienteClick(object sender, EventArgs e)
		{
			GuardarCliente();
		}

		private void GuardarSeguroClick(object sender, EventArgs e)
		{
			GuardarSeguro();
		}

		private void NuevoSeguroClick(object sender, EventArgs e)
		{
			NuevoSeguro();
		}

		private void ClienteCambio(object sender, EventArgs e)
		{
			if (DesignMode
				|| System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
			{
				return;
			}

			try
			{
				CargarSeguros();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message);
			}
		}

		private void AplicarEstilo()
		{
			BackColor = Color.FromArgb(244, 247, 251);
			ForeColor = Color.FromArgb(15, 23, 42);
			alta.BackColor = Color.White;
			formulario.BackColor = Color.White;
			desde.Format = DateTimePickerFormat.Custom;
			desde.CustomFormat = "dd/MM/yyyy";
			hasta.Format = DateTimePickerFormat.Custom;
			hasta.CustomFormat = "dd/MM/yyyy";

			foreach (TabPage pagina in tabs.TabPages)
			{
				pagina.BackColor = Color.FromArgb(244, 247, 251);
				pagina.Padding = new Padding(12);
			}

			EstilizarBotones(this);
			EstiloBotonPrincipal(clienteBoton);
			EstiloBotonPrincipal(guardarSeguroBoton);
			ConfigurarGrilla(clientes);
			ConfigurarGrilla(seguros);
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

		private void PrepararPantalla(object sender, EventArgs e)
		{
			if (DesignMode
				|| System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
			{
				return;
			}

			desde.Value = DateTime.Today;
			hasta.Value = DateTime.Today.AddYears(1);
			ActualizarEstadoFechasSeguro();
		}
	}
}
