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

        public IEnumerable<Ertekesites> GetDates()
        {
            var ertekesitesDate = from s in _context.Ertekesitesek
                                  orderby s.ErtekesitesDatum
                                  select s;
            return ertekesitesDate;
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
        public decimal GetAruMennyiseg(int id)
        {
            decimal arumennyiseg = _context.ErtekesitesReszletek.Where(k => k.AruID == id).Select(k => k.AruMennyiseg).FirstOrDefault();
            return arumennyiseg;
        }
        public string GetAruNev(int id)
        {
            string arunev = _context.AruKeszletek.Where(k => k.AruID == id).Select(k => k.AruMegnevezes).FirstOrDefault();
            return arunev;
        }
        

        //public IList<AruKeszlet> GetEgysegAr(ErtekesitesReszlet Aru)
        //{
        //    var aruIds = _context.ErtekesitesReszletek.Where(k => k.AruID == Aru.AruID).Select(k => k.AruID).ToList();
        //    List<AruKeszlet> egysegarak = new List<AruKeszlet>();
        //    foreach (var arid in aruIds)
        //    {
        //        egysegarak.Add(_context.AruKeszlet.Where(d => d.AruID == arid).FirstOrDefault());
        //    }
        //    return egysegarak;
        //}
        //public IList<Ertekesites> GetDate(ErtekesitesReszlet Aru)
        //{
        //    var ertekesitesIds = _context.Ertekesitesek.Where(k => k.ErtekesitesID == Aru.ErtekesitesID).Select(k => k.ErtekesitesID).ToList();
        //    List<Ertekesites> ertekesitesDates = new List<Ertekesites>();
        //    foreach (var dateid in ertekesitesIds)
        //    {
        //        ertekesitesDates.Add(_context.Ertekesitesek.Where(d => d.ErtekesitesID == dateid).FirstOrDefault());
        //    }
        //    return ertekesitesDates;
        //}
        //public IList<AruKeszlet> GetKategoriaId(ErtekesitesReszlet Aru)
        //{
        //    var categoryIds = _context.AruKeszlet.Where(k => k.AruKategoriaID == Aru.AruID).Select(k => k.AruKategoriaID).ToList();
        //    List<AruKeszlet> kategorianev = new List<AruKeszlet>();
        //    foreach (var catid in categoryIds)
        //    {
        //        kategorianev.Add(_context.AruKeszlet.Where(k => k.AruKategoriaID == catid).FirstOrDefault());
        //    }
        //    return kategorianev;
        //}
    }
}
