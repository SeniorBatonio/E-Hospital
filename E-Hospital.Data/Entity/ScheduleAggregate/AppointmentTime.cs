using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Hospital.Data.Entity
{
    public class AppointmentTime
    {
        public int Id { get; set; }
        public VisitTime Time { get; set; }
        public Schedule Schedule{ get; set; }
    }
}
