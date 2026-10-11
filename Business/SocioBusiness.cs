using System.Collections.Generic;
using SistemaJugueteria.Data;
using SistemaJugueteria.Entities;

namespace SistemaJugueteria.Business
{
    public class SocioBusiness
    {
        private SocioData datosSocio = new SocioData();

        public List<Socio> ListarSocios(string dni = "", string nombre = "")
        {
            return datosSocio.ObtenerSocios(dni, nombre);
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
    }
}