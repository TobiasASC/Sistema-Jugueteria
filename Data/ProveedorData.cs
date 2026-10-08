using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using SistemaJugueteria.Entities;

namespace SistemaJugueteria.Data
{
    public class ProveedorData
    {
        public List<Proveedor> ListarProveedores()
        {
            List<Proveedor> lista = new List<Proveedor>();
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                string query = "SELECT id_proveedor, nombre_proveedor FROM Proveedor ORDER BY nombre_proveedor";
                SqlCommand cmd = new SqlCommand(query, conexion);
                conexion.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Proveedor()
                        {
                            IdProveedor = Convert.ToInt32(reader["id_proveedor"]),
                            NombreProveedor = reader["nombre_proveedor"].ToString()
                        });
                    }
                }
            }
            return lista;
        }
    }
}
