using System;
using System.Drawing;
using System.Windows.Forms;
using BE;
using BLL;
using SERVICE;

namespace GUI
{
    public class UsuariosForm : Form
    {
        private readonly UsuarioBLL bll = new UsuarioBLL();
        private readonly DataGridView grilla = new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, AutoGenerateColumns = false, AllowUserToAddRows = false, MultiSelect = false, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
        private readonly TextBox nombre = new TextBox { Width = 160, MaxLength = 50 };
        private readonly TextBox clave = new TextBox { Width = 160, MaxLength = 128, UseSystemPasswordChar = true };
        private readonly ComboBox rol = new ComboBox { Width = 160, DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly CheckBox activo = new CheckBox { Text = "Activo", Checked = true, AutoSize = true };

        public UsuariosForm()
        {
            Text = "Usuarios y roles"; ClientSize = new Size(900, 470); StartPosition = FormStartPosition.CenterParent; Font = new Font("Segoe UI", 10);
            FlowLayoutPanel alta = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 120, Padding = new Padding(12) };
            alta.Controls.Add(new Label { Text = "Alta: usuario / contraseña / rol", AutoSize = true, Width = 280 });
            alta.Controls.Add(nombre); alta.Controls.Add(clave);
            rol.Items.AddRange(new object[] { "Cliente", "EncargadoStock", "Administrador", "Tecnico" }); rol.SelectedIndex = 0;
            alta.Controls.Add(rol); alta.Controls.Add(activo); alta.Controls.Add(Boton("Crear usuario", GuardarClick));
            alta.Controls.Add(Boton("Asignar rol a seleccionado", AsignarClick));
            foreach (string campo in new[] { "Id", "NombreUsuario", "Rol", "Activo" }) grilla.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = campo, HeaderText = campo });
            Controls.Add(grilla); Controls.Add(alta); Shown += CargarClick;
        }

        public void GuardarUsuario()
        {
            try
            {
                int id = bll.Guardar(new Usuario { NombreUsuario = nombre.Text, Rol = Convert.ToString(rol.SelectedItem), Activo = activo.Checked }, clave.Text);
                clave.Clear(); nombre.Clear(); Cargar(); MessageBox.Show(this, "Usuario creado: " + id);
            }
            catch (Exception ex) { MessageBox.Show(this, ex.Message, "No se guardó el usuario"); }
        }

        public void AsignarRol()
        {
            try
            {
                Usuario seleccionado = grilla.CurrentRow == null ? null : grilla.CurrentRow.DataBoundItem as Usuario;
                if (seleccionado == null) throw new ArgumentException("Seleccioná un usuario.");
                if (!bll.AsignarRol(seleccionado.Id, Convert.ToString(rol.SelectedItem))) throw new InvalidOperationException("El usuario no existe.");
                if (SesionSingleton.Instancia.UsuarioActual == null) { MessageBox.Show(this, "Tu rol cambió. Volvé a ingresar."); Close(); return; }
                Cargar(); MessageBox.Show(this, "Rol asignado. Se aplica al próximo ingreso del usuario.");
            }
            catch (Exception ex) { MessageBox.Show(this, ex.Message, "No se asignó el rol"); }
        }
        private void Cargar() { grilla.DataSource = bll.Listar(); }
        private Button Boton(string texto, EventHandler evento) { Button b = new Button { Text = texto, AutoSize = true, Height = 36 }; b.Click += evento; return b; }
        private void GuardarClick(object sender, EventArgs e) { GuardarUsuario(); }
        private void AsignarClick(object sender, EventArgs e) { AsignarRol(); }
        private void CargarClick(object sender, EventArgs e) { try { Cargar(); } catch (Exception ex) { MessageBox.Show(this, ex.Message); Close(); } }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // UsuariosForm
            // 
            this.ClientSize = new System.Drawing.Size(760, 473);
            this.Name = "UsuariosForm";
            this.ResumeLayout(false);

        }
    }
}
