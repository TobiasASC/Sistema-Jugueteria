using SistemaJugueteria.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaJugueteria.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public int IdRol { get; set; }
        public int IdEmpleado { get; set; }

        
        public Rol RolAsignado { get; set; }

        public int Estado { get; set; } 
    }
}
