using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PsychoUnedApi.Models;

public partial class MiDbContext : DbContext
{
    public MiDbContext()
    {
    }

    public MiDbContext(DbContextOptions<MiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AsignaturaPecs> AsignaturaPecs { get; set; }

    public virtual DbSet<Asignaturas> Asignaturas { get; set; }

    public virtual DbSet<AsignaturasTemas> AsignaturasTemas { get; set; }

    public virtual DbSet<Examenes> Examenes { get; set; }

    public virtual DbSet<ExamenesPreguntasRespuestas> ExamenesPreguntasRespuestas { get; set; }

    public virtual DbSet<Pecs> Pecs { get; set; }

    public virtual DbSet<Preguntas> Preguntas { get; set; }

    public virtual DbSet<Respuestas> Respuestas { get; set; }

    public virtual DbSet<Temas> Temas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\cursoSQL;Database=UnedPsycho;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AsignaturaPecs>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Asignatura_Pecs");

            entity.Property(e => e.IdAsignatura).HasColumnName("idAsignatura");
            entity.Property(e => e.IdPec).HasColumnName("idPec");
            entity.Property(e => e.NombrePec)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre_pec");
        });

        modelBuilder.Entity<Asignaturas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Asignaturas2");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Anual).HasColumnName("anual");
            entity.Property(e => e.Curso).HasColumnName("curso");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.NTemas).HasColumnName("nTemas");
            entity.Property(e => e.Semestre).HasColumnName("semestre");
        });

        modelBuilder.Entity<AsignaturasTemas>(entity =>
        {
            entity.HasKey(e => new { e.IdAsignatura, e.IdTema });

            entity.ToTable("Asignaturas_Temas");

            entity.Property(e => e.IdAsignatura).HasColumnName("idAsignatura");
            entity.Property(e => e.IdTema).HasColumnName("idTema");
            entity.Property(e => e.NombreTema)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre_tema");
            entity.Property(e => e.Semestre).HasColumnName("semestre");
        });

        modelBuilder.Entity<Examenes>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Ano).HasColumnName("ano");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.IdAsignatura).HasColumnName("idAsignatura");
            entity.Property(e => e.Semana)
                .HasDefaultValue(1)
                .HasColumnName("semana");
            entity.Property(e => e.Semestre).HasColumnName("semestre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<ExamenesPreguntasRespuestas>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ExamenesPreguntasRespuestas");

            entity.Property(e => e.Ano).HasColumnName("ano");
            entity.Property(e => e.Correcta).HasColumnName("correcta");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Pregunta)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("pregunta");
            entity.Property(e => e.Respuesta)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("respuesta");
        });

        modelBuilder.Entity<Pecs>(entity =>
        {
            entity.ToTable("PECs");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Preguntas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Preguntas2");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Correccion)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("correccion");
            entity.Property(e => e.IdExamen).HasColumnName("idExamen");
            entity.Property(e => e.Imagen).HasColumnName("imagen");
            entity.Property(e => e.Pregunta)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("pregunta");
            entity.Property(e => e.Tema).HasColumnName("tema");
        });

        modelBuilder.Entity<Respuestas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Respuest__3213E83F369D3250");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Correcta).HasColumnName("correcta");
            entity.Property(e => e.IdPregunta).HasColumnName("idPregunta");
            entity.Property(e => e.Respuesta)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("respuesta");
        });

        modelBuilder.Entity<Temas>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
