
using System;
using Microsoft.Data.SqlClient;
using SistemaJugueteria.Entities;

namespace SistemaJugueteria.Data
{
    public class VentaData
    {
        public int RegistrarVenta(
            Venta nuevaVenta,
            int puntosGastados = 0)
        {
            if (nuevaVenta == null)
                throw new ArgumentNullException(nameof(nuevaVenta));

            if (puntosGastados < 0)
                throw new ArgumentOutOfRangeException(nameof(puntosGastados));

            int idVentaGenerada = 0;

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                conexion.Open();

                using (SqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        // 1. Registrar la cabecera de la venta.
                        string queryVenta = @"
                            INSERT INTO Venta
                                (fecha_venta, subtotal_venta, total_venta,
                                 puntos_generados, id_metodo_pago,
                                 id_usuario, id_socio)
                            OUTPUT INSERTED.id_venta
                            VALUES
                                (GETDATE(), @subtotal, @total, @puntos,
                                 @metodoPago, @usuario, @socio);";

                        using (SqlCommand cmdVenta =
                               new SqlCommand(queryVenta, conexion, transaccion))
                        {
                            cmdVenta.Parameters.AddWithValue(
                                "@subtotal", nuevaVenta.SubtotalVenta);

                            cmdVenta.Parameters.AddWithValue(
                                "@total", nuevaVenta.TotalVenta);

                            cmdVenta.Parameters.AddWithValue(
                                "@puntos", nuevaVenta.PuntosGenerados);

                            cmdVenta.Parameters.AddWithValue(
                                "@metodoPago", nuevaVenta.IdMetodoPago);

                            cmdVenta.Parameters.AddWithValue(
                                "@usuario", nuevaVenta.IdUsuario);

                            cmdVenta.Parameters.AddWithValue(
                                "@socio", nuevaVenta.IdSocio);

                            idVentaGenerada =
                                Convert.ToInt32(cmdVenta.ExecuteScalar());
                        }

                        // 2. Descontar stock y registrar los detalles.
                        string queryStock = @"
                            UPDATE Producto
                            SET stock_actual = stock_actual - @cantidad
                            WHERE id_producto = @idProducto
                              AND stock_actual >= @cantidad
                              AND activo = 1;";

                        string queryDetalle = @"
                            INSERT INTO Detalle_venta
                                (id_venta, id_producto, cantidad,
                                 precio_unitario, subtotal)
                            VALUES
                                (@idVenta, @idProducto, @cantidad,
                                 @precioUnitario, @subtotal);";

                        foreach (var det in nuevaVenta.Detalles)
                        {
                            if (det.Cantidad <= 0)
                            {
                                throw new InvalidOperationException(
                                    $"La cantidad del producto {det.IdProducto} " +
                                    "debe ser mayor que cero.");
                            }

                            if (det.PrecioUnitario <= 0 ||
                                det.Subtotal < 0)
                            {
                                throw new InvalidOperationException(
                                    $"El precio o subtotal del producto " +
                                    $"{det.IdProducto} no es válido.");
                            }

                            using (SqlCommand cmdStock =
                                   new SqlCommand(queryStock, conexion, transaccion))
                            {
                                cmdStock.Parameters.AddWithValue(
                                    "@cantidad", det.Cantidad);

                                cmdStock.Parameters.AddWithValue(
                                    "@idProducto", det.IdProducto);

                                int filasAfectadas = cmdStock.ExecuteNonQuery();

                                if (filasAfectadas != 1)
                                {
                                    throw new InvalidOperationException(
                                        $"No hay stock suficiente para el producto " +
                                        $"{det.IdProducto}, o está inactivo o no existe.");
                                }
                            }

                            using (SqlCommand cmdDetalle =
                                   new SqlCommand(queryDetalle, conexion, transaccion))
                            {
                                cmdDetalle.Parameters.AddWithValue(
                                    "@idVenta", idVentaGenerada);

                                cmdDetalle.Parameters.AddWithValue(
                                    "@idProducto", det.IdProducto);

                                cmdDetalle.Parameters.AddWithValue(
                                    "@cantidad", det.Cantidad);

                                cmdDetalle.Parameters.AddWithValue(
                                    "@precioUnitario", det.PrecioUnitario);

                                cmdDetalle.Parameters.AddWithValue(
                                    "@subtotal", det.Subtotal);

                                cmdDetalle.ExecuteNonQuery();
                            }
                        }

                        // 3. Actualizar los puntos del socio.
                        // Se valida el saldo dentro de la transacción.
                        if (puntosGastados > 0 ||
                            nuevaVenta.PuntosGenerados > 0)
                        {
                            string queryPuntos = @"
                                UPDATE Socio
                                SET puntos_acumulados =
                                    ISNULL(puntos_acumulados, 0)
                                    - @puntosGastados
                                    + @puntosNuevos
                                WHERE id_socio = @idSocio
                                  AND dni_socio <> '00000000'
                                  AND ISNULL(puntos_acumulados, 0)
                                      >= @puntosGastados;";

                            using (SqlCommand cmdPuntos =
                                   new SqlCommand(queryPuntos, conexion, transaccion))
                            {
                                cmdPuntos.Parameters.AddWithValue(
                                    "@puntosGastados", puntosGastados);

                                cmdPuntos.Parameters.AddWithValue(
                                    "@puntosNuevos", nuevaVenta.PuntosGenerados);

                                cmdPuntos.Parameters.AddWithValue(
                                    "@idSocio", nuevaVenta.IdSocio);

                                int filasAfectadas = cmdPuntos.ExecuteNonQuery();

                                if (filasAfectadas != 1)
                                {
                                    throw new InvalidOperationException(
                                        "No se pudieron actualizar los puntos. " +
                                        "Verifique que el socio no sea Consumidor Final " +
                                        "y que tenga puntos suficientes para el canje.");
                                }
                            }
                        }

                        // 4. Confirmar todos los cambios juntos.
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
