using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SistemaJugueteria.Presentacion.Utilidades;

namespace SistemaJugueteria
{
    public partial class FormVentas : Form
    {
        private System.Windows.Forms.Timer timerReloj;

        public FormVentas()
        {
            InitializeComponent();
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            // 1. Cargar datos de sesión
            AsignarTextoControl("cyberTextBox1", SesionProvisoria.Dni);            // Vendedor DNI
            AsignarTextoControl("cyberTextBox2", SesionProvisoria.NombreCompleto); // Vendedor Nombre
            AsignarTextoControl("cyberTextBox3", ContadorFacturaProvisorio.ObtenerNumeroSiguiente()); // N° Factura

            // 2. Timer Fecha y Hora
            timerReloj = new System.Windows.Forms.Timer();
            timerReloj.Interval = 1000;
            timerReloj.Tick += TimerReloj_Tick;
            timerReloj.Start();
            ActualizarFechaHora();

            // 3. Bloquear campos superiores
            BloquearControl("cyberTextBox1");
            BloquearControl("cyberTextBox2");
            BloquearControl("cyberTextBox3");
            BloquearControl("cyberTextBox4");
            BloquearControl("cyberTextBox5");

            // 4. Iniciar TOTAL (cyberTextBox13) en $ 0,00 y bloquearlo
            AsignarTextoControl("cyberTextBox13", "$ 0,00");
            BloquearControl("cyberTextBox13");

            // 5. Configurar restricciones de entrada
            ConfigurarRestriccionesTeclado();

            // 6. Configurar tabla
            ConfigurarTablaProductos();

            // 7. Enlazar eventos de clic en Cancelar
            VincularEventoCancelar();
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

        // --- CONFIGURACIÓN DE VALIDACIONES DE TECLADO ---
        private void ConfigurarRestriccionesTeclado()
        {
            Validaciones.ConfigurarNumerosLongitud(cyberTextBox6, 8); // DNI Cliente (Usa la clase Validaciones que esta en la carpeta utilidades)
            AsignarEventoKeyPress("cyberTextBox8", SoloNumeros_KeyPress);   // Puntos Acumulados
            AsignarEventoKeyPress("cyberTextBox10", SoloNumeros_KeyPress);  // Código Producto
            AsignarEventoKeyPress("cyberTextBox11", SoloDecimales_KeyPress); // Precio
            AsignarEventoKeyPress("cyberTextBox7", SoloLetras_KeyPress);    // Nombre Cliente
        }

        private void SoloNumeros_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void SoloDecimales_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void SoloLetras_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AsignarEventoKeyPress(string nombreControl, KeyPressEventHandler evento)
        {
            Control[] controles = this.Controls.Find(nombreControl, true);
            if (controles.Length > 0)
            {
                Control ctrl = controles[0];
                ctrl.KeyPress += evento;

                foreach (Control subCtrl in ctrl.Controls)
                {
                    if (subCtrl is TextBox || subCtrl.GetType().Name.Contains("TextBox"))
                    {
                        subCtrl.KeyPress += evento;
                    }
                }
            }
        }

        private List<DataGridView> ObtenerTodasLasTablas()
        {
            List<DataGridView> lista = new List<DataGridView>();
            foreach (Control ctrl in GetAllControls(this))
            {
                if (ctrl is DataGridView dgv)
                {
                    lista.Add(dgv);
                }
            }
            return lista;
        }

        private DataGridView? ObtenerTablaVentas()
        {
            var tablas = ObtenerTodasLasTablas();
            if (tablas.Count > 0) return tablas[0];
            return null;
        }

        private void ConfigurarTablaProductos()
        {
            foreach (var dgv in ObtenerTodasLasTablas())
            {
                if (dgv.Columns.Count == 0)
                {
                    dgv.Columns.Add("colCodigo", "Código");
                    dgv.Columns.Add("colDescripcion", "Descripción");
                    dgv.Columns.Add("colCategoria", "Categoría");
                    dgv.Columns.Add("colCantidad", "Cantidad");
                    dgv.Columns.Add("colPrecioUnitario", "Precio Unitario");
                    dgv.Columns.Add("colSubtotal", "Subtotal");

                    DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                    btnEliminar.Name = "colEliminar";
                    btnEliminar.HeaderText = "Eliminar";
                    btnEliminar.Text = "X";
                    btnEliminar.UseColumnTextForButtonValue = true;
                    dgv.Columns.Add(btnEliminar);
                }

                dgv.CellContentClick -= Dgv_CellContentClick;
                dgv.CellContentClick += Dgv_CellContentClick;
            }
        }

        private void Dgv_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgv.Columns.Count - 1 || dgv.Columns[e.ColumnIndex].Name.ToLower().Contains("eliminar"))
                {
                    if (!dgv.Rows[e.RowIndex].IsNewRow)
                    {
                        dgv.Rows.RemoveAt(e.RowIndex);
                        CalcularTotalVenta();
                    }
                }
            }
        }

        private int ObtenerCantidadSeleccionada()
        {
            foreach (Control ctrl in GetAllControls(this))
            {
                string nombre = ctrl.Name.ToLower();
                string tipo = ctrl.GetType().Name.ToLower();

                if (nombre.Contains("dungeon") || nombre.Contains("numeric") || tipo.Contains("numeric"))
                {
                    var propVal = ctrl.GetType().GetProperty("Value");
                    if (propVal != null)
                    {
                        return Convert.ToInt32(propVal.GetValue(ctrl));
                    }
                }
            }
            return 1;
        }

        private void ResetearCantidad()
        {
            foreach (Control ctrl in GetAllControls(this))
            {
                string nombre = ctrl.Name.ToLower();
                string tipo = ctrl.GetType().Name.ToLower();

                if (nombre.Contains("dungeon") || nombre.Contains("numeric") || tipo.Contains("numeric"))
                {
                    var propVal = ctrl.GetType().GetProperty("Value");
                    if (propVal != null && propVal.CanWrite)
                    {
                        propVal.SetValue(ctrl, Convert.ChangeType(1, propVal.PropertyType));
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

        // --- BOTÓN AGREGAR PRODUCTO (cyberButton1) ---
        private void cyberButton1_Click(object sender, EventArgs e)
        {
            DataGridView? dgv = ObtenerTablaVentas();
            if (dgv == null) return;

            string codigo = ObtenerTextoControl("cyberTextBox10");
            string descripcion = ObtenerTextoControl("cyberTextBox9");

            if (string.IsNullOrWhiteSpace(descripcion))
            {
                descripcion = ObtenerTextoControl("cyberTextBox12");
            }
            else
            {
                AsignarTextoControl("cyberTextBox12", descripcion);
            }

            string strPrecio = ObtenerTextoControl("cyberTextBox11");

            // =========================================================
            // NUEVA VALIDACIÓN: Obliga a tener Producto y Precio
            // =========================================================
            if (string.IsNullOrWhiteSpace(descripcion) || string.IsNullOrWhiteSpace(strPrecio))
            {
                MessageBox.Show("El Producto y el Precio Unitario son obligatorios para agregarlo a la lista.",
                                "Datos incompletos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return; // Detiene la ejecución, no agrega la fila
            }
            // =========================================================

            string precioLimpio = strPrecio.Replace("$", "").Trim();
            if (precioLimpio.Contains(",") && !precioLimpio.Contains("."))
            {
                precioLimpio = precioLimpio.Replace(",", ".");
            }

            if (!decimal.TryParse(precioLimpio, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal precioUnitario))
            {
                decimal.TryParse(precioLimpio, NumberStyles.Any, new CultureInfo("es-AR"), out precioUnitario);
            }

            // Opcional: También puedes validar que el precio no sea cero
            if (precioUnitario <= 0)
            {
                MessageBox.Show("El Precio Unitario debe ser mayor a cero.", "Precio inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad = ObtenerCantidadSeleccionada();
            if (cantidad <= 0) cantidad = 1;

            decimal subtotal = precioUnitario * cantidad;

            // Como ahora validamos arriba, "descripcion" nunca estará vacía al llegar aquí
            dgv.Rows.Add(
                string.IsNullOrWhiteSpace(codigo) ? "-" : codigo,
                descripcion,
                "-",
                cantidad,
                "$ " + precioUnitario.ToString("N2"),
                "$ " + subtotal.ToString("N2"),
                "X"
            );

            CalcularTotalVenta();

            AsignarTextoControl("cyberTextBox10", "");
            AsignarTextoControl("cyberTextBox9", "");
            AsignarTextoControl("cyberTextBox12", "");
            AsignarTextoControl("cyberTextBox11", "");
            ResetearCantidad();
        }

        // --- CÁLCULO DEL TOTAL ---
        private void CalcularTotalVenta()
        {
            decimal totalAcumulado = 0;

            foreach (var dgv in ObtenerTodasLasTablas())
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;

                    if (row.Cells.Count > 5 && row.Cells[5].Value != null)
                    {
                        string valorSubtotal = row.Cells[5].Value.ToString()!
                            .Replace("$", "")
                            .Trim();

                        if (valorSubtotal.Contains(",") && !valorSubtotal.Contains("."))
                        {
                            valorSubtotal = valorSubtotal.Replace(",", ".");
                        }

                        if (decimal.TryParse(valorSubtotal, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal subtotal))
                        {
                            totalAcumulado += subtotal;
                        }
                        else if (decimal.TryParse(valorSubtotal, NumberStyles.Any, new CultureInfo("es-AR"), out subtotal))
                        {
                            totalAcumulado += subtotal;
                        }
                    }
                }
            }

            AsignarTextoControl("cyberTextBox13", "$ " + totalAcumulado.ToString("N2"));
        }

        // --- BOTÓN CONFIRMAR (cyberButton2) ---
        private void cyberButton2_Click(object sender, EventArgs e)
        {
            DataGridView? dgv = ObtenerTablaVentas();

            if (dgv == null || dgv.Rows.Count == 0 || (dgv.Rows.Count == 1 && dgv.Rows[0].IsNewRow))
            {
                MessageBox.Show("Por favor agregue al menos un producto a la lista antes de confirmar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string cliente = ObtenerTextoControl("cyberTextBox7");
            if (string.IsNullOrWhiteSpace(cliente)) cliente = "Consumidor Final";

            string numFactura = ContadorFacturaProvisorio.ObtenerNumeroSiguiente();
            string totalFinal = ObtenerTextoControl("cyberTextBox13");

            DialogResult resultPdf = MessageBox.Show(
                $"¡Venta confirmada exitosamente!\n\nCliente: {cliente}\nN° Factura: {numFactura}\nTotal: {totalFinal}\n\n¿Desea descargar el comprobante de pago?",
                "Venta Completada",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if (resultPdf == DialogResult.Yes)
            {
                GenerarComprobantePago(numFactura, cliente, totalFinal, dgv);
            }

            ContadorFacturaProvisorio.Incrementar();
            LimpiarFormularioTotalmente();
            AsignarTextoControl("cyberTextBox3", ContadorFacturaProvisorio.ObtenerNumeroSiguiente());
        }

        // --- VINCULACIÓN DEL BOTÓN CANCELAR ---
        private void VincularEventoCancelar()
        {
            Control[] btnCancelarList = this.Controls.Find("cyberButton3", true);
            if (btnCancelarList.Length > 0)
            {
                Control btn = btnCancelarList[0];
                btn.Click -= cyberButton3_Click;
                btn.Click += cyberButton3_Click;

                foreach (Control sub in GetAllControls(btn))
                {
                    sub.Click -= cyberButton3_Click;
                    sub.Click += cyberButton3_Click;
                }
            }
        }

        // --- ACCIÓN DEL BOTÓN CANCELAR ---
        private void cyberButton3_Click(object sender, EventArgs e)
        {
            EjecutarCancelacion();
        }

        private void button2_Click(object sender, EventArgs e) { EjecutarCancelacion(); }
        private void button3_Click(object sender, EventArgs e) { EjecutarCancelacion(); }

        private void EjecutarCancelacion()
        {
            DialogResult dr = MessageBox.Show("¿Está seguro de que desea cancelar la venta actual? Se borrarán todos los datos ingresados y la lista de productos.",
                                              "Cancelar Venta",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                LimpiarFormularioTotalmente();
            }
        }

        // --- FUNCIÓN PARA DESCARGAR / GENERAR COMPROBANTE ---
        private void GenerarComprobantePago(string numFactura, string cliente, string total, DataGridView dgv)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Documento PDF (*.pdf)|*.pdf|Archivo de Texto (*.txt)|*.txt";
                saveFileDialog.FileName = $"Factura_{numFactura}.pdf";
                saveFileDialog.Title = "Guardar Comprobante de Venta";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("==================================================");
                        sb.AppendLine("                SISTEMA JUGUETERIA                 ");
                        sb.AppendLine("              COMPROBANTE DE VENTA                 ");
                        sb.AppendLine("==================================================");
                        sb.AppendLine($"N° Factura : {numFactura}");
                        sb.AppendLine($"Fecha      : {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                        sb.AppendLine($"Vendedor   : {SesionProvisoria.NombreCompleto} (DNI: {SesionProvisoria.Dni})");
                        sb.AppendLine($"Cliente    : {cliente}");
                        sb.AppendLine("--------------------------------------------------");
                        sb.AppendLine("CÓDIGO | DESCRIPCIÓN          | CANT | PRECIO U. | SUBTOTAL");
                        sb.AppendLine("--------------------------------------------------");

                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            if (!row.IsNewRow && row.Cells[0].Value != null)
                            {
                                string cod = row.Cells[0].Value.ToString()!.PadRight(6);
                                string desc = row.Cells[1].Value.ToString()!.PadRight(20);
                                if (desc.Length > 20) desc = desc.Substring(0, 17) + "...";
                                string cant = row.Cells[3].Value.ToString()!.PadRight(4);
                                string pu = row.Cells[4].Value.ToString()!.PadRight(10);
                                string sub = row.Cells[5].Value.ToString()!;

                                sb.AppendLine($"{cod} | {desc} | {cant} | {pu} | {sub}");
                            }
                        }

                        sb.AppendLine("--------------------------------------------------");
                        sb.AppendLine($"TOTAL A PAGAR: {total}");
                        sb.AppendLine("==================================================");
                        sb.AppendLine("           ¡Gracias por su compra!                ");

                        File.WriteAllText(saveFileDialog.FileName, sb.ToString());

                        MessageBox.Show($"Comprobante guardado correctamente en:\n{saveFileDialog.FileName}",
                                        "Descarga Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error al guardar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // --- MÉTODO DE LIMPIEZA ESPECÍFICO (Solo campos 6 al 13 y DataGridView) ---
        private void LimpiarFormularioTotalmente()
        {
            // 1. Limpieza explícita únicamente de los campos especificados (6 al 12)
            string[] camposAVaciar = {
                "cyberTextBox6",
                "cyberTextBox7",
                "cyberTextBox8",
                "cyberTextBox9",
                "cyberTextBox10",
                "cyberTextBox11",
                "cyberTextBox12"
            };

            foreach (string nombreCampo in camposAVaciar)
            {
                AsignarTextoControl(nombreCampo, "");
            }

            // 2. Restablecer el TOTAL (cyberTextBox13)
            AsignarTextoControl("cyberTextBox13", "$ 0,00");

            // 3. Vaciar la/s tabla/s de productos (DataGridView)
            foreach (var dgv in ObtenerTodasLasTablas())
            {
                dgv.Rows.Clear();
                dgv.Refresh();
            }

            // 4. Restablecer el selector de cantidad a 1
            ResetearCantidad();
        }

        // --- MÉTODOS AUXILIARES ---
        private void AsignarTextoControl(string nombreControl, string texto)
        {
            Control[] controles = this.Controls.Find(nombreControl, true);
            if (controles.Length > 0)
            {
                Control ctrl = controles[0];
                ctrl.Text = texto;

                if (ctrl is TextBox txt)
                {
                    txt.Text = texto;
                }

                foreach (Control subCtrl in ctrl.Controls)
                {
                    subCtrl.Text = texto;
                    if (subCtrl is TextBox || subCtrl.GetType().Name.Contains("TextBox"))
                    {
                        subCtrl.Text = texto;
                    }
                }
            }
        }

        private string ObtenerTextoControl(string nombreControl)
        {
            Control[] controles = this.Controls.Find(nombreControl, true);
            if (controles.Length > 0)
            {
                Control ctrl = controles[0];
                if (ctrl is TextBox txt) return txt.Text;

                foreach (Control subCtrl in ctrl.Controls)
                {
                    if (subCtrl is TextBox || subCtrl.GetType().Name.Contains("TextBox"))
                    {
                        return subCtrl.Text;
                    }
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
                Control ctrl = controles[0];
                ctrl.TabStop = false;
                ctrl.Enabled = false;

                foreach (Control subCtrl in ctrl.Controls)
                {
                    subCtrl.TabStop = false;
                    subCtrl.Enabled = false;
                    if (subCtrl is TextBox internalTxt)
                    {
                        internalTxt.ReadOnly = true;
                        internalTxt.Cursor = Cursors.Default;
                    }
                }
            }
        }

        // Eventos vacíos del diseñador
        private void cyberTextBox8_Load(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void pnlInfoFactura_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void cyberTextBox7_Load(object sender, EventArgs e) { }
        private void label10_Click_1(object sender, EventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }
        private void label14_Click(object sender, EventArgs e) { }
        private void cyberTextBox12_Load(object sender, EventArgs e) { }
        private void hopeNumeric1_Click(object sender, EventArgs e) { }
        private void poisonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label18_Click(object sender, EventArgs e) { }
        private void cyberTextBox3_Load(object sender, EventArgs e) { }
    }

    // --- CLASES AUXILIARES ---
    public static class SesionProvisoria
    {
        public static string Dni { get; set; } = "11222333";
        public static string NombreCompleto { get; set; } = "Usuario Prueba";
    }

    public static class ContadorFacturaProvisorio
    {
        private static int numeroActual = 1;

        public static string ObtenerNumeroSiguiente()
        {
            return numeroActual.ToString("D8");
        }

        public static void Incrementar()
        {
            numeroActual++;
        }
    }
}