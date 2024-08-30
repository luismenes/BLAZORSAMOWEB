using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.DataAccess.Models.FineAgendamientoDian;

[Table("MallaAgenda", Schema = "Agendamiento")]
public partial class MallaAgenda
{
    [Key]
    public long Id { get; set; }

    public long? IdUsuario { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaCita { get; set; }

    public TimeSpan? HoraCita { get; set; }

    public int? IdJornada { get; set; }

    public bool? Activo { get; set; }

    public short? IdEstadoCita { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaRegistro { get; set; }

    [InverseProperty("IdMallaAgendaNavigation")]
    public virtual ICollection<Citas> Citas { get; set; } = new List<Citas>();
}
