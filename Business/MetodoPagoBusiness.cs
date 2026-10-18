using System.Data;
using SistemaJugueteria.Data;

namespace SistemaJugueteria.Business
{
    public class MetodoPagoBusiness
    {
        private MetodoPagoData metodoPagoData = new MetodoPagoData();

        public DataTable ListarMetodosPago()
        {
            return metodoPagoData.ObtenerMetodosPago();
        }
    }
}