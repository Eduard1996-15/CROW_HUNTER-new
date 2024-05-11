using System;
using System.Collections.Generic;

namespace AIRSOFTCROW_HUNTER.Models;

public partial class MantenimientoReplica
{
    public int IdMantenimiento { get; set; }

    public int? IdReplica { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Costo { get; set; }
}
