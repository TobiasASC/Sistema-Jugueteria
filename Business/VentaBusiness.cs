using SistemaJugueteria.Data;
using SistemaJugueteria.Entities;

namespace SistemaJugueteria.Business
{
    public class VentaBusiness
    {
        private VentaData ventaData = new VentaData();

        public int RegistrarVenta(Venta venta, decimal porcentajePuntosGenerados = 0.01m, bool aplicarDescuentoPuntos = false)
        {
            const int costoPuntosCanje = 1000;
            int puntosNuevos = 0;
            int puntosGastados = 0;

            bool esConsumidorFinal = false;

            // Verificamos si el ID del socio corresponde al DNI "00000000"
            if (venta.IdSocio > 0)
            {
                SocioBusiness negocioSocio = new SocioBusiness();
                // Buscamos al socio en la lista para comprobar su DNI
                var socio = negocioSocio.ListarSocios().FirstOrDefault(s => s.IdSocio == venta.IdSocio);
                if (socio != null && socio.DniSocio == "00000000")
                {
                    esConsumidorFinal = true;
                }
            }

            // Si aplica descuento por puntos pero es consumidor final, lo ignoramos por seguridad
            if (aplicarDescuentoPuntos && !esConsumidorFinal)
            {
                puntosGastados = costoPuntosCanje;
                venta.TotalVenta = venta.TotalVenta * 0.90m; // 10% de descuento
            }

            // REGLA: Si NO es consumidor final, calculamos y acumulamos puntos. Si es consumidor final, quedan en 0.
            if (!esConsumidorFinal)
            {
                puntosNuevos = (int)(venta.TotalVenta * porcentajePuntosGenerados);
            }

            // Balance neto de puntos
            venta.PuntosGenerados = puntosNuevos - puntosGastados;

            // Guardar en la base de datos a través de la capa de datos
            return ventaData.RegistrarVenta(venta);
        }
    }
}
