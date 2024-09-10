using BlazorServer.Business.Interfaces.Contratacion;
using BlazorServer.DataAccess.Context;
using BlazorServer.DataAccess.Models;
using BlazorServer.DTO.Request.Contratacion;
using BlazorServer.DTO.Response.Constant;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.Business.BLL.Contratacion
{
    public class ConveniosSAM : IConveniosSAM
    {
        private readonly SamoContext _samoContext;

        public ConveniosSAM()
        {
            //_samoContext = new SamoContext();
        }

        public class ConveDto
        {
            public long Id { get; set; }
            public string TipoConvenio { get; set; }
            public string Nombre { get; set; }
            public string Codigo { get; set; }
            public bool? Activo { get; set; }
            public string EstadoClass { get; set; }
            public string EstadoTooltip { get; set; }
            public string EstadoColor { get; set; }
            public string IconClass { get; set; }
        }

        public async Task<PaginacionResult<ConveDto>> ObtenerConvenios(string nombreConvenio, long? tipoConvenioId, int pagina, int tamañoPagina, long operacionId)
        {
            using (SamoContext db = new SamoContext())
            {
                var query = db.Convenios
                .Where(c => c.OperacionId == operacionId &&
                    (tipoConvenioId == 0 || c.TipoConvenioId == tipoConvenioId) &&
                    (string.IsNullOrWhiteSpace(nombreConvenio) || c.Nombre == nombreConvenio));

                var totalElementos = await query.CountAsync();

                var elementos = await query
                    .Skip((pagina - 1) * tamañoPagina)
                    .Take(tamañoPagina)
                    .Select(c => new ConveDto
                    {
                        Id = c.Id,
                        TipoConvenio = c.TipoConvenio.Nombre,
                        Codigo = c.Codigo,
                        Nombre = c.Nombre,
                        Activo = c.Activo,
                        EstadoClass = c.Activo == true ? "alert alert-success my-auto text-uppercase" : "alert alert-danger my-auto text-uppercase",
                        EstadoTooltip = c.Activo == true ? "Inactivar" : "Activar",
                        EstadoColor = c.Activo == true ? "btn btn-outline-danger btn-icon waves-effect waves-light" : "btn btn-outline-success btn-icon waves-effect waves-light",
                        IconClass = c.Activo != true ? "las la-check-circle" : "las la-exclamation-circle",
                    })
                    .OrderBy(x => x.Id)
                    .ToListAsync();

                var totalPaginas = (int)Math.Ceiling(totalElementos / (double)tamañoPagina);
                return new PaginacionResult<ConveDto>
                {
                    Elementos = elementos,
                    TotalPaginas = totalPaginas
                };
            }

        }

        public async Task<bool> SaveManagement(ConvenioDTO Register)
        {
            try
            {
                using (SamoContext db = new SamoContext())
                {
                    Convenio oRegister = new Convenio()
                    {
                        Codigo = Register.Codigo,
                        Nombre = Register.Nombre,
                        ClaseId = Register.ClaseId,
                        EntidadId = Register.EntidadId,
                        CodigoEapb = Register.CodigoEapb,
                        TipoConvenioId = Register.TipoConvenioId,
                        OrigenConvenioId = Register.OrigenConvenioId,
                        TipoUserRegimen = Register.TipoUserRegimen,
                        PoblacionAtiende = Register.PoblacionAtiende,
                        FechaInicio = Register.FechaInicio,
                        FechaFin = Register.FechaFin,
                        FechaPrestaInicio = Register.FechaPrestaInicio,
                        FechaPrestaFin = Register.FechaPrestaFin,
                        EsTodaSede = Register.EsTodaSede,
                        EsConBeneficiarios = Register.EsConBeneficiarios,
                        EsJustNoPos = Register.EsJustNoPos,
                        UsuarioId = Register.UsuarioId,
                        OperacionId = Register.OperacionId,
                        FechaCreacion = DateTime.Now,
                        Activo = true
                    };

                    db.Convenios.Add(oRegister);
                    await db.SaveChangesAsync();

                }
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<bool> UpdateManagement(ConvenioDTO Register)
        {
            try
            {
                using (SamoContext db = new SamoContext())
                {
                    var existingConvenio = await db.Convenios.FindAsync(Register.Id);

                    if (existingConvenio == null)
                    {
                        return false;
                    }

                    existingConvenio.Codigo = Register.Codigo;
                    existingConvenio.Nombre = Register.Nombre;
                    existingConvenio.ClaseId = Register.ClaseId;
                    existingConvenio.EntidadId = Register.EntidadId;
                    existingConvenio.CodigoEapb = Register.CodigoEapb;
                    existingConvenio.TipoConvenioId = Register.TipoConvenioId;
                    existingConvenio.OrigenConvenioId = Register.OrigenConvenioId;
                    existingConvenio.TipoUserRegimen = Register.TipoUserRegimen;
                    existingConvenio.PoblacionAtiende = Register.PoblacionAtiende;
                    existingConvenio.FechaInicio = Register.FechaInicio;
                    existingConvenio.FechaFin = Register.FechaFin;
                    existingConvenio.FechaPrestaInicio = Register.FechaPrestaInicio;
                    existingConvenio.FechaPrestaFin = Register.FechaPrestaFin;
                    existingConvenio.EsTodaSede = Register.EsTodaSede;
                    existingConvenio.EsConBeneficiarios = Register.EsConBeneficiarios;
                    existingConvenio.EsJustNoPos = Register.EsJustNoPos;
                    existingConvenio.UsuarioActualizaId = Register.UsuarioId;
                    existingConvenio.OperacionId = Register.OperacionId;
                    existingConvenio.FechaActualizacion = DateTime.Now; // Suponiendo que tienes un campo FechaModificacion
                    existingConvenio.Activo = true; // Si también estás actualizando el estado activo

                    // Guardar los cambios en la base de datos
                    await db.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception)
            {
                // Manejar la excepción, opcionalmente registrar el error
                return false;
                throw;
            }
        }

        public async Task<ConvenioDTO> EditarConvenio(long id)
        {

            using (SamoContext db = new SamoContext())
            {
                // Buscar el registro existente por su ID
                var convenio = await db.Convenios
                    .Where(c => c.Id == id)
                    .Select(c => new ConvenioDTO
                    {
                        Id = c.Id,
                        Codigo = c.Codigo,
                        Nombre = c.Nombre,
                        ClaseId = (long)c.ClaseId,
                        EntidadId = (long)c.EntidadId,
                        CodigoEapb = c.CodigoEapb,
                        TipoConvenioId = (long)c.TipoConvenioId,
                        OrigenConvenioId = (long)c.OrigenConvenioId,
                        TipoUserRegimen = (long)c.TipoUserRegimen,
                        PoblacionAtiende = c.PoblacionAtiende,
                        FechaInicio = c.FechaInicio,
                        FechaFin = c.FechaFin,
                        FechaPrestaInicio = c.FechaPrestaInicio,
                        FechaPrestaFin = c.FechaPrestaFin,
                        EsTodaSede = (bool)c.EsTodaSede,
                        EsConBeneficiarios = (bool)c.EsConBeneficiarios,
                        EsJustNoPos = (bool)c.EsJustNoPos,
                        OperacionId = c.OperacionId
                    })
                    .FirstOrDefaultAsync();

                return convenio;
            }

        }

        public async Task<bool> CambiarEstadoConvenio(long id, long usuarioId)
        {
            try
            {
                using (SamoContext db = new SamoContext())
                {
                    var convenio = await db.Convenios.FirstOrDefaultAsync(c => c.Id == id);
                    if (convenio == null) return false;

                    // Cambiar el estado (activo a inactivo y viceversa)
                    convenio.Activo = !convenio.Activo;
                    convenio.UsuarioActualizaId = usuarioId;
                    convenio.FechaActualizacion = DateTime.Now;
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                // Manejo de errores
                return false;
            }
        }

    }
}
