using System;
using System.Collections.Generic;

namespace Cantina.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Puesto { get; set; } = null!;

    public int IdTurno { get; set; }

    public virtual ICollection<Credito> Creditos { get; set; } = new List<Credito>();

    public virtual Turno IdTurnoNavigation { get; set; } = null!;
}
