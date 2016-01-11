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
        IList<AruKeszlet> GetKeszlet();
        IList<ErtekesitesReszlet> GetReszletek();
        DateTime GetErtekesitesDate(int id);
        decimal GetTermekAr(int id);
        string GetKategoriaNev(int id);
        int GetKategoriaId(int id);
    }
}
        