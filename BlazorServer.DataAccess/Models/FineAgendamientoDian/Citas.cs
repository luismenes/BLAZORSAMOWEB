using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.DataAccess.Models.FineAgendamientoDian;

[Table("Citas", Schema = "Agendamiento")]
public partial class Citas
{
    [Key]
    public long Id { get; set; }

    public long? IdMallaAgenda { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Nit { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string? RazonSocial { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string? Nombres { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Correo { get; set; }

    [StringLength(11)]
    [Unicode(false)]
    public string? Celular { get; set; }

    public short? IdCanal { get; set; }

    [StringLength(800)]
    [Unicode(false)]
    public string? Observaciones { get; set; }

    public short? IdEstadoCita { get; set; }

    public bool? Activo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaRegistro { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaActualizacion { get; set; }

    [ForeignKey("IdMallaAgenda")]
    [InverseProperty("Citas")]
    public virtual MallaAgenda? IdMallaAgendaNavigation { get; set; }
}
