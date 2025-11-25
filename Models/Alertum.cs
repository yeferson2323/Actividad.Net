using System;
using System.Collections.Generic;

namespace RoarMot.Models;

public partial class Alertum
{
    public int IdAlerta { get; set; }

    public DateOnly VencimientoSoat { get; set; }

    public DateOnly VencimientoTecnomecanica { get; set; }

    public DateOnly VencimientoLicenciaConduccion { get; set; }

    public DateOnly MantenimientoGeneral { get; set; }

    public virtual ICollection<GestorAlerta> GestorAlerta { get; set; } = new List<GestorAlerta>();
}
