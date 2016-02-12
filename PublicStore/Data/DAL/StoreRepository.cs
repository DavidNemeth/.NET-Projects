using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public class StoreRepository : IStoreRepository, IDisposable
    {
        public KiskerDbEntities context;
        public StoreRepository(KiskerDbEntities _context)
        {
            _context = context;
        }
        public IList<AruKeszlet> GetAruKeszletek()
        {
            return context.AruKeszletek.ToList();
        }
        public IList<ErtekesitesReszlet> GetErtekesitesReszletek()
        {
            return context.ErtekesitesReszletek.ToList();
        }
        public IList<Ertekesites> GetErtekesitesek()
        {
            return context.Ertekesitesek.ToList();
        }

        public IList<AruKategoria> GetCategories()
        {
            return context.AruKategoriak.ToList();
        }

        public IList<AruKeszlet> KeszletForCategory(int CategoryID)
        {
            return context.AruKeszletek.Where(p => p.AruKategoriaID == CategoryID).ToList();
        }
        public IList<ErtekesitesReszlet> GetErtekesitesireszletForAru(AruKeszlet reszletek)
        {
            var reszletekIds = context.ErtekesitesReszletek.Where(p => p.AruID == reszletek.AruID).Select(p => p.AruID).ToList();
            List<ErtekesitesReszlet> ertekesitesreszletek = new List<ErtekesitesReszlet>();
            foreach (var reszletekid in reszletekIds)
            {
                ertekesitesreszletek.Add(context.ErtekesitesReszletek.Where(p => p.AruID == reszletekid).FirstOrDefault());
            }
            return ertekesitesreszletek;
        }
        public IList<AruKeszlet> GetArukForCategory(AruKategoria aruk)
        {
            var aruIds = context.AruKeszletek.Where(p => p.AruKategoriaID == aruk.AruKategoriaID).Select(p => p.AruKategoriaID).ToList();
            List<AruKeszlet> arukeszlet = new List<AruKeszlet>();
            foreach (var arukId in aruIds)
            {
                arukeszlet.Add(context.AruKeszletek.Where(p => p.AruKategoriaID == arukId).FirstOrDefault());
            }
            return arukeszlet;
        }
        public IList<ErtekesitesReszlet> GetErtekesitesreszletForErtekesites(Ertekesites ertekesites)
        {
            var ErtekesitesIDs = context.ErtekesitesReszletek.Where(p => p.ErtekesitesID == ertekesites.ErtekesitesID).Select(p => p.ErtekesitesID).ToList();
            List<ErtekesitesReszlet> ErtekesitesReszletek = new List<ErtekesitesReszlet>();
            foreach (var ertekId in ErtekesitesIDs)
            {
                ErtekesitesReszletek.Add(context.ErtekesitesReszletek.Where(p => p.ErtekesitesID == ertekId).FirstOrDefault());
            }
            return ErtekesitesReszletek;
        }






        #region dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }
        #endregion
    }
}
