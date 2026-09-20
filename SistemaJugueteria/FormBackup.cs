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

            Validaciones.ConfigurarNumerosLongitud(numeroBackup, 5);
            Validaciones.ConfigurarSoloNumeros(numeroBackupBuscar); 
        }


        private void panel2_Click(object sender, EventArgs e)
        {

        }
    }
}
