using System;
using System.Data;
using Microsoft.Data.SqlClient; // Actualizado a tu librería
using SistemaJugueteria.Entities;

namespace SistemaJugueteria.Data
{
    public class ProductoData
    {
        // Método para listar productos activos en el DataGridView
        public DataTable Listar(bool verSoloInactivos)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                string query = @"SELECT p.id_producto as Codigo, p.descripcion_producto as Descripcion, 
                                c.nombre_categoria as Categoria, p.precio_venta as Precio, 
                                p.stock_actual as [Stock_Actual], p.stock_minimo as [Stock_Minimo]
                         FROM Producto p
                         INNER JOIN Categoria c ON p.id_categoria = c.id_categoria
                         WHERE p.activo = @estadoActivo";

                SqlCommand cmd = new SqlCommand(query, conexion);

                // Si el interruptor está activado (true), buscamos inactivos (0). 
                // Si está desactivado (false), buscamos activos (1).
                cmd.Parameters.AddWithValue("@estadoActivo", verSoloInactivos ? 0 : 1);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        // Método para verificar si un producto con el mismo id_producto ya existe en la base de datos
        public bool ExisteProducto(string idProducto)
        {
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                string query = "SELECT COUNT(*) FROM Producto WHERE id_producto = @id";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", idProducto);

                conexion.Open();
                // ExecuteScalar devuelve el primer valor de la consulta (en este caso, el conteo)
                int cantidad = Convert.ToInt32(cmd.ExecuteScalar());

                return cantidad > 0; // Si es mayor a 0, significa que el código ya existe
            }
        }

        // ALTA
        public bool Insertar(Producto obj)
        {
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                string query = @"INSERT INTO Producto (id_producto, descripcion_producto, precio_venta, stock_actual, stock_minimo, id_categoria, activo) 
                                 VALUES (@id, @desc, @precio, @stockAct, @stockMin, @idCat, 1)";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", obj.IdProducto);
                cmd.Parameters.AddWithValue("@desc", obj.Descripcion);
                cmd.Parameters.AddWithValue("@precio", obj.PrecioVenta);
                cmd.Parameters.AddWithValue("@stockAct", obj.StockActual);
                cmd.Parameters.AddWithValue("@stockMin", obj.StockMinimo);
                cmd.Parameters.AddWithValue("@idCat", obj.IdCategoria);

                conexion.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // MODIFICACIÓN
        public bool Actualizar(Producto obj)
        {
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                string query = @"UPDATE Producto SET descripcion_producto = @desc, precio_venta = @precio, 
                                 stock_actual = @stockAct, stock_minimo = @stockMin, id_categoria = @idCat 
                                 WHERE id_producto = @id";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", obj.IdProducto);
                cmd.Parameters.AddWithValue("@desc", obj.Descripcion);
                cmd.Parameters.AddWithValue("@precio", obj.PrecioVenta);
                cmd.Parameters.AddWithValue("@stockAct", obj.StockActual);
                cmd.Parameters.AddWithValue("@stockMin", obj.StockMinimo);
                cmd.Parameters.AddWithValue("@idCat", obj.IdCategoria);

                conexion.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // BAJA LÓGICA
        public bool Eliminar(string idProducto)
        {
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                string query = "UPDATE Producto SET activo = 0 WHERE id_producto = @id";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", idProducto);

                conexion.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Reactivar(string idProducto)
        {
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                string query = "UPDATE Producto SET activo = 1 WHERE id_producto = @id";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", idProducto);

                conexion.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Método para obtener un producto activo por su id_producto
        public Producto ObtenerProductoActivo(string idProducto)
        {
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                string query = "SELECT * FROM Producto WHERE id_producto = @id AND activo = 1";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", idProducto);
                conexion.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Producto()
                        {
                            IdProducto = reader["id_producto"].ToString(),
                            Descripcion = reader["descripcion_producto"].ToString(),
                            PrecioVenta = Convert.ToDecimal(reader["precio_venta"]),
                            StockActual = Convert.ToInt32(reader["stock_actual"]),
                            IdCategoria = Convert.ToInt32(reader["id_categoria"])
                        };
                    }
                }
                return null;
            }
        }

        // Método optimizado para el autocompletado de la interfaz
        public List<Producto> ListarProductosParaSugerencias()
        {
            List<Producto> lista = new List<Producto>();
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                string query = "SELECT id_producto, descripcion_producto FROM Producto WHERE activo = 1";
                SqlCommand cmd = new SqlCommand(query, conexion);
                conexion.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Producto()
                        {
                            IdProducto = reader["id_producto"].ToString(),
                            Descripcion = reader["descripcion_producto"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public Producto ObtenerProductoActivoPorDescripcion(string descripcion)
        {
            using (Microsoft.Data.SqlClient.SqlConnection conexion = Conexion.ObtenerConexion())
            {
                string query = "SELECT * FROM Producto WHERE descripcion_producto = @desc AND activo = 1";
                Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@desc", descripcion);
                conexion.Open();

                using (Microsoft.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Producto()
                        {
                            IdProducto = reader["id_producto"].ToString(),
                            Descripcion = reader["descripcion_producto"].ToString(),
                            PrecioVenta = Convert.ToDecimal(reader["precio_venta"]),
                            StockActual = Convert.ToInt32(reader["stock_actual"]),
                            IdCategoria = Convert.ToInt32(reader["id_categoria"])
                        };
                    }
                }
                return null;
            }
        }


        public DataTable ObtenerReporteProductos(bool verSoloInactivos, string criterioStock)
        {
            DataTable dt = new DataTable();

            string query = @"
        SELECT
            p.id_producto AS [Código],
            p.descripcion_producto AS [Descripción],
            c.nombre_categoria AS [Categoría],
            p.precio_venta AS [Precio de venta],
            p.stock_actual AS [Stock actual],
            p.stock_minimo AS [Stock mínimo],
            CASE
                WHEN p.stock_actual = 0 THEN 'Sin stock'
                WHEN p.stock_actual <= p.stock_minimo THEN 'Stock mínimo'
                ELSE 'Stock suficiente'
            END AS [Situación del stock]
        FROM Producto p
        INNER JOIN Categoria c
            ON p.id_categoria = c.id_categoria
        WHERE p.activo = @Activo";

            // Filtrar por situación del stock
            switch (criterioStock)
            {
                case "Sin stock":
                    query += " AND p.stock_actual = 0";
                    break;

                case "Stock mínimo":
                    query += " AND p.stock_actual > 0 AND p.stock_actual <= p.stock_minimo";
                    break;

                case "Con stock":
                    query += " AND p.stock_actual > p.stock_minimo";
                    break;

                case "Mayor stock":
                    query += " ORDER BY p.stock_actual DESC, p.descripcion_producto ASC";
                    break;

                case "Menor stock":
                    query += " ORDER BY p.stock_actual ASC, p.descripcion_producto ASC";
                    break;

                default:
                    query += " ORDER BY p.descripcion_producto ASC";
                    break;
            }

            // Si no se eligió un orden por stock, ordenar por descripción
            if (criterioStock != "Mayor stock" && criterioStock != "Menor stock")
            {
                query += ", p.id_producto ASC";
            }

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                // El switch activado muestra inactivos; desactivado, activos
                cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = !verSoloInactivos;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }


    }
}
