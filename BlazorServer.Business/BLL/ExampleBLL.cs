using AutoMapper;
using BlazorServer.Business.Interfaces;
using BlazorServer.Business.Interfaces.BaseBLL;
using BlazorServer.DataAccess.Models;
using BlazorServer.DTO.Request;
using BlazorServer.DTO.Response;

namespace BlazorServer.Business.BLL
{
    public class ExampleBLL : IDBExampleBLLQuery
    {
        private readonly IMapper _mapper;
        private readonly IBaseBLL<RequestExample, ResponseExample, Tabla, long> _BaseBLL;
        public ExampleBLL(IMapper mapper, IBaseBLL<RequestExample, ResponseExample, Tabla, long> baseBLL)
        {
            _mapper = mapper;
            _BaseBLL = baseBLL;
        }

        public async Task<GenericResponse<bool>> DBExampleQueryMethod()
        {
            try
            {
                var query = await _BaseBLL.GetAll();
                if (query.Datos != null)
                {
                    return GenericResponse<bool>.ResponseOK(true);
                }
                return GenericResponse<bool>.NoData();

            }
            catch (Exception ex)
            {
                return GenericResponse<bool>.ResponseError(ex.Message);
            }
        }
    }
}
