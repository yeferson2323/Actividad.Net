using System;
using System.Collections.Generic;

namespace RoarMot.Models;

public partial class GestorSo
{
    public int IdGestorSos { get; set; }

    public int UsuarioIdUsuario { get; set; }

    public int SosIdSos { get; set; }

    public virtual So SosIdSosNavigation { get; set; } = null!;

    public virtual Usuario UsuarioIdUsuarioNavigation { get; set; } = null!;
}
