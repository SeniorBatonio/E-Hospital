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
    class ReservationService : IReservationService
    {
        private IReservationRepository _reservationRepo;
        private IAppointmentRepository _appointmentRepo;

        public ReservationService(IReservationRepository reservationRepo, IAppointmentRepository appointmentRepo)
        {
            _reservationRepo = reservationRepo;
            _appointmentRepo = appointmentRepo;
        }
        public bool DateTimeIsReserved(DoctorAppointmentDateTime dateTime)
        {
            var res = _reservationRepo.GetReservations().FirstOrDefault(r => r.DoctorAppointmentDateTimeId == dateTime.Id);
            if (res != null && (res.End > DateTime.Now || _appointmentRepo.GetAppointments().Any(a=>a.ReservationId == res.Id)))
            {
                return true;
            }
            return false;
        }

        public void RemoveReservation(Reservation reservation)
        {
            _reservationRepo.Delete(reservation);
        }

        public Reservation Reserve(DoctorAppointmentDateTime dateTime)
        {
            if (DateTimeIsReserved(dateTime))
            {
                throw new InvalidOperationException($"{dateTime.Doctor.Name} {dateTime.Doctor.Surname} appointment on {dateTime.AppointmentDateTime} is reserved.");
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
