using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class Sede
{
    public long Id { get; set; }

    public long OperacionId { get; set; }

    public bool EsSede { get; set; }

    public long? SedePadre { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Activo { get; set; }

    public byte[]? Logo { get; set; }

    public long TipoSede { get; set; }

    public DateTime? FechaVigencia { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public long UsuarioCreacion { get; set; }

    public long? UsuarioModificacion { get; set; }

    public string? CodigoPrestador { get; set; }

    public virtual ICollection<AmbitoSede> AmbitoSedes { get; set; } = new List<AmbitoSede>();

    public virtual ICollection<Ip> Ips { get; set; } = new List<Ip>();

    public virtual ICollection<NivelSede> NivelSedes { get; set; } = new List<NivelSede>();

    public virtual Operacion Operacion { get; set; } = null!;

    public virtual Dato TipoSedeNavigation { get; set; } = null!;

    public virtual ICollection<UserSede> UserSedes { get; set; } = new List<UserSede>();

    public virtual User UsuarioCreacionNavigation { get; set; } = null!;

    public virtual User? UsuarioModificacionNavigation { get; set; }
}
