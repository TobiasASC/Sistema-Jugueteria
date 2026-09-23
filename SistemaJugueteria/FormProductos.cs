using SistemaJugueteria.Presentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaJugueteria
{
    public partial class FormProductos : Form
    {
        private int indiceFilaEditada = -1;

        public FormProductos()
        {
            InitializeComponent();

            // Configuración de validaciones
            Validaciones.ConfigurarSoloNumeros(txtCodigoProducto);
            Validaciones.ConfigurarSoloDecimales(txtPrecioProducto);
            Validaciones.ConfigurarSoloNumeros(txtCodigoProductoBuscar);
        }

        // Método auxiliar seguro para obtener texto de controles personalizados
        private string ObtenerTexto(Control control)
        {
            if (control == null) return "";

            // Intenta leer la propiedad TextButton si existe
            var propiedadTextButton = control.GetType().GetProperty("TextButton");
            if (propiedadTextButton != null)
            {
                string valor = propiedadTextButton.GetValue(control, null)?.ToString();
                if (!string.IsNullOrWhiteSpace(valor)) return valor.Trim();
            }

            // Si no, lee la propiedad Text nativa
            return control.Text.Trim();
        }

        // Método auxiliar seguro para asignar texto a controles personalizados
        private void AsignarTexto(Control control, string valor)
        {
            if (control == null) return;

            var propiedadTextButton = control.GetType().GetProperty("TextButton");
            if (propiedadTextButton != null)
            {
                propiedadTextButton.SetValue(control, valor, null);
            }
            control.Text = valor;
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            ActualizarContador();
        }

        // 1. BOTÓN NUEVO: Agrega un producto a la DataGridView

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (ValidarCamposVacios()) return;

            string codigo = ObtenerTexto(txtCodigoProducto);
            string descripcion = ObtenerTexto(txtDescripcionProducto);
            string precioPuro = ObtenerTexto(txtPrecioProducto);
            string categoria = string.IsNullOrWhiteSpace(categoriaProducto.Text) ? "-" : categoriaProducto.Text;
            string strStockActual = stockActual.Value.ToString();
            string strStockMinimo = stockMinimo.Value.ToString();

            string precioFinal = string.IsNullOrWhiteSpace(precioPuro) ? "$ 0" : "$ " + precioPuro;

            // Agregar nueva fila a la grilla y capturar en qué índice quedó
            int nuevaFilaIndice = dgvProductos.Rows.Add(codigo, descripcion, categoria, precioFinal, strStockActual, strStockMinimo, "Editar", "X");

            // Guardamos los datos originales (sin símbolos) en el Tag
            dgvProductos.Rows[nuevaFilaIndice].Tag = new string[] { codigo, descripcion, categoria, precioPuro, strStockActual, strStockMinimo };

            MessageBox.Show("Producto registrado correctamente.", "Nuevo Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarFormulario();
            ActualizarContador();
        }
        // 2. BOTÓN GUARDAR: Modifica la fila seleccionada
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (indiceFilaEditada < 0)
            {
                MessageBox.Show("Seleccione un producto de la lista (opción 'Editar') para poder guardar los cambios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ValidarCamposVacios()) return;

            string codigo = ObtenerTexto(txtCodigoProducto);
            string descripcion = ObtenerTexto(txtDescripcionProducto);
            string precioPuro = ObtenerTexto(txtPrecioProducto);
            string categoria = string.IsNullOrWhiteSpace(categoriaProducto.Text) ? "-" : categoriaProducto.Text;
            string strStockActual = stockActual.Value.ToString();
            string strStockMinimo = stockMinimo.Value.ToString();

            string precioFinal = string.IsNullOrWhiteSpace(precioPuro) ? "$ 0" : "$ " + precioPuro;

            // Actualizar celdas visuales de la fila en edición
            dgvProductos.Rows[indiceFilaEditada].Cells[0].Value = codigo;
            dgvProductos.Rows[indiceFilaEditada].Cells[1].Value = descripcion;
            dgvProductos.Rows[indiceFilaEditada].Cells[2].Value = categoria;
            dgvProductos.Rows[indiceFilaEditada].Cells[3].Value = precioFinal;
            dgvProductos.Rows[indiceFilaEditada].Cells[4].Value = strStockActual;
            dgvProductos.Rows[indiceFilaEditada].Cells[5].Value = strStockMinimo;

            // Actualizar también el Tag
            dgvProductos.Rows[indiceFilaEditada].Tag = new string[] { codigo, descripcion, categoria, precioPuro, strStockActual, strStockMinimo };

            MessageBox.Show("Producto modificado correctamente.", "Cambios Guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarFormulario();
        }

        // 3. BOTÓN CANCELAR: Limpia las cajas de texto y resetea la edición
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnLimpiarProducto_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            indiceFilaEditada = -1;

            AsignarTexto(txtCodigoProducto, "");
            AsignarTexto(txtDescripcionProducto, "");
            AsignarTexto(txtPrecioProducto, "");
            categoriaProducto.SelectedIndex = -1;
            stockActual.Value = 0;
            stockMinimo.Value = 0;
        }

        private void ActualizarContador()
        {
            int cantidad = dgvProductos.AllowUserToAddRows ? dgvProductos.Rows.Count - 1 : dgvProductos.Rows.Count;
            AsignarTexto(txtCantidadProductos, cantidad < 0 ? "0" : cantidad.ToString());
        }

        // ACCIONES EN LA GRILLA (EDITAR Y ELIMINAR)
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == dgvProductos.NewRowIndex) return;

            DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

            // Columna 6: EDITAR
            if (e.ColumnIndex == 6)
            {
                // Leemos directamente desde nuestro bolsillo secreto (Tag) si existe
                if (fila.Tag is string[] datosPuros)
                {
                    AsignarTexto(txtCodigoProducto, datosPuros[0]);
                    AsignarTexto(txtDescripcionProducto, datosPuros[1]);
                    categoriaProducto.Text = datosPuros[2];
                    AsignarTexto(txtPrecioProducto, datosPuros[3]);

                    if (int.TryParse(datosPuros[4], out int sActual)) stockActual.Value = sActual;
                    if (int.TryParse(datosPuros[5], out int sMinimo)) stockMinimo.Value = sMinimo;
                }
                else
                {
                    // Código de rescate por si la fila se creó antes de implementar el Tag
                    AsignarTexto(txtCodigoProducto, fila.Cells[0].Value?.ToString() ?? "");
                    AsignarTexto(txtDescripcionProducto, fila.Cells[1].Value?.ToString() ?? "");
                    categoriaProducto.Text = fila.Cells[2].Value?.ToString() ?? "";

                    string precioPuro = fila.Cells[3].Value?.ToString().Replace("$", "").Trim() ?? "";
                    AsignarTexto(txtPrecioProducto, precioPuro);

                    if (int.TryParse(fila.Cells[4].Value?.ToString(), out int sActual)) stockActual.Value = sActual;
                    if (int.TryParse(fila.Cells[5].Value?.ToString(), out int sMinimo)) stockMinimo.Value = sMinimo;
                }

                indiceFilaEditada = e.RowIndex;
            }
            // Columna 7: ELIMINAR
            else if (e.ColumnIndex == 7)
            {
                DialogResult respuesta = MessageBox.Show("¿Está seguro que desea eliminar este producto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    dgvProductos.Rows.RemoveAt(e.RowIndex);
                    ActualizarContador();
                    LimpiarFormulario();
                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvProductos_CellClick(sender, e);
        }

        // Handlers vacíos requeridos por el diseñador
        private void aloneTextBox1_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void crownTextBox1_TextChanged(object sender, EventArgs e) { }
        private void hopeTextBox9_Click(object sender, EventArgs e) { }


        private bool ValidarCamposVacios()
        {
            // Evaluamos solo los campos realmente obligatorios
            bool faltaCodigo = string.IsNullOrWhiteSpace(ObtenerTexto(txtCodigoProducto));
            bool faltaDescripcion = string.IsNullOrWhiteSpace(ObtenerTexto(txtDescripcionProducto));
            bool faltaPrecio = string.IsNullOrWhiteSpace(ObtenerTexto(txtPrecioProducto));

            // Si alguno está vacío, mostramos la alerta
            if (faltaCodigo || faltaDescripcion || faltaPrecio)
            {
                MessageBox.Show("Por favor, complete todos los campos para guardar el producto.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            return false;
        }
    }
}
