using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaJugueteria
{
    public partial class menuPrincipal : Form
    {
        public menuPrincipal()
        {
            InitializeComponent();
        }

        // Variable para recordar qué formulario está abierto actualmente
        private Form formularioActivo = null;

        private void AbrirFormularioHijo(Form nuevoFormulario)
        {
            // Si ya hay un formulario abierto, lo cerramos
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            // Asignamos el nuevo formulario
            formularioActivo = nuevoFormulario;

            // Le quitamos los bordes de ventana clásica para que parezca un control interno
            nuevoFormulario.TopLevel = false;
            nuevoFormulario.FormBorderStyle = FormBorderStyle.None;

            // Hacemos que rellene todo el panel gris
            nuevoFormulario.Dock = DockStyle.Fill;

            // Lo agregamos al panel gris y lo mostramos
            panelContenedor.Controls.Add(nuevoFormulario);
            panelContenedor.Tag = nuevoFormulario;
            nuevoFormulario.BringToFront();
            nuevoFormulario.Show();
        }

        private void crownDockPanel1_Load(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            // Llama al método y le pasa una nueva instancia de tu vista de Ventas
            AbrirFormularioHijo(new FormEmpleados());
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            // Llama al método y le pasa una nueva instancia de tu vista de Ventas
            AbrirFormularioHijo(new FormVentas());

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormProductos());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormClientes());
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormPedidos());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormReportes());
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormBackup());
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            // 1. Calculamos cuánto espacio roban las líneas separadoras.
            // Si tienes 7 líneas y les pusiste 1 píxel de alto a cada una, el total es 7.
            // (Si les pusiste 2 píxeles de alto, cambia este número a 14).
            int altoTotalLineas = 21;

            // 2. Le restamos esas líneas al alto total del panel y ahora sí dividimos
            int altoDisponible = panel1.Height - altoTotalLineas;
            int altoBoton = altoDisponible / 8;

            // 3. Aplicamos el nuevo alto a todos los botones
            btnEmpleados.Height = altoBoton;
            btnVentas.Height = altoBoton;
            btnProductos.Height = altoBoton;
            btnClientes.Height = altoBoton;
            btnPedidos.Height = altoBoton;
            btnReportes.Height = altoBoton;
            btnBackup.Height = altoBoton;
            btnSalir.Height = altoBoton;
        }
    }
}

