using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class ResolucionAutoretenedor
{
    public long Id { get; set; }

    public long IpsId { get; set; }

    public string? Nombre { get; set; }

    public long? ResolucionId { get; set; }

    public virtual Ip Ips { get; set; } = null!;

    public virtual Dato? Resolucion { get; set; }
}
