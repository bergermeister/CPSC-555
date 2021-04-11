using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StDb2EFRP.Models
{
    public partial class StDb2SqlContext : DbContext
    {
        public StDb2SqlContext()
        {
        }

        public StDb2SqlContext(DbContextOptions<StDb2SqlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CoursesOffered> CoursesOffereds { get; set; }
        public virtual DbSet<CoursesTaken> CoursesTakens { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Prerequisite> Prerequisites { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VwCoursestaken> VwCoursestakens { get; set; }
        public virtual DbSet<VwGrade> VwGrades { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("server=DESKTOP-MBVR3E3\\CPSC555A03;Trusted_Connection=True;MultipleActiveResultSets=true;database=StDb2Sql;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseNum);

                entity.Property(e => e.CourseNum).HasMaxLength(50);

                entity.Property(e => e.CourseName).HasMaxLength(50);
            });

            modelBuilder.Entity<CoursesOffered>(entity =>
            {
                entity.HasKey(e => e.CourseNum);

                entity.ToTable("CoursesOffered");

                entity.Property(e => e.CourseNum).HasMaxLength(50);

                entity.HasOne(d => d.CourseNumNavigation)
                    .WithOne(p => p.CoursesOffered)
                    .HasForeignKey<CoursesOffered>(d => d.CourseNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CoursesOffered_Courses");
            });

            modelBuilder.Entity<CoursesTaken>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.CourseNum });

                entity.ToTable("CoursesTaken");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.CourseNum).HasMaxLength(50);

                entity.Property(e => e.Snum).HasColumnName("snum");

                entity.HasOne(d => d.CourseNumNavigation)
                    .WithMany(p => p.CoursesTakens)
                    .HasForeignKey(d => d.CourseNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CoursesTaken_Courses");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.CoursesTakens)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CoursesTaken_Students");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(e => new { e.CourseNum, e.StudentId });

                entity.ToTable("Enrollment");

                entity.Property(e => e.CourseNum).HasMaxLength(50);

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.Cnum).HasColumnName("CNum");

                entity.HasOne(d => d.CourseNumNavigation)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.CourseNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Enrollment_Courses");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Enrollment_Students");
            });

            modelBuilder.Entity<Prerequisite>(entity =>
            {
                entity.HasKey(e => new { e.CourseNum, e.PrereqCnum });

                entity.Property(e => e.CourseNum).HasMaxLength(50);

                entity.Property(e => e.PrereqCnum)
                    .HasMaxLength(50)
                    .HasColumnName("Prereq_Cnum");

                entity.Property(e => e.Cnum).HasColumnName("cnum");

                entity.HasOne(d => d.CourseNumNavigation)
                    .WithMany(p => p.PrerequisiteCourseNumNavigations)
                    .HasForeignKey(d => d.CourseNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prerequisites_Courses");

                entity.HasOne(d => d.PrereqCnumNavigation)
                    .WithMany(p => p.PrerequisitePrereqCnumNavigations)
                    .HasForeignKey(d => d.PrereqCnum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prerequisites_Courses1");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId)
                    .ValueGeneratedNever()
                    .HasColumnName("StudentID");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.Property(e => e.Major).HasMaxLength(4);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwCoursestaken>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_COURSESTAKEN");

                entity.Property(e => e.CourseNum).HasMaxLength(50);

                entity.Property(e => e.Snum).HasColumnName("snum");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");
            });

            modelBuilder.Entity<VwGrade>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_GRADES");

                entity.Property(e => e.Gpa).HasColumnName("GPA");

                entity.Property(e => e.MaxGrade).HasColumnName("MAX_GRADE");

                entity.Property(e => e.MinGrade).HasColumnName("MIN_GRADE");

                entity.Property(e => e.StudentId).HasColumnName("STudentID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
