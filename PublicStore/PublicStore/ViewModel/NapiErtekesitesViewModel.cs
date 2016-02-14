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
        private IStoreRepository repo = new StoreRepository();
        public ObservableCollection<AruKategoria> AruKategoriak { get; set; }
        public NapiErtekesitesViewModel()
        {
             AruKategoriak = new ObservableCollection<AruKategoria>(repo.GetAruKategoriak().Result);
        }         
    }
}
