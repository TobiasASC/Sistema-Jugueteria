using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SistemaJugueteria.Presentacion.Utilidades;
using SistemaJugueteria.Business;
using SistemaJugueteria.Entities;

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
            dgvListaPedidos.CellFormatting += dgvListaPedidos_CellFormatting;

            // Conectar el evento TextChanged del CyberTextBox por código:
            TextBox txtBusqueda = txtNumeroPedidoBuscar.Controls.OfType<TextBox>().FirstOrDefault();
            if (txtBusqueda != null)
            {
                txtBusqueda.TextChanged += txtNumeroPedidoBuscar_TextChanged;
            }

            dgvDetallePedido.CellValueChanged += dgvDetallePedido_CellValueChanged;

        }

        private void FormPedidos_Load(object sender, EventArgs e)
        {
            CargarProveedores();

            ConfigurarAutocompletado();

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
            string codigo = txtCodigoProducto.TextButton;
            string productoIdentificado = txtProductoSeleccionado.TextButton;

            if (string.IsNullOrWhiteSpace(codigo) || string.IsNullOrWhiteSpace(productoIdentificado))
            {
                MessageBox.Show("Primero busque o seleccione un producto válido.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Producto productoReal = _productoBusiness.ObtenerProductoActivo(codigo);

            if (productoReal != null)
            {
                int cantidadIngresada = Convert.ToInt32(numCantidad.Value);
                if (cantidadIngresada <= 0) cantidadIngresada = 1;

                bool existe = false;

                // Recorremos la grilla para ver si el producto ya está cargado
                foreach (DataGridViewRow fila in dgvDetallePedido.Rows)
                {
                    if (fila.IsNewRow) continue;

                    if (fila.Cells[0].Value.ToString() == productoReal.IdProducto)
                    {
                        // IMPORTANTE: REEMPLAZAMOS LA CANTIDAD EN LUGAR DE SUMARLA
                        fila.Cells[3].Value = cantidadIngresada;

                        // NOTA: Al modificar Cells[3].Value aquí, el evento "CellValueChanged" que programamos antes 
                        // se disparará solo y actualizará el Subtotal de la fila y el Total General automáticamente.

                        existe = true;
                        break; // Detenemos la búsqueda
                    }
                }

                // Si el producto no estaba en la grilla, lo agregamos como una fila nueva
                if (!existe)
                {
                    decimal precioUnitario = productoReal.PrecioVenta;
                    decimal subtotal = precioUnitario * cantidadIngresada;
                    dgvDetallePedido.Rows.Add(productoReal.IdProducto, productoReal.Descripcion, precioUnitario.ToString("C"), cantidadIngresada, subtotal.ToString("C"), "X");

                    // Recalculamos el total porque agregamos una fila nueva
                    RecalcularTotalPedido();
                }

                // Limpiamos los campos para el próximo producto
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
                    FechaEntrega = dtpFechaEstimadaPedido.Checked ? (DateTime?)dtpFechaEstimadaPedido.Value : null,
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
            txtCodigoProducto.TextButton = "";
            txtDescripcionPedido.TextButton = "";
            numCantidad.Value = 0;
            txtProductoSeleccionado.TextButton = "";
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
                txtCodigoProducto.TextButton = codigo;
                txtProductoSeleccionado.TextButton = $"{codigo} - {descripcion}";
                numCantidad.Value = cantidadActual;

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

            // 1. CAMBIO DIRECTO A RECIBIDO
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
            // 2. MODO EDICIÓN (Botón Editar)
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
            // 3. DESCARGAR DETALLE
            else if (nombreColumna == "Detalles")
            {
                string proveedor = fila.Cells["Proveedor"].Value.ToString();
                SimularDescargaPDF(idPedido, proveedor);
            }
        }

        // Método para simular la descarga de un comprobante en formato PDF (en realidad es un archivo de texto) con los detalles del pedido
        private void SimularDescargaPDF(int idPedido, string proveedor)
        {
            // Buscamos los detalles reales en la base de datos
            List<DetallePedido> detalles = _pedidoBusiness.ObtenerDetalles(idPedido);

            // Construimos la lista de productos como texto
            string listaProductosTexto = "";
            if (detalles.Count > 0)
            {
                foreach (var item in detalles)
                {
                    // Agregamos cada producto con su cantidad
                    listaProductosTexto += $"- {item.DescripcionProducto} x {item.Cantidad} unidades\n";
                }
            }
            else
            {
                listaProductosTexto = "- (No hay productos registrados en este pedido)\n";
            }

            // 3. Armamos el comprobante con el formato exacto solicitado
            string rutaTemporal = Path.Combine(Path.GetTempPath(), $"Pedido_{idPedido}_Detalle.txt");
            string contenidoPDF = $@"==========================================" + "\n" +
                                   $"    COMPROBANTE DE DETALLE DE PEDIDO     " + "\n" +
                                   $"==========================================" + "\n" +
                                   $"Número de Pedido: {idPedido:D5}\n" +
                                   $"Proveedor: {proveedor}\n" +
                                   $"Fecha de Descarga: {DateTime.Now:dd/MM/yyyy HH:mm}\n" +
                                   $"------------------------------------------\n" +
                                   $"[DETALLES DEL PEDIDO SOLICITADO]\n" +
                                   listaProductosTexto +
                                   $"==========================================";

            // Escribimos el archivo en los temporales de Windows
            File.WriteAllText(rutaTemporal, contenidoPDF);

            MessageBox.Show($"Descargando comprobante para el pedido N° {idPedido:D5}...", "Descarga completada", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Lo abrimos automáticamente con el bloc de notas
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

        // Evento del botón de búsqueda de producto (lupa) para obtener el producto activo desde la base de datos
        private void btnBuscarProductoLupa_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigoProducto.TextButton.Trim();
            string descripcion = txtDescripcionPedido.TextButton.Trim();

            // Validamos que al menos uno de los dos campos tenga datos
            if (string.IsNullOrWhiteSpace(codigo) && string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show("Por favor, ingrese un código o una descripción para buscar el producto.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Producto productoReal = null;

            // 1. Priorizamos la búsqueda por Código
            if (!string.IsNullOrWhiteSpace(codigo))
            {
                productoReal = _productoBusiness.ObtenerProductoActivo(codigo);
            }
            // 2. Si no hay código, buscamos por la Descripción ingresada
            else if (!string.IsNullOrWhiteSpace(descripcion))
            {
                productoReal = _productoBusiness.ObtenerProductoActivoPorDescripcion(descripcion);
            }

            if (productoReal == null)
            {
                MessageBox.Show("El producto no existe o se encuentra inactivo.", "Producto no disponible", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProductoSeleccionado.TextButton = "";
            }
            else
            {
                // AUTOCOMPLETAMOS LA INTERFAZ: Llenamos el dato que el usuario NO escribió
                txtCodigoProducto.TextButton = productoReal.IdProducto;
                txtDescripcionPedido.TextButton = productoReal.Descripcion;

                // Mostramos el formato final solicitado (CODIGO - DESCRIPCION)
                txtProductoSeleccionado.TextButton = $"{productoReal.IdProducto} - {productoReal.Descripcion}";

                // Movemos el cursor a la cantidad para agilizar la carga
                numCantidad.Focus();
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

        private void ConfigurarAutocompletado()
        {
            List<Producto> productosActivos = _productoBusiness.ListarProductosParaSugerencias();

            AutoCompleteStringCollection codigos = new AutoCompleteStringCollection();
            AutoCompleteStringCollection descripciones = new AutoCompleteStringCollection();

            foreach (Producto p in productosActivos)
            {
                codigos.Add(p.IdProducto);
                descripciones.Add(p.Descripcion);
            }

            // Aplicamos autocompletado al Código
            TextBox txtCod = txtCodigoProducto.Controls.OfType<TextBox>().FirstOrDefault();
            if (txtCod != null)
            {
                txtCod.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtCod.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtCod.AutoCompleteCustomSource = codigos;
            }

            // Aplicamos autocompletado a la Descripción
            TextBox txtDesc = txtDescripcionPedido.Controls.OfType<TextBox>().FirstOrDefault();
            if (txtDesc != null)
            {
                txtDesc.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtDesc.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtDesc.AutoCompleteCustomSource = descripciones;
            }
        }

        // 2. EVENTO QUE DETECTA CUANDO SE ESCRIBE UNA NUEVA CANTIDAD EN LA GRILLA
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


    }
}