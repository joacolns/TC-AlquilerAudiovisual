using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BE;
using BLL;
using SERVICE;

namespace GUI
{
    public class EquiposForm : Form
    {
        private readonly EquipoBLL bll = new EquipoBLL();
        private readonly ClienteBLL clientes = new ClienteBLL();
        private readonly Seguridad seguridad = new Seguridad();
        private readonly DataGridView grilla = new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, AutoGenerateColumns = false, AllowUserToAddRows = false, MultiSelect = false, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
        private readonly TextBox codigo = new TextBox { MaxLength = 30 }, serie = new TextBox { MaxLength = 80 }, categoria = new TextBox { MaxLength = 50 }, marca = new TextBox { MaxLength = 50 }, modelo = new TextBox { MaxLength = 80 }, descripcion = new TextBox { MaxLength = 300 };
        private readonly NumericUpDown tarifa = Dinero(), reposicion = Dinero(), dias = new NumericUpDown { Maximum = 365, Value = 1 };
        private readonly ComboBox estado = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList }, cliente = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, DisplayMember = "Nombre" }, seguro = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, DisplayMember = "Poliza" };
        private readonly DateTimePicker desde = Fecha(), hasta = Fecha();
        private readonly FlowLayoutPanel mantenimiento = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 260, Padding = new Padding(10) };
        private int equipoId;

        public EquiposForm()
        {
            Text = "Equipos · catálogo y disponibilidad"; ClientSize = new Size(1180, 650); StartPosition = FormStartPosition.CenterParent; Font = new Font("Segoe UI", 10);
            hasta.Value = DateTime.Today.AddDays(1);
            FlowLayoutPanel filtro = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 90, Padding = new Padding(10) };
            Campo(filtro, "Desde", desde); Campo(filtro, "Hasta", hasta); filtro.Controls.Add(Boton("Consultar disponibles", DisponiblesClick)); filtro.Controls.Add(Boton("Ver todo el catálogo", TodoClick));
            foreach (string campo in new[] { "Id", "CodigoInventario", "Categoria", "Marca", "Modelo", "Serie", "Estado", "TarifaDiaria", "ValorReposicion", "DiasReacondicionamiento" })
                grilla.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = campo, HeaderText = Etiqueta(campo) });
            grilla.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Campo(mantenimiento, "Código inventario", codigo); Campo(mantenimiento, "Serie", serie); Campo(mantenimiento, "Categoría", categoria); Campo(mantenimiento, "Marca", marca); Campo(mantenimiento, "Modelo", modelo); Campo(mantenimiento, "Descripción", descripcion);
            Campo(mantenimiento, "Tarifa diaria ARS", tarifa); Campo(mantenimiento, "Reposición ARS", reposicion); Campo(mantenimiento, "Días reacondicionamiento", dias);
            estado.Items.AddRange(new object[] { "Disponible", "Baja" }); estado.SelectedIndex = 0;
            Campo(mantenimiento, "Estado", estado); Campo(mantenimiento, "Cliente de la póliza", cliente); Campo(mantenimiento, "Seguro (opcional)", seguro);
            mantenimiento.Controls.Add(Boton("Guardar unidad", GuardarClick)); mantenimiento.Controls.Add(Boton("Nueva unidad", NuevoClick));
            mantenimiento.Controls.Add(new Label { Text = "Una póliza puede asignarse a varias unidades. Su cobertura es por unidad.", AutoSize = true });
            Controls.Add(grilla); Controls.Add(mantenimiento); Controls.Add(filtro);
            mantenimiento.Visible = seguridad.TienePermiso("Equipo.Guardar");
            cliente.SelectedIndexChanged += ClienteCambio; grilla.SelectionChanged += EquipoCambio; Shown += CargarClick;
        }

        public void GuardarEquipo()
        {
            try
            {
                Seguro seleccion = seguro.SelectedItem as Seguro;
                int id = bll.Guardar(new Equipo { Id = equipoId, CodigoInventario = codigo.Text, Serie = serie.Text, Categoria = categoria.Text, Marca = marca.Text, Modelo = modelo.Text, Descripcion = descripcion.Text, Estado = Convert.ToString(estado.SelectedItem), TarifaDiaria = tarifa.Value, ValorReposicion = reposicion.Value, DiasReacondicionamiento = (int)dias.Value, Seguro = seleccion == null || seleccion.Id == 0 ? null : seleccion });
                Cargar(); Nuevo(); MessageBox.Show(this, "Unidad guardada: " + id);
            }
            catch (Exception ex) { MessageBox.Show(this, ex.Message, "No se guardó el equipo"); }
        }

        public void ConsultarDisponibles()
        {
            try { grilla.DataSource = bll.ListarDisponibles(desde.Value, hasta.Value); grilla.ClearSelection(); }
            catch (Exception ex) { MessageBox.Show(this, ex.Message, "No se consultó disponibilidad"); }
        }

        private void Cargar() { grilla.DataSource = bll.Listar(); }
        private void CargarSeguros()
        {
            List<Seguro> opciones = new List<Seguro> { new Seguro { Poliza = "Sin seguro" } };
            Cliente actual = cliente.SelectedItem as Cliente;
            if (actual != null) opciones.AddRange(clientes.ListarSeguros(actual.Id));
            seguro.DataSource = opciones;
        }
        private void Nuevo()
        {
            grilla.ClearSelection(); equipoId = 0; codigo.Clear(); serie.Clear(); categoria.Clear(); marca.Clear(); modelo.Clear(); descripcion.Clear(); tarifa.Value = 0; reposicion.Value = 0; dias.Value = 1; estado.SelectedIndex = 0;
            if (seguro.Items.Count > 0) seguro.SelectedIndex = 0;
        }
        private void EquipoCambio(object sender, EventArgs e)
        {
            if (!mantenimiento.Visible) return;
            Equipo actual = grilla.CurrentRow == null || !grilla.CurrentRow.Selected ? null : grilla.CurrentRow.DataBoundItem as Equipo;
            if (actual == null) return;
            equipoId = actual.Id; codigo.Text = actual.CodigoInventario; serie.Text = actual.Serie; categoria.Text = actual.Categoria; marca.Text = actual.Marca; modelo.Text = actual.Modelo; descripcion.Text = actual.Descripcion;
            tarifa.Value = actual.TarifaDiaria; reposicion.Value = actual.ValorReposicion; dias.Value = actual.DiasReacondicionamiento; estado.SelectedItem = actual.Estado;
            if (actual.Seguro != null)
            {
                for (int i = 0; i < cliente.Items.Count; i++) if (((Cliente)cliente.Items[i]).Id == actual.Seguro.ClienteId) { cliente.SelectedIndex = i; break; }
                for (int i = 0; i < seguro.Items.Count; i++) if (((Seguro)seguro.Items[i]).Id == actual.Seguro.Id) { seguro.SelectedIndex = i; break; }
            }
            else if (seguro.Items.Count > 0) seguro.SelectedIndex = 0;
        }
        private static NumericUpDown Dinero() { return new NumericUpDown { DecimalPlaces = 2, Maximum = 1000000000000, ThousandsSeparator = true }; }
        private string Etiqueta(string campo)
        {
            switch (campo)
            {
                case "CodigoInventario": return "Inventario";
                case "Categoria": return "Categoría";
                case "TarifaDiaria": return "Tarifa diaria ARS";
                case "ValorReposicion": return "Reposición ARS";
                case "DiasReacondicionamiento": return "Días preparación";
                default: return campo;
            }
        }
        private static DateTimePicker Fecha() { return new DateTimePicker { Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy HH:mm", Value = DateTime.Today }; }
        private void Campo(FlowLayoutPanel panel, string etiqueta, Control control) { FlowLayoutPanel grupo = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, Width = 185, Height = 68 }; grupo.Controls.Add(new Label { Text = etiqueta, AutoSize = true }); control.Width = 175; grupo.Controls.Add(control); panel.Controls.Add(grupo); }
        private Button Boton(string texto, EventHandler evento) { Button b = new Button { Text = texto, AutoSize = true, Height = 36 }; b.Click += evento; return b; }
        private void GuardarClick(object sender, EventArgs e) { GuardarEquipo(); }
        private void DisponiblesClick(object sender, EventArgs e) { ConsultarDisponibles(); }
        private void NuevoClick(object sender, EventArgs e) { Nuevo(); }
        private void TodoClick(object sender, EventArgs e) { try { Cargar(); } catch (Exception ex) { MessageBox.Show(this, ex.Message); } }
        private void ClienteCambio(object sender, EventArgs e) { try { CargarSeguros(); } catch (Exception ex) { MessageBox.Show(this, ex.Message); } }
        private void CargarClick(object sender, EventArgs e)
        {
            try { if (mantenimiento.Visible) cliente.DataSource = clientes.Listar(); Cargar(); Nuevo(); }
            catch (Exception ex) { MessageBox.Show(this, ex.Message); Close(); }
        }
    }
}
