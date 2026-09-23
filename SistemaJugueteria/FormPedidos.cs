using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SistemaJugueteria.Presentacion.Utilidades;

namespace SistemaJugueteria
{
    public partial class FormPedidos : Form
    {
        private int contadorNumeroPedido = 1001;

        public FormPedidos()
        {
            InitializeComponent();

            Validaciones.ConfigurarSoloNumeros(txtNumeroPedidoBuscar);
            Validaciones.ConfigurarSoloNumeros(txtCodigoPedido);

            // Nombre de usuario desde Sesión
            txtUsuario.TextButton = Sesion.NombreCompleto;

            TextBox txtUsuarioReal = txtUsuario.Controls.OfType<TextBox>().FirstOrDefault();
            if (txtUsuarioReal != null)
            {
                txtUsuarioReal.Enabled = false;
                txtUsuarioReal.BackColor = SystemColors.Control;
            }
            else
            {
                txtUsuario.Enabled = false;
            }

            TextBox txtPedidoReal = txtNumeroPedido.Controls.OfType<TextBox>().FirstOrDefault();
            if (txtPedidoReal != null)
            {
                txtPedidoReal.Enabled = false;
                txtPedidoReal.BackColor = SystemColors.Control;
            }
            else
            {
                txtNumeroPedido.Enabled = false;
            }

            GenerarSiguienteNumeroPedido();

            // Suscribir el evento para el color del estado
            dgvListaPedidos.CellFormatting += dgvListaPedidos_CellFormatting;
        }

        private void GenerarSiguienteNumeroPedido()
        {
            txtNumeroPedido.TextButton = contadorNumeroPedido.ToString();
        }

        private void label2_Click(object sender, EventArgs e) { }
        private void hopeTextBox3_Click(object sender, EventArgs e) { }
        private void FormPedidos_Load(object sender, EventArgs e) { }
        private void panel1_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void panel3_Click(object sender, EventArgs e) { }
        private void cbProveedor_SelectedIndexChanged(object sender, EventArgs e) { }

