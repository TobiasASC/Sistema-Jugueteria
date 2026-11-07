using SistemaJugueteria.Business;
using SistemaJugueteria.Entities;
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
    public partial class FormVerificarContraseñaBackup : Form
    {
        private UsuarioBusiness _usuarioBusiness = new UsuarioBusiness();

        // Único constructor con toda la configuración unificada
        public FormVerificarContraseñaBackup()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Mostrar de quién estamos pidiendo la clave
            this.Text = $"Verificar identidad - {Sesion.NombreUsuario}";
        }

        private void FormVerificarContraseña_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Usa .TextButton si es un CyberTextBox, o .Text si es un TextBox normal
            string password = txtContraseña.TextButton.Trim();

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Debe ingresar su contraseña.", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificamos si la contraseña ingresada coincide con la del usuario logueado
            Usuario usuarioValido = _usuarioBusiness.AutenticarUsuario(Sesion.NombreUsuario, password);

            if (usuarioValido != null)
            {
                // Contraseña correcta
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta. Verifique e intente nuevamente.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}