using E_Hospital.Data.Entity;
using E_Hospital.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Hospital.EF.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        public void Create(Doctor doctor)
        {
            using (var context = new E_HospitalContext())
            {
                context.Doctors.Add(doctor);
                context.SaveChanges();
            }
        }

        public void Delete(Doctor doctor)
        {
            using (var context = new E_HospitalContext())
            {
                context.Doctors.Remove(doctor);
                context.SaveChanges();
            }
        }

        public Doctor GetDoctorDetails(int id)
        {
            using (var context = new E_HospitalContext())
            {
                var d1 = context.Doctors.ToList();
                return context.Doctors
                    .Include("Hospital")
                    .FirstOrDefault(d => d.Id == id);
            }
        }

        public List<Doctor> GetDoctors()
        {
            using (var context = new E_HospitalContext())
            {
                return context.Doctors.ToList();
            }
        }

        public void Update(Doctor doctor)
        {
            using (var context = new E_HospitalContext())
            {
                context.Doctors.Attach(doctor);
                context.Entry(doctor).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
