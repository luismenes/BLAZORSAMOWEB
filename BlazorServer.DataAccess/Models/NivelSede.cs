using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class NivelSede
{
    public long Id { get; set; }

    public long? NivelId { get; set; }

    public long? SedeId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public long? UsuarioId { get; set; }

    public bool? Activo { get; set; }

    public virtual Dato? Nivel { get; set; }

    public virtual Sede? Sede { get; set; }
}
