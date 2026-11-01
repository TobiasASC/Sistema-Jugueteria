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
    public partial class FormConfigurarPin : Form
    {
        private UsuarioBusiness _usuarioBusiness = new UsuarioBusiness();

        public FormConfigurarPin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }





        private void FormConfigurarPin_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            string nuevoPin = txtNuevoPin.TextButton.Trim();
            string confirmarPin = txtConfirmarPin.TextButton.Trim();

            try
            {

                string mensaje = _usuarioBusiness.ConfigurarNuevoPin(Sesion.IdUsuario, nuevoPin, confirmarPin);

                MessageBox.Show(mensaje, "PIN Configurado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
