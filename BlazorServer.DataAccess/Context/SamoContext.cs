using System;
using System.Collections.Generic;
using BlazorServer.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlazorServer.DataAccess.Context;

public partial class SamoContext : DbContext
{
    public SamoContext()
    {
    }

    public SamoContext(DbContextOptions<SamoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acceso> Accesos { get; set; }

    public virtual DbSet<AmbitoProcedimiento> AmbitoProcedimientos { get; set; }

    public virtual DbSet<AmbitoSede> AmbitoSedes { get; set; }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<ClaseEntidad> ClaseEntidads { get; set; }

    public virtual DbSet<ConfiguracionPlantilla> ConfiguracionPlantillas { get; set; }

    public virtual DbSet<ContactoPaciente> ContactoPacientes { get; set; }

    public virtual DbSet<Convenio> Convenios { get; set; }

    public virtual DbSet<ConvenioControlProcedimiento> ConvenioControlProcedimientos { get; set; }

    public virtual DbSet<ConvenioSede> ConvenioSedes { get; set; }

    public virtual DbSet<Dato> Datos { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<DetalleOperacion> DetalleOperacions { get; set; }

    public virtual DbSet<Entidad> Entidads { get; set; }

    public virtual DbSet<Especialidad> Especialidads { get; set; }

    public virtual DbSet<EspecialidadProcedimiento> EspecialidadProcedimientos { get; set; }

    public virtual DbSet<Ip> Ips { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<NivelRecaudo> NivelRecaudos { get; set; }

    public virtual DbSet<NivelRecaudoConfiguracion> NivelRecaudoConfiguracions { get; set; }

    public virtual DbSet<NivelRecaudoConfiguracionProcedimiento> NivelRecaudoConfiguracionProcedimientos { get; set; }

    public virtual DbSet<NivelRecaudoConfiguracionTipo> NivelRecaudoConfiguracionTipos { get; set; }

    public virtual DbSet<NivelSede> NivelSedes { get; set; }

    public virtual DbSet<Operacion> Operacions { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<PlanSalud> PlanSaluds { get; set; }

    public virtual DbSet<PlanSaludProcedimiento> PlanSaludProcedimientos { get; set; }

    public virtual DbSet<Procedimiento> Procedimientos { get; set; }

    public virtual DbSet<Profesional> Profesionals { get; set; }

    public virtual DbSet<ProfesionalEspecialidad> ProfesionalEspecialidads { get; set; }

    public virtual DbSet<ResolucionAutoretenedor> ResolucionAutoretenedors { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<RolUser> RolUsers { get; set; }

    public virtual DbSet<Sede> Sedes { get; set; }

    public virtual DbSet<Tabla> Tablas { get; set; }

    public virtual DbSet<Tarifa> Tarifas { get; set; }

    public virtual DbSet<TarifaVigenciaConfiguracion> TarifaVigenciaConfiguracions { get; set; }

    public virtual DbSet<TarifaVigencium> TarifaVigencia { get; set; }

    public virtual DbSet<UbicacionSede> UbicacionSedes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserSede> UserSedes { get; set; }

    public virtual DbSet<ZonaResidencial> ZonaResidencials { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json").Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DBConectionString"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acceso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PermisoPaginas");

            entity.ToTable("Acceso", "Seguridad");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Accesos)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Acceso_Rol");

            entity.HasOne(d => d.Menu).WithMany(p => p.Accesos)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Acceso_Menu");

            entity.HasOne(d => d.Operacion).WithMany(p => p.Accesos)
                .HasForeignKey(d => d.OperacionId)
                .HasConstraintName("FK_Acceso_Operacion");
        });

        modelBuilder.Entity<AmbitoProcedimiento>(entity =>
        {
            entity.ToTable("AmbitoProcedimiento", "Configuracion");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.HasOne(d => d.Ambito).WithMany(p => p.AmbitoProcedimientos)
                .HasForeignKey(d => d.AmbitoId)
                .HasConstraintName("FK_AmbitoProcedimiento_Dato");

            entity.HasOne(d => d.Procedimiento).WithMany(p => p.AmbitoProcedimientos)
                .HasForeignKey(d => d.ProcedimientoId)
                .HasConstraintName("FK_AmbitoProcedimiento_Procedimiento");
        });

        modelBuilder.Entity<AmbitoSede>(entity =>
        {
            entity.ToTable("AmbitoSede", "Configuracion");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.HasOne(d => d.Ambito).WithMany(p => p.AmbitoSedes)
                .HasForeignKey(d => d.AmbitoId)
                .HasConstraintName("FK_AmbitoSede_Dato");

            entity.HasOne(d => d.Sede).WithMany(p => p.AmbitoSedes)
                .HasForeignKey(d => d.SedeId)
                .HasConstraintName("FK_AmbitoSede_Sede");
        });

        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TR_MUNICIPIOS");

            entity.ToTable("Ciudad", "Configuracion");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .HasColumnName("CODIGO");
            entity.Property(e => e.CodigoArea)
                .HasMaxLength(10)
                .HasColumnName("CODIGO_AREA");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.IdDepartamento).HasColumnName("ID_DEPARTAMENTO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("NOMBRE");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TR_MUNICIPIOS_TR_DEPARTAMENTO");
        });

        modelBuilder.Entity<ClaseEntidad>(entity =>
        {
            entity.ToTable("ClaseEntidad", "Configuracion");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.HasOne(d => d.ClaseEntidadNavigation).WithMany(p => p.ClaseEntidads)
                .HasForeignKey(d => d.ClaseEntidadId)
                .HasConstraintName("FK_ClaseEntidad_Dato");

            entity.HasOne(d => d.Entidad).WithMany(p => p.ClaseEntidads)
                .HasForeignKey(d => d.EntidadId)
                .HasConstraintName("FK_ClaseEntidad_Entidad");

            entity.HasOne(d => d.Usuario).WithMany(p => p.ClaseEntidads)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_ClaseEntidad_User");
        });

