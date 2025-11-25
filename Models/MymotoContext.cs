using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace RoarMot.Models;

public partial class MymotoContext : DbContext
{
    public MymotoContext()
    {
    }

    public MymotoContext(DbContextOptions<MymotoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accione> Acciones { get; set; }

    public virtual DbSet<Alertum> Alerta { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<GestorAlerta> GestorAlertas { get; set; }

    public virtual DbSet<GestorSo> GestorSos { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Moto> Motos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<RolQueAccione> RolQueAcciones { get; set; }

    public virtual DbSet<So> Sos { get; set; }

    public virtual DbSet<Subcategoria> Subcategorias { get; set; }

    public virtual DbSet<Tiendum> Tienda { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    { }

        /*
         #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;database=mymoto", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));
         */

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Accione>(entity =>
        {
            entity.HasKey(e => e.IdAccion).HasName("PRIMARY");

            entity
                .ToTable("acciones")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.IdAccion)
                .HasColumnType("int(11)")
                .HasColumnName("ID_ACCION");
            entity.Property(e => e.NombreAccion)
                .HasMaxLength(45)
                .HasColumnName("NOMBRE_ACCION");
        });

        modelBuilder.Entity<Alertum>(entity =>
        {
            entity.HasKey(e => e.IdAlerta).HasName("PRIMARY");

            entity
                .ToTable("alerta")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.IdAlerta)
                .HasColumnType("int(11)")
                .HasColumnName("ID_ALERTA");
            entity.Property(e => e.MantenimientoGeneral).HasColumnName("MANTENIMIENTO_GENERAL");
            entity.Property(e => e.VencimientoLicenciaConduccion).HasColumnName("VENCIMIENTO_LICENCIA_CONDUCCION");
            entity.Property(e => e.VencimientoSoat).HasColumnName("VENCIMIENTO_SOAT");
            entity.Property(e => e.VencimientoTecnomecanica).HasColumnName("VENCIMIENTO_TECNOMECANICA");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("categorias");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.IdCompra).HasName("PRIMARY");

            entity
                .ToTable("compra")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.IdCompra)
                .HasColumnType("int(11)")
                .HasColumnName("ID_COMPRA");
            entity.Property(e => e.AgregarMasArtiCulos)
                .HasColumnType("enum('SI','NO')")
                .HasColumnName("AGREGAR_MAS_ARTiCULOS");
            entity.Property(e => e.EstadoCompra)
                .HasColumnType("enum('CONFIRMADO','CANCELADO','EN ESPERA','EN CARRITO')")
                .HasColumnName("ESTADO_COMPRA");
            entity.Property(e => e.FacturaProducto)
                .HasColumnType("text")
                .HasColumnName("FACTURA_PRODUCTO");
            entity.Property(e => e.MetodoPago)
                .HasColumnType("enum('NEQUI','TARJETA CREDITO','TARJETA DEBITO')")
                .HasColumnName("METODO_PAGO");
        });

