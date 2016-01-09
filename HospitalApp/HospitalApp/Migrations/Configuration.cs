namespace HospitalApp.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HospitalApp.DAL.HospitalEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HospitalApp.DAL.HospitalEntities context)
        {
            var doctors = new List<Doctor>
            {
                new Doctor {FirstName = "David", LastName = "House" },
                new Doctor {FirstName = "Michael", LastName = "Janos" },
                new Doctor {FirstName = "Gabriel", LastName = "Nagy" }
            };
            doctors.ForEach(d => context.Doctors.AddOrUpdate(n => n.LastName, d));
            context.SaveChanges();

            var patients = new List<Patient>
            {
                new Patient {FirstName = "Tom", LastName = "Frank", TB = "123456789",DoB =DateTime.Parse("1990-02-01"),YrVisits = 1, DoctorID = 1 },
                new Patient {FirstName = "Andras", LastName = "Gabe", TB = "934817284",DoB =DateTime.Parse("1965-06-16"),YrVisits = 1, DoctorID = 2 },
                new Patient {FirstName = "Mike", LastName = "Jonas", TB = "746374819",DoB =DateTime.Parse("1940-10-21"),YrVisits = 1, DoctorID = 2 },
                new Patient {FirstName = "Peter", LastName = "Henry", TB = "918203948",DoB =DateTime.Parse("1955-10-21"),YrVisits = 1, DoctorID = 3 },
                new Patient {FirstName = "Frank", LastName = "Leo", TB = "645081901",DoB =DateTime.Parse("1976-05-11"),YrVisits = 1, DoctorID = 1 },
            };
            patients.ForEach(d => context.Patients.AddOrUpdate(n => n.TB, d));
            context.SaveChanges();
        }
    }
}
