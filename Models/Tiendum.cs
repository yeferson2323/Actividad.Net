using System;
using System.Collections.Generic;

namespace RoarMot.Models;

public partial class Tiendum
{
    public int IdTienda { get; set; }

    public int UsuarioIdUsuario { get; set; }

    public string SeccionesArticulos { get; set; } = null!;

    public int ProductoIdProducto { get; set; }

    public string AgregadoCarrito { get; set; } = null!;

    public virtual Producto ProductoIdProductoNavigation { get; set; } = null!;

    public virtual Usuario UsuarioIdUsuarioNavigation { get; set; } = null!;
}
