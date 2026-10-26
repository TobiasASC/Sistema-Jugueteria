using Microsoft.Data.SqlClient;
using SistemaJugueteria.Entities;
using System;
using System.Data;

namespace SistemaJugueteria.Data
{
    public class ReporteData
    {
        public int RegistrarReporte(Reporte reporte)
        {
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                const string query = @"
                    INSERT INTO Reporte
                    (
                        id_tipo_reporte,
                        id_usuario,
                        filtros_aplicados,
                        incluye_detalle
                    )
                    OUTPUT INSERTED.id_reporte
                    VALUES
                    (
                        @id_tipo_reporte,
                        @id_usuario,
                        @filtros_aplicados,
                        @incluye_detalle
                    );";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(
                        "@id_tipo_reporte", SqlDbType.Int
                    ).Value = reporte.IdTipoReporte;

                    comando.Parameters.Add(
                        "@id_usuario", SqlDbType.Int
                    ).Value = reporte.IdUsuario;

                    comando.Parameters.Add(
                        "@filtros_aplicados", SqlDbType.NVarChar, -1
                    ).Value = (object?)reporte.FiltrosAplicados
                        ?? DBNull.Value;

                    comando.Parameters.Add(
                        "@incluye_detalle", SqlDbType.Bit
                    ).Value = reporte.IncluyeDetalle;

                    conexion.Open();

                    return Convert.ToInt32(comando.ExecuteScalar());
                }
            }
        }

        public DataTable ListarReportes(
            int? idTipoReporte = null,
            DateTime? fecha = null)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                const string query = @"
                    SELECT
                        r.id_reporte AS [N.º Reporte],
                        tr.nombre_tipo AS [Tipo de reporte],
                        r.fecha_generacion AS [Fecha de generación],
                        r.id_usuario AS [Usuario],
                        r.filtros_aplicados AS [Filtros aplicados],
                        r.incluye_detalle AS [Incluye detalle]
                    FROM Reporte r
                    INNER JOIN Tipo_Reporte tr
                        ON r.id_tipo_reporte = tr.id_tipo_reporte
                    WHERE
                        (@id_tipo_reporte IS NULL
                         OR r.id_tipo_reporte = @id_tipo_reporte)
                        AND
                        (@fecha IS NULL
                         OR r.fecha_generacion >= @fecha
                         AND r.fecha_generacion < DATEADD(DAY, 1, @fecha))
                    ORDER BY r.fecha_generacion DESC;";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(
                        "@id_tipo_reporte", SqlDbType.Int
                    ).Value = (object?)idTipoReporte ?? DBNull.Value;

                    comando.Parameters.Add(
                        "@fecha", SqlDbType.Date
                    ).Value = (object?)fecha?.Date ?? DBNull.Value;

                    using (SqlDataAdapter adaptador =
                           new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }
            }

            return tabla;
        }

        public int ObtenerIdTipoReportePorNombre(string nombreTipo)
        {
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                const string query = @"
            SELECT id_tipo_reporte
            FROM Tipo_Reporte
            WHERE nombre_tipo = @nombre_tipo;";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(
                        "@nombre_tipo",
                        SqlDbType.VarChar,
                        30
                    ).Value = nombreTipo;

                    conexion.Open();

                    object resultado = comando.ExecuteScalar();

                    if (resultado == null || resultado == DBNull.Value)
                    {
                        throw new Exception(
                            $"No existe el tipo de reporte '{nombreTipo}' en la base de datos."
                        );
                    }

                    return Convert.ToInt32(resultado);
                }
            }
        }
    }
}