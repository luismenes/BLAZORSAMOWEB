using BlazorServer.DataAccess.Models;
using BlazorServer.DTO.Response.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlazorServer.Business.BLL.EntidadSamo;

namespace BlazorServer.Business.Interfaces
{
    public interface IEntidadSamo
    {
        Task<PaginacionResult<EntidadDto>> ObtenerEntidades(string identificacion, long? documentoIdentidadID, int pagina, int tamañoPagina, long operacionId, long? ClaseId = null);
        Task<Entidad> ObtenerEntidad(long entidadID);

    }
}
