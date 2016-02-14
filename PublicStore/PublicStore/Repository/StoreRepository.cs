using PublicStore.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicStore.Repository
{
    public class StoreRepository : IStoreRepository, IDisposable
    {
        KiskerDbEntities context = new KiskerDbEntities();     
        
        public Task<List<AruKategoria>> GetAruKategoriak()
        {
            return context.AruKategoriak.ToListAsync();
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
