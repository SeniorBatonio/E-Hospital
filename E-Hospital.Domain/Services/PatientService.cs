using E_Hospital.Data.Entity;
using E_Hospital.Data.Repositories;
using E_Hospital.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Hospital.Domain.Services
{
    public class PatientService : IPatientService
    {
        private IPatientRepository _patientRepo;
        public PatientService(IPatientRepository patientRepo)
        {
            _patientRepo = patientRepo;
        }
        public Patient CreatePatient(string email, string name, string surname, DateTime birthday)
        {
            var newPatient = new Patient
            {
                Email = email,
                Name = name,
                Surname = surname,
                Birthday = birthday,
            };
            _patientRepo.Create(newPatient);
            return newPatient;
        }

        public bool IsPatientExist(string email)
        {
            return _patientRepo.GetPatients().Any(p => p.Email == email);
        }
    }
}
