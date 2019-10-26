using E_Hospital.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Hospital.Data.Repositories
{
    public interface IAppointmentRepository
    {
        void Create(Appointment appointment);
        void Update(Appointment appointment);
        void Delete(Appointment appointment);
        Appointment GetAppointmentDetails(int id);
        List<Appointment> GetAppointments();
    }
}
