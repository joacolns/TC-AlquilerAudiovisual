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
		private readonly Seguridad seguridad = new Seguridad();
		private readonly ReservaBLL reservas = new ReservaBLL();
		private readonly List<Reserva> importesPorEquipo = new List<Reserva>();
		private int equipoId;
		private Seguro seguroEquipo;
		private int diasEquipo;
		private bool preparandoUnidad;

		public EquiposForm()
		{
			InitializeComponent();
		}

		public void GuardarEquipo()
		{
			try
			{
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
						DiasReacondicionamiento = diasEquipo,
						Seguro = seguroEquipo
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
				List<Equipo> lista = bll.ListarDisponibles(desde.Value, hasta.Value);
				PrepararImportes(lista);
				grilla.DataSource = lista;
				grilla.ClearSelection();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "No se consultó disponibilidad");
			}
		}

		private void Cargar()
		{
			List<Equipo> lista = bll.Listar();
			PrepararImportes(lista);
			grilla.DataSource = lista;
		}

		private void PrepararImportes(List<Equipo> lista)
		{
			importesPorEquipo.Clear();
			bool puedeCotizar = seguridad.TienePermiso("Reserva.Cotizar");
			grillaSenaRequeridaColumna.Visible = puedeCotizar;
			grillaGarantiaRequeridaColumna.Visible = puedeCotizar;

			if (!puedeCotizar || hasta.Value <= desde.Value)
			{
				return;
			}

			foreach (Equipo equipo in lista)
			{
				Reserva consulta = new Reserva
				{
					Desde = desde.Value,
					Hasta = hasta.Value,
					Equipos = new List<Equipo>
					{
						equipo
					}
				};
				reservas.CalcularImportes(consulta);
				importesPorEquipo.Add(consulta);
			}
		}

		private void FormatearImportes(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex < 0
				|| (grilla.Columns[e.ColumnIndex] != grillaSenaRequeridaColumna
					&& grilla.Columns[e.ColumnIndex] != grillaGarantiaRequeridaColumna))
			{
				return;
			}

			Equipo equipo = grilla.Rows[e.RowIndex].DataBoundItem as Equipo;
			e.Value = "—";
			e.FormattingApplied = true;

			if (equipo == null)
			{
				return;
			}

			foreach (Reserva consulta in importesPorEquipo)
			{
				if (consulta.Equipos[0].Id == equipo.Id)
				{
					if (grilla.Columns[e.ColumnIndex] == grillaSenaRequeridaColumna)
					{
						e.Value = consulta.SenaRequerida.ToString("N2");
					}
					else
					{
						e.Value = consulta.GarantiaRequerida.ToString("N2");
					}

					break;
				}
			}
		}

		private void FechasCambio(object sender, EventArgs e)
		{
			if (DesignMode
				|| System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
			{
				return;
			}

			List<Equipo> lista = grilla.DataSource as List<Equipo>;

			if (lista == null)
			{
				return;
			}

			try
			{
				PrepararImportes(lista);
				grilla.Refresh();
			}
			catch (Exception ex)
			{
				importesPorEquipo.Clear();
				grilla.Refresh();
				MessageBox.Show(this, ex.Message, "Importes requeridos");
			}
		}

		private void Nuevo()
		{
			preparandoUnidad = true;

			try
			{
				grilla.ClearSelection();
				grilla.CurrentCell = null;
				equipoId = 0;
				seguroEquipo = null;
				diasEquipo = 0;
				codigo.Clear();
				serie.Clear();
				categoria.Clear();
				marca.Clear();
				modelo.Clear();
				descripcion.Clear();
				tarifa.Value = 0;
				reposicion.Value = 0;
				estado.SelectedIndex = 0;
				guardarBoton.Enabled = true;
				guardarBoton.Text = "Agregar unidad";
				unidadNota.Text = "Nueva unidad: completá los datos y pulsá Agregar unidad.";
				codigo.Focus();
			}
			finally
			{
				preparandoUnidad = false;
			}
		}

		private void EquipoCambio(object sender, EventArgs e)
		{
			if (preparandoUnidad || !mantenimiento.Visible)
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
			seguroEquipo = actual.Seguro;
			diasEquipo = actual.DiasReacondicionamiento;
			codigo.Text = actual.CodigoInventario;
			serie.Text = actual.Serie;
			categoria.Text = actual.Categoria;
			marca.Text = actual.Marca;
			modelo.Text = actual.Modelo;
			descripcion.Text = actual.Descripcion;
			tarifa.Value = actual.TarifaDiaria;
			reposicion.Value = actual.ValorReposicion;
			estado.SelectedItem = actual.Estado;
			guardarBoton.Text = "Guardar cambios";
			guardarBoton.Enabled = actual.Estado == "Disponible" || actual.Estado == "Baja";
			unidadNota.Text = "Editando unidad: " + actual.CodigoInventario + ". Para agregar otra, pulsá Nueva unidad.";

			if (!guardarBoton.Enabled)
			{
				unidadNota.Text = "La unidad está en un alquiler o incidencia. Pulsá Nueva unidad para agregar otro equipo.";
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

		private void ColumnasCatalogo(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			if (grilla.Columns.Contains("DiasReacondicionamiento"))
			{
				grilla.Columns["DiasReacondicionamiento"].Visible = false;
			}

			if (grilla.Columns.Contains("Seguro"))
			{
				grilla.Columns["Seguro"].Visible = false;
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
