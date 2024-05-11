using System;
using System.Collections.Generic;

namespace AIRSOFTCROW_HUNTER.Models;

public partial class Estadistica
{
    public int IdPersona { get; set; }

    public int? Comunicacion { get; set; }

    public int? Experiencia { get; set; }

    public int? Tecnica { get; set; }

    public int? Disciplina { get; set; }

    public int? Velocidad { get; set; }

    public int? Ataque { get; set; }

    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}
