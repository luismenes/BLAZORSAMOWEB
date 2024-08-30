using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.DTO.Request
{
    public class ConsumeObjetDTO
    {
        public string tablaid { get; set; }
        public string herencia { get; set; }
        public long? Padreid { get; set; }

    }

    public class ValidarHorario
    {
        public long Id { get; set; }
    }
}
