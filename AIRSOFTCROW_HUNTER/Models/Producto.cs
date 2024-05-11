using System;
using System.Collections.Generic;

namespace AIRSOFTCROW_HUNTER.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public int? Stock { get; set; }

    public string? Categoria { get; set; }

    public virtual ICollection<Bb> Bbs { get; set; } = new List<Bb>();

    public virtual ICollection<Replica> Replicas { get; set; } = new List<Replica>();
}
