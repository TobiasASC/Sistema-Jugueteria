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

        // Variable para rastrear si estamos creando (-1) o editando una fila existente
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void hopeTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void cyberTextBox10_Load(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Cancelar cualquier edición en curso
            indiceFilaEditada = -1;

            // Limpiamos los controles
            txtDniCliente.TextButton = "";
            txtNombreCliente.TextButton = "";
            txtApellidoCliente.TextButton = "";
            txtEmailCliente.TextButton = "";
            txtDireccionCliente.TextButton = "";

            // Si tienes el campo de puntos (Puntos Acumulados), límpialo aquí también
            // txtPuntosCliente.TextButton = "";

            txtDniCliente.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDniCliente.TextButton) ||
                string.IsNullOrWhiteSpace(txtNombreCliente.TextButton) ||
                string.IsNullOrWhiteSpace(txtApellidoCliente.TextButton) ||
                string.IsNullOrWhiteSpace(txtEmailCliente.TextButton) ||
                string.IsNullOrWhiteSpace(txtDireccionCliente.TextButton))
            {
                MessageBox.Show("Todos los campos son obligatorios. Por favor, complete la información faltante.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Capturar valores y unir el nombre completo
            string dni = txtDniCliente.TextButton;
            string nombreCompleto = $"{txtNombreCliente.TextButton.Trim()} {txtApellidoCliente.TextButton.Trim()}";
            string direccion = txtDireccionCliente.TextButton;
            string email = txtEmailCliente.TextButton;

            // Si tu control de Puntos es un DungeonNumeric, usa .Value.ToString(). Si es CyberTextBox, usa .TextButton
            string puntos = "0"; // Reemplaza esto por tu control real, ej: txtPuntosCliente.TextButton;

            if (indiceFilaEditada >= 0)
            {
                // MODIFICAR FILA EXISTENTE
                dgvClientes.Rows[indiceFilaEditada].Cells[0].Value = dni;
                dgvClientes.Rows[indiceFilaEditada].Cells[1].Value = nombreCompleto;
                dgvClientes.Rows[indiceFilaEditada].Cells[2].Value = direccion;
                dgvClientes.Rows[indiceFilaEditada].Cells[3].Value = email;
                dgvClientes.Rows[indiceFilaEditada].Cells[4].Value = puntos;

                // Actualizamos el bolsillo secreto con los datos separados
                dgvClientes.Rows[indiceFilaEditada].Tag = new string[] { txtNombreCliente.TextButton.Trim(), txtApellidoCliente.TextButton.Trim() };

                MessageBox.Show("Cliente modificado correctamente.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // AGREGAR FILA NUEVA y obtener en qué índice quedó guardada
                int nuevaFilaIndice = dgvClientes.Rows.Add(dni, nombreCompleto, direccion, email, puntos, "Editar", "X");

                // Guardamos los datos separados en el bolsillo secreto de esta nueva fila
                dgvClientes.Rows[nuevaFilaIndice].Tag = new string[] { txtNombreCliente.TextButton.Trim(), txtApellidoCliente.TextButton.Trim() };

                MessageBox.Show("¡Cliente agregado con éxito!", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ActualizarContador();
            btnNuevo_Click(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string dniAEliminar = txtDniCliente.TextButton.Trim();

            // 1. Validar que haya un DNI escrito
            if (string.IsNullOrWhiteSpace(dniAEliminar))
            {
                MessageBox.Show("Por favor, seleccione un cliente de la lista o ingrese un DNI para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Preguntar al usuario para confirmar
            DialogResult respuesta = MessageBox.Show($"¿Está seguro que desea eliminar al cliente con DNI {dniAEliminar}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                bool clienteEncontrado = false;

                // 3. Recorrer la grilla buscando la fila que tenga ese DNI (Columna 0)
                foreach (DataGridViewRow fila in dgvClientes.Rows)
                {
                    // Ignoramos la última fila en blanco (si existe)
                    if (fila.IsNewRow) continue;

                    if (fila.Cells[0].Value?.ToString() == dniAEliminar)
                    {
                        // Encontramos al cliente, lo eliminamos de la grilla
                        dgvClientes.Rows.Remove(fila);
                        clienteEncontrado = true;
                        break; // Detenemos la búsqueda
                    }
                }

                // 4. Mostrar el resultado y sincronizar la interfaz
                if (clienteEncontrado)
                {
                    MessageBox.Show("Cliente eliminado de la lista correctamente.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ActualizarContador(); // Actualiza el número de abajo
                    btnNuevo_Click(sender, e); // Limpia los campos de texto y resetea la variable de edición
                }
                else
                {
                    MessageBox.Show("No se encontró ningún cliente con ese DNI en la lista.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {

        }


        private void ActualizarContador()
        {
            // Resta 1 si la grilla muestra la fila en blanco al final
            int cantidad = dgvClientes.AllowUserToAddRows ? dgvClientes.Rows.Count - 1 : dgvClientes.Rows.Count;
            contadorClientes.TextButton = cantidad.ToString();
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == dgvClientes.NewRowIndex) return;

            DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];

            // --- MODIFICAR (Suponiendo que "Modificar" es la columna 5) ---
            if (e.ColumnIndex == 5)
            {
                txtDniCliente.TextButton = fila.Cells[0].Value?.ToString();

                // Recuperamos los nombres originales exactos desde el bolsillo secreto (Tag)
                if (fila.Tag is string[] nombresOriginales)
                {
                    txtNombreCliente.TextButton = nombresOriginales[0];
                    txtApellidoCliente.TextButton = nombresOriginales[1];
                }
                else
                {
                    // Código de rescate por si la fila no tenía Tag (ej. datos cargados antes de este cambio)
                    string nombreCompleto = fila.Cells[1].Value?.ToString() ?? "";
                    string[] partes = nombreCompleto.Split(new[] { ' ' }, 2);
                    txtNombreCliente.TextButton = partes.Length > 0 ? partes[0] : "";
                    txtApellidoCliente.TextButton = partes.Length > 1 ? partes[1] : "";
                }

                txtDireccionCliente.TextButton = fila.Cells[2].Value?.ToString();
                txtEmailCliente.TextButton = fila.Cells[3].Value?.ToString();

                // txtPuntosCliente.TextButton = fila.Cells[4].Value?.ToString();

                indiceFilaEditada = e.RowIndex;
            }
            // --- ELIMINAR (Suponiendo que "Eliminar" es la columna 6) ---
            else if (e.ColumnIndex == 6)
            {
                DialogResult respuesta = MessageBox.Show("¿Está seguro que desea eliminar este cliente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    dgvClientes.Rows.RemoveAt(e.RowIndex);
                    ActualizarContador();

                    // Forzamos la limpieza de campos para no dejar datos "fantasma" listos para editar
                    btnNuevo_Click(null, null);
                }
            }
        }
    }
}
