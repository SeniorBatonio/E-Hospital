using E_Hospital.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Hospital.Data.Repositories
{
    public interface IScheduleRepository
    {
        void Create(Schedule schedule);
        List<Schedule> GetSchedules(int doctorId, DateTime startDate, DateTime endDate);
        Schedule GetSchedule(int id);
        AppointmentTime GetTime(int timeId);
    }
}
