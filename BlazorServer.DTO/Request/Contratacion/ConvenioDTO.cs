using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.DTO.Request.Contratacion
{
    public class ConvenioDTO
    {
        public long Id { get; set; }

        public string? Codigo { get; set; }

        public string? Nombre { get; set; }

        public long ClaseId { get; set; }

        public long EntidadId { get; set; }
        public string NombreEntidad { get; set; }

        public string CodigoEapb { get; set; }

        public string TipoConvenioId { get; set; }

        public string OrigenConvenioId { get; set; }

        public string TipoUserRegimen { get; set; }

        public string? PoblacionAtiende { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public DateTime? FechaPrestaInicio { get; set; }

        public DateTime? FechaPrestaFin { get; set; }

        public bool EsTodaSede { get; set; }

        public bool EsConBeneficiarios { get; set; }

        public bool EsJustNoPos { get; set; }

    }
}
