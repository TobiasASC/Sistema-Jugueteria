using SistemaJugueteria.Business;
using SistemaJugueteria.Entities;
using SistemaJugueteria.Presentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SistemaJugueteria
{
    public partial class FormBackup : Form
    {
        private BackupBusiness _backupBusiness = new BackupBusiness();

        public FormBackup()
        {
            InitializeComponent();

            Validaciones.ConfigurarNumerosLongitud(txtNumeroBackup, 5);
            Validaciones.ConfigurarSoloNumeros(numeroBackupBuscar);

            dgvBackups.AutoGenerateColumns = false;

            // Bloquea los campos superiores informativos
            BloquearCyberTextBox(txtNumeroBackup);
            BloquearCyberTextBox(txtBD);
            dtpFechaBackup.Enabled = false;

            // CONECTA EVENTOS DE BÚSQUEDA DINÁMICA
            VincularEventoInterno(numeroBackupBuscar);
            dtpFechaBuscar.ValueChanged += ControlesBusqueda_Changed;

            // CARGA LA INFORMACIÓN INICIAL
            CargarGrillaBackups();
            PrepararNuevoBackupVisual();

            if (dgvBackups.Columns["Restaurar"] is DataGridViewButtonColumn colRestaurar)
            {
                colRestaurar.UseColumnTextForButtonValue = true;
                colRestaurar.Text = "Restaurar";
            }

            // Valida si el usuario activo es Gerente para mostrar el botón de CONFIGURAR PIN ---
            if (Sesion.IdRol == 3)
            {
                btnConfigurarPin.Visible = true;
            }
            else
            {
                btnConfigurarPin.Visible = false;
            }
        }

        // Método para extraer el TextBox real del CyberTextBox
        private void VincularEventoInterno(ReaLTaiizor.Controls.CyberTextBox cyberCaja)
        {
            if (cyberCaja == null) return;

            foreach (Control controlInterno in cyberCaja.Controls)
            {
                if (controlInterno is TextBox cajaReal)
                {
                    cajaReal.KeyUp += new KeyEventHandler(ControlesBusqueda_KeyUp);
                    break;
                }
            }
        }

        // Evento para el tipeo del número
        private void ControlesBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            FiltrarGrilla();
        }

        // Evento para el cambio de la fecha o el CheckBox
        private void ControlesBusqueda_Changed(object sender, EventArgs e)
        {
            FiltrarGrilla();
        }

        private void FormBackup_Load(object sender, EventArgs e)
        {
            // El Load queda vacío porque movimos la carga inicial al constructor
        }


        // LÓGICA DE FILTRADO DINÁMICO
        private void FiltrarGrilla()
        {
            if (dgvBackups.DataSource is DataTable dt)
            {
                string numeroBuscado = numeroBackupBuscar.TextButton.Trim();

                // Se usa la propiedad Checked del propio DateTimePicker integrado
                bool usarFiltroFecha = dtpFechaBuscar.Checked;
                DateTime fechaBuscada = dtpFechaBuscar.Value.Date;

                List<string> filtros = new List<string>();

                if (!string.IsNullOrWhiteSpace(numeroBuscado))
                {
                    filtros.Add($"Numero LIKE '%{numeroBuscado}%'");
                }

                if (usarFiltroFecha)
                {
                    // Rango de 24 horas para cubrir todo el día seleccionado
                    string fechaInicio = fechaBuscada.ToString("yyyy-MM-dd");
                    string fechaFin = fechaBuscada.AddDays(1).ToString("yyyy-MM-dd");

                    filtros.Add($"(Fecha >= '{fechaInicio}' AND Fecha < '{fechaFin}')");
                }

                string filtroFinal = string.Join(" AND ", filtros);
                dt.DefaultView.RowFilter = filtroFinal;

                ActualizarContador();
            }
        }

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

        private void PrepararNuevoBackupVisual()
        {
            DataTable dt = _backupBusiness.ObtenerHistorialBackups();
            int proximoNumero = dt.Rows.Count + 1;

            txtNumeroBackup.TextButton = proximoNumero.ToString("D5");
            txtBD.TextButton = "SistemaJugueteriaDB";
            dtpFechaBackup.Value = DateTime.Now;
        }

        private void CargarGrillaBackups()
        {
            DataTable dt = _backupBusiness.ObtenerHistorialBackups();
            dgvBackups.DataSource = dt;

            ActualizarContador();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            PrepararNuevoBackupVisual();
        }

        private void ActualizarContador()
        {
            if (dgvBackups.DataSource is DataTable dt)
            {
                contadorBackups.TextButton = dt.DefaultView.Count.ToString();
            }
            else
            {
                int cantidad = dgvBackups.AllowUserToAddRows ? dgvBackups.Rows.Count - 1 : dgvBackups.Rows.Count;
                contadorBackups.TextButton = cantidad.ToString();
            }
        }



        private void dgvBackups_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreColumna = dgvBackups.Columns[e.ColumnIndex].Name;

            if (nombreColumna == "Restaurar")
            {
                string rutaArchivo = dgvBackups.Rows[e.RowIndex].Cells["Ruta"].Value.ToString();

                DialogResult advertencia = MessageBox.Show(
                    "¡PELIGRO CRÍTICO! Restaurar la base de datos sobrescribirá toda la información actual del sistema con los datos de este archivo.\n\n¿Desea proceder con la autorización de doble factor?",
                    "Advertencia de Restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (advertencia == DialogResult.Yes)
                {
                    using (FormAutorizacionRestore modal = new FormAutorizacionRestore())
                    {
                        if (modal.ShowDialog() == DialogResult.OK)
                        {
                            string resultadoRestauracion = _backupBusiness.RestaurarDesdeBackup(rutaArchivo);
                            MessageBox.Show(resultadoRestauracion, "Restauración Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (resultadoRestauracion.Contains("exitosamente"))
                            {
                                Application.Restart();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Restauración cancelada.", "Operación abortada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show(
                    "¿Desea generar una nueva copia de seguridad física de la base de datos?",
                    "Confirmar Backup", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                // 1. Instanciamos y abrimos el nuevo modal de seguridad
                using (FormVerificarContraseñaBackup modal = new FormVerificarContraseñaBackup())
                {
                    // 2. Si el usuario ingresa su contraseña correctamente, procede el backup
                    if (modal.ShowDialog() == DialogResult.OK)
                    {
                        // Llamamos directamente a la capa de negocio que ejecuta el BACKUP DATABASE de SQL Server
                        string mensaje = _backupBusiness.GenerarNuevoBackup();
                        MessageBox.Show(mensaje, "Resultado del Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refrescamos la grilla leyendo la carpeta física y reseteamos el formulario
                        CargarGrillaBackups();
                        PrepararNuevoBackupVisual();
                    }
                    else
                    {
                        // Si le dio a cancelar o cerró el modal
                        MessageBox.Show("Generación de backup cancelada.", "Operación abortada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void FormBackup_Load_1(object sender, EventArgs e)
        {

        }

        private void btnConfigurarPin_Click(object sender, EventArgs e)
        {
            using (FormConfigurarPin modalPin = new FormConfigurarPin())
            {
                modalPin.ShowDialog();
            }
        }
    }
}