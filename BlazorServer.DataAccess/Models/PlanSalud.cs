using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class PlanSalud
{
    public long Id { get; set; }

    public long? TipoPlanId { get; set; }

    public string? Nombre { get; set; }

    public string? Observacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public long? UsuarioCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public long? UsuarioActualiza { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<PlanSaludProcedimiento> PlanSaludProcedimientos { get; set; } = new List<PlanSaludProcedimiento>();

    public virtual Dato? TipoPlan { get; set; }

    public virtual User? UsuarioActualizaNavigation { get; set; }

    public virtual User? UsuarioCreacionNavigation { get; set; }
}
