using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class Rol
{
    public long Id { get; set; }

    public string? Nombre { get; set; }

    public bool Estado { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Acceso> Accesos { get; set; } = new List<Acceso>();

    public virtual ICollection<RolUser> RolUsers { get; set; } = new List<RolUser>();
}
