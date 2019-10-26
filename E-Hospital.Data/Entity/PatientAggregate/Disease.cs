using System;
using System.Collections.Generic;
using System.Text;

namespace E_Hospital.Data.Entity
{
    public class Disease
    {
        public int Id { get; set; }
        public string Conclusion { get; set; }
        public virtual MedHistory MedHistory { get; set; }
        public int DoctorID { get; set; }
    }
}
