using System;
using System.Collections.Generic;

namespace RoarMot.Models;

public partial class Compra
{
    public int IdCompra { get; set; }

    public string MetodoPago { get; set; } = null!;

    public string AgregarMasArtiCulos { get; set; } = null!;

    public string EstadoCompra { get; set; } = null!;

    public string FacturaProducto { get; set; } = null!;
}
