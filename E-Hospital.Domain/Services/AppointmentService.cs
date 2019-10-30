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
    public class AppointmentService : IAppointmentService
    {
        private IAppointmentRepository _appointmentRepo;
        private IReservationRepository _reservationRepo;
        public AppointmentService(IAppointmentRepository appointmentRepo, IReservationRepository reservationRepo)
        {
            _appointmentRepo = appointmentRepo;
            _reservationRepo = reservationRepo;
        }
        public Appointment Create(int reservationId, int patientId)
        {
            var reservation = _reservationRepo.Get(reservationId);
            var newAppointment = new Appointment
            {
                ReservationId = reservationId,
                PatientId = patientId
            };
            _appointmentRepo.Create(newAppointment);
            reservation.AppointmentId = newAppointment.Id;
            _reservationRepo.Update(reservation);
            return newAppointment;
        }

        public void Remove(Appointment appointment)
        {
            _appointmentRepo.Delete(appointment);
        }
    }
}
