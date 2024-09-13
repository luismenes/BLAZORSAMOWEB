using BlazorServer.DataAccess.Models;
using BlazorServer.DTO.Request.Contratacion;
using BlazorServer.DTO.Response.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlazorServer.Business.BLL.Contratacion.ConveniosSAM;

namespace BlazorServer.Business.Interfaces.Contratacion
{
    public interface IConveniosSAM
    {
        Task<bool> SaveManagement(ConvenioDTO Register);

        Task<PaginacionResult<ConveDto>> ObtenerConvenios(string nombreConvenio, long? tipoConvenioId, int pagina, int tamañoPagina, long operacionId);
        Task<bool> UpdateManagement(ConvenioDTO Register);
        Task<ConvenioDTO> EditarConvenio(long id);
        Task<bool> CambiarEstadoConvenio(long id, long usuarioId);
        Task<IEnumerable<SedeConvenioDTO>> ObtenerSedes(long? convenioId);

        Task<bool> ActivarSede(long convenioId, long sedeId, long usuarioId);
    }
}
