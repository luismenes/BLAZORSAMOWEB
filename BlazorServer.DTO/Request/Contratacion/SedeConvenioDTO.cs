using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.DTO.Request.Contratacion
{
    public class SedeConvenioDTO
    {
        public long Id { get; set; }
        public long SedeId { get; set; }
        public string NombreSede { get; set; }
        public bool? Activo { get; set; }
        public string EstadoClass { get; set; }
        public string EstadoTooltip { get; set; }
        public string EstadoColor { get; set; }
        public string IconClass { get; set; }
    }
}
