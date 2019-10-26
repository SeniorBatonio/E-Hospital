using E_Hospital.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Hospital.Domain.Interfaces
{
    public interface IReservationService
    {
        Reservation Reserve(DoctorAppointmentTime dateTime);
        void RemoveReservation(Reservation appointment);
        bool DateTimeIsReserved(DoctorAppointmentTime dateTime);
        bool IsActive(Reservation reservation);
    }
}
