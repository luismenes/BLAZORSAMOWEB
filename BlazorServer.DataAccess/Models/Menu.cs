using System;
using System.Collections.Generic;

namespace BlazorServer.DataAccess.Models;

public partial class Menu
{
    public long Id { get; set; }

    public long? PadreId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public short Orden { get; set; }

    public string? Url { get; set; }

    public string? UrlImagen { get; set; }

    public bool? Estado { get; set; }

    public string? Adicional { get; set; }

    public bool? Desplegable { get; set; }

    public string? UrlAdsoluta { get; set; }

    public string? UrlBlazor { get; set; }

    public virtual ICollection<Acceso> Accesos { get; set; } = new List<Acceso>();
}
