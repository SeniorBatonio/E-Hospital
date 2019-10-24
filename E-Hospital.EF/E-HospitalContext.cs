using E_Hospital.Data.Entity;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace E_Hospital.EF
{
    public class E_HospitalContext : DbContext
    {
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<MedHistory> MedHistories { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public E_HospitalContext() : base("E-HospitalContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Patient>().HasRequired(p => p.MedHistory).WithRequiredPrincipal(m => m.Patient);

            modelBuilder.Entity<MedHistory>().HasMany(m => m.Diseases).WithRequired(d => d.MedHistory);

            modelBuilder.Entity<Disease>().HasRequired(d=>d.Doctor);

            modelBuilder.Entity<Hospital>();

            modelBuilder.Entity<Doctor>();

            modelBuilder.Entity<Appointment>();
        }
    }
}
