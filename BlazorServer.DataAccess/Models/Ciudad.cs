using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class Ciudad
{
    public long Id { get; set; }

    public long IdDepartamento { get; set; }

    public string? Codigo { get; set; }

    public string? Nombre { get; set; }

    public string? CodigoArea { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<ContactoPaciente> ContactoPacientes { get; set; } = new List<ContactoPaciente>();

    public virtual ICollection<Entidad> Entidads { get; set; } = new List<Entidad>();

    public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;
}
