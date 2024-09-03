using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class Entidad
{
    public long Id { get; set; }

    public long IdTipoIdentificacion { get; set; }

    public string NumeroIdentificacion { get; set; } = null!;

    public string? PrimerNombre { get; set; }

    public string? SegundoNombre { get; set; }

    public string? PrimerApellido { get; set; }

    public string? SegundoApellido { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono1 { get; set; }

    public string? Telefono2 { get; set; }

    public string? Email { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? UltimaModificacion { get; set; }

    public string? Usuario { get; set; }

    public string? IpMaquina { get; set; }

    public string? NombreMaquina { get; set; }

    public bool? Activo { get; set; }

    public long? OperacionId { get; set; }

    public long? TipoPersonaId { get; set; }

    public string? TarjetaProfesional { get; set; }

    public string? RazonSocial { get; set; }

    public string? DigitoVerificacion { get; set; }

    public string? RepresentanteLegal { get; set; }

    public string? Responsable { get; set; }

    public long? NaturalezaJuridicaId { get; set; }

    public string? Barrio { get; set; }

    public int? ZonaId { get; set; }

    public long? DepartamentoId { get; set; }

    public long? CiudadId { get; set; }

    public DateTime? FechaExpedicion { get; set; }

    public string? LugarExpedicion { get; set; }

    public long? UsuarioGestionaId { get; set; }

    public string? CiudadNacimiento { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public long? GeneroId { get; set; }

    public long? EstadoCivil { get; set; }

    public virtual Ciudad? Ciudad { get; set; }

    public virtual ICollection<ClaseEntidad> ClaseEntidads { get; set; } = new List<ClaseEntidad>();

    public virtual Departamento? Departamento { get; set; }

    public virtual ICollection<DetalleOperacion> DetalleOperacions { get; set; } = new List<DetalleOperacion>();

    public virtual Dato? EstadoCivilNavigation { get; set; }

    public virtual Dato? Genero { get; set; }

    public virtual Dato IdTipoIdentificacionNavigation { get; set; } = null!;

    public virtual ICollection<Ip> Ips { get; set; } = new List<Ip>();

    public virtual Operacion? Operacion { get; set; }

    public virtual ICollection<Profesional> Profesionals { get; set; } = new List<Profesional>();

    public virtual Dato? TipoPersona { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual User? UsuarioGestiona { get; set; }

    public virtual ZonaResidencial? Zona { get; set; }
}
