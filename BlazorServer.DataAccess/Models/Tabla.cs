using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class Tabla
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime? FechaRegistro { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Dato> Datos { get; set; } = new List<Dato>();
}
