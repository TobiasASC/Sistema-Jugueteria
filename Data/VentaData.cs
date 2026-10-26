
using System;
using Microsoft.Data.SqlClient;
using SistemaJugueteria.Entities;
using System.Data;

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




        public DataTable ObtenerReporteVentas(
            DateTime fechaDesde,
            DateTime fechaHasta,
            int? idEmpleado,
            bool incluirDetalle)
        {
            if (fechaDesde.Date > fechaHasta.Date)
            {
                throw new ArgumentException(
                    "La fecha desde no puede ser posterior a la fecha hasta.");
            }

            DataTable tabla = new DataTable();
            string query;

            if (incluirDetalle)
            {
                query = @"
            SELECT
                v.id_venta AS [N.º Venta],
                v.fecha_venta AS [Fecha],
                e.nombre_empleado + ' ' + e.apellido_empleado AS [Empleado],
                s.dni_socio AS [DNI Socio],
                p.id_producto AS [Código Producto],
                p.descripcion_producto AS [Producto],
                dv.cantidad AS [Cantidad],
                dv.precio_unitario AS [Precio Unitario],
                dv.subtotal AS [Subtotal Producto],
                v.subtotal_venta AS [Subtotal Venta],
                v.total_venta AS [Total Venta]
            FROM Venta v
            INNER JOIN Usuario u
                ON u.id_usuario = v.id_usuario
            INNER JOIN Empleado e
                ON e.id_empleado = u.id_empleado
            INNER JOIN Socio s
                ON s.id_socio = v.id_socio
            INNER JOIN Detalle_venta dv
                ON dv.id_venta = v.id_venta
            INNER JOIN Producto p
                ON p.id_producto = dv.id_producto
            WHERE v.fecha_venta >= @fechaDesde
              AND v.fecha_venta < @fechaHasta
              AND (
                    @idEmpleado IS NULL
                    OR e.id_empleado = @idEmpleado
                  )
            ORDER BY v.fecha_venta, v.id_venta;";
            }
            else
            {
                query = @"
            SELECT
                v.id_venta AS [N.º Venta],
                v.fecha_venta AS [Fecha],
                e.nombre_empleado + ' ' + e.apellido_empleado AS [Empleado],
                s.dni_socio AS [DNI Socio],
                v.subtotal_venta AS [Subtotal],
                v.total_venta AS [Total],
                v.puntos_generados AS [Puntos Generados]
            FROM Venta v
            INNER JOIN Usuario u
                ON u.id_usuario = v.id_usuario
            INNER JOIN Empleado e
                ON e.id_empleado = u.id_empleado
            INNER JOIN Socio s
                ON s.id_socio = v.id_socio
            WHERE v.fecha_venta >= @fechaDesde
              AND v.fecha_venta < @fechaHasta
              AND (
                    @idEmpleado IS NULL
                    OR e.id_empleado = @idEmpleado
                  )
            ORDER BY v.fecha_venta, v.id_venta;";
            }

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.Add(
                    "@fechaDesde", SqlDbType.DateTime).Value =
                    fechaDesde.Date;

                comando.Parameters.Add(
                    "@fechaHasta", SqlDbType.DateTime).Value =
                    fechaHasta.Date.AddDays(1);

                comando.Parameters.Add(
                    "@idEmpleado", SqlDbType.Int).Value =
                    idEmpleado.HasValue
                        ? (object)idEmpleado.Value
                        : DBNull.Value;

                using (SqlDataAdapter adaptador =
                       new SqlDataAdapter(comando))
                {
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }



    }
}
