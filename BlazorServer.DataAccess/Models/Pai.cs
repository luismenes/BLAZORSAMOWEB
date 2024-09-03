using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class Pai
{
    public long Id { get; set; }

    public string Pais { get; set; } = null!;

    public string? Codigo { get; set; }

    public int? CodigoArea { get; set; }

    public string? Gtm { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
}
