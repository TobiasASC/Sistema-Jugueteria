using SistemaJugueteria.Presentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaJugueteria
{
    public partial class FormReportes : Form
    {
        public FormReportes()
        {
            InitializeComponent();
            Validaciones.ConfigurarSoloNumeros(txtNumeroReporteBuscar);
            Validaciones.ConfigurarSoloNumeros(txtNumeroReporte);
        }

        private void hopeTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Limpiamos los campos
            txtNumeroReporte.TextButton = "";
            cbMotivo.SelectedIndex = -1;

            // Para "limpiar" el DateTimePicker, simplemente lo devolvemos a la fecha y hora actual
            dtpFechaReporte.Value = DateTime.Now;
        }

        private void panel3_Click(object sender, EventArgs e)
        {

        }

        private void ActualizarContador()
        {
            // Restamos 1 si la grilla tiene la fila en blanco al final para agregar registros nuevos
            int cantidad = dgvReportes.AllowUserToAddRows ? dgvReportes.Rows.Count - 1 : dgvReportes.Rows.Count;
            contadorReportes.TextButton = cantidad.ToString();
        }

        

        private void btnGenerarReportePDF_Click(object sender, EventArgs e)
        {
            // 1. Validación de campos vacíos
            if (string.IsNullOrWhiteSpace(txtNumeroReporte.TextButton) || string.IsNullOrWhiteSpace(cbMotivo.Text))
            {
                MessageBox.Show("Debe completar el N° de Reporte y el Motivo para generar el documento.", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Capturar los datos
            string numero = txtNumeroReporte.TextButton;
            string fecha = dtpFechaReporte.Value.ToString("dd/MM/yyyy");
            string motivo = cbMotivo.Text;

            // 3. Llamar a la función para guardar el archivo físicamente
            bool guardadoExitoso = GenerarReporteFisico(numero, fecha, motivo);

            // 4. Si el archivo se guardó realmente, actualizamos la interfaz
            if (guardadoExitoso)
            {
                dgvReportes.Rows.Add(numero, fecha, motivo, "Abrir archivo");
                ActualizarContador();
                btnCancelar_Click(sender, e); // Limpia los campos
            }
        }


        private bool GenerarReporteFisico(string numReporte, string fecha, string motivo)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Documento PDF (*.pdf)|*.pdf|Archivo de Texto (*.txt)|*.txt";
                saveFileDialog.FileName = $"Reporte_{numReporte}.pdf";
                saveFileDialog.Title = "Guardar Reporte del Sistema";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("==================================================");
                        sb.AppendLine("                SISTEMA JUGUETERIA                ");
                        sb.AppendLine("                REPORTE DEL SISTEMA               ");
                        sb.AppendLine("==================================================");
                        sb.AppendLine($"N° Reporte : {numReporte}");
                        sb.AppendLine($"Fecha      : {fecha}");
                        sb.AppendLine($"Motivo     : {motivo}");
                        sb.AppendLine("--------------------------------------------------");
                        sb.AppendLine("Detalles del documento:");
                        sb.AppendLine("Este reporte ha sido generado automáticamente por");
                        sb.AppendLine("el módulo de administración de la juguetería.");
                        sb.AppendLine("==================================================");

                        // Escribe el texto en la ruta elegida por el usuario
                        File.WriteAllText(saveFileDialog.FileName, sb.ToString());

                        MessageBox.Show($"Reporte guardado correctamente en:\n{saveFileDialog.FileName}",
                                        "Descarga Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return true; // Retorna verdadero si se guardó con éxito
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error al guardar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                return false; // Retorna falso si el usuario canceló la ventana de guardado
            }
        }
    }
}
