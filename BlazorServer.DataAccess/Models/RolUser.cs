using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class RolUser
{
    public long Id { get; set; }

    public long RolId { get; set; }

    public long UsuarioId { get; set; }

    public DateTime FechaCreacion { get; set; }

    public bool Activo { get; set; }

    public virtual Rol Rol { get; set; } = null!;

    public virtual User Usuario { get; set; } = null!;
}
