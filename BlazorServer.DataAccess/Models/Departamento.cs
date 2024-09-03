using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class Departamento
{
    public long Id { get; set; }

    public long IdPais { get; set; }

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? CodigoArea { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<Ciudad> Ciudads { get; set; } = new List<Ciudad>();

    public virtual ICollection<ContactoPaciente> ContactoPacientes { get; set; } = new List<ContactoPaciente>();

    public virtual ICollection<Entidad> Entidads { get; set; } = new List<Entidad>();

    public virtual Pai IdPaisNavigation { get; set; } = null!;
}
