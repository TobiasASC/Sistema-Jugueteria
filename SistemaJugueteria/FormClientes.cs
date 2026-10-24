using Entities;
using Microsoft.Data.SqlClient;
using SistemaJugueteria.Business;
using SistemaJugueteria.Data;
using SistemaJugueteria.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SistemaJugueteria.Presentacion.Utilidades;

namespace SistemaJugueteria
{
    public partial class FormClientes : Form
    {
        private SocioBusiness negocioSocio = new SocioBusiness();
        private int idSocioEditando = -1;

        public FormClientes()
        {
            InitializeComponent();

            Validaciones.ConfigurarNumerosLongitud(txtDniCliente, 8);
            Validaciones.ConfigurarSoloLetras(txtNombreCliente);
            Validaciones.ConfigurarSoloLetras(txtApellidoCliente);
            Validaciones.ConfigurarEmail(txtEmailCliente);

            dgvClientes.AutoGenerateColumns = false;
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();

            // Configuración de restricciones mediante el TextBox interno del CyberTextBox
            TextBox txtDniReal = txtDniCliente.Controls.OfType<TextBox>().FirstOrDefault();
            if (txtDniReal != null)
            {
                txtDniReal.MaxLength = 8;
                txtDniReal.KeyPress += TxtDniReal_KeyPress;
            }

            // Configuración del campo de Puntos para que sea de solo lectura
            TextBox txtPuntosReal = txtPuntosCliente.Controls.OfType<TextBox>().FirstOrDefault();
            if (txtPuntosReal != null)
            {
                txtPuntosReal.ReadOnly = true;
            }

            // Configuración de buscadores en tiempo real
            TextBox cajaDniBuscar = txtDniClienteBuscar.Controls.OfType<TextBox>().FirstOrDefault();
            if (cajaDniBuscar != null)
            {
                cajaDniBuscar.MaxLength = 8;
                cajaDniBuscar.KeyPress += TxtDniReal_KeyPress;
                cajaDniBuscar.TextChanged += FiltroEnTiempoReal_TextChanged;
            }

            TextBox cajaNombreBuscar = txtNombreClienteBuscar.Controls.OfType<TextBox>().FirstOrDefault();
            if (cajaNombreBuscar != null)
            {
                cajaNombreBuscar.TextChanged += FiltroEnTiempoReal_TextChanged;
            }

            // Vincular evento de cambio de estado para activos/inactivos (chkEstado)
            if (chkEstado != null)
            {
                chkEstado.CheckedChanged += delegate {
                    ConfigurarDataGridView();
                    CargarGrillaClientes();
                };
            }

            CargarGrillaClientes();
        }

        private void ConfigurarDataGridView()
        {
            dgvClientes.Columns.Clear();
            dgvClientes.AutoGenerateColumns = false;

            dgvClientes.Columns.Add("colDni", "DNI");
            dgvClientes.Columns.Add("colNomApe", "Nom y Ape");
            dgvClientes.Columns.Add("colDireccion", "Dirección");
            dgvClientes.Columns.Add("colEmail", "Email");
            dgvClientes.Columns.Add("colPuntos", "Puntos");

            // Columna Modificar
            DataGridViewButtonColumn btnModificarCol = new DataGridViewButtonColumn();
            btnModificarCol.Name = "colModificar";
            btnModificarCol.HeaderText = "Modificar";
            btnModificarCol.Text = "Modificar";
            btnModificarCol.UseColumnTextForButtonValue = true;
            dgvClientes.Columns.Add(btnModificarCol);

            // Columna Eliminar / Reactivar
            bool verInactivos = chkEstado != null && chkEstado.Checked;
            DataGridViewButtonColumn btnEliminarCol = new DataGridViewButtonColumn();
            btnEliminarCol.Name = "colEliminar";
            btnEliminarCol.HeaderText = verInactivos ? "Reactivar" : "Eliminar";
            btnEliminarCol.Text = verInactivos ? "Reactivar" : "Eliminar"; 
            btnEliminarCol.UseColumnTextForButtonValue = true;
            dgvClientes.Columns.Add(btnEliminarCol);

            dgvClientes.CellClick -= dgvClientes_CellClick;
            dgvClientes.CellClick += dgvClientes_CellClick;
        }

