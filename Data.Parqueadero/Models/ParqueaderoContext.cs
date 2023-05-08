using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Parqueadero.Models;

public partial class ParqueaderoContext : DbContext
{

    private readonly IConfiguration _configuration;

    public ParqueaderoContext(DbContextOptions<ParqueaderoContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Importe> Importes { get; set; }

    public virtual DbSet<TiposUsuario> TiposUsuarios { get; set; }

    public virtual DbSet<TiposVehiculo> TiposVehiculos { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(_configuration.GetConnectionString("parqueaderoConection"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasIndex(e => e.Id, "IX_Empleados").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.Celular)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.Contrasena)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.TipoUsuarioNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.TipoUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empleados_TiposUsuarios");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado);

            entity.HasIndex(e => e.IdEstado, "IX_Estados").IsUnique();

            entity.Property(e => e.IdEstado).HasColumnName("Id_Estado");
            entity.Property(e => e.Estado1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Estado");
        });

        modelBuilder.Entity<Importe>(entity =>
        {
            entity.HasKey(e => e.IdRegistro);

            entity.HasIndex(e => e.IdRegistro, "IX_Importes").IsUnique();

            entity.Property(e => e.IdRegistro).HasColumnName("Id_Registro");
            entity.Property(e => e.FechaEntrada).HasColumnType("datetime");
            entity.Property(e => e.FechaSalida).HasColumnType("datetime");
            entity.Property(e => e.Importe1).HasColumnName("Importe");
            entity.Property(e => e.Placa)
                .HasMaxLength(9)
                .IsUnicode(false);

            entity.HasOne(d => d.EstadoNavigation).WithMany(p => p.Importes)
                .HasForeignKey(d => d.Estado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Importes_Estados");

           
        });

        modelBuilder.Entity<TiposUsuario>(entity =>
        {
            entity.HasKey(e => e.IdTipoUsuario);

            entity.HasIndex(e => e.IdTipoUsuario, "IX_TiposUsuarios").IsUnique();

            entity.Property(e => e.IdTipoUsuario).HasColumnName("Id_TipoUsuario");
            entity.Property(e => e.TipoUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TiposVehiculo>(entity =>
        {
            entity.HasKey(e => e.IdTipoVehiculo);

            entity.HasIndex(e => e.IdTipoVehiculo, "IX_TiposVehiculos").IsUnique();

            entity.Property(e => e.IdTipoVehiculo).HasColumnName("Id_TipoVehiculo");
            entity.Property(e => e.TipoVehiculo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.Placa);

            entity.HasIndex(e => e.Placa, "IX_Vehiculos").IsUnique();

            entity.Property(e => e.Placa)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.IdTipoVehiculo).HasColumnName("Id_TipoVehiculo");

            entity.HasOne(d => d.IdTipoVehiculoNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.IdTipoVehiculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehiculos_TiposVehiculos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
