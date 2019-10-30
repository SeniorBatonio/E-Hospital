using E_Hospital.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Hospital.Models
{
    public class DoctorsViewModel
    {
        public Hospital Hospital{ get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}