using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaJugueteria.Entities
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal SubtotalVenta { get; set; }
        public decimal TotalVenta { get; set; }
        public int PuntosGenerados { get; set; }
        public int IdMetodoPago { get; set; }
        public int IdUsuario { get; set; } // ID Vendedor
        public int IdSocio { get; set; }   // ID Cliente

        public List<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
    }
}
