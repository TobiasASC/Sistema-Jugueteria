using SistemaJugueteria.Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaJugueteria
{
    public partial class FormModalPago : Form
    {
        private MetodoPagoBusiness negocioMetodoPago = new MetodoPagoBusiness();

        // Propiedad pública que guardará la ID elegida para que la lea FormVentas
        public int IdMetodoPagoSeleccionado { get; private set; } = 0;

        public FormModalPago()
        {
            InitializeComponent();
            CargarMetodosPago(); 
        }

        private void FormModalPago_Load(object sender, EventArgs e)
        {
            CargarMetodosPago();
        }

        private void CargarMetodosPago()
        {
            try
            {
                DataTable dt = negocioMetodoPago.ListarMetodosPago();
                cbMetodoPagoModal.DataSource = dt;
                cbMetodoPagoModal.DisplayMember = "descripcion_metodo";
                cbMetodoPagoModal.ValueMember = "id_metodo_pago";
                cbMetodoPagoModal.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar métodos de pago: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento del botón CONFIRMAR (cyberButton7)
        private void cyberButton7_Click(object sender, EventArgs e)
        {
            if (cbMetodoPagoModal.SelectedIndex == -1 || cbMetodoPagoModal.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un método de pago antes de continuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Guardamos la ID del método seleccionado
            IdMetodoPagoSeleccionado = Convert.ToInt32(cbMetodoPagoModal.SelectedValue);

            // Marcamos el resultado como OK y cerramos el modal
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}