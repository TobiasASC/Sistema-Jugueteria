using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SistemaJugueteria.Presentacion.Utilidades;

namespace SistemaJugueteria
{
    public partial class FormClientes : Form
    {
        // Variable para guardar el índice de la fila que se está modificando (-1 = ninguna)
        private int indiceFilaEditada = -1;

        public FormClientes()
        {
            InitializeComponent();

            Validaciones.ConfigurarNumerosLongitud(txtDniCliente, 8);
            Validaciones.ConfigurarSoloLetras(txtNombreCliente);
            Validaciones.ConfigurarSoloLetras(txtApellidoCliente);
            Validaciones.ConfigurarEmail(txtEmailCliente);

            Validaciones.ConfigurarNumerosLongitud(txtDniClienteBuscar, 8);
            Validaciones.ConfigurarSoloLetras(txtNombreClienteBuscar);
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            ActualizarContador();
        }

        private void ConfigurarDataGridView()
        {
            dgvClientes.Columns.Clear();
            dgvClientes.AutoGenerateColumns = false;

            // Columnas de datos
            dgvClientes.Columns.Add("colDni", "DNI");
            dgvClientes.Columns.Add("colNomApe", "Nom y Ape");
            dgvClientes.Columns.Add("colDireccion", "Dirección");
            dgvClientes.Columns.Add("colEmail", "Email");
            dgvClientes.Columns.Add("colPuntos", "Puntos");

            // Botón Modificar dentro de la grilla
            DataGridViewButtonColumn btnModificarCol = new DataGridViewButtonColumn();
            btnModificarCol.Name = "colModificar";
            btnModificarCol.HeaderText = "Modificar";
            btnModificarCol.Text = "Modificar";
            btnModificarCol.UseColumnTextForButtonValue = true;
            dgvClientes.Columns.Add(btnModificarCol);

            // Botón Eliminar dentro de la grilla
            DataGridViewButtonColumn btnEliminarCol = new DataGridViewButtonColumn();
            btnEliminarCol.Name = "colEliminar";
            btnEliminarCol.HeaderText = "Eliminar";
            btnEliminarCol.Text = "Eliminar";
            btnEliminarCol.UseColumnTextForButtonValue = true;
            dgvClientes.Columns.Add(btnEliminarCol);

            dgvClientes.CellClick -= dgvClientes_CellClick;
            dgvClientes.CellClick += dgvClientes_CellClick;
        }

        // --- BOTÓN NUEVO: Crea y agrega el cliente al DataGrid ---
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (ValidarCamposVacios()) return;

            string dni = txtDniCliente.TextButton;
            string nombreCompleto = $"{txtNombreCliente.TextButton.Trim()} {txtApellidoCliente.TextButton.Trim()}";
            string direccion = txtDireccionCliente.TextButton;
            string email = txtEmailCliente.TextButton;
            string puntos = "0";

            // Se agrega una nueva fila directamente
            int nuevaFilaIndice = dgvClientes.Rows.Add(dni, nombreCompleto, direccion, email, puntos);

            // Guardamos el nombre y apellido por separado en el Tag
            dgvClientes.Rows[nuevaFilaIndice].Tag = new string[] { txtNombreCliente.TextButton.Trim(), txtApellidoCliente.TextButton.Trim() };

            MessageBox.Show("¡Cliente agregado con éxito!", "Nuevo Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ActualizarContador();
            LimpiarCampos();
        }

        // --- BOTÓN GUARDAR / MODIFICAR: Actualiza la fila en edición ---
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (indiceFilaEditada < 0)
            {
                MessageBox.Show("Por favor, seleccione un cliente en la tabla usando el botón 'Modificar' antes de guardar cambios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidarCamposVacios()) return;

            // Actualizamos la fila seleccionada
            dgvClientes.Rows[indiceFilaEditada].Cells[0].Value = txtDniCliente.TextButton;
            dgvClientes.Rows[indiceFilaEditada].Cells[1].Value = $"{txtNombreCliente.TextButton.Trim()} {txtApellidoCliente.TextButton.Trim()}";
            dgvClientes.Rows[indiceFilaEditada].Cells[2].Value = txtDireccionCliente.TextButton;
            dgvClientes.Rows[indiceFilaEditada].Cells[3].Value = txtEmailCliente.TextButton;

            dgvClientes.Rows[indiceFilaEditada].Tag = new string[] { txtNombreCliente.TextButton.Trim(), txtApellidoCliente.TextButton.Trim() };

            MessageBox.Show("Cliente modificado correctamente.", "Guardar Cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarCampos();
        }

        // --- BOTÓN ELIMINAR / CANCELAR: Limpia el formulario y resetea la edición ---
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // --- INTERACCIÓN CON LA GRILLA ---
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == dgvClientes.NewRowIndex) return;

            DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];

            // Clic en 'Modificar' de la grilla -> Carga datos arriba para editar
            if (e.ColumnIndex == 5)
            {
                txtDniCliente.TextButton = fila.Cells[0].Value?.ToString();

                if (fila.Tag is string[] nombres)
                {
                    txtNombreCliente.TextButton = nombres[0];
                    txtApellidoCliente.TextButton = nombres[1];
                }

                txtDireccionCliente.TextButton = fila.Cells[2].Value?.ToString();
                txtEmailCliente.TextButton = fila.Cells[3].Value?.ToString();

                indiceFilaEditada = e.RowIndex;
            }
            // Clic en 'Eliminar' de la grilla -> Elimina directamente esa fila
            else if (e.ColumnIndex == 6)
            {
                DialogResult respuesta = MessageBox.Show("¿Desea borrar este cliente de la lista?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    dgvClientes.Rows.RemoveAt(e.RowIndex);
                    ActualizarContador();
                    LimpiarCampos();
                }
            }
        }

        private void LimpiarCampos()
        {
            indiceFilaEditada = -1;
            txtDniCliente.TextButton = "";
            txtNombreCliente.TextButton = "";
            txtApellidoCliente.TextButton = "";
            txtEmailCliente.TextButton = "";
            txtDireccionCliente.TextButton = "";
            txtDniCliente.Focus();
        }

        private bool ValidarCamposVacios()
        {
            if (string.IsNullOrWhiteSpace(txtDniCliente.TextButton) ||
                string.IsNullOrWhiteSpace(txtNombreCliente.TextButton) ||
                string.IsNullOrWhiteSpace(txtApellidoCliente.TextButton) ||
                string.IsNullOrWhiteSpace(txtEmailCliente.TextButton) ||
                string.IsNullOrWhiteSpace(txtDireccionCliente.TextButton))
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }

        private void ActualizarContador()
        {
            int cantidad = dgvClientes.AllowUserToAddRows ? dgvClientes.Rows.Count - 1 : dgvClientes.Rows.Count;
            contadorClientes.TextButton = cantidad < 0 ? "0" : cantidad.ToString();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void hopeTextBox1_Click(object sender, EventArgs e) { }
        private void button5_Click(object sender, EventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }
        private void cyberTextBox10_Load(object sender, EventArgs e) { }
        private void txtApellidoCliente_Load(object sender, EventArgs e) { }
    }
}