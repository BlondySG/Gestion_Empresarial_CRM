using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities;

public partial class GeCrmContext : DbContext
{
    public GeCrmContext()
    {
    }

    public GeCrmContext(DbContextOptions<GeCrmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbBitacora> TbBitacoras { get; set; }

    public virtual DbSet<TbCliente> TbClientes { get; set; }

    public virtual DbSet<TbCompra> TbCompras { get; set; }

    public virtual DbSet<TbDetalleCompra> TbDetalleCompras { get; set; }

    public virtual DbSet<TbDetalleVenta> TbDetalleVentas { get; set; }

    public virtual DbSet<TbEmpleado> TbEmpleados { get; set; }

    public virtual DbSet<TbEmpleadoSoporte> TbEmpleadoSoportes { get; set; }

    public virtual DbSet<TbProducto> TbProductos { get; set; }

    public virtual DbSet<TbProveedor> TbProveedors { get; set; }

    public virtual DbSet<TbRol> TbRols { get; set; }

    public virtual DbSet<TbSoporte> TbSoportes { get; set; }

    public virtual DbSet<TbSoporteCliente> TbSoporteClientes { get; set; }

    public virtual DbSet<TbTipoSoporte> TbTipoSoportes { get; set; }

    public virtual DbSet<TbVenta> TbVentas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=GE_CRM;Integrated Security=True;Trusted_Connection=True ;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbBitacora>(entity =>
        {
            entity.HasKey(e => e.IdBitacora).HasName("PK_IdBitacora");

            entity.ToTable("tbBitacora");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(2500)
                .IsUnicode(false);
            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.Origen)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.TbBitacoras)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empleado");
        });

        modelBuilder.Entity<TbCliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK_IdCliente");

            entity.ToTable("tbCliente");

            entity.Property(e => e.CorreoCliente)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.DireccionCliente)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.PersonaContacto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TelefonoCliente)
                .HasMaxLength(12)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbCompra>(entity =>
        {
            entity.HasKey(e => e.IdCompra);

            entity.ToTable("tbCompras");

            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaCompra).HasColumnType("datetime");
            entity.Property(e => e.IdProveedorC).HasColumnName("IdProveedor_c");
            entity.Property(e => e.MontoTotal).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.IdProveedorCNavigation).WithMany(p => p.TbCompras)
                .HasForeignKey(d => d.IdProveedorC)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Compra_Proveedor");
        });

        modelBuilder.Entity<TbDetalleCompra>(entity =>
        {
            entity.HasKey(e => e.IdDetalleCompra).HasName("PK_IdDetalleCompra");

            entity.ToTable("tbDetalleCompras");

            entity.Property(e => e.IdCompraP).HasColumnName("IdCompra_p");
            entity.Property(e => e.IdProductoP).HasColumnName("IdProducto_p");
            entity.Property(e => e.ImpuestoCompra).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.NumFacturaCompra)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SubTotalCompra).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TotalCompra).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdCompraPNavigation).WithMany(p => p.TbDetalleCompras)
                .HasForeignKey(d => d.IdCompraP)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleCompras_Compras");

            entity.HasOne(d => d.IdProductoPNavigation).WithMany(p => p.TbDetalleCompras)
                .HasForeignKey(d => d.IdProductoP)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleCompras_Producto");
        });

        modelBuilder.Entity<TbDetalleVenta>(entity =>
        {
            entity.HasKey(e => e.IdDetalleVenta).HasName("PK_IdDetalleVenta");

            entity.ToTable("tbDetalleVentas");

            entity.Property(e => e.IdProductoC).HasColumnName("IdProducto_c");
            entity.Property(e => e.IdVentaC).HasColumnName("IdVenta_c");
            entity.Property(e => e.ImpuestoVenta).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.NumFacturaVenta)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SubTotalVenta).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TotalVenta).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdProductoCNavigation).WithMany(p => p.TbDetalleVenta)
                .HasForeignKey(d => d.IdProductoC)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleVentas_Producto");

            entity.HasOne(d => d.IdVentaCNavigation).WithMany(p => p.TbDetalleVenta)
                .HasForeignKey(d => d.IdVentaC)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleVentas_Ventas");
        });

        modelBuilder.Entity<TbEmpleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK_IdEmpleado");

            entity.ToTable("tbEmpleado");

            entity.HasIndex(e => e.Cedula, "AK_Cedula").IsUnique();

            entity.Property(e => e.Apellido1)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Apellido2)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Cedula)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.CorreoEmpleado)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.NombreContacto)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RutaFoto).IsUnicode(false);
            entity.Property(e => e.TelefonoContacto)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.TelefonoEmpleado)
                .HasMaxLength(11)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.TbEmpleados)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empleado_Rol");
        });

        modelBuilder.Entity<TbEmpleadoSoporte>(entity =>
        {
            entity.HasKey(e => e.IdEmpleadoSoporte).HasName("PK_IdEmpleadoSoporte");

            entity.ToTable("tbEmpleadoSoporte");

            entity.Property(e => e.IdEmpleadoEs).HasColumnName("IdEmpleado_es");
            entity.Property(e => e.IdSoporteEs).HasColumnName("IdSoporte_es");

            entity.HasOne(d => d.IdEmpleadoEsNavigation).WithMany(p => p.TbEmpleadoSoportes)
                .HasForeignKey(d => d.IdEmpleadoEs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_EmpleadoSoporte_Empleado");

            entity.HasOne(d => d.IdSoporteEsNavigation).WithMany(p => p.TbEmpleadoSoportes)
                .HasForeignKey(d => d.IdSoporteEs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_EmpleadoSoporte_Soporte");
        });

        modelBuilder.Entity<TbProducto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK_IdProducto");

            entity.ToTable("tbProducto");

            entity.HasIndex(e => new { e.NumSerie, e.NumParte }, "AK_NumSerie_NumParte").IsUnique();

            entity.Property(e => e.CostoProducto).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FechaFinGarantia).HasColumnType("datetime");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumParte)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NumSerie)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.TbProductos)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proveedor");
        });

        modelBuilder.Entity<TbProveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK_IdProveedor");

            entity.ToTable("tbProveedor");

            entity.Property(e => e.CorreoProveedor)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.DireccionProveedor)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NombreContacto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreProveedor)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.ProductoProveedor)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.TelefonoProveedor)
                .HasMaxLength(14)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbRol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__tbRol__2A49584CA5627544");

            entity.ToTable("tbRol");

            entity.HasIndex(e => e.NombreRol, "AK_NombreRol").IsUnique();

            entity.Property(e => e.NombreRol)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbSoporte>(entity =>
        {
            entity.HasKey(e => e.IdSoporte).HasName("PK_IdSoporte");

            entity.ToTable("tbSoporte");

            entity.Property(e => e.DescripcionSoporte)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FechaAgendada).HasColumnType("datetime");
            entity.Property(e => e.FechaCierreSoporte).HasColumnType("datetime");
            entity.Property(e => e.IdTipoS).HasColumnName("IdTipo_s");

            entity.HasOne(d => d.IdTipoSNavigation).WithMany(p => p.TbSoportes)
                .HasForeignKey(d => d.IdTipoS)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_Soporte_Tipo");
        });

        modelBuilder.Entity<TbSoporteCliente>(entity =>
        {
            entity.HasKey(e => e.IdSoporteCliente).HasName("PK_IdSoporteCliente");

            entity.ToTable("tbSoporteCliente");

            entity.Property(e => e.IdClienteSc).HasColumnName("IdCliente_sc");
            entity.Property(e => e.IdSoporteSc).HasColumnName("IdSoporte_sc");

            entity.HasOne(d => d.IdClienteScNavigation).WithMany(p => p.TbSoporteClientes)
                .HasForeignKey(d => d.IdClienteSc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SoporteCliente_Cliente");

            entity.HasOne(d => d.IdSoporteScNavigation).WithMany(p => p.TbSoporteClientes)
                .HasForeignKey(d => d.IdSoporteSc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SoporteCliente_Soporte");
        });

        modelBuilder.Entity<TbTipoSoporte>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("PK_IdTipo");

            entity.ToTable("tbTipoSoporte");

            entity.HasIndex(e => e.NombreSoporte, "AK_IdNombreSoporte").IsUnique();

            entity.Property(e => e.NombreSoporte)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbVenta>(entity =>
        {
            entity.HasKey(e => e.IdVenta);

            entity.ToTable("tbVentas");

            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaVenta).HasColumnType("datetime");
            entity.Property(e => e.IdClienteV).HasColumnName("IdCliente_v");
            entity.Property(e => e.MontoTotal).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.IdClienteVNavigation).WithMany(p => p.TbVenta)
                .HasForeignKey(d => d.IdClienteV)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Venta_Cliente");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
