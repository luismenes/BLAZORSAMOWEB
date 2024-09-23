using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class Convenio
{
    public long Id { get; set; }

    public string? Codigo { get; set; }

    public string? Nombre { get; set; }

    public long? ClaseId { get; set; }

    public long? EntidadId { get; set; }

    public string? CodigoRips { get; set; }

    public string? CodigoEapb { get; set; }

    public long? TipoConvenioId { get; set; }

    public long? OrigenConvenioId { get; set; }

    public long? TipoUserRegimen { get; set; }

    public string? PoblacionAtiende { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public DateTime? FechaPrestaInicio { get; set; }

    public DateTime? FechaPrestaFin { get; set; }

    public bool? EsTodaSede { get; set; }

    public bool? Activo { get; set; }

    public bool? EsConBeneficiarios { get; set; }

    public bool? EsJustNoPos { get; set; }

    public long? UsuarioId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public long? UsuarioActualizaId { get; set; }

    public long? OperacionId { get; set; }

    public virtual Dato? Clase { get; set; }

    public virtual ICollection<ConvenioControlProcedimiento> ConvenioControlProcedimientos { get; set; } = new List<ConvenioControlProcedimiento>();

    public virtual ICollection<ConvenioSede> ConvenioSedes { get; set; } = new List<ConvenioSede>();

    public virtual Entidad? Entidad { get; set; }

    public virtual Operacion? Operacion { get; set; }

    public virtual Dato? OrigenConvenio { get; set; }

    public virtual Dato? TipoConvenio { get; set; }

    public virtual Dato? TipoUserRegimenNavigation { get; set; }

    public virtual User? Usuario { get; set; }

    public virtual User? UsuarioActualiza { get; set; }
}
