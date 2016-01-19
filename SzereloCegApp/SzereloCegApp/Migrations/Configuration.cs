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
                new Szerelo { Vezetéknév = "Nagy", Keresztnév = "Péter", Oraber= 5000 },
                new Szerelo { Vezetéknév = "Kiss", Keresztnév = "Áron", Oraber= 4500 },
                new Szerelo { Vezetéknév = "Joó", Keresztnév = "Gábor", Oraber= 4000 },
                new Szerelo { Vezetéknév = "Alex", Keresztnév = "János", Oraber= 7000 }
            };
            szerelok.ForEach(s => context.Szerelok.AddOrUpdate(a => a.Keresztnév, s));
            context.SaveChanges();

            var ugyfelek = new List<Ugyfel>
            {
                new Ugyfel { Vezetéknév = "Németh", Keresztnév = "Gábor", Szulido = DateTime.Parse("1990-01-01"), SzereloID =1, FelvetelIdeje = DateTime.Parse("2015-12-11"), Fizetve = false },
                new Ugyfel { Vezetéknév = "Nagy", Keresztnév = "Lajos", Szulido = DateTime.Parse("1980-07-21"), SzereloID =2, FelvetelIdeje = DateTime.Parse("2015-12-20"), Fizetve = false },
                new Ugyfel { Vezetéknév = "Répás", Keresztnév = "Viktor", Szulido = DateTime.Parse("1970-03-20"), SzereloID =3, FelvetelIdeje = DateTime.Parse("2015-12-05"), Fizetve = false },
                new Ugyfel { Vezetéknév = "Oleg", Keresztnév = "Renátó", Szulido = DateTime.Parse("1975-05-30"), SzereloID =4, FelvetelIdeje = DateTime.Parse("2015-11-11"), Fizetve = true },
                new Ugyfel { Vezetéknév = "Franc", Keresztnév = "Béle", Szulido = DateTime.Parse("1912-02-11"), SzereloID =3, FelvetelIdeje = DateTime.Parse("2015-12-26"), Fizetve = false },
                new Ugyfel { Vezetéknév = "Loo", Keresztnév = "Károly", Szulido = DateTime.Parse("1965-11-05"), SzereloID =2, FelvetelIdeje = DateTime.Parse("2016-01-02"), Fizetve = false },
                new Ugyfel { Vezetéknév = "Ollos", Keresztnév = "Vilmos", Szulido = DateTime.Parse("1979-12-14"), SzereloID =3, FelvetelIdeje = DateTime.Parse("2015-10-11"), Fizetve = true }
            };
            ugyfelek.ForEach(s => context.Ugyfelek.AddOrUpdate(a => a.Vezetéknév, s));
            context.SaveChanges();

            var diagnosztikak = new List<Diagnosztika>
            {
                new Diagnosztika { HibaNeve = "Kerékcsere",MunkaIdo = 1 ,Anyagköltseg= 0 },
                new Diagnosztika { HibaNeve = "Fékbetét" ,MunkaIdo = 3 ,Anyagköltseg= 15000 },
                new Diagnosztika { HibaNeve = "Karosszéria-Kicsi" ,MunkaIdo = 3 ,Anyagköltseg= 10000 },
                new Diagnosztika { HibaNeve = "Karosszéria-Közepes" ,MunkaIdo = 5 ,Anyagköltseg= 20000 },
                new Diagnosztika { HibaNeve = "Karosszéria-Nagy" ,MunkaIdo = 8 ,Anyagköltseg= 30000 },
                new Diagnosztika { HibaNeve = "Üzemanyagrendszer" ,MunkaIdo = 10 ,Anyagköltseg= 25000 },
                new Diagnosztika { HibaNeve = "Kuplung - Váltó" ,MunkaIdo = 8 ,Anyagköltseg= 125000 },                
                new Diagnosztika { HibaNeve = "Alváz" ,MunkaIdo = 5 ,Anyagköltseg= 10000 },
                new Diagnosztika { HibaNeve = "Olajcsere" ,MunkaIdo = 1 ,Anyagköltseg= 5000 }
            };
            diagnosztikak.ForEach(d => context.Diagnosztikák.AddOrUpdate(b => b.HibaNeve, d));
            context.SaveChanges();

            var gepjarmuvek = new List<GepJarmu>
            {
                new GepJarmu { Marka = "Opel", Tipus = "Astra", GyartasiEv = DateTime.Parse("2010-01-01"),  Rendszam = "AGB-121", UgyfelID = 1},
                new GepJarmu { Marka = "Audi", Tipus = "A4", GyartasiEv = DateTime.Parse("1999-01-01"),  Rendszam = "HBD-123", UgyfelID = 2},
                new GepJarmu { Marka = "BMW", Tipus = "M4", GyartasiEv = DateTime.Parse("2000-01-01"),  Rendszam = "AWQ-663", UgyfelID = 3},
                new GepJarmu { Marka = "Fiat", Tipus = "Punto", GyartasiEv = DateTime.Parse("2001-01-01"),  Rendszam = "XAW-234", UgyfelID = 4},
                new GepJarmu { Marka = "Mitsubishi", Tipus = "Galant", GyartasiEv = DateTime.Parse("2013-01-01"),  Rendszam = "JRW-732", UgyfelID = 5},
                new GepJarmu { Marka = "Audi", Tipus = "R8", GyartasiEv = DateTime.Parse("2015-01-01"),  Rendszam = "MEW-373", UgyfelID = 6},
                new GepJarmu { Marka = "BMW", Tipus = "X5", GyartasiEv = DateTime.Parse("2015-01-01"),  Rendszam = "MEW-373", UgyfelID = 6},
                new GepJarmu { Marka = "Opel", Tipus = "Vectra", GyartasiEv = DateTime.Parse("1990-01-01"),  Rendszam = "HWW-723", UgyfelID = 7}
            };
            gepjarmuvek.ForEach(s => context.GepJarmuvek.AddOrUpdate(a => a.Rendszam, s));
            context.SaveChanges();
        }
    }
}
