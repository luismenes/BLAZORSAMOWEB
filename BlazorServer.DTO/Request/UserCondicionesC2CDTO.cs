using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.DTO.Request
{
    public class UserCondicionesC2CDTO
    {
        public bool DatosSensibles { get; set; }
        public bool DatosPersonales { get; set; }
    }
}
