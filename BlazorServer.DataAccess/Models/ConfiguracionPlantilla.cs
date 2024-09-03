using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class ConfiguracionPlantilla
{
    public long Id { get; set; }

    public long? UserId { get; set; }

    public long? OperacionId { get; set; }

    public string? AttributesClass { get; set; }

    public string? AttributesStyle { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual Operacion? Operacion { get; set; }

    public virtual User? User { get; set; }
}
