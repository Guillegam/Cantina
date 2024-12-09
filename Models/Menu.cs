using System;
using System.Collections.Generic;

namespace Cantina.Models;

public partial class Menu
{
    public int IdMenu { get; set; }

    public string TipoConsumo { get; set; } = null!;

    public string NombreComida { get; set; } = null!;

    public string Descripcion { get; set; } = null!;
    public int Credito { get; set; } 
}
