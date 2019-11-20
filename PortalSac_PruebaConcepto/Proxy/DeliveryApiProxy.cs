﻿using Release.Helper;
using Release.Helper.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FalabellaPE.PortalSAC.Console.Proxy
{
    public class DeliveryApiProxy : BaseProxy
    {
        private string _url;
        public DeliveryApiProxy(string url)
        {
            this._url = url.TrimEnd('/');

        }

      

        public CommandResponse ActualizarEstado(string request)
        {
            var cr = this.CallWebApi<CommandResponse>(HttpMethod.Post, this._url + "/ExternalEntrega/actualizarEstado", request, timeout: 500);

            return cr;
        }
    }
}
