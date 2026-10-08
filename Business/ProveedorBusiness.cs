using System.Collections.Generic;
using SistemaJugueteria.Data;
using SistemaJugueteria.Entities;

namespace SistemaJugueteria.Business
{
    public class ProveedorBusiness
    {
        private ProveedorData _proveedorData = new ProveedorData();

        public List<Proveedor> ListarProveedores()
        {
            return _proveedorData.ListarProveedores();
        }
    }
}
