using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class Ip
{
    public long Id { get; set; }

    public long SedeId { get; set; }

    public string CodigoIps { get; set; } = null!;

    public long SolicitudHabilitacion { get; set; }

    public long TipoIdentificacion { get; set; }

    public string NumeroIdentificacion { get; set; } = null!;

    public string DigitoVerificacion { get; set; } = null!;

    public string? Sigla { get; set; }

    public string RazonSocial { get; set; } = null!;

    public DateTime? FechaCreacionIps { get; set; }

    public bool IdAnimoLucro { get; set; }

    public string Slogan { get; set; } = null!;

    public long? IdResponsable { get; set; }

    public long? IdNaturaleza { get; set; }

    public string? RepresentanteLegal { get; set; }

    public long? IdTipoDocRepresentante { get; set; }

    public string? NumeroDocumentoRepresentante { get; set; }

    public string? DigitoVerifiRepresentante { get; set; }

    public long? NumeroSucursales { get; set; }

    public long? NumeroSedes { get; set; }

    public long? IdClaseEntidad { get; set; }

    public string? CodigoUnion { get; set; }

    public string? ObjetoSocial { get; set; }

    public long? IdTipoEmpresa { get; set; }

    public long? IdActoAdministrativo { get; set; }

    public string? NumeroActoAdmin { get; set; }

    public DateTime? FechaActoAdmin { get; set; }

    public long? IdEstadoSociedad { get; set; }

    public DateTime? VencimientoConstitucion { get; set; }

    public long? IdActividadEconomica { get; set; }

    public long? IdTipoResolucion { get; set; }

    public bool? IvaDeducible { get; set; }

    public long? IdRegimenIva { get; set; }

    public long? IdTipoContribuyente { get; set; }

    public long? IdGrupoNiif { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? UltimaModificacion { get; set; }

    public long UsuarioCreacion { get; set; }

    public long? UsuarioModificacion { get; set; }

    public virtual Dato? IdActividadEconomicaNavigation { get; set; }

    public virtual Dato? IdActoAdministrativoNavigation { get; set; }

    public virtual Dato? IdClaseEntidadNavigation { get; set; }

    public virtual Dato? IdEstadoSociedadNavigation { get; set; }

    public virtual Dato? IdGrupoNiifNavigation { get; set; }

    public virtual Dato? IdNaturalezaNavigation { get; set; }

    public virtual Entidad? IdResponsableNavigation { get; set; }

    public virtual Dato? IdTipoContribuyenteNavigation { get; set; }

    public virtual Dato? IdTipoDocRepresentanteNavigation { get; set; }

    public virtual Dato? IdTipoEmpresaNavigation { get; set; }

    public virtual Dato? IdTipoResolucionNavigation { get; set; }

    public virtual ICollection<ResolucionAutoretenedor> ResolucionAutoretenedors { get; set; } = new List<ResolucionAutoretenedor>();

    public virtual Sede Sede { get; set; } = null!;

    public virtual Dato TipoIdentificacionNavigation { get; set; } = null!;

    public virtual User UsuarioCreacionNavigation { get; set; } = null!;

    public virtual User? UsuarioModificacionNavigation { get; set; }
}
