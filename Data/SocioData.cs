using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using SistemaJugueteria.Entities;

namespace SistemaJugueteria.Data
{
    public class SocioData
    {
        // Método actualizado para listar activos o inactivos según el switch
        public List<Socio> Listar(bool verSoloInactivos)
        {
            List<Socio> lista = new List<Socio>();

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                string query = @"SELECT id_socio, dni_socio, nombre_socio, apellido_socio, 
                                        correo_socio, direccion_socio, puntos_acumulados 
                                 FROM Socio 
                                 WHERE activo = @estadoActivo 
                                 ORDER BY apellido_socio, nombre_socio";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    // Si verSoloInactivos es true busca inactivos (0), sino activos (1)
                    comando.Parameters.AddWithValue("@estadoActivo", verSoloInactivos ? 0 : 1);

                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            lista.Add(new Socio
                            {
                                IdSocio = lector.GetInt32(0),
                                DniSocio = lector.GetString(1),
                                NombreSocio = lector.GetString(2),
                                ApellidoSocio = lector.GetString(3),
                                CorreoSocio = lector.GetString(4),
                                DireccionSocio = lector.GetString(5),
                                PuntosAcumulados = lector["puntos_acumulados"] != DBNull.Value ? lector.GetInt32(6) : 0
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public void Insertar(Socio socio)
        {
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                string query = @"INSERT INTO Socio (dni_socio, nombre_socio, apellido_socio, correo_socio, direccion_socio, puntos_acumulados, activo) 
                                 VALUES (@dni, @nombre, @apellido, @email, @direccion, 0, 1)";
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@dni", socio.DniSocio);
                    comando.Parameters.AddWithValue("@nombre", socio.NombreSocio);
                    comando.Parameters.AddWithValue("@apellido", socio.ApellidoSocio);
                    comando.Parameters.AddWithValue("@email", socio.CorreoSocio);
                    comando.Parameters.AddWithValue("@direccion", socio.DireccionSocio);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Actualizar(Socio socio)
        {
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                string query = @"UPDATE Socio 
                                 SET dni_socio = @dni, nombre_socio = @nombre, apellido_socio = @apellido, 
                                     correo_socio = @email, direccion_socio = @direccion 
                                 WHERE id_socio = @id";
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@dni", socio.DniSocio);
                    comando.Parameters.AddWithValue("@nombre", socio.NombreSocio);
                    comando.Parameters.AddWithValue("@apellido", socio.ApellidoSocio);
                    comando.Parameters.AddWithValue("@email", socio.CorreoSocio);
                    comando.Parameters.AddWithValue("@direccion", socio.DireccionSocio);
                    comando.Parameters.AddWithValue("@id", socio.IdSocio);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        // Baja lógica
        public void Eliminar(int idSocio)
        {
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                string query = "UPDATE Socio SET activo = 0 WHERE id_socio = @id";
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@id", idSocio);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        // Reactivación lógica (Nuevo método necesario)
        public bool Reactivar(int idSocio)
        {
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                string query = "UPDATE Socio SET activo = 1 WHERE id_socio = @id";
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@id", idSocio);
                    conexion.Open();
                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }


        public DataTable ObtenerReporteClientes(
            bool incluirActivos,
            bool incluirInactivos,
            string criterioOrden)
        {
            DataTable tabla = new DataTable();

            string ordenamiento;

            switch (criterioOrden)
            {
                case "Mayores compradores":
                    ordenamiento = "SUM(ISNULL(v.total_venta, 0)) DESC";
                    break;

                case "Más tiempo registrados":
                    ordenamiento = "s.id_socio ASC";
                    break;

                case "Mayor cantidad de puntos":
                    ordenamiento = "s.puntos_acumulados DESC";
                    break;

                default:
                    ordenamiento = "s.id_socio ASC";
                    break;
            }

            string query = $@"
        SELECT
            s.id_socio AS [ID],
            s.dni_socio AS [DNI],
            s.nombre_socio AS [Nombre],
            s.apellido_socio AS [Apellido],
            s.correo_socio AS [Correo],
            CASE
                WHEN s.activo = 1 THEN 'Activo'
                ELSE 'Inactivo'
            END AS [Estado],
            ISNULL(s.puntos_acumulados, 0) AS [Puntos],
            ISNULL(SUM(v.total_venta), 0) AS [Total comprado]
        FROM Socio s
        LEFT JOIN Venta v
            ON s.id_socio = v.id_socio
        WHERE
            (@Activos = 1 AND s.activo = 1)
            OR
            (@Inactivos = 1 AND s.activo = 0)
        GROUP BY
            s.id_socio,
            s.dni_socio,
            s.nombre_socio,
            s.apellido_socio,
            s.correo_socio,
            s.activo,
            s.puntos_acumulados
        ORDER BY {ordenamiento};";

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@Activos", incluirActivos ? 1 : 0);
                comando.Parameters.AddWithValue("@Inactivos", incluirInactivos ? 1 : 0);

                using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                {
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }

    }
}