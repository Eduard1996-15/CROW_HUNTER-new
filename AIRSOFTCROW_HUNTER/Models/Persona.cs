using System;
using System.Collections.Generic;

namespace AIRSOFTCROW_HUNTER.Models;

public partial class Persona
{
    

    public int IdPersona { get; set; }

    public string Nombre { get; set; } = null!;

    public string Alias { get; set; } = null!;

    public string? Rol { get; set; }

    public DateOnly? FechaIngreso { get; set; }

    public string? Email { get; set; }

    public string? Biografía { get; set; }

    public byte[]? CancionMp3 { get; set; }

    public virtual ICollection<Foto> Fotos { get; set; } = new List<Foto>();
}
