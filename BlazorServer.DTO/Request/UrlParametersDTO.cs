using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.DTO.Request
{
    public class UrlParametersDTO
    {
        public long UserId { get; set; }
        public string KeySession { get; set; }
        public List<Parameter> Parameters { get; set; }
        public class Parameter
        {
            public string KeySede { get; set; }
            public string ValueCliente { get; set; }
        }
    }
}
