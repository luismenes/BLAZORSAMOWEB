using BlazorServer.DataAccess.Context;
using BlazorServer.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.Business.BLL.TablaDatos
{
    public class TablaDatoService : IDisposable
    {
        private readonly SamoContext _context;

        // Inyectamos el contexto de base de datos (SamoEntities)
        public TablaDatoService()
        {
            _context = new SamoContext();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        // Método asíncrono para obtener los datos de la tabla
        public async Task<List<Dato>> ObtenerDatosTablaAsync(long TablaId)
        {
            return await _context.Datos
                                 .Where(x => x.TablaId == TablaId && x.Activo == true && x.Tabla.Activo == true)
                                 .OrderBy(x => x.Nombre)
                                 .ToListAsync();
        }

        // Método asíncrono para obtener datos de Departamento
        public async Task<List<Departamento>> ObtenerDatosDepartamentoAsync(long IdPais)
        {
            return await _context.Departamentos
                                 .Where(x => x.IdPais == IdPais)
                                 .ToListAsync();
        }

        // Método asíncrono para obtener datos de Ciudad/Municipio
        public async Task<List<Ciudad>> ObtenerDatosMunicipioAsync(long IdDpto)
        {
            return await _context.Ciudads
                                 .Where(x => x.IdDepartamento == IdDpto)
                                 .ToListAsync();
        }

        // Método asíncrono para obtener datos de Zona Residencial
        public async Task<List<ZonaResidencial>> ObtenerDatosZonaAsync()
        {
            return await _context.ZonaResidencials.ToListAsync();
        }

        // Método asíncrono para obtener el tipo de persona
        public async Task<Dato> ObtenerTipoPersonaAsync(long DatoIdentificacion)
        {
            return await _context.Datos
                                 .Where(x => (DatoIdentificacion == 126 ? x.Id == (long)ConfiguracionGlobal.TipoPersona.Juridica : x.Id == (long)ConfiguracionGlobal.TipoPersona.Natural) && x.Activo == true)
                                 .FirstOrDefaultAsync();
        }

        // Método asíncrono para obtener las clases de entidades según el tipo de persona
        public async Task<List<Dato>> ObtenerClaseEntidadesAsync(long DatoTipoPersona)
        {
            return await _context.Datos
                                 .Where(x => x.PadreId == DatoTipoPersona && x.Activo == true)
                                 .OrderBy(x => x.Nombre)
                                 .ToListAsync();
        }

        public async Task<List<Dato>> ObtenerClaseEntidadesJuridicaAsync()
        {
            return await _context.Datos
                                 .Where(x => x.PadreId == (long)ConfiguracionGlobal.TipoPersona.Juridica && x.Activo == true)
                                 .OrderBy(x => x.Nombre)
                                 .ToListAsync();
        }
    }
}
