using SistemaJugueteria.Business;
using SistemaJugueteria.Entities;

namespace SistemaJugueteria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void hopeButton1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void hopeTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void bigLabel2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void hopeButton1_Click_1(object sender, EventArgs e)
        {


            try
            {
                string usuarioInput = txtUsuario.Text;
                string contraseñaInput = txtContraseña.Text;

                UsuarioBusiness negocio = new UsuarioBusiness();

                // Llamamos a la capa de negocio. Si hay campos vacíos, esto lanzará una excepción 
                // y saltará directamente al bloque catch, cancelando el resto del proceso.
                Usuario usuarioLogueado = negocio.AutenticarUsuario(usuarioInput, contraseñaInput);

                // Si la base de datos encontró al usuario, usuarioLogueado tendrá datos. Si no, será null.
                if (usuarioLogueado != null)
                {
                    MessageBox.Show($"Bienvenido, {usuarioLogueado.NombreUsuario}", "Acceso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // SOLO SI EL USUARIO ES CORRECTO se abre el menú principal
                    menuPrincipal menu = new menuPrincipal(usuarioLogueado);

                    menu.Show();


                    txtUsuario.Text = "";
                    txtContraseña.Text = "";

                    // Oculta la ventana de login
                    this.Hide();
                }
                else
                {
                    // El usuario no existe o la clave es incorrecta
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Opcional: Limpiar la contraseña para que el usuario vuelva a intentar
                    txtContraseña.Text = "";
                    txtContraseña.Focus();
                }
            }
            catch (Exception ex)
            {
                // Captura los errores de validación de campos vacíos (ArgumentException) 
                // o los errores de conexión de Data (Exception)
                MessageBox.Show(ex.Message, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
