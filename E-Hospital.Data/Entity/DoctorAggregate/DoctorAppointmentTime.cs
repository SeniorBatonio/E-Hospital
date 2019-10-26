using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Hospital.Data.Entity
{
    public class DoctorAppointmentTime
    {
        public int Id { get; set; }
        public DateTime AppointmentTime { get; set; }
        public virtual Schedule Schedule{ get; set; }
    }
}
