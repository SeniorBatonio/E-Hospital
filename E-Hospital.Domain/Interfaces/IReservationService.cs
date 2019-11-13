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
        Reservation Reserve(AppointmentTime time);
        void RemoveReservation(Reservation appointment);
        bool DateTimeIsReserved(AppointmentTime time);
        bool IsActive(Reservation reservation);
    }
}
