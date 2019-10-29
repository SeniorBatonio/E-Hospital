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
        List<DoctorAppointmentTime> GetFreeTimes(Schedule schedule);
        List<DoctorAppointmentTime> GetTimesForNewSchedule(DateTime date);
        void Delete(Schedule schedule);
    }
}