        modelBuilder.Entity<GestorAlerta>(entity =>
        {
            entity.HasKey(e => e.IdGestorAlerta).HasName("PRIMARY");

            entity
                .ToTable("gestor_alertas")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.AlertaIdAlerta, "alerta_ID_ALERTA");

            entity.HasIndex(e => e.MotoIdDatosmoto, "moto_ID_DATOSMOTO");

            entity.Property(e => e.IdGestorAlerta)
                .HasColumnType("int(11)")
                .HasColumnName("ID_GESTOR_ALERTA");
            entity.Property(e => e.AlertaIdAlerta)
                .HasColumnType("int(11)")
                .HasColumnName("alerta_ID_ALERTA");
            entity.Property(e => e.MotoIdDatosmoto)
                .HasColumnType("int(11)")
                .HasColumnName("moto_ID_DATOSMOTO");

            entity.HasOne(d => d.AlertaIdAlertaNavigation).WithMany(p => p.GestorAlerta)
                .HasForeignKey(d => d.AlertaIdAlerta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("gestor_alertas_ibfk_1");

            entity.HasOne(d => d.MotoIdDatosmotoNavigation).WithMany(p => p.GestorAlerta)
                .HasForeignKey(d => d.MotoIdDatosmoto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("gestor_alertas_ibfk_2");
        });

        modelBuilder.Entity<GestorSo>(entity =>
        {
            entity.HasKey(e => e.IdGestorSos).HasName("PRIMARY");

            entity
                .ToTable("gestor_sos")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.SosIdSos, "sos_ID_SOS");

            entity.HasIndex(e => e.UsuarioIdUsuario, "usuario_ID_USUARIO");

            entity.Property(e => e.IdGestorSos)
                .HasColumnType("int(11)")
                .HasColumnName("ID_GESTOR_SOS");
            entity.Property(e => e.SosIdSos)
                .HasColumnType("int(11)")
                .HasColumnName("sos_ID_SOS");
            entity.Property(e => e.UsuarioIdUsuario)
                .HasColumnType("int(11)")
                .HasColumnName("usuario_ID_USUARIO");

            entity.HasOne(d => d.SosIdSosNavigation).WithMany(p => p.GestorSos)
                .HasForeignKey(d => d.SosIdSos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("gestor_sos_ibfk_1");

            entity.HasOne(d => d.UsuarioIdUsuarioNavigation).WithMany(p => p.GestorSos)
                .HasForeignKey(d => d.UsuarioIdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("gestor_sos_ibfk_2");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.IdInventario).HasName("PRIMARY");

            entity
                .ToTable("inventario")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.ProductoIdProducto, "producto_ID_PRODUCTO");

            entity.Property(e => e.IdInventario)
                .HasColumnType("int(11)")
                .HasColumnName("ID_INVENTARIO");
            entity.Property(e => e.Cantidad)
                .HasColumnType("int(11)")
                .HasColumnName("CANTIDAD");
            entity.Property(e => e.LineaMoto)
                .HasColumnType("enum('espejos','protectores','luces','llaveros','llantas','grips','vaules','alforjas','cupulas','no aplica')")
                .HasColumnName("LINEA_MOTO");
            entity.Property(e => e.LineaPersona)
                .HasColumnType("enum('cascos','guantes','chaquetas','pantalones','botas','rodilleras','buff','intercomunicadores','maletas','chalecos','no aplica')")
                .HasColumnName("LINEA_PERSONA");
            entity.Property(e => e.ProductoIdProducto)
                .HasColumnType("int(11)")
                .HasColumnName("producto_ID_PRODUCTO");

            entity.HasOne(d => d.ProductoIdProductoNavigation).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.ProductoIdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inventario_ibfk_1");
        });

