using System;
using System.Collections.Generic;

namespace RoarMot.Models;

public partial class GestorAlerta
{
    public int IdGestorAlerta { get; set; }

    public int AlertaIdAlerta { get; set; }

    public int MotoIdDatosmoto { get; set; }

    public virtual Alertum AlertaIdAlertaNavigation { get; set; } = null!;

    public virtual Moto MotoIdDatosmotoNavigation { get; set; } = null!;
}
