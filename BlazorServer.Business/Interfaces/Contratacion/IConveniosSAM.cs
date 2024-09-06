using BlazorServer.DTO.Request.Contratacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.Business.Interfaces.Contratacion
{
    public interface IConveniosSAM
    {
        Task<bool> SaveManagement(ConvenioDTO Register);
    }
}
