using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace SistemaJugueteria.Presentacion.Utilidades
{
    public static class Validaciones
    {
        // --- TUS MÉTODOS ORIGINALES SE QUEDAN IGUAL ---
        public static void SoloNumeros(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        public static void SoloLetras(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)) e.Handled = true;
        }

        public static void SoloDecimales(KeyPressEventArgs e, TextBox txt)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ',')) e.Handled = true;
            if (e.KeyChar == '.') e.KeyChar = ',';
            if ((e.KeyChar == ',') && (txt.Text.IndexOf(',') > -1)) e.Handled = true;
        }

        // --- NUEVOS MÉTODOS ESPECIALES PARA CYBERTEXTBOX ---

        public static void ConfigurarSoloNumeros(Control cyberTextBox)
        {
            // Busca el TextBox real dentro del diseño de ReaLTaiizor
            foreach (Control c in cyberTextBox.Controls)
            {
                if (c is TextBox txtReal)
                {
                    txtReal.KeyPress += (s, e) => SoloNumeros(e);
                    break;
                }
            }
        }

        public static void ConfigurarSoloLetras(Control cyberTextBox)
        {
            foreach (Control c in cyberTextBox.Controls)
            {
                if (c is TextBox txtReal)
                {
                    txtReal.KeyPress += (s, e) => SoloLetras(e);
                    break;
                }
            }
        }

        public static void ConfigurarSoloDecimales(Control cyberTextBox)
        {
            foreach (Control c in cyberTextBox.Controls)
            {
                if (c is TextBox txtReal)
                {
                    txtReal.KeyPress += (s, e) => SoloDecimales(e, txtReal);
                    break;
                }
            }
        }


        // Método para limitar cantidad de números (Ideal para DNI)
        public static void ConfigurarNumerosLongitud(Control cyberTextBox, int longitudMaxima = 8)
        {
            foreach (Control c in cyberTextBox.Controls)
            {
                if (c is TextBox txtReal)
                {
                    // Mantenemos esta línea por si la librería se actualiza en el futuro
                    txtReal.MaxLength = longitudMaxima;

                    // Aplicamos la validación manual de números y de límite de longitud
                    txtReal.KeyPress += (s, e) =>
                    {
                        // 1. Permitimos teclas de control (como Retroceso/Borrar)
                        if (char.IsControl(e.KeyChar))
                        {
                            return;
                        }

                        // 2. Si la tecla NO es un dígito, la bloqueamos
                        if (!char.IsDigit(e.KeyChar))
                        {
                            e.Handled = true;
                            return;
                        }

                        // 3. Si ya llegó al límite máximo (ej. 8), bloqueamos cualquier número nuevo
                        if (txtReal.Text.Length >= longitudMaxima)
                        {
                            e.Handled = true;
                        }
                    };
                    break;
                }
            }
        }

        // Método para validar el formato del correo al terminar de escribir
        public static void ConfigurarEmail(Control cyberTextBox)
        {
            foreach (Control c in cyberTextBox.Controls)
            {
                if (c is TextBox txtReal)
                {
                    // El evento Leave ocurre cuando el usuario quita el cursor del TextBox
                    txtReal.Leave += (s, e) =>
                    {
                        // Solo validamos si escribió algo (no obligamos a llenarlo aquí, eso lo hace el botón Guardar)
                        if (!string.IsNullOrWhiteSpace(txtReal.Text) && !EsEmailValido(txtReal.Text))
                        {
                            MessageBox.Show("Por favor, ingrese un formato de correo electrónico válido.\nEjemplo: usuario@dominio.com",
                                            "Correo Inválido",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);

                            txtReal.Focus(); // Regresa el cursor al campo para que lo corrija
                        }
                    };
                    break;
                }
            }
        }

        // Método interno que usa Regex para verificar que el texto tenga un @ y un .
        public static bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            // Patrón que exige: [texto] @ [texto] . [texto]
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            return Regex.IsMatch(email, patron);
        }
    }
}

