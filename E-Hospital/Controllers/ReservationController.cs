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
        private IScheduleRepository _scheduleRepo;
        private IScheduleService _scheduleService;
        public ReservationController(IDoctorRepository doctorRepo, IReservationService reservationService,
            IPatientService patientService, IPatientRepository patientRepo, IReservationRepository reservationRepo,
            IAppointmentService appointmentService, IScheduleRepository scheduleRepo, IScheduleService scheduleService)
        {
            _doctorRepo = doctorRepo;
            _reservationService = reservationService;
            _patientService = patientService;
            _patientRepo = patientRepo;
            _reservationRepo = reservationRepo;
            _appointmentService = appointmentService;
            _scheduleRepo = scheduleRepo;
            _scheduleService = scheduleService;
        }
        public ActionResult Index(int timeId)
        {
            var time = _scheduleRepo.GetTime(timeId);
            var schedule = time.Schedule;
            var reservation = _reservationService.Reserve(time);
            var model = new ReservationViewModel
            {
                Reservation = reservation,
                ReservationDate = schedule.Date,
                ReservationTime =  _scheduleService.FormatTime(time.Time),
                Doctor = _doctorRepo.GetDoctorDetails(schedule.DoctorId)
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
            var time = _scheduleRepo.GetTime(reservation.DoctorAppointmentDateTimeId);
            var model = new AppointmentDetailsViewModel
            {
                Doctor = _doctorRepo.GetDoctorDetails(time.Schedule.DoctorId),
                Patient = patient,
                Date = time.Schedule.Date,
                Time = _scheduleService.FormatTime(time.Time)
            };
            return View(model);
        }
    }
}