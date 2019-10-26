using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Hospital.Data.Entity
{
    public class DoctorAppointmentDateTime
    {
        public int Id { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public virtual Doctor Doctor{ get; set; }
    }
}
