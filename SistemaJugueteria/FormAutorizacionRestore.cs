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

        public FormAutorizacionRestore()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string passUsuarioActual = txtAdminContraseña.TextButton.Trim();
            string userAutorizador = txtGerenteUsuario.TextButton.Trim();
            string pinAutorizador = txtGerenteContraseña.TextButton.Trim(); // Ahora este campo es el PIN

            if (string.IsNullOrEmpty(passUsuarioActual) || string.IsNullOrEmpty(userAutorizador) || string.IsNullOrEmpty(pinAutorizador))
            {
                MessageBox.Show("Debe completar todos los campos de seguridad.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Validar la contraseña del usuario que inició el proceso
                Usuario usuarioActual = _usuarioBusiness.AutenticarUsuario(Sesion.NombreUsuario, passUsuarioActual);
                if (usuarioActual == null)
                {
                    MessageBox.Show("Tu contraseña actual es incorrecta.", "Doble Factor Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. Validar que el autorizador haya ingresado el PIN correcto (Llamamos al NUEVO método)
                Usuario autorizador = _usuarioBusiness.ValidarPinAutorizacion(userAutorizador, pinAutorizador);
                if (autorizador == null)
                {
                    MessageBox.Show("El usuario o PIN de autorización son incorrectos.", "Doble Factor Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                /* 3 Regla de seguridad: Evitar auto-autorización
                if (usuarioActual.IdUsuario == autorizador.IdUsuario)
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
