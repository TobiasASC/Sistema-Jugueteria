using SistemaJugueteria.Data;
using System;
using System.Data;
using System.IO;
using System.Linq;

namespace SistemaJugueteria.Business
{
    public class BackupBusiness
    {
        private BackupData _backupData = new BackupData();
        private readonly string directorioBackup = @"C:\Jugueteria_Backups";

        // MÉTODO PARA LISTAR LOS ARCHIVOS DE LA CARPETA EN UN DATATABLE
        public DataTable ObtenerHistorialBackups()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Numero");
            dt.Columns.Add("Base_de_Datos");
            dt.Columns.Add("Ruta");
            dt.Columns.Add("Fecha", typeof(DateTime));

            if (Directory.Exists(directorioBackup))
            {
                // Se obtienen todos los archivos .bak en la carpeta y se ordenan por fecha de creación descendente
                DirectoryInfo dir = new DirectoryInfo(directorioBackup);
                FileInfo[] archivos = dir.GetFiles("*.bak");

                // Ordenar los archivos por fecha de creación descendente
                var archivosOrdenados = archivos.OrderByDescending(f => f.CreationTime).ToList();

                int contador = archivosOrdenados.Count; // Para enumerarlos del más nuevo al más viejo

                foreach (FileInfo file in archivosOrdenados)
                {
                    // Llena la fila con los metadatos del archivo de Windows
                    dt.Rows.Add(
                        contador.ToString("D5"),
                        "SistemaJugueteriaDB",
                        file.FullName,
                        file.CreationTime
                    );
                    contador--;
                }
            }

            return dt;
        }

        // MÉTODO PARA GENERAR EL BACKUP
        public string GenerarNuevoBackup()
        {
            string fechaFormato = DateTime.Now.ToString("ddMMyyyy_HHmmss");
            string nombreArchivo = $"Backup_{fechaFormato}.bak";

            string resultado = _backupData.CrearBackup(nombreArchivo);

            if (resultado.StartsWith("OK|"))
            {
                string rutaGuardada = resultado.Split('|')[1];
                return $"El backup se generó exitosamente en la ruta:\n{rutaGuardada}";
            }
            else
            {
                string error = resultado.Split('|')[1];
                return $"Ocurrió un error al generar el backup:\n{error}";
            }
        }

        // MÉTODO PARA RESTAURAR
        public string RestaurarDesdeBackup(string rutaArchivo)
        {
            if (string.IsNullOrWhiteSpace(rutaArchivo))
            {
                return "Debe seleccionar un archivo válido para restaurar.";
            }

            if (!File.Exists(rutaArchivo))
            {
                return "El archivo de backup seleccionado ya no existe en el disco.";
            }

            string resultado = _backupData.RestaurarBackup(rutaArchivo);

            if (resultado == "OK")
            {
                return "La base de datos se restauró exitosamente al estado seleccionado.";
            }
            else
            {
                string error = resultado.Split('|')[1];
                return $"Error crítico al restaurar la base de datos:\n{error}";
            }
        }
    }
}