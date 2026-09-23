using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string DniEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public string CorreoEmpleado { get; set; }

        public string TelefonoEmpleado { get; set; }
        public string DireccionEmpleado { get; set; }

        public int Estado { get; set; }

        public string Rol { get; set; }

        // Constructor vacío por defecto
        public Empleado()
        {
        }
    }
}
