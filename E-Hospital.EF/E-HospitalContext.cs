using E_Hospital.Data.Entity;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
