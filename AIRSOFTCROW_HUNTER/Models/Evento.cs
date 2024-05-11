using System;
using System.Collections.Generic;

namespace AIRSOFTCROW_HUNTER.Models;

public partial class Evento
{
    public int IdEvento { get; set; }

    public string? NombreEvento { get; set; }

    public string? Descripcion { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public string? Ubicacion { get; set; }

    public virtual ICollection<Foto> Fotos { get; set; } = new List<Foto>();
}
