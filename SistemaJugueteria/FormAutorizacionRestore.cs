using SistemaJugueteria.Business;
using SistemaJugueteria.Entities;
using SistemaJugueteria.Presentacion.Utilidades;
using System;
using System.Windows.Forms;

namespace SistemaJugueteria
{
    public partial class FormAutorizacionRestore : Form
    {
        private UsuarioBusiness _usuarioBusiness = new UsuarioBusiness();
        private bool _faseUnoCompletada = false; // Bandera para controlar el paso actual
        private Usuario _usuarioActual; // Guarda al usuario del primer paso

        public FormAutorizacionRestore()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Bloqueamos los campos del gerente al abrir la ventana
            txtGerenteUsuario.Enabled = false;
            txtGerentePin.Enabled = false;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                // PASO 1: Validar primero la contraseña de la cuenta actual
                if (!_faseUnoCompletada)
                {
                    string passUsuarioActual = txtAdminContraseña.TextButton.Trim();

                    if (string.IsNullOrEmpty(passUsuarioActual))
                    {
                        MessageBox.Show("Debe ingresar la contraseña de su cuenta primero.", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    _usuarioActual = _usuarioBusiness.AutenticarUsuario(Sesion.NombreUsuario, passUsuarioActual);

                    if (_usuarioActual == null)
                    {
                        MessageBox.Show("Tu contraseña actual es incorrecta.", "Verificación Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Éxito en Fase 1: Desbloqueamos los campos inferiores
                    _faseUnoCompletada = true;
                    txtAdminContraseña.Enabled = false; // Bloqueamos este para que no lo cambie
                    txtGerenteUsuario.Enabled = true;
                    txtGerentePin.Enabled = true;

                    MessageBox.Show("Identidad verificada. Ahora ingrese los datos del autorizador.", "Paso 1 Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtGerenteUsuario.Focus();
                }
                // PASO 2: Validar usuario y PIN del autorizador
                else
                {
                    string userAutorizador = txtGerenteUsuario.TextButton.Trim();
                    string pinAutorizador = txtGerentePin.TextButton.Trim(); // Ahora este campo es el PIN

                    if (string.IsNullOrEmpty(userAutorizador) || string.IsNullOrEmpty(pinAutorizador))
                    {
                        MessageBox.Show("Debe completar los campos del autorizador.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 2. Validar que el autorizador haya ingresado el PIN correcto
                    Usuario autorizador = _usuarioBusiness.ValidarPinAutorizacion(userAutorizador, pinAutorizador);
                    if (autorizador == null)
                    {
                        MessageBox.Show("El usuario o PIN de autorización son incorrectos.", "Doble Factor Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    /* 3 Regla de seguridad: Evitar auto-autorización
                    if (_usuarioActual.IdUsuario == autorizador.IdUsuario)
                    {
                        MessageBox.Show("La validación de doble factor requiere la autorización de dos usuarios diferentes.", "Acción denegada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    */

                    // 4. Verificar jerarquía del autorizador (IdRol 1 = Admin, IdRol 3 = Gerente)

                    if (autorizador.IdRol != 1 && autorizador.IdRol != 3)
                    {
                        MessageBox.Show("El usuario autorizador no cuenta con rango jerárquico suficiente.", "Permisos insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error de Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtAdminContraseña_Load(object sender, EventArgs e)
        {

        }

        private void FormAutorizacionRestore_Load(object sender, EventArgs e)
        {

        }
    }
}