using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class ConvenioControlProcedimiento
{
    public long Id { get; set; }

    public long ConvenioId { get; set; }

    public long ProcedimientoId { get; set; }

    public long TipoControlId { get; set; }

    public DateTime FechaCreacion { get; set; }

    public bool Activo { get; set; }

    public virtual Convenio Convenio { get; set; } = null!;

    public virtual Procedimiento Procedimiento { get; set; } = null!;

    public virtual Dato TipoControl { get; set; } = null!;
}
