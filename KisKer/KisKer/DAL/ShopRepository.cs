using KisKer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KisKer.DAL
{
    public class ShopRepository : IShopRepository, IDisposable
    {
        #region context
        private KiskerEntities _context;
        public ShopRepository(KiskerEntities context)
        {
            _context = context;
        }
        private bool disposed = false;        

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        public IEnumerable<AruKeszlet> AruKeszletek()
        {
            return _context.AruKeszletek;
        }
        public List<DateTime> GetDates(int id)
        {
            List<DateTime> dates = new List<DateTime>();
            var datetimes = _context.ErtekesitesReszletek.Where(p => p.AruID == id).Select(p => p.ErtekesitesID);
            foreach (var time in datetimes)
            {
                dates.Add(_context.Ertekesitesek.Where(p => p.ErtekesitesID == time).Select(p => p.ErtekesitesDatum).FirstOrDefault());
            }
            return dates;
        }
        public List<decimal> GetAruMennyiseg(int id)
        {
            List<decimal> mennyiseg = new List<decimal>();
            var arumennyiseg = _context.ErtekesitesReszletek.Where(p => p.AruID == id).Select(p => p.AruMennyiseg);
            foreach (var menyi in arumennyiseg)
            {
                mennyiseg.Add(menyi);
            }
            return mennyiseg;
        }
        public IEnumerable<AruKategoria> GetCategories()
        {
            var categories = from s in _context.AruKategoriak
                             orderby s.AruKategoriaMegnevezes
                             select s;
            return categories;
        }
        public IList<ErtekesitesReszlet> GetReszletek()
        {
            return _context.ErtekesitesReszletek.ToList();
        }
        public IList<AruKeszlet> GetAruKeszlet()
        {
            return _context.AruKeszletek.ToList();
        }
        public string GetKategoriaNev(int id)
        {
            string KatName = _context.AruKeszletek.Where(k => k.AruID == id).Select(k => k.AruMegnevezes).FirstOrDefault();
            return KatName;
        }
        public int GetKategoriaId(int id)
        {
            int KatId = _context.AruKeszletek.Where(k => k.AruID == id).Select(k => k.AruKategoriaID).FirstOrDefault();
            return KatId;
        }     
        public decimal GetEgysegAr(int id)
        {            
            decimal egysegar = _context.AruKeszletek.Where(k => k.AruID == id).Select(k => k.EgysegAr).FirstOrDefault();
            return egysegar;
        }
        public decimal GetTeljesAr(int id)
        {
            decimal egysegar = _context.AruKeszletek.Where(k => k.AruID == id).Select(k => k.EgysegAr).FirstOrDefault();
            decimal darabszam = _context.ErtekesitesReszletek.Where(k => k.AruID == id).Select(k => k.AruMennyiseg).FirstOrDefault();
            return egysegar * darabszam;
        }
        public string GetMertekEgyseg(int id)
        {
            string mertekegyseg = _context.AruKeszletek.Where(k => k.AruID == id).Select(k => k.Mertekegyseg).FirstOrDefault();
            return mertekegyseg;
        }
        public int GetMertekEgysegAzon(int id)
        {
            int mertekegysegazon = _context.AruKeszletek.Where(k => k.AruID == id).Select(k => k.MertekegysegAzon).FirstOrDefault();
            return mertekegysegazon;
        }        
        public string GetAruNev(int id)
        {
            string arunev = _context.AruKeszletek.Where(k => k.AruID == id).Select(k => k.AruMegnevezes).FirstOrDefault();
            return arunev;
        }
    }
}
