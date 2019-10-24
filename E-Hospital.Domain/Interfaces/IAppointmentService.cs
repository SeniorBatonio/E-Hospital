using E_Hospital.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Hospital.Domain.Interfaces
{
    interface IAppointmentService
    {
        void Appoint(Appointment appointment);
        void RemoveAppointment(Appointment appointment);
        bool IsReserved(Appointment appointment);
    }
}
