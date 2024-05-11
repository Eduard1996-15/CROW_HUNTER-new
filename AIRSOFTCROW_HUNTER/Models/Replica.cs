using System;
using System.Collections.Generic;

namespace AIRSOFTCROW_HUNTER.Models;

public partial class Replica
{
    public int IdReplica { get; set; }

    public int? IdProducto { get; set; }

    public string? Tipo { get; set; }

    public int? Fps { get; set; }

    public string? Material { get; set; }

    public decimal? Peso { get; set; }

    public byte[]? Imagen { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
