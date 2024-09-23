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
using static BlazorServer.Business.BLL.ProcedimientoSamo;

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
                    (string.IsNullOrWhiteSpace(nombreConvenio) || c.Nombre.Contains(nombreConvenio)));

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

        public async Task<IEnumerable<SedeConvenioDTO>> ObtenerSedes(long? convenioId)
        {
            using (SamoContext db = new SamoContext())
            {
                // Primero, obtenemos todas las sedes activas
                var sedes = await db.Sedes.Where(s => s.Activo).ToListAsync();

                // Si se proporciona un convenioId, obtenemos la configuración de convenio
                var convenioSedes = convenioId.HasValue
                    ? await db.ConvenioSedes.Where(cs => cs.ConvenioId == convenioId.Value).ToListAsync()
                    : new List<ConvenioSede>();

                // Ahora combinamos las sedes con la configuración de convenio
                var result = from sede in sedes
                             join convenioSede in convenioSedes
                             on sede.Id equals convenioSede.SedeId into sedesConfig
                             from convenioSede in sedesConfig.DefaultIfEmpty() // LEFT JOIN
                             select new SedeConvenioDTO
                             {
                                 SedeId = sede.Id,
                                 NombreSede = sede.EsSede ? "Principal: " + sede.Nombre : sede.Nombre,
                                 Activo = convenioSede != null ? convenioSede.Activo : false, // Si no hay ConvenioSede, lo marcamos como inactivo
                                 EstadoClass = convenioSede != null && convenioSede.Activo == true
                                     ? "alert alert-success my-auto text-uppercase"
                                     : "alert alert-danger my-auto text-uppercase",
                                 EstadoTooltip = convenioSede != null && convenioSede.Activo == true
                                     ? "Inactivar"
                                     : "Activar",
                                 EstadoColor = convenioSede != null && convenioSede.Activo == true
                                     ? "btn btn-outline-danger btn-icon waves-effect waves-light"
                                     : "btn btn-outline-success btn-icon waves-effect waves-light",
                                 IconClass = convenioSede != null && !convenioSede.Activo == true
                                     ? "las la-check-circle"
                                     : "las la-exclamation-circle",
                             };

                return result.ToList(); // Aquí simplemente usamos ToList()
            }
        }

        public async Task<bool> ActivarSede(long convenioId, long sedeId, long usuarioId)
        {
            using (SamoContext db = new SamoContext())
            {
                var convenioSede = await db.ConvenioSedes
                                           .FirstOrDefaultAsync(cs => cs.ConvenioId == convenioId && cs.SedeId == sedeId);

                if (convenioSede != null)
                {
                    convenioSede.Activo = !convenioSede.Activo;
                    convenioSede.UsuarioId = usuarioId;
                    convenioSede.FechaModificacion = DateTime.Now;
                    db.ConvenioSedes.Update(convenioSede);
                }
                else
                {
                    var nuevaConvenioSede = new ConvenioSede
                    {
                        ConvenioId = convenioId,
                        SedeId = sedeId,
                        Activo = true,
                        UsuarioId = usuarioId,
                        FechaCreacion = DateTime.Now,
                    };
                    await db.ConvenioSedes.AddAsync(nuevaConvenioSede);
                };

                // Guardar cambios en la base de datos
                await db.SaveChangesAsync();
                return convenioSede?.Activo ?? true;
            }
        }

        public async Task<IEnumerable<ProcedimientoSamo.ProcedimientoDto>> ObtenerProcedimientoFrecuencia(long? convenioId, long tipo)
        {
            using (SamoContext db = new SamoContext())
            {
                // Obtener el control del convenio
                var convenioControl = await db.ConvenioControlProcedimientos
                    .Where(s => s.Activo && s.TipoControlId == tipo && s.ConvenioId == convenioId)
                    .Include(c => c.Procedimiento)  // Asegúrate de hacer un Include de las entidades relacionadas
                    .Include(c => c.Procedimiento.TipoProcedimiento)
                    .ToListAsync();

                // Proyección a ProcedimientoDto
                var result = from c in convenioControl
                             select new ProcedimientoDto
                             {
                                 Id = c.Id,
                                 Nombre = c?.Procedimiento != null && c.Procedimiento.Codigo != null && c.Procedimiento.Nombre != null
                                     ? "(" + c.Procedimiento.Codigo + ") -" + c.Procedimiento.Nombre
                                     : "N/A", // Valor predeterminado si alguna propiedad es nula
                                 Tipo = c?.Procedimiento?.TipoProcedimiento?.Nombre ?? "Desconocido", // Si es null, asigna un valor predeterminado
                                 Activo = c != null ? c.Activo : false, // Si no hay ConvenioSede, lo marcamos como inactivo
                                 EstadoClass = c != null && c.Activo == true
                                     ? "alert alert-success my-auto text-uppercase"
                                     : "alert alert-danger my-auto text-uppercase",
                                 EstadoTooltip = c != null && c.Activo == true
                                     ? "Inactivar"
                                     : "Activar",
                                 EstadoColor = c != null && c.Activo == true
                                     ? "btn btn-outline-danger btn-icon waves-effect waves-light"
                                     : "btn btn-outline-success btn-icon waves-effect waves-light",
                                 IconClass = c != null && !c.Activo == true
                                     ? "las la-check-circle"
                                     : "las la-exclamation-circle",
                             };

                return result.ToList(); // Convertir a lista y retornar
            }
        }


        public async Task<bool> ActivarProcedimiento(long convenioId, long tipo, long procedimientoId)
        {
            using (SamoContext db = new SamoContext())
            {
                var Obj = await db.ConvenioControlProcedimientos
                                           .FirstOrDefaultAsync(cs => cs.ConvenioId == convenioId && cs.ProcedimientoId == procedimientoId && cs.TipoControlId == tipo);

                if (Obj != null)
                {
                    Obj.Activo = Obj.Activo;
                    Obj.FechaCreacion = DateTime.Now;
                    db.ConvenioControlProcedimientos.Update(Obj);
                }
                else
                {
                    var newObj = new ConvenioControlProcedimiento
                    {
                        ConvenioId = convenioId,
                        ProcedimientoId = procedimientoId,
                        Activo = true,
                        TipoControlId = tipo,
                        FechaCreacion = DateTime.Now,
                    };
                    await db.ConvenioControlProcedimientos.AddAsync(newObj);
                };

                // Guardar cambios en la base de datos
                await db.SaveChangesAsync();
                return Obj?.Activo ?? true;
            }

        }
    }

}

