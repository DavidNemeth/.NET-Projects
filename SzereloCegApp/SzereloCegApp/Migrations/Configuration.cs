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
                new Szerelo { Vezet�kn�v = "Nagy", Keresztn�v = "P�ter",SzereloTelefon = "06304637463"},
                new Szerelo { Vezet�kn�v = "Kiss", Keresztn�v = "�ron",SzereloTelefon = "06704527389"},
                new Szerelo { Vezet�kn�v = "Jo�", Keresztn�v = "G�bor",SzereloTelefon = "06709939283"},
                new Szerelo { Vezet�kn�v = "Alex", Keresztn�v = "J�nos",SzereloTelefon = "06207374981"}
            };
            szerelok.ForEach(s => context.Szerelok.AddOrUpdate(a => a.Keresztn�v, s));
            context.SaveChanges();

            var ugyfelek = new List<Ugyfel>
            {
                new Ugyfel { Vezet�kn�v = "N�meth", Keresztn�v = "G�bor", Szulido = DateTime.Parse("1990-01-01"), SzereloID =1, FelvetelIdeje = DateTime.Parse("2015-12-11"), Fizetve = false, UgyfelTelefon = "06208283723" },
                new Ugyfel { Vezet�kn�v = "Nagy", Keresztn�v = "Lajos", Szulido = DateTime.Parse("1980-07-21"), SzereloID =2, FelvetelIdeje = DateTime.Parse("2015-12-20"), Fizetve = false, UgyfelTelefon = "06307237471" },
                new Ugyfel { Vezet�kn�v = "R�p�s", Keresztn�v = "Viktor", Szulido = DateTime.Parse("1970-03-20"), SzereloID =3, FelvetelIdeje = DateTime.Parse("2015-12-05"), Fizetve = false, UgyfelTelefon = "06708987876" },
                new Ugyfel { Vezet�kn�v = "Oleg", Keresztn�v = "Ren�t�", Szulido = DateTime.Parse("1975-05-30"), SzereloID =4, FelvetelIdeje = DateTime.Parse("2015-11-11"), Fizetve = true, UgyfelTelefon = "06306473888"},
                new Ugyfel { Vezet�kn�v = "Franc", Keresztn�v = "Bel�", Szulido = DateTime.Parse("1912-02-11"), SzereloID =3, FelvetelIdeje = DateTime.Parse("2015-12-26"), Fizetve = false, UgyfelTelefon = "06708878123" },
                new Ugyfel { Vezet�kn�v = "Loo", Keresztn�v = "K�roly", Szulido = DateTime.Parse("1965-11-05"), SzereloID =2, FelvetelIdeje = DateTime.Parse("2016-01-02"), Fizetve = false, UgyfelTelefon = "06203324234"},
                new Ugyfel { Vezet�kn�v = "Ollos", Keresztn�v = "Vilmos", Szulido = DateTime.Parse("1979-12-14"), SzereloID =3, FelvetelIdeje = DateTime.Parse("2015-10-11"), Fizetve = true, UgyfelTelefon = "06307464643"}
            };
            ugyfelek.ForEach(s => context.Ugyfelek.AddOrUpdate(a => a.Vezet�kn�v, s));
            context.SaveChanges();

            var diagnosztikak = new List<Diagnosztika>
            {
                new Diagnosztika { HibaNeve = "Ker�kcsere",JavitasAr=5000},
                new Diagnosztika { HibaNeve = "F�kbet�t jav�t�s",JavitasAr=30000},
                new Diagnosztika { HibaNeve = "Karossz�ria szerel�s(kicsi)",JavitasAr=20000},
                new Diagnosztika { HibaNeve = "Karossz�ria szerel�s(k�zepes)",JavitasAr=40000},
                new Diagnosztika { HibaNeve = "Karossz�ria szerel�s(nagy)",JavitasAr=80000},
                new Diagnosztika { HibaNeve = "�zemanyagrendszer jav�t�s",JavitasAr=150000},
                new Diagnosztika { HibaNeve = "Kuplung csere",JavitasAr=200000},
                new Diagnosztika { HibaNeve = "Alv�z szerel�s",JavitasAr=50000},
                new Diagnosztika { HibaNeve = "Szerv� jav�t�s",JavitasAr=70000},
                new Diagnosztika { HibaNeve = "V�lt� csere",JavitasAr=300000},
                new Diagnosztika { HibaNeve = "R�szecskesz�r� jav�t�s",JavitasAr=99000},
                new Diagnosztika { HibaNeve = "Kompresszor jav�t�s",JavitasAr=60000}

            };
            diagnosztikak.ForEach(d => context.Diagnosztik�k.AddOrUpdate(b => b.HibaNeve, d));
            context.SaveChanges();

            var gepjarmuvek = new List<GepJarmu>
            {
                new GepJarmu { Marka = "Opel", Tipus = "Astra", GyartasiEv = DateTime.Parse("2010-01-01"),  Rendszam = "AGB-121", UgyfelID = 1},
                new GepJarmu { Marka = "Audi", Tipus = "A4", GyartasiEv = DateTime.Parse("1999-01-01"),  Rendszam = "HBD-123", UgyfelID = 2},
                new GepJarmu { Marka = "BMW", Tipus = "M4", GyartasiEv = DateTime.Parse("2000-01-01"),  Rendszam = "AWQ-663", UgyfelID = 3},
                new GepJarmu { Marka = "Fiat", Tipus = "Punto", GyartasiEv = DateTime.Parse("2001-01-01"),  Rendszam = "XAW-234", UgyfelID = 4},
                new GepJarmu { Marka = "Mitsubishi", Tipus = "Galant", GyartasiEv = DateTime.Parse("2013-01-01"),  Rendszam = "JRW-732", UgyfelID = 5},
                new GepJarmu { Marka = "Audi", Tipus = "R8", GyartasiEv = DateTime.Parse("2015-01-01"),  Rendszam = "MEW-373", UgyfelID = 6},
                new GepJarmu { Marka = "BMW", Tipus = "X5", GyartasiEv = DateTime.Parse("2015-01-01"),  Rendszam = "MEW-615", UgyfelID = 6},
                new GepJarmu { Marka = "Opel", Tipus = "Vectra", GyartasiEv = DateTime.Parse("1990-01-01"),  Rendszam = "HWW-723", UgyfelID = 7}
            };            
            gepjarmuvek.ForEach(s => context.GepJarmuvek.AddOrUpdate(a => a.Rendszam, s));            
            context.SaveChanges();
            var posts = new List<Post>
            {
                new Post { Description = "Alex hozd vissza a vill�skucsot", Body = "Alex ha m�g egyszer elt�nteted a vill�skulcsot, ki tekerem a nyakadat! �dv: Peti", PostedDate = DateTime.Parse("2016-01-12"),  SzereloID = 1},
                new Post { Description = "Szabads�g", Body = "Sr�cok, nyertem egy kissebb �sszeget kapar�son, �gyhogy k�t h�tre sielni mentem. UI: a vill�skulcsot a Gabi tette el..", PostedDate = DateTime.Parse("2016-01-14"),  SzereloID = 4},
                new Post { Description = "Vill�skulcs", Body = "Eln�z�st, visszaraktam a kulcsot a hely�re, tudom ott sosem keresitek.", PostedDate = DateTime.Parse("2016-01-15"),  SzereloID = 3},
                new Post { Description = "Alex BMW", Body = "Alex azt a pancser BMW-s sr�cot �tveszem t�led am�g szabin vagy.", PostedDate = DateTime.Parse("2016-01-16"),  SzereloID = 2},
                new Post { Description = "BMW-s sr�c", Body = "Ha valaki t�voll�temben lenyulja a BMW-s kuncsaftomat, azt a Vill�skulcsal verem agyon.", PostedDate = DateTime.Parse("2016-01-17"),  SzereloID = 4}
            };
            posts.ForEach(s => context.Posts.AddOrUpdate(a => a.Description, s));
            context.SaveChanges();
        }
    }
}
