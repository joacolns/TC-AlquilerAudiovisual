using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BE;

namespace GUI
{
	public partial class ReservasForm
	{
		private TabPage inventarioTab;
		private DataGridView inventario;
		private TableLayoutPanel editorInventario;
		private FlowLayoutPanel accionesInventario;
		private TextBox codigo;
		private TextBox serie;
		private TextBox categoria;
		private TextBox marca;
		private TextBox modelo;
		private TextBox descripcion;
		private NumericUpDown tarifa;
		private NumericUpDown reposicion;
		private ComboBox estado;
		private Button guardarEquipoBoton;
		private Button nuevoEquipoBoton;
		private Button actualizarInventarioBoton;
		private Label unidadNota;
		private int equipoId;
		private Seguro seguroEquipo;
		private int diasEquipo;
		private bool preparandoUnidad;

		private void InicializarInventario()
		{
			inventarioTab = new TabPage("Inventario");
			inventarioTab.BackColor = Color.FromArgb(244, 247, 251);
			inventarioTab.Padding = new Padding(12);

			inventario = new DataGridView();
			inventario.Dock = DockStyle.Fill;
			inventario.ReadOnly = true;
			inventario.MultiSelect = false;
			inventario.AllowUserToAddRows = false;
			inventario.AllowUserToDeleteRows = false;
			inventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			inventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			inventario.SelectionChanged += EquipoInventarioCambio;
			inventario.DataBindingComplete += ColumnasInventario;

			editorInventario = new TableLayoutPanel();
			editorInventario.Dock = DockStyle.Top;
			editorInventario.Height = 226;
			editorInventario.BackColor = Color.White;
			editorInventario.Padding = new Padding(8);
			editorInventario.ColumnCount = 4;
			editorInventario.RowCount = 3;

			for (int i = 0; i < 4; i++)
			{
				editorInventario.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
			}

			for (int i = 0; i < 3; i++)
			{
				editorInventario.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
			}

			codigo = CrearTexto(30);
			serie = CrearTexto(80);
			categoria = CrearTexto(50);
			marca = CrearTexto(50);
			modelo = CrearTexto(80);
			descripcion = CrearTexto(300);
			tarifa = CrearImporte();
			reposicion = CrearImporte();
			estado = new ComboBox();
			estado.Dock = DockStyle.Bottom;
			estado.DropDownStyle = ComboBoxStyle.DropDownList;
			estado.Items.AddRange(new object[] { "Disponible", "Baja" });

			editorInventario.Controls.Add(CrearCampo("Código de inventario", codigo), 0, 0);
			editorInventario.Controls.Add(CrearCampo("Serie", serie), 1, 0);
			editorInventario.Controls.Add(CrearCampo("Categoría", categoria), 2, 0);
			editorInventario.Controls.Add(CrearCampo("Marca", marca), 3, 0);
			editorInventario.Controls.Add(CrearCampo("Modelo", modelo), 0, 1);
			editorInventario.Controls.Add(CrearCampo("Tarifa diaria ARS", tarifa), 1, 1);
			editorInventario.Controls.Add(CrearCampo("Reposición ARS", reposicion), 2, 1);
			editorInventario.Controls.Add(CrearCampo("Estado", estado), 3, 1);
			editorInventario.Controls.Add(CrearCampo("Descripción", descripcion), 0, 2);
			editorInventario.SetColumnSpan(editorInventario.Controls[editorInventario.Controls.Count - 1], 2);

			unidadNota = new Label();
			unidadNota.Dock = DockStyle.Fill;
			unidadNota.TextAlign = ContentAlignment.MiddleLeft;
			unidadNota.ForeColor = Color.FromArgb(100, 116, 139);
			unidadNota.Text = "Completá los datos para agregar una unidad.";
			editorInventario.Controls.Add(unidadNota, 2, 2);
			editorInventario.SetColumnSpan(unidadNota, 2);

			accionesInventario = new FlowLayoutPanel();
			accionesInventario.Dock = DockStyle.Bottom;
			accionesInventario.Height = 58;
			accionesInventario.Padding = new Padding(4, 8, 4, 4);
			accionesInventario.BackColor = Color.FromArgb(244, 247, 251);

			guardarEquipoBoton = CrearBotonInventario("Agregar unidad", true);
			guardarEquipoBoton.Click += GuardarEquipoClick;
			nuevoEquipoBoton = CrearBotonInventario("Nueva unidad", false);
			nuevoEquipoBoton.Click += NuevoEquipoClick;
			actualizarInventarioBoton = CrearBotonInventario("Actualizar", false);
			actualizarInventarioBoton.Click += ActualizarInventarioClick;
			accionesInventario.Controls.Add(guardarEquipoBoton);
			accionesInventario.Controls.Add(nuevoEquipoBoton);
			accionesInventario.Controls.Add(actualizarInventarioBoton);

			inventarioTab.Controls.Add(inventario);
			inventarioTab.Controls.Add(accionesInventario);
			inventarioTab.Controls.Add(editorInventario);
			tabs.Controls.Add(inventarioTab);
		}

		private TextBox CrearTexto(int longitud)
		{
			TextBox texto = new TextBox();
			texto.Dock = DockStyle.Bottom;
			texto.MaxLength = longitud;
			return texto;
		}

		private NumericUpDown CrearImporte()
		{
			NumericUpDown importe = new NumericUpDown();
			importe.Dock = DockStyle.Bottom;
			importe.DecimalPlaces = 2;
			importe.Maximum = 999999999;
			importe.ThousandsSeparator = true;
			return importe;
		}

		private Panel CrearCampo(string titulo, Control control)
		{
			Panel campo = new Panel();
			campo.Dock = DockStyle.Fill;
			campo.Margin = new Padding(6);
			Label etiqueta = new Label();
			etiqueta.Dock = DockStyle.Top;
			etiqueta.Height = 24;
			etiqueta.Text = titulo;
			etiqueta.ForeColor = Color.FromArgb(71, 85, 105);
			campo.Controls.Add(control);
			campo.Controls.Add(etiqueta);
			return campo;
		}

		private Button CrearBotonInventario(string texto, bool principal)
		{
			Button boton = new Button();
			boton.Size = new Size(140, 36);
			boton.Margin = new Padding(4);
			boton.Text = texto;
			boton.FlatStyle = FlatStyle.Flat;
			boton.FlatAppearance.BorderSize = 0;
			boton.Cursor = Cursors.Hand;

			if (principal)
			{
				boton.BackColor = Color.FromArgb(37, 99, 235);
				boton.ForeColor = Color.White;
			}
			else
			{
				boton.BackColor = Color.White;
				boton.ForeColor = Color.FromArgb(51, 65, 85);
				boton.FlatAppearance.BorderSize = 1;
				boton.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
			}

			return boton;
		}

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
					}
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

		private void ColumnasInventario(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			if (inventario.Columns.Contains("Seguro"))
			{
				inventario.Columns["Seguro"].Visible = false;
			}

			if (inventario.Columns.Contains("Descripcion"))
			{
				inventario.Columns["Descripcion"].Visible = false;
			}

			if (inventario.Columns.Contains("DiasReacondicionamiento"))
			{
				inventario.Columns["DiasReacondicionamiento"].HeaderText = "Reacond. (días)";
			}

			if (inventario.Columns.Contains("TarifaDiaria"))
			{
				inventario.Columns["TarifaDiaria"].DefaultCellStyle.Format = "N2";
			}

			if (inventario.Columns.Contains("ValorReposicion"))
			{
				inventario.Columns["ValorReposicion"].DefaultCellStyle.Format = "N2";
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