        private void ActualizarContadorPedidos()
        {
            int cantidad = dgvListaPedidos.AllowUserToAddRows ? dgvListaPedidos.Rows.Count - 1 : dgvListaPedidos.Rows.Count;
            contadorPedidos.TextButton = cantidad.ToString();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigoPedido.TextButton;
            string descripcion = txtDescripcionPedido.TextButton; // Se usa solo la descripción

            if (string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show("Por favor, ingrese un producto.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad = Convert.ToInt32(numCantidad.Value);
            if (cantidad <= 0)
            {
                cantidad = 1;
            }

            string categoria = "-";

            // Se agregan las columnas eliminando 'nombre': 
            // 0: Codigo, 1: Descripcion, 2: Categoria, 3: Cantidad, 4: Eliminar ("X")
            dgvDetallePedido.Rows.Add(codigo, descripcion, categoria, cantidad, "X");

            LimpiarCamposProducto();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumeroPedido.TextButton) ||
                string.IsNullOrWhiteSpace(cbProveedor.Text))
            {
                MessageBox.Show("Por favor, seleccione un Proveedor.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int filasDetalle = dgvDetallePedido.AllowUserToAddRows ? dgvDetallePedido.Rows.Count - 1 : dgvDetallePedido.Rows.Count;
            if (filasDetalle == 0)
            {
                MessageBox.Show("El pedido debe contener al menos un producto.", "Pedido vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string numero = txtNumeroPedido.TextButton;
            string usuario = txtUsuario.TextButton;
            string proveedor = cbProveedor.Text;

            string fechaRealizacion = dtpFechaRealizacion.Value.ToString("dd/MM/yyyy");
            string fechaEstimada = dtpFechaEstimadaPedido.Checked ? dtpFechaEstimadaPedido.Value.ToString("dd/MM/yyyy") : "A confirmar";

            // Asumiendo las columnas en dgvListaPedidos:
            // 0: Numero | 1: Usuario | 2: FechaRealizacion | 3: FechaEstimada | 4: Proveedor | 5: Estado | 6: Eliminar | 7: Detalle
            dgvListaPedidos.Rows.Add(numero, usuario, fechaRealizacion, fechaEstimada, proveedor, "Pendiente", "X", "📄 Detalle");

            MessageBox.Show("Pedido registrado y confirmado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            contadorNumeroPedido++;

            ActualizarContadorPedidos();
            btnCancelar_Click(sender, e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            GenerarSiguienteNumeroPedido();

            cbProveedor.SelectedIndex = -1;

            dtpFechaRealizacion.Value = DateTime.Now;
            dtpFechaEstimadaPedido.Value = DateTime.Now;
            dtpFechaEstimadaPedido.Checked = true;

            LimpiarCamposProducto();

            dgvDetallePedido.Rows.Clear();
        }

        private void LimpiarCamposProducto()
        {
            txtCodigoPedido.TextButton = "";
            txtDescripcionPedido.TextButton = "";
            numCantidad.Value = 0;
            nombreProducto.TextButton = "";
        }

        private void btnCancelarProducto_Click(object sender, EventArgs e)
        {
            LimpiarCamposProducto();
        }

        private void cyberButton1_Click(object sender, EventArgs e)
        {
            LimpiarCamposProducto();
        }

        private void dgvDetallePedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == dgvDetallePedido.NewRowIndex) return;

            // Al eliminar 'nombre', la columna 'Eliminar' (X) pasa a ser la número 4
            if (e.ColumnIndex == 4)
            {
                DialogResult respuesta = MessageBox.Show("¿Desea quitar este producto del pedido actual?", "Quitar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    dgvDetallePedido.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void dgvListaPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == dgvListaPedidos.NewRowIndex) return;

            // COLUMNA 5: ESTADO (Cambio de estado: Pendiente <-> Recibido)
            if (e.ColumnIndex == 5)
            {
                string estadoActual = dgvListaPedidos.Rows[e.RowIndex].Cells[5].Value?.ToString();

                if (estadoActual == "Pendiente")
                {
                    dgvListaPedidos.Rows[e.RowIndex].Cells[5].Value = "Recibido";
                }
                else
                {
                    dgvListaPedidos.Rows[e.RowIndex].Cells[5].Value = "Pendiente";
                }

                dgvListaPedidos.InvalidateRow(e.RowIndex);
            }
            // COLUMNA 6: ELIMINAR
            else if (e.ColumnIndex == 6)
            {
                string numPedido = dgvListaPedidos.Rows[e.RowIndex].Cells[0].Value?.ToString();

                DialogResult respuesta = MessageBox.Show($"¿Está seguro que desea eliminar el pedido N° {numPedido} del historial?", "Eliminar Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    dgvListaPedidos.Rows.RemoveAt(e.RowIndex);
                    ActualizarContadorPedidos();
                }
            }
            // COLUMNA 7: DETALLE (Simulación de descarga de PDF)
            else if (e.ColumnIndex == 7)
            {
                string numPedido = dgvListaPedidos.Rows[e.RowIndex].Cells[0].Value?.ToString();
                string proveedor = dgvListaPedidos.Rows[e.RowIndex].Cells[4].Value?.ToString();

                SimularDescargaPDF(numPedido, proveedor);
            }
        }

        // Método auxiliar para simular la descarga/apertura del PDF de detalle del pedido
        private void SimularDescargaPDF(string numeroPedido, string proveedor)
        {
            string rutaTemporal = Path.Combine(Path.GetTempPath(), $"Pedido_{numeroPedido}_Detalle.txt");

            string contenidoPDF = $@"==========================================" + "\n" +
                                   $"    COMPROBANTE DE DETALLE DE PEDIDO     " + "\n" +
                                   $"==========================================" + "\n" +
                                   $"Número de Pedido: {numeroPedido}\n" +
                                   $"Proveedor: {proveedor}\n" +
                                   $"Fecha de Descarga: {DateTime.Now:dd/MM/yyyy HH:mm}\n" +
                                   $"------------------------------------------\n" +
                                   $"[DETALLES DEL PEDIDO SOLICITADO]\n" +
                                   $"- Producto Ejemplo A x 5 unidades\n" +
                                   $"- Producto Ejemplo B x 2 unidades\n" +
                                   $"==========================================";

            File.WriteAllText(rutaTemporal, contenidoPDF);

            MessageBox.Show($"Descargando detalle en PDF para el pedido N° {numeroPedido}...", "Descarga de Archivo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Simula abrir el PDF utilizando el visor del sistema (abre el bloc de notas)
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(rutaTemporal) { UseShellExecute = true });
        }

        // EVENTO PARA EL COLOR DEL ESTADO (Gris = Pendiente, Verde = Recibido)
        private void dgvListaPedidos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == dgvListaPedidos.NewRowIndex) return;

            if (e.ColumnIndex == 5)
            {
                string estado = e.Value?.ToString();

                if (estado == "Recibido")
                {
                    e.CellStyle.BackColor = Color.MediumSeaGreen;
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.SeaGreen;
                    e.CellStyle.SelectionForeColor = Color.White;
                }
                else
                {
                    e.CellStyle.BackColor = Color.LightGray;
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.SelectionBackColor = Color.Gray;
                    e.CellStyle.SelectionForeColor = Color.White;
                }
            }
        }
    }
}