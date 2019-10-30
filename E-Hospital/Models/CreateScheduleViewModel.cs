using E_Hospital.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Hospital.Models
{
    public class CreateScheduleViewModel
    {
        public Doctor Doctor{ get; set; }
        public List<Schedule> Schedules { get; set; }
        public List<DateTime> AvailableDates { get; set; }
    }
}