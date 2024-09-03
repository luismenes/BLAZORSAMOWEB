using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class EspecialidadProcedimiento
{
    public long Id { get; set; }

    public long EspecialidadId { get; set; }

    public long ProcedimientoId { get; set; }

    public DateTime FechaCreacion { get; set; }

    public bool Activo { get; set; }

    public virtual Especialidad Especialidad { get; set; } = null!;

    public virtual Procedimiento Procedimiento { get; set; } = null!;
}
