using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public interface IStoreRepository : IDisposable
    {
        IList<AruKategoria> GetCategories();
        IList<AruKeszlet> GetAruKeszletek();
        IList<Ertekesites> GetErtekesitesek();
        IList<ErtekesitesReszlet> GetErtekesitesReszletek();
        IList<AruKeszlet> KeszletForCategory(int CategoryID);
        IList<ErtekesitesReszlet> GetAruErtekesitesReszletek(AruKeszlet reszletek);
        IList<AruKeszlet> GetArukForCategory(AruKategoria aruk);
        IList<ErtekesitesReszlet> GetErtekesitesreszletForErtekesites(Ertekesites ertekesites);

    }
}
