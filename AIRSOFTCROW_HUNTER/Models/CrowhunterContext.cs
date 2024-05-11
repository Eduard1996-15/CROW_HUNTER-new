using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AIRSOFTCROW_HUNTER.Models;

public partial class CrowhunterContext : DbContext
{
    public CrowhunterContext()
    {
    }

    public CrowhunterContext(DbContextOptions<CrowhunterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accesorio> Accesorios { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Bb> Bbs { get; set; }

    public virtual DbSet<Estadistica> Estadisticas { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<Foto> Fotos { get; set; }

    public virtual DbSet<HistorialMantenimientoReplica> HistorialMantenimientoReplicas { get; set; }

    public virtual DbSet<MantenimientoReplica> MantenimientoReplicas { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Publicacion> Publicacions { get; set; }

    public virtual DbSet<Replica> Replicas { get; set; }

    public virtual DbSet<Tema> Temas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:conexion");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accesorio>(entity =>
        {
            entity.HasKey(e => e.IdAccesorio).HasName("PK__Accesori__F7D9D8C7B84C6E44");

            entity.ToTable("Accesorio");

            entity.Property(e => e.IdAccesorio)
                .ValueGeneratedNever()
                .HasColumnName("ID_Accesorio");
            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.IdAdmin).HasName("PK__Admin__69F5676677D9D26B");

            entity.ToTable("Admin");

            entity.HasIndex(e => e.Username, "UQ__Admin__536C85E4E489F7D7").IsUnique();

            entity.Property(e => e.IdAdmin).HasColumnName("ID_Admin");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Bb>(entity =>
        {
            entity.HasKey(e => e.IdBb).HasName("PK__BB__8B6207EECD9854A1");

            entity.ToTable("BB");

            entity.Property(e => e.IdBb)
                .ValueGeneratedNever()
                .HasColumnName("ID_BB");
            entity.Property(e => e.IdProducto).HasColumnName("ID_Producto");
            entity.Property(e => e.Material)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Bbs)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__BB__ID_Producto__4BAC3F29");
        });

        modelBuilder.Entity<Estadistica>(entity =>
        {

            entity.HasKey(k => k.IdPersona);
            entity.Property(e => e.IdPersona).HasColumnName("ID_Persona");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany()
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Estadistica_Persona");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.IdEvento).HasName("PK__Evento__929BD0C1359344BF");

            entity.ToTable("Evento");

            entity.Property(e => e.IdEvento)
                .ValueGeneratedNever()
                .HasColumnName("ID_Evento");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.FechaFin).HasColumnName("Fecha_Fin");
            entity.Property(e => e.FechaInicio).HasColumnName("Fecha_Inicio");
            entity.Property(e => e.NombreEvento)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Nombre_Evento");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Foto>(entity =>
        {
            entity.HasKey(e => e.IdFoto).HasName("PK__Foto__195DD8756E3E286F");

            entity.ToTable("Foto");

            entity.Property(e => e.IdFoto).UseIdentityColumn()
                .HasColumnName("ID_Foto");
            entity.Property(e => e.EventoRelacionado).HasColumnName("Evento_Relacionado");
            entity.Property(e => e.IdPersona).HasColumnName("ID_Persona");
            entity.Property(e => e.Titulo)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.EventoRelacionadoNavigation).WithMany(p => p.Fotos)
                .HasForeignKey(d => d.EventoRelacionado)
                .HasConstraintName("FK__Foto__Evento_Rel__3F466844");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Fotos)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK__Foto__ID_Persona__3E52440B");
        });

        modelBuilder.Entity<HistorialMantenimientoReplica>(entity =>
        {
            entity.HasKey(e => e.IdHistorialMantenimiento).HasName("PK__Historia__127C423C978DA813");

            entity.ToTable("HistorialMantenimientoReplica");

            entity.Property(e => e.IdHistorialMantenimiento)
                .ValueGeneratedNever()
                .HasColumnName("ID_HistorialMantenimiento");
            entity.Property(e => e.Costo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.FechaMantenimiento).HasColumnType("datetime");
            entity.Property(e => e.IdReplica).HasColumnName("ID_Replica");
            entity.Property(e => e.Responsable)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MantenimientoReplica>(entity =>
        {
            entity.HasKey(e => e.IdMantenimiento).HasName("PK__Mantenim__BD4C405AC35A1B56");

            entity.ToTable("MantenimientoReplica");

            entity.Property(e => e.IdMantenimiento)
                .ValueGeneratedNever()
                .HasColumnName("ID_Mantenimiento");
            entity.Property(e => e.Costo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.FechaFin).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.IdReplica).HasColumnName("ID_Replica");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__Persona__E9916EC1A1636EFA");

            entity.ToTable("Persona");

            entity.Property(e => e.IdPersona).HasColumnName("ID_Persona");
            entity.Property(e => e.Alias).HasMaxLength(50);
            entity.Property(e => e.Biografía).HasMaxLength(500);
            entity.Property(e => e.CancionMp3).HasColumnName("CancionMP3");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FechaIngreso).HasColumnName("Fecha_Ingreso");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Rol)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__9B4120E23EB58F20");

            entity.ToTable("Producto");

            entity.Property(e => e.IdProducto)
                .ValueGeneratedNever()
                .HasColumnName("ID_Producto");
            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Publicacion>(entity =>
        {
            entity.HasKey(e => e.IdPublicacion).HasName("PK__Publicac__1EF15D3A8EA52896");

            entity.ToTable("Publicacion");

            entity.Property(e => e.IdPublicacion)
                .ValueGeneratedNever()
                .HasColumnName("ID_Publicacion");
            entity.Property(e => e.Autor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contenido).HasColumnType("text");
            entity.Property(e => e.FechaPublicacion).HasColumnType("datetime");
            entity.Property(e => e.IdTema).HasColumnName("ID_Tema");
        });

        modelBuilder.Entity<Replica>(entity =>
        {
            entity.HasKey(e => e.IdReplica).HasName("PK__Replica__CDF7A3EDD531E646");

            entity.ToTable("Replica");

            entity.Property(e => e.IdReplica)
                .ValueGeneratedNever()
                .HasColumnName("ID_Replica");
            entity.Property(e => e.Fps).HasColumnName("FPS");
            entity.Property(e => e.IdProducto).HasColumnName("ID_Producto");
            entity.Property(e => e.Material)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Peso).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Replicas)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__Replica__ID_Prod__47DBAE45");
        });

        modelBuilder.Entity<Tema>(entity =>
        {
            entity.HasKey(e => e.IdTema).HasName("PK__Tema__D659FE8F9AF654B1");

            entity.ToTable("Tema");

            entity.Property(e => e.IdTema)
                .ValueGeneratedNever()
                .HasColumnName("ID_Tema");
            entity.Property(e => e.Autor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
