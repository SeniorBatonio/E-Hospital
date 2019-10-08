using E_Hospital.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Hospital.Data.Repositories
{
    public interface IHospitalRepository
    {
        void Create(Hospital hospital);
        void Update(Hospital hospital);
        void Delete(Hospital hospital);
        Hospital Get(int id);
        List<Hospital> GetHospitals();
    }
}
