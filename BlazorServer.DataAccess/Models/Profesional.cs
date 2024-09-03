using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class Profesional
{
    public long Id { get; set; }

    public long? Entidadld { get; set; }

    public long? TipoVinculacionId { get; set; }

    public long? ClasePrestadorId { get; set; }

    public long? TipoProfesionalId { get; set; }

    public long? ClasificacionId { get; set; }

    public long? CargoId { get; set; }

    public string? SociedadMedica { get; set; }

    public string? NumeroRegistro { get; set; }

    public string? CantidadCitaExtra { get; set; }

    public string? CantidadCitaExtraMin { get; set; }

    public DateTime? FechaInicial { get; set; }

    public DateTime? FechaFinal { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreate { get; set; }

    public DateTime FechaUpdate { get; set; }

    public long? UserId { get; set; }

    public long? OperacionId { get; set; }

    public virtual Dato? Cargo { get; set; }

    public virtual Dato? ClasePrestador { get; set; }

    public virtual Dato? Clasificacion { get; set; }

    public virtual Entidad? EntidadldNavigation { get; set; }

    public virtual Operacion? Operacion { get; set; }

    public virtual ICollection<ProfesionalEspecialidad> ProfesionalEspecialidads { get; set; } = new List<ProfesionalEspecialidad>();

    public virtual Dato? TipoProfesional { get; set; }

    public virtual Dato? TipoVinculacion { get; set; }

    public virtual User? User { get; set; }
}
