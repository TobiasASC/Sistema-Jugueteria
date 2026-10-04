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
    }
}
