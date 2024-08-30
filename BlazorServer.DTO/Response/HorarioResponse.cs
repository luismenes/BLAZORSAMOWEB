using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.DTO.Response
{
    public class HorarioResponse
    {
        public bool Validacion { get; set; }
        public string Status { get; set; }
        public string Descripcion { get; set; }
    }
}
