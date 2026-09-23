using System;
using System.Linq;
using System.Windows.Forms;
using SistemaJugueteria.Business;
using SistemaJugueteria.Entities;
using SistemaJugueteria.Presentacion.Utilidades;

namespace SistemaJugueteria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void hopeButton1_Click(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void hopeTextBox2_Click(object sender, EventArgs e) { }
        private void bigLabel2_Click(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }

        private void hopeButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string usuarioInput = txtUsuario.Text;
                string contraseñaInput = txtContraseña.Text;

                UsuarioBusiness negocioUsuario = new UsuarioBusiness();

                // 1. Validar autenticación
                Usuario usuarioLogueado = negocioUsuario.AutenticarUsuario(usuarioInput, contraseñaInput);

                if (usuarioLogueado != null)
                {
                    // 2. Cargar sesión
                    Sesion.IdUsuario = usuarioLogueado.IdUsuario;
                    Sesion.NombreUsuario = usuarioLogueado.NombreUsuario;
                    Sesion.IdRol = usuarioLogueado.IdRol;

                    try
                    {
                        SistemaJugueteria.Data.EmpleadoData dataEmpleado = new SistemaJugueteria.Data.EmpleadoData();
                        var listaEmpleados = dataEmpleado.ListarEmpleados(1);
                        var empleado = listaEmpleados.FirstOrDefault(emp => emp.IdEmpleado == usuarioLogueado.IdEmpleado);

                        if (empleado != null)
                        {
                            Sesion.NombreCompleto = $"{empleado.NombreEmpleado} {empleado.ApellidoEmpleado}";
                            Sesion.Dni = empleado.DniEmpleado;
                        }
                        else
                        {
                            Sesion.NombreCompleto = usuarioLogueado.NombreUsuario;
                            Sesion.Dni = "-";
                        }
                    }
                    catch
                    {
                        Sesion.NombreCompleto = usuarioLogueado.NombreUsuario;
                        Sesion.Dni = "-";
                    }

                    MessageBox.Show($"Bienvenido, {Sesion.NombreCompleto}", "Acceso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 3. Abrir Menú Principal
                    menuPrincipal menu = new menuPrincipal(usuarioLogueado);
                    menu.Show();

                    txtUsuario.Text = "";
                    txtContraseña.Text = "";

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtContraseña.Text = "";
                    txtContraseña.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}