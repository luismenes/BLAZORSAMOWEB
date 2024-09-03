using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class NivelRecaudoConfiguracion
{
    public long Id { get; set; }

    public long? RecaudoId { get; set; }

    public long TipoUsuarioId { get; set; }

    public long? TipoRecaudoId { get; set; }

    public long? TipoCobroId { get; set; }

    public int? CantidadItems { get; set; }

    public bool EsProcedimiento { get; set; }

    public bool EsArticulo { get; set; }

    public bool EsOtro { get; set; }

    public long RedondeoId { get; set; }

    public long? UnidadRedondeoId { get; set; }

    public bool ConImpuesto { get; set; }

    public long? ImpuestoId { get; set; }

    public bool ConTope { get; set; }

    public long? CobrarId { get; set; }

    public int? Anho { get; set; }

    public decimal? ValorIndividual { get; set; }

    public decimal? ValorPorCuenta { get; set; }

    public decimal? ValorAnual { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreate { get; set; }

    public DateTime? FechaUpdate { get; set; }

    public long? UserId { get; set; }

    public long? OperacionId { get; set; }

    public virtual Dato? Cobrar { get; set; }

    public virtual Dato? Impuesto { get; set; }

    public virtual ICollection<NivelRecaudoConfiguracionProcedimiento> NivelRecaudoConfiguracionProcedimientos { get; set; } = new List<NivelRecaudoConfiguracionProcedimiento>();

    public virtual ICollection<NivelRecaudoConfiguracionTipo> NivelRecaudoConfiguracionTipos { get; set; } = new List<NivelRecaudoConfiguracionTipo>();

    public virtual Operacion? Operacion { get; set; }

    public virtual NivelRecaudo? Recaudo { get; set; }

    public virtual Dato Redondeo { get; set; } = null!;

    public virtual Dato? TipoCobro { get; set; }

    public virtual Dato? TipoRecaudo { get; set; }

    public virtual Dato TipoUsuario { get; set; } = null!;

    public virtual Dato? UnidadRedondeo { get; set; }

    public virtual User? User { get; set; }
}
