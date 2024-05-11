using System;
using System.Collections.Generic;

namespace AIRSOFTCROW_HUNTER.Models;

public partial class Bb
{
    public int IdBb { get; set; }

    public int? IdProducto { get; set; }

    public int? Calibre { get; set; }

    public string? Material { get; set; }

    public int? Cantidad { get; set; }

    public byte[]? Imagen { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
