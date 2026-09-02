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
            // Llama a la clase del sidebar que diseñaste
            menuPrincipal menu = new menuPrincipal();
            menu.Show();

            // Oculta la ventana de login
            this.Hide();
        }
    }
}
