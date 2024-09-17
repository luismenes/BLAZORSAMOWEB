using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class Procedimiento
{
    public long Id { get; set; }

    public string? Codigo { get; set; }

    public string? Nombre { get; set; }

    public string? NombreAlterno { get; set; }

    public long? GeneroId { get; set; }

    public int? SemanasRequeridad { get; set; }

    public long? EdadId { get; set; }

    public int? EdadInicial { get; set; }

    public int? EdadFinal { get; set; }

    public long? ClaseRangoId { get; set; }

    public long? PosId { get; set; }

    public long? AltoCosto { get; set; }

    public long? ExtramuralId { get; set; }

    public long? ConcentimientoId { get; set; }

    public long? NivelAtencionId { get; set; }

    public long? ComplejidadId { get; set; }

    public long? PaqueteId { get; set; }

    public long? TipoProcedimientoId { get; set; }

    public long? NivelAutorizacionId { get; set; }

    public long? ConceptoId { get; set; }

    public long? FinalidadProdedimientoId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public long? UsuarioCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public long? UsuarioActualiza { get; set; }

    public bool? Activo { get; set; }

    public string? CodigoServicio { get; set; }

    public virtual Dato? AltoCostoNavigation { get; set; }

    public virtual ICollection<AmbitoProcedimiento> AmbitoProcedimientos { get; set; } = new List<AmbitoProcedimiento>();

    public virtual Dato? ClaseRango { get; set; }

    public virtual Dato? Complejidad { get; set; }

    public virtual Dato? Concentimiento { get; set; }

    public virtual Dato? Concepto { get; set; }

    public virtual ICollection<ConvenioControlProcedimiento> ConvenioControlProcedimientos { get; set; } = new List<ConvenioControlProcedimiento>();

    public virtual Dato? Edad { get; set; }

    public virtual ICollection<EspecialidadProcedimiento> EspecialidadProcedimientos { get; set; } = new List<EspecialidadProcedimiento>();

    public virtual Dato? Extramural { get; set; }

    public virtual Dato? FinalidadProdedimiento { get; set; }

    public virtual Dato? Genero { get; set; }

    public virtual Dato? NivelAtencion { get; set; }

    public virtual Dato? NivelAutorizacion { get; set; }

    public virtual Dato? Paquete { get; set; }

    public virtual ICollection<PlanSaludProcedimiento> PlanSaludProcedimientos { get; set; } = new List<PlanSaludProcedimiento>();

    public virtual Dato? Pos { get; set; }

    public virtual ICollection<TarifaVigenciaConfiguracion> TarifaVigenciaConfiguracions { get; set; } = new List<TarifaVigenciaConfiguracion>();

    public virtual Dato? TipoProcedimiento { get; set; }

    public virtual User? UsuarioActualizaNavigation { get; set; }

    public virtual User? UsuarioCreacionNavigation { get; set; }
}
