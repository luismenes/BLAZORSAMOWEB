using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class NivelRecaudoConfiguracionProcedimiento
{
    public long Id { get; set; }

    public long? NivelRecaudoConfigId { get; set; }

    public long? TipoProcedimientoId { get; set; }

    public long? AmbitoId { get; set; }

    public bool? EsCobroValor { get; set; }

    public decimal? Valor { get; set; }

    public int? Procentaje { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public long? UsuarioId { get; set; }

    public bool? Activo { get; set; }

    public virtual Dato? Ambito { get; set; }

    public virtual NivelRecaudoConfiguracion? NivelRecaudoConfig { get; set; }

    public virtual Dato? TipoProcedimiento { get; set; }

    public virtual User? Usuario { get; set; }
}
