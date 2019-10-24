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

        public int HospitalID { get; set; }
        public Hospital Hospital { get; set; }
    }
}
