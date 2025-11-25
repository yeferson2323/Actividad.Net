using System;
using System.Collections.Generic;

namespace RoarMot.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public string Imagen { get; set; } = null!;

    public string Talla { get; set; } = null!;

    public string Lote { get; set; } = null!;

    /// <summary>
    /// Cantidad en stock
    /// </summary>
    public int Cantidad { get; set; }

    /// <summary>
    /// Precio del producto
    /// </summary>
    public decimal Precio { get; set; }

    public int IdSubcategoria { get; set; }

    /// <summary>
    /// Usuario asociado al producto
    /// </summary>
    public int IdUsuario { get; set; }

    public virtual Subcategoria IdSubcategoriaNavigation { get; set; } = null!;

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual ICollection<Tiendum> Tienda { get; set; } = new List<Tiendum>();
}
