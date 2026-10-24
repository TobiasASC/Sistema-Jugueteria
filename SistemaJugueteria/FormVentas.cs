using Microsoft.Data.SqlClient;
using SistemaJugueteria.Business;
using SistemaJugueteria.Data;
using SistemaJugueteria.Entities;
using SistemaJugueteria.Presentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaJugueteria
{
    public partial class FormVentas : Form
    {
        private System.Windows.Forms.Timer timerReloj;

        // Instancias de Negocio
        private readonly SocioBusiness negocioSocio = new SocioBusiness();
        private readonly ProductoBusiness negocioProducto = new ProductoBusiness();
        private readonly VentaBusiness negocioVenta = new VentaBusiness();

        private int idSocioSeleccionado = 0;
        private bool usarPuntosSeleccionado = false;

        // Selección del producto
        private string codigoSeleccionado = "";
        private string descripcionSeleccionada = "";
        private decimal precioSeleccionado = 0m;

        // Identificadores de selección (se usan IDs/códigos, no índices de fila).
        private int? idSocioSeleccionadoEnGrilla = null;
        private string codigoProductoSeleccionadoEnGrilla = "";

        public FormVentas()
        {
            InitializeComponent();
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            AsignarTextoControl("cyberTextBox1", Sesion.Dni);
            AsignarTextoControl("cyberTextBox2", Sesion.NombreCompleto);
            CargarSiguienteNumeroFactura();

            timerReloj = new System.Windows.Forms.Timer();
            timerReloj.Interval = 1000;
            timerReloj.Tick += TimerReloj_Tick;
            timerReloj.Start();
            ActualizarFechaHora();

            BloquearControl("cyberTextBox1");
            BloquearControl("cyberTextBox2");
            BloquearControl("cyberTextBox3");
            BloquearControl("cyberTextBox4");
            BloquearControl("cyberTextBox5");
            BloquearControl("cyberTextBox7");
            BloquearControl("cyberTextBox8");
            BloquearControl("cyberTextBox11"); 
            BloquearControl("cyberTextBox12");
            BloquearControl("cyberTextBox13");

            AsignarTextoControl("cyberTextBox13", "$ 0,00");

            ConfigurarGrillaClientes();
            ConfigurarGrillaBuscarProductos();
            ConfigurarGrillaVentaDetalle();
            ConfigurarRestriccionesTeclado();
            ConfigurarBuscadoresDinamicos();
            ConfigurarControlCantidad();
            VincularEventosBotones();
            ActualizarEstadoBotonPuntos();
        }

        private void TimerReloj_Tick(object? sender, EventArgs e)
        {
            ActualizarFechaHora();
        }

        private void ActualizarFechaHora()
        {
            AsignarTextoControl("cyberTextBox4", DateTime.Now.ToString("dd/MM/yyyy"));
            AsignarTextoControl("cyberTextBox5", DateTime.Now.ToString("HH:mm:ss"));
        }

        private void CargarSiguienteNumeroFactura()
        {
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    const string query = "SELECT ISNULL(MAX(id_venta), 0) + 1 FROM Venta";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        object resultado = cmd.ExecuteScalar();
                        int siguienteId = resultado != null && resultado != DBNull.Value
                            ? Convert.ToInt32(resultado)
                            : 1;

                        AsignarTextoControl("cyberTextBox3", siguienteId.ToString("D8"));
                    }
                }
            }
            catch
            {
                // Valor visual de respaldo; el ID real lo devuelve RegistrarVenta.
                AsignarTextoControl("cyberTextBox3", "00000001");
            }
        }

        // --- ESTILO NEUTRO DE GRILLAS ---
        private void AplicarEstiloNeutroGrilla(DataGridView dgv)
        {
            Color colorSeleccion = Color.FromArgb(220, 220, 220);
            Color colorEncabezado = Color.FromArgb(240, 240, 240);

            dgv.EnableHeadersVisualStyles = false;
            dgv.BackgroundColor = Color.White;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;

            dgv.DefaultCellStyle.SelectionBackColor = colorSeleccion;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = colorEncabezado;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = colorEncabezado;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.RowHeadersDefaultCellStyle.BackColor = colorEncabezado;
            dgv.RowHeadersDefaultCellStyle.SelectionBackColor = colorSeleccion;

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.HeaderCell.Style.BackColor = colorEncabezado;
                col.HeaderCell.Style.ForeColor = Color.Black;
                col.HeaderCell.Style.SelectionBackColor = colorEncabezado;
                col.HeaderCell.Style.SelectionForeColor = Color.Black;
                col.DefaultCellStyle.SelectionBackColor = colorSeleccion;
                col.DefaultCellStyle.SelectionForeColor = Color.Black;
            }
        }

        // --- GRILLA DE CLIENTES ---
        private void ConfigurarGrillaClientes()
        {
            dataGridView2.AutoGenerateColumns = false;

            if (!dataGridView2.Columns.Contains("colSeleccionarCliente"))
            {
                DataGridViewButtonColumn btnSeleccionar = new DataGridViewButtonColumn
                {
                    Name = "colSeleccionarCliente",
                    HeaderText = "",
                    Text = "Seleccionar",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };
                dataGridView2.Columns.Add(btnSeleccionar);
            }

            AplicarEstiloNeutroGrilla(dataGridView2);
            dataGridView2.CellContentClick -= dataGridView2_CellContentClick;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            CargarSocio("");
        }

        private void CargarSocio(string filtroDni)
        {
            dataGridView2.Rows.Clear();

            try
            {
                List<Socio> lista = negocioSocio.ListarSocios();

                if (!string.IsNullOrWhiteSpace(filtroDni))
                {
                    lista = lista
                        .Where(s => (s.DniSocio ?? "").Contains(filtroDni))
                        .ToList();
                }

                foreach (Socio socio in lista)
                {
                    int index = dataGridView2.Rows.Add(
                        socio.DniSocio,
                        $"{socio.NombreSocio} {socio.ApellidoSocio}",
                        socio.DireccionSocio,
                        socio.CorreoSocio,
                        socio.PuntosAcumulados
                    );

                    dataGridView2.Rows[index].Tag = socio;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al cargar socios: " + ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dataGridView2.Columns[e.ColumnIndex].Name != "colSeleccionarCliente")
                return;

            DataGridViewRow fila = dataGridView2.Rows[e.RowIndex];
            if (fila.Tag is not Socio socio)
                return;

            // Pulsar el mismo cliente otra vez lo deselecciona.
            if (idSocioSeleccionado == socio.IdSocio)
            {
                LimpiarSeleccionCliente();
                return;
            }

            idSocioSeleccionado = socio.IdSocio;
            idSocioSeleccionadoEnGrilla = socio.IdSocio;

            AsignarTextoControl("cyberTextBox6", socio.DniSocio);
            AsignarTextoControl("cyberTextBox7", $"{socio.NombreSocio} {socio.ApellidoSocio}");
            AsignarTextoControl("cyberTextBox8", socio.PuntosAcumulados.ToString());

            // Cambiar de cliente cancela cualquier canje que estuviera activado.
            usarPuntosSeleccionado = false;
            ActualizarEstadoBotonPuntos();
            CalcularTotalVenta();
        }

        private void LimpiarSeleccionCliente()
        {
            idSocioSeleccionado = 0;
            idSocioSeleccionadoEnGrilla = null;
            usarPuntosSeleccionado = false;

            AsignarTextoControl("cyberTextBox6", "");
            AsignarTextoControl("cyberTextBox7", "");
            AsignarTextoControl("cyberTextBox8", "");

            ActualizarEstadoBotonPuntos();
            CalcularTotalVenta();
        }

        // Detecta Consumidor Final por el nombre visible.
        // Si en la BD se identifica por un ID o campo específico, conviene reemplazarlo por esa regla.
        private bool EsConsumidorFinal()
        {
            string nombre = ObtenerTextoControl("cyberTextBox7").Trim();
            return nombre.Equals("Consumidor Final", StringComparison.OrdinalIgnoreCase);
        }

        // --- GRILLA DE BÚSQUEDA DE PRODUCTOS ---
        private void ConfigurarGrillaBuscarProductos()
        {
            dataGridView3.AutoGenerateColumns = false;

            if (!dataGridView3.Columns.Contains("colSeleccionar"))
            {
                DataGridViewButtonColumn btnSeleccionar = new DataGridViewButtonColumn
                {
                    Name = "colSeleccionar",
                    HeaderText = "",
                    Text = "Seleccionar",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };
                dataGridView3.Columns.Add(btnSeleccionar);
            }

            AplicarEstiloNeutroGrilla(dataGridView3);
            dataGridView3.CellContentClick -= dataGridView3_CellContentClick;
            dataGridView3.CellContentClick += dataGridView3_CellContentClick;
            CargarDatosGrillaProductos("");
        }

        private void CargarDatosGrillaProductos(string filtro)
        {
            dataGridView3.Rows.Clear();

            try
            {
                object resultado = negocioProducto.ListarProductos(false);
                DataTable? dt = resultado as DataTable;

                if (dt == null)
                    return;

                foreach (DataRow row in dt.Rows)
                {
                    string codigo = row["Codigo"]?.ToString() ?? "";
                    string desc = row["Descripcion"]?.ToString() ?? "";
                    string categoria = row["Categoria"]?.ToString() ?? "-";
                    string precio = row["Precio"]?.ToString() ?? "0";

                    bool coincide = string.IsNullOrWhiteSpace(filtro) ||
                        codigo.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        desc.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0;

                    if (!coincide)
                        continue;

                    int index = dataGridView3.Rows.Add(codigo, desc, categoria, precio);
                    dataGridView3.Rows[index].Tag = row;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al cargar productos: " + ex.Message);
            }
        }

        private void dataGridView3_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dataGridView3.Columns[e.ColumnIndex].Name != "colSeleccionar")
                return;

            DataGridViewRow fila = dataGridView3.Rows[e.RowIndex];
            if (fila.Tag is not DataRow dr)
                return;

            string codigo = dr["Codigo"]?.ToString() ?? "";

            // Pulsar el mismo producto otra vez lo deselecciona.
            if (codigoSeleccionado == codigo &&
                codigoProductoSeleccionadoEnGrilla == codigo)
            {
                ResetearSeleccionProducto();
                return;
            }

            string descripcion = dr["Descripcion"]?.ToString() ?? "";

            if (!TryConvertirPrecio(dr["Precio"], out decimal precio) || precio <= 0m)
            {
                MessageBox.Show(
                    "El producto seleccionado no tiene un precio válido.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                ResetearSeleccionProducto();
                return;
            }

            codigoSeleccionado = codigo;
            codigoProductoSeleccionadoEnGrilla = codigo;
            descripcionSeleccionada = descripcion;
            precioSeleccionado = precio;

            AsignarTextoControl("cyberTextBox10", codigoSeleccionado);
            AsignarTextoControl("cyberTextBox9", descripcionSeleccionada);
            AsignarTextoControl("cyberTextBox12", descripcionSeleccionada);
            AsignarTextoControl("cyberTextBox11", precioSeleccionado.ToString("N2"));
        }

        private bool TryConvertirPrecio(object? valor, out decimal precio)
        {
            string texto = Convert.ToString(valor, CultureInfo.InvariantCulture) ?? "0";

            if (decimal.TryParse(texto, NumberStyles.Any, CultureInfo.InvariantCulture, out precio))
                return true;

            return decimal.TryParse(texto, NumberStyles.Any, new CultureInfo("es-AR"), out precio);
        }

        private void ResetearSeleccionProducto()
        {
            codigoSeleccionado = "";
            codigoProductoSeleccionadoEnGrilla = "";
            descripcionSeleccionada = "";
            precioSeleccionado = 0m;

            AsignarTextoControl("cyberTextBox10", "");
            AsignarTextoControl("cyberTextBox9", "");
            AsignarTextoControl("cyberTextBox12", "");
            AsignarTextoControl("cyberTextBox11", "");
        }

        // --- GRILLA DEL DETALLE DE VENTA ---
        private void ConfigurarGrillaVentaDetalle()
        {
            if (dataGridView1.Columns.Contains("PrecioColum"))
            {
                dataGridView1.Columns["PrecioColum"]
                    .DefaultCellStyle.Format = "C2";
            }

            if (dataGridView1.Columns.Contains("SubtotalColum"))
            {
                dataGridView1.Columns["SubtotalColum"]
                    .DefaultCellStyle.Format = "C2";
            }

            AplicarEstiloNeutroGrilla(dataGridView1);

            dataGridView1.CellContentClick -= dataGridView1_CellContentClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }

        private void dataGridView1_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "colEliminar" &&
                !dataGridView1.Rows[e.RowIndex].IsNewRow)
            {
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                CalcularTotalVenta();
            }
        }

        // --- BUSCADORES DINÁMICOS ---
        private void ConfigurarBuscadoresDinamicos()
        {
            Control[] ctrlDni = Controls.Find("cyberTextBox6", true);
            if (ctrlDni.Length > 0)
            {
                TextBox? txtDni = ctrlDni[0].Controls.OfType<TextBox>().FirstOrDefault();
                if (txtDni != null)
                {
                    txtDni.MaxLength = 8;
                    txtDni.TextChanged += (s, e) => CargarSocio(txtDni.Text.Trim());
                }
            }

            Control[] ctrlCod = Controls.Find("cyberTextBox10", true);
            if (ctrlCod.Length > 0)
            {
                TextBox? txtCod = ctrlCod[0].Controls.OfType<TextBox>().FirstOrDefault();
                if (txtCod != null)
                    txtCod.TextChanged += (s, e) => CargarDatosGrillaProductos(txtCod.Text.Trim());
            }

            Control[] ctrlDesc = Controls.Find("cyberTextBox9", true);
            if (ctrlDesc.Length > 0)
            {
                TextBox? txtDesc = ctrlDesc[0].Controls.OfType<TextBox>().FirstOrDefault();
                if (txtDesc != null)
                    txtDesc.TextChanged += (s, e) => CargarDatosGrillaProductos(txtDesc.Text.Trim());
            }
        }

        private void ConfigurarControlCantidad()
        {
            foreach (Control ctrl in GetAllControls(this))
            {
                if (ctrl is NumericUpDown cantidad)
                {
                    cantidad.Minimum = 1;
                    cantidad.Maximum = 1000;
                    cantidad.DecimalPlaces = 0;
                    cantidad.Increment = 1;
                    cantidad.ReadOnly = false;
                    cantidad.TextAlign = HorizontalAlignment.Center;
                }
            }
        }

        // --- AGREGAR PRODUCTO ---

        private void cyberButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(codigoSeleccionado) ||
                precioSeleccionado <= 0m)
            {
                MessageBox.Show(
                    "Seleccione un producto válido de la lista para agregarlo.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            int cantidad = ObtenerCantidadSeleccionada();

            if (cantidad <= 0)
            {
                MessageBox.Show(
                    "La cantidad debe ser mayor que cero.",
                    "Cantidad inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string categoriaProducto = "-";

            // Buscar la categoría del producto seleccionado.
            foreach (DataGridViewRow rowBuscador in dataGridView3.Rows)
            {
                if (!rowBuscador.IsNewRow &&
                    rowBuscador.Cells[0].Value?.ToString() == codigoSeleccionado)
                {
                    categoriaProducto =
                        rowBuscador.Cells[2].Value?.ToString() ?? "-";
                    break;
                }
            }

            DataGridViewRow filaExistente = null;

            // Comprobar si el producto ya está agregado a la venta.
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string codigoFila =
                    row.Cells["ColumCodigo"].Value?.ToString() ?? "";

                if (codigoFila == codigoSeleccionado)
                {
                    filaExistente = row;
                    break;
                }
            }

            if (filaExistente != null)
            {
                // El producto ya existe: sumar la cantidad.
                int cantidadAnterior = Convert.ToInt32(
                    filaExistente.Cells["CantidadColum"].Value
                );

                int cantidadNueva;

                try
                {
                    cantidadNueva = checked(cantidadAnterior + cantidad);
                }
                catch (OverflowException)
                {
                    MessageBox.Show(
                        "La cantidad ingresada es demasiado grande.",
                        "Cantidad inválida",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                decimal nuevoSubtotal = precioSeleccionado * cantidadNueva;

                filaExistente.Cells["CantidadColum"].Value = cantidadNueva;
                filaExistente.Cells["PrecioColum"].Value = precioSeleccionado;
                filaExistente.Cells["SubtotalColum"].Value = nuevoSubtotal;
            }
            else
            {
                // Es un producto nuevo: agregar una fila.
                dataGridView1.Rows.Add(
                    codigoSeleccionado,
                    descripcionSeleccionada,
                    categoriaProducto,
                    cantidad,
                    precioSeleccionado,
                    precioSeleccionado * cantidad,
                    "X"
                );
            }

            // Recalcular el total y limpiar la selección del producto.
            CalcularTotalVenta();
            ResetearSeleccionProducto();
            ResetearCantidad();
        }


        // --- CANJE DE PUNTOS ---
        private void cyberButton4_Click(object sender, EventArgs e)
        {
            if (idSocioSeleccionado <= 0 || EsConsumidorFinal())
            {
                MessageBox.Show(
                    "Consumidor Final no puede utilizar puntos. Seleccione un cliente registrado.",
                    "Canje no disponible",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                usarPuntosSeleccionado = false;
                ActualizarEstadoBotonPuntos();
                CalcularTotalVenta();
                return;
            }

            if (!int.TryParse(ObtenerTextoControl("cyberTextBox8"), out int puntosDisponibles) ||
                puntosDisponibles < 1000)
            {
                MessageBox.Show(
                    "El cliente necesita al menos 1000 puntos para realizar el canje.",
                    "Puntos insuficientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            usarPuntosSeleccionado = !usarPuntosSeleccionado;
            ActualizarEstadoBotonPuntos();
            CalcularTotalVenta();

            MessageBox.Show(
                usarPuntosSeleccionado
                    ? "Canje activado: se aplicará un 10% de descuento y se deberán descontar 1000 puntos al confirmar la venta."
                    : "Se canceló el canje de puntos.",
                "Canje de puntos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void ActualizarEstadoBotonPuntos()
        {
            Control[] controles = Controls.Find("cyberButton4", true);
            if (controles.Length == 0)
                return;

            Control boton = controles[0];

            bool tienePuntosSuficientes =
                int.TryParse(ObtenerTextoControl("cyberTextBox8"), out int puntos) &&
                puntos >= 1000;

            bool habilitado =
                idSocioSeleccionado > 0 &&
                !EsConsumidorFinal() &&
                tienePuntosSuficientes;

            boton.Enabled = habilitado;
            boton.BackColor = usarPuntosSeleccionado
                ? Color.FromArgb(40, 167, 69)
                : Color.FromArgb(200, 200, 200);
            boton.ForeColor = usarPuntosSeleccionado ? Color.White : Color.Black;
            boton.Refresh();
        }

        // --- CONFIRMAR VENTA ---

        private void cyberButton2_Click(object sender, EventArgs e)
        {
            if (!dataGridView1.Rows.Cast<DataGridViewRow>()
                .Any(r => !r.IsNewRow))
            {
                MessageBox.Show(
                    "Agregue al menos un producto antes de confirmar.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (idSocioSeleccionado == 0)
            {
                MessageBox.Show(
                    "Debe seleccionar un cliente antes de confirmar la venta.",
                    "Cliente requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (usarPuntosSeleccionado &&
                (EsConsumidorFinal() ||
                 !int.TryParse(
                     ObtenerTextoControl("cyberTextBox8"),
                     out int puntosActuales) ||
                 puntosActuales < 1000))
            {
                usarPuntosSeleccionado = false;
                ActualizarEstadoBotonPuntos();
                CalcularTotalVenta();

                MessageBox.Show(
                    "No se puede aplicar el canje: el cliente no es elegible " +
                    "o no tiene 1000 puntos.",
                    "Canje no válido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                decimal subtotalSinDescuento = 0m;

                DataTable dtDetalleVenta = new DataTable();
                dtDetalleVenta.Columns.Add("Código", typeof(string));
                dtDetalleVenta.Columns.Add("Descripción", typeof(string));
                dtDetalleVenta.Columns.Add("Cantidad", typeof(int));
                dtDetalleVenta.Columns.Add("Precio Unitario", typeof(string));
                dtDetalleVenta.Columns.Add("Subtotal", typeof(string));

                Venta ventaBD = new Venta
                {
                    IdUsuario = Sesion.IdUsuario > 0
                        ? Sesion.IdUsuario
                        : 1,

                    IdSocio = idSocioSeleccionado
                };

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    string cod =
                        row.Cells["ColumCodigo"].Value?.ToString() ?? "";

                    string desc =
                        row.Cells["DescripColum"].Value?.ToString() ?? "";

                    int cant = Convert.ToInt32(
                        row.Cells["CantidadColum"].Value
                    );

                    decimal precioU = Convert.ToDecimal(
                        row.Cells["PrecioColum"].Value
                    );

                    decimal sub = Convert.ToDecimal(
                        row.Cells["SubtotalColum"].Value
                    );

                    if (string.IsNullOrWhiteSpace(cod) ||
                        cant <= 0 ||
                        precioU <= 0m)
                    {
                        throw new InvalidOperationException(
                            "Hay un producto con datos inválidos en el detalle."
                        );
                    }

                    subtotalSinDescuento += sub;

                    ventaBD.Detalles.Add(new DetalleVenta
                    {
                        IdProducto = cod,
                        Cantidad = cant,
                        PrecioUnitario = precioU,
                        Subtotal = sub
                    });

                    dtDetalleVenta.Rows.Add(
                        cod,
                        desc,
                        cant,
                        "$ " + precioU.ToString("N2"),
                        "$ " + sub.ToString("N2")
                    );
                }

                // El formulario envía el importe SIN descuento.
                // VentaBusiness aplicará el 10 % si corresponde.
                ventaBD.SubtotalVenta = subtotalSinDescuento;
                ventaBD.TotalVenta = subtotalSinDescuento;

                using (FormModalPago modalPago = new FormModalPago())
                {
                    modalPago.StartPosition = FormStartPosition.CenterParent;

                    if (modalPago.ShowDialog(this) != DialogResult.OK)
                        return;

                    ventaBD.IdMetodoPago =
                        modalPago.IdMetodoPagoSeleccionado;

                    int idVentaGenerado = negocioVenta.RegistrarVenta(
                        ventaBD,
                        0.01m,
                        usarPuntosSeleccionado
                    );

                    // VentaBusiness modifica ventaBD.TotalVenta
                    // con el importe definitivo.
                    decimal totalFinal = ventaBD.TotalVenta;

                    string nombreClienteActual =
                        ObtenerTextoControl("cyberTextBox7");

                    // Actualizar el total visible.
                    AsignarTextoControl(
                        "cyberTextBox13",
                        "$ " + totalFinal.ToString("N2")
                    );

                    MessageBox.Show(
                        $"¡Venta registrada con éxito!\n\n" +
                        $"N° Factura: {idVentaGenerado:D8}\n" +
                        $"Total cobrado: $ {totalFinal:N2}",
                        "Venta completada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    GenerarFacturaFisica(
                        idVentaGenerado.ToString("D8"),
                        nombreClienteActual,
                        dtDetalleVenta,
                        totalFinal
                    );

                    LimpiarFormularioTotalmente();
                    CargarSiguienteNumeroFactura();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al registrar la venta: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        // --- GENERACIÓN DEL COMPROBANTE HTML ---
        private void GenerarFacturaFisica(string numFactura, string cliente, DataTable dtDatos, decimal total)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Documento HTML (*.html)|*.html";
                saveFileDialog.FileName = $"Factura_{numFactura}.html";
                saveFileDialog.Title = "Guardar factura de venta";

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    CrearDocumentoFacturaHtml(saveFileDialog.FileName, numFactura, cliente, dtDatos, total);

                    MessageBox.Show(
                        "Factura generada. Se abrirá en el navegador para visualizarla o imprimirla en PDF.",
                        "Generación completada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    Process.Start(new ProcessStartInfo
                    {
                        FileName = saveFileDialog.FileName,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Ocurrió un error al generar la factura: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void CrearDocumentoFacturaHtml(
            string rutaArchivo,
            string numFactura,
            string cliente,
            DataTable dtDatos,
            decimal total)
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine("<!DOCTYPE html><html><head><meta charset='utf-8'>");
            html.AppendLine("<title>Factura N° " + System.Net.WebUtility.HtmlEncode(numFactura) + "</title>");
            html.AppendLine("<style>");
            html.AppendLine("body { font-family: 'Segoe UI', Arial, sans-serif; margin: 40px; color: #333; background: #fff; }");
            html.AppendLine(".header { text-align: center; border-bottom: 3px solid #ff7b7b; padding-bottom: 15px; margin-bottom: 20px; }");
            html.AppendLine(".header h1 { color: #d9534f; margin: 0; font-size: 26px; }");
            html.AppendLine(".header h3 { color: #555; margin: 5px 0 0; font-weight: normal; }");
            html.AppendLine(".info { display: flex; justify-content: space-between; background: #fff5f5; padding: 12px 20px; border-radius: 5px; margin-bottom: 25px; border: 1px solid #ffe0e0; }");
            html.AppendLine(".info p { margin: 3px 0; font-size: 14px; }");
            html.AppendLine("table { width: 100%; border-collapse: collapse; margin-top: 10px; }");
            html.AppendLine("th, td { border: 1px solid #e0e0e0; padding: 10px; text-align: left; font-size: 13px; }");
            html.AppendLine("th { background: #ff9999; color: white; font-weight: bold; }");
            html.AppendLine("tr:nth-child(even) { background: #fcfcfc; }");
            html.AppendLine(".totales { margin-top: 20px; text-align: right; font-size: 16px; font-weight: bold; color: #d9534f; }");
            html.AppendLine(".footer { margin-top: 40px; font-size: 11px; text-align: center; color: #888; border-top: 1px solid #eee; padding-top: 15px; }");
            html.AppendLine("</style></head><body>");

            html.AppendLine("<div class='header'><h1>SISTEMA JUGUETERÍA</h1><h3>Comprobante de venta</h3></div>");
            html.AppendLine("<div class='info'><div>");
            html.AppendLine($"<p><strong>N° de factura:</strong> {System.Net.WebUtility.HtmlEncode(numFactura)}</p>");
            html.AppendLine($"<p><strong>Fecha de emisión:</strong> {DateTime.Now:dd/MM/yyyy HH:mm:ss}</p>");
            html.AppendLine($"<p><strong>Cliente:</strong> {System.Net.WebUtility.HtmlEncode(string.IsNullOrWhiteSpace(cliente) ? "Consumidor Final" : cliente)}</p>");
            html.AppendLine("</div><div style='text-align:right;'>");
            html.AppendLine($"<p><strong>Atendido por:</strong> {System.Net.WebUtility.HtmlEncode(Sesion.NombreCompleto ?? "")}</p>");

            if (usarPuntosSeleccionado)
                html.AppendLine("<p style='color:#28a745;font-weight:bold;'>Descuento por puntos (10%) aplicado</p>");

            html.AppendLine("</div></div>");

            if (dtDatos != null && dtDatos.Rows.Count > 0)
            {
                html.AppendLine("<table><thead><tr>");
                foreach (DataColumn columna in dtDatos.Columns)
                    html.AppendLine($"<th>{System.Net.WebUtility.HtmlEncode(columna.ColumnName)}</th>");
                html.AppendLine("</tr></thead><tbody>");

                foreach (DataRow fila in dtDatos.Rows)
                {
                    html.AppendLine("<tr>");
                    foreach (object item in fila.ItemArray)
                        html.AppendLine($"<td>{System.Net.WebUtility.HtmlEncode(Convert.ToString(item) ?? "")}</td>");
                    html.AppendLine("</tr>");
                }

                html.AppendLine("</tbody></table>");
            }

            html.AppendLine($"<div class='totales'><p>Total a pagar: $ {total:N2}</p></div>");
            html.AppendLine("<div class='footer'><p>¡Gracias por su compra en la Juguetería!</p></div>");
            html.AppendLine("</body></html>");

            File.WriteAllText(rutaArchivo, html.ToString(), Encoding.UTF8);
        }

        // --- EVENTOS DE BOTONES ---
        private void VincularEventosBotones()
        {
            Control[] btn1 = Controls.Find("cyberButton1", true);
            if (btn1.Length > 0)
            {
                btn1[0].Click -= cyberButton1_Click;
                btn1[0].Click += cyberButton1_Click;
            }

            Control[] btn2 = Controls.Find("cyberButton2", true);
            if (btn2.Length > 0)
            {
                btn2[0].Click -= cyberButton2_Click;
                btn2[0].Click += cyberButton2_Click;
            }

            Control[] btn3 = Controls.Find("cyberButton3", true);
            if (btn3.Length > 0)
            {
                btn3[0].Click += (s, e) => EjecutarCancelacion();
            }

            Control[] btn4 = Controls.Find("cyberButton4", true);
            if (btn4.Length > 0)
            {
                btn4[0].Click -= cyberButton4_Click;
                btn4[0].Click += cyberButton4_Click;
            }
        }

        private void EjecutarCancelacion()
        {
            if (MessageBox.Show(
                "¿Desea cancelar la venta actual?",
                "Cancelar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LimpiarFormularioTotalmente();
            }
        }

        private void LimpiarFormularioTotalmente()
        {
            idSocioSeleccionado = 0;
            idSocioSeleccionadoEnGrilla = null;
            usarPuntosSeleccionado = false;

            string[] campos =
            {
                "cyberTextBox6", "cyberTextBox7", "cyberTextBox8",
                "cyberTextBox9", "cyberTextBox10", "cyberTextBox11",
                "cyberTextBox12"
            };

            foreach (string campo in campos)
                AsignarTextoControl(campo, "");

            AsignarTextoControl("cyberTextBox13", "$ 0,00");
            dataGridView1.Rows.Clear();

            ResetearSeleccionProducto();
            CargarSocio("");
            CargarDatosGrillaProductos("");
            ResetearCantidad();
            ActualizarEstadoBotonPuntos();
        }

        // --- CÁLCULOS ---

        private void CalcularTotalVenta()
        {
            decimal subtotal = 0m;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                object valor = row.Cells["SubtotalColum"].Value;

                if (valor == null || valor == DBNull.Value)
                    continue;

                if (decimal.TryParse(
                    Convert.ToString(valor),
                    NumberStyles.Any,
                    CultureInfo.CurrentCulture,
                    out decimal importe))
                {
                    subtotal += importe;
                }
                else if (decimal.TryParse(
                    Convert.ToString(valor),
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out importe))
                {
                    subtotal += importe;
                }
            }

            decimal total = usarPuntosSeleccionado
                ? Math.Round(subtotal * 0.90m, 2)
                : subtotal;

            AsignarTextoControl(
                "cyberTextBox13",
                "$ " + total.ToString("N2")
            );
        }


        private decimal ObtenerTotalNumerico()
        {
            string texto = ObtenerTextoControl("cyberTextBox13")
                .Replace("$", "")
                .Trim();

            if (decimal.TryParse(texto, NumberStyles.Any, new CultureInfo("es-AR"), out decimal totalAr))
                return totalAr;

            if (decimal.TryParse(texto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal total))
                return total;

            return 0m;
        }

        private int ObtenerCantidadSeleccionada()
        {
            foreach (Control ctrl in GetAllControls(this))
            {
                if (ctrl is NumericUpDown numeric)
                    return Convert.ToInt32(numeric.Value);

                if (ctrl.GetType().Name.ToLowerInvariant().Contains("numeric") ||
                    ctrl.Name.ToLowerInvariant().Contains("numeric"))
                {
                    var prop = ctrl.GetType().GetProperty("Value");
                    if (prop != null)
                    {
                        try { return Convert.ToInt32(prop.GetValue(ctrl)); }
                        catch { /* probar siguiente control */ }
                    }
                }
            }

            return 1;
        }

        private void ResetearCantidad()
        {
            foreach (Control ctrl in GetAllControls(this))
            {
                if (ctrl is NumericUpDown numeric)
                {
                    numeric.Value = Math.Max(numeric.Minimum, Math.Min(1, numeric.Maximum));
                    continue;
                }

                if (ctrl.GetType().Name.ToLowerInvariant().Contains("numeric") ||
                    ctrl.Name.ToLowerInvariant().Contains("numeric"))
                {
                    var prop = ctrl.GetType().GetProperty("Value");
                    if (prop != null && prop.CanWrite)
                    {
                        try { prop.SetValue(ctrl, Convert.ChangeType(1, prop.PropertyType)); }
                        catch { /* el control personalizado puede no admitir el valor */ }
                    }
                }
            }
        }

        private IEnumerable<Control> GetAllControls(Control container)
        {
            foreach (Control c in container.Controls)
            {
                yield return c;

                foreach (Control child in GetAllControls(c))
                    yield return child;
            }
        }

        // --- VALIDACIONES Y CONTROLES ---
        private void ConfigurarRestriccionesTeclado()
        {
            Validaciones.ConfigurarNumerosLongitud(cyberTextBox6, 8);

            AsignarKeyPress("cyberTextBox10", (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    e.Handled = true;
            });
        }

        private void AsignarKeyPress(string nombreCtrl, KeyPressEventHandler ev)
        {
            Control[] controles = Controls.Find(nombreCtrl, true);
            if (controles.Length > 0)
                controles[0].KeyPress += ev;
        }

        private void AsignarTextoControl(string nombreControl, string texto)
        {
            Control[] controles = Controls.Find(nombreControl, true);
            if (controles.Length == 0)
                return;

            Control ctrl = controles[0];
            ctrl.Text = texto;

            if (ctrl is TextBox txt)
                txt.Text = texto;

            foreach (Control sub in ctrl.Controls)
            {
                sub.Text = texto;

                if (sub is TextBox t)
                    t.Text = texto;
            }
        }

        private string ObtenerTextoControl(string nombreControl)
        {
            Control[] controles = Controls.Find(nombreControl, true);
            if (controles.Length == 0)
                return "";

            Control ctrl = controles[0];

            if (ctrl is TextBox txt)
                return txt.Text;

            foreach (Control sub in ctrl.Controls)
            {
                if (sub is TextBox t)
                    return t.Text;
            }

            return ctrl.Text;
        }

        // Bloquea la edición sin deshabilitar visualmente el control completo.
        private void BloquearControl(string nombreControl)
        {
            Control[] controles = Controls.Find(nombreControl, true);
            if (controles.Length == 0)
                return;

            Control ctrl = controles[0];
            ctrl.TabStop = false;

            if (ctrl is TextBox txt)
            {
                txt.ReadOnly = true;
                return;
            }

            bool encontroTextBox = false;
            foreach (Control sub in ctrl.Controls)
            {
                sub.TabStop = false;

                if (sub is TextBox t)
                {
                    t.ReadOnly = true;
                    encontroTextBox = true;
                }
            }

            // Para controles personalizados con TextBox anidado, no se deshabilita
            // el contenedor, así conserva mejor su apariencia visual.
            if (!encontroTextBox)
                ctrl.Enabled = false;
        }

        // Métodos requeridos por el Diseñador
        private void pnlInfoFactura_Click_1(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label10_Click_1(object sender, EventArgs e) { }
        private void button5_Click(object sender, EventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }
        private void label14_Click(object sender, EventArgs e) { }
        private void label18_Click(object sender, EventArgs e) { }
        private void cyberTextBox8_Load(object sender, EventArgs e) { }
        private void cyberTextBox7_Load(object sender, EventArgs e) { }
        private void cyberTextBox12_Load(object sender, EventArgs e) { }
        private void cyberTextBox3_Load(object sender, EventArgs e) { }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}