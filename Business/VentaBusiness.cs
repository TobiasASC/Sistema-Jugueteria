
using System;
using System.Linq;
using SistemaJugueteria.Data;
using SistemaJugueteria.Entities;

namespace SistemaJugueteria.Business
{
    public class VentaBusiness
    {
        private readonly VentaData ventaData = new VentaData();

        public int RegistrarVenta(
            Venta venta,
            decimal porcentajePuntosGenerados = 0.01m,
            bool aplicarDescuentoPuntos = false)
        {
            const int costoPuntosCanje = 1000;

            if (venta == null)
                throw new ArgumentNullException(nameof(venta));

            if (venta.IdSocio <= 0)
                throw new InvalidOperationException(
                    "Debe seleccionar un socio para registrar la venta.");

            if (venta.Detalles == null || venta.Detalles.Count == 0)
                throw new InvalidOperationException(
                    "La venta debe tener al menos un producto.");

            if (porcentajePuntosGenerados < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(porcentajePuntosGenerados));

            // Identificar al socio.
            SocioBusiness negocioSocio = new SocioBusiness();

            var socio = negocioSocio.ListarSocios()
                .FirstOrDefault(s => s.IdSocio == venta.IdSocio);

            if (socio == null)
                throw new InvalidOperationException(
                    "No se encontró el socio seleccionado.");

            bool esConsumidorFinal = socio.DniSocio == "00000000";

            if (esConsumidorFinal && aplicarDescuentoPuntos)
            {
                throw new InvalidOperationException(
                    "Consumidor Final no puede canjear puntos.");
            }

            int puntosGastados = aplicarDescuentoPuntos
                ? costoPuntosCanje
                : 0;

            // El formulario debe enviar el total sin descuento.
            decimal subtotal = venta.SubtotalVenta;

            if (subtotal <= 0)
                throw new InvalidOperationException(
                    "El subtotal de la venta debe ser mayor que cero.");

            // Aplicar el descuento una sola vez.
            venta.TotalVenta = aplicarDescuentoPuntos
                ? Math.Round(subtotal * 0.90m, 2)
                : subtotal;

            // Consumidor Final no acumula puntos.
            // El resto acumula el porcentaje del total efectivamente pagado.
            int puntosNuevos = esConsumidorFinal
                ? 0
                : (int)(venta.TotalVenta * porcentajePuntosGenerados);

            // Guardar únicamente los puntos NUEVOS en la venta.
            // Los puntos gastados se envían por separado.
            venta.PuntosGenerados = puntosNuevos;

            return ventaData.RegistrarVenta(venta, puntosGastados);
        }
    }
}
