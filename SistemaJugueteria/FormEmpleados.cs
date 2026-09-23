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
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SistemaJugueteria.Presentacion.Utilidades;

namespace SistemaJugueteria
{
    public partial class FormEmpleados : Form
    {
        private int idEmpleadoSeleccionado = 0;
        private int idEmpleadoAEditar = 0;
        private int idUsuarioAEditar = 0;

        public FormEmpleados()
        {
            InitializeComponent();

            // Configurar el ComboBox de Roles al abrir la pantalla
            CargarRolesEnComboBox();
        }

        private void CargarRolesEnComboBox()
        {
            var roles = new System.Collections.Generic.List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(1, "Administrador"),
                new KeyValuePair<int, string>(2, "Vendedor"),
                new KeyValuePair<int, string>(3, "Gerente")
            };

            cmbRol.DataSource = roles;
            cmbRol.DisplayMember = "Value";
            cmbRol.ValueMember = "Key";
        }

        private void label12_Click(object sender, EventArgs e) { }

        private void btnLupaDniEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                string dniBuscado = LeerCyberTextBox(txtDniEmpleadoBuscar);

                if (string.IsNullOrWhiteSpace(dniBuscado))
                {
                    MessageBox.Show("Por favor, ingrese un DNI para buscar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dniBuscado.Length != 8)
                {
                    MessageBox.Show("El DNI debe tener exactamente 8 números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                EmpleadoData data = new EmpleadoData();
                Empleado empleado = data.BuscarPorDNI(dniBuscado);

                if (empleado != null)
                {
                    idEmpleadoSeleccionado = empleado.IdEmpleado;
                    MessageBox.Show($"Empleado encontrado: {empleado.NombreEmpleado} {empleado.ApellidoEmpleado}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    UsuarioData usuData = new UsuarioData();
                    Usuario usuarioExistente = usuData.BuscarUsuarioPorIdEmpleado(empleado.IdEmpleado);

                    if (usuarioExistente != null)
                    {
                        idUsuarioAEditar = usuarioExistente.IdUsuario;

                        EscribirCyberTextBox(txtUsuario, usuarioExistente.NombreUsuario);
                        EscribirCyberTextBox(txtContraseña, usuarioExistente.Contraseña);
                        EscribirCyberTextBox(txtConfirmarContraseña, usuarioExistente.Contraseña);
                        cmbRol.SelectedValue = usuarioExistente.IdRol;
                    }
                    else
                    {
                        EscribirCyberTextBox(txtUsuario, "");
                        EscribirCyberTextBox(txtContraseña, "");
                        EscribirCyberTextBox(txtConfirmarContraseña, "");

                        if (cmbRol.Items.Count > 0) cmbRol.SelectedIndex = 0;

                        idUsuarioAEditar = 0;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró ningún empleado activo con ese DNI.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    idEmpleadoSeleccionado = 0;
                    idUsuarioAEditar = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarEmpleado_Click(object sender, EventArgs e)
        {
            LimpiarCamposEmpleado();
        }

        private void panel1_Click(object sender, EventArgs e) { }

        private void LimpiarCyberTextBox(ReaLTaiizor.Controls.CyberTextBox cyberCaja)
        {
            TextBox cajaReal = cyberCaja.Controls.OfType<TextBox>().FirstOrDefault();
            if (cajaReal != null)
            {
                cajaReal.Text = "";
            }
            cyberCaja.Text = "";
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreUsu = LeerCyberTextBox(txtUsuario);
                string pass = LeerCyberTextBox(txtContraseña);
                string confirmacion = LeerCyberTextBox(txtConfirmarContraseña);

                if (string.IsNullOrWhiteSpace(nombreUsu) || string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(confirmacion))
                {
                    MessageBox.Show("Todos los campos de usuario son obligatorios.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (pass != confirmacion)
                {
                    MessageBox.Show("Las contraseñas no coinciden.", "Error de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (idEmpleadoSeleccionado == 0)
                {
                    MessageBox.Show("Primero debe buscar y seleccionar un empleado con la lupa.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Usuario nuevoUsuario = new Usuario
                {
                    IdUsuario = idUsuarioAEditar,
                    NombreUsuario = nombreUsu,
                    Contraseña = pass,
                    IdRol = Convert.ToInt32(cmbRol.SelectedValue),
                    IdEmpleado = idEmpleadoSeleccionado
                };

                char operacion = (idUsuarioAEditar == 0) ? 'A' : 'M';

                UsuarioBusiness negocio = new UsuarioBusiness();
                negocio.RegistrarUsuario(nuevoUsuario, confirmacion, operacion);

                string mensajeExito = (operacion == 'A') ? "Usuario creado exitosamente." : "Usuario actualizado correctamente.";
                MessageBox.Show(mensajeExito, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCamposUsuario();

                int estadoActual = chkEstado.Checked ? 0 : 1;
                CargarGrillaEmpleados(estadoActual);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("Ese nombre de usuario ya está en uso. Por favor, elija uno diferente.", "Usuario duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Error de base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // =========================================================================
        // 1. BOTÓN NUEVO: REGISTRA UN EMPLEADO NUEVO (ALTA - 'A')
        // =========================================================================
        private void btnNuevoEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                string dni = LeerCyberTextBox(txtDniEmpleado);
                string nombre = LeerCyberTextBox(txtNombreEmpleado);
                string apellido = LeerCyberTextBox(txtApellidoEmpleado);
                string direccion = LeerCyberTextBox(txtDireccionEmpleado);
                string correo = LeerCyberTextBox(txtEmailEmpleado);
                string telefono = LeerCyberTextBox(txtTelefonoEmpleado);

                Empleado nuevoEmpleado = new Empleado
                {
                    IdEmpleado = 0, // Siempre 0 para indicar que es un registro nuevo
                    DniEmpleado = dni,
                    NombreEmpleado = nombre,
                    ApellidoEmpleado = apellido,
                    DireccionEmpleado = direccion,
                    CorreoEmpleado = correo,
                    TelefonoEmpleado = telefono
                };

                EmpleadoBusiness negocio = new EmpleadoBusiness();
                negocio.RegistrarEmpleado(nuevoEmpleado, 'A');

                MessageBox.Show("Empleado registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Autocompletar datos de usuario para agilizar el proceso
                EscribirCyberTextBox(txtDniEmpleadoBuscar, dni);
                Clipboard.SetText(dni);

                LimpiarCamposEmpleado();
                CargarGrillaEmpleados();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("Ya existe un empleado registrado con ese DNI.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Error de base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error grave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================================
        // 2. BOTÓN GUARDAR: ACTUALIZA LOS DATOS DE UN EMPLEADO (MODIFICACIÓN - 'M')
        // =========================================================================
        private void btnGuardarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que se haya seleccionado un empleado de la grilla
                if (idEmpleadoAEditar == 0)
                {
                    MessageBox.Show("Para modificar, primero debe seleccionar un empleado de la lista presionando 'Modificar'. Si desea agregar uno nuevo, use el botón 'NUEVO'.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string dni = LeerCyberTextBox(txtDniEmpleado);
                string nombre = LeerCyberTextBox(txtNombreEmpleado);
                string apellido = LeerCyberTextBox(txtApellidoEmpleado);
                string direccion = LeerCyberTextBox(txtDireccionEmpleado);
                string correo = LeerCyberTextBox(txtEmailEmpleado);
                string telefono = LeerCyberTextBox(txtTelefonoEmpleado);

                Empleado empleadoModificado = new Empleado
                {
                    IdEmpleado = idEmpleadoAEditar,
                    DniEmpleado = dni,
                    NombreEmpleado = nombre,
                    ApellidoEmpleado = apellido,
                    DireccionEmpleado = direccion,
                    CorreoEmpleado = correo,
                    TelefonoEmpleado = telefono
                };

                EmpleadoBusiness negocio = new EmpleadoBusiness();
                negocio.RegistrarEmpleado(empleadoModificado, 'M');

                MessageBox.Show("Empleado actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCamposEmpleado();
                CargarGrillaEmpleados();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("Ya existe un empleado registrado con ese DNI.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Error de base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error grave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCamposEmpleado()
        {
            LimpiarCyberTextBox(txtDniEmpleado);
            LimpiarCyberTextBox(txtNombreEmpleado);
            LimpiarCyberTextBox(txtApellidoEmpleado);
            LimpiarCyberTextBox(txtDireccionEmpleado);
            LimpiarCyberTextBox(txtEmailEmpleado);
            LimpiarCyberTextBox(txtTelefonoEmpleado);

            TextBox cajaReal = txtDniEmpleado.Controls.OfType<TextBox>().FirstOrDefault();
            if (cajaReal != null) cajaReal.Focus();

            idEmpleadoAEditar = 0; // Se resetea el ID en edición
        }

        private void LimpiarCamposUsuario()
        {
            LimpiarCyberTextBox(txtDniEmpleadoBuscar);
            LimpiarCyberTextBox(txtUsuario);
            LimpiarCyberTextBox(txtContraseña);
            LimpiarCyberTextBox(txtConfirmarContraseña);

            if (cmbRol.Items.Count > 0)
                cmbRol.SelectedIndex = 0;

            idEmpleadoSeleccionado = 0;
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

        private void txtDniEmpleadoBuscar_Load(object sender, EventArgs e) { }
        private void txtDniEmpleado_Load(object sender, EventArgs e) { }

        private void txtDniEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            var textBox = sender as ReaLTaiizor.Controls.CyberTextBox;
            if (textBox != null && textBox.TextButton != null && textBox.TextButton.Length >= 8 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FormEmpleados_Load(object sender, EventArgs e)
        {
            TextBox txtDniReal = txtDniEmpleado.Controls.OfType<TextBox>().FirstOrDefault();
            if (txtDniReal != null)
            {
                txtDniReal.MaxLength = 8;
                txtDniReal.KeyPress += TxtDniReal_KeyPress;
            }

            TextBox txtNombreReal = txtNombreEmpleado.Controls.OfType<TextBox>().FirstOrDefault();
            if (txtNombreReal != null) txtNombreReal.KeyPress += SoloLetras_KeyPress;

            TextBox txtApellidoReal = txtApellidoEmpleado.Controls.OfType<TextBox>().FirstOrDefault();
            if (txtApellidoReal != null) txtApellidoReal.KeyPress += SoloLetras_KeyPress;

            TextBox txtTelefonoReal = txtTelefonoEmpleado.Controls.OfType<TextBox>().FirstOrDefault();
            if (txtTelefonoReal != null)
            {
                txtTelefonoReal.MaxLength = 10;
                txtTelefonoReal.KeyPress += SoloNumeros_KeyPress;
            }

            TextBox txtDniLupaReal = txtDniEmpleadoBuscar.Controls.OfType<TextBox>().FirstOrDefault();
            if (txtDniLupaReal != null)
            {
                txtDniLupaReal.MaxLength = 8;
                txtDniLupaReal.KeyPress += TxtDniReal_KeyPress;
            }

            TextBox cajaDniBuscar = txtDniBuscar.Controls.OfType<TextBox>().FirstOrDefault();
            if (cajaDniBuscar != null)
            {
                cajaDniBuscar.MaxLength = 8;
                cajaDniBuscar.KeyPress += TxtDniReal_KeyPress;
                cajaDniBuscar.TextChanged += FiltroEnTiempoReal_TextChanged;
            }

            TextBox cajaNombreBuscar = txtNombreBuscar.Controls.OfType<TextBox>().FirstOrDefault();
            if (cajaNombreBuscar != null)
            {
                cajaNombreBuscar.KeyPress += SoloLetras_KeyPress;
                cajaNombreBuscar.TextChanged += FiltroEnTiempoReal_TextChanged;
            }

            CargarGrillaEmpleados();
        }

        private void FiltroEnTiempoReal_TextChanged(object sender, EventArgs e)
        {
            int estado = chkEstado.Checked ? 0 : 1;
            CargarGrillaEmpleados(estado);
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

        private void SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            TextBox cajaReal = sender as TextBox;
            if (cajaReal != null && cajaReal.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCancelarUsuario_Click(object sender, EventArgs e)
        {
            LimpiarCamposUsuario();
        }

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvEmpleados.Rows[e.RowIndex].IsNewRow || dgvEmpleados.Rows[e.RowIndex].Tag == null)
            {
                MessageBox.Show("Por favor, seleccione un empleado válido. Esta fila está vacía.", "Fila vacía", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dgvEmpleados.Columns[e.ColumnIndex].Name == "Modificar")
            {
                try
                {
                    idEmpleadoAEditar = Convert.ToInt32(dgvEmpleados.Rows[e.RowIndex].Tag);

                    string dniClickeado = dgvEmpleados.Rows[e.RowIndex].Cells["dniColum"].Value.ToString();

                    EmpleadoData data = new EmpleadoData();
                    Empleado emp = data.BuscarPorDNI(dniClickeado);

                    if (emp != null)
                    {
                        EscribirCyberTextBox(txtDniEmpleado, emp.DniEmpleado);
                        EscribirCyberTextBox(txtNombreEmpleado, emp.NombreEmpleado);
                        EscribirCyberTextBox(txtApellidoEmpleado, emp.ApellidoEmpleado);
                        EscribirCyberTextBox(txtDireccionEmpleado, emp.DireccionEmpleado);
                        EscribirCyberTextBox(txtEmailEmpleado, emp.CorreoEmpleado);
                        EscribirCyberTextBox(txtTelefonoEmpleado, emp.TelefonoEmpleado);
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron los detalles de este empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al leer datos de la grilla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (dgvEmpleados.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                int idClickeado = Convert.ToInt32(dgvEmpleados.Rows[e.RowIndex].Tag);
                string nombreEmp = dgvEmpleados.Rows[e.RowIndex].Cells[2].Value.ToString();

                int nuevoEstado = chkEstado.Checked ? 1 : 0;
                string verboPregunta = chkEstado.Checked ? "reactivar" : "dar de baja";

                DialogResult respuesta = MessageBox.Show($"¿Está seguro que desea {verboPregunta} al empleado: {nombreEmp}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    try
                    {
                        EmpleadoData data = new EmpleadoData();
                        data.CambiarEstadoEmpleado(idClickeado, nuevoEstado);

                        string verboExito = chkEstado.Checked ? "reactivado" : "dado de baja";
                        MessageBox.Show($"El empleado ha sido {verboExito} exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarGrillaEmpleados(chkEstado.Checked ? 0 : 1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CargarGrillaEmpleados(int estado = 1)
        {
            dgvEmpleados.Rows.Clear();

            EmpleadoData data = new EmpleadoData();
            List<Empleado> lista = data.ListarEmpleados(estado);

            string filtroDni = LeerCyberTextBox(txtDniBuscar).Trim();
            string filtroNombre = LeerCyberTextBox(txtNombreBuscar).Trim().ToLower();

            if (!string.IsNullOrWhiteSpace(filtroDni))
            {
                lista = lista.Where(emp => emp.DniEmpleado.Contains(filtroDni)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(filtroNombre))
            {
                lista = lista.Where(emp =>
                    emp.NombreEmpleado.ToLower().Contains(filtroNombre) ||
                    emp.ApellidoEmpleado.ToLower().Contains(filtroNombre)).ToList();
            }

            string textoBotonEliminar = (estado == 1) ? "Eliminar" : "Reactivar";

            foreach (Empleado emp in lista)
            {
                string nombreCompleto = $"{emp.NombreEmpleado} {emp.ApellidoEmpleado}";
                int indiceFila = dgvEmpleados.Rows.Add(
                    emp.Rol,
                    emp.DniEmpleado,
                    nombreCompleto,
                    emp.DireccionEmpleado,
                    emp.CorreoEmpleado,
                    emp.TelefonoEmpleado,
                    "Modificar",
                    textoBotonEliminar
                );
                dgvEmpleados.Rows[indiceFila].Tag = emp.IdEmpleado;
            }

            EscribirCyberTextBox(txtCantidadEmpleados, lista.Count.ToString());
        }

        private void label18_Click(object sender, EventArgs e) { }
        private void panel3_Click(object sender, EventArgs e) { }

        private void chkEstado_Click(object sender, EventArgs e)
        {
            int estado = chkEstado.Checked ? 1 : 0;
            CargarGrillaEmpleados(estado);
        }
    }
}