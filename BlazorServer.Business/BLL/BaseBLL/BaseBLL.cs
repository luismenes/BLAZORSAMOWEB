using AutoMapper;
using BlazorServer.Business.AutoMapper;
using BlazorServer.Business.Interfaces.BaseBLL;
using BlazorServer.DataAccess.Context;
using BlazorServer.DataAccess.Models.BaseEntity;
using BlazorServer.DTO.Response;
using BlazorServer.DTO.Response.Constant;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorServer.Business.BLL.BaseBLL
{
    public class BaseBLL<TModeloRequest, TModeloResponse, TEntity, PK> : IBaseBLL<TModeloRequest, TModeloResponse, TEntity, PK>
    where TModeloRequest : new()
    where TModeloResponse : new()
    where TEntity : BaseEntity<PK>, new()
    {
        private readonly BalzorServerContext _db;
        private readonly IMapper _mapper;
        public BaseBLL(IMapper mapper)
        {
            _mapper = mapper;
            _db = new BalzorServerContext();
        }

        public virtual async Task<GenericResponse<IEnumerable<TModeloResponse>>> GetAll()
        {
            try
            {
                List<TEntity> listaRegistrosEntidad = await _db.Set<TEntity>().ToListAsync();

                List<TModeloResponse> listaRegistros = ConvertMapping<TModeloRequest, TModeloResponse, TEntity, PK>.ConvertToResponseModelList(listaRegistrosEntidad);

                if (listaRegistros.Count() > 0)
                {
                    return GenericResponse<IEnumerable<TModeloResponse>>.ResponseOK(listaRegistros);
                }
                else
                {
                    return GenericResponse<IEnumerable<TModeloResponse>>.ResponseValidation(Constans.Messages.NoData);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<IEnumerable<TModeloResponse>>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<TModeloResponse>>getbyid(PK id)
        {
            try
            {
                TEntity? entidad = await _db.Set<TEntity>()
                    .FirstOrDefaultAsync(x => x.Id.Equals(id));

                TModeloResponse registro = ConvertMapping<TModeloRequest, TModeloResponse, TEntity, PK>.ConvertToResponseModel(entidad);

                if (registro != null)
                {
                    return GenericResponse<TModeloResponse>.ResponseOK(registro);
                }
                else
                {
                    return GenericResponse<TModeloResponse>.ResponseValidation(Constans.Messages.NoData);
                }
            }
            catch (Exception ex)
            {

                return GenericResponse<TModeloResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<TModeloResponse>> Modify(TModeloRequest modeloModificado)
        {
            try
            {
                TEntity entidadModificada = ConvertMapping<TModeloRequest, TModeloResponse, TEntity, PK>.ConvertToEntity(modeloModificado);
                TEntity? entidad = await _db.Set<TEntity>()
                    .FirstOrDefaultAsync(x => x.Id.Equals(entidadModificada.Id));

                if (entidad == null)
                {
                    return null;
                }

                UpdateModel(modeloModificado, entidad);
                await _db.SaveChangesAsync();

                TModeloResponse modelo = ConvertMapping<TModeloRequest, TModeloResponse, TEntity, PK>.ConvertToResponseModel(entidad);

                if (modelo != null)
                {
                    return GenericResponse<TModeloResponse>.ResponseOK(modelo);
                }
                else
                {
                    return GenericResponse<TModeloResponse>.ResponseValidation(Constans.Messages.NoData);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<TModeloResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<TModeloResponse>> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var query = await _db.Set<TEntity>().AsNoTracking().Where(expression).FirstOrDefaultAsync();
                TModeloResponse coneverted = ConvertMapping<TModeloRequest, TModeloResponse, TEntity, PK>.ConvertToResponseModel(query);

                if (coneverted != null)
                {
                    return GenericResponse<TModeloResponse>.ResponseOK(coneverted);
                }
                else
                {
                    return GenericResponse<TModeloResponse>.ResponseValidation(Constans.Messages.NoData);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<TModeloResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<IEnumerable<TModeloResponse>>> GetAsyncList(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var query = await _db.Set<TEntity>().AsNoTracking().Where(expression).ToListAsync();

                IEnumerable<TModeloResponse> modeloResponse = ConvertMapping<TModeloRequest, TModeloResponse, TEntity, PK>.ConvertToResponseModelList(query);

                if (modeloResponse.Count() > 0)
                {
                    return GenericResponse<IEnumerable<TModeloResponse>>.ResponseOK(modeloResponse);
                }
                else
                {
                    return GenericResponse<IEnumerable<TModeloResponse>>.ResponseValidation(Constans.Messages.NoData);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<IEnumerable<TModeloResponse>>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<TModeloResponse>> Insert(TModeloRequest modelo)
        {
            try
            {
                TEntity entidad = ConvertMapping<TModeloRequest, TModeloResponse, TEntity, PK>.ConvertToEntity(modelo);
                _db.Set<TEntity>().Add(entidad);
                await _db.SaveChangesAsync();
                TModeloResponse modeloResponse = ConvertMapping<TModeloRequest, TModeloResponse, TEntity, PK>.ConvertToResponseModel(entidad);

                if (modelo != null)
                {
                    return GenericResponse<TModeloResponse>.ResponseOK(modeloResponse);
                }
                else
                {
                    return GenericResponse<TModeloResponse>.ResponseValidation(Constans.Messages.NoData);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<TModeloResponse>.ResponseError(ex.Message);
            }
        }

        protected virtual void UpdateModel(TModeloRequest modelo, TEntity entidad)
        {
        }
    }
}
