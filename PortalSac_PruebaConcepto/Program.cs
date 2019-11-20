using PortalSac.APIClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PortalSac_PruebaConcepto
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;


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

            object obj1 = new RestClient().post("ExternalEntrega/actualizarEstado/", request);



            var request2 = new
            {
                Page = 1,
                PageSize = 10,
                estado_id = 1,
                courier_id = 1,
                fechaCreacion = "2019-11-20"
            };

            object obj2 = new RestClient().post("ExternalEntrega/busquedaPaginada/", request2);
        }
    }
}


