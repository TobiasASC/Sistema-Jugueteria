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
            //  Validar que las contraseñas ingresadas en los TextBox coincidan
            if (nuevoUsuario.Contraseña != confirmarContraseña)
            {
                throw new ArgumentException("Las contraseñas no coinciden. Por favor, verifíquelas.");
            }

            // Validar que tenga un empleado asociado (búsqueda por DNI previa)
            if (nuevoUsuario.IdEmpleado <= 0)
            {
                throw new ArgumentException("Debe buscar y seleccionar un empleado válido antes de crear el usuario.");
            }

            // Hashear la contraseña usando BCrypt (Validando que no se encripte dos veces si ya viene encriptada)
            // Los hashes de BCrypt siempre empiezan con "$2a$", "$2b$" o "$2y$"
            if (!nuevoUsuario.Contraseña.StartsWith("$2"))
            {
                nuevoUsuario.Contraseña = BCrypt.Net.BCrypt.HashPassword(nuevoUsuario.Contraseña);
            }

            // Llamar a la capa de Datos enviando la operación dinámica ('A' o 'M')
            UsuarioData data = new UsuarioData();
            data.ABMUsuario(nuevoUsuario, operacion);
        }

        
        public Usuario ValidarPinAutorizacion(string usuarioInput, string pinInput)
        {
            if (string.IsNullOrEmpty(usuarioInput) || string.IsNullOrEmpty(pinInput))
            {
                throw new ArgumentException("El usuario y el PIN son obligatorios.");
            }

            UsuarioData data = new UsuarioData();
            Usuario usuarioBD = data.ObtenerUsuario(usuarioInput);

            if (usuarioBD != null)
            {
                if (usuarioBD.Estado == 0)
                {
                    throw new ArgumentException("Error de autorización: Usuario gerente dado de baja.");
                }

                // Si el usuario no tiene un PIN configurado todavía
                if (string.IsNullOrEmpty(usuarioBD.Pin_Seguridad)) 
                {
                    throw new ArgumentException("El usuario ingresado no tiene un PIN de seguridad configurado.");
                }

                // Verificamos el PIN ingresado contra el hash de la base de datos
                bool pinCorrecto = BCrypt.Net.BCrypt.Verify(pinInput, usuarioBD.Pin_Seguridad);

                if (pinCorrecto)
                {
                    return usuarioBD;
                }
            }

            return null; // Usuario no existe o PIN incorrecto
        }

        
        public string ConfigurarNuevoPin(int idUsuario, string nuevoPin, string confirmarPin)
        {
            if (string.IsNullOrWhiteSpace(nuevoPin) || string.IsNullOrWhiteSpace(confirmarPin))
            {
                throw new ArgumentException("Debe completar ambos campos.");
            }

            if (nuevoPin != confirmarPin)
            {
                throw new ArgumentException("Los PINs ingresados no coinciden. Verifíquelos.");
            }

            if (nuevoPin.Length < 4)
            {
                throw new ArgumentException("Por seguridad, el PIN debe tener al menos 4 dígitos.");
            }

            // Encriptamos el PIN exactamente igual que una contraseña
            string pinHash = BCrypt.Net.BCrypt.HashPassword(nuevoPin);

            // Llamamos a la capa de datos
            _usuarioData.ActualizarPinSeguridad(idUsuario, pinHash);

            return "Su PIN de seguridad ha sido configurado correctamente.";
        }

    }
}

