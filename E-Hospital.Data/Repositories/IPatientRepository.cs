using E_Hospital.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Hospital.Data.Repositories
{
    public interface IPatientRepository
    {
        void Create(Patient patient);
        void Update(Patient patient);
        void Delete(Patient patient);
        Patient Get(int id);
        List<Patient> GetPatients();
    }
}
