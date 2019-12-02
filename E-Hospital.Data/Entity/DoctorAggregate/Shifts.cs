using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Hospital.Data.Entity.DoctorAggregate
{
    public class Shifts
    {
        public int Id { get; set; }
        public VisitTime StartTime { get; set; }
        public VisitTime EndTime{ get; set; }
        public Doctor Doctor { get; set; }
    }
}
