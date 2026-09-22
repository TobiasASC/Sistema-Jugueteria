using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            txtUsuario.TextButton = SesionProvisoria.NombreCompleto;

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
            string descripcion = txtDescripcionPedido.TextButton;
            string nombre = nombreProducto.TextButton;

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

            dgvDetallePedido.Rows.Add(codigo, nombre, descripcion, categoria, cantidad, "X");

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

            dgvListaPedidos.Rows.Add(numero, usuario, fechaRealizacion, fechaEstimada, proveedor, "X");

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
            nombreProducto.TextButton = "";
            numCantidad.Value = 0;
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

            if (e.ColumnIndex == 5)
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

            if (e.ColumnIndex == 5)
            {
                string numPedido = dgvListaPedidos.Rows[e.RowIndex].Cells[0].Value?.ToString();

                DialogResult respuesta = MessageBox.Show($"¿Está seguro que desea eliminar el pedido N° {numPedido} del historial?", "Eliminar Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    dgvListaPedidos.Rows.RemoveAt(e.RowIndex);
                    ActualizarContadorPedidos();
                }
            }
        }
    }
}