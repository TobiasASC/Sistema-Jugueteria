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
    }
}