using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class TarifaVigenciaConfiguracion
{
    public long Id { get; set; }

    public long? VigenciaId { get; set; }

    public long ProcedimientoId { get; set; }

    public long? LiquidacionId { get; set; }

    public long? GrupoQxid { get; set; }

    public decimal? Valor { get; set; }

    public bool ConImpuesto { get; set; }

    public long? ImpuestoId { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreate { get; set; }

    public DateTime? FechaUpdate { get; set; }

    public long? UserId { get; set; }

    public long? OperacionId { get; set; }

    public virtual Dato? GrupoQx { get; set; }

    public virtual Dato? Impuesto { get; set; }

    public virtual Dato? Liquidacion { get; set; }

    public virtual Operacion? Operacion { get; set; }

    public virtual Procedimiento Procedimiento { get; set; } = null!;

    public virtual User? User { get; set; }

    public virtual TarifaVigencium? Vigencia { get; set; }
}
