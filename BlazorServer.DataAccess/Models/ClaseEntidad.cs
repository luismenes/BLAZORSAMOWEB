using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class ClaseEntidad
{
    public long Id { get; set; }

    public long? ClaseEntidadId { get; set; }

    public long? EntidadId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public long? UsuarioId { get; set; }

    public bool? Activo { get; set; }

    public virtual Dato? ClaseEntidadNavigation { get; set; }

    public virtual Entidad? Entidad { get; set; }

    public virtual User? Usuario { get; set; }
}
