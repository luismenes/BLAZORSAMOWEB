using BlazorServer.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlazorServer.DataAccess.Context;

public partial class BalzorServerContext : DbContext
{
    public BalzorServerContext()
    {
    }

    public BalzorServerContext(DbContextOptions<BalzorServerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dato> Datos { get; set; }

    public virtual DbSet<Tabla> Tablas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json").Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DBConectionString"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Configuracion.Dato");

            entity.ToTable("Dato", "Configuracion");

            entity.Property(e => e.Codigo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Equivalente).IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Herencia).IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(600)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioId).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.Tabla).WithMany(p => p.Datos)
                .HasForeignKey(d => d.TablaId)
                .HasConstraintName("FK_Configuracion.Dato_Configuracion.Tabla_TablaId");
        });

        modelBuilder.Entity<Tabla>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Configuracion.Tabla");

            entity.ToTable("Tabla", "Configuracion");

            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
