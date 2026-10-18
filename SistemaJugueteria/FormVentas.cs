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
        private SocioBusiness negocioSocio = new SocioBusiness();
        private ProductoBusiness negocioProducto = new ProductoBusiness();
        private VentaBusiness negocioVenta = new VentaBusiness();

        private int idSocioSeleccionado = 0;
        private bool usarPuntosSeleccionado = false; // Variable de control para el botón de puntos

        // Producto seleccionado desde la grilla de búsqueda
        private string codigoSeleccionado = "";
        private string descripcionSeleccionada = "";
        private decimal precioSeleccionado = 0;

        public FormVentas()
        {
            InitializeComponent();
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            // 1. Datos de sesión y N° de Factura real de la BD
            AsignarTextoControl("cyberTextBox1", Sesion.Dni);
            AsignarTextoControl("cyberTextBox2", Sesion.NombreCompleto);
            CargarSiguienteNumeroFactura();

            // 2. Timer Fecha y Hora
            timerReloj = new System.Windows.Forms.Timer();
            timerReloj.Interval = 1000;
            timerReloj.Tick += TimerReloj_Tick;
            timerReloj.Start();
            ActualizarFechaHora();

            // 3. Bloquear campos de solo lectura
            BloquearControl("cyberTextBox1");
            BloquearControl("cyberTextBox2");
            BloquearControl("cyberTextBox3");
            BloquearControl("cyberTextBox4");
            BloquearControl("cyberTextBox5");
            BloquearControl("cyberTextBox7");
            BloquearControl("cyberTextBox8");
            BloquearControl("cyberTextBox12");
            BloquearControl("cyberTextBox13");

            AsignarTextoControl("cyberTextBox13", "$ 0,00");

            // 4. Configurar Tablas, Estilos Visuales y Eventos
            ConfigurarGrillaClientes();
            ConfigurarGrillaBuscarProductos();
            ConfigurarGrillaVentaDetalle();

            ConfigurarRestriccionesTeclado();
            ConfigurarBuscadoresDinamicos();
            VincularEventosBotones();
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
                    string query = "SELECT ISNULL(MAX(id_venta), 0) + 1 FROM Venta";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        object resultado = cmd.ExecuteScalar();
                        int siguienteId = (resultado != null && resultado != DBNull.Value) ? Convert.ToInt32(resultado) : 1;
                        AsignarTextoControl("cyberTextBox3", siguienteId.ToString("D8"));
                    }
                }
            }
            catch
            {
                AsignarTextoControl("cyberTextBox3", "00000001");
            }
        }

        // --- ESTILOS VISUALES PARA EVITAR EL "TODO AZUL" ---
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

            // Celdas
            dgv.DefaultCellStyle.SelectionBackColor = colorSeleccion;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Encabezados de columna
            dgv.ColumnHeadersDefaultCellStyle.BackColor = colorEncabezado;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = colorEncabezado;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;

            // Encabezados de fila
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

        // --- CONFIGURACIÓN DE GRILLAS ---
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
                    lista = lista.Where(s => s.DniSocio.Contains(filtroDni)).ToList();
                }
                foreach (var socio in lista)
                {
                    int index = dataGridView2.Rows.Add(socio.DniSocio, $"{socio.NombreSocio} {socio.ApellidoSocio}", socio.DireccionSocio, socio.CorreoSocio, socio.PuntosAcumulados);
                    dataGridView2.Rows[index].Tag = socio;
                }
            }
            catch { }
        }

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
                var resultado = negocioProducto.ListarProductos(false);
                DataTable dt = resultado is DataTable ? (DataTable)resultado : null;

                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string codigo = row["Codigo"]?.ToString() ?? "";
                        string desc = row["Descripcion"]?.ToString() ?? "";
                        string categoria = row["Categoria"]?.ToString() ?? "-";
                        string precio = row["Precio"]?.ToString() ?? "0";

                        if (string.IsNullOrWhiteSpace(filtro) ||
                            codigo.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            desc.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            int index = dataGridView3.Rows.Add(codigo, desc, categoria, precio);
                            dataGridView3.Rows[index].Tag = row;
                        }
                    }
                }
            }
            catch { }
        }

        private void ConfigurarGrillaVentaDetalle()
        {
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("colCodigo", "Código");
                dataGridView1.Columns.Add("colDescripcion", "Descripción");
                dataGridView1.Columns.Add("colCategoria", "Categoría");
                dataGridView1.Columns.Add("colCantidad", "Cantidad");
                dataGridView1.Columns.Add("colPrecioUnitario", "Precio Unitario");
                dataGridView1.Columns.Add("colSubtotal", "Subtotal");

                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn
                {
                    Name = "colEliminar",
                    HeaderText = "Eliminar",
                    Text = "X",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(btnEliminar);

                dataGridView1.Columns["colPrecioUnitario"].DefaultCellStyle.Format = "C2";
                dataGridView1.Columns["colSubtotal"].DefaultCellStyle.Format = "C2";
            }

            AplicarEstiloNeutroGrilla(dataGridView1);

            dataGridView1.CellContentClick -= dataGridView1_CellContentClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }

        private void ConfigurarBuscadoresDinamicos()
        {
            Control[] ctrlDni = this.Controls.Find("cyberTextBox6", true);
            if (ctrlDni.Length > 0)
            {
                TextBox? txtDni = ctrlDni[0].Controls.OfType<TextBox>().FirstOrDefault();
                if (txtDni != null)
                {
                    txtDni.MaxLength = 8;
                    txtDni.TextChanged += (s, e) => CargarSocio(txtDni.Text.Trim());
                }
            }

            Control[] ctrlCod = this.Controls.Find("cyberTextBox10", true);
            if (ctrlCod.Length > 0)
            {
                TextBox? txtCod = ctrlCod[0].Controls.OfType<TextBox>().FirstOrDefault();
                if (txtCod != null)
                {
                    txtCod.TextChanged += (s, e) => CargarDatosGrillaProductos(txtCod.Text.Trim());
                }
            }

            Control[] ctrlDesc = this.Controls.Find("cyberTextBox9", true);
            if (ctrlDesc.Length > 0)
            {
                TextBox? txtDesc = ctrlDesc[0].Controls.OfType<TextBox>().FirstOrDefault();
                if (txtDesc != null)
                {
                    txtDesc.TextChanged += (s, e) => CargarDatosGrillaProductos(txtDesc.Text.Trim());
                }
            }
        }

        private void dataGridView2_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dataGridView2.Columns[e.ColumnIndex].Name != "colSeleccionarCliente") return;

            DataGridViewRow fila = dataGridView2.Rows[e.RowIndex];
            if (fila.Tag is Socio socio)
            {
                idSocioSeleccionado = socio.IdSocio;
                AsignarTextoControl("cyberTextBox6", socio.DniSocio);
                AsignarTextoControl("cyberTextBox7", $"{socio.NombreSocio} {socio.ApellidoSocio}");
                AsignarTextoControl("cyberTextBox8", socio.PuntosAcumulados.ToString());
            }
        }

        private void dataGridView3_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dataGridView3.Columns[e.ColumnIndex].Name != "colSeleccionar") return;

            DataGridViewRow fila = dataGridView3.Rows[e.RowIndex];

            if (fila.Tag is DataRow dr)
            {
                codigoSeleccionado = dr["Codigo"]?.ToString() ?? "";
                descripcionSeleccionada = dr["Descripcion"]?.ToString() ?? "";
                precioSeleccionado = Convert.ToDecimal(dr["Precio"], CultureInfo.InvariantCulture);
            }
            else
            {
                return;
            }

            if (precioSeleccionado <= 0)
            {
                MessageBox.Show("El producto seleccionado no tiene un precio válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetearSeleccionProducto();
                return;
            }

            AsignarTextoControl("cyberTextBox10", codigoSeleccionado);
            AsignarTextoControl("cyberTextBox9", descripcionSeleccionada);
            AsignarTextoControl("cyberTextBox12", descripcionSeleccionada);
            AsignarTextoControl("cyberTextBox11", precioSeleccionado.ToString("N2"));
        }

        private void ResetearSeleccionProducto()
        {
            codigoSeleccionado = "";
            descripcionSeleccionada = "";
            precioSeleccionado = 0;

            AsignarTextoControl("cyberTextBox10", "");
            AsignarTextoControl("cyberTextBox9", "");
            AsignarTextoControl("cyberTextBox12", "");
            AsignarTextoControl("cyberTextBox11", "");
        }

        private void dataGridView1_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                dataGridView1.Columns[e.ColumnIndex].Name == "colEliminar")
            {
                if (!dataGridView1.Rows[e.RowIndex].IsNewRow)
                {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                    CalcularTotalVenta();
                }
            }
        }

        private void cyberButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(codigoSeleccionado) || precioSeleccionado <= 0)
            {
                string codigoActual = ObtenerTextoControl("cyberTextBox10");
                if (!string.IsNullOrWhiteSpace(codigoActual))
                {
                    codigoSeleccionado = codigoActual;
                    string descActual = ObtenerTextoControl("cyberTextBox12");
                    if (!string.IsNullOrWhiteSpace(descActual)) descripcionSeleccionada = descActual;

                    string precioTxt = ObtenerTextoControl("cyberTextBox11");
                    if (decimal.TryParse(precioTxt, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal p))
                    {
                        precioSeleccionado = p;
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(codigoSeleccionado) || precioSeleccionado <= 0)
            {
                MessageBox.Show("Seleccione un producto válido de la lista para agregarlo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad = ObtenerCantidadSeleccionada();

            if (cantidad <= 0)
            {
                MessageBox.Show("No se puede agregar un producto con cantidad 0. Por favor, seleccione una cantidad válida.", "Cantidad Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal subtotal = precioSeleccionado * cantidad;

            // Obtenemos la categoría directamente de la grilla de búsqueda (dataGridView3)
            string categoriaProducto = "-";
            foreach (DataGridViewRow rowBuscador in dataGridView3.Rows)
            {
                if (rowBuscador.Cells[0].Value?.ToString() == codigoSeleccionado)
                {
                    // La columna 2 de dataGridView3 corresponde a la Categoría según el método CargarDatosGrillaProductos
                    categoriaProducto = rowBuscador.Cells[2].Value?.ToString() ?? "-";
                    break;
                }
            }

            dataGridView1.Rows.Add(
                codigoSeleccionado,
                descripcionSeleccionada,
                categoriaProducto,
                cantidad,
                precioSeleccionado,
                subtotal,
                "X"
            );

            CalcularTotalVenta();
            ResetearSeleccionProducto();
            ResetearCantidad();
        }

        private void cyberButton4_Click(object sender, EventArgs e)
        {
            if (idSocioSeleccionado == 0)
            {
                MessageBox.Show("Debe seleccionar un cliente primero para utilizar sus puntos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string puntosTxt = ObtenerTextoControl("cyberTextBox8");
            if (!int.TryParse(puntosTxt, out int puntosDisponibles) || puntosDisponibles < 1000)
            {
                MessageBox.Show("El cliente no cuenta con suficientes puntos (mínimo necesario: 1000 puntos).", "Puntos Insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            usarPuntosSeleccionado = !usarPuntosSeleccionado;

            Control[] btnCtrl = this.Controls.Find("cyberButton4", true);
            if (btnCtrl.Length > 0)
            {
                Button btnPuntos = btnCtrl[0] as Button;
                if (btnPuntos != null)
                {
                    if (usarPuntosSeleccionado)
                    {
                        btnPuntos.BackColor = Color.FromArgb(40, 167, 69); // Verde éxito
                        btnPuntos.ForeColor = Color.White;
                        MessageBox.Show("¡Puntos activados! Se aplicará un 10% de descuento en esta compra (canje de 1000 puntos).", "Puntos Aplicados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        btnPuntos.BackColor = Color.FromArgb(200, 200, 200); // Gris neutro
                        btnPuntos.ForeColor = Color.Black;
                        MessageBox.Show("Se ha cancelado el uso de puntos para esta venta.", "Puntos Desactivados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            CalcularTotalVenta();
        }

        // --- BOTÓN CONFIRMAR (cyberButton2) CON DESCARGA/VISUALIZACIÓN DE FACTURA PDF ---
        private void cyberButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0 || (dataGridView1.Rows.Count == 1 && dataGridView1.Rows[0].IsNewRow))
            {
                MessageBox.Show("Agregue al menos un producto a la lista antes de confirmar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (idSocioSeleccionado == 0)
            {
                MessageBox.Show("Debe seleccionar un cliente antes de confirmar la venta (seleccione 'Consumidor Final' o un cliente registrado).", "Cliente Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                decimal totalFinal = ObtenerTotalNumerico();

                // 1. Abrimos la ventana emergente de selección de método de pago
                using (FormModalPago modalPago = new FormModalPago())
                {
                    modalPago.StartPosition = FormStartPosition.CenterParent;
                    DialogResult resultadoModal = modalPago.ShowDialog(this);

                    // 2. Si el usuario seleccionó un método de pago y dio clic en CONFIRMAR en la ventana pequeña:
                    if (resultadoModal == DialogResult.OK)
                    {
                        int idMetodoPagoElegido = modalPago.IdMetodoPagoSeleccionado;
                        string numeroFacturaActual = ObtenerTextoControl("cyberTextBox3");
                        string nombreClienteActual = ObtenerTextoControl("cyberTextBox7");

                        Venta ventaBD = new Venta
                        {
                            IdUsuario = Sesion.IdUsuario > 0 ? Sesion.IdUsuario : 1,
                            IdSocio = idSocioSeleccionado,
                            IdMetodoPago = idMetodoPagoElegido
                        };

                        decimal totalAcumulado = 0;
                        DataTable dtDetalleVenta = new DataTable();
                        dtDetalleVenta.Columns.Add("Código", typeof(string));
                        dtDetalleVenta.Columns.Add("Descripción", typeof(string));
                        dtDetalleVenta.Columns.Add("Cantidad", typeof(int));
                        dtDetalleVenta.Columns.Add("Precio Unitario", typeof(string));
                        dtDetalleVenta.Columns.Add("Subtotal", typeof(string));

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.IsNewRow) continue;

                            string cod = row.Cells[0].Value?.ToString() ?? "-";
                            string desc = row.Cells[1].Value?.ToString() ?? "-";
                            int cant = Convert.ToInt32(row.Cells[3].Value);
                            decimal precioU = Convert.ToDecimal(row.Cells[4].Value, CultureInfo.InvariantCulture);
                            decimal sub = Convert.ToDecimal(row.Cells[5].Value, CultureInfo.InvariantCulture);

                            totalAcumulado += sub;

                            ventaBD.Detalles.Add(new DetalleVenta
                            {
                                IdProducto = cod,
                                Cantidad = cant,
                                PrecioUnitario = precioU,
                                Subtotal = sub
                            });

                            dtDetalleVenta.Rows.Add(cod, desc, cant, $"$ {precioU:N2}", $"$ {sub:N2}");
                        }

                        ventaBD.SubtotalVenta = totalAcumulado;
                        ventaBD.TotalVenta = totalFinal;

                        // 3. Registramos la venta en la BD mediante la Capa de Negocio
                        int idVentaGenerado = negocioVenta.RegistrarVenta(ventaBD, 0.01m, usarPuntosSeleccionado);

                        MessageBox.Show(
                            $"¡Venta registrada con éxito en la Base de Datos!\n\nN° Factura: {idVentaGenerado:D8}\nTotal Cobrado: $ {totalFinal:N2}",
                            "Venta Completada",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        // 4. Generación automática y guardado del comprobante / factura en PDF/HTML
                        GenerarFacturaFisica(idVentaGenerado.ToString("D8"), nombreClienteActual, dtDetalleVenta, totalFinal);

                        LimpiarFormularioTotalmente();
                        CargarSiguienteNumeroFactura();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarFacturaFisica(string numFactura, string cliente, DataTable dtDatos, decimal total)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Documento HTML (*.html)|*.html|Documento PDF (*.pdf)|*.pdf";
                saveFileDialog.FileName = $"Factura_{numFactura}.html";
                saveFileDialog.Title = "Guardar Factura de Venta";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        CrearDocumentoFacturaHtml(saveFileDialog.FileName, numFactura, cliente, dtDatos, total);

                        MessageBox.Show("Factura generada exitosamente.\n\nSe abrirá en su navegador para visualizar o guardar/imprimir en PDF.",
                                        "Generación Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Process.Start(new ProcessStartInfo
                        {
                            FileName = saveFileDialog.FileName,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error al generar la factura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CrearDocumentoFacturaHtml(string rutaArchivo, string numFactura, string cliente, DataTable dtDatos, decimal total)
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine("<!DOCTYPE html><html><head><meta charset='utf-8'>");
            html.AppendLine("<title>Factura N° " + numFactura + "</title>");
            html.AppendLine("<style>");
            html.AppendLine("body { font-family: 'Segoe UI', Arial, sans-serif; margin: 40px; color: #333; background-color: #fff; }");
            html.AppendLine(".header { text-align: center; border-bottom: 3px solid #ff7b7b; padding-bottom: 15px; margin-bottom: 20px; }");
            html.AppendLine(".header h1 { color: #d9534f; margin: 0; font-size: 26px; }");
            html.AppendLine(".header h3 { color: #555; margin: 5px 0 0 0; font-weight: normal; }");
            html.AppendLine(".info { display: flex; justify-content: space-between; background-color: #fff5f5; padding: 12px 20px; border-radius: 5px; margin-bottom: 25px; border: 1px solid #ffe0e0; }");
            html.AppendLine(".info p { margin: 3px 0; font-size: 14px; }");
            html.AppendLine("table { width: 100%; border-collapse: collapse; margin-top: 10px; }");
            html.AppendLine("th, td { border: 1px solid #e0e0e0; padding: 10px; text-align: left; font-size: 13px; }");
            html.AppendLine("th { background-color: #ff9999; color: white; font-weight: bold; }");
            html.AppendLine("tr:nth-child(even) { background-color: #fcfcfc; }");
            html.AppendLine(".totales { margin-top: 20px; text-align: right; font-size: 16px; font-weight: bold; color: #d9534f; }");
            html.AppendLine(".footer { margin-top: 40px; font-size: 11px; text-align: center; color: #888; border-top: 1px solid #eee; padding-top: 15px; }");
            html.AppendLine("</style></head><body>");

            // Cabecera
            html.AppendLine("<div class='header'>");
            html.AppendLine("<h1>SISTEMA JUGUETERÍA</h1>");
            html.AppendLine("<h3>Comprobante Oficial de Venta</h3>");
            html.AppendLine("</div>");

            // Información
            html.AppendLine("<div class='info'>");
            html.AppendLine("<div>");
            html.AppendLine($"<p><strong>N° de Factura:</strong> {numFactura}</p>");
            html.AppendLine($"<p><strong>Fecha de Emisión:</strong> {DateTime.Now:dd/MM/yyyy HH:mm:ss}</p>");
            html.AppendLine($"<p><strong>Cliente:</strong> {(string.IsNullOrWhiteSpace(cliente) ? "Consumidor Final" : cliente)}</p>");
            html.AppendLine("</div>");
            html.AppendLine("<div style='text-align: right;'>");
            html.AppendLine($"<p><strong>Atendido por:</strong> {Sesion.NombreCompleto}</p>");
            if (usarPuntosSeleccionado)
            {
                html.AppendLine("<p style='color: #28a745; font-weight: bold;'>✔ Descuento por Puntos (10%) Aplicado</p>");
            }
            html.AppendLine("</div>");
            html.AppendLine("</div>");

            // Tabla de Detalles
            if (dtDatos != null && dtDatos.Rows.Count > 0)
            {
                html.AppendLine("<table>");
                html.AppendLine("<thead><tr>");
                foreach (DataColumn columna in dtDatos.Columns)
                {
                    html.AppendLine($"<th>{columna.ColumnName}</th>");
                }
                html.AppendLine("</tr></thead>");

                html.AppendLine("<tbody>");
                foreach (DataRow fila in dtDatos.Rows)
                {
                    html.AppendLine("<tr>");
                    foreach (var item in fila.ItemArray)
                    {
                        html.AppendLine($"<td>{item}</td>");
                    }
                    html.AppendLine("</tr>");
                }
                html.AppendLine("</tbody></table>");
            }

            // Totales
            html.AppendLine($"<div class='totales'>");
            html.AppendLine($"<p>Total a Pagar: $ {total:N2}</p>");
            html.AppendLine($"</div>");

            // Pie de página
            html.AppendLine("<div class='footer'>");
            html.AppendLine("<p>¡Gracias por su compra en la Juguetería! Documento generado electrónicamente.</p>");
            html.AppendLine("</div>");

            html.AppendLine("</body></html>");

            File.WriteAllText(rutaArchivo, html.ToString(), Encoding.UTF8);
        }

        private void VincularEventosBotones()
        {
            Control[] btn1 = this.Controls.Find("cyberButton1", true);
            if (btn1.Length > 0) btn1[0].Click += cyberButton1_Click;

            Control[] btn2 = this.Controls.Find("cyberButton2", true);
            if (btn2.Length > 0) btn2[0].Click += cyberButton2_Click;

            Control[] btn3 = this.Controls.Find("cyberButton3", true);
            if (btn3.Length > 0) btn3[0].Click += (s, e) => EjecutarCancelacion();

            Control[] btn4 = this.Controls.Find("cyberButton4", true);
            if (btn4.Length > 0) btn4[0].Click += cyberButton4_Click;
        }

        private void EjecutarCancelacion()
        {
            if (MessageBox.Show("¿Desea cancelar la venta actual?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LimpiarFormularioTotalmente();
            }
        }

        private void LimpiarFormularioTotalmente()
        {
            idSocioSeleccionado = 0;
            usarPuntosSeleccionado = false;

            Control[] btnCtrl = this.Controls.Find("cyberButton4", true);
            if (btnCtrl.Length > 0 && btnCtrl[0] is Button btnPuntos)
            {
                btnPuntos.BackColor = Color.FromArgb(200, 200, 200);
                btnPuntos.ForeColor = Color.Black;
            }

            string[] campos = { "cyberTextBox6", "cyberTextBox7", "cyberTextBox8", "cyberTextBox9", "cyberTextBox10", "cyberTextBox11", "cyberTextBox12" };
            foreach (string c in campos) AsignarTextoControl(c, "");
            AsignarTextoControl("cyberTextBox13", "$ 0,00");
            dataGridView1.Rows.Clear();
            ResetearSeleccionProducto();
            CargarSocio("");
            CargarDatosGrillaProductos("");
            ResetearCantidad();
        }

        private void CalcularTotalVenta()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells[5].Value != null)
                    total += Convert.ToDecimal(row.Cells[5].Value, CultureInfo.InvariantCulture);
            }

            // Si el botón de usar puntos está activo, aplicamos el 10% de descuento visualmente
            if (usarPuntosSeleccionado)
            {
                total = total * 0.90m;
            }

            AsignarTextoControl("cyberTextBox13", "$ " + total.ToString("N2"));
        }

        private decimal ObtenerTotalNumerico()
        {
            string textoTotal = ObtenerTextoControl("cyberTextBox13")
                .Replace("$", "")
                .Trim();

            if (decimal.TryParse(textoTotal, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal val))
            {
                return val;
            }
            if (decimal.TryParse(textoTotal, NumberStyles.Any, new CultureInfo("es-AR"), out decimal valAr))
            {
                return valAr;
            }
            return 0;
        }

        private int ObtenerCantidadSeleccionada()
        {
            foreach (Control ctrl in GetAllControls(this))
            {
                if (ctrl.GetType().Name.ToLower().Contains("numeric") || ctrl.Name.ToLower().Contains("numeric"))
                {
                    var prop = ctrl.GetType().GetProperty("Value");
                    if (prop != null) return Convert.ToInt32(prop.GetValue(ctrl));
                }
            }
            return 1;
        }

        private void ResetearCantidad()
        {
            foreach (Control ctrl in GetAllControls(this))
            {
                if (ctrl.GetType().Name.ToLower().Contains("numeric") || ctrl.Name.ToLower().Contains("numeric"))
                {
                    var prop = ctrl.GetType().GetProperty("Value");
                    if (prop != null && prop.CanWrite) prop.SetValue(ctrl, Convert.ChangeType(1, prop.PropertyType));
                }
            }
        }

        private IEnumerable<Control> GetAllControls(Control container)
        {
            foreach (Control c in container.Controls)
            {
                yield return c;
                foreach (Control child in GetAllControls(c)) yield return child;
            }
        }

        private void ConfigurarRestriccionesTeclado()
        {
            Validaciones.ConfigurarNumerosLongitud(cyberTextBox6, 8);
            AsignarKeyPress("cyberTextBox10", (s, e) => { if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true; });
        }

        private void AsignarKeyPress(string nombreCtrl, KeyPressEventHandler ev)
        {
            Control[] controles = this.Controls.Find(nombreCtrl, true);
            if (controles.Length > 0) controles[0].KeyPress += ev;
        }

        private void AsignarTextoControl(string nombreControl, string texto)
        {
            Control[] controles = this.Controls.Find(nombreControl, true);
            if (controles.Length > 0)
            {
                Control ctrl = controles[0];
                ctrl.Text = texto;
                if (ctrl is TextBox txt) txt.Text = texto;
                foreach (Control sub in ctrl.Controls)
                {
                    sub.Text = texto;
                    if (sub is TextBox t) t.Text = texto;
                }
            }
        }

        private string ObtenerTextoControl(string nombreControl)
        {
            Control[] controles = this.Controls.Find(nombreControl, true);
            if (controles.Length > 0)
            {
                Control ctrl = controles[0];
                ctrl.Text = ctrl.Text; // Refresco básico
                if (ctrl is TextBox txt) return txt.Text;
                foreach (Control sub in ctrl.Controls)
                {
                    if (sub is TextBox t) return t.Text;
                }
                return ctrl.Text;
            }
            return "";
        }

        private void BloquearControl(string nombreControl)
        {
            Control[] controles = this.Controls.Find(nombreControl, true);
            if (controles.Length > 0)
            {
                Control ctrl = controles.Length > 0 ? controles[0] : null;
                if (ctrl != null)
                {
                    ctrl.TabStop = false;
                    ctrl.Enabled = false;
                    foreach (Control sub in ctrl.Controls)
                    {
                        sub.TabStop = false;
                        sub.Enabled = false;
                        if (sub is TextBox t) t.ReadOnly = true;
                    }
                }
            }
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
    }
}