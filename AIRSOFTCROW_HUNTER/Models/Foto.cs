using System;
using System.Collections.Generic;

namespace AIRSOFTCROW_HUNTER.Models;

public partial class Foto
{
    public int IdFoto { get; set; }

    public int? IdPersona { get; set; }

    public string? Titulo { get; set; }

    public byte[]? Imagen { get; set; }

    public DateOnly? Fecha { get; set; }

    public int? EventoRelacionado { get; set; }

    public virtual Evento? EventoRelacionadoNavigation { get; set; }

    public virtual Persona? IdPersonaNavigation { get; set; }
}
