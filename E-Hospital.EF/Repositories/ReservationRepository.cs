using E_Hospital.Data.Entity;
using E_Hospital.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Hospital.EF.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        public void Create(Reservation reservation)
        {
            using (var ctx = new E_HospitalContext())
            {
                ctx.Reservations.Add(reservation);
                ctx.SaveChanges();
            }
        }

        public void Delete(Reservation reservation)
        {
            using (var ctx = new E_HospitalContext())
            {
                ctx.Reservations.Remove(reservation);
                ctx.SaveChanges();
            }
        }

        public Reservation Get(int id)
        {
            using (var ctx = new E_HospitalContext())
            {
                return ctx.Reservations.FirstOrDefault(r => r.Id == id);
            }
        }

        public List<Reservation> GetReservations()
        {
            using (var context = new E_HospitalContext())
            {
                return context.Reservations.ToList();
            }
        }

        public void Update(Reservation reservation)
        {
            using (var ctx = new E_HospitalContext())
            {
                ctx.Reservations.Attach(reservation);
                ctx.Entry(reservation).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
        }
    }
}
