using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaJugueteria.Entities
{
    public class DetallePedido
    {
        public int IdPedido { get; set; }
        public string IdProducto { get; set; } = string.Empty;
        public string DescripcionProducto { get; set; } = string.Empty; 
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}
