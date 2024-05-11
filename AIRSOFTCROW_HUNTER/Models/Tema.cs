using System;
using System.Collections.Generic;

namespace AIRSOFTCROW_HUNTER.Models;

public partial class Tema
{
    public int IdTema { get; set; }

    public string? Titulo { get; set; }

    public string? Autor { get; set; }

    public DateTime? FechaCreacion { get; set; }
}
