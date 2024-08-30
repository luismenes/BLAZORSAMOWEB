using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.DTO.Request.C2CRequest
{
    public class RequestC2C
    {
        public UserModelC2CDTO DatosCliente { get; set; }
        public UserModelCaracterizaDTO DatosCaracterizacion { get; set; }
        public UserCondicionesC2CDTO DatosCondiciones { get; set; }

    }
}
