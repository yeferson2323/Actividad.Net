using System;
using System.Collections.Generic;

namespace RoarMot.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? TipoDocumento { get; set; }

    public string? NumeroUsuario { get; set; }

    public string? NombreUsuario { get; set; }

    public string? ApellidoUsuario { get; set; }

    public string? TelUsuario { get; set; }

    public string CorreoUsuario { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string EstadoUsuario { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? NombreEmpresa { get; set; }

    public int RolIdRol { get; set; }

    public string? UrlImagenPerfil { get; set; }

    public string? UrlImagenMoto { get; set; }

    public virtual ICollection<GestorSo> GestorSos { get; set; } = new List<GestorSo>();

    public virtual ICollection<Moto> Motos { get; set; } = new List<Moto>();

    public virtual Rol RolIdRolNavigation { get; set; } = null!;

    public virtual ICollection<Tiendum> Tienda { get; set; } = new List<Tiendum>();
}
