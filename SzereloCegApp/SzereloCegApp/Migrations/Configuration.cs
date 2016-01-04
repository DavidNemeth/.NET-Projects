namespace SzereloCegApp.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SzereloCegApp.DAL.SzereloCegEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SzereloCegApp.DAL.SzereloCegEntities context)
        {
            var szerelok = new List<Szerelo>
            {
                new Szerelo { Vezetéknév = "Nagy", Keresztnév = "Péter" },
                new Szerelo { Vezetéknév = "Kiss", Keresztnév = "Áron" },
                new Szerelo { Vezetéknév = "Joó", Keresztnév = "Gábor" },
                new Szerelo { Vezetéknév = "Alex", Keresztnév = "János" }
            };
            szerelok.ForEach(s => context.Szerelok.AddOrUpdate(a => a.Keresztnév, s));
            context.SaveChanges();

            var kliensek = new List<Kliens>
            {
                new Kliens { Vezetéknév = "Németh", Keresztnév = "Gábor", Szulido = DateTime.Parse("1990-01-01"), SzereloID =1, FelvetelIdeje = DateTime.Parse("2015-12-11"), Surgos = false },
                new Kliens { Vezetéknév = "Nagy", Keresztnév = "Lajos", Szulido = DateTime.Parse("1980-07-21"), SzereloID =2, FelvetelIdeje = DateTime.Parse("2015-12-20"), Surgos = false },
                new Kliens { Vezetéknév = "Répás", Keresztnév = "Viktor", Szulido = DateTime.Parse("1970-03-20"), SzereloID =3, FelvetelIdeje = DateTime.Parse("2015-12-05"), Surgos = false },
                new Kliens { Vezetéknév = "Oleg", Keresztnév = "Renátó", Szulido = DateTime.Parse("1975-05-30"), SzereloID =4, FelvetelIdeje = DateTime.Parse("2015-11-11"), Surgos = true },
                new Kliens { Vezetéknév = "Franc", Keresztnév = "Béle", Szulido = DateTime.Parse("1912-02-11"), SzereloID =3, FelvetelIdeje = DateTime.Parse("2015-12-26"), Surgos = false },
                new Kliens { Vezetéknév = "Loo", Keresztnév = "Károly", Szulido = DateTime.Parse("1965-11-05"), SzereloID =2, FelvetelIdeje = DateTime.Parse("2016-01-02"), Surgos = false },
                new Kliens { Vezetéknév = "Ollos", Keresztnév = "Vilmos", Szulido = DateTime.Parse("1979-12-14"), SzereloID =3, FelvetelIdeje = DateTime.Parse("2015-10-11"), Surgos = true }
            };
            kliensek.ForEach(s => context.Kliensek.AddOrUpdate(a => a.Vezetéknév, s));
            context.SaveChanges();            
        }
    }
}
