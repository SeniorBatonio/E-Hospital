﻿using System;
using System.Collections.Generic;
using System.Text;

namespace E_Hospital.Data.Entity
{
    class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday{ get; set; }
    }
}
