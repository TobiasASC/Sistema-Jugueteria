using System;
using System.Data;
using Microsoft.Data.SqlClient;
using SistemaJugueteria.Entities;

namespace SistemaJugueteria.Data
{
    public class PedidoData
    {

        // Registrar un nuevo pedido en la base de datos, incluyendo sus detalles.
        public bool RegistrarPedido(Pedido obj)
        {
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                conexion.Open();
                using (SqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        string queryPedido = @"INSERT INTO Pedido (fecha_pedido, fecha_entrega, total_pedido, estado_pedido, id_proveedor, id_usuario) 
                                               OUTPUT INSERTED.id_pedido 
                                               VALUES (GETDATE(), @fecha_entrega, @total, 'EN ESPERA', @id_prov, @id_usu)";

                        SqlCommand cmdPedido = new SqlCommand(queryPedido, conexion, transaccion);
                        cmdPedido.Parameters.AddWithValue("@fecha_entrega", (object)obj.FechaEntrega ?? DBNull.Value);
                        cmdPedido.Parameters.AddWithValue("@total", obj.TotalPedido);
                        cmdPedido.Parameters.AddWithValue("@id_prov", obj.IdProveedor);
                        cmdPedido.Parameters.AddWithValue("@id_usu", obj.IdUsuario);

                        int idGenerado = Convert.ToInt32(cmdPedido.ExecuteScalar());

                        string queryDetalle = @"INSERT INTO Detalle_pedido (id_pedido, id_producto, cantidad, precio_unitario, subtotal) 
                                                VALUES (@id_ped, @id_prod, @cant, @precio, @subtotal)";

                        foreach (DetallePedido item in obj.Detalles)
                        {
                            SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conexion, transaccion);
                            cmdDetalle.Parameters.AddWithValue("@id_ped", idGenerado);
                            cmdDetalle.Parameters.AddWithValue("@id_prod", item.IdProducto);
                            cmdDetalle.Parameters.AddWithValue("@cant", item.Cantidad);
                            cmdDetalle.Parameters.AddWithValue("@precio", item.PrecioUnitario);
                            cmdDetalle.Parameters.AddWithValue("@subtotal", item.Subtotal);
                            cmdDetalle.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaccion.Rollback();
                        return false;
                    }
                }
            }
        }

        // Listar todos los pedidos de la base de datos.
        public DataTable ListarPedidos()
        {
            DataTable dt = new DataTable();
            using (Microsoft.Data.SqlClient.SqlConnection conexion = Conexion.ObtenerConexion())
            {
                string query = @"SELECT p.id_pedido as Numero, 
                                e.nombre_empleado + ' ' + e.apellido_empleado as Usuario, 
                                p.fecha_pedido as [Fecha Realizacion], 
                                p.fecha_entrega as [Fecha Estimada Entrega], 
                                pr.nombre_proveedor as Proveedor, 
                                p.total_pedido as Total, 
                                p.estado_pedido as Estado
                         FROM Pedido p
                         INNER JOIN Proveedor pr ON p.id_proveedor = pr.id_proveedor
                         INNER JOIN Usuario u ON p.id_usuario = u.id_usuario
                         INNER JOIN Empleado e ON u.id_empleado = e.id_empleado
                         ORDER BY p.fecha_pedido DESC";

                Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conexion);
                Microsoft.Data.SqlClient.SqlDataAdapter da = new Microsoft.Data.SqlClient.SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        // Cambiar el estado de un pedido y actualizar el stock de los productos si es necesario.
        public bool CambiarEstado(int idPedido, string estadoAnterior, string nuevoEstado)
        {
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                conexion.Open();
                using (SqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        string queryEstado = "UPDATE Pedido SET estado_pedido = @estado WHERE id_pedido = @id";
                        SqlCommand cmdEstado = new SqlCommand(queryEstado, conexion, transaccion);
                        cmdEstado.Parameters.AddWithValue("@estado", nuevoEstado);
                        cmdEstado.Parameters.AddWithValue("@id", idPedido);
                        cmdEstado.ExecuteNonQuery();

                        // Control de Stock simplificado
                        if (estadoAnterior == "EN ESPERA" && nuevoEstado == "RECIBIDO")
                        {
                            string queryStock = @"UPDATE p
                                          SET p.stock_actual = p.stock_actual + dp.cantidad
                                          FROM Producto p
                                          INNER JOIN Detalle_pedido dp ON p.id_producto = dp.id_producto
                                          WHERE dp.id_pedido = @id";
                            SqlCommand cmdStock = new SqlCommand(queryStock, conexion, transaccion);
                            cmdStock.Parameters.AddWithValue("@id", idPedido);
                            cmdStock.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaccion.Rollback();
                        return false;
                    }
                }
            }
        }

        // Modificar un pedido existente, actualizando su total y detalles.

        public bool ModificarPedido(int idPedido, decimal totalPedido, List<DetallePedido> detalles)
        {
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                conexion.Open();
                using (SqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        // 1. Actualizamos el total y la fecha del pedido
                        string queryUpd = "UPDATE Pedido SET total_pedido = @total WHERE id_pedido = @id";
                        SqlCommand cmdUpd = new SqlCommand(queryUpd, conexion, transaccion);
                        cmdUpd.Parameters.AddWithValue("@total", totalPedido);
                        cmdUpd.Parameters.AddWithValue("@id", idPedido);
                        cmdUpd.ExecuteNonQuery();

                        // 2. Borramos los detalles viejos
                        string queryDel = "DELETE FROM Detalle_pedido WHERE id_pedido = @id";
                        SqlCommand cmdDel = new SqlCommand(queryDel, conexion, transaccion);
                        cmdDel.Parameters.AddWithValue("@id", idPedido);
                        cmdDel.ExecuteNonQuery();

                        // 3. Insertamos los detalles actualizados
                        string queryIns = @"INSERT INTO Detalle_pedido (id_pedido, id_producto, cantidad, precio_unitario, subtotal) 
                                    VALUES (@id_ped, @id_prod, @cant, @precio, @subtotal)";
                        foreach (DetallePedido item in detalles)
                        {
                            SqlCommand cmdIns = new SqlCommand(queryIns, conexion, transaccion);
                            cmdIns.Parameters.AddWithValue("@id_ped", idPedido);
                            cmdIns.Parameters.AddWithValue("@id_prod", item.IdProducto);
                            cmdIns.Parameters.AddWithValue("@cant", item.Cantidad);
                            cmdIns.Parameters.AddWithValue("@precio", item.PrecioUnitario);
                            cmdIns.Parameters.AddWithValue("@subtotal", item.Subtotal);
                            cmdIns.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaccion.Rollback();
                        return false;
                    }
                }
            }
        }

        // Obtener los detalles de un pedido específico.
        public List<DetallePedido> ObtenerDetalles(int idPedido)
        {
            List<DetallePedido> lista = new List<DetallePedido>();
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                string query = @"SELECT dp.id_pedido, dp.id_producto, p.descripcion_producto, 
                                dp.cantidad, dp.precio_unitario, dp.subtotal
                         FROM Detalle_pedido dp
                         INNER JOIN Producto p ON dp.id_producto = p.id_producto
                         WHERE dp.id_pedido = @id";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", idPedido);

                conexion.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new DetallePedido()
                        {
                            IdPedido = Convert.ToInt32(reader["id_pedido"]),
                            IdProducto = reader["id_producto"].ToString(),
                            DescripcionProducto = reader["descripcion_producto"].ToString(),
                            Cantidad = Convert.ToInt32(reader["cantidad"]),
                            PrecioUnitario = Convert.ToDecimal(reader["precio_unitario"]),
                            Subtotal = Convert.ToDecimal(reader["subtotal"])
                        });
                    }
                }
            }
            return lista;
        }

        // Obtener el próximo número de pedido disponible en la base de datos.
        public int ObtenerProximoNumeroPedido()
        {
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                // ISNULL previene errores si la tabla no tiene ningún pedido guardado aún
                string query = "SELECT ISNULL(MAX(id_pedido), 0) + 1 FROM Pedido";
                SqlCommand cmd = new SqlCommand(query, conexion);
                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
