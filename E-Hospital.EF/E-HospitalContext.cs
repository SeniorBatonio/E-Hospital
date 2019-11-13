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
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<AppointmentTime> AppointmentTimes{ get; set; }

        public E_HospitalContext() : base("E-HospitalContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Schedule>().HasMany(s => s.AppointmentTimes).WithRequired(t => t.Schedule);

            modelBuilder.ComplexType<VisitTime>();

            modelBuilder.Entity<Patient>();

            modelBuilder.Entity<Doctor>();

            modelBuilder.Entity<Hospital>();

            modelBuilder.Entity<Doctor>();

            modelBuilder.Entity<Reservation>();
        }
    }
}
