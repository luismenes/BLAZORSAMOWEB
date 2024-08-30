using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.DTO.Request
{
    public class UserModelCaracterizaDTO
    {
        [Required(ErrorMessage = "Campo requerido.")]

        public int AgeRange { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]

        public int Sex { get; set; }
        public int Feature { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]

        public int Organization { get; set; }
        public int Disability { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]

        public int LGBTIQ { get; set; }

        public string NameFeature { get; set; }
        public string NameDisability { get; set; }
        public string NameLGBTIQ { get; set; }
        public string NameOrganization { get; set; }
        public string NameVulnerabilidad { get; set; }
        public int Vulnerabilidad { get; set; }
    }
}
