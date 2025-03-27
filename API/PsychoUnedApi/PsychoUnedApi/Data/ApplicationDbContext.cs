using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PsychoUnedApi.Models;

namespace PsychoUnedApi.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<ExamsQuestion> ExamsQuestions { get; set; }

    public virtual DbSet<ExamsQuestionsAnswer> ExamsQuestionsAnswers { get; set; }

    public virtual DbSet<Pec> Pecs { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SubjectTopic> SubjectTopics { get; set; }

    public virtual DbSet<SubjectsNote> SubjectsNotes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\cursoSQL;Database=UnedPsycho;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exam>(entity =>
        {
            entity.ToTable("exams");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdSubject).HasColumnName("id_subject");
            entity.Property(e => e.Semestre).HasColumnName("semestre");
            entity.Property(e => e.Type)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("type");
            entity.Property(e => e.Week)
                .HasDefaultValue(1)
                .HasColumnName("week");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.IdSubjectNavigation).WithMany(p => p.Exams)
                .HasForeignKey(d => d.IdSubject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_exams_subjects");
        });

        modelBuilder.Entity<ExamsQuestion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Preguntas2");

            entity.ToTable("exams_questions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Correction)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("correction");
            entity.Property(e => e.IdExam).HasColumnName("id_exam");
            entity.Property(e => e.IdSubjects).HasColumnName("id_subjects");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Question)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("question");
            entity.Property(e => e.Topic).HasColumnName("topic");

            entity.HasOne(d => d.IdExamNavigation).WithMany(p => p.ExamsQuestions)
                .HasForeignKey(d => d.IdExam)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_exams_questions_exams");

            entity.HasOne(d => d.IdSubjectsNavigation).WithMany(p => p.ExamsQuestions)
                .HasForeignKey(d => d.IdSubjects)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_exams_questions_subjects");
        });

        modelBuilder.Entity<ExamsQuestionsAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Respuest__3213E83F369D3250");

            entity.ToTable("exams_questions_answers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Answer)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("answer");
            entity.Property(e => e.Correct).HasColumnName("correct");
            entity.Property(e => e.IdQuestion).HasColumnName("id_question");

            entity.HasOne(d => d.IdQuestionNavigation).WithMany(p => p.ExamsQuestionsAnswers)
                .HasForeignKey(d => d.IdQuestion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_exams_questions_answers_exams_questions");
        });

        modelBuilder.Entity<Pec>(entity =>
        {
            entity.ToTable("PECs");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IdSubjects).HasColumnName("id_subjects");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Asignaturas2");

            entity.ToTable("subjects");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Annual).HasColumnName("annual");
            entity.Property(e => e.Course).HasColumnName("course");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Semester).HasColumnName("semester");
        });

        modelBuilder.Entity<SubjectTopic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Temas");

            entity.ToTable("subject_topics");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdSubject).HasColumnName("id_subject");

            entity.HasOne(d => d.IdSubjectNavigation).WithMany(p => p.SubjectTopics)
                .HasForeignKey(d => d.IdSubject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_subject_topics_subjects");
        });

        modelBuilder.Entity<SubjectsNote>(entity =>
        {
            entity.ToTable("subjects_notes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdSubject).HasColumnName("id_subject");
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("link");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Topic).HasColumnName("topic");

            entity.HasOne(d => d.IdSubjectNavigation).WithMany(p => p.SubjectsNotes)
                .HasForeignKey(d => d.IdSubject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_subjects_notes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
