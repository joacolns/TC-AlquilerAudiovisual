using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BE;
using BLL;
using SERVICE;

namespace GUI
{
	public partial class EquiposForm : Form
	{
		private readonly EquipoBLL bll = new EquipoBLL();
		private readonly ClienteBLL clientes = new ClienteBLL();
		private readonly Seguridad seguridad = new Seguridad();
		private int equipoId;

		public EquiposForm()
		{
			InitializeComponent();
		}

		public void GuardarEquipo()
		{
			try
			{
				Seguro seleccion = seguro.SelectedItem as Seguro;

				if (seleccion == null || seleccion.Id == 0)
				{
					seleccion = null;
				}

				int id = bll.Guardar(
					new Equipo
					{
						Id = equipoId,
						CodigoInventario = codigo.Text,
						Serie = serie.Text,
						Categoria = categoria.Text,
						Marca = marca.Text,
						Modelo = modelo.Text,
						Descripcion = descripcion.Text,
						Estado = Convert.ToString(estado.SelectedItem),
						TarifaDiaria = tarifa.Value,
						ValorReposicion = reposicion.Value,
						DiasReacondicionamiento = (int)dias.Value,
						Seguro = seleccion
					}
				);
				Cargar();
				Nuevo();
				MessageBox.Show(this, "Unidad guardada: " + id);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "No se guardó el equipo");
			}
		}

		public void ConsultarDisponibles()
		{
			try
			{
				grilla.DataSource = bll.ListarDisponibles(desde.Value, hasta.Value);
				grilla.ClearSelection();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "No se consultó disponibilidad");
			}
		}

		private void Cargar()
		{
			grilla.DataSource = bll.Listar();
		}

		private void CargarSeguros()
		{
			List<Seguro> opciones = new List<Seguro>
			{
				new Seguro
				{
					Poliza = "Sin seguro"
				}
			};
			Cliente actual = cliente.SelectedItem as Cliente;

			if (actual != null)
			{
				opciones.AddRange(clientes.ListarSeguros(actual.Id));
			}

			seguro.DataSource = opciones;
		}

		private void Nuevo()
		{
			grilla.ClearSelection();
			equipoId = 0;
			codigo.Clear();
			serie.Clear();
			categoria.Clear();
			marca.Clear();
			modelo.Clear();
			descripcion.Clear();
			tarifa.Value = 0;
			reposicion.Value = 0;
			dias.Value = 1;
			estado.SelectedIndex = 0;

			if (seguro.Items.Count > 0)
			{
				seguro.SelectedIndex = 0;
			}
		}

		private void EquipoCambio(object sender, EventArgs e)
		{
			if (!mantenimiento.Visible)
			{
				return;
			}

			Equipo actual = null;

			if (grilla.CurrentRow != null && grilla.CurrentRow.Selected)
			{
				actual = grilla.CurrentRow.DataBoundItem as Equipo;
			}

			if (actual == null)
			{
				return;
			}

			equipoId = actual.Id;
			codigo.Text = actual.CodigoInventario;
			serie.Text = actual.Serie;
			categoria.Text = actual.Categoria;
			marca.Text = actual.Marca;
			modelo.Text = actual.Modelo;
			descripcion.Text = actual.Descripcion;
			tarifa.Value = actual.TarifaDiaria;
			reposicion.Value = actual.ValorReposicion;
			dias.Value = actual.DiasReacondicionamiento;
			estado.SelectedItem = actual.Estado;

			if (actual.Seguro != null)
			{
				for (int i = 0; i < cliente.Items.Count; i++)
				{
					if (((Cliente)cliente.Items[i]).Id == actual.Seguro.ClienteId)
					{
						cliente.SelectedIndex = i;
						break;
					}
				}

				for (int i = 0; i < seguro.Items.Count; i++)
				{
					if (((Seguro)seguro.Items[i]).Id == actual.Seguro.Id)
					{
						seguro.SelectedIndex = i;
						break;
					}
				}
			}
			else if (seguro.Items.Count > 0)
			{
				seguro.SelectedIndex = 0;
			}
		}

		private void GuardarClick(object sender, EventArgs e)
		{
			GuardarEquipo();
		}

		private void DisponiblesClick(object sender, EventArgs e)
		{
			ConsultarDisponibles();
		}

		private void NuevoClick(object sender, EventArgs e)
		{
			Nuevo();
		}

		private void TodoClick(object sender, EventArgs e)
		{
			try
			{
				Cargar();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message);
			}
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
				if (mantenimiento.Visible)
				{
					cliente.DataSource = clientes.Listar();
				}

				Cargar();
				Nuevo();
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
			hasta.Value = DateTime.Today.AddDays(1);
			mantenimiento.Visible = seguridad.TienePermiso("Equipo.Guardar");
		}
	}
}
