using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using SistemaJugueteria.Entities; 

namespace SistemaJugueteria.Data
{
    public class CategoriaData
    {
        public List<Categoria> ListarCategoriasActivas()
        {
            List<Categoria> lista = new List<Categoria>();

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                string query = "SELECT id_categoria, nombre_categoria FROM Categoria WHERE activo = 1 ORDER BY nombre_categoria";
                SqlCommand cmd = new SqlCommand(query, conexion);

                conexion.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Categoria()
                        {
                            IdCategoria = Convert.ToInt32(reader["id_categoria"]),
                            NombreCategoria = reader["nombre_categoria"].ToString()
                        });
                    }
                }
            }
            return lista;
        }
    }
}
