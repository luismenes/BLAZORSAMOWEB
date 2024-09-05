using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.DTO.Response.Constant
{
    public class PaginacionResult<T>
    {
        public List<T> Elementos { get; set; }
        public int TotalPaginas { get; set; }
    }
}
