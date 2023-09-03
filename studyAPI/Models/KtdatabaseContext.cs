using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace studyAPI.Models;

public partial class KtdatabaseContext : DbContext
{
    public KtdatabaseContext()
    {
    }

    public KtdatabaseContext(DbContextOptions<KtdatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CourseDetail> CourseDetails { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CourseDetail>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__COURSE_D__71CB31DBE424A1D0");

            entity.ToTable("COURSE_DETAILS");

            entity.Property(e => e.CourseId)
                .ValueGeneratedNever()
                .HasColumnName("COURSE_ID");
            entity.Property(e => e.CourseName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("COURSE_NAME");
            entity.Property(e => e.Duration)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DURATION");
            entity.Property(e => e.Mentor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MENTOR");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__STUDENTS__3214EC2708318937");

            entity.ToTable("STUDENTS");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Age).HasColumnName("AGE");
            entity.Property(e => e.CourseId).HasColumnName("COURSE_ID");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PHONE_NUMBER");

            entity.HasOne(d => d.Course).WithMany(p => p.Students)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__STUDENTS__COURSE__25869641");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
