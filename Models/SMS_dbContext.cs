using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace test_angular.Models
{
    public partial class SMS_dbContext : DbContext
    {
        public virtual DbSet<Dept> Dept { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }

        public SMS_dbContext(DbContextOptions<SMS_dbContext> options) 
            :base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
           
            //optionsBuilder.UseSqlServer(@"Server=corei5-pc;Database=SMS_db;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(@"Server = tcp:faizan.database.windows.net, 1433; Initial Catalog = server2; Persist Security Info = False; User ID = anchro28; Password = Mobile786!; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dept>(entity =>
            {
                entity.ToTable("dept");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DeptName)
                    .HasColumnName("dept_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Teachers>(entity =>
            {
                entity.ToTable("teachers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DeptId).HasColumnName("dept_id");

                entity.Property(e => e.TeacherName)
                    .HasColumnName("teacher_name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.DeptId)
                    .HasConstraintName("FK_teachers_dept");
            });
        }
    }
}