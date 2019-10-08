using System;
using System.Collections.Generic;
using System.Text;

namespace E_Hospital.Data.Entity
{
    class Disease
    {
        public int Id { get; set; }
        public virtual MedHistory MedHistory { get; set; }
        public virtual Doctor Doctor { get; set; }
        public string Conclusion { get; set; }
    }
}
