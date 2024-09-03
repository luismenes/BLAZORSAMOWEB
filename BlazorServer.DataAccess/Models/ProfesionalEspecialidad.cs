using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class ProfesionalEspecialidad
{
    public long Id { get; set; }

    public long ProfesionalId { get; set; }

    public long EspecialidadId { get; set; }

    public DateTime FechaCreacion { get; set; }

    public bool Activo { get; set; }

    public virtual Especialidad Especialidad { get; set; } = null!;

    public virtual Profesional Profesional { get; set; } = null!;
}
