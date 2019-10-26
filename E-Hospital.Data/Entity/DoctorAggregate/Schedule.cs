using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Hospital.Data.Entity
{
    public class Schedule
    {
        public int Id { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime Date { get; set; }
        public List<DoctorAppointmentTime> DoctorAppointmentTimes { get; set; }
    }
}
