using Entities; // O SistemaJugueteria.Entities dependiendo de tu estructura
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace SistemaJugueteria.Data
{
    // Eliminamos la herencia de ConexionBase
    public class EmpleadoData
    {
        public int ABMEmpleado(Empleado empleado, char operacion)
        {
            int idGenerado = 0;

            // Llamamos a la clase estática Conexion
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var comando = new SqlCommand("sp_ABM_Empleado", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@p_Operacion", operacion);
                    comando.Parameters.AddWithValue("@p_id_empleado", empleado.IdEmpleado == 0 ? (object)DBNull.Value : empleado.IdEmpleado);
                    comando.Parameters.AddWithValue("@p_dni_empleado", empleado.DniEmpleado);
                    comando.Parameters.AddWithValue("@p_nombre_empleado", empleado.NombreEmpleado);
                    comando.Parameters.AddWithValue("@p_apellido_empleado", empleado.ApellidoEmpleado);
                    comando.Parameters.AddWithValue("@p_correo_empleado", empleado.CorreoEmpleado);
                    comando.Parameters.AddWithValue("@p_telefono_empleado", empleado.TelefonoEmpleado);
                    comando.Parameters.AddWithValue("@p_direccion_empleado", empleado.DireccionEmpleado);

                    conexion.Open();
                    var result = comando.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        idGenerado = Convert.ToInt32(result);
                    }
                }
            }
            return idGenerado;
        }

        public Empleado BuscarPorDNI(string dni)
        {
            Empleado empleadoEncontrado = null;
            using (var conexion = Conexion.ObtenerConexion())
            {
                string query = "SELECT id_empleado, dni_empleado, nombre_empleado, apellido_empleado, correo_empleado, telefono_empleado, direccion_empleado FROM Empleado WHERE dni_empleado = @dni AND estado = 1";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@dni", dni);
                    conexion.Open();
                    using (var reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            empleadoEncontrado = new Empleado
                            {
                                IdEmpleado = Convert.ToInt32(reader["id_empleado"]),
                                DniEmpleado = reader["dni_empleado"].ToString(),
                                NombreEmpleado = reader["nombre_empleado"].ToString(),
                                ApellidoEmpleado = reader["apellido_empleado"].ToString(),
                                CorreoEmpleado = reader["correo_empleado"].ToString(),
                                TelefonoEmpleado = reader["telefono_empleado"].ToString(),
                                DireccionEmpleado = reader["direccion_empleado"].ToString()
                            };
                        }
                    }
                }
            }
            return empleadoEncontrado;
        }

        public List<Empleado> ListarEmpleados(int estadoBuscado = 1)
        {
            List<Empleado> lista = new List<Empleado>();
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                // Agregamos filtro: u.id_rol <> 1 (o r.nombre_rol <> 'Administrador')
                string query = @"
            SELECT e.id_empleado, e.dni_empleado, e.nombre_empleado, e.apellido_empleado, 
            e.correo_empleado, e.telefono_empleado, e.direccion_empleado, r.nombre_rol 
            FROM Empleado e
            INNER JOIN Usuario u ON e.id_empleado = u.id_empleado
            INNER JOIN Rol r ON u.id_rol = r.id_rol
            WHERE e.estado = @estadoBuscado AND u.id_rol <> 1";

                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@estadoBuscado", estadoBuscado);

                conexion.Open();
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Empleado
                        {
                            IdEmpleado = Convert.ToInt32(reader["id_empleado"]),
                            DniEmpleado = reader["dni_empleado"].ToString(),
                            NombreEmpleado = reader["nombre_empleado"].ToString(),
                            ApellidoEmpleado = reader["apellido_empleado"].ToString(),
                            CorreoEmpleado = reader["correo_empleado"].ToString(),
                            TelefonoEmpleado = reader["telefono_empleado"].ToString(),
                            DireccionEmpleado = reader["direccion_empleado"].ToString(),
                            Rol = reader["nombre_rol"] != DBNull.Value ? reader["nombre_rol"].ToString() : "Sin Usuario"
                        });
                    }
                }
            }
            return lista;
        }

        public void CambiarEstadoEmpleado(int idEmpleado, int nuevoEstado)
        {
            using (var conexion = Conexion.ObtenerConexion())
            {
                string query = @"
                    UPDATE Empleado SET estado = @nuevoEstado WHERE id_empleado = @idEmpleado;
                    UPDATE Usuario SET estado = @nuevoEstado WHERE id_empleado = @idEmpleado;";

                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@nuevoEstado", nuevoEstado);
                    comando.Parameters.AddWithValue("@idEmpleado", idEmpleado);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        public DataTable ObtenerEmpleadosTabla()
        {
            DataTable dt = new DataTable();
            using (var conexion = Conexion.ObtenerConexion())
            {
                // Unimos con Usuario para excluir a los administradores (id_rol <> 1)
                string query = @"SELECT 
                    e.id_empleado AS [ID],
                    e.dni_empleado AS [DNI],
                    e.nombre_empleado + ' ' + e.apellido_empleado AS [Nombre Completo],
                    e.correo_empleado AS [Correo],
                    e.telefono_empleado AS [Teléfono],
                    e.direccion_empleado AS [Dirección],
                    CASE WHEN e.estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS [Estado]
                 FROM Empleado e
                 LEFT JOIN Usuario u ON e.id_empleado = u.id_empleado
                 WHERE u.id_rol IS NULL OR u.id_rol <> 1";

                using (var comando = new SqlCommand(query, conexion))
                {
                    using (var da = new SqlDataAdapter(comando))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}