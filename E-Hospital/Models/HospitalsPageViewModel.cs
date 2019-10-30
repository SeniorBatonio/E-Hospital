using E_Hospital.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Hospital.Models
{
    public class HospitalsPageViewModel
    {
        public List<Hospital> Hospitals{ get; set; }
        public List<string> Locations { get; set; }
    }
}