        private void CargarGrillaClientes()
        {
            dgvClientes.Rows.Clear();
            bool verInactivos = chkEstado != null && chkEstado.Checked;
            List<Socio> lista = negocioSocio.ListarSocios(verInactivos);

            string filtroDni = LeerCyberTextBox(txtDniClienteBuscar).Trim();
            string filtroNombre = LeerCyberTextBox(txtNombreClienteBuscar).Trim().ToLower();

            if (!string.IsNullOrWhiteSpace(filtroDni))
            {
                lista = lista.Where(s => s.DniSocio.Contains(filtroDni)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(filtroNombre))
            {
                lista = lista.Where(s =>
                    s.NombreSocio.ToLower().Contains(filtroNombre) ||
                    s.ApellidoSocio.ToLower().Contains(filtroNombre)).ToList();
            }

            foreach (var socio in lista)
            {
                string nombreCompleto = $"{socio.NombreSocio} {socio.ApellidoSocio}";
                int indiceFila = dgvClientes.Rows.Add(socio.DniSocio, nombreCompleto, socio.DireccionSocio, socio.CorreoSocio, socio.PuntosAcumulados);

                // Guardamos los datos en el Tag para usarlos al modificar
                dgvClientes.Rows[indiceFila].Tag = new object[] { socio.IdSocio, socio.NombreSocio, socio.ApellidoSocio };
            }

            // Configurar botón Modificar (índice 5)
            if (dgvClientes.Columns["colModificar"] is DataGridViewButtonColumn colModificar)
            {
                colModificar.UseColumnTextForButtonValue = true;
                colModificar.Text = "Modificar";
            }

            // Configurar botón Eliminar / Reactivar (índice 6)
            if (dgvClientes.Columns["colEliminar"] is DataGridViewButtonColumn colEliminar)
            {
                colEliminar.UseColumnTextForButtonValue = true;
                colEliminar.Text = verInactivos ? "Reactivar" : "Eliminar";
            }

            ActualizarContador(lista.Count);
        }

        private void FiltroEnTiempoReal_TextChanged(object sender, EventArgs e)
        {
            CargarGrillaClientes();
        }

        private void ChkEstado_CheckedChanged(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CargarGrillaClientes();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (ValidarCamposVacios()) return;

            try
            {
                Socio nuevoSocio = new Socio
                {
                    IdSocio = 0, // 0 indica que es nuevo
                    DniSocio = LeerCyberTextBox(txtDniCliente),
                    NombreSocio = LeerCyberTextBox(txtNombreCliente),
                    ApellidoSocio = LeerCyberTextBox(txtApellidoCliente),
                    CorreoSocio = LeerCyberTextBox(txtEmailCliente),
                    DireccionSocio = LeerCyberTextBox(txtDireccionCliente)
                };

                negocioSocio.GuardarSocio(nuevoSocio);
                MessageBox.Show("¡Cliente agregado con éxito!", "Nuevo Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarGrillaClientes();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("2627") || ex.Message.Contains("UNIQUE") || ex.Message.Contains("UQ_Socio"))
                {
                    MessageBox.Show("Este cliente ya está registrado. Para modificar sus datos presione 'Guardar'.", "Cliente Existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idSocioEditando < 0)
            {
                MessageBox.Show("Seleccione un cliente de la tabla usando 'Modificar' para actualizar sus datos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidarCamposVacios()) return;

            try
            {
                Socio socioModificado = new Socio
                {
                    IdSocio = idSocioEditando,
                    DniSocio = LeerCyberTextBox(txtDniCliente),
                    NombreSocio = LeerCyberTextBox(txtNombreCliente),
                    ApellidoSocio = LeerCyberTextBox(txtApellidoCliente),
                    CorreoSocio = LeerCyberTextBox(txtEmailCliente),
                    DireccionSocio = LeerCyberTextBox(txtDireccionCliente)
                };

                negocioSocio.GuardarSocio(socioModificado);
                MessageBox.Show("Cliente modificado correctamente.", "Guardar Cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarGrillaClientes();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == dgvClientes.NewRowIndex) return;

            DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];

            // Columna Modificar (Columna 5)
            if (e.ColumnIndex == 5)
            {
                EscribirCyberTextBox(txtDniCliente, fila.Cells[0].Value?.ToString());

                if (fila.Tag is object[] datos && datos.Length >= 3)
                {
                    idSocioEditando = Convert.ToInt32(datos[0]);
                    EscribirCyberTextBox(txtNombreCliente, datos[1].ToString());
                    EscribirCyberTextBox(txtApellidoCliente, datos[2].ToString());
                }

                EscribirCyberTextBox(txtDireccionCliente, fila.Cells[2].Value?.ToString());
                EscribirCyberTextBox(txtEmailCliente, fila.Cells[3].Value?.ToString());

                // Carga los puntos pero quedan bloqueados de edición
                EscribirCyberTextBox(txtPuntosCliente, fila.Cells[4].Value?.ToString());
            }
            // Columna Eliminar / Reactivar (Columna 6)
            else if (e.ColumnIndex == 6)
            {
                bool verInactivos = chkEstado != null && chkEstado.Checked;

                if (!verInactivos)
                {
                    DialogResult respuesta = MessageBox.Show("¿Está seguro que desea dar de baja este cliente?", "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes)
                    {
                        if (fila.Tag is object[] datos && datos.Length > 0)
                        {
                            int idSocio = Convert.ToInt32(datos[0]);
                            negocioSocio.EliminarSocio(idSocio);
                            CargarGrillaClientes();
                            LimpiarCampos();
                        }
                    }
                }
                else
                {
                    DialogResult respuesta = MessageBox.Show("¿Desea volver a activar este cliente?", "Confirmar Reactivación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes)
                    {
                        if (fila.Tag is object[] datos && datos.Length > 0)
                        {
                            int idSocio = Convert.ToInt32(datos[0]);
                            negocioSocio.ReactivarSocio(idSocio); // Asegúrate de tener este método en tu SocioBusiness o ajústalo si se llama distinto
                            CargarGrillaClientes();
                            LimpiarCampos();
                        }
                    }
                }
            }
        }

        private string LeerCyberTextBox(ReaLTaiizor.Controls.CyberTextBox cyberCaja)
        {
            TextBox cajaReal = cyberCaja.Controls.OfType<TextBox>().FirstOrDefault();
            return cajaReal != null ? cajaReal.Text.Trim() : cyberCaja.Text.Trim();
        }

        private void EscribirCyberTextBox(ReaLTaiizor.Controls.CyberTextBox cyberCaja, string texto)
        {
            TextBox cajaReal = cyberCaja.Controls.OfType<TextBox>().FirstOrDefault();
            if (cajaReal != null)
            {
                cajaReal.Text = texto;
            }
            cyberCaja.Text = texto;
        }

        private void TxtDniReal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            TextBox cajaReal = sender as TextBox;
            if (cajaReal != null && cajaReal.Text.Length >= 8 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void LimpiarCampos()
        {
            idSocioEditando = -1;
            EscribirCyberTextBox(txtDniCliente, "");
            EscribirCyberTextBox(txtNombreCliente, "");
            EscribirCyberTextBox(txtApellidoCliente, "");
            EscribirCyberTextBox(txtEmailCliente, "");
            EscribirCyberTextBox(txtDireccionCliente, "");
            EscribirCyberTextBox(txtPuntosCliente, ""); // Limpia también los puntos

            TextBox cajaReal = txtDniCliente.Controls.OfType<TextBox>().FirstOrDefault();
            if (cajaReal != null) cajaReal.Focus();
        }

        private bool ValidarCamposVacios()
        {
            if (string.IsNullOrWhiteSpace(LeerCyberTextBox(txtDniCliente)) ||
                string.IsNullOrWhiteSpace(LeerCyberTextBox(txtNombreCliente)) ||
                string.IsNullOrWhiteSpace(LeerCyberTextBox(txtApellidoCliente)) ||
                string.IsNullOrWhiteSpace(LeerCyberTextBox(txtEmailCliente)) ||
                string.IsNullOrWhiteSpace(LeerCyberTextBox(txtDireccionCliente)))
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }

        private void ActualizarContador(int cantidad)
        {
            EscribirCyberTextBox(contadorClientes, cantidad < 0 ? "0" : cantidad.ToString());
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void hopeTextBox1_Click(object sender, EventArgs e) { }
        private void button5_Click(object sender, EventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }
        private void cyberTextBox10_Load(object sender, EventArgs e) { }
        private void txtApellidoCliente_Load(object sender, EventArgs e) { }
        private void txtNombreClienteBuscar_Load(object sender, EventArgs e) { }
        private void txtDniClienteBuscar_Load(object sender, EventArgs e) { }
    }
}