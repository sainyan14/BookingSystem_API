﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BIM.Booking.Domain.Models;

public partial class BookingDBContext : DbContext
{
    public BookingDBContext(DbContextOptions<BookingDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admin { get; set; }

    public virtual DbSet<Appointments> Appointments { get; set; }

    public virtual DbSet<Bookings> Bookings { get; set; }

    public virtual DbSet<DoctorService> DoctorService { get; set; }

    public virtual DbSet<Doctors> Doctors { get; set; }

    public virtual DbSet<Hospital> Hospital { get; set; }

    public virtual DbSet<HospitalServices> HospitalServices { get; set; }

    public virtual DbSet<IdentityRefreshToken> IdentityRefreshToken { get; set; }

    public virtual DbSet<IdentityUser> IdentityUser { get; set; }

    public virtual DbSet<Patients> Patients { get; set; }

    public virtual DbSet<Payments> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__719FE488C9CAAAA6");

            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.IdentityUser).WithMany(p => p.Admin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Admin__Identity___5FB337D6");
        });

        modelBuilder.Entity<Appointments>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCC2AB8DD0F5");

            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__Docto__787EE5A0");
        });

        modelBuilder.Entity<Bookings>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Bookings__73951AED6FDD8515");

            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Bookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bookings__Doctor__72C60C4A");

            //entity.HasOne(d => d.Hospital).WithMany(p => p.Bookings)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK__Bookings__Hospit__71D1E811");

            entity.HasOne(d => d.Patient).WithMany(p => p.Bookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bookings__Patien__73BA3083");

            entity.HasOne(d => d.Payment).WithMany(p => p.Bookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bookings__Paymen__75A278F5");

            entity.HasOne(d => d.Service).WithMany(p => p.Bookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bookings__Servic__74AE54BC");
        });

        modelBuilder.Entity<DoctorService>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Services__C51BB00A7007F079");

            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<Doctors>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__Doctors__2DC00EBFC3018743");

            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

            //entity.HasOne(d => d.Hospital).WithMany(p => p.Doctors)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK__Doctors__Hospita__6D0D32F4");

            entity.HasOne(d => d.Service).WithMany(p => p.Doctors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Doctors__Service__6C190EBB");
        });

        modelBuilder.Entity<Hospital>(entity =>
        {
            entity.HasKey(e => e.HospitalId).HasName("PK__Hospital__38C2E5AF226BF671");

            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<HospitalServices>(entity =>
        {
            entity.HasKey(e => e.HospitalServiceId).HasName("PK__Hospital__FF7C58B47CC9D5FD");

            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Hospital).WithMany(p => p.HospitalServices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Hospital___Hospi__29221CFB");
        });

        modelBuilder.Entity<IdentityRefreshToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Identity__3214EC07F72A96E0");

            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.User).WithMany(p => p.IdentityRefreshToken)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__IdentityR__UserI__5CD6CB2B");
        });

        modelBuilder.Entity<IdentityUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Identity__1788CC4C64C1631C");

            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<Patients>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patients__970EC3665C6FE00D");

            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.User).WithMany(p => p.Patients)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Patients__UserId__6477ECF3");
        });

        modelBuilder.Entity<Payments>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A380335D45E");

            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}