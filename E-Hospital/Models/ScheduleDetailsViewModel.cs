﻿using E_Hospital.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Hospital.Models
{
    public class ScheduleDetailsViewModel
    {
        public Schedule Schedule{ get; set; }
        public List<int> FreeTimesIds { get; set; }
        public Doctor Doctor { get; set; }
    }
}