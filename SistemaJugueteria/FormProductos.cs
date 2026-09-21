using SistemaJugueteria.Presentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaJugueteria
{
    public partial class FormProductos : Form
    {

        // Variable global para saber si estamos editando (-1 significa que es un producto NUEVO)
        private int indiceFilaEditada = -1;
        public FormProductos()
        {
            InitializeComponent();

            Validaciones.ConfigurarSoloDecimales(txtPrecioProducto);
        }

        private void aloneTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void crownTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormProductos_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void hopeTextBox9_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validar
            if (string.IsNullOrWhiteSpace(txtCodigoProducto.TextButton) || string.IsNullOrWhiteSpace(txtDescripcionProducto.TextButton))
            {
                MessageBox.Show("El Código y la Descripción son obligatorios.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Capturar valores
            string codigo = txtCodigoProducto.TextButton;
            string descripcion = txtDescripcionProducto.TextButton;
            string precio = "$ " + txtPrecioProducto.TextButton;
            string categoria = categoriaProducto.Text;
            string strStockActual = stockActual.Value.ToString();
            string strStockMinimo = stockMinimo.Value.ToString();

            // 3. DECISIÓN: ¿Estamos editando o creando?
            if (indiceFilaEditada >= 0)
            {
                // ACTUALIZAR fila existente
                dgvProductos.Rows[indiceFilaEditada].Cells[0].Value = codigo;
                dgvProductos.Rows[indiceFilaEditada].Cells[1].Value = descripcion;
                dgvProductos.Rows[indiceFilaEditada].Cells[2].Value = categoria;
                dgvProductos.Rows[indiceFilaEditada].Cells[3].Value = precio;
                dgvProductos.Rows[indiceFilaEditada].Cells[4].Value = strStockActual;
                dgvProductos.Rows[indiceFilaEditada].Cells[5].Value = strStockMinimo;

                MessageBox.Show("Producto modificado correctamente.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Resetear la variable para la próxima vez
                indiceFilaEditada = -1;
            }
            else
            {
                // AGREGAR fila nueva (código anterior)
                dgvProductos.Rows.Add(codigo, descripcion, categoria, precio, strStockActual, strStockMinimo, "Editar", "X");
                MessageBox.Show("Producto guardado temporalmente en la lista.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // 4. Limpiar los controles
            txtCodigoProducto.TextButton = "";
            txtDescripcionProducto.TextButton = "";
            txtPrecioProducto.TextButton = "";
            categoriaProducto.SelectedIndex = -1;
            stockActual.Value = 0;
            stockMinimo.Value = 0;

            // 5. Actualizar el contador total
            ActualizarContador();
        }

        private void ActualizarContador()
        {
            // Restamos 1 solo si tu DataGridView tiene habilitada la fila vacía para agregar al final (AllowUserToAddRows = true)
            // Si no la tiene, simplemente usa dgvProductos.Rows.Count
            int cantidad = dgvProductos.AllowUserToAddRows ? dgvProductos.Rows.Count - 1 : dgvProductos.Rows.Count;

            // Asigna el número al CyberTextBox de abajo (cambia el nombre por el tuyo)
            txtCantidadProductos.TextButton = cantidad.ToString();
        }





        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Ignorar si el clic fue en los títulos de las columnas o en la fila vacía del final
            if (e.RowIndex < 0 || e.RowIndex == dgvProductos.NewRowIndex) return;

            DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

            // --- ACCIÓN: MODIFICAR (Asumiendo que es la columna 6) ---
            if (e.ColumnIndex == 6)
            {
                // Pasar los datos de la fila a los controles de arriba
                txtCodigoProducto.TextButton = fila.Cells[0].Value?.ToString();
                txtDescripcionProducto.TextButton = fila.Cells[1].Value?.ToString();
                categoriaProducto.Text = fila.Cells[2].Value?.ToString();

                // Limpiar el símbolo "$"
                string precioPuro = fila.Cells[3].Value?.ToString().Replace("$", "").Trim();
                txtPrecioProducto.TextButton = precioPuro;

                stockActual.Value = Convert.ToInt32(fila.Cells[4].Value);
                stockMinimo.Value = Convert.ToInt32(fila.Cells[5].Value);

                // Guardar el índice para sobreescribir después
                indiceFilaEditada = e.RowIndex;
            }
            // --- ACCIÓN: ELIMINAR (Asumiendo que es la columna 7) ---
            else if (e.ColumnIndex == 7)
            {
                DialogResult respuesta = MessageBox.Show("¿Está seguro que desea eliminar este producto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    // 1. Eliminamos la fila de la grilla
                    dgvProductos.Rows.RemoveAt(e.RowIndex);

                    // 2. Actualizamos el contador
                    ActualizarContador();

                    // 3. NUEVO: Cancelamos cualquier edición en curso para evitar que colapse
                    indiceFilaEditada = -1;

                    // 4. NUEVO: Limpiamos los campos de arriba
                    txtCodigoProducto.TextButton = "";
                    txtDescripcionProducto.TextButton = "";
                    txtPrecioProducto.TextButton = "";
                    categoriaProducto.SelectedIndex = -1; // o categoriaProducto.Text = ""; si no usas SelectedIndex
                    stockActual.Value = 0;
                    stockMinimo.Value = 0;
                }
            }
        }

        private void btnLimpiarProducto_Click(object sender, EventArgs e)
        {
            // 1. Cancelar cualquier edición pendiente para que el próximo guardado sea un producto nuevo
            indiceFilaEditada = -1;

            // 2. Limpiar los campos de texto (CyberTextBox)
            txtCodigoProducto.TextButton = "";
            txtDescripcionProducto.TextButton = "";
            txtPrecioProducto.TextButton = "";

            // 3. Limpiar el ComboBox (deselecciona la categoría)
            categoriaProducto.SelectedIndex = -1;
            // Si la línea anterior te da error, usa: categoriaProducto.Text = "";

            // 4. Reiniciar los valores de los DungeonNumeric
            stockActual.Value = 0;
            stockMinimo.Value = 0;

            // 5. (Opcional) Llevar el cursor de vuelta al primer campo para mayor comodidad
            txtCodigoProducto.Focus();
        }
    }
}
