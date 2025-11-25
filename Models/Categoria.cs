using System;
using System.Collections.Generic;

namespace RoarMot.Models;

public partial class Categoria
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Subcategoria> Subcategoria { get; set; } = new List<Subcategoria>();
}
