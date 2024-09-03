using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class Especialidad
{
    public long Id { get; set; }

    public string? Codigo { get; set; }

    public string? Nombre { get; set; }

    public bool? Urgencia { get; set; }

    public bool? EsAutorizado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public long? UsuarioCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public long? UsuarioActualiza { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<EspecialidadProcedimiento> EspecialidadProcedimientos { get; set; } = new List<EspecialidadProcedimiento>();

    public virtual ICollection<ProfesionalEspecialidad> ProfesionalEspecialidads { get; set; } = new List<ProfesionalEspecialidad>();

    public virtual User? UsuarioActualizaNavigation { get; set; }

    public virtual User? UsuarioCreacionNavigation { get; set; }
}
