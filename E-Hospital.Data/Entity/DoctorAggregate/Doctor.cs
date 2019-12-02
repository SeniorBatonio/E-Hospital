using E_Hospital.Data.Entity.DoctorAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Hospital.Data.Entity
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Profession { get; set; }
        public List<int> SchedulesIds { get; set; }
        public int HospitalID { get; set; }
        public List<Shifts> Shifts { get; set; }

    }
}
