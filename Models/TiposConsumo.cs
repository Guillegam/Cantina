using System;
using System.Collections.Generic;

namespace Cantina.Models;

public partial class TiposConsumo
{
    public int IdConsumo { get; set; }

    public string NombreConsumo { get; set; } = null!;

    public TimeOnly HorarioInicio { get; set; }

    public TimeOnly HorarioFin { get; set; }

    public int CreditosRequeridos { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
