using KisKer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KisKer.ViewModels
{
    public class CartViewModel
    {
        public ErtekesitesReszletekModel DataModell { get; set; }
        public string ReturnUrl { get; set; }
        public class ErtekesitesReszletekLine
        {
            public int AruID { get; set; }
            public decimal EgysegAr { get; set; }
            public int AruMennyiseg { get; set; }
            public string AruMegnevezes { get; set; }
        }
        public class ErtekesitesReszletekModel
        {
            private List<ErtekesitesReszletekLine> BevasarloLista = new List<ErtekesitesReszletekLine>();
            public IEnumerable<ErtekesitesReszletekLine> ErtekesitesTetelek
            {
                get
                {
                    return (BevasarloLista);
                }
            }
            public void AddTetel(AruKeszlet Aru, int nMennyiseg)
            {
                ErtekesitesReszletekLine tetel = BevasarloLista.
                  Where(p => p.AruID == Aru.AruID).
                  FirstOrDefault();
                if (tetel == null)
                {
                    BevasarloLista.Add(new ErtekesitesReszletekLine
                    {
                        AruID = Aru.AruID,
                        EgysegAr = Aru.EgysegAr,
                        AruMennyiseg = 1,
                        AruMegnevezes = Aru.AruMegnevezes                        
                    });
                }
                else
                {
                    tetel.AruMennyiseg += (short)nMennyiseg;
                }
            }

            public void RemoveTetel(AruKeszlet Aru)
            {
                BevasarloLista.RemoveAll(p => p.AruID == Aru.AruID);
            }

            public decimal TeljesErtek()
            {
                return (BevasarloLista.Sum(p => Convert.ToDecimal(p.AruMennyiseg) * p.EgysegAr));
            }

            public void ClearAll()
            {
                BevasarloLista.Clear();
            }
        }
    }
}