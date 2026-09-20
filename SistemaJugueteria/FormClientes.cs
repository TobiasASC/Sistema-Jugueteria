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
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();

            Validaciones.ConfigurarNumerosLongitud(txtDniCliente, 8);
            Validaciones.ConfigurarSoloLetras(txtNombreCliente);
            Validaciones.ConfigurarSoloLetras(txtApellidoCliente);
            Validaciones.ConfigurarEmail(txtEmailCliente);

            Validaciones.ConfigurarNumerosLongitud(txtDniClienteBuscar, 8);
            Validaciones.ConfigurarSoloLetras(txtNombreClienteBuscar);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void hopeTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void cyberTextBox10_Load(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Limpiamos el texto de los controles CyberTextBox
            txtDniCliente.TextButton = "";
            txtNombreCliente.TextButton = "";
            txtApellidoCliente.TextButton = "";
            txtEmailCliente.TextButton = "";
            txtDireccionCliente.TextButton = "";


            // Llevamos el cursor al campo DNI para que el usuario empiece a tipear rápido
            txtDniCliente.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validar que NINGÚN campo esté vacío (usando solo .TextButton)
            if (string.IsNullOrWhiteSpace(txtDniCliente.TextButton) ||
                string.IsNullOrWhiteSpace(txtNombreCliente.TextButton) ||
                string.IsNullOrWhiteSpace(txtApellidoCliente.TextButton) ||
                string.IsNullOrWhiteSpace(txtEmailCliente.TextButton) ||
                string.IsNullOrWhiteSpace(txtDireccionCliente.TextButton))
            // Si tienes el campo de puntos, agrégalo así: || string.IsNullOrWhiteSpace(txtPuntosCliente.TextButton)
            {
                MessageBox.Show("Todos los campos son obligatorios. Por favor, complete la información faltante.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Frena la ejecución aquí, no sigue simulando el guardado
            }

            // 2. Simular el guardado exitoso
            MessageBox.Show("¡Cliente agregado con éxito!", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 3. Reutilizar el código del botón "Nuevo" para limpiar la pantalla automáticamente
            btnNuevo_Click(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Validar que haya al menos un DNI cargado en pantalla para "eliminar"
            if (string.IsNullOrWhiteSpace(txtDniCliente.TextButton))
            {
                MessageBox.Show("Por favor, seleccione un cliente o ingrese un DNI para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Preguntar al usuario para confirmar la acción
            DialogResult respuesta = MessageBox.Show("¿Está seguro que desea eliminar este cliente?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Si el usuario hace clic en "Sí", procedemos
            if (respuesta == DialogResult.Yes)
            {
                MessageBox.Show("Cliente eliminado correctamente.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiamos la pantalla tras eliminar
                btnNuevo_Click(sender, e);
            }
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {

        }
    }
}
