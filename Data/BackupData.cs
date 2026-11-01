using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.IO;

namespace SistemaJugueteria.Data
{
    public class BackupData
    {
        // CAMBIAR ESTO POR EL NOMBRE EXACTO DE TU BASE DE DATOS EN SQL SERVER
        private readonly string nombreBaseDatos = "sistema_jugueteria";

        // Ruta universal para evitar conflictos entre PCs
        private readonly string directorioBackup = @"C:\Jugueteria_Backups";

        public BackupData()
        {
            // Si la carpeta no existe en la PC actual, la crea automáticamente
            if (!Directory.Exists(directorioBackup))
            {
                Directory.CreateDirectory(directorioBackup);
            }
        }

        public string CrearBackup(string nombreArchivo)
        {
            string rutaCompleta = Path.Combine(directorioBackup, nombreArchivo);

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                try
                {
                    conexion.Open();
                    // Comando SQL puro para generar el archivo .bak
                    string query = $@"BACKUP DATABASE [{nombreBaseDatos}] 
                                      TO DISK = '{rutaCompleta}' 
                                      WITH FORMAT, MEDIANAME = 'DB_Jugueteria', NAME = 'Backup Completo'";

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.ExecuteNonQuery();

                    return "OK|" + rutaCompleta;
                }
                catch (Exception ex)
                {
                    return "ERROR|" + ex.Message;
                }
            }
        }

        public string RestaurarBackup(string rutaCompleta)
        {
            string connectionStringMaster = Conexion.ObtenerConexion().ConnectionString.Replace(nombreBaseDatos, "master");

            using (SqlConnection conexionMaster = new SqlConnection(connectionStringMaster))
            {
                try
                {
                    conexionMaster.Open();

                    // 1. Expulsar a todos los usuarios conectados (Single User)
                    // 2. Restaurar la base pisando la actual (Replace)
                    // 3. Volver a abrir la base al público (Multi User)
                    string query = $@"
                        ALTER DATABASE [{nombreBaseDatos}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                        RESTORE DATABASE [{nombreBaseDatos}] FROM DISK = '{rutaCompleta}' WITH REPLACE;
                        ALTER DATABASE [{nombreBaseDatos}] SET MULTI_USER;";

                    SqlCommand cmd = new SqlCommand(query, conexionMaster);
                    cmd.ExecuteNonQuery();

                    return "OK";
                }
                catch (Exception ex)
                {
                    return "ERROR|" + ex.Message;
                }
            }
        }
    }
}