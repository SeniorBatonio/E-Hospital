namespace E_Hospital.EF.Migrations
{
    using E_Hospital.Data.Entity;
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

            context.Doctors.AddOrUpdate(
                d => d.Id,
                new Doctor
                {
                    Name = "Luba",
                    Surname = "Kostenko",
                    Profession = "Therapist",
                    HospitalID = 1
                },
                new Doctor
                {
                    Name = "Oksana",
                    Surname = "Petrenko",
                    Profession = "Therapist",
                    HospitalID = 2
                }) ;

        }
    }
}
