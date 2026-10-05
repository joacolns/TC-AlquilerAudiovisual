using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BE;
using BLL;

namespace GUI
{
    public class ClientesForm : Form
    {
        private readonly ClienteBLL bll = new ClienteBLL();
        private readonly UsuarioBLL usuarios = new UsuarioBLL();
        private readonly ComboBox cuenta = new ComboBox { Width = 190, DropDownStyle = ComboBoxStyle.DropDownList, DisplayMember = "NombreUsuario" };
        private readonly ComboBox clienteSeguro = new ComboBox { Width = 190, DropDownStyle = ComboBoxStyle.DropDownList, DisplayMember = "Nombre" };
        private readonly TextBox dni = new TextBox { MaxLength = 13 }, nombre = new TextBox { MaxLength = 100 }, telefono = new TextBox { MaxLength = 30 }, email = new TextBox { MaxLength = 150 };
        private readonly CheckBox antecedente = new CheckBox { Text = "Antecedente negativo", AutoSize = true };
        private readonly TextBox poliza = new TextBox { MaxLength = 50 }, aseguradora = new TextBox { MaxLength = 100 };
        private readonly DateTimePicker desde = new DateTimePicker { Format = DateTimePickerFormat.Short }, hasta = new DateTimePicker { Format = DateTimePickerFormat.Short, Value = DateTime.Today.AddYears(1) };
        private readonly NumericUpDown cobertura = new NumericUpDown { DecimalPlaces = 2, Maximum = 1000000000000, ThousandsSeparator = true, Width = 190 };
        private readonly DataGridView clientes = Grilla(), seguros = Grilla();
        private int seguroId;

