using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class ContactoPaciente
{
    public long Id { get; set; }

    public long PacienteId { get; set; }

    public string? Direccion { get; set; }

    public string? Barrio { get; set; }

    public int? ZonaId { get; set; }

    public long? DepartamentoId { get; set; }

    public long? CiudadId { get; set; }

    public string? Correo { get; set; }

    public string? Celular { get; set; }

    public string? Telefono { get; set; }

    public virtual Ciudad? Ciudad { get; set; }

    public virtual Departamento? Departamento { get; set; }

    public virtual Paciente Paciente { get; set; } = null!;

    public virtual ZonaResidencial? Zona { get; set; }
}
