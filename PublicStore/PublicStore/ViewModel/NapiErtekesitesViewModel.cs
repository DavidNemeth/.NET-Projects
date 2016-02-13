using PublicStore.Model;
using PublicStore.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicStore.ViewModel
{
    public class NapiErtekesitesViewModel : BaseViewModel
    {
        private IStoreRepository context;
        //private Ertekesites Ertekesites
        //private AruKeszlet Arukeszlet;
        //private AruKategoria Arukategoria;
        //private ErtekesitesReszlet ErtekesitesReszlet;
        public NapiErtekesitesViewModel()
        {
            this.context = new StoreRepository(new KiskerDbEntities());
        }
        public ObservableCollection<string> Arukategoriak()
        {
            var kategoriak = new ObservableCollection<string>();
            //foreach (var item in context.GetCategories())
            //{
            //    kategoriak.Add(item.AruKategoriaMegnevezes);
            //}
            kategoriak.Add("LOL");
            return kategoriak;
        }        
    }
}
