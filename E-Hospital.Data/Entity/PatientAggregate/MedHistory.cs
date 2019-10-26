using System;
using System.Collections.Generic;
using System.Text;

namespace E_Hospital.Data.Entity
{
    public class MedHistory
    {
        public int Id { get; set; }
        public virtual Patient Patient { get; set; }
        public List<Disease> Diseases { get; set; }
    }
}
