using System;
using System.Collections.Generic;

namespace RoarMot.Models;

public partial class Moto
{
    public int IdDatosmoto { get; set; }

    public string MarcaMoto { get; set; } = null!;

    public string ModeloMoto { get; set; } = null!;

    public string ColorMoto { get; set; } = null!;

    public string? ImagenMoto { get; set; }

    public DateOnly SoatMoto { get; set; }

    public DateOnly Tecnomecanica { get; set; }

    public string PlacaMoto { get; set; } = null!;

    public int Kilometraje { get; set; }

    public int UsuarioIdUsuario { get; set; }

    public virtual ICollection<GestorAlerta> GestorAlerta { get; set; } = new List<GestorAlerta>();

    public virtual Usuario UsuarioIdUsuarioNavigation { get; set; } = null!;
}
