using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.DataAccess.Models.FineAgendamientoDian;

[Table("Dato", Schema = "Configuracion")]
public partial class Dato
{
    [Key]
    public long Id { get; set; }

    public long TablaId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaCreacion { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Codigo { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    public long? Valor { get; set; }

    public bool Activo { get; set; }

    public long? PadreId { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Equivalente { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Herencia { get; set; }

    [InverseProperty("Parametro")]
    public virtual ICollection<Parametros> Parametros { get; set; } = new List<Parametros>();
}
