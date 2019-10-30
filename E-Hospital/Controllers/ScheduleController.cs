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
    public class ScheduleController : Controller
    {
        private IDoctorRepository _doctorRepo;
        private IScheduleService _scheduleService;
        public ScheduleController(IDoctorRepository doctorRepo, IScheduleService scheduleService)
        {
            _doctorRepo = doctorRepo;
            _scheduleService = scheduleService;
        }

        public ActionResult Index(int doctorId)
        {
            var doctor = _doctorRepo.GetDoctorDetails(doctorId);
            var startDate = DateTime.Today;
            var endDate = startDate.AddDays(7);
            var model = new CreateScheduleViewModel
            {
                Doctor = doctor,
                Schedules = doctor.Schedules,
                AvailableDates = _scheduleService.GetAvailableDatesForNewSchedule(doctor, startDate, endDate)
            };
            return View(model);
        }

        public ActionResult CreateSchedule(int doctorId, DateTime date)
        {
            var doctor = _doctorRepo.GetDoctorDetails(doctorId);
            _scheduleService.Create(date, doctor);
            return RedirectToAction("Index", new { doctorId = doctorId });
        }

        public ActionResult ScheduleDetails(int scheduleId)
        {
            var schedule = _doctorRepo.GetSchedule(scheduleId);
            var model = new ScheduleDetailsViewModel
            {
                Schedule = schedule,
                FreeTimesIds = _scheduleService.GetFreeTimes(schedule).Select(s => s.Id).ToList(),
                Doctor = schedule.Doctor
            };
            return View(model);
        }
    }
}