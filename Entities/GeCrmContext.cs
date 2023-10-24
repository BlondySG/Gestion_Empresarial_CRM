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

    public virtual DbSet<TbArticulo> TbArticulos { get; set; }

    public virtual DbSet<TbBitacora> TbBitacoras { get; set; }

    public virtual DbSet<TbCliente> TbClientes { get; set; }

    public virtual DbSet<TbDatosCompra> TbDatosCompras { get; set; }

    public virtual DbSet<TbDatosVentum> TbDatosVenta { get; set; }

    public virtual DbSet<TbEmpleado> TbEmpleados { get; set; }

    public virtual DbSet<TbEmpleadoSoporte> TbEmpleadoSoportes { get; set; }

    public virtual DbSet<TbProveedor> TbProveedors { get; set; }

    public virtual DbSet<TbRol> TbRols { get; set; }

    public virtual DbSet<TbSoporte> TbSoportes { get; set; }

    public virtual DbSet<TbSoporteCliente> TbSoporteClientes { get; set; }

    public virtual DbSet<TbTipoSoporte> TbTipoSoportes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=GE_CRM;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbArticulo>(entity =>
        {
            entity.HasKey(e => e.IdArticulo).HasName("PK_IdArticulo");

            entity.ToTable("tbArticulo", tb => tb.HasTrigger("InsertBitArticulo"));

            entity.HasIndex(e => new { e.IdArticulo, e.NumSerie, e.NumParte }, "AK_Articulo_NumSerie_NumParte").IsUnique();

            entity.Property(e => e.CostoArticulo).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FechaFinGarantia).HasColumnType("datetime");
            entity.Property(e => e.NombreArticulo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumParte)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NumSerie)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.TbArticulos)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proveedor");
        });

        modelBuilder.Entity<TbBitacora>(entity =>
        {
            entity.HasKey(e => e.IdBitacora).HasName("PK_IdBitacora");

            entity.ToTable("tbBitacora");

            entity.HasIndex(e => e.IdBitacora, "AK_IdBitacora").IsUnique();

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

            entity.ToTable("tbCliente", tb => tb.HasTrigger("InsertBitCliente"));

            entity.HasIndex(e => e.IdCliente, "AK_IdCliente").IsUnique();

            entity.Property(e => e.CorreoCliente)
                .HasMaxLength(50)
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

        modelBuilder.Entity<TbDatosCompra>(entity =>
        {
            entity.HasKey(e => e.IdCompra).HasName("PK_IdCompra");

            entity.ToTable("tbDatosCompra", tb =>
                {
                    tb.HasTrigger("InsertBitdcompra");
                    tb.HasTrigger("tbCompraDeleteTrigger");
                });

            entity.HasIndex(e => e.IdCompra, "AK_IdCompra").IsUnique();

            entity.Property(e => e.FechaCompra).HasColumnType("datetime");
            entity.Property(e => e.ImpuestoCompra).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.NumFacturaCompra)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SubTotalCompra).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TotalCompra).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdArticuloNavigation).WithMany(p => p.TbDatosCompras)
                .HasForeignKey(d => d.IdArticulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Compra_Articulo");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.TbDatosCompras)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Compra_Proveedor");
        });

        modelBuilder.Entity<TbDatosVentum>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK_IdVenta");

            entity.ToTable("tbDatosVenta", tb =>
                {
                    tb.HasTrigger("InsertBitdventa");
                    tb.HasTrigger("tbVentaDeleteTrigger");
                });

            entity.HasIndex(e => e.IdVenta, "AK_IdVenta").IsUnique();

            entity.Property(e => e.FechaCompra).HasColumnType("datetime");
            entity.Property(e => e.FechaVenta).HasColumnType("datetime");
            entity.Property(e => e.ImpuestoVenta).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.NumFacturaVenta)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SubTotalVenta).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TotalVenta).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdArticuloNavigation).WithMany(p => p.TbDatosVenta)
                .HasForeignKey(d => d.IdArticulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Venta_Articulo");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.TbDatosVenta)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Venta_Cliente");
        });

        modelBuilder.Entity<TbEmpleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK_IdEmpleado");

            entity.ToTable("tbEmpleado", tb => tb.HasTrigger("InsertBitEmpleado"));

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
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Foto).IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.NombreContacto)
                .HasMaxLength(255)
                .IsUnicode(false);
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
            entity.HasKey(e => e.IdEmpleadoSoporte).HasName("PK__tbEmplea__17881CD653345E86");

            entity.ToTable("tbEmpleadoSoporte");

            entity.HasIndex(e => e.IdEmpleadoSoporte, "AK_IdEmpleadoSoporte").IsUnique();

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.TbEmpleadoSoportes)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_EmpleadoSoporte_Empleado");

            entity.HasOne(d => d.IdSoporteNavigation).WithMany(p => p.TbEmpleadoSoportes)
                .HasForeignKey(d => d.IdSoporte)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_EmpleadoSoporte_Soporte");
        });

        modelBuilder.Entity<TbProveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK_IdProveedor");

            entity.ToTable("tbProveedor", tb => tb.HasTrigger("InsertBitProveedor"));

            entity.HasIndex(e => e.IdProveedor, "AK_IdProveedor").IsUnique();

            entity.Property(e => e.CorreoProveedor)
                .HasMaxLength(50)
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
            entity.HasKey(e => e.IdRol).HasName("PK__tbRol__2A49584CCCF4060B");

            entity.ToTable("tbRol", tb => tb.HasTrigger("InsertBitRol"));

            entity.HasIndex(e => e.IdRol, "AK_IdRol").IsUnique();

            entity.Property(e => e.NombreRol)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbSoporte>(entity =>
        {
            entity.HasKey(e => e.IdSoporte).HasName("PK_IdSoporte");

            entity.ToTable("tbSoporte", tb => tb.HasTrigger("InsertBitSoporte"));

            entity.HasIndex(e => e.IdSoporte, "AK_Soporte").IsUnique();

            entity.Property(e => e.DescripcionSoporte)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FechaAgendada).HasColumnType("datetime");
            entity.Property(e => e.FechaCierreSoporte).HasColumnType("datetime");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.TbSoportes)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Soporte_Cliente");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.TbSoportes)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_Soporte_Empleado");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.TbSoportes)
                .HasForeignKey(d => d.IdTipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_Soporte_Tipo");
        });

        modelBuilder.Entity<TbSoporteCliente>(entity =>
        {
            entity.HasKey(e => e.IdSoporteCliente).HasName("PK_IdSoporteCliente");

            entity.ToTable("tbSoporteCliente");

            entity.HasIndex(e => e.IdSoporteCliente, "AK_IdSoporteCliente").IsUnique();

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.TbSoporteClientes)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SoporteCliente_Cliente");

            entity.HasOne(d => d.IdSoporteNavigation).WithMany(p => p.TbSoporteClientes)
                .HasForeignKey(d => d.IdSoporte)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SoporteCliente_Soporte");
        });

        modelBuilder.Entity<TbTipoSoporte>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("PK_IdTipo");

            entity.ToTable("tbTipoSoporte");

            entity.HasIndex(e => e.IdTipo, "AK_Tipo").IsUnique();

            entity.Property(e => e.NombreSoporte)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
