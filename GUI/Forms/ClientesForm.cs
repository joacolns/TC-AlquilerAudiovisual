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

		public ClientesForm()
		{
			InitializeComponent();
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
						Hasta = hasta.Value.Date,
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
		}
	}
}
