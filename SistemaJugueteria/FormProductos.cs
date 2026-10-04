using SistemaJugueteria.Business;
using SistemaJugueteria.Entities;
using SistemaJugueteria.Presentacion.Utilidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaJugueteria
{
    public partial class FormProductos : Form
    {
        // Variables de negocio para manejar operaciones relacionadas con productos  
        private ProductoBusiness _productoBusiness = new ProductoBusiness();
        private CategoriaBusiness _categoriaBusiness = new CategoriaBusiness();
        // Variable para determinar si estamos en modo de modificación o no
        private bool esModificacion = false;

        public FormProductos()
        {
            InitializeComponent();

            Validaciones.ConfigurarSoloNumeros(txtCodigoProducto);
            Validaciones.ConfigurarSoloDecimales(txtPrecioProducto);
            Validaciones.ConfigurarSoloNumeros(txtCodigoProductoBuscar);

            dgvProductos.AutoGenerateColumns = false;
        }

        private string ObtenerTexto(Control control)
        {
            if (control == null) return "";
            var propiedadTextButton = control.GetType().GetProperty("TextButton");
            if (propiedadTextButton != null)
            {
                string valor = propiedadTextButton.GetValue(control, null)?.ToString();
                if (!string.IsNullOrWhiteSpace(valor)) return valor.Trim();
            }
            return control.Text.Trim();
        }

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
            CargarCategorias();
            CargarGrilla();

            // Vincular eventos KeyUp a los controles internos de los CyberTextBox para filtrar la grilla   
            VincularEventoInterno(txtCodigoProductoBuscar);
            VincularEventoInterno(txtDescripcionBuscar);
        }

        // Método para vincular el evento KeyUp a los controles internos de los CyberTextBox
        private void VincularEventoInterno(ReaLTaiizor.Controls.CyberTextBox cyberCaja)
        {
            if (cyberCaja == null) return;

            foreach (Control controlInterno in cyberCaja.Controls)
            {
                if (controlInterno is TextBox cajaReal)
                {
                    cajaReal.KeyUp += new KeyEventHandler(CajasDeBusqueda_KeyUp);
                    break;
                }
            }
        }

        // Evento que se dispara cuando se presiona una tecla en las cajas de búsqueda
        private void CajasDeBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            FiltrarGrilla();
        }

        // Método para cargar los productos en el DataGridView
        private void CargarGrilla()
        {
            bool verInactivos = chkEstado.Checked;
            dgvProductos.DataSource = _productoBusiness.ListarProductos(verInactivos);
            ActualizarContador();

            if (dgvProductos.Columns.Count > 6 && dgvProductos.Columns[6] is DataGridViewButtonColumn columModificar)
            {
                columModificar.UseColumnTextForButtonValue = true;
                columModificar.Text = "Modificar";
            }

            if (dgvProductos.Columns.Count > 7 && dgvProductos.Columns[7] is DataGridViewButtonColumn columEliminar)
            {
                columEliminar.UseColumnTextForButtonValue = true;
                columEliminar.Text = verInactivos ? "Reactivar" : "Eliminar";
            }
        }

        // Evento que se dispara al hacer clic en el botón "Nuevo"
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Bloquea la creación si el usuario está modificando un producto
            if (esModificacion)
            {
                MessageBox.Show("Actualmente está modificando un producto. Presione 'Guardar' para aplicar los cambios, o 'Cancelar' para limpiar el formulario y registrar uno nuevo.", "Modo Edición", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidarCamposVacios()) return;

            Producto nuevoProducto = new Producto()
            {
                IdProducto = ObtenerTexto(txtCodigoProducto),
                Descripcion = ObtenerTexto(txtDescripcionProducto),
                PrecioVenta = Convert.ToDecimal(ObtenerTexto(txtPrecioProducto)),
                StockActual = (int)stockActual.Value,
                StockMinimo = (int)stockMinimo.Value,
                IdCategoria = Convert.ToInt32(cbCategoriaProducto.SelectedValue)
            };

            string mensaje = _productoBusiness.RegistrarProducto(nuevoProducto);
            MessageBox.Show(mensaje, "Nuevo Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (mensaje.Contains("correctamente"))
            {
                LimpiarFormulario();
                CargarGrilla();
            }
        }

        // Evento que se dispara al hacer clic en el botón "Guardar"
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!esModificacion)
            {
                MessageBox.Show("Seleccione un producto de la lista (opción 'Modificar') para poder guardar los cambios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ValidarCamposVacios()) return;

            Producto productoModificado = new Producto()
            {
                IdProducto = ObtenerTexto(txtCodigoProducto),
                Descripcion = ObtenerTexto(txtDescripcionProducto),
                PrecioVenta = Convert.ToDecimal(ObtenerTexto(txtPrecioProducto)),
                StockActual = (int)stockActual.Value,
                StockMinimo = (int)stockMinimo.Value,
                IdCategoria = Convert.ToInt32(cbCategoriaProducto.SelectedValue)
            };

            string mensaje = _productoBusiness.ModificarProducto(productoModificado);
            MessageBox.Show(mensaje, "Cambios Guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (mensaje.Contains("correctamente"))
            {
                LimpiarFormulario();
                CargarGrilla();
            }
        }

        // Evento que se dispara al hacer clic en el botón "Cancelar"
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }



        // Método para limpiar el formulario y resetear los campos
        private void LimpiarFormulario()
        {
            esModificacion = false;

            AsignarTexto(txtCodigoProducto, "");
            AsignarTexto(txtDescripcionProducto, "");
            AsignarTexto(txtPrecioProducto, "");
            cbCategoriaProducto.SelectedIndex = -1;
            stockActual.Value = 0;
            stockMinimo.Value = 0;

            if (txtCodigoProducto != null) txtCodigoProducto.Enabled = true;
        }

        // Método para actualizar el contador de productos en la interfaz
        private void ActualizarContador()
        {
            if (dgvProductos.DataSource is DataTable dt)
            {
                // Cuenta las filas de la vista filtrada
                AsignarTexto(txtCantidadProductos, dt.DefaultView.Count.ToString());
            }
            else
            {
                AsignarTexto(txtCantidadProductos, dgvProductos.Rows.Count.ToString());
            }
        }

        // Evento que se dispara al hacer clic en una celda del DataGridView
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

            if (e.ColumnIndex == 6)
            {
                AsignarTexto(txtCodigoProducto, fila.Cells["Codigo"].Value.ToString());
                AsignarTexto(txtDescripcionProducto, fila.Cells["Descripcion"].Value.ToString());
                AsignarTexto(txtPrecioProducto, fila.Cells["Precio"].Value.ToString());
                cbCategoriaProducto.Text = fila.Cells["Categoria"].Value.ToString();

                stockActual.Value = Convert.ToInt32(fila.Cells["Stock_Actual"].Value);
                stockMinimo.Value = Convert.ToInt32(fila.Cells["Stock_Minimo"].Value);

                if (txtCodigoProducto != null) txtCodigoProducto.Enabled = false;

                esModificacion = true;
            }
            else if (e.ColumnIndex == 7)
            {
                string idProducto = fila.Cells["Codigo"].Value.ToString();

                if (!chkEstado.Checked)
                {
                    DialogResult respuesta = MessageBox.Show("¿Está seguro que desea dar de baja este producto?", "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes)
                    {
                        string mensaje = _productoBusiness.EliminarProducto(idProducto);
                        MessageBox.Show(mensaje, "Producto Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrilla();
                        LimpiarFormulario();
                    }
                }
                else
                {
                    DialogResult respuesta = MessageBox.Show("¿Desea volver a activar este producto?", "Confirmar Reactivación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes)
                    {
                        string mensaje = _productoBusiness.ReactivarProducto(idProducto);
                        MessageBox.Show(mensaje, "Producto Reactivado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrilla();
                        LimpiarFormulario();
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvProductos_CellClick(sender, e);
        }

        private void aloneTextBox1_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void crownTextBox1_TextChanged(object sender, EventArgs e) { }
        private void hopeTextBox9_Click(object sender, EventArgs e) { }

        // Método para validar que los campos obligatorios no estén vacíos
        private bool ValidarCamposVacios()
        {
            bool faltaCodigo = string.IsNullOrWhiteSpace(ObtenerTexto(txtCodigoProducto));
            bool faltaDescripcion = string.IsNullOrWhiteSpace(ObtenerTexto(txtDescripcionProducto));
            bool faltaPrecio = string.IsNullOrWhiteSpace(ObtenerTexto(txtPrecioProducto));

            if (faltaCodigo || faltaDescripcion || faltaPrecio)
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            return false;
        }

        // Método para cargar las categorías activas en el ComboBox
        private void CargarCategorias()
        {
            cbCategoriaProducto.DataSource = _categoriaBusiness.ListarCategoriasActivas();
            cbCategoriaProducto.DisplayMember = "NombreCategoria";
            cbCategoriaProducto.ValueMember = "IdCategoria";
            cbCategoriaProducto.SelectedIndex = -1;
        }


        // Método para filtrar la grilla de productos según los criterios de búsqueda
        private void FiltrarGrilla()
        {
            if (dgvProductos.DataSource is DataTable dt)
            {

                string codigoBuscado = ObtenerTexto(txtCodigoProductoBuscar);
                string descripcionBuscada = ObtenerTexto(txtDescripcionBuscar);

                System.Collections.Generic.List<string> filtros = new System.Collections.Generic.List<string>();

                if (!string.IsNullOrWhiteSpace(codigoBuscado))
                {
                    filtros.Add($"Codigo LIKE '%{codigoBuscado}%'");
                }

                if (!string.IsNullOrWhiteSpace(descripcionBuscada))
                {
                    filtros.Add($"Descripcion LIKE '%{descripcionBuscada}%'");
                }

                string filtroFinal = string.Join(" AND ", filtros);
                dt.DefaultView.RowFilter = filtroFinal;

                ActualizarContador();
            }
        }

        // Evento que se dispara al cambiar el estado del interruptor para ver productos activos/inactivos
        private void chkEstado_CheckedChanged()
        {
            CargarGrilla();
        }
    }
}