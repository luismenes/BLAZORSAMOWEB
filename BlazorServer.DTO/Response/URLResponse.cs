using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.DTO.Response
{
    public class URLResponse
    {
        public string? IdCita { get; set; }
        public string? Nit { get; set; }
        public string? Nombres { get; set; }
        public string? RazonSocial { get; set; }
        public string? Celular { get; set; }
        public string? ProcessID { get; set; }
        public string? Correo { get; set; }
        public DateTime? FechaCita { get; set; }
        public TimeSpan? HoraCita { get; set; }
        public bool IsVisible { get; set; }
        public string IframeUrl { get; set; }
        public DateTime? FechaCitaExpirada { get; set; }
        public short? CitaEstadoId { get; set; }
    }
}
