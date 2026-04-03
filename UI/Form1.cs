using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD_Usuarios.Datos;
using CRUD_Usuarios.Modelo;

namespace CRUD_Usuarios2
{
    public partial class Form1 : Form
    {
        UsuarioDAL dal = new UsuarioDAL();

        public Form1()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CargarDatos()
        {
            dgvUsuarios.DataSource = dal.Listar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario
            {
                Nombre = txtNombre.Text,
                Email = txtEmail.Text
            };

            dal.Crear(u);
            CargarDatos();
            Limpiar();
            MessageBox.Show($"Nombre: {txtNombre.Text} | Email: {txtEmail.Text}");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Seguro que deseas eliminar?", "Confirmar", MessageBoxButtons.YesNo);

            if (r == DialogResult.No) return;

            dal.Eliminar(int.Parse(txtId.Text));
            CargarDatos();
            Limpiar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Selecciona un usuario para actualizar");
                return;

            }

            Usuario u = new Usuario
            {
                Id = id,
                Nombre = txtNombre.Text,
                Email = txtEmail.Text
            };

            dal.Actualizar(u);
            CargarDatos();
            Limpiar();
        }

    
        private void Limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtEmail.Clear();
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                var fila = dgvUsuarios.Rows[e.RowIndex];

                txtId.Text = fila.Cells["Id"].Value.ToString();
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtEmail.Text = fila.Cells["Email"].Value.ToString();
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
