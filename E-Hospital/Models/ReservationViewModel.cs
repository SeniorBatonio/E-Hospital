using E_Hospital.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Hospital.Models
{
    public class ReservationViewModel
    {
        public string ReservationTime { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime ReservationDate { get; set; }
        public Reservation Reservation { get; set; }
    }
}