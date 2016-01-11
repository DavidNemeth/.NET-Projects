using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KisKer.ViewModels
{
    public class NapiAdatokViewModel
    {
        public DateTime ErtekesitesDatum { get; set; }
        public string AruKategoriaMegnevezes { get; set; }
        public int AruKategoriaID { get; set; }
        public string Mertekegyseg { get; set; }
        public int MertekegysegAzon { get; set; }
        public int EgysegAr { get; set; }
        public int AruMennyiseg { get; set; }
        public int AruID { get; set; }
        public string AruMegnevezes { get; set; }
    }
}