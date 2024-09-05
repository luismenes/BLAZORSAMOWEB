using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class Operacion
{
    public long Id { get; set; }

    public string? NombreEmpresa { get; set; }

    public byte[]? LogoOperacion { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public long? UsuarioActualiza { get; set; }

    public string? CodigoPrestador { get; set; }

    public virtual ICollection<Acceso> Accesos { get; set; } = new List<Acceso>();

    public virtual ICollection<ConfiguracionPlantilla> ConfiguracionPlantillas { get; set; } = new List<ConfiguracionPlantilla>();

    public virtual ICollection<Convenio> Convenios { get; set; } = new List<Convenio>();

    public virtual ICollection<DetalleOperacion> DetalleOperacions { get; set; } = new List<DetalleOperacion>();

    public virtual ICollection<Entidad> Entidads { get; set; } = new List<Entidad>();

    public virtual ICollection<NivelRecaudoConfiguracion> NivelRecaudoConfiguracions { get; set; } = new List<NivelRecaudoConfiguracion>();

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();

    public virtual ICollection<Profesional> Profesionals { get; set; } = new List<Profesional>();

    public virtual ICollection<Sede> Sedes { get; set; } = new List<Sede>();

    public virtual ICollection<TarifaVigencium> TarifaVigencia { get; set; } = new List<TarifaVigencium>();

    public virtual ICollection<TarifaVigenciaConfiguracion> TarifaVigenciaConfiguracions { get; set; } = new List<TarifaVigenciaConfiguracion>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
