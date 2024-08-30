using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.DTO.Request
{
    public class UserModelC2CDTO
    {
        [Required(ErrorMessage = "El Nombre completo es requerido.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "El Tipo de Identificación es requerido.")]
        public int DocumentType { get; set; }

        [Required(ErrorMessage = "El Celular es requerido.")]
        [Phone(ErrorMessage = "El número de celular no es válido.")]
        public string NumPhone { get; set; }

        [Required(ErrorMessage = "La Identificación es requerida.")]
        public string DocumentNumber { get; set; }

        public string NameDocumentType { get; set; }

        public int Issue { get; set; }

        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]

        public int Department { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]

        public int City { get; set; }

        public string NameIssue { get; set; }

    }
}
