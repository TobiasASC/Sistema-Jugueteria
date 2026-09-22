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
    public partial class FormPedidos : Form
    {
        public FormPedidos()
        {
            InitializeComponent();
            Validaciones.ConfigurarSoloNumeros(txtNumeroPedido);
            Validaciones.ConfigurarSoloNumeros(txtNumeroPedidoBuscar);

            //Cargamos el nombre de la sesión activa
            txtUsuario.TextButton = SesionProvisoria.NombreCompleto;

            // 2. Bloqueamos el campo buscando el TextBox interno del CyberTextBox
            TextBox txtUsuarioReal = txtUsuario.Controls.OfType<TextBox>().FirstOrDefault();
            if (txtUsuarioReal != null)
            {
                txtUsuarioReal.ReadOnly = true;
                txtUsuarioReal.BackColor = SystemColors.Control; // Le da un tono grisáceo para indicar que está bloqueado
            }
            else
            {
                txtUsuario.Enabled = false; // Alternativa por si falla lo anterior
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void hopeTextBox3_Click(object sender, EventArgs e)
        {

        }

        private void FormPedidos_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Click(object sender, EventArgs e)
        {

        }

        private void ActualizarContadorPedidos()
        {
            // Asegúrate de cambiar "dgvListaPedidos" y "contadorPedidos" por los nombres reales de tus controles
            int cantidad = dgvListaPedidos.AllowUserToAddRows ? dgvListaPedidos.Rows.Count - 1 : dgvListaPedidos.Rows.Count;
            contadorPedidos.TextButton = cantidad.ToString();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigoPedido.TextButton;
            string descripcion = txtDescripcionPedido.TextButton;
            string nombre = nombreProducto.TextButton;

            // Validamos que haya buscado/seleccionado un producto
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show("Por favor, ingrese un producto.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validación de Cantidad: Si es 0 o menor, se fuerza a 1 automáticamente
            int cantidad = Convert.ToInt32(numCantidad.Value);
            if (cantidad <= 0)
            {
                cantidad = 1;
            }

            // Categoría simulada (en un sistema real vendría de la base de datos al buscar el producto)
            string categoria = "-";

            // Agregamos a la primera grilla 
            dgvDetallePedido.Rows.Add(codigo, nombre, descripcion, categoria, cantidad, "X");

            // Limpiamos los campos para buscar el siguiente producto
            txtCodigoPedido.TextButton = "";
            txtDescripcionPedido.TextButton = ""; // La caja de búsqueda larga
            nombreProducto.TextButton = "";
            numCantidad.Value = 0;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // 1. Validar Cabecera (Ya no validamos txtUsuario porque siempre estará lleno y bloqueado)
            if (string.IsNullOrWhiteSpace(txtNumeroPedido.TextButton) ||
                string.IsNullOrWhiteSpace(cbProveedor.Text))
            {
                MessageBox.Show("Por favor, complete el N° de Pedido y seleccione un Proveedor.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validar que haya al menos 1 producto en la grilla de detalle
            int filasDetalle = dgvDetallePedido.AllowUserToAddRows ? dgvDetallePedido.Rows.Count - 1 : dgvDetallePedido.Rows.Count;
            if (filasDetalle == 0)
            {
                MessageBox.Show("El pedido debe contener al menos un producto.", "Pedido vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Capturar todos los datos
            string numero = txtNumeroPedido.TextButton;
            string usuario = txtUsuario.TextButton;
            string proveedor = cbProveedor.Text;

            // Corregimos la lectura: asegúrate de usar el control correcto para la fecha de realización
            string fechaRealizacion = dtpFechaRealizacion.Value.ToString("dd/MM/yyyy"); // Reemplaza dtpFechaRealizacion por el nombre de tu control

            // Lectura de fecha estimada con CheckBox
            string fechaEstimada = dtpFechaEstimadaPedido.Checked ? dtpFechaEstimadaPedido.Value.ToString("dd/MM/yyyy") : "A confirmar";

            // 4. Agregar a la grilla inferior en el orden EXACTO de tus columnas
            dgvListaPedidos.Rows.Add(numero, usuario, fechaRealizacion, fechaEstimada, proveedor, "X");

            MessageBox.Show("Pedido registrado y confirmado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 5. Limpiar todo para un nuevo pedido
            ActualizarContadorPedidos();
            btnCancelar_Click(sender, e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Limpiar Cabecera
            txtNumeroPedido.TextButton = "";
            cbProveedor.SelectedIndex = -1;

            // Ojo aquí tenías repetido dtpFechaEntrega, asumiendo que tienes 2 controles distintos:
            dtpFechaRealizacion.Value = DateTime.Now;
            dtpFechaEstimadaPedido.Value = DateTime.Now;
            dtpFechaEstimadaPedido.Checked = true;

            // Limpiar Detalle
            txtCodigoPedido.TextButton = "";
            txtDescripcionPedido.TextButton = "";
            nombreProducto.TextButton = "";
            numCantidad.Value = 0;

            dgvDetallePedido.Rows.Clear();
        }

        private void dgvDetallePedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignorar clics en los encabezados o en la fila vacía
            if (e.RowIndex < 0 || e.RowIndex == dgvDetallePedido.NewRowIndex) return;

            // Verificamos si hizo clic en la columna que contiene la "X"
            string valorCelda = dgvDetallePedido.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

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

            string valorCelda = dgvListaPedidos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

            // Verificamos si hizo clic en la columna de eliminar ("X")
            if (e.ColumnIndex == 5)
            {
                // Leemos el número de pedido para hacerlo más descriptivo
                string numPedido = dgvListaPedidos.Rows[e.RowIndex].Cells[0].Value?.ToString();

                DialogResult respuesta = MessageBox.Show($"¿Está seguro que desea eliminar el pedido N° {numPedido} del historial?", "Eliminar Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    dgvListaPedidos.Rows.RemoveAt(e.RowIndex);

                    // Es vital llamar a tu método para que el CyberTextBox de abajo se actualice
                    ActualizarContadorPedidos();
                }
            }
        }
    }
}
