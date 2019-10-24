using System;
using System.Collections.Generic;
using System.Text;

namespace E_Hospital.Data.Entity
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
