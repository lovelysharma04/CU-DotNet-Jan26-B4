using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebAPIdbFirst.Models;

namespace WebAPIdbFirst.Data;

public partial class MyAppDbContext : DbContext
{
    public MyAppDbContext()
    {
    }

    public MyAppDbContext(DbContextOptions<MyAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=TrialDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.Facultyid).HasName("PK__faculty__DBBE9399B364214B");

            entity.ToTable("faculty");

            entity.Property(e => e.Facultyid)
                .ValueGeneratedNever()
                .HasColumnName("facultyid");
            entity.Property(e => e.Facultyname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("facultyname");
            entity.Property(e => e.Subject)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("subject");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Studentid).HasName("PK__Student__4D16D264AAA913EA");

            entity.ToTable("Student");

            entity.Property(e => e.Studentid).HasColumnName("studentid");
            entity.Property(e => e.Class)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("class");
            entity.Property(e => e.Studentname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("studentname");

            entity.HasOne(d => d.FidNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.Fid)
                .HasConstraintName("FK__Student__Fid__5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