        modelBuilder.Entity<ConfiguracionPlantilla>(entity =>
        {
            entity.ToTable("ConfiguracionPlantilla", "Configuracion");

            entity.Property(e => e.AttributesClass)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AttributesStyle)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.HasOne(d => d.Operacion).WithMany(p => p.ConfiguracionPlantillas)
                .HasForeignKey(d => d.OperacionId)
                .HasConstraintName("FK_ConfiguracionPlantilla_Operacion");

            entity.HasOne(d => d.User).WithMany(p => p.ConfiguracionPlantillas)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_ConfiguracionPlantilla_User");
        });

        modelBuilder.Entity<ContactoPaciente>(entity =>
        {
            entity.ToTable("ContactoPaciente", "Configuracion");

            entity.Property(e => e.Barrio)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Celular)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Ciudad).WithMany(p => p.ContactoPacientes)
                .HasForeignKey(d => d.CiudadId)
                .HasConstraintName("FK_ContactoPaciente_TR_MUNICIPIOS");

            entity.HasOne(d => d.Departamento).WithMany(p => p.ContactoPacientes)
                .HasForeignKey(d => d.DepartamentoId)
                .HasConstraintName("FK_ContactoPaciente_TR_DEPARTAMENTO");

            entity.HasOne(d => d.Paciente).WithMany(p => p.ContactoPacientes)
                .HasForeignKey(d => d.PacienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContactoPaciente_Paciente");

            entity.HasOne(d => d.Zona).WithMany(p => p.ContactoPacientes)
                .HasForeignKey(d => d.ZonaId)
                .HasConstraintName("FK_ContactoPaciente_TR_ZONA_RESIDENCIAL");
        });

        modelBuilder.Entity<Convenio>(entity =>
        {
            entity.ToTable("Convenio", "Configuracion");

            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CodigoEapb)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("CodigoEAPB");
            entity.Property(e => e.CodigoRips)
                .IsUnicode(false)
                .HasColumnName("CodigoRIPS");
            entity.Property(e => e.EsConBeneficiarios).HasColumnName("Es_ConBeneficiarios");
            entity.Property(e => e.EsJustNoPos).HasColumnName("Es_JustNoPos");
            entity.Property(e => e.EsTodaSede).HasColumnName("Es_TodaSede");
            entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaFin).HasColumnType("date");
            entity.Property(e => e.FechaInicio).HasColumnType("date");
            entity.Property(e => e.FechaPrestaFin).HasColumnType("date");
            entity.Property(e => e.FechaPrestaInicio).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PoblacionAtiende).HasMaxLength(100);

            entity.HasOne(d => d.Clase).WithMany(p => p.ConvenioClases)
                .HasForeignKey(d => d.ClaseId)
                .HasConstraintName("FK_Convenio_Dato");

            entity.HasOne(d => d.Entidad).WithMany(p => p.Convenios)
                .HasForeignKey(d => d.EntidadId)
                .HasConstraintName("FK_Convenio_Entidad");

            entity.HasOne(d => d.Operacion).WithMany(p => p.Convenios)
                .HasForeignKey(d => d.OperacionId)
                .HasConstraintName("FK_Convenio_Operacion");

            entity.HasOne(d => d.OrigenConvenio).WithMany(p => p.ConvenioOrigenConvenios)
                .HasForeignKey(d => d.OrigenConvenioId)
                .HasConstraintName("FK_Convenio_Dato2");

            entity.HasOne(d => d.TipoConvenio).WithMany(p => p.ConvenioTipoConvenios)
                .HasForeignKey(d => d.TipoConvenioId)
                .HasConstraintName("FK_Convenio_Dato1");

            entity.HasOne(d => d.TipoUserRegimenNavigation).WithMany(p => p.ConvenioTipoUserRegimenNavigations)
                .HasForeignKey(d => d.TipoUserRegimen)
                .HasConstraintName("FK_Convenio_Dato3");

            entity.HasOne(d => d.UsuarioActualiza).WithMany(p => p.ConvenioUsuarioActualizas)
                .HasForeignKey(d => d.UsuarioActualizaId)
                .HasConstraintName("FK_Convenio_User1");

            entity.HasOne(d => d.Usuario).WithMany(p => p.ConvenioUsuarios)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_Convenio_User");
        });

        modelBuilder.Entity<ConvenioControlProcedimiento>(entity =>
        {
            entity.ToTable("ConvenioControlProcedimiento", "Configuracion");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.HasOne(d => d.Convenio).WithMany(p => p.ConvenioControlProcedimientos)
                .HasForeignKey(d => d.ConvenioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConvenioControlProcedimiento_Convenio");

            entity.HasOne(d => d.Procedimiento).WithMany(p => p.ConvenioControlProcedimientos)
                .HasForeignKey(d => d.ProcedimientoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConvenioControlProcedimiento_Procedimiento");

            entity.HasOne(d => d.TipoControl).WithMany(p => p.ConvenioControlProcedimientos)
                .HasForeignKey(d => d.TipoControlId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConvenioControlProcedimiento_Dato");
        });

        modelBuilder.Entity<ConvenioSede>(entity =>
        {
            entity.ToTable("ConvenioSede", "Configuracion");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.HasOne(d => d.Convenio).WithMany(p => p.ConvenioSedes)
                .HasForeignKey(d => d.ConvenioId)
                .HasConstraintName("FK_ConvenioSede_Convenio");

            entity.HasOne(d => d.Sede).WithMany(p => p.ConvenioSedes)
                .HasForeignKey(d => d.SedeId)
                .HasConstraintName("FK_ConvenioSede_Sede");
        });

        modelBuilder.Entity<Dato>(entity =>
        {
            entity.ToTable("Dato", "Configuracion");

            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Equivalente)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.Herencia)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.Tabla).WithMany(p => p.Datos)
                .HasForeignKey(d => d.TablaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Dato_Tabla");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TR_DEPARTAMENTO");

            entity.ToTable("Departamento", "Configuracion");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CODIGO");
            entity.Property(e => e.CodigoArea)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CODIGO_AREA");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.IdPais).HasColumnName("ID_PAIS");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Departamentos)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TR_DEPARTAMENTO_TR_PAIS");
        });

        modelBuilder.Entity<DetalleOperacion>(entity =>
        {
            entity.ToTable("DetalleOperacion", "Configuracion");

            entity.Property(e => e.DigitoVerificacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.IdTipoIdentificacion).HasColumnName("Id_Tipo_Identificacion");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IpMaquina)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.NombreMaquina)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.NumRut)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RentaAnual)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RentaMensual)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RepresentanteLegal)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Resolucion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Responsable)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Ambito).WithMany(p => p.DetalleOperacionAmbitos)
                .HasForeignKey(d => d.AmbitoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleOperacion_Dato1");

            entity.HasOne(d => d.Centralizado).WithMany(p => p.DetalleOperacionCentralizados)
                .HasForeignKey(d => d.CentralizadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleOperacion_Dato2");

            entity.HasOne(d => d.CostoNiff).WithMany(p => p.DetalleOperacionCostoNiffs)
                .HasForeignKey(d => d.CostoNiffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleOperacion_Dato6");

            entity.HasOne(d => d.Entidad).WithMany(p => p.DetalleOperacions)
                .HasForeignKey(d => d.EntidadId)
                .HasConstraintName("FK_DetalleOperacion_Entidad");

            entity.HasOne(d => d.IdTipoIdentificacionNavigation).WithMany(p => p.DetalleOperacionIdTipoIdentificacionNavigations)
                .HasForeignKey(d => d.IdTipoIdentificacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleOperacion_Dato");

            entity.HasOne(d => d.Operacion).WithMany(p => p.DetalleOperacions)
                .HasForeignKey(d => d.OperacionId)
                .HasConstraintName("FK_DetalleOperacion_Operacion");

            entity.HasOne(d => d.Regimen).WithMany(p => p.DetalleOperacionRegimen)
                .HasForeignKey(d => d.RegimenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleOperacion_Dato4");

            entity.HasOne(d => d.TipoContribuyente).WithMany(p => p.DetalleOperacionTipoContribuyentes)
                .HasForeignKey(d => d.TipoContribuyenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleOperacion_Dato5");

            entity.HasOne(d => d.TipoPersona).WithMany(p => p.DetalleOperacionTipoPersonas)
                .HasForeignKey(d => d.TipoPersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleOperacion_Dato7");

            entity.HasOne(d => d.TipoPlan).WithMany(p => p.DetalleOperacionTipoPlans)
                .HasForeignKey(d => d.TipoPlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleOperacion_Dato3");

            entity.HasOne(d => d.Usuario).WithMany(p => p.DetalleOperacions)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleOperacion_User");
        });

        modelBuilder.Entity<Entidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TP_PERSONAL_W_S");

            entity.ToTable("Entidad", "Configuracion");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Activo).HasColumnName("ACTIVO");
            entity.Property(e => e.Barrio)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CiudadNacimiento)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DigitoVerificacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.FechaExpedicion).HasColumnType("date");
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.IdTipoIdentificacion).HasColumnName("ID_TIPO_IDENTIFICACION");
            entity.Property(e => e.IpMaquina)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("IP_MAQUINA");
            entity.Property(e => e.LugarExpedicion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_COMPLETO");
            entity.Property(e => e.NombreMaquina)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_MAQUINA");
            entity.Property(e => e.NumeroIdentificacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NUMERO_IDENTIFICACION");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRIMER_APELLIDO");
            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRIMER_NOMBRE");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RepresentanteLegal)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Responsable)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SEGUNDO_APELLIDO");
            entity.Property(e => e.SegundoNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SEGUNDO_NOMBRE");
            entity.Property(e => e.TarjetaProfesional)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono1)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("TELEFONO1");
            entity.Property(e => e.Telefono2)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("TELEFONO2");
            entity.Property(e => e.UltimaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("ULTIMA_MODIFICACION");
            entity.Property(e => e.Usuario)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("USUARIO");

            entity.HasOne(d => d.Ciudad).WithMany(p => p.Entidads)
                .HasForeignKey(d => d.CiudadId)
                .HasConstraintName("FK_Entidad_Ciudad");

            entity.HasOne(d => d.Departamento).WithMany(p => p.Entidads)
                .HasForeignKey(d => d.DepartamentoId)
                .HasConstraintName("FK_Entidad_Departamento");

            entity.HasOne(d => d.EstadoCivilNavigation).WithMany(p => p.EntidadEstadoCivilNavigations)
                .HasForeignKey(d => d.EstadoCivil)
                .HasConstraintName("FK_Entidad_Dato3");

            entity.HasOne(d => d.Genero).WithMany(p => p.EntidadGeneros)
                .HasForeignKey(d => d.GeneroId)
                .HasConstraintName("FK_Entidad_Dato2");

            entity.HasOne(d => d.IdTipoIdentificacionNavigation).WithMany(p => p.EntidadIdTipoIdentificacionNavigations)
                .HasForeignKey(d => d.IdTipoIdentificacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Entidad_Dato");

            entity.HasOne(d => d.Operacion).WithMany(p => p.Entidads)
                .HasForeignKey(d => d.OperacionId)
                .HasConstraintName("FK_Entidad_Operacion");

            entity.HasOne(d => d.TipoPersona).WithMany(p => p.EntidadTipoPersonas)
                .HasForeignKey(d => d.TipoPersonaId)
                .HasConstraintName("FK_Entidad_Dato1");

            entity.HasOne(d => d.UsuarioGestiona).WithMany(p => p.Entidads)
                .HasForeignKey(d => d.UsuarioGestionaId)
                .HasConstraintName("FK_Entidad_User");

            entity.HasOne(d => d.Zona).WithMany(p => p.Entidads)
                .HasForeignKey(d => d.ZonaId)
                .HasConstraintName("FK_Entidad_ZonaResidencial");
        });

        modelBuilder.Entity<Especialidad>(entity =>
        {
            entity.ToTable("Especialidad", "Configuracion");

            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EsAutorizado).HasColumnName("Es_Autorizado");
            entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).IsUnicode(false);

            entity.HasOne(d => d.UsuarioActualizaNavigation).WithMany(p => p.EspecialidadUsuarioActualizaNavigations)
                .HasForeignKey(d => d.UsuarioActualiza)
                .HasConstraintName("FK_Especialidad_User1");

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.EspecialidadUsuarioCreacionNavigations)
                .HasForeignKey(d => d.UsuarioCreacion)
                .HasConstraintName("FK_Especialidad_User");
        });

        modelBuilder.Entity<EspecialidadProcedimiento>(entity =>
        {
            entity.ToTable("EspecialidadProcedimiento", "Configuracion");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.HasOne(d => d.Especialidad).WithMany(p => p.EspecialidadProcedimientos)
                .HasForeignKey(d => d.EspecialidadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EspecialidadProcedimiento_Especialidad");

            entity.HasOne(d => d.Procedimiento).WithMany(p => p.EspecialidadProcedimientos)
                .HasForeignKey(d => d.ProcedimientoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EspecialidadProcedimiento_Procedimiento");
        });

        modelBuilder.Entity<Ip>(entity =>
        {
            entity.ToTable("Ips", "Configuracion");

            entity.Property(e => e.CodigoIps)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Codigo_Ips");
            entity.Property(e => e.CodigoUnion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Codigo_Union");
            entity.Property(e => e.DigitoVerifiRepresentante)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("Digito_Verifi_Representante");
            entity.Property(e => e.DigitoVerificacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Digito_Verificacion");
            entity.Property(e => e.FechaActoAdmin)
                .HasColumnType("date")
                .HasColumnName("Fecha_Acto_Admin");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.FechaCreacionIps)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion_Ips");
            entity.Property(e => e.IdActividadEconomica).HasColumnName("Id_Actividad_Economica");
            entity.Property(e => e.IdActoAdministrativo).HasColumnName("Id_Acto_Administrativo");
            entity.Property(e => e.IdAnimoLucro).HasColumnName("Id_Animo_Lucro");
            entity.Property(e => e.IdClaseEntidad).HasColumnName("Id_Clase_Entidad");
            entity.Property(e => e.IdEstadoSociedad).HasColumnName("Id_Estado_Sociedad");
            entity.Property(e => e.IdGrupoNiif).HasColumnName("Id_Grupo_NIIF");
            entity.Property(e => e.IdNaturaleza).HasColumnName("Id_Naturaleza");
            entity.Property(e => e.IdRegimenIva).HasColumnName("Id_Regimen_Iva");
            entity.Property(e => e.IdResponsable).HasColumnName("Id_Responsable");
            entity.Property(e => e.IdTipoContribuyente).HasColumnName("Id_Tipo_Contribuyente");
            entity.Property(e => e.IdTipoDocRepresentante).HasColumnName("Id_Tipo_Doc_Representante");
            entity.Property(e => e.IdTipoEmpresa).HasColumnName("Id_Tipo_Empresa");
            entity.Property(e => e.IdTipoResolucion).HasColumnName("Id_Tipo_Resolucion");
            entity.Property(e => e.IvaDeducible).HasColumnName("Iva_Deducible");
            entity.Property(e => e.NumeroActoAdmin)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Numero_Acto_Admin");
            entity.Property(e => e.NumeroDocumentoRepresentante)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Numero_Documento_Representante");
            entity.Property(e => e.NumeroIdentificacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Numero_Identificacion");
            entity.Property(e => e.NumeroSedes).HasColumnName("Numero_Sedes");
            entity.Property(e => e.NumeroSucursales).HasColumnName("Numero_Sucursales");
            entity.Property(e => e.ObjetoSocial)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Objeto_Social");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Razon_Social");
            entity.Property(e => e.RepresentanteLegal)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Representante_Legal");
            entity.Property(e => e.Sigla)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Slogan)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SolicitudHabilitacion).HasColumnName("Solicitud_Habilitacion");
            entity.Property(e => e.TipoIdentificacion).HasColumnName("Tipo_Identificacion");
            entity.Property(e => e.UltimaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("Ultima_Modificacion");
            entity.Property(e => e.UsuarioCreacion).HasColumnName("Usuario_Creacion");
            entity.Property(e => e.UsuarioModificacion).HasColumnName("Usuario_Modificacion");
            entity.Property(e => e.VencimientoConstitucion)
                .HasColumnType("date")
                .HasColumnName("Vencimiento_Constitucion");

            entity.HasOne(d => d.IdActividadEconomicaNavigation).WithMany(p => p.IpIdActividadEconomicaNavigations)
                .HasForeignKey(d => d.IdActividadEconomica)
                .HasConstraintName("FK_Ips_Dato5");

            entity.HasOne(d => d.IdActoAdministrativoNavigation).WithMany(p => p.IpIdActoAdministrativoNavigations)
                .HasForeignKey(d => d.IdActoAdministrativo)
                .HasConstraintName("FK_Ips_Dato3");

            entity.HasOne(d => d.IdClaseEntidadNavigation).WithMany(p => p.IpIdClaseEntidadNavigations)
                .HasForeignKey(d => d.IdClaseEntidad)
                .HasConstraintName("FK_Ips_Dato1");

            entity.HasOne(d => d.IdEstadoSociedadNavigation).WithMany(p => p.IpIdEstadoSociedadNavigations)
                .HasForeignKey(d => d.IdEstadoSociedad)
                .HasConstraintName("FK_Ips_Dato4");

            entity.HasOne(d => d.IdGrupoNiifNavigation).WithMany(p => p.IpIdGrupoNiifNavigations)
                .HasForeignKey(d => d.IdGrupoNiif)
                .HasConstraintName("FK_Ips_Dato7");

            entity.HasOne(d => d.IdNaturalezaNavigation).WithMany(p => p.IpIdNaturalezaNavigations)
                .HasForeignKey(d => d.IdNaturaleza)
                .HasConstraintName("FK_Ips_Dato");

            entity.HasOne(d => d.IdResponsableNavigation).WithMany(p => p.Ips)
                .HasForeignKey(d => d.IdResponsable)
                .HasConstraintName("FK_Ips_Entidad");

            entity.HasOne(d => d.IdTipoContribuyenteNavigation).WithMany(p => p.IpIdTipoContribuyenteNavigations)
                .HasForeignKey(d => d.IdTipoContribuyente)
                .HasConstraintName("FK_Ips_Dato6");

            entity.HasOne(d => d.IdTipoDocRepresentanteNavigation).WithMany(p => p.IpIdTipoDocRepresentanteNavigations)
                .HasForeignKey(d => d.IdTipoDocRepresentante)
                .HasConstraintName("FK_Ips_Dato9");

            entity.HasOne(d => d.IdTipoEmpresaNavigation).WithMany(p => p.IpIdTipoEmpresaNavigations)
                .HasForeignKey(d => d.IdTipoEmpresa)
                .HasConstraintName("FK_Ips_Dato2");

            entity.HasOne(d => d.IdTipoResolucionNavigation).WithMany(p => p.IpIdTipoResolucionNavigations)
                .HasForeignKey(d => d.IdTipoResolucion)
                .HasConstraintName("FK_Ips_Dato10");

            entity.HasOne(d => d.Sede).WithMany(p => p.Ips)
                .HasForeignKey(d => d.SedeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ips_Sede");

            entity.HasOne(d => d.TipoIdentificacionNavigation).WithMany(p => p.IpTipoIdentificacionNavigations)
                .HasForeignKey(d => d.TipoIdentificacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ips_Dato8");

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.IpUsuarioCreacionNavigations)
                .HasForeignKey(d => d.UsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ips_User");

            entity.HasOne(d => d.UsuarioModificacionNavigation).WithMany(p => p.IpUsuarioModificacionNavigations)
                .HasForeignKey(d => d.UsuarioModificacion)
                .HasConstraintName("FK_Ips_User1");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MenuPagina");

            entity.ToTable("Menu", "Seguridad");

            entity.Property(e => e.Adicional)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Url)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UrlAdsoluta).IsUnicode(false);
            entity.Property(e => e.UrlBlazor).IsUnicode(false);
            entity.Property(e => e.UrlImagen)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NivelRecaudo>(entity =>
        {
            entity.ToTable("NivelRecaudo", "Configuracion");

            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).IsUnicode(false);

            entity.HasOne(d => d.TipoVinculacion).WithMany(p => p.NivelRecaudos)
                .HasForeignKey(d => d.TipoVinculacionId)
                .HasConstraintName("FK_NivelRecaudo_Dato");

            entity.HasOne(d => d.UsuarioActualizaNavigation).WithMany(p => p.NivelRecaudoUsuarioActualizaNavigations)
                .HasForeignKey(d => d.UsuarioActualiza)
                .HasConstraintName("FK_NivelRecaudo_User1");

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.NivelRecaudoUsuarioCreacionNavigations)
                .HasForeignKey(d => d.UsuarioCreacion)
                .HasConstraintName("FK_NivelRecaudo_User");
        });

        modelBuilder.Entity<NivelRecaudoConfiguracion>(entity =>
        {
            entity.ToTable("NivelRecaudo_Configuracion", "Configuracion");

            entity.Property(e => e.ConImpuesto).HasColumnName("Con_Impuesto");
            entity.Property(e => e.ConTope).HasColumnName("Con_Tope");
            entity.Property(e => e.EsArticulo).HasColumnName("ES_Articulo");
            entity.Property(e => e.EsOtro).HasColumnName("ES_Otro");
            entity.Property(e => e.EsProcedimiento).HasColumnName("ES_Procedimiento");
            entity.Property(e => e.FechaCreate).HasColumnType("datetime");
            entity.Property(e => e.FechaUpdate).HasColumnType("datetime");
            entity.Property(e => e.ValorAnual).HasColumnType("money");
            entity.Property(e => e.ValorIndividual).HasColumnType("money");
            entity.Property(e => e.ValorPorCuenta).HasColumnType("money");

            entity.HasOne(d => d.Cobrar).WithMany(p => p.NivelRecaudoConfiguracionCobrars)
                .HasForeignKey(d => d.CobrarId)
                .HasConstraintName("FK_NivelRecaudo_Configuracion_Dato6");

            entity.HasOne(d => d.Impuesto).WithMany(p => p.NivelRecaudoConfiguracionImpuestos)
                .HasForeignKey(d => d.ImpuestoId)
                .HasConstraintName("FK_NivelRecaudo_Configuracion_Dato5");

            entity.HasOne(d => d.Operacion).WithMany(p => p.NivelRecaudoConfiguracions)
                .HasForeignKey(d => d.OperacionId)
                .HasConstraintName("FK_NivelRecaudo_Configuracion_Operacion");

            entity.HasOne(d => d.Recaudo).WithMany(p => p.NivelRecaudoConfiguracions)
                .HasForeignKey(d => d.RecaudoId)
                .HasConstraintName("FK_NivelRecaudo_Configuracion_NivelRecaudo");

            entity.HasOne(d => d.Redondeo).WithMany(p => p.NivelRecaudoConfiguracionRedondeos)
                .HasForeignKey(d => d.RedondeoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NivelRecaudo_Configuracion_Dato3");

            entity.HasOne(d => d.TipoCobro).WithMany(p => p.NivelRecaudoConfiguracionTipoCobros)
                .HasForeignKey(d => d.TipoCobroId)
                .HasConstraintName("FK_NivelRecaudo_Configuracion_Dato2");

            entity.HasOne(d => d.TipoRecaudo).WithMany(p => p.NivelRecaudoConfiguracionTipoRecaudos)
                .HasForeignKey(d => d.TipoRecaudoId)
                .HasConstraintName("FK_NivelRecaudo_Configuracion_Dato1");

            entity.HasOne(d => d.TipoUsuario).WithMany(p => p.NivelRecaudoConfiguracionTipoUsuarios)
                .HasForeignKey(d => d.TipoUsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NivelRecaudo_Configuracion_Dato");

            entity.HasOne(d => d.UnidadRedondeo).WithMany(p => p.NivelRecaudoConfiguracionUnidadRedondeos)
                .HasForeignKey(d => d.UnidadRedondeoId)
                .HasConstraintName("FK_NivelRecaudo_Configuracion_Dato4");

            entity.HasOne(d => d.User).WithMany(p => p.NivelRecaudoConfiguracions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_NivelRecaudo_Configuracion_User");
        });

        modelBuilder.Entity<NivelRecaudoConfiguracionProcedimiento>(entity =>
        {
            entity.ToTable("NivelRecaudo_Configuracion_Procedimiento", "Configuracion");

            entity.Property(e => e.EsCobroValor).HasColumnName("Es_cobro_Valor");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Valor).HasColumnType("money");

            entity.HasOne(d => d.Ambito).WithMany(p => p.NivelRecaudoConfiguracionProcedimientoAmbitos)
                .HasForeignKey(d => d.AmbitoId)
                .HasConstraintName("FK_NivelRecaudo_Configuracion_Procedimiento_Dato1");

            entity.HasOne(d => d.NivelRecaudoConfig).WithMany(p => p.NivelRecaudoConfiguracionProcedimientos)
                .HasForeignKey(d => d.NivelRecaudoConfigId)
                .HasConstraintName("FK_NivelRecaudo_Configuracion_Procedimiento_NivelRecaudo_Configuracion");

            entity.HasOne(d => d.TipoProcedimiento).WithMany(p => p.NivelRecaudoConfiguracionProcedimientoTipoProcedimientos)
                .HasForeignKey(d => d.TipoProcedimientoId)
                .HasConstraintName("FK_NivelRecaudo_Configuracion_Procedimiento_Dato");

            entity.HasOne(d => d.Usuario).WithMany(p => p.NivelRecaudoConfiguracionProcedimientos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_NivelRecaudo_Configuracion_Procedimiento_User");
        });

        modelBuilder.Entity<NivelRecaudoConfiguracionTipo>(entity =>
        {
            entity.ToTable("NivelRecaudo_Configuracion_Tipo", "Configuracion");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.HasOne(d => d.NivelRecaudoConfig).WithMany(p => p.NivelRecaudoConfiguracionTipos)
                .HasForeignKey(d => d.NivelRecaudoConfigId)
                .HasConstraintName("FK_NivelRecaudo_Configuracion_Tipo_NivelRecaudo_Configuracion");

            entity.HasOne(d => d.TipoRecaudo).WithMany(p => p.NivelRecaudoConfiguracionTipos)
                .HasForeignKey(d => d.TipoRecaudoId)
                .HasConstraintName("FK_NivelRecaudo_Configuracion_Tipo_Dato");

            entity.HasOne(d => d.Usuario).WithMany(p => p.NivelRecaudoConfiguracionTipos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_NivelRecaudo_Configuracion_Tipo_User");
        });

        modelBuilder.Entity<NivelSede>(entity =>
        {
            entity.ToTable("NivelSede", "Configuracion");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.HasOne(d => d.Nivel).WithMany(p => p.NivelSedes)
                .HasForeignKey(d => d.NivelId)
                .HasConstraintName("FK_NivelSede_Dato");

            entity.HasOne(d => d.Sede).WithMany(p => p.NivelSedes)
                .HasForeignKey(d => d.SedeId)
                .HasConstraintName("FK_NivelSede_Sede");
        });

        modelBuilder.Entity<Operacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TP_DATOS_EMPRESA");

            entity.ToTable("Operacion", "Configuracion");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CodigoPrestador)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.LogoOperacion).HasColumnType("image");
            entity.Property(e => e.NombreEmpresa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_Empresa");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.ToTable("Paciente", "Configuracion");

            entity.Property(e => e.CasoEspecial)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Documento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FactorRhid).HasColumnName("FactorRHId");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RiesgoJuridico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SegundoNombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Clasificacion).WithMany(p => p.PacienteClasificacions)
                .HasForeignKey(d => d.ClasificacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Paciente_Dato6");

            entity.HasOne(d => d.Discapacidad).WithMany(p => p.PacienteDiscapacidads)
                .HasForeignKey(d => d.DiscapacidadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Paciente_Dato7");

            entity.HasOne(d => d.DocumentoNavigation).WithMany(p => p.PacienteDocumentoNavigations)
                .HasForeignKey(d => d.DocumentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Paciente_Dato");

            entity.HasOne(d => d.EstadoCivil).WithMany(p => p.PacienteEstadoCivils)
                .HasForeignKey(d => d.EstadoCivilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Paciente_Dato9");

            entity.HasOne(d => d.Etnia).WithMany(p => p.PacienteEtnia)
                .HasForeignKey(d => d.EtniaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Paciente_Dato10");

            entity.HasOne(d => d.FactorRh).WithMany(p => p.PacienteFactorRhs)
                .HasForeignKey(d => d.FactorRhid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Paciente_Dato3");

            entity.HasOne(d => d.Genero).WithMany(p => p.PacienteGeneros)
                .HasForeignKey(d => d.GeneroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Paciente_Dato1");

            entity.HasOne(d => d.GradoDiscapacidad).WithMany(p => p.PacienteGradoDiscapacidads)
                .HasForeignKey(d => d.GradoDiscapacidadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Paciente_Dato8");

            entity.HasOne(d => d.GrupoSangre).WithMany(p => p.PacienteGrupoSangres)
                .HasForeignKey(d => d.GrupoSangreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Paciente_Dato2");

            entity.HasOne(d => d.Ocupacion).WithMany(p => p.PacienteOcupacions)
                .HasForeignKey(d => d.OcupacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Paciente_Dato4");

            entity.HasOne(d => d.Operacion).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.OperacionId)
                .HasConstraintName("FK_Paciente_Operacion");

            entity.HasOne(d => d.Profesion).WithMany(p => p.PacienteProfesions)
                .HasForeignKey(d => d.ProfesionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Paciente_Dato5");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_Paciente_User");
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TR_PAIS");

            entity.ToTable("Pais", "Configuracion");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .HasColumnName("CODIGO");
            entity.Property(e => e.CodigoArea).HasColumnName("CODIGO_AREA");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Gtm)
                .HasMaxLength(20)
                .HasColumnName("GTM");
            entity.Property(e => e.Pais)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("PAIS");
        });

        modelBuilder.Entity<PlanSalud>(entity =>
        {
            entity.ToTable("PlanSalud", "Configuracion");

            entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).IsUnicode(false);
            entity.Property(e => e.Observacion).IsUnicode(false);

            entity.HasOne(d => d.TipoPlan).WithMany(p => p.PlanSaluds)
                .HasForeignKey(d => d.TipoPlanId)
                .HasConstraintName("FK_PlanSalud_Dato");

            entity.HasOne(d => d.UsuarioActualizaNavigation).WithMany(p => p.PlanSaludUsuarioActualizaNavigations)
                .HasForeignKey(d => d.UsuarioActualiza)
                .HasConstraintName("FK_PlanSalud_User1");

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.PlanSaludUsuarioCreacionNavigations)
                .HasForeignKey(d => d.UsuarioCreacion)
                .HasConstraintName("FK_PlanSalud_User");
        });

        modelBuilder.Entity<PlanSaludProcedimiento>(entity =>
        {
            entity.ToTable("PlanSaludProcedimiento", "Configuracion");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.HasOne(d => d.PlanSalud).WithMany(p => p.PlanSaludProcedimientos)
                .HasForeignKey(d => d.PlanSaludId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlanSaludProcedimiento_PlanSalud");

            entity.HasOne(d => d.Procedimiento).WithMany(p => p.PlanSaludProcedimientos)
                .HasForeignKey(d => d.ProcedimientoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlanSaludProcedimiento_Procedimiento");
        });

        modelBuilder.Entity<Procedimiento>(entity =>
        {
            entity.ToTable("Procedimiento", "Configuracion");

            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CodigoServicio)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).IsUnicode(false);
            entity.Property(e => e.NombreAlterno).IsUnicode(false);

            entity.HasOne(d => d.AltoCostoNavigation).WithMany(p => p.ProcedimientoAltoCostoNavigations)
                .HasForeignKey(d => d.AltoCosto)
                .HasConstraintName("FK_Procedimiento_Dato4");

            entity.HasOne(d => d.ClaseRango).WithMany(p => p.ProcedimientoClaseRangos)
                .HasForeignKey(d => d.ClaseRangoId)
                .HasConstraintName("FK_Procedimiento_Dato2");

            entity.HasOne(d => d.Complejidad).WithMany(p => p.ProcedimientoComplejidads)
                .HasForeignKey(d => d.ComplejidadId)
                .HasConstraintName("FK_Procedimiento_Dato8");

            entity.HasOne(d => d.Concentimiento).WithMany(p => p.ProcedimientoConcentimientos)
                .HasForeignKey(d => d.ConcentimientoId)
                .HasConstraintName("FK_Procedimiento_Dato6");

            entity.HasOne(d => d.Concepto).WithMany(p => p.ProcedimientoConceptos)
                .HasForeignKey(d => d.ConceptoId)
                .HasConstraintName("FK_Procedimiento_Dato12");

            entity.HasOne(d => d.Edad).WithMany(p => p.ProcedimientoEdads)
                .HasForeignKey(d => d.EdadId)
                .HasConstraintName("FK_Procedimiento_Dato1");

            entity.HasOne(d => d.Extramural).WithMany(p => p.ProcedimientoExtramurals)
                .HasForeignKey(d => d.ExtramuralId)
                .HasConstraintName("FK_Procedimiento_Dato5");

            entity.HasOne(d => d.FinalidadProdedimiento).WithMany(p => p.ProcedimientoFinalidadProdedimientos)
                .HasForeignKey(d => d.FinalidadProdedimientoId)
                .HasConstraintName("FK_Procedimiento_Dato13");

            entity.HasOne(d => d.Genero).WithMany(p => p.ProcedimientoGeneros)
                .HasForeignKey(d => d.GeneroId)
                .HasConstraintName("FK_Procedimiento_Dato");

            entity.HasOne(d => d.NivelAtencion).WithMany(p => p.ProcedimientoNivelAtencions)
                .HasForeignKey(d => d.NivelAtencionId)
                .HasConstraintName("FK_Procedimiento_Dato7");

            entity.HasOne(d => d.NivelAutorizacion).WithMany(p => p.ProcedimientoNivelAutorizacions)
                .HasForeignKey(d => d.NivelAutorizacionId)
                .HasConstraintName("FK_Procedimiento_Dato11");

            entity.HasOne(d => d.Paquete).WithMany(p => p.ProcedimientoPaquetes)
                .HasForeignKey(d => d.PaqueteId)
                .HasConstraintName("FK_Procedimiento_Dato9");

            entity.HasOne(d => d.Pos).WithMany(p => p.ProcedimientoPos)
                .HasForeignKey(d => d.PosId)
                .HasConstraintName("FK_Procedimiento_Dato3");

            entity.HasOne(d => d.TipoProcedimiento).WithMany(p => p.ProcedimientoTipoProcedimientos)
                .HasForeignKey(d => d.TipoProcedimientoId)
                .HasConstraintName("FK_Procedimiento_Dato10");

            entity.HasOne(d => d.UsuarioActualizaNavigation).WithMany(p => p.ProcedimientoUsuarioActualizaNavigations)
                .HasForeignKey(d => d.UsuarioActualiza)
                .HasConstraintName("FK_Procedimiento_User1");

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.ProcedimientoUsuarioCreacionNavigations)
                .HasForeignKey(d => d.UsuarioCreacion)
                .HasConstraintName("FK_Procedimiento_User");
        });

        modelBuilder.Entity<Profesional>(entity =>
        {
            entity.ToTable("Profesional", "Configuracion");

            entity.Property(e => e.CantidadCitaExtra)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.CantidadCitaExtraMin)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreate).HasColumnType("datetime");
            entity.Property(e => e.FechaFinal).HasColumnType("date");
            entity.Property(e => e.FechaInicial).HasColumnType("date");
            entity.Property(e => e.FechaUpdate).HasColumnType("datetime");
            entity.Property(e => e.NumeroRegistro)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.SociedadMedica)
                .HasMaxLength(3000)
                .IsUnicode(false);

            entity.HasOne(d => d.Cargo).WithMany(p => p.ProfesionalCargos)
                .HasForeignKey(d => d.CargoId)
                .HasConstraintName("FK_Profesional_Dato4");

            entity.HasOne(d => d.ClasePrestador).WithMany(p => p.ProfesionalClasePrestadors)
                .HasForeignKey(d => d.ClasePrestadorId)
                .HasConstraintName("FK_Profesional_Dato1");

            entity.HasOne(d => d.Clasificacion).WithMany(p => p.ProfesionalClasificacions)
                .HasForeignKey(d => d.ClasificacionId)
                .HasConstraintName("FK_Profesional_Dato3");

            entity.HasOne(d => d.EntidadldNavigation).WithMany(p => p.Profesionals)
                .HasForeignKey(d => d.Entidadld)
                .HasConstraintName("FK_Profesional_Entidad");

            entity.HasOne(d => d.Operacion).WithMany(p => p.Profesionals)
                .HasForeignKey(d => d.OperacionId)
                .HasConstraintName("FK_Profesional_Operacion");

            entity.HasOne(d => d.TipoProfesional).WithMany(p => p.ProfesionalTipoProfesionals)
                .HasForeignKey(d => d.TipoProfesionalId)
                .HasConstraintName("FK_Profesional_Dato2");

            entity.HasOne(d => d.TipoVinculacion).WithMany(p => p.ProfesionalTipoVinculacions)
                .HasForeignKey(d => d.TipoVinculacionId)
                .HasConstraintName("FK_Profesional_Dato");

            entity.HasOne(d => d.User).WithMany(p => p.Profesionals)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Profesional_User");
        });

        modelBuilder.Entity<ProfesionalEspecialidad>(entity =>
        {
            entity.ToTable("ProfesionalEspecialidad", "Configuracion");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.HasOne(d => d.Especialidad).WithMany(p => p.ProfesionalEspecialidads)
                .HasForeignKey(d => d.EspecialidadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProfesionalEspecialidad_Especialidad");

            entity.HasOne(d => d.Profesional).WithMany(p => p.ProfesionalEspecialidads)
                .HasForeignKey(d => d.ProfesionalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProfesionalEspecialidad_Profesional");
        });

        modelBuilder.Entity<ResolucionAutoretenedor>(entity =>
        {
            entity.ToTable("ResolucionAutoretenedor", "Configuracion");

            entity.Property(e => e.Nombre)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.Ips).WithMany(p => p.ResolucionAutoretenedors)
                .HasForeignKey(d => d.IpsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResolucionAutoretenedor_Ips");

            entity.HasOne(d => d.Resolucion).WithMany(p => p.ResolucionAutoretenedors)
                .HasForeignKey(d => d.ResolucionId)
                .HasConstraintName("FK_ResolucionAutoretenedor_Dato");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Roles");

            entity.ToTable("Rol", "Seguridad");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RolUser>(entity =>
        {
            entity.ToTable("RolUser", "Seguridad");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.HasOne(d => d.Rol).WithMany(p => p.RolUsers)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolUser_Rol");

            entity.HasOne(d => d.Usuario).WithMany(p => p.RolUsers)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolUser_User");
        });

        modelBuilder.Entity<Sede>(entity =>
        {
            entity.ToTable("Sede", "Configuracion");

            entity.Property(e => e.CodigoPrestador)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FechaVigencia).HasColumnType("datetime");
            entity.Property(e => e.Logo).HasColumnType("image");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Operacion).WithMany(p => p.Sedes)
                .HasForeignKey(d => d.OperacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sede_Operacion");

            entity.HasOne(d => d.TipoSedeNavigation).WithMany(p => p.Sedes)
                .HasForeignKey(d => d.TipoSede)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sede_Dato");

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.SedeUsuarioCreacionNavigations)
                .HasForeignKey(d => d.UsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sede_User");

            entity.HasOne(d => d.UsuarioModificacionNavigation).WithMany(p => p.SedeUsuarioModificacionNavigations)
                .HasForeignKey(d => d.UsuarioModificacion)
                .HasConstraintName("FK_Sede_User1");
        });

        modelBuilder.Entity<Tabla>(entity =>
        {
            entity.ToTable("Tabla", "Configuracion");

            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tarifa>(entity =>
        {
            entity.ToTable("Tarifa", "Configuracion");

            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).IsUnicode(false);
            entity.Property(e => e.Observacion).IsUnicode(false);

            entity.HasOne(d => d.UsuarioActualizaNavigation).WithMany(p => p.TarifaUsuarioActualizaNavigations)
                .HasForeignKey(d => d.UsuarioActualiza)
                .HasConstraintName("FK_Tarifa_User1");

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.TarifaUsuarioCreacionNavigations)
                .HasForeignKey(d => d.UsuarioCreacion)
                .HasConstraintName("FK_Tarifa_User");
        });

        modelBuilder.Entity<TarifaVigenciaConfiguracion>(entity =>
        {
            entity.ToTable("Tarifa_Vigencia_Configuracion", "Configuracion");

            entity.Property(e => e.ConImpuesto).HasColumnName("Con_Impuesto");
            entity.Property(e => e.FechaCreate).HasColumnType("datetime");
            entity.Property(e => e.FechaUpdate).HasColumnType("datetime");
            entity.Property(e => e.GrupoQxid).HasColumnName("GrupoQXId");
            entity.Property(e => e.Valor).HasColumnType("money");

            entity.HasOne(d => d.GrupoQx).WithMany(p => p.TarifaVigenciaConfiguracionGrupoQxes)
                .HasForeignKey(d => d.GrupoQxid)
                .HasConstraintName("FK_Tarifa_Vigencia_Configuracion_Dato1");

            entity.HasOne(d => d.Impuesto).WithMany(p => p.TarifaVigenciaConfiguracionImpuestos)
                .HasForeignKey(d => d.ImpuestoId)
                .HasConstraintName("FK_Tarifa_Vigencia_Configuracion_Dato2");

            entity.HasOne(d => d.Liquidacion).WithMany(p => p.TarifaVigenciaConfiguracionLiquidacions)
                .HasForeignKey(d => d.LiquidacionId)
                .HasConstraintName("FK_Tarifa_Vigencia_Configuracion_Dato");

            entity.HasOne(d => d.Operacion).WithMany(p => p.TarifaVigenciaConfiguracions)
                .HasForeignKey(d => d.OperacionId)
                .HasConstraintName("FK_Tarifa_Vigencia_Configuracion_Operacion");

            entity.HasOne(d => d.Procedimiento).WithMany(p => p.TarifaVigenciaConfiguracions)
                .HasForeignKey(d => d.ProcedimientoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tarifa_Vigencia_Configuracion_Procedimiento");

            entity.HasOne(d => d.User).WithMany(p => p.TarifaVigenciaConfiguracions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Tarifa_Vigencia_Configuracion_User");

            entity.HasOne(d => d.Vigencia).WithMany(p => p.TarifaVigenciaConfiguracions)
                .HasForeignKey(d => d.VigenciaId)
                .HasConstraintName("FK_Tarifa_Vigencia_Configuracion_Tarifa_Vigencia");
        });

        modelBuilder.Entity<TarifaVigencium>(entity =>
        {
            entity.ToTable("Tarifa_Vigencia", "Configuracion");

            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EsSmmlv).HasColumnName("Es_SMMLV");
            entity.Property(e => e.FechaAplicacion).HasColumnType("date");
            entity.Property(e => e.FechaCreate).HasColumnType("datetime");
            entity.Property(e => e.FechaUpdate).HasColumnType("datetime");

            entity.HasOne(d => d.Operacion).WithMany(p => p.TarifaVigencia)
                .HasForeignKey(d => d.OperacionId)
                .HasConstraintName("FK_Tarifa_Vigencia_Operacion");

            entity.HasOne(d => d.Tarifa).WithMany(p => p.TarifaVigencia)
                .HasForeignKey(d => d.TarifaId)
                .HasConstraintName("FK_Tarifa_Vigencia_Tarifa");

            entity.HasOne(d => d.User).WithMany(p => p.TarifaVigencia)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Tarifa_Vigencia_User");
        });

        modelBuilder.Entity<UbicacionSede>(entity =>
        {
            entity.ToTable("UbicacionSede", "Configuracion");

            entity.Property(e => e.Barrio)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Celular)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Responsable)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User", "Seguridad");

            entity.Property(e => e.FechaCreate).HasColumnType("datetime");
            entity.Property(e => e.FechaUpdate).HasColumnType("datetime");
            entity.Property(e => e.Firma).HasColumnType("image");
            entity.Property(e => e.Foto).HasColumnType("image");
            entity.Property(e => e.Password)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.EntidadldNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Entidadld)
                .HasConstraintName("FK_User_Entidad");

            entity.HasOne(d => d.Operacion).WithMany(p => p.Users)
                .HasForeignKey(d => d.OperacionId)
                .HasConstraintName("FK_User_Operacion");
        });

        modelBuilder.Entity<UserSede>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SedeUsuario");

            entity.ToTable("UserSede", "Seguridad");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.HasOne(d => d.Sede).WithMany(p => p.UserSedes)
                .HasForeignKey(d => d.SedeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserSede_Sede");

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.UserSedeUsuarioCreacionNavigations)
                .HasForeignKey(d => d.UsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserSede_User");

            entity.HasOne(d => d.UsuarioModificacionNavigation).WithMany(p => p.UserSedeUsuarioModificacionNavigations)
                .HasForeignKey(d => d.UsuarioModificacion)
                .HasConstraintName("FK_UserSede_User1");
        });

        modelBuilder.Entity<ZonaResidencial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TR_ZONA_RESIDENCIAL");

            entity.ToTable("ZonaResidencial", "Configuracion");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Codigo)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("CODIGO");
            entity.Property(e => e.ZonaResidencial1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ZONA_RESIDENCIAL");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
