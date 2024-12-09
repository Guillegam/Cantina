using System;
using System.Collections.Generic;

namespace Cantina.Models;

public partial class Reserva
{
    public int IdReserva { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public string NombreEmpleado { get; set; } = null!;

    public string TipoConsumo { get; set; } = null!;

    public string ComidaSeleccionada { get; set; } = null!;

    public virtual TiposConsumo TipoConsumoNavigation { get; set; } = null!;
}
