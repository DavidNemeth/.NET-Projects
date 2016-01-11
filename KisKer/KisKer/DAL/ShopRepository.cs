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


        public IList<AruKeszlet> GetKeszlet()
        {
            return _context.AruKeszlet.ToList();
        }
        public IList<ErtekesitesReszlet> GetReszletek()
        {
            return _context.ErtekesitesReszletek.ToList();
        }
        public IList<AruKeszlet> GetKategoria(ErtekesitesReszlet Aru)
        {
            var categoryIds = _context.AruKeszlet.Where(k => k.AruKategoriaID == Aru.AruID).Select(k => k.AruKategoriaID).ToList();
            List<AruKeszlet> kategorianev = new List<AruKeszlet>();
            foreach (var catid in categoryIds)
            {
                kategorianev.Add(_context.AruKeszlet.Where(k => k.AruKategoriaID == catid).FirstOrDefault());
            }
            return kategorianev;
        }
        public IList<Ertekesites> GetDate(ErtekesitesReszlet Aru)
        {
            var ertekesitesIds = _context.Ertekesitesek.Where(k => k.ErtekesitesID == Aru.ErtekesitesID).Select(k => k.ErtekesitesID).ToList();
            List<Ertekesites> ertekesitesDates = new List<Ertekesites>();
            foreach (var dateid in ertekesitesIds)
            {
                ertekesitesDates.Add(_context.Ertekesitesek.Where(d => d.ErtekesitesID == dateid).FirstOrDefault());
            }
            return ertekesitesDates;
        }
    }
}