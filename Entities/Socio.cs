using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaJugueteria.Entities{
    public class Socio{
        public int IdSocio { get; set; }
        public string DniSocio { get; set; }
        public string NombreSocio { get; set; }
        public string ApellidoSocio { get; set; }
        public string CorreoSocio { get; set; }
        public string DireccionSocio { get; set; }
        public int PuntosAcumulados { get; set; }
    }
}
