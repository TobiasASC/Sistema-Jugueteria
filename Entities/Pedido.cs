using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaJugueteria.Entities
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public decimal TotalPedido { get; set; }
        public string EstadoPedido { get; set; } = "EN ESPERA";
        public int IdProveedor { get; set; }
        public int IdUsuario { get; set; }

        public List<DetallePedido> Detalles { get; set; } = new List<DetallePedido>();
    }
}
