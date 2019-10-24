using E_Hospital.Data.Entity;
using E_Hospital.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Hospital.EF.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        public void Create(Patient patient)
        {
            using (var context = new E_HospitalContext())
            {
                context.Patients.Add(patient);
                context.SaveChanges();
            }
        }

        public void Delete(Patient patient)
        {
            using (var context = new E_HospitalContext())
            {
                context.Patients.Remove(patient);
                context.SaveChanges();
            }
        }

        public Patient Get(int id)
        {
            using (var context = new E_HospitalContext())
            {
                return context.Patients
                    .Include("MedHistory")
                    .Include("MedHistory.Diseases")
                    .Include("MedHistory.Diseases.Doctor")
                    .FirstOrDefault(p => p.Id == id);
            }
        }

        public List<Patient> GetPatients()
        {
            using (var context = new E_HospitalContext())
            {
                return context.Patients.ToList();
            }
        }

        public void Update(Patient patient)
        {
            using (var context = new E_HospitalContext())
            {
                context.Patients.Attach(patient);
                context.Entry(patient).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
