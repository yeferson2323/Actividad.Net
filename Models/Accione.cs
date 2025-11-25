using System;
using System.Collections.Generic;

namespace RoarMot.Models;

public partial class Accione
{
    public int IdAccion { get; set; }

    public string NombreAccion { get; set; } = null!;

    public virtual ICollection<RolQueAccione> RolQueAcciones { get; set; } = new List<RolQueAccione>();
}
