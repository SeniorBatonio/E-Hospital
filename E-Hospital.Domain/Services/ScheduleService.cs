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
        private IScheduleRepository _scheduleRepo;
        private IDoctorRepository _doctorRepo;
        private IReservationService _reservationService;
        public ScheduleService(IScheduleRepository scheduleRepo, IReservationService reservationService, IDoctorRepository doctorRepo)
        {
            _scheduleRepo = scheduleRepo;
            _reservationService = reservationService;
            _doctorRepo = doctorRepo;
        }
        public Schedule Create(DateTime date, Doctor doctor)
        {
            if (doctor.SchedulesIds == null) doctor.SchedulesIds = new List<int>();
            var newSchedule = new Schedule
            {
                Date = date,
                DoctorId = doctor.Id,
                AppointmentTimes = GetTimesForNewSchedule(date, doctor)

            };
            _scheduleRepo.Create(newSchedule);
            doctor.SchedulesIds.Add(newSchedule.Id);
            _doctorRepo.Update(doctor);
            return newSchedule;
        }

        public List<AppointmentTime> GetTimesForNewSchedule(DateTime date, Doctor doctor)
        {
            var newTimes = new List<AppointmentTime>();
            foreach (var shift in doctor.Shifts)
            {
                for (var hour = shift.StartTime.Hour; hour <= shift.EndTime.Hour; ++hour)
                {
                    var time = new AppointmentTime { Time = new VisitTime { Hour = hour, Minute = 0 } };
                    newTimes.Add(time);
                }
            }
            
            return newTimes;
        }

        public void Delete(Schedule schedule)
        {
            var doctor = _doctorRepo.GetDoctorDetails(schedule.Id);
            doctor.SchedulesIds.Remove(schedule.Id);
            _doctorRepo.Update(doctor);
        }

        public List<AppointmentTime> GetFreeTimes(Schedule schedule)
        {
            var freeTimes = new List<AppointmentTime>();
            foreach(var time in schedule.AppointmentTimes)
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
            var reservedDates = _scheduleRepo.GetSchedules(doctor.Id, startDate, endDate);
            for(var date = startDate; date < endDate; date = date.AddDays(1))
            {
                if(!reservedDates.Any(d=>d.Date == date))
                {
                    avDates.Add(date);
                }
            }
            return avDates;
        }

        public string FormatTime(VisitTime time)
        {
            var result = $"{time.Hour}:";
            if (time.Minute < 10) result += $"0{time.Minute}";
            else result += time.Minute;
            return result;
        }

        public List<AppointmentTime> GetReservedTimes(Schedule schedule)
        {
            var reservedTimes = new List<AppointmentTime>();
            foreach (var time in schedule.AppointmentTimes)
            {
                if (_reservationService.DateTimeIsReserved(time))
                {
                    reservedTimes.Add(time);
                }
            }
            return reservedTimes;
        }
    }
}
