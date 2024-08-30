using System;
using System.Collections.Generic;
using BlazorServer.DataAccess.Models.FineAgendamientoDian;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlazorServer.DataAccess.Context;

public partial class FineAgendamientoDianContext : DbContext
{
    public FineAgendamientoDianContext()
    {
    }

    public FineAgendamientoDianContext(DbContextOptions<FineAgendamientoDianContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CargueBaseDian> CargueBaseDian { get; set; }

    public virtual DbSet<Citas> Citas { get; set; }

    public virtual DbSet<Dato> Dato { get; set; }

    public virtual DbSet<LogSmscitas> LogSmscitas { get; set; }

    public virtual DbSet<MallaAgenda> MallaAgenda { get; set; }

    public virtual DbSet<Parametros> Parametros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json").Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DBConectionFineDIAN"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<CargueBaseDian>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CargueBaseDianDestino");
        });

        modelBuilder.Entity<Citas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Citas__3214EC0714CD611B");

            entity.HasOne(d => d.IdMallaAgendaNavigation).WithMany(p => p.Citas).HasConstraintName("FK_MallaAgenda");
        });

        modelBuilder.Entity<Dato>(entity =>
        {
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<LogSmscitas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LogSMSCi__3214EC073D51674B");
        });

        modelBuilder.Entity<MallaAgenda>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MallaAge__3214EC07E138DAE0");
        });

        modelBuilder.Entity<Parametros>(entity =>
        {
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Parametro).WithMany(p => p.Parametros)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Parametros_Dato");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