        modelBuilder.Entity<Moto>(entity =>
        {
            entity.HasKey(e => e.IdDatosmoto).HasName("PRIMARY");

            entity
                .ToTable("moto")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.UsuarioIdUsuario, "usuario_ID_USUARIO");

            entity.Property(e => e.IdDatosmoto)
                .HasColumnType("int(11)")
                .HasColumnName("ID_DATOSMOTO");
            entity.Property(e => e.ColorMoto)
                .HasMaxLength(30)
                .HasColumnName("COLOR_MOTO");
            entity.Property(e => e.ImagenMoto)
                .HasMaxLength(255)
                .HasColumnName("IMAGEN_MOTO");
            entity.Property(e => e.Kilometraje)
                .HasColumnType("int(11)")
                .HasColumnName("KILOMETRAJE");
            entity.Property(e => e.MarcaMoto)
                .HasMaxLength(25)
                .HasColumnName("MARCA_MOTO");
            entity.Property(e => e.ModeloMoto)
                .HasMaxLength(50)
                .HasColumnName("MODELO_MOTO");
            entity.Property(e => e.PlacaMoto)
                .HasMaxLength(45)
                .HasColumnName("PLACA_MOTO");
            entity.Property(e => e.SoatMoto).HasColumnName("SOAT_MOTO");
            entity.Property(e => e.Tecnomecanica).HasColumnName("TECNOMECANICA");
            entity.Property(e => e.UsuarioIdUsuario)
                .HasColumnType("int(11)")
                .HasColumnName("usuario_ID_USUARIO");

            entity.HasOne(d => d.UsuarioIdUsuarioNavigation).WithMany(p => p.Motos)
                .HasForeignKey(d => d.UsuarioIdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("moto_ibfk_1");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("producto")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.IdSubcategoria, "ID_SUBCATEGORIA");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Cantidad)
                .HasComment("Cantidad en stock")
                .HasColumnType("int(11)")
                .HasColumnName("CANTIDAD");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.IdSubcategoria)
                .HasColumnType("int(11)")
                .HasColumnName("ID_SUBCATEGORIA");
            entity.Property(e => e.IdUsuario)
                .HasComment("Usuario asociado al producto")
                .HasColumnType("int(11)")
                .HasColumnName("ID_USUARIO");
            entity.Property(e => e.Imagen)
                .HasMaxLength(1000)
                .HasColumnName("IMAGEN");
            entity.Property(e => e.Lote)
                .HasMaxLength(15)
                .HasColumnName("LOTE");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .HasColumnName("MARCA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasComment("Precio del producto")
                .HasColumnName("PRECIO");
            entity.Property(e => e.Talla)
                .HasColumnType("enum('S','L','M','XS','XL','NO_APLICA')")
                .HasColumnName("TALLA");

            entity.HasOne(d => d.IdSubcategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdSubcategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("producto_ibfk_1");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PRIMARY");

            entity
                .ToTable("proveedor")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.InventarioIdInventario, "inventario_ID_INVENTARIO");

            entity.HasIndex(e => e.RolIdRol, "rol_ID_ROL");

            entity.Property(e => e.IdProveedor)
                .HasColumnType("int(11)")
                .HasColumnName("ID_PROVEEDOR");
            entity.Property(e => e.ApellidoProveedro)
                .HasMaxLength(45)
                .HasColumnName("APELLIDO_PROVEEDRO");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(100)
                .HasColumnName("CONTRASENA");
            entity.Property(e => e.CorreoProveedor)
                .HasMaxLength(100)
                .HasColumnName("CORREO_PROVEEDOR");
            entity.Property(e => e.EstadoProvedor)
                .HasDefaultValueSql("'Activo'")
                .HasColumnType("enum('Activo','Inactivo')")
                .HasColumnName("ESTADO_PROVEDOR");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.InventarioIdInventario)
                .HasColumnType("int(11)")
                .HasColumnName("inventario_ID_INVENTARIO");
            entity.Property(e => e.NombreProveedor)
                .HasMaxLength(45)
                .HasColumnName("NOMBRE_PROVEEDOR");
            entity.Property(e => e.NumeroDocProveedor)
                .HasMaxLength(45)
                .HasColumnName("NUMERO_DOC_PROVEEDOR");
            entity.Property(e => e.RolIdRol)
                .HasColumnType("int(11)")
                .HasColumnName("rol_ID_ROL");
            entity.Property(e => e.TelProveedor)
                .HasMaxLength(45)
                .HasColumnName("TEL_PROVEEDOR");
            entity.Property(e => e.TipoDocumento)
                .HasColumnType("enum('CC','CE','TI')")
                .HasColumnName("TIPO_DOCUMENTO");

            entity.HasOne(d => d.InventarioIdInventarioNavigation).WithMany(p => p.Proveedors)
                .HasForeignKey(d => d.InventarioIdInventario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("proveedor_ibfk_2");

            entity.HasOne(d => d.RolIdRolNavigation).WithMany(p => p.Proveedors)
                .HasForeignKey(d => d.RolIdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("proveedor_ibfk_1");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PRIMARY");

            entity
                .ToTable("rol")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.IdRol)
                .HasColumnType("int(11)")
                .HasColumnName("ID_ROL");
            entity.Property(e => e.NombreRol)
                .HasColumnType("enum('usuario','proveedor')")
                .HasColumnName("NOMBRE_ROL");
        });

        modelBuilder.Entity<RolQueAccione>(entity =>
        {
            entity.HasKey(e => e.IdRolAccion).HasName("PRIMARY");

            entity
                .ToTable("rol_que_acciones")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.AccionesIdAccion, "acciones_ID_ACCION");

            entity.HasIndex(e => e.RolIdRol, "rol_ID_ROL");

            entity.Property(e => e.IdRolAccion)
                .HasColumnType("int(11)")
                .HasColumnName("ID_ROL_ACCION");
            entity.Property(e => e.AccionesIdAccion)
                .HasColumnType("int(11)")
                .HasColumnName("acciones_ID_ACCION");
            entity.Property(e => e.RolIdRol)
                .HasColumnType("int(11)")
                .HasColumnName("rol_ID_ROL");

            entity.HasOne(d => d.AccionesIdAccionNavigation).WithMany(p => p.RolQueAcciones)
                .HasForeignKey(d => d.AccionesIdAccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rol_que_acciones_ibfk_2");

            entity.HasOne(d => d.RolIdRolNavigation).WithMany(p => p.RolQueAcciones)
                .HasForeignKey(d => d.RolIdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rol_que_acciones_ibfk_1");
        });

        modelBuilder.Entity<So>(entity =>
        {
            entity.HasKey(e => e.IdSos).HasName("PRIMARY");

            entity
                .ToTable("sos")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.IdSos)
                .HasColumnType("int(11)")
                .HasColumnName("ID_SOS");
            entity.Property(e => e.LlamadaEmergencia)
                .HasColumnType("enum('POLICIA','BOMBEROS','AMBULANCIA','NO APLICA')")
                .HasColumnName("LLAMADA_EMERGENCIA");
            entity.Property(e => e.MensajeEmergencia)
                .HasColumnType("enum('PAPA','HERMANO','AMIGO','NO APLICA')")
                .HasColumnName("MENSAJE_EMERGENCIA");
        });

        modelBuilder.Entity<Subcategoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("subcategorias");

            entity.HasIndex(e => e.IdCategoria, "ID_CATEGORIA");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.IdCategoria)
                .HasColumnType("int(11)")
                .HasColumnName("ID_CATEGORIA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Subcategoria)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("subcategorias_ibfk_1");
        });

        modelBuilder.Entity<Tiendum>(entity =>
        {
            entity.HasKey(e => e.IdTienda).HasName("PRIMARY");

            entity
                .ToTable("tienda")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.ProductoIdProducto, "producto_ID_PRODUCTO");

            entity.HasIndex(e => e.UsuarioIdUsuario, "usuario_ID_USUARIO");

            entity.Property(e => e.IdTienda)
                .HasColumnType("int(11)")
                .HasColumnName("ID_TIENDA");
            entity.Property(e => e.AgregadoCarrito)
                .HasColumnType("enum('si','no')")
                .HasColumnName("AGREGADO_CARRITO");
            entity.Property(e => e.ProductoIdProducto)
                .HasColumnType("int(11)")
                .HasColumnName("producto_ID_PRODUCTO");
            entity.Property(e => e.SeccionesArticulos)
                .HasColumnType("enum('PARA PERSONA','PARA MOTO')")
                .HasColumnName("SECCIONES_ARTICULOS");
            entity.Property(e => e.UsuarioIdUsuario)
                .HasColumnType("int(11)")
                .HasColumnName("usuario_ID_USUARIO");

            entity.HasOne(d => d.ProductoIdProductoNavigation).WithMany(p => p.Tienda)
                .HasForeignKey(d => d.ProductoIdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tienda_ibfk_1");

            entity.HasOne(d => d.UsuarioIdUsuarioNavigation).WithMany(p => p.Tienda)
                .HasForeignKey(d => d.UsuarioIdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tienda_ibfk_2");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity
                .ToTable("usuario")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.RolIdRol, "rol_ID_ROL");

            entity.Property(e => e.IdUsuario)
                .HasColumnType("int(11)")
                .HasColumnName("ID_USUARIO");
            entity.Property(e => e.ApellidoUsuario)
                .HasMaxLength(255)
                .HasColumnName("APELLIDO_USUARIO");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(255)
                .HasColumnName("CONTRASENA");
            entity.Property(e => e.CorreoUsuario)
                .HasMaxLength(255)
                .HasColumnName("CORREO_USUARIO");
            entity.Property(e => e.EstadoUsuario)
                .HasMaxLength(255)
                .HasColumnName("ESTADO_USUARIO");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.NombreEmpresa)
                .HasMaxLength(255)
                .HasColumnName("NOMBRE_EMPRESA");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(255)
                .HasColumnName("NOMBRE_USUARIO");
            entity.Property(e => e.NumeroUsuario)
                .HasMaxLength(255)
                .HasColumnName("NUMERO_USUARIO");
            entity.Property(e => e.RolIdRol)
                .HasColumnType("int(11)")
                .HasColumnName("ROL_ID_ROL");
            entity.Property(e => e.TelUsuario)
                .HasMaxLength(255)
                .HasColumnName("TEL_USUARIO");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(255)
                .HasColumnName("TIPO_DOCUMENTO");
            entity.Property(e => e.UrlImagenMoto)
                .HasMaxLength(255)
                .HasColumnName("URL_IMAGEN_MOTO");
            entity.Property(e => e.UrlImagenPerfil)
                .HasMaxLength(255)
                .HasColumnName("URL_IMAGEN_PERFIL");

            entity.HasOne(d => d.RolIdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolIdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuario_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
