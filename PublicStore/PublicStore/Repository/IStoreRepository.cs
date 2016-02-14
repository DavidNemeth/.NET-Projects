using PublicStore.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicStore.Repository
{
    public interface IStoreRepository : IDisposable
    {
        Task<List<AruKategoria>> GetAruKategoriak();
    }
}
