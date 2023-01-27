using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Labb3_V._2.Models
{
    public partial class SchoolDbContext : DbContext
    {
        public SchoolDbContext()
        {
        }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Personel> Personels { get; set; }
        public virtual DbSet<RoleList> RoleLists { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-C2ANJQD\\MSSQLSERVER01;Initial Catalog = The School;Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Class1)
                    .HasMaxLength(10)
                    .HasColumnName("Class")
                    .IsFixedLength();

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.HasOne(d => d.ClassNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_Classes_Students");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasKey(e => e.GradesId);

                entity.Property(e => e.GradesId)
                    .ValueGeneratedNever()
                    .HasColumnName("GradesID");

                entity.Property(e => e.English)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GradeDate).HasColumnType("date");

                entity.Property(e => e.GradingTeacher).HasColumnName("Grading Teacher");

                entity.Property(e => e.History)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Maths)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Grades)
                    .WithOne(p => p.Grade)
                    .HasForeignKey<Grade>(d => d.GradesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grades_Students");

                entity.HasOne(d => d.GradingTeacherNavigation)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.GradingTeacher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grades_Personel");
            });

            modelBuilder.Entity<Personel>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK_Personel_1");

                entity.ToTable("Personel");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.EmployeeRoleNavigation)
                    .WithMany(p => p.Personels)
                    .HasForeignKey(d => d.EmployeeRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Personel_RoleList");
            });

            modelBuilder.Entity<RoleList>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("RoleList");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("Role ID");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId)
                    .ValueGeneratedNever()
                    .HasColumnName("StudentID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PersonalNumber)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
