using KisKer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisKer.DAL
{
    public interface IShopRepository : IDisposable
    {
        void AddErtekesites(int AruID, DateTime selectedDate, decimal arumennyiseg);
        void Save();
        IEnumerable<AruKeszlet> AruKeszletek();
        IList<ErtekesitesReszlet> GetReszletek();
        List<DateTime> GetDates(int id);
        string GetKategoriaNev(int id);
        int GetKategoriaId(int id);
        decimal GetEgysegAr(int id);
        decimal GetTeljesAr(int id);
        string GetMertekEgyseg(int id);
        int GetMertekEgysegAzon(int id);
        List<decimal> GetAruMennyiseg(int id);
        string GetAruNev(int id);
        IEnumerable<AruKategoria> GetCategories();
        IList<AruKeszlet> GetAruKeszlet();        
    }
}
        