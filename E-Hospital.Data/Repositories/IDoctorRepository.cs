using E_Hospital.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Hospital.Data.Repositories
{
    public interface IDoctorRepository
    {
        void Create(Doctor doctor);
        void Update(Doctor doctor);
        void Delete(Doctor doctor);
        Doctor GetDoctorDetails(int id);
        List<Doctor> GetDoctors();
    }
}
