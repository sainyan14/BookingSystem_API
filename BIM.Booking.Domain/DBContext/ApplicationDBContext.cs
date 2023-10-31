using BIM.Booking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM.Booking.Domain.DBContext
{
    public class ApplicationDBContext : DbContext
    {
       

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options) { }

        public ApplicationDBContext() { }

        public virtual DbSet<Admin> Admin { get; set; }

        public virtual DbSet<Appointments> Appointments { get; set; }

        public virtual DbSet<Bookings> Bookings { get; set; }

        public virtual DbSet<Doctors> Doctors { get; set; }

        public virtual DbSet<IdentityRefreshToken> IdentityRefreshToken { get; set; }

        public virtual DbSet<IdentityUser> IdentityUser { get; set; }

        public virtual DbSet<Patients> Patients { get; set; }

        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<DoctorService> DoctorService { get; set; }

        public virtual DbSet<Hospital> Hospital { get; set; }

        public virtual DbSet<HospitalServices> HospitalServices { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>();

            modelBuilder.Entity<Appointments>();

            modelBuilder.Entity<Bookings>();

            modelBuilder.Entity<DoctorService>();

            modelBuilder.Entity<Doctors>();

            modelBuilder.Entity<IdentityRefreshToken>();

            modelBuilder.Entity<IdentityUser>();

            modelBuilder.Entity<Patients>();

            modelBuilder.Entity<Payments>();

            modelBuilder.Entity<Hospital>();

            modelBuilder.Entity<HospitalServices>();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        public static string ConnectionString = "";

        public static void SetConnectionString(string connectionString)
        {
            ConnectionString = connectionString;
        }

    }
}
