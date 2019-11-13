using E_Hospital.Data.Entity;
using E_Hospital.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Hospital.EF.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        public void Create(Schedule schedule)
        {
            using (var context = new E_HospitalContext())
            {
                context.Schedules.Add(schedule);
                context.SaveChanges();
            }
        }

        public Schedule GetSchedule(int id)
        {
            using (var context = new E_HospitalContext())
            {
                return context.Schedules
                    .Include("AppointmentTimes")
                    .FirstOrDefault(s => s.Id == id);
            }
        }

        public List<Schedule> GetSchedules(int doctorId, DateTime startDate, DateTime endDate)
        {
            using (var context = new E_HospitalContext())
            {
                return context.Schedules.Where(s => s.Date >= startDate && s.Date <= endDate).ToList();
            }
        }

        public AppointmentTime GetTime(int timeId)
        {
            using (var context = new E_HospitalContext())
            {
                return context.AppointmentTimes
                    .Include("Schedule")
                    .FirstOrDefault(t => t.Id == timeId);
            }
        }
    }
}
