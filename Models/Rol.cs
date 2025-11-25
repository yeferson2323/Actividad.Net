using System;
using System.Collections.Generic;

namespace RoarMot.Models;

public partial class Rol
{
    public int IdRol { get; set; }

    public string NombreRol { get; set; } = null!;

    public virtual ICollection<Proveedor> Proveedors { get; set; } = new List<Proveedor>();

    public virtual ICollection<RolQueAccione> RolQueAcciones { get; set; } = new List<RolQueAccione>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
