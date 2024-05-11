using System;
using System.Collections.Generic;

namespace AIRSOFTCROW_HUNTER.Models;

public partial class HistorialMantenimientoReplica
{
    public int IdHistorialMantenimiento { get; set; }

    public int? IdReplica { get; set; }

    public DateTime? FechaMantenimiento { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Costo { get; set; }

    public string? Responsable { get; set; }
}
