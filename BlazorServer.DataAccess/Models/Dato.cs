using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class Dato
{
    public long Id { get; set; }

    public long TablaId { get; set; }

    public string? Codigo { get; set; }

    public string? Nombre { get; set; }

    public long? Valor { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public long? PadreId { get; set; }

    public string? Equivalente { get; set; }

    public string? Herencia { get; set; }

    public virtual ICollection<AmbitoProcedimiento> AmbitoProcedimientos { get; set; } = new List<AmbitoProcedimiento>();

    public virtual ICollection<AmbitoSede> AmbitoSedes { get; set; } = new List<AmbitoSede>();

    public virtual ICollection<ClaseEntidad> ClaseEntidads { get; set; } = new List<ClaseEntidad>();

    public virtual ICollection<Convenio> ConvenioClases { get; set; } = new List<Convenio>();

    public virtual ICollection<ConvenioControlProcedimiento> ConvenioControlProcedimientos { get; set; } = new List<ConvenioControlProcedimiento>();

    public virtual ICollection<Convenio> ConvenioOrigenConvenios { get; set; } = new List<Convenio>();

    public virtual ICollection<Convenio> ConvenioTipoConvenios { get; set; } = new List<Convenio>();

    public virtual ICollection<Convenio> ConvenioTipoUserRegimenNavigations { get; set; } = new List<Convenio>();

    public virtual ICollection<DetalleOperacion> DetalleOperacionAmbitos { get; set; } = new List<DetalleOperacion>();

    public virtual ICollection<DetalleOperacion> DetalleOperacionCentralizados { get; set; } = new List<DetalleOperacion>();

    public virtual ICollection<DetalleOperacion> DetalleOperacionCostoNiffs { get; set; } = new List<DetalleOperacion>();

    public virtual ICollection<DetalleOperacion> DetalleOperacionIdTipoIdentificacionNavigations { get; set; } = new List<DetalleOperacion>();

    public virtual ICollection<DetalleOperacion> DetalleOperacionRegimen { get; set; } = new List<DetalleOperacion>();

    public virtual ICollection<DetalleOperacion> DetalleOperacionTipoContribuyentes { get; set; } = new List<DetalleOperacion>();

    public virtual ICollection<DetalleOperacion> DetalleOperacionTipoPersonas { get; set; } = new List<DetalleOperacion>();

    public virtual ICollection<DetalleOperacion> DetalleOperacionTipoPlans { get; set; } = new List<DetalleOperacion>();

    public virtual ICollection<Entidad> EntidadEstadoCivilNavigations { get; set; } = new List<Entidad>();

    public virtual ICollection<Entidad> EntidadGeneros { get; set; } = new List<Entidad>();

    public virtual ICollection<Entidad> EntidadIdTipoIdentificacionNavigations { get; set; } = new List<Entidad>();

    public virtual ICollection<Entidad> EntidadTipoPersonas { get; set; } = new List<Entidad>();

    public virtual ICollection<Ip> IpIdActividadEconomicaNavigations { get; set; } = new List<Ip>();

    public virtual ICollection<Ip> IpIdActoAdministrativoNavigations { get; set; } = new List<Ip>();

    public virtual ICollection<Ip> IpIdClaseEntidadNavigations { get; set; } = new List<Ip>();

    public virtual ICollection<Ip> IpIdEstadoSociedadNavigations { get; set; } = new List<Ip>();

    public virtual ICollection<Ip> IpIdGrupoNiifNavigations { get; set; } = new List<Ip>();

    public virtual ICollection<Ip> IpIdNaturalezaNavigations { get; set; } = new List<Ip>();

    public virtual ICollection<Ip> IpIdTipoContribuyenteNavigations { get; set; } = new List<Ip>();

    public virtual ICollection<Ip> IpIdTipoDocRepresentanteNavigations { get; set; } = new List<Ip>();

    public virtual ICollection<Ip> IpIdTipoEmpresaNavigations { get; set; } = new List<Ip>();

    public virtual ICollection<Ip> IpIdTipoResolucionNavigations { get; set; } = new List<Ip>();

    public virtual ICollection<Ip> IpTipoIdentificacionNavigations { get; set; } = new List<Ip>();

    public virtual ICollection<NivelRecaudoConfiguracion> NivelRecaudoConfiguracionCobrars { get; set; } = new List<NivelRecaudoConfiguracion>();

    public virtual ICollection<NivelRecaudoConfiguracion> NivelRecaudoConfiguracionImpuestos { get; set; } = new List<NivelRecaudoConfiguracion>();

    public virtual ICollection<NivelRecaudoConfiguracionProcedimiento> NivelRecaudoConfiguracionProcedimientoAmbitos { get; set; } = new List<NivelRecaudoConfiguracionProcedimiento>();

    public virtual ICollection<NivelRecaudoConfiguracionProcedimiento> NivelRecaudoConfiguracionProcedimientoTipoProcedimientos { get; set; } = new List<NivelRecaudoConfiguracionProcedimiento>();

    public virtual ICollection<NivelRecaudoConfiguracion> NivelRecaudoConfiguracionRedondeos { get; set; } = new List<NivelRecaudoConfiguracion>();

    public virtual ICollection<NivelRecaudoConfiguracion> NivelRecaudoConfiguracionTipoCobros { get; set; } = new List<NivelRecaudoConfiguracion>();

    public virtual ICollection<NivelRecaudoConfiguracion> NivelRecaudoConfiguracionTipoRecaudos { get; set; } = new List<NivelRecaudoConfiguracion>();

    public virtual ICollection<NivelRecaudoConfiguracion> NivelRecaudoConfiguracionTipoUsuarios { get; set; } = new List<NivelRecaudoConfiguracion>();

    public virtual ICollection<NivelRecaudoConfiguracionTipo> NivelRecaudoConfiguracionTipos { get; set; } = new List<NivelRecaudoConfiguracionTipo>();

    public virtual ICollection<NivelRecaudoConfiguracion> NivelRecaudoConfiguracionUnidadRedondeos { get; set; } = new List<NivelRecaudoConfiguracion>();

    public virtual ICollection<NivelRecaudo> NivelRecaudos { get; set; } = new List<NivelRecaudo>();

    public virtual ICollection<NivelSede> NivelSedes { get; set; } = new List<NivelSede>();

    public virtual ICollection<Paciente> PacienteClasificacions { get; set; } = new List<Paciente>();

    public virtual ICollection<Paciente> PacienteDiscapacidads { get; set; } = new List<Paciente>();

    public virtual ICollection<Paciente> PacienteDocumentoNavigations { get; set; } = new List<Paciente>();

    public virtual ICollection<Paciente> PacienteEstadoCivils { get; set; } = new List<Paciente>();

    public virtual ICollection<Paciente> PacienteEtnia { get; set; } = new List<Paciente>();

    public virtual ICollection<Paciente> PacienteFactorRhs { get; set; } = new List<Paciente>();

    public virtual ICollection<Paciente> PacienteGeneros { get; set; } = new List<Paciente>();

    public virtual ICollection<Paciente> PacienteGradoDiscapacidads { get; set; } = new List<Paciente>();

    public virtual ICollection<Paciente> PacienteGrupoSangres { get; set; } = new List<Paciente>();

    public virtual ICollection<Paciente> PacienteOcupacions { get; set; } = new List<Paciente>();

    public virtual ICollection<Paciente> PacienteProfesions { get; set; } = new List<Paciente>();

    public virtual ICollection<PlanSalud> PlanSaluds { get; set; } = new List<PlanSalud>();

    public virtual ICollection<Procedimiento> ProcedimientoAltoCostoNavigations { get; set; } = new List<Procedimiento>();

    public virtual ICollection<Procedimiento> ProcedimientoClaseRangos { get; set; } = new List<Procedimiento>();

    public virtual ICollection<Procedimiento> ProcedimientoComplejidads { get; set; } = new List<Procedimiento>();

    public virtual ICollection<Procedimiento> ProcedimientoConcentimientos { get; set; } = new List<Procedimiento>();

    public virtual ICollection<Procedimiento> ProcedimientoConceptos { get; set; } = new List<Procedimiento>();

    public virtual ICollection<Procedimiento> ProcedimientoEdads { get; set; } = new List<Procedimiento>();

    public virtual ICollection<Procedimiento> ProcedimientoExtramurals { get; set; } = new List<Procedimiento>();

    public virtual ICollection<Procedimiento> ProcedimientoFinalidadProdedimientos { get; set; } = new List<Procedimiento>();

    public virtual ICollection<Procedimiento> ProcedimientoGeneros { get; set; } = new List<Procedimiento>();

    public virtual ICollection<Procedimiento> ProcedimientoNivelAtencions { get; set; } = new List<Procedimiento>();

    public virtual ICollection<Procedimiento> ProcedimientoNivelAutorizacions { get; set; } = new List<Procedimiento>();

    public virtual ICollection<Procedimiento> ProcedimientoPaquetes { get; set; } = new List<Procedimiento>();

    public virtual ICollection<Procedimiento> ProcedimientoPos { get; set; } = new List<Procedimiento>();

    public virtual ICollection<Procedimiento> ProcedimientoTipoProcedimientos { get; set; } = new List<Procedimiento>();

    public virtual ICollection<Profesional> ProfesionalCargos { get; set; } = new List<Profesional>();

    public virtual ICollection<Profesional> ProfesionalClasePrestadors { get; set; } = new List<Profesional>();

    public virtual ICollection<Profesional> ProfesionalClasificacions { get; set; } = new List<Profesional>();

    public virtual ICollection<Profesional> ProfesionalTipoProfesionals { get; set; } = new List<Profesional>();

    public virtual ICollection<Profesional> ProfesionalTipoVinculacions { get; set; } = new List<Profesional>();

    public virtual ICollection<ResolucionAutoretenedor> ResolucionAutoretenedors { get; set; } = new List<ResolucionAutoretenedor>();

    public virtual ICollection<Sede> Sedes { get; set; } = new List<Sede>();

    public virtual Tabla Tabla { get; set; } = null!;

    public virtual ICollection<TarifaVigenciaConfiguracion> TarifaVigenciaConfiguracionGrupoQxes { get; set; } = new List<TarifaVigenciaConfiguracion>();

    public virtual ICollection<TarifaVigenciaConfiguracion> TarifaVigenciaConfiguracionImpuestos { get; set; } = new List<TarifaVigenciaConfiguracion>();

    public virtual ICollection<TarifaVigenciaConfiguracion> TarifaVigenciaConfiguracionLiquidacions { get; set; } = new List<TarifaVigenciaConfiguracion>();
}
