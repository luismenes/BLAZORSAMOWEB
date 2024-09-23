using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class ConvenioSede
{
    public long Id { get; set; }

    public long? ConvenioId { get; set; }

    public long? SedeId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public long? UsuarioId { get; set; }

    public bool? Activo { get; set; }

    public virtual Convenio? Convenio { get; set; }

    public virtual Sede? Sede { get; set; }
}
