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
		private int seguroId;
		private const string NotaSeguro = "Básico: 25% de daño reparable. Intermedio: 50% de daños. Completo: 80% de daños y faltantes. Hasta el tope por unidad; los atrasos no tienen cobertura.";

		public ClientesForm()
		{
			InitializeComponent();
			desde.ValueChanged += FechasSeguroCambio;
			hasta.ValueChanged += FechasSeguroCambio;
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
			clientes.DataSource = bll.Listar();
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
			Cliente cliente = null;

			if (clientes.CurrentRow != null && clientes.CurrentRow.Selected)
			{
				cliente = clientes.CurrentRow.DataBoundItem as Cliente;
			}

			Usuario usuario = SesionSingleton.Instancia.UsuarioActual;
			eliminarAntecedentesBoton.Enabled = usuario != null && usuario.Rol == "Administrador" && cliente != null && !string.IsNullOrWhiteSpace(cliente.Antecedentes);
		}

		private void ActualizarClientesClick(object sender, EventArgs e)
		{
			try
			{
				clientes.DataSource = bll.Listar();
				SeleccionarCliente(this, EventArgs.Empty);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "No se pudo actualizar");
			}
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
			ActualizarEstadoFechasSeguro();
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

		private void FormatearTipoSeguro(object sender, ListControlConvertEventArgs e)
		{
			if (Convert.ToString(e.ListItem) == "Basico")
			{
				e.Value = "Básico";
			}
		}

		private void FormatearSeguro(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex >= 0 && seguros.Columns[e.ColumnIndex].DataPropertyName == "Tipo" && Convert.ToString(e.Value) == "Basico")
			{
				e.Value = "Básico";
				e.FormattingApplied = true;
			}
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
			try
			{
				CargarSeguros();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message);
			}
		}

		private void ClientesForm_Load(object sender, EventArgs e)
		{
			CargarPantalla();
		}

		private void CargarPantalla()
		{
			try
			{
				NuevoSeguro();
				Cargar();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "No se pudo abrir la pantalla", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
