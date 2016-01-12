using KisKer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KisKer.ViewModels
{
    public class NapiAdatokViewModel
    {
        //public IList<ErtekesitesReszlet> ErtekesitesReszletek { get; set; }
        //public IList<Ertekesites> Ertekesitesek { get; set; }
        //public IList<AruKeszlet> AruKeszletek { get; set; }
        //public IList<AruKategoria> AruKategoriak { get; set; }     
        public int ID { get; set; }       
        public string AruKategoriaMegnevezes { get; set; }
        public int AruKategoriaID { get; set; }
        public string Mertekegyseg { get; set; }
        public int MertekegysegAzon { get; set; }
        public decimal EgysegAr { get; set; }
        public decimal AruMennyiseg { get; set; }        
        public int AruID { get; set; }
        public string AruMegnevezes { get; set; }
        public decimal TeljesAr { get; set; }
    }
}