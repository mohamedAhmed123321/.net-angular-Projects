using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Domains;
using System.Runtime;
using Microsoft.AspNetCore.Identity;

namespace Bl
{

    public partial class CoursesContext : IdentityDbContext<ApplicationUser>
    {
        public CoursesContext()
        {
        }

        public CoursesContext(DbContextOptions<CoursesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCourse> TbCourses { get; set; }

        public virtual DbSet<TbCourseType> TbCourseTypes { get; set; }

        public virtual DbSet<TbCustomer> TbCustomers { get; set; }

        public virtual DbSet<TbCustomerCourse> TbCustomerCourses { get; set; }

        public virtual DbSet<TbFeature> TbFeatures { get; set; }

        public virtual DbSet<TbInstructor> TbInstructors { get; set; }

        public virtual DbSet<TbPaymentMethod> TbPaymentMethods { get; set; }
        public virtual DbSet<Details> vwdetails { get; set; }
        public virtual DbSet<VwCustomerCourses> VwCoustomersCourses { get; set; }
        public virtual DbSet<TableSetting> TbSettings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TbCourse>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.ToTable("TbCourse");

                entity.Property(e => e.BookingPrice).HasColumnType("decimal(8, 4)");
                entity.Property(e => e.CourseName).HasMaxLength(200);
                entity.Property(e => e.ImageName).HasMaxLength(200);
                entity.Property(e => e.InstructorId).HasColumnName("instructorId");
                entity.Property(e => e.Lectures).HasMaxLength(200);
                entity.Property(e => e.Minute)
                    .HasMaxLength(200)
                    .HasColumnName("minute");
                entity.Property(e => e.Price).HasColumnType("decimal(8, 4)");
                entity.Property(e => e.SkillLevel).HasMaxLength(200);
                entity.Property(e => e.Time).HasMaxLength(200);
                entity.Property(e => e.Video).HasMaxLength(200);

                entity.HasOne(d => d.CourseType).WithMany(p => p.TbCourses)
                    .HasForeignKey(d => d.CourseTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbCourse_TbCourseType");

                entity.HasOne(d => d.Instructor).WithMany(p => p.TbCourses)
                    .HasForeignKey(d => d.InstructorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbCourse_TbInstructor");
            });

            modelBuilder.Entity<TbCourseType>(entity =>
            {
                entity.HasKey(e => e.CourseTypeId);

                entity.ToTable("TbCourseType");

                entity.Property(e => e.CourseTypeName).HasMaxLength(200);
            });

            modelBuilder.Entity<TbCustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("TbCustomer");

                entity.Property(e => e.CustomerName).HasMaxLength(300);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<TbCustomerCourse>(entity =>
            {
                entity.HasKey(e => e.CustomerCourseId);

                entity.Property(e => e.PaymentValue).HasColumnType("decimal(8, 4)");

                entity.HasOne(d => d.Course).WithMany(p => p.TbCustomerCourses)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbCustomerCourses_TbCourse");

                entity.HasOne(d => d.CourseNavigation).WithMany(p => p.TbCustomerCourses)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbCustomerCourses_TbCustomer");

                entity.HasOne(d => d.PaymentMethod).WithMany(p => p.TbCustomerCourses)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .HasConstraintName("FK_TbCustomerCourses_TbPaymentMethod");
            });

            modelBuilder.Entity<TbFeature>(entity =>
            {
                entity.HasKey(e => e.Featuresd);

                entity.Property(e => e.FeatureName).HasMaxLength(1000);

                entity.HasOne(d => d.Cousre).WithMany(p => p.TbFeatures)
                    .HasForeignKey(d => d.CousreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbFeatures_TbCourse");
            });

            modelBuilder.Entity<TbInstructor>(entity =>
            {
                entity.HasKey(e => e.InstructorId);

                entity.ToTable("TbInstructor");

                entity.Property(e => e.InstructorName).HasMaxLength(1000);
            });

            modelBuilder.Entity<TbPaymentMethod>(entity =>
            {
                entity.HasKey(e => e.PaymentMethodId);

                entity.ToTable("TbPaymentMethod");

                entity.Property(e => e.PaymentMethodId).ValueGeneratedNever();
                entity.Property(e => e.PaymentMethodName).HasMaxLength(200);
            });

            modelBuilder.Entity<Details>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<VwCustomerCourses>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("VwCoustomersCourses");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}