        public ClientesForm()
        {
            Text = "Clientes y seguros"; ClientSize = new Size(1030, 600); StartPosition = FormStartPosition.CenterParent; Font = new Font("Segoe UI", 10);
            TabControl tabs = new TabControl { Dock = DockStyle.Fill };
            TabPage ficha = new TabPage("Clientes"), coberturaTab = new TabPage("Seguros");
            FlowLayoutPanel alta = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 160, Padding = new Padding(10) };
            Campo(alta, "Cuenta con rol Cliente", cuenta); Campo(alta, "DNI/CUIT", dni); Campo(alta, "Nombre", nombre); Campo(alta, "Teléfono", telefono); Campo(alta, "Correo", email);
            alta.Controls.Add(antecedente); alta.Controls.Add(Boton("Crear cliente", GuardarClienteClick));
            foreach (string campo in new[] { "Id", "UsuarioId", "DniCuit", "Nombre", "Telefono", "Email", "AntecedenteNegativo" }) Columna(clientes, campo);
            ficha.Controls.Add(clientes); ficha.Controls.Add(alta);
            FlowLayoutPanel formulario = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 200, Padding = new Padding(10) };
            Campo(formulario, "Cliente", clienteSeguro); Campo(formulario, "Póliza", poliza); Campo(formulario, "Aseguradora", aseguradora); Campo(formulario, "Vigente desde", desde); Campo(formulario, "Vigente hasta", hasta); Campo(formulario, "Cobertura ARS por unidad", cobertura);
            formulario.Controls.Add(Boton("Guardar seguro", GuardarSeguroClick)); formulario.Controls.Add(Boton("Nueva póliza", NuevoSeguroClick));
            formulario.Controls.Add(new Label { Text = "La póliza se asigna a las unidades desde Equipos.", AutoSize = true });
            foreach (string campo in new[] { "Id", "Poliza", "Aseguradora", "Desde", "Hasta", "Cobertura" }) Columna(seguros, campo);
            coberturaTab.Controls.Add(seguros); coberturaTab.Controls.Add(formulario);
            tabs.TabPages.Add(ficha); tabs.TabPages.Add(coberturaTab); Controls.Add(tabs);
            clienteSeguro.SelectedIndexChanged += ClienteCambio; seguros.SelectionChanged += SeguroCambio; Shown += CargarClick;
        }

        public void GuardarCliente()
        {
            try
            {
                Usuario usuario = cuenta.SelectedItem as Usuario;
                int id = bll.Guardar(new Cliente { Usuario = usuario, DniCuit = dni.Text, Nombre = nombre.Text, Telefono = telefono.Text, Email = email.Text, AntecedenteNegativo = antecedente.Checked });
                Cargar(); MessageBox.Show(this, "Cliente creado: " + id);
            }
            catch (Exception ex) { MessageBox.Show(this, ex.Message, "No se guardó el cliente"); }
        }

        public void GuardarSeguro()
        {
            try
            {
                int id = bll.GuardarSeguro(new Seguro { Id = seguroId, Cliente = clienteSeguro.SelectedItem as Cliente, Poliza = poliza.Text, Aseguradora = aseguradora.Text, Desde = desde.Value.Date, Hasta = hasta.Value.Date, Cobertura = cobertura.Value });
                CargarSeguros(); MessageBox.Show(this, "Seguro guardado: " + id);
            }
            catch (Exception ex) { MessageBox.Show(this, ex.Message, "No se guardó el seguro"); }
        }
        private void Cargar()
        {
            List<Usuario> disponibles = new List<Usuario>();
            foreach (Usuario usuario in usuarios.Listar()) if (usuario.Rol == "Cliente" && usuario.Activo) disponibles.Add(usuario);
            cuenta.DataSource = disponibles; clientes.DataSource = bll.Listar(); clienteSeguro.DataSource = bll.Listar();
        }
        private void CargarSeguros()
        {
            Cliente cliente = clienteSeguro.SelectedItem as Cliente;
            seguros.DataSource = cliente == null ? new List<Seguro>() : bll.ListarSeguros(cliente.Id);
            NuevoSeguro();
        }
        private void NuevoSeguro() { seguros.ClearSelection(); seguroId = 0; poliza.Clear(); aseguradora.Clear(); cobertura.Value = 0; }
        private void SeguroCambio(object sender, EventArgs e)
        {
            Seguro seguro = seguros.CurrentRow == null || !seguros.CurrentRow.Selected ? null : seguros.CurrentRow.DataBoundItem as Seguro;
            if (seguro == null) return;
            seguroId = seguro.Id; poliza.Text = seguro.Poliza; aseguradora.Text = seguro.Aseguradora; desde.Value = seguro.Desde; hasta.Value = seguro.Hasta; cobertura.Value = seguro.Cobertura;
        }
        private static DataGridView Grilla() { return new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, AutoGenerateColumns = false, AllowUserToAddRows = false, MultiSelect = false, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill }; }
        private void Columna(DataGridView grid, string campo)
        {
            string etiqueta = campo;
            if (campo == "AntecedenteNegativo") etiqueta = "Antecedente negativo";
            if (campo == "UsuarioId") etiqueta = "Cuenta";
            if (campo == "DniCuit") etiqueta = "DNI/CUIT";
            if (campo == "Telefono") etiqueta = "Teléfono";
            if (campo == "Poliza") etiqueta = "Póliza";
            if (campo == "Cobertura") etiqueta = "Cobertura ARS";
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = campo, HeaderText = etiqueta });
            grid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }
        private void Campo(FlowLayoutPanel panel, string etiqueta, Control control) { FlowLayoutPanel grupo = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, Width = 195, Height = 66 }; grupo.Controls.Add(new Label { Text = etiqueta, AutoSize = true }); control.Width = 185; grupo.Controls.Add(control); panel.Controls.Add(grupo); }
        private Button Boton(string texto, EventHandler evento) { Button b = new Button { Text = texto, AutoSize = true, Height = 36 }; b.Click += evento; return b; }
        private void GuardarClienteClick(object sender, EventArgs e) { GuardarCliente(); }
        private void GuardarSeguroClick(object sender, EventArgs e) { GuardarSeguro(); }
        private void NuevoSeguroClick(object sender, EventArgs e) { NuevoSeguro(); }
        private void ClienteCambio(object sender, EventArgs e) { try { CargarSeguros(); } catch (Exception ex) { MessageBox.Show(this, ex.Message); } }
        private void CargarClick(object sender, EventArgs e) { try { Cargar(); } catch (Exception ex) { MessageBox.Show(this, ex.Message); Close(); } }
    }
}
