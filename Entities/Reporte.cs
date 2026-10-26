using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaJugueteria.Entities
{
    public class Reporte
    {
        public int IdReporte { get; set; }
        public int IdTipoReporte { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public int IdUsuario { get; set; }
        public string? FiltrosAplicados { get; set; }
        public bool IncluyeDetalle { get; set; }
    }
}