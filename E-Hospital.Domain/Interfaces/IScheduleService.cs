using E_Hospital.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Hospital.Domain.Interfaces
{
    public interface IScheduleService
    {
        Schedule Create(DateTime date, Doctor doctor);
        List<AppointmentTime> GetFreeTimes(Schedule schedule);
        List<AppointmentTime> GetReservedTimes(Schedule schedule);
        List<AppointmentTime> GetTimesForNewSchedule(DateTime date);
        List<DateTime> GetAvailableDatesForNewSchedule(Doctor doctor, DateTime startDate, DateTime endDate);
        void Delete(Schedule schedule);
        string FormatTime(int timeid);
    }
}
