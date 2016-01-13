using KisKer.Models;
using KisKer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KisKer.ViewModels
{
    public class AdatFelvitelViewModel
    {
        public ReszletekViewModel DataModell { get; set; }
        public string ReturnUrl { get; set; }
    }
    public class AdatFelvitelLine
    {
        public int AruID { get; set; }
        public DateTime ErtekesitesDatum { get; set; }
        public string AruMegnevezes { get; set; }
        public decimal EgysegAr { get; set; }
        public int AruMennyiseg { get; set; }
    }
}
public class ReszletekViewModel
{
    private List<AdatFelvitelLine> BevasarloLista = new List<AdatFelvitelLine>();
    public IEnumerable<AdatFelvitelLine> Tetelek
    {
        get
        {
            return (BevasarloLista);
        }
    }
    public void AddTetel(AruKeszlet Aru, int nMennyiseg)
    {
        AdatFelvitelLine tetel = BevasarloLista.
          Where(p => p.AruID == Aru.AruID).
          FirstOrDefault();
        if (tetel == null)
        {
            BevasarloLista.Add(new AdatFelvitelLine
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

