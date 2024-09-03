using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class Paciente
{
    public long Id { get; set; }

    public string PrimerNombre { get; set; } = null!;

    public string? SegundoNombre { get; set; }

    public string PrimerApellido { get; set; } = null!;

    public string? SegundoApellido { get; set; }

    public long DocumentoId { get; set; }

    public string Documento { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public long GeneroId { get; set; }

    public long GrupoSangreId { get; set; }

    public long FactorRhid { get; set; }

    public long OcupacionId { get; set; }

    public long ProfesionId { get; set; }

    public long ClasificacionId { get; set; }

    public long DiscapacidadId { get; set; }

    public long GradoDiscapacidadId { get; set; }

    public long EstadoCivilId { get; set; }

    public long EtniaId { get; set; }

    public string? RiesgoJuridico { get; set; }

    public string? CasoEspecial { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public long? UsuarioId { get; set; }

    public long? OperacionId { get; set; }

    public virtual Dato Clasificacion { get; set; } = null!;

    public virtual ICollection<ContactoPaciente> ContactoPacientes { get; set; } = new List<ContactoPaciente>();

    public virtual Dato Discapacidad { get; set; } = null!;

    public virtual Dato DocumentoNavigation { get; set; } = null!;

    public virtual Dato EstadoCivil { get; set; } = null!;

    public virtual Dato Etnia { get; set; } = null!;

    public virtual Dato FactorRh { get; set; } = null!;

    public virtual Dato Genero { get; set; } = null!;

    public virtual Dato GradoDiscapacidad { get; set; } = null!;

    public virtual Dato GrupoSangre { get; set; } = null!;

    public virtual Dato Ocupacion { get; set; } = null!;

    public virtual Operacion? Operacion { get; set; }

    public virtual Dato Profesion { get; set; } = null!;

    public virtual User? Usuario { get; set; }
}
