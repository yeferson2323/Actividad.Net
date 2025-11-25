using System;
using System.Collections.Generic;

namespace RoarMot.Models;

public partial class RolQueAccione
{
    public int IdRolAccion { get; set; }

    public int RolIdRol { get; set; }

    public int AccionesIdAccion { get; set; }

    public virtual Accione AccionesIdAccionNavigation { get; set; } = null!;

    public virtual Rol RolIdRolNavigation { get; set; } = null!;
}
