using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.DataAccess.Models.FineAgendamientoDian;

[Table("Parametros", Schema = "Configuracion")]
public partial class Parametros
{
    [Key]
    public long Id { get; set; }

    public int Campanaid { get; set; }

    public long ParametroId { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string Valor { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime FechaCreacion { get; set; }

    public bool Activo { get; set; }

    [ForeignKey("ParametroId")]
    [InverseProperty("Parametros")]
    public virtual Dato Parametro { get; set; } = null!;
}
