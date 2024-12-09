using System;
using System.Collections.Generic;

namespace Cantina.Models;

public partial class Turno
{
    public int IdTurno { get; set; }

    public string NombreTurno { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
