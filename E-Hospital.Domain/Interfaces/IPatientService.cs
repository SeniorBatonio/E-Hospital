using E_Hospital.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Hospital.Domain.Interfaces
{
    public interface IPatientService
    {
        bool IsPatientExist(string email);
        Patient CreatePatient(string email, string name, string surname, DateTime birthday);
    }
}
