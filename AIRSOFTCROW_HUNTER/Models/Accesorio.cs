using System;
using System.Collections.Generic;

namespace AIRSOFTCROW_HUNTER.Models;

public partial class Accesorio
{
    public int IdAccesorio { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public int? Stock { get; set; }

    public string? Categoria { get; set; }
}
