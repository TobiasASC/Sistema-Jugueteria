using System;
using Microsoft.Data.SqlClient;

namespace SistemaJugueteria.Data
{
    public static class Conexion
    {
        // .\SQLEXPRESS es el nombre por defecto cuando instalas SQL Server Express.
        // Si tú o tu compañero instalaron la versión "Developer" completa, 
        // simplemente borren el "\SQLEXPRESS" y dejen solo el "." o "(local)".
        private static readonly string cadenaConexion = @"Data Source=.\SQLEXPRESS;Initial Catalog=sistema_jugueteria;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
