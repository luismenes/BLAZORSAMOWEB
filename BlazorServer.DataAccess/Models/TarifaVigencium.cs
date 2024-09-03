using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class TarifaVigencium
{
    public long Id { get; set; }

    public long? TarifaId { get; set; }

    public DateTime FechaAplicacion { get; set; }

    public string? Codigo { get; set; }

    public bool EsSmmlv { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreate { get; set; }

    public DateTime FechaUpdate { get; set; }

    public long? UserId { get; set; }

    public long? OperacionId { get; set; }

    public virtual Operacion? Operacion { get; set; }

    public virtual Tarifa? Tarifa { get; set; }

    public virtual ICollection<TarifaVigenciaConfiguracion> TarifaVigenciaConfiguracions { get; set; } = new List<TarifaVigenciaConfiguracion>();

    public virtual User? User { get; set; }
}
