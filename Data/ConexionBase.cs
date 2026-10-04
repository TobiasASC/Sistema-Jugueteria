using System;
using Microsoft.Data.SqlClient;

namespace SistemaJugueteria.Data
{
    public static class Conexion
    {

        private static readonly string cadenaConexion = @"Data Source=.\SQLEXPRESS;Initial Catalog=sistema_jugueteria;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
