using System;
using System.Collections.Generic;

namespace RoarMot.Models;

public partial class Proveedor
{
    public int IdProveedor { get; set; }

    public string TipoDocumento { get; set; } = null!;

    public string NumeroDocProveedor { get; set; } = null!;

    public string NombreProveedor { get; set; } = null!;

    public string ApellidoProveedro { get; set; } = null!;

    public string TelProveedor { get; set; } = null!;

    public string CorreoProveedor { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string EstadoProvedor { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public int RolIdRol { get; set; }

    public int InventarioIdInventario { get; set; }

    public virtual Inventario InventarioIdInventarioNavigation { get; set; } = null!;

    public virtual Rol RolIdRolNavigation { get; set; } = null!;
}
