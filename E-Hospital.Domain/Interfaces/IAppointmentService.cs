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
        Appointment Create(int reservationId, int patientId);
        void Remove(Appointment appointment);
    }
}
