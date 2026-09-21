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
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Linq;
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
            // Creamos una lista de "pares" (ID, Nombre)
            var roles = new System.Collections.Generic.List<KeyValuePair<int, string>>()
        {
        new KeyValuePair<int, string>(1, "Administrador"),
        new KeyValuePair<int, string>(2, "Vendedor"),
        new KeyValuePair<int, string>(3, "Gerente")
        };

            // Le decimos al ComboBox de dónde sacar los datos
            cmbRol.DataSource = roles;

            // Le decimos qué debe mostrarle al usuario (El texto)
            cmbRol.DisplayMember = "Value";

            // Le decimos qué debe guardar invisiblemente por detrás (El ID numérico)
            cmbRol.ValueMember = "Key";
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

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

                // Validación para que el DNI tenga 8 caracteres y solo números
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

                    // --- NUEVA LÓGICA: Buscar credenciales del usuario ---
                    UsuarioData usuData = new UsuarioData();
                    Usuario usuarioExistente = usuData.BuscarUsuarioPorIdEmpleado(empleado.IdEmpleado);

                    if (usuarioExistente != null)
                    {
                        // MODO EDICIÓN: El empleado ya tiene usuario. Cargamos los datos.
                        idUsuarioAEditar = usuarioExistente.IdUsuario;

                        EscribirCyberTextBox(txtUsuario, usuarioExistente.NombreUsuario);
                        EscribirCyberTextBox(txtContraseña, usuarioExistente.Contraseña);
                        EscribirCyberTextBox(txtConfirmarContraseña, usuarioExistente.Contraseña);
                        cmbRol.SelectedValue = usuarioExistente.IdRol;
                    }
                    else
                    {
                        // MODO ALTA: El empleado no tiene usuario. Limpiamos las cajas.
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
                    idUsuarioAEditar = 0; // Reseteamos por seguridad
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

        private void panel1_Click(object sender, EventArgs e)
        {

        }

        private void LimpiarCyberTextBox(ReaLTaiizor.Controls.CyberTextBox cyberCaja)
        {
            // Buscamos la cajita invisible y la vaciamos
            TextBox cajaReal = cyberCaja.Controls.OfType<TextBox>().FirstOrDefault();
            if (cajaReal != null)
            {
                cajaReal.Text = "";
            }
            cyberCaja.Text = ""; // Por las dudas vaciamos también la capa visual
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreUsu = LeerCyberTextBox(txtUsuario);
                string pass = LeerCyberTextBox(txtContraseña);
                string confirmacion = LeerCyberTextBox(txtConfirmarContraseña);

                // Validar que no haya campos vacíos
                if (string.IsNullOrWhiteSpace(nombreUsu) || string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(confirmacion))
                {
                    MessageBox.Show("Todos los campos de usuario son obligatorios.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que las contraseñas coincidan
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

                // 1. Agregamos el IdUsuario para que sepa de quién se trata
                Usuario nuevoUsuario = new Usuario
                {
                    IdUsuario = idUsuarioAEditar, // 0 = Nuevo, >0 = Modificación
                    NombreUsuario = nombreUsu,
                    Contraseña = pass,
                    IdRol = Convert.ToInt32(cmbRol.SelectedValue),
                    IdEmpleado = idEmpleadoSeleccionado
                };

                // 2. Definimos si es Alta ('A') o Modificación ('M')
                char operacion = (idUsuarioAEditar == 0) ? 'A' : 'M';

                UsuarioBusiness negocio = new UsuarioBusiness();
                // 3. ¡Asegúrate de actualizar la capa de Negocio para que acepte este tercer parámetro!
                negocio.RegistrarUsuario(nuevoUsuario, confirmacion, operacion);

                // 4. Mensaje dinámico según lo que acabamos de hacer
                string mensajeExito = (operacion == 'A') ? "Usuario creado exitosamente." : "Usuario actualizado correctamente.";
                MessageBox.Show(mensajeExito, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCamposUsuario();

                // Recargamos la grilla para ver al usuario modificado/agregado al instante
                int estadoActual = chkEstado.Checked ? 0 : 1;
                CargarGrillaEmpleados(estadoActual);
            }
            catch (SqlException ex) // 5. Atrapamos errores específicos de SQL Server PRIMERO
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
            catch (Exception ex) // 6. Atrapamos cualquier otro error de C# DESPUÉS
            {
                MessageBox.Show(ex.Message, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuardarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Capturamos los datos que escribió el usuario
                string dni = LeerCyberTextBox(txtDniEmpleado);
                string nombre = LeerCyberTextBox(txtNombreEmpleado);
                string apellido = LeerCyberTextBox(txtApellidoEmpleado);
                string direccion = LeerCyberTextBox(txtDireccionEmpleado);
                string correo = LeerCyberTextBox(txtEmailEmpleado);
                string telefono = LeerCyberTextBox(txtTelefonoEmpleado);

                // 2. Empaquetamos la información en nuestro "molde" (Entidad)
                Empleado empleadoProcesado = new Empleado
                {
                    IdEmpleado = idEmpleadoAEditar, // Si apretas Limpiar será 0, si tocas la grilla tendrá el ID real
                    DniEmpleado = dni,
                    NombreEmpleado = nombre,
                    ApellidoEmpleado = apellido,
                    DireccionEmpleado = direccion,
                    CorreoEmpleado = correo,
                    TelefonoEmpleado = telefono
                };

                // LÓGICA INTELIGENTE: ¿Es Alta o Modificación?
                char operacion = (idEmpleadoAEditar == 0) ? 'A' : 'M';

                // 3. Le pasamos toda la responsabilidad al "Cerebro" (Capa Business)
                EmpleadoBusiness negocio = new EmpleadoBusiness();
                negocio.RegistrarEmpleado(empleadoProcesado, operacion);

                // 4. Si todo salió bien, mostramos el mensaje y actualizamos visualmente
                string mensaje = (operacion == 'A') ? "Empleado registrado exitosamente." : "Empleado actualizado correctamente.";
                MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 
                // Se Autocompleta la caja de búsqueda en la sección "Datos de Usuario"
                EscribirCyberTextBox(txtDniEmpleadoBuscar, dni);

                // Se copia el DNI al portapapeles de Windows 
                Clipboard.SetText(dni);
                // ----------------------------------------

                LimpiarCamposEmpleado();
                CargarGrillaEmpleados(); // Actualizamos la tabla visual
            }
            catch (ArgumentException ex) // Atrapamos los errores de reglas de negocio (ej. DNI de 7 números)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException ex) // Atrapamos los errores específicos de la Base de Datos (ej. DNI repetido)
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
            catch (Exception ex) // Atrapamos cualquier otro error grave no contemplado
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

            // Enfocamos la caja real escondida del DNI
            TextBox cajaReal = txtDniEmpleado.Controls.OfType<TextBox>().FirstOrDefault();
            if (cajaReal != null) cajaReal.Focus();

            idEmpleadoAEditar = 0; // Reseteamos el modo edición
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

        /* Lee los campos de texto de un CyberTextBox, considerando que la caja real está escondida dentro del control. 
         * Esto es necesario porque el CyberTextBox de ReaLTaiizor tiene una capa visual que no siempre se ve.
        */
        private string LeerCyberTextBox(ReaLTaiizor.Controls.CyberTextBox cyberCaja)
        {
            // Buscamos la caja de texto nativa escondida dentro del diseño
            TextBox cajaReal = cyberCaja.Controls.OfType<TextBox>().FirstOrDefault();
            // Si la encuentra, devuelve su texto. Si no, intenta leer la propiedad normal.
            return cajaReal != null ? cajaReal.Text.Trim() : cyberCaja.Text.Trim();
        }

        // Escribe en un CyberTextBox, considerando que la caja real está escondida dentro del control.
        private void EscribirCyberTextBox(ReaLTaiizor.Controls.CyberTextBox cyberCaja, string texto)
        {
            // Buscamos la cajita invisible y le inyectamos el texto
            TextBox cajaReal = cyberCaja.Controls.OfType<TextBox>().FirstOrDefault();
            if (cajaReal != null)
            {
                cajaReal.Text = texto;
            }
            cyberCaja.Text = texto; // Capa visual
        }

        private void txtDniEmpleadoBuscar_Load(object sender, EventArgs e)
        {

        }

        private void txtDniEmpleado_Load(object sender, EventArgs e)
        {

        }

        private void txtDniEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 1. Bloquear letras y símbolos (Solo permitimos números y la tecla de borrar 'Backspace')
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Esto "mata" la tecla pulsada; no se escribirá nada.
            }

            // 2. Limitar a máximo 8 caracteres
            // Convertimos el "sender" a CyberTextBox para poder leer su texto actual
            var textBox = sender as ReaLTaiizor.Controls.CyberTextBox;

            // Si ya hay 8 caracteres y el usuario intenta escribir un 9no (que no sea borrar)...
            if (textBox != null && textBox.TextButton != null && textBox.TextButton.Length >= 8 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloqueamos la tecla
            }
        }

        private void FormEmpleados_Load(object sender, EventArgs e)
        {
            // --- PANEL: DATOS DEL EMPLEADO ---

            // Validar DNI: Solo números y 8 caracteres
            TextBox txtDniReal = txtDniEmpleado.Controls.OfType<TextBox>().FirstOrDefault();
            if (txtDniReal != null)
            {
                txtDniReal.MaxLength = 8;
                txtDniReal.KeyPress += TxtDniReal_KeyPress;
            }

            // 2. Nombre/s y Apellido/s: Solo letras
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


            // --- PANEL: DATOS DE USUARIO ---

            //  Validación del DNI del empleado en la busqueda (Lupa): Solo números y 8 caracteres
            TextBox txtDniLupaReal = txtDniEmpleadoBuscar.Controls.OfType<TextBox>().FirstOrDefault();
            if (txtDniLupaReal != null)
            {
                txtDniLupaReal.MaxLength = 8;
                txtDniLupaReal.KeyPress += TxtDniReal_KeyPress;
            }


            // --- PANEL: BUSCAR EMPLEADO ---

            // Validación del DNI en la busqueda de empleados: Solo números, 8 caracteres + Filtro en vivo
            TextBox cajaDniBuscar = txtDniBuscar.Controls.OfType<TextBox>().FirstOrDefault();
            if (cajaDniBuscar != null)
            {
                cajaDniBuscar.MaxLength = 8;
                cajaDniBuscar.KeyPress += TxtDniReal_KeyPress;
                cajaDniBuscar.TextChanged += FiltroEnTiempoReal_TextChanged;
            }

            // 5. Nombre Filtro: Solo letras + Filtro en vivo
            TextBox cajaNombreBuscar = txtNombreBuscar.Controls.OfType<TextBox>().FirstOrDefault();
            if (cajaNombreBuscar != null)
            {
                cajaNombreBuscar.KeyPress += SoloLetras_KeyPress;
                cajaNombreBuscar.TextChanged += FiltroEnTiempoReal_TextChanged;
            }


            // Cargar la tabla al iniciar
            CargarGrillaEmpleados();
        }

        private void FiltroEnTiempoReal_TextChanged(object sender, EventArgs e)
        {
            int estado = chkEstado.Checked ? 0 : 1;
            CargarGrillaEmpleados(estado);
        }

        // Bloqueador de letras para campos 
        private void TxtDniReal_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 1. Bloqueamos letras
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            // 2. Forzamos el límite de 8 números en vivo leyendo la caja real
            TextBox cajaReal = sender as TextBox;
            if (cajaReal != null && cajaReal.Text.Length >= 8 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        // Bloqueador de números y símbolos para campos de texto que solo aceptan letras (Usado en campos de nombre o apellido)
        private void SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir letras, teclas de control (como Backspace) y espacios (para nombres compuestos)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla pulsada (números o símbolos)
            }
        }


        // Bloqueador de letras y símbolos con límite de 10 caracteres (Usado en campo teléfono)
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 1. Permitimos números y teclas de control (como borrar), bloqueamos todo lo demás
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return; // Detenemos la ejecución aquí
            }

            // 2. Forzamos el límite de 10 números en vivo leyendo la caja real
            TextBox cajaReal = sender as TextBox;
            if (cajaReal != null && cajaReal.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla si ya llegó a 10 caracteres
            }
        }


        // Limpiar campos de usuario
        private void btnCancelarUsuario_Click(object sender, EventArgs e)
        {
            LimpiarCamposUsuario();
        }


        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Evitamos errores si hace clic en los encabezados de las columnas (RowIndex -1)
            if (e.RowIndex < 0) return;

            // 2. Verificamos si la fila está vacía
            if (dgvEmpleados.Rows[e.RowIndex].IsNewRow || dgvEmpleados.Rows[e.RowIndex].Tag == null)
            {
                MessageBox.Show("Por favor, seleccione un empleado válido. Esta fila está vacía.", "Fila vacía", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // --- LÓGICA PARA COLUMNA MODIFICAR ---
            if (dgvEmpleados.Columns[e.ColumnIndex].Name == "Modificar")
            {
                try
                {
                    idEmpleadoAEditar = Convert.ToInt32(dgvEmpleados.Rows[e.RowIndex].Tag);

                    // Asumo que "dniColum" es el nombre interno de tu segunda columna (ajusta si es distinto)
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
            // --- LÓGICA PARA COLUMNA ELIMINAR / REACTIVAR ---
            else if (dgvEmpleados.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                int idClickeado = Convert.ToInt32(dgvEmpleados.Rows[e.RowIndex].Tag);

                // Asumo que el "Nom y Ape" está en la columna índice 2 visualmente
                string nombreEmp = dgvEmpleados.Rows[e.RowIndex].Cells[2].Value.ToString();

                // Evaluamos qué acción estamos haciendo basados en el switch
                int nuevoEstado = chkEstado.Checked ? 1 : 0;
                string verboPregunta = chkEstado.Checked ? "reactivar" : "dar de baja";

                // 2. Hacemos la pregunta con la gramática correcta
                DialogResult respuesta = MessageBox.Show($"¿Está seguro que desea {verboPregunta} al empleado: {nombreEmp}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    try
                    {
                        EmpleadoData data = new EmpleadoData();
                        data.CambiarEstadoEmpleado(idClickeado, nuevoEstado);

                        // 3. Definimos el verbo en participio para el cartel de éxito
                        string verboExito = chkEstado.Checked ? "reactivado" : "dado de baja";

                        MessageBox.Show($"El empleado ha sido {verboExito} exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refrescamos la grilla manteniendo el filtro en el que estábamos
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

            // 1. Leemos lo que el usuario está escribiendo en el buscador
            string filtroDni = LeerCyberTextBox(txtDniBuscar).Trim();
            string filtroNombre = LeerCyberTextBox(txtNombreBuscar).Trim().ToLower();

            // 2. FILTRO INTELIGENTE (LINQ): Achicamos la lista según lo escrito
            if (!string.IsNullOrWhiteSpace(filtroDni))
            {
                lista = lista.Where(emp => emp.DniEmpleado.Contains(filtroDni)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(filtroNombre))
            {
                // Filtramos por nombre o apellido
                lista = lista.Where(emp =>
                    emp.NombreEmpleado.ToLower().Contains(filtroNombre) ||
                    emp.ApellidoEmpleado.ToLower().Contains(filtroNombre)).ToList();
            }

            // 3. Cargamos la grilla con la lista ya filtrada
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

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Click(object sender, EventArgs e)
        {

        }

        private void chkEstado_Click(object sender, EventArgs e)
        {

            // 2. Evaluamos el valor y actualizamos la grilla
            int estado = chkEstado.Checked ? 1 : 0;
            CargarGrillaEmpleados(estado);
        }
    }
}
