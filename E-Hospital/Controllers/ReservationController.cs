using E_Hospital.Data.Entity;
using E_Hospital.Data.Repositories;
using E_Hospital.Domain.Interfaces;
using E_Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Hospital.Controllers
{
    public class ReservationController : Controller
    {
        private IDoctorRepository _doctorRepo;
        private IReservationService _reservationService;
        private IPatientService _patientService;
        private IPatientRepository _patientRepo;
        private IReservationRepository _reservationRepo;
        private IAppointmentService _appointmentService;
        public ReservationController(IDoctorRepository doctorRepo, IReservationService reservationService,
            IPatientService patientService, IPatientRepository patientRepo, IReservationRepository reservationRepo,
            IAppointmentService appointmentService)
        {
            _doctorRepo = doctorRepo;
            _reservationService = reservationService;
            _patientService = patientService;
            _patientRepo = patientRepo;
            _reservationRepo = reservationRepo;
            _appointmentService = appointmentService;
        }
        public ActionResult Index(int timeId)
        {
            var time = _doctorRepo.GetTime(timeId);
            var schedule = time.Schedule;
            var reservation = _reservationService.Reserve(time);
            var model = new ReservationViewModel
            {
                Reservation = reservation,
                ReservationDate = schedule.Date,
                ReservationTime = time,
                Doctor = schedule.Doctor
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Reserve(string email, int reservationId)
        {
            if (_patientService.IsPatientExist(email))
            {
                var patient = _patientRepo.GetPatients().First(p => p.Email == email);
                return RedirectToAction("CreateAppointment", new { patientId = patient.Id, reservationId = reservationId });
            }
            return RedirectToAction("CreatePatient", new { reservationId = reservationId, email = email});
        }

        public ActionResult CreatePatient(int reservationId, string email)
        {
            var model = new CreatePatientViewModel
            {
                ReservationId = reservationId,
                Email = email
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult CreatePatient(Patient patient, int reservationId)
        {
            var newPatient = _patientService.CreatePatient(patient.Email, patient.Name, patient.Surname, patient.Birthday);
            return RedirectToAction("CreateAppointment", new { patientId = newPatient.Id, reservationId = reservationId });
        }

        public ActionResult CreateAppointment(int patientId, int reservationId)
        {
            _appointmentService.Create(reservationId, patientId);

            var patient = _patientRepo.Get(patientId);
            var reservation = _reservationRepo.Get(reservationId);
            var time = _doctorRepo.GetTime(reservation.DoctorAppointmentDateTimeId);
            var model = new AppointmentDetailsViewModel
            {
                Doctor = time.Schedule.Doctor,
                Patient = patient,
                Date = time.Schedule.Date,
                Time = time.AppointmentTime
            };
            return View(model);
        }
    }
}