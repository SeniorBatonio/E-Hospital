namespace E_Hospital.EF.Migrations
{
    using E_Hospital.Data.Entity;
    using E_Hospital.Data.Entity.DoctorAggregate;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<E_Hospital.EF.E_HospitalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(E_Hospital.EF.E_HospitalContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Hospitals.AddOrUpdate(
                h => h.Id,
                new Hospital { Id = 1, Location = "Kiev", Number = 5 },
                new Hospital { Id = 2, Location = "Cherkasy", Number = 3 });

            var s1 = new Shifts { Id = 1, StartTime = new VisitTime { Hour = 8, Minute = 0 }, EndTime = new VisitTime { Hour = 13, Minute = 0 } };
            var s2 = new Shifts { Id = 2, StartTime = new VisitTime { Hour = 15, Minute = 0 }, EndTime = new VisitTime { Hour = 18, Minute = 0 } };

            var s3 = new Shifts { Id = 3, StartTime = new VisitTime { Hour = 14, Minute = 0 }, EndTime = new VisitTime { Hour = 18, Minute = 0 } };
            context.Shifts.AddOrUpdate(
                s => s.Id,
                s1, s2, s3
                );

            context.Doctors.AddOrUpdate(
                d => d.Id,
                new Doctor
                {
                    Id = 1,
                    Name = "Luba",
                    Surname = "Kostenko",
                    Profession = "Therapist",
                    HospitalID = 1,
                    Shifts = new List<Shifts>
                    {
                    s1,s2
                    }
                },
                new Doctor
                {
                    Id = 2,
                    Name = "Oksana",
                    Surname = "Petrenko",
                    Profession = "Therapist",
                    HospitalID = 2,
                    Shifts = new List<Shifts>
                    {
                    s3
                    }
                });

        }
    }
}
