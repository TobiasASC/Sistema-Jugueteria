using Entities;
using SistemaJugueteria.Data;
using SistemaJugueteria.Entities;
using System;
using System.Data;
using System.Text.RegularExpressions;
//3
namespace SistemaJugueteria.Business
{
    public class EmpleadoBusiness
    {
        public void RegistrarEmpleado(Empleado empleado, char operacion)
        {
            // Validación de que NINGÚN campo este vacio
            if (string.IsNullOrWhiteSpace(empleado.DniEmpleado) ||
                string.IsNullOrWhiteSpace(empleado.NombreEmpleado) ||
                string.IsNullOrWhiteSpace(empleado.ApellidoEmpleado) ||
                string.IsNullOrWhiteSpace(empleado.DireccionEmpleado) ||
                string.IsNullOrWhiteSpace(empleado.CorreoEmpleado) ||
                string.IsNullOrWhiteSpace(empleado.TelefonoEmpleado)) 
            {
                throw new ArgumentException("Todos los campos del empleado son obligatorios.");
            }

            // 2. Validar longitud exacta del DNI
            if (empleado.DniEmpleado.Length != 8)
            {
                throw new ArgumentException("El DNI debe tener exactamente 8 números.");
            }

            // 3. Validar Correo Electrónico mediante Regex
            string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(empleado.CorreoEmpleado, patronCorreo))
            {
                throw new ArgumentException("Formato de correo inválido (ejemplo: usuario@gmail.com).");
            }

            // 4. Si todas las validaciones pasan, enviamos la orden a la capa de Datos
            EmpleadoData data = new EmpleadoData();
            data.ABMEmpleado(empleado, operacion);
        }

        public DataTable ObtenerEmpleadosTabla()
        {
            EmpleadoData objData = new EmpleadoData(); // O SistemaJugueteria.Data.EmpleadoData
            return objData.ObtenerEmpleadosTabla();
        }
    }
}
