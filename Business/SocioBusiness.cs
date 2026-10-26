using SistemaJugueteria.Data;
using SistemaJugueteria.Entities;
using System.Collections.Generic;
using System.Data;

namespace SistemaJugueteria.Business
{
    public class SocioBusiness
    {
        private SocioData datosSocio = new SocioData();

        // Se agrega el parámetro booleano para controlar si se traen activos o inactivos
        public List<Socio> ListarSocios(bool verInactivos = false)
        {
            return datosSocio.Listar(verInactivos);
        }

        public void GuardarSocio(Socio socio)
        {
            if (socio.IdSocio == 0)
            {
                datosSocio.Insertar(socio);
            }
            else
            {
                datosSocio.Actualizar(socio);
            }
        }

        public void EliminarSocio(int idSocio)
        {
            datosSocio.Eliminar(idSocio);
        }

        public string ReactivarSocio(int idSocio)
        {
            if (idSocio <= 0) return "Debe seleccionar un cliente para reactivar.";

            bool respuesta = datosSocio.Reactivar(idSocio);
            return respuesta ? "Cliente reactivado exitosamente." : "Error al reactivar el cliente.";
        }


        public DataTable ObtenerReporteClientes(
            bool incluirActivos,
            bool incluirInactivos,
            string criterioOrden)
        {
            return datosSocio.ObtenerReporteClientes(
                incluirActivos,
                incluirInactivos,
                criterioOrden);
        }

    }
}