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
        IList<AruKategoria> GetCategories();
        IList<AruKeszlet> GetAruKeszletek();
        IEnumerable<Ertekesites> GetErtekesitesek();
        IList<ErtekesitesReszlet> GetErtekesitesReszletek();
        IList<AruKeszlet> KeszletForCategory(int CategoryID);
        IList<ErtekesitesReszlet> GetErtekesitesireszletForAru(AruKeszlet reszletek);
        IList<AruKeszlet> GetArukForCategory(AruKategoria aruk);
        IList<ErtekesitesReszlet> GetErtekesitesreszletForErtekesites(Ertekesites ertekesites);
    }
}
