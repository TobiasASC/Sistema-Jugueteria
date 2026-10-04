using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaJugueteria.Entities
{
    public class Producto
    {
        public string IdProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioVenta { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public int IdCategoria { get; set; }
        public bool Activo { get; set; }
    }
}
