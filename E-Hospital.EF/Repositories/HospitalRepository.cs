using E_Hospital.Data.Entity;
using E_Hospital.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Hospital.EF.Repositories
{
    public class HospitalRepository : IHospitalRepository
    {
        public void Create(Hospital hospital)
        {
            using (var context = new E_HospitalContext())
            {
                context.Hospitals.Add(hospital);
                context.SaveChanges();
            }
        }

        public void Delete(Hospital hospital)
        {
            using (var context = new E_HospitalContext())
            {
                context.Hospitals.Remove(hospital);
                context.SaveChanges();
            }
        }

        public Hospital Get(int id)
        {
            using (var context = new E_HospitalContext())
            {
                return context.Hospitals.FirstOrDefault(h => h.Id == id);
            }
        }

        public List<Hospital> GetHospitals()
        {
            using (var context = new E_HospitalContext())
            {
                return context.Hospitals.ToList();
            }
        }

        public void Update(Hospital hospital)
        {
            using (var context = new E_HospitalContext())
            {
                context.Hospitals.Attach(hospital);
                context.Entry(hospital).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
