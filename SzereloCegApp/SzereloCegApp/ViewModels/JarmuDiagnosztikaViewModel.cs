using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SzereloCegApp.ViewModels
{
    public class JarmuDiagnosztikaViewModel
    {
        public int DiagnosztikaID { get; set; }
        public string DiagnosztikaNeve { get; set; }
        public bool Hibas { get; set; }
    }
}