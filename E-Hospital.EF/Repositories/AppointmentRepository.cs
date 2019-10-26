using E_Hospital.Data.Entity;
using E_Hospital.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Hospital.EF.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public void Create(Appointment appointment)
        {
            using (var context = new E_HospitalContext())
            {
                context.Appointments.Add(appointment);
                context.SaveChanges();
            }
        }

        public void Delete(Appointment appointment)
        {
            using (var context = new E_HospitalContext())
            {
                context.Appointments.Remove(appointment);
                context.SaveChanges();
            }
        }

        public Appointment GetAppointmentDetails(int id)
        {
            using (var context = new E_HospitalContext())
            {
                return context.Appointments
                    .Include("Doctor")
                    .Include("Patient")
                    .FirstOrDefault(a => a.Id == id);
            }
        }

        public List<Appointment> GetAppointments()
        {
            using (var context = new E_HospitalContext())
            {
                return context.Appointments.ToList();
            }
        }

        public void Update(Appointment appointment)
        {
            using (var context = new E_HospitalContext())
            {
                context.Appointments.Attach(appointment);
                context.Entry(appointment).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
