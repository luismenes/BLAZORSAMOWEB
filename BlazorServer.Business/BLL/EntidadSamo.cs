using BlazorServer.Business.Interfaces;
using BlazorServer.DataAccess.Context;
using BlazorServer.DataAccess.Models;
using BlazorServer.DTO.Response.Constant;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.Business.BLL
{
    public class EntidadSamo : IEntidadSamo
    {
        private readonly SamoContext _samoContext;

        public EntidadSamo()
        {
            _samoContext = new SamoContext();
        }
        public class EntidadDto
        {
            public long Id { get; set; }
            public string TipoIdentificacion { get; set; }
            public string Documento { get; set; }
            public string NombreEntidad { get; set; }
            public DateTime FechaCreacion { get; set; }
            public string TipoPersona { get; set; }
        }
        public async Task<PaginacionResult<EntidadDto>> ObtenerEntidades(string identificacion, long? documentoIdentidadID, int pagina, int tamañoPagina)
        {
            long operacionId = 1;

            var query = _samoContext.Entidads
                .Where(c => c.OperacionId == operacionId && c.Activo == true &&
                    (documentoIdentidadID == null || c.IdTipoIdentificacion == documentoIdentidadID) &&
                    (string.IsNullOrWhiteSpace(identificacion) || c.NumeroIdentificacion == identificacion));

            var totalElementos = await query.CountAsync();

            var elementos = await query
                .Skip((pagina - 1) * tamañoPagina)
                .Take(tamañoPagina)
                .Select(c => new EntidadDto
                {
                    Id = c.Id,
                    TipoIdentificacion = c.IdTipoIdentificacionNavigation.Nombre,
                    Documento = c.TipoPersonaId == 134 ? c.NumeroIdentificacion : $"{c.NumeroIdentificacion} - {c.DigitoVerificacion}",
                    NombreEntidad = c.TipoPersonaId == 134 ? $"{c.PrimerNombre} {c.SegundoNombre} {c.PrimerApellido} {c.SegundoApellido}" : c.RazonSocial,
                    FechaCreacion = c.FechaCreacion ?? DateTime.MinValue,
                    TipoPersona = c.TipoPersona.Nombre
                })
                .OrderBy(x => x.Id)
                .ToListAsync();

            var totalPaginas = (int)Math.Ceiling(totalElementos / (double)tamañoPagina);

            return new PaginacionResult<EntidadDto>
            {
                Elementos = elementos,
                TotalPaginas = totalPaginas
            };
        }

        public async Task<Entidad> ObtenerEntidad(long entidadID)
        {
            return await _samoContext.Entidads
                    .Include(e => e.IdTipoIdentificacionNavigation) // Incluye la propiedad de navegación
                    .Where(x => x.Id == entidadID && x.Activo == true)
                    .FirstOrDefaultAsync();
        }
    }
}
