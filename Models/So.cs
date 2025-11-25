using System;
using System.Collections.Generic;

namespace RoarMot.Models;

public partial class So
{
    public int IdSos { get; set; }

    public string LlamadaEmergencia { get; set; } = null!;

    public string MensajeEmergencia { get; set; } = null!;

    public virtual ICollection<GestorSo> GestorSos { get; set; } = new List<GestorSo>();
}
