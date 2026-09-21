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
    public partial class FormBackup : Form
    {
        public FormBackup()
        {
            InitializeComponent();

            Validaciones.ConfigurarNumerosLongitud(txtNumeroBackup, 5);
            Validaciones.ConfigurarSoloNumeros(numeroBackupBuscar);
        }


        private void panel2_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Limpiamos la sección superior
            txtNumeroBackup.TextButton = "";
            txtBD.TextButton = "";

            // Reiniciamos el DateTimePicker a la fecha actual
            dtpFechaBackup.Value = DateTime.Now;
        }

        private void ActualizarContador()
        {
            // Actualiza el CyberTextBox inferior con la cantidad de filas
            int cantidad = dgvBackups.AllowUserToAddRows ? dgvBackups.Rows.Count - 1 : dgvBackups.Rows.Count;
            contadorBackups.TextButton = cantidad.ToString();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // 1. Validar que los campos clave no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNumeroBackup.TextButton) || string.IsNullOrWhiteSpace(txtBD.TextButton))
            {
                MessageBox.Show("El N° de Backup y el nombre de la Base de Datos son obligatorios.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Capturar datos
            string numero = txtNumeroBackup.TextButton;
            string baseDatos = txtBD.TextButton;
            string fecha = dtpFechaBackup.Value.ToString("dd/MM/yyyy");

            // 3. Generar archivo y obtener la ruta final
            if (GenerarBackupFisico(numero, baseDatos, fecha, out string rutaFinal))
            {
                // 4. Agregar a la grilla respetando las columnas: N° Backup, Base de Datos, Ruta, Fecha, Detalles
                dgvBackups.Rows.Add(numero, baseDatos, rutaFinal, fecha, "Copia Completa");

                ActualizarContador();

                // 5. Limpiar para el siguiente backup
                btnCancelar_Click(sender, e);
            }
        }


        private bool GenerarBackupFisico(string numBackup, string baseDatos, string fecha, out string rutaGuardada)
        {
            rutaGuardada = ""; // Inicializamos la variable obligatoriamente

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // Filtros específicos para bases de datos
                saveFileDialog.Filter = "Archivo de Backup (*.bak)|*.bak|Script SQL (*.sql)|*.sql";
                saveFileDialog.FileName = $"Backup_{baseDatos}_{fecha.Replace("/", "-")}.bak";
                saveFileDialog.Title = "Guardar Copia de Seguridad";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Simulamos el contenido de un script de backup de SQL Server
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("-- ==================================================");
                        sb.AppendLine("-- SISTEMA JUGUETERÍA - COPIA DE SEGURIDAD");
                        sb.AppendLine("-- ==================================================");
                        sb.AppendLine($"-- N° Backup      : {numBackup}");
                        sb.AppendLine($"-- Base de Datos  : {baseDatos}");
                        sb.AppendLine($"-- Fecha de Copia : {fecha}");
                        sb.AppendLine("-- ==================================================");
                        sb.AppendLine();
                        sb.AppendLine($"BACKUP DATABASE [{baseDatos}]");
                        sb.AppendLine($"TO DISK = '{saveFileDialog.FileName}'");
                        sb.AppendLine("WITH NOFORMAT, NOINIT, NAME = 'Copia completa estática', SKIP, NOREWIND, NOUNLOAD, STATS = 10;");

                        File.WriteAllText(saveFileDialog.FileName, sb.ToString());

                        rutaGuardada = saveFileDialog.FileName; // Capturamos la ruta final

                        MessageBox.Show($"Copia de seguridad guardada correctamente en:\n{rutaGuardada}", "Backup Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al guardar el backup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                return false; // El usuario canceló la ventana
            }
        }
    }
}
