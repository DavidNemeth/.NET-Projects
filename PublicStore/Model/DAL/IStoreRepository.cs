using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL
{
    public interface IStoreRepository : IDisposable
    {
        IList<AruKategoria> GetCategories();
        IList<AruKeszlet> GetAruKeszletek();
        IList<Ertekesites> GetErtekesitesek();
        IList<ErtekesitesReszlet> GetErtekesitesReszletek();
        IList<AruKeszlet> KeszletForCategory(int CategoryID);
        IList<ErtekesitesReszlet> GetErtekesitesireszletForAru(AruKeszlet reszletek);
        IList<AruKeszlet> GetArukForCategory(AruKategoria aruk);
        IList<ErtekesitesReszlet> GetErtekesitesreszletForErtekesites(Ertekesites ertekesites);

    }
}
