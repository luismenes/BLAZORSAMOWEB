using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class User
{
    public long Id { get; set; }

    public string UserName { get; set; } = null!;

    public string? Password { get; set; }

    public bool Estado { get; set; }

    public DateTime FechaCreate { get; set; }

    public DateTime FechaUpdate { get; set; }

    public byte[]? Foto { get; set; }

    public byte[]? Firma { get; set; }

    public long? Entidadld { get; set; }

    public long? OperacionId { get; set; }

    public virtual ICollection<ClaseEntidad> ClaseEntidads { get; set; } = new List<ClaseEntidad>();

    public virtual ICollection<ConfiguracionPlantilla> ConfiguracionPlantillas { get; set; } = new List<ConfiguracionPlantilla>();

    public virtual ICollection<DetalleOperacion> DetalleOperacions { get; set; } = new List<DetalleOperacion>();

    public virtual Entidad? EntidadldNavigation { get; set; }

    public virtual ICollection<Entidad> Entidads { get; set; } = new List<Entidad>();

    public virtual ICollection<Especialidad> EspecialidadUsuarioActualizaNavigations { get; set; } = new List<Especialidad>();

    public virtual ICollection<Especialidad> EspecialidadUsuarioCreacionNavigations { get; set; } = new List<Especialidad>();

    public virtual ICollection<Ip> IpUsuarioCreacionNavigations { get; set; } = new List<Ip>();

    public virtual ICollection<Ip> IpUsuarioModificacionNavigations { get; set; } = new List<Ip>();

    public virtual ICollection<NivelRecaudoConfiguracionProcedimiento> NivelRecaudoConfiguracionProcedimientos { get; set; } = new List<NivelRecaudoConfiguracionProcedimiento>();

    public virtual ICollection<NivelRecaudoConfiguracionTipo> NivelRecaudoConfiguracionTipos { get; set; } = new List<NivelRecaudoConfiguracionTipo>();

    public virtual ICollection<NivelRecaudoConfiguracion> NivelRecaudoConfiguracions { get; set; } = new List<NivelRecaudoConfiguracion>();

    public virtual ICollection<NivelRecaudo> NivelRecaudoUsuarioActualizaNavigations { get; set; } = new List<NivelRecaudo>();

    public virtual ICollection<NivelRecaudo> NivelRecaudoUsuarioCreacionNavigations { get; set; } = new List<NivelRecaudo>();

    public virtual Operacion? Operacion { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();

    public virtual ICollection<PlanSalud> PlanSaludUsuarioActualizaNavigations { get; set; } = new List<PlanSalud>();

    public virtual ICollection<PlanSalud> PlanSaludUsuarioCreacionNavigations { get; set; } = new List<PlanSalud>();

    public virtual ICollection<Procedimiento> ProcedimientoUsuarioActualizaNavigations { get; set; } = new List<Procedimiento>();

    public virtual ICollection<Procedimiento> ProcedimientoUsuarioCreacionNavigations { get; set; } = new List<Procedimiento>();

    public virtual ICollection<Profesional> Profesionals { get; set; } = new List<Profesional>();

    public virtual ICollection<RolUser> RolUsers { get; set; } = new List<RolUser>();

    public virtual ICollection<Sede> SedeUsuarioCreacionNavigations { get; set; } = new List<Sede>();

    public virtual ICollection<Sede> SedeUsuarioModificacionNavigations { get; set; } = new List<Sede>();

    public virtual ICollection<Tarifa> TarifaUsuarioActualizaNavigations { get; set; } = new List<Tarifa>();

    public virtual ICollection<Tarifa> TarifaUsuarioCreacionNavigations { get; set; } = new List<Tarifa>();

    public virtual ICollection<TarifaVigencium> TarifaVigencia { get; set; } = new List<TarifaVigencium>();

    public virtual ICollection<TarifaVigenciaConfiguracion> TarifaVigenciaConfiguracions { get; set; } = new List<TarifaVigenciaConfiguracion>();

    public virtual ICollection<UserSede> UserSedeUsuarioCreacionNavigations { get; set; } = new List<UserSede>();

    public virtual ICollection<UserSede> UserSedeUsuarioModificacionNavigations { get; set; } = new List<UserSede>();
}
