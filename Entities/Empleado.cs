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

        // El estado es útil por si luego quieres mostrar en la grilla solo los activos
        // En MariaDB TINYINT(1) se suele mapear como bool en C# (true = 1, false = 0) 
        // o simplemente como int. Usaremos int para mantenerlo simple.
        public int Estado { get; set; }

        public string Rol { get; set; }

        // Constructor vacío por defecto
        public Empleado()
        {
        }
    }
}
