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
        IList<ErtekesitesReszlet> GetReszletek();
        IEnumerable<Ertekesites> GetDates();
        string GetKategoriaNev(int id);
        int GetKategoriaId(int id);
        decimal GetEgysegAr(int id);
        decimal GetTeljesAr(int id);
        string GetMertekEgyseg(int id);
        int GetMertekEgysegAzon(int id);
        decimal GetAruMennyiseg(int id);
        string GetAruNev(int id);
        IEnumerable<AruKategoria> GetCategories();
        IList<AruKeszlet> GetAruKeszlet();
    }
}
        