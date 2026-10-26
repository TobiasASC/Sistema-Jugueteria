
using SistemaJugueteria.Data;
using SistemaJugueteria.Entities;
using System;
using System.Data;

namespace SistemaJugueteria.Business
{
    public class ReporteBusiness
    {
        private readonly ReporteData _reporteData = new ReporteData();

        public int RegistrarReporte(Reporte reporte)
        {
            if (reporte == null)
                throw new ArgumentNullException(nameof(reporte));

            if (reporte.IdTipoReporte <= 0)
                throw new ArgumentException("Debe seleccionar un tipo de reporte.");

            if (reporte.IdUsuario <= 0)
                throw new ArgumentException("El usuario no es válido.");

            return _reporteData.RegistrarReporte(reporte);
        }

        public DataTable ListarReportes(
            int? idTipoReporte = null,
            DateTime? fecha = null)
        {
            return _reporteData.ListarReportes(idTipoReporte, fecha);
        }

        public int ObtenerIdTipoReportePorNombre(string nombreTipo)
        {
            if (string.IsNullOrWhiteSpace(nombreTipo))
            {
                throw new ArgumentException(
                    "Debe indicar el tipo de reporte."
                );
            }

            return _reporteData.ObtenerIdTipoReportePorNombre(nombreTipo);
        }
    }
}
