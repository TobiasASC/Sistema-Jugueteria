using SistemaJugueteria.Business;
using SistemaJugueteria.Entities;
using SistemaJugueteria.Presentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaJugueteria
{
    public partial class FormPedidos : Form
    {
        // Instancias de las clases de negocio
        private PedidoBusiness _pedidoBusiness = new PedidoBusiness();
        private ProveedorBusiness _proveedorBusiness = new ProveedorBusiness();
        private ProductoBusiness _productoBusiness = new ProductoBusiness();

        // Variable para llevar el total del pedido actual
        private decimal totalPedidoActual = 0;
        private int idPedidoEnEdicion = 0;
        private string codigoProductoSeleccionado = "";

        public FormPedidos()
        {
            InitializeComponent();

            // Configuracionn de validación para el textbox de búsqueda de número de pedido
            Validaciones.ConfigurarSoloNumeros(txtNumeroPedidoBuscar);

            txtUsuario.TextButton = Sesion.NombreCompleto;

            // Bloquea los CyberTextBox que no deben ser editables por el usuario
            BloquearCyberTextBox(txtUsuario);
            BloquearCyberTextBox(txtNumeroPedido);
            BloquearCyberTextBox(txtProductoSeleccionado);

            dgvListaPedidos.AutoGenerateColumns = false;
            dgvBuscarProducto.AutoGenerateColumns = false;
            dgvListaPedidos.CellFormatting += dgvListaPedidos_CellFormatting;

            // Conectar el evento TextChanged del CyberTextBox por código:
            TextBox txtBusqueda = txtNumeroPedidoBuscar.Controls.OfType<TextBox>().FirstOrDefault();
            if (txtBusqueda != null)
            {
                txtBusqueda.TextChanged += txtNumeroPedidoBuscar_TextChanged;
            }

            dgvDetallePedido.CellValueChanged += dgvDetallePedido_CellValueChanged;

            TextBox txtBusquedaCodProd = txtCodigoProductoBuscar.Controls.OfType<TextBox>().FirstOrDefault();
            if (txtBusquedaCodProd != null)
            {
                txtBusquedaCodProd.TextChanged += txtFiltroProducto_TextChanged;
            }

            TextBox txtBusquedaDescProd = txtDescripcionProductoBuscar.Controls.OfType<TextBox>().FirstOrDefault();
            if (txtBusquedaDescProd != null)
            {
                txtBusquedaDescProd.TextChanged += txtFiltroProducto_TextChanged;
            }

        }

        private void txtFiltroProducto_TextChanged(object sender, EventArgs e)
        {
            FiltrarGrillaProductos();
        }

        private void FormPedidos_Load(object sender, EventArgs e)
        {
            CargarProveedores();


            // Deja el comboBox de búsqueda de estado con las opciones "Todos", "EN ESPERA", "RECIBIDO" y "CANCELADO"
            cbBuscarEstado.Items.Clear();
            cbBuscarEstado.Items.Add("Todos");
            cbBuscarEstado.Items.Add("EN ESPERA");
            cbBuscarEstado.Items.Add("RECIBIDO");
            cbBuscarEstado.SelectedIndex = 0; // Selecciona "Todos"

            // Se declara el atributo de tipo List<Proveedor> para poder agregar el primer elemento "Todos" al comboBox de búsqueda de proveedores y luego asignar la lista completa de proveedores a la propiedad DataSource del comboBox
            List<Proveedor> listaBuscarProveedores = _proveedorBusiness.ListarProveedores();
            listaBuscarProveedores.Insert(0, new Proveedor { IdProveedor = 0, NombreProveedor = "Todos" });
            cbBuscarProveedor.DataSource = listaBuscarProveedores;
            cbBuscarProveedor.DisplayMember = "NombreProveedor";
            cbBuscarProveedor.ValueMember = "IdProveedor";
            cbBuscarProveedor.SelectedIndex = 0; // Selecciona "Todos"
            // -------------------------------------

            CargarGrillaPedidos();
            PrepararNuevoPedido();
            FiltrarGrillaProductos();
        }

        // Método para bloquear un CyberTextBox y hacer que se vea deshabilitado para la escritura
        private void BloquearCyberTextBox(ReaLTaiizor.Controls.CyberTextBox control)
        {
            TextBox txtReal = control.Controls.OfType<TextBox>().FirstOrDefault();
            if (txtReal != null)
            {
                txtReal.Enabled = false;
                txtReal.BackColor = SystemColors.Control;
            }
            else
            {
                control.Enabled = false;
            }
        }

        // Método para preparar un nuevo pedido, limpiar campos y obtener el próximo número de pedido
        private void PrepararNuevoPedido()
        {
            idPedidoEnEdicion = 0;
            int proximoNumero = _pedidoBusiness.ObtenerProximoNumeroPedido();
            txtNumeroPedido.TextButton = proximoNumero.ToString("D5");
            totalPedidoActual = 0;
            dgvDetallePedido.Rows.Clear();
            cbProveedor.SelectedIndex = -1;
            dtpFechaEstimadaPedido.Checked = false;
            LimpiarCamposProducto();
        }


        // Método para cargar los proveedores en el comboBox de selección
        private void CargarProveedores()
        {
            cbProveedor.DataSource = _proveedorBusiness.ListarProveedores();
            cbProveedor.DisplayMember = "NombreProveedor";
            cbProveedor.ValueMember = "IdProveedor";
            cbProveedor.SelectedIndex = -1;
        }


        // Método para cargar la grilla de pedidos desde la base de datos
        private void CargarGrillaPedidos()
        {
            dgvListaPedidos.DataSource = _pedidoBusiness.ListarPedidos();
            ActualizarContadorPedidos();
        }

        // Método para actualizar el contador de pedidos en la interfaz
        private void ActualizarContadorPedidos()
        {
            int cantidad = dgvListaPedidos.Rows.Count;
            contadorPedidos.TextButton = cantidad.ToString();
        }

        // Evento del botón "Agregar Producto" para añadir un producto al pedido actual
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(codigoProductoSeleccionado))
            {
                MessageBox.Show("Primero busque y seleccione un producto de la lista superior.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Producto productoReal = _productoBusiness.ObtenerProductoActivo(codigoProductoSeleccionado);

            if (productoReal != null)
            {
                int cantidadIngresada = Convert.ToInt32(numCantidad.Value);
                if (cantidadIngresada <= 0) cantidadIngresada = 1;

                bool existe = false;

                foreach (DataGridViewRow fila in dgvDetallePedido.Rows)
                {
                    if (fila.IsNewRow) continue;

                    if (fila.Cells[0].Value.ToString() == productoReal.IdProducto)
                    {
                        // Reemplazamos la cantidad si el producto ya está en el detalle
                        fila.Cells[3].Value = cantidadIngresada;
                        existe = true;
                        break;
                    }
                }

                if (!existe)
                {
                    decimal precioUnitario = productoReal.PrecioVenta;
                    decimal subtotal = precioUnitario * cantidadIngresada;
                    dgvDetallePedido.Rows.Add(productoReal.IdProducto, productoReal.Descripcion, precioUnitario.ToString("C"), cantidadIngresada, subtotal.ToString("C"), "X");

                    RecalcularTotalPedido();
                }

                LimpiarCamposProducto();
            }
        }

        // Evento del botón "Confirmar Pedido" para registrar el pedido en la base de datos
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cbProveedor.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un Proveedor.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvDetallePedido.Rows.Count == 0 || (dgvDetallePedido.AllowUserToAddRows && dgvDetallePedido.Rows.Count == 1))
            {
                MessageBox.Show("El pedido debe contener al menos un producto.", "Pedido vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<DetallePedido> listaDetalles = new List<DetallePedido>();
            foreach (DataGridViewRow fila in dgvDetallePedido.Rows)
            {
                if (fila.IsNewRow) continue;
                listaDetalles.Add(new DetallePedido()
                {
                    IdProducto = fila.Cells[0].Value.ToString(),
                    Cantidad = Convert.ToInt32(fila.Cells[3].Value),
                    PrecioUnitario = Convert.ToDecimal(fila.Cells[2].Value.ToString().Replace("$", "").Trim()),
                    Subtotal = Convert.ToDecimal(fila.Cells[4].Value.ToString().Replace("$", "").Trim())
                });
            }

            string mensaje = "";

            // Si es 0, es un nuevo registro. Si tiene número, es una modificación.
            if (idPedidoEnEdicion == 0)
            {
                Pedido nuevoPedido = new Pedido()
                {
                    IdProveedor = Convert.ToInt32(cbProveedor.SelectedValue),
                    IdUsuario = Sesion.IdUsuario,
                    TotalPedido = totalPedidoActual,
                    // Si no lo tocan, guarda la fecha y hora actual automáticamente
                    FechaEntrega = dtpFechaEstimadaPedido.Checked ? (DateTime?)dtpFechaEstimadaPedido.Value : DateTime.Now,
                    Detalles = listaDetalles
                };
                mensaje = _pedidoBusiness.RegistrarPedido(nuevoPedido);
            }
            else
            {
                mensaje = _pedidoBusiness.ModificarPedido(idPedidoEnEdicion, totalPedidoActual, listaDetalles);
            }

            MessageBox.Show(mensaje, "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (mensaje.Contains("exitosamente"))
            {
                PrepararNuevoPedido();
                CargarGrillaPedidos();
            }
        }

        // Evento del botón "Cancelar Pedido" para limpiar los campos y preparar un nuevo pedido
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            PrepararNuevoPedido();
        }

        // Método para limpiar los campos relacionados con el producto en la sección de detalle del pedido
        private void LimpiarCamposProducto()
        {
            txtCodigoProductoBuscar.TextButton = "";
            txtDescripcionProductoBuscar.TextButton = "";

            codigoProductoSeleccionado = "";
            txtProductoSeleccionado.TextButton = "";
            numCantidad.Value = 0;

            // Volver a cargar la grilla de búsqueda vacía o completa
            FiltrarGrillaProductos();
        }

        // Evento del botón "Cancelar Producto" para limpiar los campos de producto
        private void btnCancelarProducto_Click(object sender, EventArgs e)
        {
            LimpiarCamposProducto();
        }

        // Evento del DataGridView de detalle del pedido para manejar la eliminación de productos
        private void dgvDetallePedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == dgvDetallePedido.NewRowIndex) return;

            // Si hizo clic en la columna 5 (El botón Eliminar con la "X")
            if (e.ColumnIndex == 5)
            {
                DialogResult respuesta = MessageBox.Show("¿Desea quitar este producto del pedido actual?", "Quitar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    dgvDetallePedido.Rows.RemoveAt(e.RowIndex);
                    RecalcularTotalPedido();
                }
            }
            else
            {
                // Si hizo clic en CUALQUIER OTRA PARTE de la fila (Código, Descripción, etc.)
                DataGridViewRow fila = dgvDetallePedido.Rows[e.RowIndex];

                // Extraemos los datos de esa fila
                string codigo = fila.Cells[0].Value.ToString();
                string descripcion = fila.Cells[1].Value.ToString();
                int cantidadActual = Convert.ToInt32(fila.Cells[3].Value);

                // Subimos los datos al panel de edición superior
                txtCodigoProductoBuscar.TextButton = codigo;
                txtProductoSeleccionado.TextButton = $"{codigo} - {descripcion}";
                numCantidad.Value = cantidadActual;
                codigoProductoSeleccionado = codigo;

                // Ponemos el foco en el número para que el usuario edite rápidamente
                numCantidad.Focus();
            }
        }

        // Evento del DataGridView de lista de pedidos para manejar cambios de estado y detalles
        private void dgvListaPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvListaPedidos.Rows[e.RowIndex];
            int idPedido = Convert.ToInt32(fila.Cells["Numero"].Value);
            string estadoActual = fila.Cells["Estado"].Value.ToString();
            string nombreColumna = dgvListaPedidos.Columns[e.ColumnIndex].Name;

            // CAMBIO DIRECTO A RECIBIDO
            if (nombreColumna == "Estado")
            {
                if (estadoActual == "RECIBIDO")
                {
                    MessageBox.Show("Este pedido ya fue recibido y el stock contabilizado. La acción es irreversible.", "Acción bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult res = MessageBox.Show($"¿Desea marcar el pedido N° {idPedido:D5} como RECIBIDO?\n\nEsta acción sumará automáticamente el stock de los productos y no podrá ser deshecha.", "Confirmar Ingreso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    string mensaje = _pedidoBusiness.CambiarEstado(idPedido, estadoActual, "RECIBIDO");
                    MessageBox.Show(mensaje, "Estado Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrillaPedidos();
                }
            }
            // MODO EDICIÓN (Botón Editar)
            else if (nombreColumna == "Editar")
            {
                if (estadoActual == "RECIBIDO")
                {
                    MessageBox.Show("No se puede editar un pedido que ya fue recibido.", "Edición bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cargamos los datos básicos en la interfaz superior
                idPedidoEnEdicion = Convert.ToInt32(fila.Cells["Numero"].Value);
                txtNumeroPedido.TextButton = idPedidoEnEdicion.ToString("D5");

                string nombreProveedor = fila.Cells["Proveedor"].Value.ToString();
                cbProveedor.SelectedIndex = cbProveedor.FindStringExact(nombreProveedor);

                if (fila.Cells["Fecha_Estimada_Entrega"].Value != DBNull.Value && fila.Cells["Fecha_Estimada_Entrega"].Value != null)
                {
                    dtpFechaEstimadaPedido.Checked = true;
                    dtpFechaEstimadaPedido.Value = Convert.ToDateTime(fila.Cells["Fecha_Estimada_Entrega"].Value);
                }
                else
                {
                    dtpFechaEstimadaPedido.Checked = false;
                }

                // Cargamos los productos en la grilla superior
                dgvDetallePedido.Rows.Clear();
                List<DetallePedido> detalles = _pedidoBusiness.ObtenerDetalles(idPedidoEnEdicion);

                foreach (var item in detalles)
                {
                    dgvDetallePedido.Rows.Add(item.IdProducto, item.DescripcionProducto, item.PrecioUnitario.ToString("C"), item.Cantidad, item.Subtotal.ToString("C"), "X");
                }

                RecalcularTotalPedido();
                MessageBox.Show($"El pedido N° {idPedidoEnEdicion:D5} está listo para ser editado.\nModifique las cantidades directamente en la grilla superior o agregue nuevos productos.", "Modo Edición", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // DESCARGAR DETALLE
            else if (nombreColumna == "Detalles")
            {
                string proveedor = fila.Cells["Proveedor"].Value.ToString();
                SimularDescargaPDF(idPedido, proveedor);
            }
        }

        // Método para descargar PDF
        private void SimularDescargaPDF(int idPedido, string proveedor)
        {
            // Buscamos los detalles reales en la base de datos
            List<DetallePedido> detalles = _pedidoBusiness.ObtenerDetalles(idPedido);

            // Cambiamos la extensión a .html
            string rutaTemporal = Path.Combine(Path.GetTempPath(), $"Pedido_{idPedido}_Detalle.html");

            StringBuilder html = new StringBuilder();

            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html><head><meta charset='utf-8'>");
            html.AppendLine($"<title>Detalle de Pedido N° {idPedido:D5}</title>");

            // Estilos CSS basados en tu diseño
            html.AppendLine("<style>");
            html.AppendLine("body{font-family:Segoe UI,Arial,sans-serif;margin:30px;color:#333;background:#fff;}");
            html.AppendLine(".header{text-align:center;border-bottom:3px solid #ff7b7b;padding-bottom:15px;margin-bottom:20px;}");
            html.AppendLine(".header h1{color:#d9534f;margin:0;font-size:26px;}");
            html.AppendLine(".header h3{color:#555;margin:5px 0 0;font-weight:normal;}");
            html.AppendLine(".info{display:flex;justify-content:space-between;background:#fff5f5;padding:12px 20px;margin-bottom:25px;border:1px solid #ffe0e0;}");
            html.AppendLine("table{width:100%;border-collapse:collapse;margin-top:10px;}");
            html.AppendLine("th,td{border:1px solid #e0e0e0;padding:10px;text-align:left;font-size:13px;}");
            html.AppendLine("th{background:#ff9999;color:white;font-weight:bold;}");
            html.AppendLine("tr:nth-child(even){background:#fcfcfc;}");
            html.AppendLine(".footer{margin-top:40px;font-size:11px;text-align:center;color:#888;border-top:1px solid #eee;padding-top:15px;}");
            html.AppendLine("</style></head><body>");

            string usuarioHtml = System.Net.WebUtility.HtmlEncode(Sesion.NombreCompleto ?? Sesion.NombreUsuario ?? "");
            string proveedorHtml = System.Net.WebUtility.HtmlEncode(proveedor);

            // Cabecera
            html.AppendLine("<div class='header'>");
            html.AppendLine("<h1>SISTEMA JUGUETERÍA</h1>");
            html.AppendLine($"<h3>Comprobante de Detalle de Pedido</h3>");
            html.AppendLine("</div>");

            // Panel de Información
            html.AppendLine("<div class='info'>");
            html.AppendLine("<div>");
            html.AppendLine($"<p><strong>N.º de Pedido:</strong> {idPedido:D5}</p>");
            html.AppendLine($"<p><strong>Fecha de Descarga:</strong> {DateTime.Now:dd/MM/yyyy HH:mm}</p>");
            html.AppendLine("</div><div>");
            html.AppendLine($"<p><strong>Proveedor:</strong> {proveedorHtml}</p>");
            html.AppendLine($"<p><strong>Generado por:</strong> {usuarioHtml}</p>");
            html.AppendLine("</div></div>");

            // Tabla de Productos
            if (detalles.Count > 0)
            {
                html.AppendLine("<table><thead><tr>");
                html.AppendLine("<th>Código</th>");
                html.AppendLine("<th>Producto</th>");
                html.AppendLine("<th>Cantidad</th>");
                html.AppendLine("<th>Precio Unitario</th>");
                html.AppendLine("<th>Subtotal</th>");
                html.AppendLine("</tr></thead><tbody>");

                decimal totalGasto = 0;

                foreach (var item in detalles)
                {
                    html.AppendLine("<tr>");
                    html.AppendLine($"<td>{System.Net.WebUtility.HtmlEncode(item.IdProducto)}</td>");
                    html.AppendLine($"<td>{System.Net.WebUtility.HtmlEncode(item.DescripcionProducto)}</td>");
                    html.AppendLine($"<td>{item.Cantidad}</td>");
                    html.AppendLine($"<td>{item.PrecioUnitario:C}</td>");
                    html.AppendLine($"<td>{item.Subtotal:C}</td>");
                    html.AppendLine("</tr>");

                    totalGasto += item.Subtotal;
                }

                // Fila extra para mostrar el Total del Pedido
                html.AppendLine("<tr>");
                html.AppendLine("<td colspan='4' style='text-align:right;'><strong>TOTAL DEL PEDIDO:</strong></td>");
                html.AppendLine($"<td><strong style='color:#d9534f;'>{totalGasto:C}</strong></td>");
                html.AppendLine("</tr>");

                html.AppendLine("</tbody></table>");
            }
            else
            {
                html.AppendLine("<p style='text-align:center;padding:20px;color:#666;'>No hay productos registrados en este pedido.</p>");
            }

            // Pie de página
            html.AppendLine("<div class='footer'>");
            html.AppendLine("<p>Documento generado desde el Sistema de Gestión de Juguetería.</p>");
            html.AppendLine("</div>");
            html.AppendLine("</body></html>");

            // Escribimos el archivo en los temporales de Windows con codificación UTF8
            File.WriteAllText(rutaTemporal, html.ToString(), new UTF8Encoding(true));

            MessageBox.Show($"Descargando comprobante para el pedido N° {idPedido:D5}...", "Descarga completada", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Lo abrimos automáticamente con el navegador web predeterminado
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(rutaTemporal) { UseShellExecute = true });
        }

        // Método para filtrar la grilla de pedidos según los criterios de busqueda seleccionados por el usuario
        private void FiltrarGrilla()
        {
            // Obtenemos los datos que ya están en la grilla (evita consultar a la BD en cada tecla)
            DataTable dtPedidos = dgvListaPedidos.DataSource as DataTable;
            if (dtPedidos == null) return;

            List<string> filtros = new List<string>();

            // FILTRO 1: N° Pedido (Búsqueda parcial con LIKE para que filtre mientras el usuario escribe)
            string textoNumero = txtNumeroPedidoBuscar.TextButton.Trim();
            if (!string.IsNullOrWhiteSpace(textoNumero))
            {
                filtros.Add($"Convert(Numero, 'System.String') LIKE '%{textoNumero}%'");
            }

            // FILTRO 2: Proveedor
            if (cbBuscarProveedor.SelectedIndex > 0) // El índice 0 será "Todos"
            {
                filtros.Add($"Proveedor = '{cbBuscarProveedor.Text}'");
            }

            // FILTRO 3: Estado
            if (cbBuscarEstado.SelectedIndex > 0) // El índice 0 será "Todos"
            {
                filtros.Add($"Estado = '{cbBuscarEstado.Text}'");
            }

            // Unimos los filtros y los aplicamos
            string filtroFinal = string.Join(" AND ", filtros);
            dtPedidos.DefaultView.RowFilter = filtroFinal;

            ActualizarContadorPedidos();
        }

        // Evento para formatear las celdas del DataGridView de lista de pedidos, incluyendo el formato del número de pedido y los colores según el estado

        private void dgvListaPedidos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // --- NUEVO BLOQUE PARA FORMATEAR EL NÚMERO CON CEROS ---
            if (dgvListaPedidos.Columns[e.ColumnIndex].Name == "Numero" && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int numeroPedido))
                {
                    e.Value = numeroPedido.ToString("D5");
                    e.FormattingApplied = true;
                }
            }

            if (dgvListaPedidos.Columns[e.ColumnIndex].Name == "Estado" && e.Value != null)
            {
                string estado = e.Value.ToString();

                if (estado == "RECIBIDO")
                {
                    e.CellStyle.BackColor = Color.MediumSeaGreen;
                    e.CellStyle.ForeColor = Color.White;
                }
                else
                {
                    e.CellStyle.BackColor = Color.LightGray;
                    e.CellStyle.ForeColor = Color.Black;
                }
            }
        }


        // EVENTOS CONECTADOS AL FILTRADO DINÁMICO:
        private void txtNumeroPedidoBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarGrilla();
        }

        private void cbBuscarEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarGrilla();
        }

        private void cbBuscarProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarGrilla();
        }

        // Eventos vacíos auto-generados por el diseñador
        private void label2_Click(object sender, EventArgs e) { }
        private void hopeTextBox3_Click(object sender, EventArgs e) { }
        private void panel1_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void panel3_Click(object sender, EventArgs e) { }
        private void cbProveedor_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cyberButton1_Click(object sender, EventArgs e) { LimpiarCamposProducto(); }
        private void label2_Click_1(object sender, EventArgs e) { }
        private void cyberComboBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        // Evento para cambiar el cursor a una manito cuando el mouse pasa sobre las columnas "Estado" o "Detalles" del DataGridView de lista de pedidos
        private void dgvListaPedidos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que no estemos en los títulos de las columnas (RowIndex < 0)
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtenemos el nombre de la columna por la que está pasando el mouse
                string nombreColumna = dgvListaPedidos.Columns[e.ColumnIndex].Name;

                // Si es la columna Estado, cambiamos el cursor a la manito
                if (nombreColumna == "Estado" || nombreColumna == "Detalles" || nombreColumna == "Editar")
                {
                    dgvListaPedidos.Cursor = Cursors.Hand;
                }
                else
                {
                    // Si es otra columna, lo dejamos normal
                    dgvListaPedidos.Cursor = Cursors.Default;
                }
            }
        }

        private void dgvListaPedidos_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            // Cuando el mouse sale de la celda, devolvemos el cursor a la normalidad
            dgvListaPedidos.Cursor = Cursors.Default;
        }

        // EVENTO QUE DETECTA CUANDO SE ESCRIBE UNA NUEVA CANTIDAD EN LA GRILLA
        private void dgvDetallePedido_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Si se modificó la columna Cantidad (índice 3)
            if (e.ColumnIndex == 3)
            {
                DataGridViewRow fila = dgvDetallePedido.Rows[e.RowIndex];

                if (int.TryParse(fila.Cells[3].Value?.ToString(), out int nuevaCantidad) && nuevaCantidad > 0)
                {
                    decimal precioUnitario = Convert.ToDecimal(fila.Cells[2].Value.ToString().Replace("$", "").Trim());
                    decimal nuevoSubtotal = precioUnitario * nuevaCantidad;

                    fila.Cells[4].Value = nuevoSubtotal.ToString("C"); // Actualiza Subtotal de esa fila
                    RecalcularTotalPedido(); // Recalcula el gran total
                }
                else
                {
                    MessageBox.Show("La cantidad debe ser un número entero mayor a 0.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    fila.Cells[3].Value = 1; // Reseteamos a 1 para evitar errores
                }
            }
        }

        // 3. RECALCULA EL TOTAL GENERAL SUMANDO TODOS LOS SUBTOTALES
        private void RecalcularTotalPedido()
        {
            totalPedidoActual = 0;
            foreach (DataGridViewRow fila in dgvDetallePedido.Rows)
            {
                if (fila.IsNewRow) continue;
                decimal subtotal = Convert.ToDecimal(fila.Cells[4].Value.ToString().Replace("$", "").Trim());
                totalPedidoActual += subtotal;
            }
        }

        private void FiltrarGrillaProductos()
        {
            string codigo = txtCodigoProductoBuscar.TextButton.Trim();
            string descripcion = txtDescripcionProductoBuscar.TextButton.Trim();

            DataTable dtProductos = _productoBusiness.ListarProductos(false); // Trae solo activos

            if (dtProductos != null)
            {
                List<string> filtros = new List<string>();

                if (!string.IsNullOrWhiteSpace(codigo))
                {
                    // Usamos el alias 'Codigo' definido en el SQL
                    filtros.Add($"Codigo LIKE '%{codigo}%'");
                }
                if (!string.IsNullOrWhiteSpace(descripcion))
                {
                    // Usamos el alias 'Descripcion' definido en el SQL
                    filtros.Add($"Descripcion LIKE '%{descripcion}%'");
                }

                string filtroFinal = string.Join(" AND ", filtros);
                dtProductos.DefaultView.RowFilter = filtroFinal;

                dgvBuscarProducto.DataSource = dtProductos;
            }
        }

        private void dgvBuscarProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignora los clics en los encabezados o en la fila en blanco de creación
            if (e.RowIndex < 0 || e.RowIndex == dgvBuscarProducto.NewRowIndex) return;

            string nombreColumna = dgvBuscarProducto.Columns[e.ColumnIndex].Name;

            if (nombreColumna == "Seleccionar")
            {
                DataGridViewRow fila = dgvBuscarProducto.Rows[e.RowIndex];

                DataRowView filaDatos = fila.DataBoundItem as DataRowView;

                if (filaDatos != null)
                {
                    // Extraemos usando los Alias EXACTOS de la base de datos
                    string codigo = filaDatos["Codigo"].ToString();
                    string descripcion = filaDatos["Descripcion"].ToString();

                    // Guardamos la selección
                    codigoProductoSeleccionado = codigo;
                    txtProductoSeleccionado.TextButton = $"{codigo} - {descripcion}";

                    // Movemos el foco
                    numCantidad.Focus();
                }
                else
                {
                    MessageBox.Show("No se pudieron leer los datos del producto.", "Error de lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}