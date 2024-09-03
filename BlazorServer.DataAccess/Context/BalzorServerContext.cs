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

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
