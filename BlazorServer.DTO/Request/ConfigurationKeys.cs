using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.DTO.Request
{
    public class ConfigurationKeys
    {
        public enum TipoControl : long
        {
            Frecuencia = 10387,
            Autorizaciones = 10388
        }
    }
}
