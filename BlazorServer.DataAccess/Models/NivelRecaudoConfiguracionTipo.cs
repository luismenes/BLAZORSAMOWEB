using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class NivelRecaudoConfiguracionTipo
{
    public long Id { get; set; }

    public long? TipoRecaudoId { get; set; }

    public long? NivelRecaudoConfigId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public long? UsuarioId { get; set; }

    public bool? Activo { get; set; }

    public virtual NivelRecaudoConfiguracion? NivelRecaudoConfig { get; set; }

    public virtual Dato? TipoRecaudo { get; set; }

    public virtual User? Usuario { get; set; }
}
