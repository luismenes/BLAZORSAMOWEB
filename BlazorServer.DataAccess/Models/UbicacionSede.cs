using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class UbicacionSede
{
    public long Id { get; set; }

    public long SedeId { get; set; }

    public string? Direccion { get; set; }

    public string? Barrio { get; set; }

    public int? ZonaId { get; set; }

    public long? DepartamentoId { get; set; }

    public long? CiudadId { get; set; }

    public string? Correo { get; set; }

    public string? Celular { get; set; }

    public string? Telefono { get; set; }

    public string? Responsable { get; set; }
}
