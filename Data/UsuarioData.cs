using SistemaJugueteria.Entities;
using Microsoft.Data.SqlClient;
using System.Data;
using System;

namespace SistemaJugueteria.Data
{
    // Eliminamos la herencia de ConexionBase
    public class UsuarioData
    {
        public Usuario ObtenerUsuario(string usuario)
        {
            Usuario usuarioEncontrado = null;

            // Llamamos a la clase estática Conexion
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var comando = new SqlCommand("sp_ValidarUsuario", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("p_nombre_usuario", usuario);

                    try
                    {
                        conexion.Open();
                        using (var reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                usuarioEncontrado = new Usuario
                                {
                                    IdUsuario = Convert.ToInt32(reader["id_usuario"]),
                                    NombreUsuario = reader["nombre_usuario"].ToString(),
                                    Contraseña = reader["contraseña"].ToString(),
                                    IdRol = Convert.ToInt32(reader["id_rol"]),
                                    IdEmpleado = Convert.ToInt32(reader["id_empleado"]),
                                    Estado = Convert.ToInt32(reader["estado"])
                                };
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error en la base de datos: " + ex.Message);
                    }
                }
            }
            return usuarioEncontrado;
        }

        public int ABMUsuario(Usuario usuario, char operacion)
        {
            int idGenerado = 0;
            using (var conexion = Conexion.ObtenerConexion())
            {
                using (var comando = new SqlCommand("sp_ABM_Usuario", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@p_Operacion", operacion);
                    comando.Parameters.AddWithValue("@p_id_usuario", usuario.IdUsuario == 0 ? (object)DBNull.Value : usuario.IdUsuario);
                    comando.Parameters.AddWithValue("@p_nombre_usuario", usuario.NombreUsuario);
                    comando.Parameters.AddWithValue("@p_contraseña", usuario.Contraseña);
                    comando.Parameters.AddWithValue("@p_id_rol", usuario.IdRol);
                    comando.Parameters.AddWithValue("@p_id_empleado", usuario.IdEmpleado);

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

        public Usuario BuscarUsuarioPorIdEmpleado(int idEmpleado)
        {
            Usuario usuarioEncontrado = null;
            using (var conexion = Conexion.ObtenerConexion())
            {
                string query = "SELECT id_usuario, nombre_usuario, contraseña, id_rol FROM Usuario WHERE id_empleado = @idEmpleado";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                    conexion.Open();
                    using (var reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuarioEncontrado = new Usuario
                            {
                                IdUsuario = Convert.ToInt32(reader["id_usuario"]),
                                NombreUsuario = reader["nombre_usuario"].ToString(),
                                Contraseña = reader["contraseña"].ToString(),
                                IdRol = Convert.ToInt32(reader["id_rol"]),
                                IdEmpleado = idEmpleado
                            };
                        }
                    }
                }
            }
            return usuarioEncontrado;
        }
    }
}