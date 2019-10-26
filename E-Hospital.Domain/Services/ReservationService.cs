using E_Hospital.Data.Entity;
using E_Hospital.Data.Repositories;
using E_Hospital.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Hospital.Domain.Services
{
    public class ReservationService : IReservationService
    {
        private IReservationRepository _reservationRepo;

        public ReservationService(IReservationRepository reservationRepo)
        {
            _reservationRepo = reservationRepo;
        }
        public bool DateTimeIsReserved(DoctorAppointmentTime dateTime)
        {
            var reservationsForCurTime = _reservationRepo.GetReservations().FindAll(r => r.DoctorAppointmentDateTimeId == dateTime.Id);
            if(reservationsForCurTime != null)
            {
                return false;
            }
            foreach (var res in reservationsForCurTime)
            {
                if (IsActive(res))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsActive(Reservation reservation)
        {
            return reservation.End > DateTime.Now || reservation.AppointmentId.HasValue;
        }

        public void RemoveReservation(Reservation reservation)
        {
            _reservationRepo.Delete(reservation);
        }

        public Reservation Reserve(DoctorAppointmentTime dateTime)
        {
            if (DateTimeIsReserved(dateTime))
            {
                throw new InvalidOperationException($"{dateTime.Schedule.Doctor.Name} {dateTime.Schedule.Doctor.Surname} appointment on {dateTime.AppointmentTime} is reserved.");
            }
            var newReservation = new Reservation
            {
                Start = DateTime.Now,
                End = DateTime.Now.AddMinutes(20),
                DoctorAppointmentDateTimeId = dateTime.Id
            };

            return newReservation;
        }
    }
}
