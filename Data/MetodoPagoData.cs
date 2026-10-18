using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace SistemaJugueteria.Data
{
    public class MetodoPagoData
    {
        public DataTable ObtenerMetodosPago()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                conexion.Open();
                string query = "SELECT id_metodo_pago, descripcion_metodo FROM Metodo_pago";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}
