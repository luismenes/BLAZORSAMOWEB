using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class UserSede
{
    public long Id { get; set; }

    public long SedeId { get; set; }

    public long UsuarioId { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public long UsuarioCreacion { get; set; }

    public long? UsuarioModificacion { get; set; }

    public bool Activo { get; set; }

    public virtual Sede Sede { get; set; } = null!;

    public virtual User UsuarioCreacionNavigation { get; set; } = null!;

    public virtual User? UsuarioModificacionNavigation { get; set; }
}
