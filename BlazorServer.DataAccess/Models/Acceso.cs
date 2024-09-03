using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class Acceso
{
    public long Id { get; set; }

    public long IdRol { get; set; }

    public long MenuId { get; set; }

    public bool? Visible { get; set; }

    public long? OperacionId { get; set; }

    public virtual Rol IdRolNavigation { get; set; } = null!;

    public virtual Menu Menu { get; set; } = null!;

    public virtual Operacion? Operacion { get; set; }
}
