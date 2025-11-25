using System;
using System.Collections.Generic;

namespace RoarMot.Models;

public partial class Inventario
{
    public int IdInventario { get; set; }

    public string LineaMoto { get; set; } = null!;

    public string LineaPersona { get; set; } = null!;

    public int ProductoIdProducto { get; set; }

    public int Cantidad { get; set; }

    public virtual Producto ProductoIdProductoNavigation { get; set; } = null!;

    public virtual ICollection<Proveedor> Proveedors { get; set; } = new List<Proveedor>();
}
