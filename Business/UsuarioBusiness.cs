using SistemaJugueteria.Data;
using SistemaJugueteria.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaJugueteria.Business
{
    public class UsuarioBusiness
    {
        private UsuarioData _usuarioData = new UsuarioData();

        public Usuario AutenticarUsuario(string usuarioInput, string contraseñaInput)
        {
            if (string.IsNullOrEmpty(usuarioInput) || string.IsNullOrEmpty(contraseñaInput))
            {
                throw new ArgumentException("El usuario y la contraseña son obligatorios.");
            }

            UsuarioData data = new UsuarioData();
            Usuario usuarioBD = data.ObtenerUsuario(usuarioInput);

            if (usuarioBD != null)
            {
                
                if (usuarioBD.Estado == 0)
                {
                    
                    throw new ArgumentException("Error al ingresar: Usuario dado de baja.");
                }

                
                bool claveCorrecta = BCrypt.Net.BCrypt.Verify(contraseñaInput, usuarioBD.Contraseña);

                if (claveCorrecta)
                {
                    return usuarioBD;
                }
            }

            // Si el usuarioBD es nulo (no existe el nombre) o la clave falló
            return null;
        }


        public void RegistrarUsuario(Usuario nuevoUsuario, string confirmarContraseña, char operacion)
        {
            // 1. Validar que las contraseñas ingresadas en los TextBox coincidan
            if (nuevoUsuario.Contraseña != confirmarContraseña)
            {
                throw new ArgumentException("Las contraseñas no coinciden. Por favor, verifíquelas.");
            }

            // 2. Validar que tenga un empleado asociado (búsqueda por DNI previa)
            if (nuevoUsuario.IdEmpleado <= 0)
            {
                throw new ArgumentException("Debe buscar y seleccionar un empleado válido antes de crear el usuario.");
            }

            // 3. Hashear la contraseña usando BCrypt (Validando que no se encripte dos veces si ya viene encriptada)
            // Los hashes de BCrypt siempre empiezan con "$2a$", "$2b$" o "$2y$"
            if (!nuevoUsuario.Contraseña.StartsWith("$2"))
            {
                nuevoUsuario.Contraseña = BCrypt.Net.BCrypt.HashPassword(nuevoUsuario.Contraseña);
            }

            // 4. Llamar a la capa de Datos enviando la operación dinámica ('A' o 'M')
            UsuarioData data = new UsuarioData();
            data.ABMUsuario(nuevoUsuario, operacion);
        }

    }
}

