using E_Hospital.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Hospital.Models
{
    public class AppointmentDetailsViewModel
    {
        public Patient Patient{ get; set; }
        public Doctor Doctor{ get; set; }
        public DateTime Date{ get; set; }
        public string Time { get; set; }
    }
}