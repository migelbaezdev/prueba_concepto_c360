using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FalabellaPE.PortalSAC.Console.Proxy;

namespace PortalSac_PruebaConcepto
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = " https://falabellape-portalsacapi.azurewebsites.net";
            var request = new
            {
                fechaCreacion = "2019-11-11T15:00:00Z",
                folio = 12782513531,
                courier = new
                {
                    id = 1
                },
                motivo = new
                {
                    id = 17
                },
                ubicacion = "1258474854,-188212225"
            };
            new DeliveryApiProxy(url).ActualizarEstado(request);
        }
    }
}
