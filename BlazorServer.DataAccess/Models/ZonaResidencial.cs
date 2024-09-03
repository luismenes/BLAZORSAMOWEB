using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class ZonaResidencial
{
    public int Id { get; set; }

    public string ZonaResidencial1 { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public virtual ICollection<ContactoPaciente> ContactoPacientes { get; set; } = new List<ContactoPaciente>();

    public virtual ICollection<Entidad> Entidads { get; set; } = new List<Entidad>();
}
