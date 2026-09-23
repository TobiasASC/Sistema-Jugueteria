using Business; // Asegúrate de tener referenciada tu capa de negocio
using SistemaJugueteria.Business;
using SistemaJugueteria.Presentacion.Utilidades;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaJugueteria
{
    public partial class FormReportes : Form
    {
        private int contadorNumeroReporte = 5001;

        public FormReportes()
        {
            InitializeComponent();

            Validaciones.ConfigurarSoloNumeros(txtNumeroReporteBuscar);

            TextBox txtReporteReal = txtNumeroReporte.Controls.OfType<TextBox>().FirstOrDefault();
            if (txtReporteReal != null)
            {
                txtReporteReal.Enabled = false;
                txtReporteReal.BackColor = SystemColors.Control;
            }
            else
            {
                txtNumeroReporte.Enabled = false;
            }

            GenerarSiguienteNumeroReporte();
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

        private void GenerarSiguienteNumeroReporte()
        {
            var propiedadTextButton = txtNumeroReporte.GetType().GetProperty("TextButton");
            if (propiedadTextButton != null)
            {
                propiedadTextButton.SetValue(txtNumeroReporte, contadorNumeroReporte.ToString(), null);
            }
            txtNumeroReporte.Text = contadorNumeroReporte.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            GenerarSiguienteNumeroReporte();
            cbMotivo.SelectedIndex = -1;
            dtpFechaReporte.Value = DateTime.Now;
        }

        private void ActualizarContador()
        {
            int cantidad = dgvReportes.AllowUserToAddRows ? dgvReportes.Rows.Count - 1 : dgvReportes.Rows.Count;
            var propiedadTextButton = contadorReportes.GetType().GetProperty("TextButton");
            if (propiedadTextButton != null)
            {
                propiedadTextButton.SetValue(contadorReportes, cantidad < 0 ? "0" : cantidad.ToString(), null);
            }
        }

        private void btnGenerarReportePDF_Click(object sender, EventArgs e)
        {
            string numero = ObtenerTexto(txtNumeroReporte);
            string motivo = cbMotivo.Text;

            if (string.IsNullOrWhiteSpace(numero) || string.IsNullOrWhiteSpace(motivo))
            {
                MessageBox.Show("Debe seleccionar un Motivo para generar el reporte.", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fecha = dtpFechaReporte.Value.ToString("dd/MM/yyyy");

            bool guardadoExitoso = GenerarReporteFisico(numero, fecha, motivo);

            if (guardadoExitoso)
            {
                dgvReportes.Rows.Add(numero, fecha, motivo, "Abrir archivo");
                contadorNumeroReporte++;
                ActualizarContador();
                btnCancelar_Click(sender, e);
            }
        }

        private bool GenerarReporteFisico(string numReporte, string fecha, string motivo)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Documento HTML (*.html)|*.html|Documento PDF (*.pdf)|*.pdf";
                saveFileDialog.FileName = $"Reporte_{motivo.Replace(" ", "_")}_{numReporte}.html";
                saveFileDialog.Title = "Guardar Reporte del Sistema";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        DataTable dtDatos = new DataTable();

                        // Carga datos desde la capa Business si el motivo es "Empleado" o "Empleados"
                        if (motivo.ToLower().Contains("empleado"))
                        {
                            dtDatos = ObtenerListaEmpleadosBD();
                        }

                        CrearDocumentoReporte(saveFileDialog.FileName, numReporte, fecha, motivo, dtDatos);

                        MessageBox.Show($"Reporte generado exitosamente.\n\nSe abrirá en su navegador para visualizar o guardar/imprimir en PDF.",
                                        "Generación Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Process.Start(new ProcessStartInfo
                        {
                            FileName = saveFileDialog.FileName,
                            UseShellExecute = true
                        });

                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                return false;
            }
        }

        // Llamada a la Capa Business
        private DataTable ObtenerListaEmpleadosBD()
        {
            EmpleadoBusiness negocio = new EmpleadoBusiness(); // Ajustar al nombre real de tu clase en Business
            return negocio.ObtenerEmpleadosTabla();
        }

        private void CrearDocumentoReporte(string rutaArchivo, string numReporte, string fecha, string motivo, DataTable dtDatos)
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine("<!DOCTYPE html><html><head><meta charset='utf-8'>");
            html.AppendLine("<title>Reporte de " + motivo + "</title>");
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
            html.AppendLine(".footer { margin-top: 40px; font-size: 11px; text-align: center; color: #888; border-top: 1px solid #eee; padding-top: 15px; }");
            html.AppendLine("</style></head><body>");

            // Cabecera
            html.AppendLine("<div class='header'>");
            html.AppendLine("<h1>SISTEMA JUGUETERÍA</h1>");
            html.AppendLine($"<h3>Reporte Oficial - Modulo: {motivo}</h3>");
            html.AppendLine("</div>");

            // Información
            html.AppendLine("<div class='info'>");
            html.AppendLine("<div>");
            html.AppendLine($"<p><strong>N° de Reporte:</strong> {numReporte}</p>");
            html.AppendLine($"<p><strong>Fecha de Emisión:</strong> {fecha}</p>");
            html.AppendLine("</div>");
            html.AppendLine("<div style='text-align: right;'>");
            html.AppendLine($"<p><strong>Tipo/Motivo:</strong> {motivo}</p>");
            html.AppendLine($"<p><strong>Generado por:</strong> {Sesion.NombreCompleto}</p>");
            html.AppendLine("</div>");
            html.AppendLine("</div>");

            // Tabla de Datos
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
            else
            {
                html.AppendLine("<p style='text-align:center; padding: 20px; color: #666;'>No se encontraron registros para este reporte.</p>");
            }

            html.AppendLine("<div class='footer'>");
            html.AppendLine("<p>Documento generado dinámicamente desde el Sistema de Gestión de Juguetería.</p>");
            html.AppendLine("</div>");

            html.AppendLine("</body></html>");

            File.WriteAllText(rutaArchivo, html.ToString(), Encoding.UTF8);
        }

        private void hopeTextBox1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void panel3_Click(object sender, EventArgs e) { }
    }
}