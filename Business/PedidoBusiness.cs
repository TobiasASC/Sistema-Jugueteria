using System.Data;
using SistemaJugueteria.Data;
using SistemaJugueteria.Entities;

namespace SistemaJugueteria.Business
{
    public class PedidoBusiness
    {
        private PedidoData _pedidoData = new PedidoData();

        public string RegistrarPedido(Pedido pedido)
        {
            if (pedido.IdProveedor <= 0) return "Debe seleccionar un proveedor válido.";
            if (pedido.Detalles.Count == 0) return "El pedido debe contener al menos un producto.";

            bool respuesta = _pedidoData.RegistrarPedido(pedido);
            return respuesta ? "Pedido registrado y confirmado exitosamente." : "Error al registrar el pedido en la base de datos.";
        }

        // Listar todos los pedidos de la base de datos, incluyendo detalles como proveedor, fecha, total y estado.
        public DataTable ListarPedidos()
        {
            return _pedidoData.ListarPedidos();
        }

        public string CambiarEstado(int idPedido, string estadoActual, string nuevoEstado)
        {
            if (estadoActual == "RECIBIDO") return "Operación denegada: El pedido ya fue recibido.";

            bool respuesta = _pedidoData.CambiarEstado(idPedido, estadoActual, nuevoEstado);
            return respuesta ? "Estado actualizado a RECIBIDO correctamente." : "Error al actualizar el estado.";
        }

        public string ModificarPedido(int idPedido, decimal totalPedido, List<DetallePedido> detalles)
        {
            if (detalles.Count == 0) return "El pedido debe contener al menos un producto.";

            bool respuesta = _pedidoData.ModificarPedido(idPedido, totalPedido, detalles);
            return respuesta ? "Pedido modificado exitosamente." : "Error al modificar el pedido en la base de datos.";
        }

        public List<DetallePedido> ObtenerDetalles(int idPedido)
        {
            return _pedidoData.ObtenerDetalles(idPedido);
        }

        public int ObtenerProximoNumeroPedido()
        {
            return _pedidoData.ObtenerProximoNumeroPedido();
        }
    }
}
