using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.DTO.Request
{
    public class CounselorDTO
    {
        [Required]
        public long DocumentType { get; set; }
        [Required]
        public string DocumentNumber { get; set; } 
        [Required]
        public string NumPhone { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public long AttentionType { get; set; }
    }
}
