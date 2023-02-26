using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Task26_2.Models;

public partial class CoreTaskContext : DbContext
{
    public CoreTaskContext()
    {
    }

    public CoreTaskContext(DbContextOptions<CoreTaskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clinicc> Cliniccs { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)=> optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=CoreTask;Trusted_Connection=SSPI;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clinicc>(entity =>
        {
            entity.HasKey(e => e.ClinicId).HasName("PK__Cliniccs__C2691A361E3FFF1A");

            entity.Property(e => e.ClinicId).HasColumnName("Clinic_Id");
            entity.Property(e => e.ClinicName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Clinic_Name");
            entity.Property(e => e.Clinicimg)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("clinicimg");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__Doctors__E59B532FB1F94426");

            entity.Property(e => e.DoctorId).HasColumnName("Doctor_Id");
            entity.Property(e => e.ClinicId).HasColumnName("Clinic_Id");
            entity.Property(e => e.DoctorName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Doctor_Name");

            entity.HasOne(d => d.Clinic).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.ClinicId)
                .HasConstraintName("FK__Doctors__Clinic___3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
