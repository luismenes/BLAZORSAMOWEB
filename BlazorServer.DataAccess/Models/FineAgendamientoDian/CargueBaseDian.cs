using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.DataAccess.Models.FineAgendamientoDian;

[Table("CargueBaseDian", Schema = "Proceso")]
[Index("Id", Name = "_dta_index_CargueBaseDian")]
public partial class CargueBaseDian
{
    [Key]
    public long Id { get; set; }

    public long? TransaccionId { get; set; }

    public bool? EstadoObligacion { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Nit { get; set; }

    [Column("Codigo_Seguridad")]
    [StringLength(100)]
    [Unicode(false)]
    public string? CodigoSeguridad { get; set; }

    [Column("Nombre_RazonSocial")]
    [StringLength(350)]
    [Unicode(false)]
    public string? NombreRazonSocial { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Ciudad { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Admi { get; set; }

    [Column("Tipo_Contribuyente")]
    [StringLength(100)]
    [Unicode(false)]
    public string? TipoContribuyente { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Concepto { get; set; }

    [Column("Ano_Gravable")]
    [StringLength(100)]
    [Unicode(false)]
    public string? AnoGravable { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Periodo { get; set; }

    [Column("No_Obligacion")]
    [StringLength(100)]
    [Unicode(false)]
    public string? NoObligacion { get; set; }

    [Column("Valor_Impuesto")]
    [StringLength(100)]
    [Unicode(false)]
    public string? ValorImpuesto { get; set; }

    [Column("Valor_Sancion")]
    [StringLength(100)]
    [Unicode(false)]
    public string? ValorSancion { get; set; }

    [Column("Fecha_Exigibilidad", TypeName = "datetime")]
    public DateTime? FechaExigibilidad { get; set; }

    [Column("Fecha_Maxima_Gestion", TypeName = "datetime")]
    public DateTime? FechaMaximaGestion { get; set; }

    [Column("Telefono_0")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Telefono0 { get; set; }

    [Column("Telefono_1")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Telefono1 { get; set; }

    [Column("Num_Doc_Representante_Legal")]
    [StringLength(100)]
    [Unicode(false)]
    public string? NumDocRepresentanteLegal { get; set; }

    [Column("Nombre_Representante_Legal")]
    [StringLength(100)]
    [Unicode(false)]
    public string? NombreRepresentanteLegal { get; set; }

    [Column("Ciudad_Representante_Legal")]
    [StringLength(100)]
    [Unicode(false)]
    public string? CiudadRepresentanteLegal { get; set; }

    [Column("Telefono_2")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Telefono2 { get; set; }

    [Column("Telefono_3")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Telefono3 { get; set; }

    [Column("Num_Doc_Suplente_Uno")]
    [StringLength(100)]
    [Unicode(false)]
    public string? NumDocSuplenteUno { get; set; }

    [Column("Nombre_Suplente_Uno")]
    [StringLength(100)]
    [Unicode(false)]
    public string? NombreSuplenteUno { get; set; }

    [Column("Ciudad_Suplente_Uno")]
    [StringLength(100)]
    [Unicode(false)]
    public string? CiudadSuplenteUno { get; set; }

    [Column("Telefono_4")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Telefono4 { get; set; }

    [Column("Telefono_5")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Telefono5 { get; set; }

    [Column("Num_Doc_Suplente_Dos")]
    [StringLength(100)]
    [Unicode(false)]
    public string? NumDocSuplenteDos { get; set; }

    [Column("Nombre_Suplente_Dos")]
    [StringLength(100)]
    [Unicode(false)]
    public string? NombreSuplenteDos { get; set; }

    [Column("Ciudad_Suplente_Dos")]
    [StringLength(100)]
    [Unicode(false)]
    public string? CiudadSuplenteDos { get; set; }

    [Column("Telefono_6")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Telefono6 { get; set; }

    [Column("Telefono_7")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Telefono7 { get; set; }

    [Column("ASESOR")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Asesor { get; set; }

    [Column("CICLO")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Ciclo { get; set; }

    [Column("FOCO")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Foco { get; set; }

    [Column("BRIGADA")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Brigada { get; set; }

    [Column("TAREA")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Tarea { get; set; }

    [Column("EXTRA1")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Extra1 { get; set; }

    [Column("EXTRA2")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Extra2 { get; set; }

    [Column("EXTRA3")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Extra3 { get; set; }

    public long IdUsuario { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaCargue { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaActualizacion { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaCierreObligacion { get; set; }
}
