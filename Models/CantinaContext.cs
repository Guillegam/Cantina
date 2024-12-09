using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cantina.Models;

public partial class CantinaContext : DbContext
{
    public CantinaContext()
    {
    }

    public CantinaContext(DbContextOptions<CantinaContext> options) : base(options)
    { 

    }
   
    public virtual DbSet<Credito> Creditos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<TiposConsumo> TiposConsumos { get; set; }

    public virtual DbSet<Turno> Turnos { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            //=> optionsBuilder.UseSqlServer("Server=localhost;Database=Cantina;Integrated Security=True;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

        modelBuilder.Entity<Credito>(entity =>
        {
            entity.HasKey(e => e.IdCredito).HasName("PK__Creditos__9AA34D3F56BD6E29");

            entity.Property(e => e.IdCredito).HasColumnName("Id_Credito");
            entity.Property(e => e.CreditosAsignados).HasColumnName("Creditos_Asignados");
            entity.Property(e => e.CreditosConsumidos).HasColumnName("Creditos_Consumidos");
            entity.Property(e => e.IdEmpleado).HasColumnName("Id_Empleado");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Creditos)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Creditos__Id_Emp__4222D4EF");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__74056223F0EDA407");

            entity.Property(e => e.IdEmpleado).HasColumnName("Id_Empleado");
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.IdTurno).HasColumnName("Id_Turno");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Puesto).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(15);

            entity.HasOne(d => d.IdTurnoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdTurno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Empleados__Id_Tu__3E52440B");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("PK__Menus__F6BCBF2E665C26CA");

            entity.Property(e => e.IdMenu).HasColumnName("Id_Menu");
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.NombreComida)
                .HasMaxLength(100)
                .HasColumnName("Nombre_Comida");
            entity.Property(e => e.TipoConsumo)
                .HasMaxLength(50)
                .HasColumnName("Tipo_Consumo");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK__Reservas__9E953BE124C41595");

            entity.Property(e => e.IdReserva).HasColumnName("Id_Reserva");
            entity.Property(e => e.ComidaSeleccionada)
                .HasMaxLength(100)
                .HasColumnName("Comida_Seleccionada");
            entity.Property(e => e.NombreEmpleado)
                .HasMaxLength(100)
                .HasColumnName("Nombre_Empleado");
            entity.Property(e => e.TipoConsumo)
                .HasMaxLength(50)
                .HasColumnName("Tipo_Consumo");

            entity.HasOne(d => d.TipoConsumoNavigation).WithMany(p => p.Reservas)
                .HasPrincipalKey(p => p.NombreConsumo)
                .HasForeignKey(d => d.TipoConsumo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservas__Tipo_C__44FF419A");
        });

        modelBuilder.Entity<TiposConsumo>(entity =>
        {
            entity.HasKey(e => e.IdConsumo).HasName("PK__TiposCon__EE83809A968326C5");

            entity.HasIndex(e => e.NombreConsumo, "UQ__TiposCon__5C85ED26B348EC6E").IsUnique();

            entity.Property(e => e.IdConsumo).HasColumnName("Id_Consumo");
            entity.Property(e => e.CreditosRequeridos).HasColumnName("Creditos_Requeridos");
            entity.Property(e => e.HorarioFin).HasColumnName("Horario_Fin");
            entity.Property(e => e.HorarioInicio).HasColumnName("Horario_Inicio");
            entity.Property(e => e.NombreConsumo)
                .HasMaxLength(50)
                .HasColumnName("Nombre_Consumo");
        });

        modelBuilder.Entity<Turno>(entity =>
        {
            entity.HasKey(e => e.IdTurno).HasName("PK__Turnos__5CF9003F812024F9");

            entity.Property(e => e.IdTurno).HasColumnName("Id_Turno");
            entity.Property(e => e.NombreTurno)
                .HasMaxLength(50)
                .HasColumnName("Nombre_Turno");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
