using System;
using Microsoft.Data.SqlClient;
using SistemaJugueteria.Entities;

namespace SistemaJugueteria.Data
{
    public class VentaData
    {
        public int RegistrarVenta(Venta nuevaVenta)
        {
            int idVentaGenerada = 0;

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                conexion.Open();
                using (SqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        // 1. Insertar Cabecera de Venta
                        string queryVenta = @"
                            INSERT INTO Venta (fecha_venta, subtotal_venta, total_venta, puntos_generados, id_metodo_pago, id_usuario, id_socio)
                            OUTPUT INSERTED.id_venta
                            VALUES (GETDATE(), @subtotal, @total, @puntos, @metodoPago, @usuario, @socio);";

                        using (SqlCommand cmdVenta = new SqlCommand(queryVenta, conexion, transaccion))
                        {
                            cmdVenta.Parameters.AddWithValue("@subtotal", nuevaVenta.SubtotalVenta);
                            cmdVenta.Parameters.AddWithValue("@total", nuevaVenta.TotalVenta);
                            cmdVenta.Parameters.AddWithValue("@puntos", nuevaVenta.PuntosGenerados);
                            cmdVenta.Parameters.AddWithValue("@metodoPago", nuevaVenta.IdMetodoPago);
                            cmdVenta.Parameters.AddWithValue("@usuario", nuevaVenta.IdUsuario);
                            cmdVenta.Parameters.AddWithValue("@socio", nuevaVenta.IdSocio);

                            idVentaGenerada = Convert.ToInt32(cmdVenta.ExecuteScalar());
                        }

                        // 2. Insertar Detalle de Venta
                        string queryDetalle = @"
                            INSERT INTO Detalle_venta (id_venta, id_producto, cantidad, precio_unitario, subtotal)
                            VALUES (@idVenta, @idProducto, @cantidad, @precioUnitario, @subtotal);";

                        foreach (var det in nuevaVenta.Detalles)
                        {
                            using (SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conexion, transaccion))
                            {
                                cmdDetalle.Parameters.AddWithValue("@idVenta", idVentaGenerada);
                                cmdDetalle.Parameters.AddWithValue("@idProducto", det.IdProducto);
                                cmdDetalle.Parameters.AddWithValue("@cantidad", det.Cantidad);
                                cmdDetalle.Parameters.AddWithValue("@precioUnitario", det.PrecioUnitario);
                                cmdDetalle.Parameters.AddWithValue("@subtotal", det.Subtotal);

                                cmdDetalle.ExecuteNonQuery();
                            }
                        }

                        // 3. Sumar Puntos al Socio en la BD (1% del total)
                        if (nuevaVenta.IdSocio > 0 && nuevaVenta.PuntosGenerados > 0)
                        {
                            string queryPuntos = @"
                                UPDATE Socio 
                                SET puntos_acumulados = ISNULL(puntos_acumulados, 0) + @puntos 
                                WHERE id_socio = @idSocio;";

                            using (SqlCommand cmdPuntos = new SqlCommand(queryPuntos, conexion, transaccion))
                            {
                                cmdPuntos.Parameters.AddWithValue("@puntos", nuevaVenta.PuntosGenerados);
                                cmdPuntos.Parameters.AddWithValue("@idSocio", nuevaVenta.IdSocio);
                                cmdPuntos.ExecuteNonQuery();
                            }
                        }

                        transaccion.Commit();
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }

            return idVentaGenerada;
        }
    }
}