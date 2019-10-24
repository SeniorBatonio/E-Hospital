using System;
using System.Collections.Generic;
using System.Text;

namespace E_Hospital.Data.Entity
{
    public class Disease
    {
        public int Id { get; set; }
        public string Conclusion { get; set; }

        public int MedHistoryId { get; set; }
        public MedHistory MedHistory { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
