using System;
using System.Collections.Generic;

namespace RoarMot.Models;

public partial class Subcategoria
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdCategoria { get; set; }

    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
