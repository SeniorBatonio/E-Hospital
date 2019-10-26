using System;
using System.Collections.Generic;
using System.Text;

namespace E_Hospital.Data.Entity
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int ReservationId { get; set; }
    }
}
