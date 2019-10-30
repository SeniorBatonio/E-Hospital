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
    public class ScheduleService : IScheduleService
    {
        private IDoctorRepository _doctorRepo;
        private IReservationService _reservationService;
        public ScheduleService(IDoctorRepository doctorRepo, IReservationService reservationService)
        {
            _doctorRepo = doctorRepo;
            _reservationService = reservationService;
        }
        public Schedule Create(DateTime date, Doctor doctor)
        {
            var newSchedule = new Schedule
            {
                Date = date,
                Doctor = doctor,
                DoctorAppointmentTimes = GetTimesForNewSchedule(date)
            };
            _doctorRepo.AddSchedule(newSchedule);
            doctor.Schedules.Add(newSchedule);
            _doctorRepo.Update(doctor);
            return newSchedule;
        }

        public List<DoctorAppointmentTime> GetTimesForNewSchedule(DateTime date)
        {
            var newTimes = new List<DoctorAppointmentTime>();
            for(var t = date.Date.AddHours(9); t.Hour <= 17; t = t.AddHours(1)) // 9:00 - start of the working day 
            {                                                                   // 17:00 - end of working day
                var time = new DoctorAppointmentTime { AppointmentTime = t };
                newTimes.Add(time);
            }
            return newTimes;
        }

        public void Delete(Schedule schedule)
        {
            var doc = schedule.Doctor;
            _doctorRepo.GetDoctorDetails(doc.Id).Schedules.Remove(schedule);
            _doctorRepo.Update(doc);
        }

        public List<DoctorAppointmentTime> GetFreeTimes(Schedule schedule)
        {
            var freeTimes = new List<DoctorAppointmentTime>();
            foreach(var time in schedule.DoctorAppointmentTimes)
            {
                if(!_reservationService.DateTimeIsReserved(time))
                {
                    freeTimes.Add(time);
                }
            }
            return freeTimes;
        }

        public List<DateTime> GetAvailableDatesForNewSchedule(Doctor doctor, DateTime startDate, DateTime endDate)
        {
            var avDates = new List<DateTime>();
            var reservedDates = doctor.Schedules.Select(s => s.Date);
            for(var date = startDate; date < endDate; date = date.AddDays(1))
            {
                if(!reservedDates.Any(d=>d.Date == date))
                {
                    avDates.Add(date);
                }
            }
            return avDates;
        }
    }
}
