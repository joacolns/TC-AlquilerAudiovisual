using System;
using System.Windows.Forms;
using BE;

namespace GUI
{
	public partial class ReservasForm
	{
		private int equipoId;
		private Seguro seguroEquipo;
		private int diasEquipo;
		private bool preparandoUnidad;
		private Equipo equipoOriginal;

		private void CargarInventario()
		{
			preparandoUnidad = true;

			try
			{
				inventario.DataSource = equipos.Listar();
			}
			finally
			{
				preparandoUnidad = false;
			}

			NuevoEquipo();
		}

		private void NuevoEquipo()
		{
			preparandoUnidad = true;

			try
			{
				inventario.ClearSelection();
				inventario.CurrentCell = null;
				equipoId = 0;
				equipoOriginal = null;
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
				guardarEquipoBoton.Enabled = true;
				guardarEquipoBoton.Text = "Agregar unidad";
				unidadNota.Text = "Nueva unidad: completá los datos y pulsá Agregar unidad.";
			}
			finally
			{
				preparandoUnidad = false;
			}
		}

		private void GuardarEquipo()
		{
			try
			{
				int id = equipos.Guardar(
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
					},
					equipoOriginal
				);
				CargarInventario();
				MessageBox.Show(this, "Unidad guardada: " + id, "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "No se guardó el equipo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void EquipoInventarioCambio(object sender, EventArgs e)
		{
			if (preparandoUnidad)
			{
				return;
			}

			Equipo actual = null;

			if (inventario.CurrentRow != null && inventario.CurrentRow.Selected)
			{
				actual = inventario.CurrentRow.DataBoundItem as Equipo;
			}

			if (actual == null)
			{
				return;
			}

			equipoId = actual.Id;
			equipoOriginal = actual;
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
			guardarEquipoBoton.Text = "Guardar cambios";
			guardarEquipoBoton.Enabled = actual.Estado == "Disponible" || actual.Estado == "Baja";
			unidadNota.Text = "Editando " + actual.CodigoInventario + ". Para agregar otra, pulsá Nueva unidad.";

			if (!guardarEquipoBoton.Enabled)
			{
				unidadNota.Text = "La unidad está en un alquiler o incidencia y no se puede editar.";
			}
		}

		private void GuardarEquipoClick(object sender, EventArgs e)
		{
			GuardarEquipo();
		}

		private void NuevoEquipoClick(object sender, EventArgs e)
		{
			NuevoEquipo();
			codigo.Focus();
		}

		private void ActualizarInventarioClick(object sender, EventArgs e)
		{
			try
			{
				CargarInventario();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
	}
}
