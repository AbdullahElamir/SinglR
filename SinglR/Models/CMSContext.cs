using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Managegment.Models
{
    public partial class CMSContext : DbContext
    {
        public CMSContext()
        {
        }

        public CMSContext(DbContextOptions<CMSContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<CourseFiles> CourseFiles { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Packages> Packages { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<SuperPackages> SuperPackages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-PTGVLQG;Database=CMS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classes>(entity =>
            {
                entity.HasKey(e => e.ClassId);

                entity.Property(e => e.ClassName).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Teacher).HasMaxLength(150);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Companies>(entity =>
            {
                entity.HasKey(e => e.CompanyId);

                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.BoughtBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.City).HasMaxLength(150);

                entity.Property(e => e.Communicator)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName).HasMaxLength(250);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<CourseFiles>(entity =>
            {
                entity.HasKey(e => e.CourseFileId);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseFiles)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_CourseFiles_Courses");
            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.Property(e => e.Color).HasMaxLength(10);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.PriceCompany).HasColumnType("money");

                entity.Property(e => e.PricePersonal).HasColumnType("money");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("FK_Courses_Packages");

                entity.HasOne(d => d.SuperPackage)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.SuperPackageId)
                    .HasConstraintName("FK_Courses_SuperPackages");
            });

            modelBuilder.Entity<Packages>(entity =>
            {
                entity.HasKey(e => e.PackageId);

                entity.Property(e => e.Color)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.PriceCompany).HasColumnType("money");

                entity.Property(e => e.PricePersonal).HasColumnType("money");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.SuperPackage)
                    .WithMany(p => p.Packages)
                    .HasForeignKey(d => d.SuperPackageId)
                    .HasConstraintName("FK_Packages_SuperPackages");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CurrentJob)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.Location)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NameAr).HasMaxLength(150);

                entity.Property(e => e.NameEn).HasMaxLength(150);

                entity.Property(e => e.Nationality).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber1).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber2).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_Students_Companies");
            });

            modelBuilder.Entity<SuperPackages>(entity =>
            {
                entity.HasKey(e => e.SuperPackageId);

                entity.Property(e => e.Color).HasMaxLength(10);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.PriceCompany).HasColumnType("money");

                entity.Property(e => e.PricePersonal).HasColumnType("money");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });
        }
    }
}
