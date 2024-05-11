using System;
using System.Collections.Generic;

namespace AIRSOFTCROW_HUNTER.Models;

public partial class Publicacion
{
    public int IdPublicacion { get; set; }

    public string? Contenido { get; set; }

    public int? IdTema { get; set; }

    public string? Autor { get; set; }

    public DateTime? FechaPublicacion { get; set; }
}
