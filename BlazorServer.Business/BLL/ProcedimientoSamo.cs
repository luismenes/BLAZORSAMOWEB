using BlazorServer.Business.Interfaces;
using BlazorServer.DataAccess.Context;
using BlazorServer.DTO.Response.Constant;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.Business.BLL
{
    public class ProcedimientoSamo : IProcedimientoSamo
    {
        public class ProcedimientoDto
        {
            public long Id { get; set; }
            public string Nombre { get; set; }
            public string Tipo { get; set; }
            public bool Activo { get; set; }
            public string EstadoClass { get; set; }
            public string EstadoTooltip { get; set; }
            public string EstadoColor { get; set; }
            public string IconClass { get; set; }

        }
        public async Task<PaginacionResult<ProcedimientoDto>> ObtenerProcedimeintos(string codigo, string nombre, int pagina, int tamañoPagina)
        {
            using (SamoContext db = new SamoContext())
            {
                var query = db.Procedimientos
                .Where(c => c.Activo == true &&
                    (codigo == null || c.Codigo.Contains(codigo)) &&
                    (nombre == null || c.Nombre.Contains(nombre)));

                var totalElementos = await query.CountAsync();

                var elementos = await query
                    .Skip((pagina - 1) * tamañoPagina)
                    .Take(tamañoPagina)
                    .Select(c => new ProcedimientoDto
                    {
                        Id = c.Id,
                        Nombre = "(" + c.Codigo + ") -" + c.Nombre,
                        Tipo = c.TipoProcedimiento.Nombre,
                        Activo = (bool)c.Activo
                    })
                    .OrderBy(x => x.Id)
                    .ToListAsync();

                var totalPaginas = (int)Math.Ceiling(totalElementos / (double)tamañoPagina);

                return new PaginacionResult<ProcedimientoDto>
                {
                    Elementos = elementos,
                    TotalPaginas = totalPaginas
                };
            }
        }

        public async Task<ProcedimientoDto> ObtenerProcedimeinto(long procedimeintoID)
        {

            using (SamoContext db = new SamoContext())
            {
                var procedimiento = await db.Procedimientos
                     .Where(x => x.Id == procedimeintoID && x.Activo == true)
                     .FirstOrDefaultAsync();

                // Si el procedimiento no se encuentra, retorna null
                if (procedimiento == null)
                    return null;

                // Mapeo manual de la entidad Procedimiento a ProcedimientoDto
                return new ProcedimientoDto
                {
                    Id = procedimiento.Id,
                };
            }
        }
    }
}
