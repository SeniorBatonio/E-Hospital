using E_Hospital.Data.Entity;
using E_Hospital.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Hospital.EF.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        public void AddSchedule(Schedule schedule)
        {
            using (var context = new E_HospitalContext())
            {
                context.Doctors.Attach(schedule.Doctor);
                context.Schedules.Add(schedule);
                context.SaveChanges();
            }
        }

        public void Create(Doctor doctor)
        {
            using (var context = new E_HospitalContext())
            {
                context.Doctors.Add(doctor);
                context.SaveChanges();
            }
        }

        public void Delete(Doctor doctor)
        {
            using (var context = new E_HospitalContext())
            {
                context.Doctors.Remove(doctor);
                context.SaveChanges();
            }
        }

        public Doctor GetDoctorDetails(int id)
        {
            using (var context = new E_HospitalContext())
            {
                return context.Doctors
                    .Include("Schedules")
                    .Include("Schedules.DoctorAppointmentTimes")
                    .FirstOrDefault(d => d.Id == id);
            }
        }

        public List<Doctor> GetDoctors()
        {
            using (var context = new E_HospitalContext())
            {
                return context.Doctors.ToList();
            }
        }

        public Schedule GetSchedule(int id)
        {
            using (var context = new E_HospitalContext())
            {
                return context.Schedules
                    .Include("Doctor")
                    .Include("DoctorAppointmentTimes")
                    .FirstOrDefault(s => s.Id == id);
            }
        }

        public List<Schedule> GetSchedules(int doctorId, DateTime startDate, DateTime endDate)
        {
            using (var context = new E_HospitalContext())
            {
                var doctor = context.Doctors.FirstOrDefault(d => d.Id == doctorId);
                return doctor.Schedules.Where(s => s.Date > startDate && s.Date < endDate).ToList();
            }
        }

        public void Update(Doctor doctor)
        {
            using (var context = new E_HospitalContext())
            {
                context.Doctors.Attach(doctor);
                context.Entry(doctor).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public DoctorAppointmentTime GetTime(int timeId)
        {
            using (var context = new E_HospitalContext())
            {
                return context.DoctorAppointmentTimes
                    .Include("Schedule")
                    .Include("Schedule.Doctor")
                    .FirstOrDefault(t => t.Id == timeId);
            }
        }
    }
}
