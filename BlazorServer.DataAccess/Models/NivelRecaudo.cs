using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class NivelRecaudo
{
    public long Id { get; set; }

    public string? Codigo { get; set; }

    public string? Nombre { get; set; }

    public long? TipoVinculacionId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public long? UsuarioCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public long? UsuarioActualiza { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<NivelRecaudoConfiguracion> NivelRecaudoConfiguracions { get; set; } = new List<NivelRecaudoConfiguracion>();

    public virtual Dato? TipoVinculacion { get; set; }

    public virtual User? UsuarioActualizaNavigation { get; set; }

    public virtual User? UsuarioCreacionNavigation { get; set; }
}
