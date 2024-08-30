using BlazorServer.DTO.Response;

namespace BlazorServer.Business.Interfaces
{
    public interface IDBExampleBLLQuery
    {
        Task<GenericResponse<bool>> DBExampleQueryMethod();
    }
}
