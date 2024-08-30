using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.DataAccess.Models.FineAgendamientoDian;

[Table("LogSMSCitas", Schema = "Agendamiento")]
public partial class LogSmscitas
{
    [Key]
    public int Id { get; set; }

    public long? IdCita { get; set; }

    [StringLength(11)]
    [Unicode(false)]
    public string? Celular { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string? UrlVideollamada { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string? MensajeConfirmacion { get; set; }

    public bool? EstadoConfirmacion { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string? MensajeRecordatorio { get; set; }

    public bool? EstadoRecordatorio { get; set; }

    [Column("AperturaURL")]
    [StringLength(250)]
    [Unicode(false)]
    public string? AperturaUrl { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaRegistro { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaEnvioConfirmacion { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaEnvioRecordatorio { get; set; }

    [Column("FechaIngresoURL", TypeName = "datetime")]
    public DateTime? FechaIngresoUrl { get; set; }

    [Column("FechaExpiracionURL", TypeName = "datetime")]
    public DateTime? FechaExpiracionUrl { get; set; }
}
