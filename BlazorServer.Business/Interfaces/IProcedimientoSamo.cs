using BlazorServer.DTO.Response.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlazorServer.Business.BLL.ProcedimientoSamo;

namespace BlazorServer.Business.Interfaces
{
    public interface IProcedimientoSamo
    {
        Task<PaginacionResult<ProcedimientoDto>> ObtenerProcedimeintos(string Codigo, string nombre, int pagina, int tamañoPagina);
        Task<ProcedimientoDto> ObtenerProcedimeinto(long procedimeintoID);
    }
}
