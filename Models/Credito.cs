using System;
using System.Collections.Generic;

namespace Cantina.Models;

public partial class Credito
{
    public int IdCredito { get; set; }

    public int IdEmpleado { get; set; }

    public int CreditosAsignados { get; set; }

    public int CreditosConsumidos { get; set; }

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
}
