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
                new Szerelo { Vezet�kn�v = "Nagy", Keresztn�v = "P�ter" },
                new Szerelo { Vezet�kn�v = "Kiss", Keresztn�v = "�ron" },
                new Szerelo { Vezet�kn�v = "Jo�", Keresztn�v = "G�bor" },
                new Szerelo { Vezet�kn�v = "Alex", Keresztn�v = "J�nos" }
            };
            szerelok.ForEach(s => context.Szerelok.AddOrUpdate(a => a.Keresztn�v, s));
            context.SaveChanges();

            var kliensek = new List<Kliens>
            {
                new Kliens { Vezet�kn�v = "N�meth", Keresztn�v = "G�bor", Szulido = DateTime.Parse("1990-01-01"), SzereloID =1, FelvetelIdeje = DateTime.Parse("2015-12-11"), Surgos = false },
                new Kliens { Vezet�kn�v = "Nagy", Keresztn�v = "Lajos", Szulido = DateTime.Parse("1980-07-21"), SzereloID =2, FelvetelIdeje = DateTime.Parse("2015-12-20"), Surgos = false },
                new Kliens { Vezet�kn�v = "R�p�s", Keresztn�v = "Viktor", Szulido = DateTime.Parse("1970-03-20"), SzereloID =3, FelvetelIdeje = DateTime.Parse("2015-12-05"), Surgos = false },
                new Kliens { Vezet�kn�v = "Oleg", Keresztn�v = "Ren�t�", Szulido = DateTime.Parse("1975-05-30"), SzereloID =4, FelvetelIdeje = DateTime.Parse("2015-11-11"), Surgos = true },
                new Kliens { Vezet�kn�v = "Franc", Keresztn�v = "B�le", Szulido = DateTime.Parse("1912-02-11"), SzereloID =3, FelvetelIdeje = DateTime.Parse("2015-12-26"), Surgos = false },
                new Kliens { Vezet�kn�v = "Loo", Keresztn�v = "K�roly", Szulido = DateTime.Parse("1965-11-05"), SzereloID =2, FelvetelIdeje = DateTime.Parse("2016-01-02"), Surgos = false },
                new Kliens { Vezet�kn�v = "Ollos", Keresztn�v = "Vilmos", Szulido = DateTime.Parse("1979-12-14"), SzereloID =3, FelvetelIdeje = DateTime.Parse("2015-10-11"), Surgos = true }
            };
            kliensek.ForEach(s => context.Kliensek.AddOrUpdate(a => a.Vezet�kn�v, s));
            context.SaveChanges();            
        }
    }
}
