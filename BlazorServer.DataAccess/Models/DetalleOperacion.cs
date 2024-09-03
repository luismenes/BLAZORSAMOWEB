using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class DetalleOperacion
{
    public long Id { get; set; }

    public long? OperacionId { get; set; }

    public long IdTipoIdentificacion { get; set; }

    public string Identificacion { get; set; } = null!;

    public string? DigitoVerificacion { get; set; }

    public string? RazonSocial { get; set; }

    public string? RepresentanteLegal { get; set; }

    public string? Responsable { get; set; }

    public long AmbitoId { get; set; }

    public long CentralizadoId { get; set; }

    public long TipoPlanId { get; set; }

    public int? Acciones { get; set; }

    public string? RentaMensual { get; set; }

    public string? RentaAnual { get; set; }

    public long RegimenId { get; set; }

    public long TipoContribuyenteId { get; set; }

    public long CostoNiffId { get; set; }

    public string? NumRut { get; set; }

    public string? Resolucion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public long UsuarioId { get; set; }

    public string? IpMaquina { get; set; }

    public string? NombreMaquina { get; set; }

    public bool? Activo { get; set; }

    public long TipoPersonaId { get; set; }

    public long? EntidadId { get; set; }

    public virtual Dato Ambito { get; set; } = null!;

    public virtual Dato Centralizado { get; set; } = null!;

    public virtual Dato CostoNiff { get; set; } = null!;

    public virtual Entidad? Entidad { get; set; }

    public virtual Dato IdTipoIdentificacionNavigation { get; set; } = null!;

    public virtual Operacion? Operacion { get; set; }

    public virtual Dato Regimen { get; set; } = null!;

    public virtual Dato TipoContribuyente { get; set; } = null!;

    public virtual Dato TipoPersona { get; set; } = null!;

    public virtual Dato TipoPlan { get; set; } = null!;

    public virtual User Usuario { get; set; } = null!;
}
