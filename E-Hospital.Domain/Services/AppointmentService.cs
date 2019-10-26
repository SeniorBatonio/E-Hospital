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
        public AppointmentService(IAppointmentRepository appointmentRepo)
        {
            _appointmentRepo = appointmentRepo;
        }
        public Appointment Create(int reservationId, int patientId)
        {

            var newAppointment = new Appointment
            {
                ReservationId = reservationId,
                PatientId = patientId
            };
            _appointmentRepo.Create(newAppointment);
            return newAppointment;
        }

        public void Remove(Appointment appointment)
        {
            _appointmentRepo.Delete(appointment);
        }
    }
}
