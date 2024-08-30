using BlazorServer.DTO.Response.Constant;

namespace BlazorServer.DTO.Response
{
    public class GenericResponse<TEntity>
    {
        public static string GetMessageException(Exception ex)
        {
            if (ex.InnerException != null)
            {
                return GetMessageException(ex.InnerException);
            }
            else
            {
                return ex.Message;
            }
        }

        public int Codigo { get; set; }

        public string? Mensaje { get; set; }

        public TEntity? Datos { get; set; }

        public static GenericResponse<TEntity> ResponseOK(TEntity datos, string mensaje = Constans.Messages.OK)
        {
            return new GenericResponse<TEntity>
            {
                Codigo = Constans.ApiCodes.OK,
                Mensaje = mensaje,
                Datos = datos
            };
        }

        public static GenericResponse<TEntity> ResponseValidation(string mensaje)
        {
            return new GenericResponse<TEntity>
            {
                Codigo = Constans.ApiCodes.ControlledError,
                Mensaje = mensaje,
                Datos = default(TEntity)
            };
        }

        public static GenericResponse<TEntity> ResponseError(string mensaje = Constans.Messages.UnexpectedError)
        {
            return new GenericResponse<TEntity>
            {
                Codigo = Constans.ApiCodes.UnexpectedError,
                Mensaje = mensaje,
                Datos = default(TEntity)
            };
        }

        public static GenericResponse<TEntity> ResponseError(Exception ex)
        {
            return new GenericResponse<TEntity>
            {
                Codigo = Constans.ApiCodes.UnexpectedError,
                Mensaje = GetMessageException(ex),
                Datos = default
            };
        }

        public static GenericResponse<TEntity> NoData(string mensaje = Constans.Messages.NoData)
        {
            return new GenericResponse<TEntity>
            {
                Codigo = Constans.ApiCodes.UnexpectedError,
                Mensaje = mensaje,
                Datos = default
            };
        }
    }
}
