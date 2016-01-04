using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SzereloCegApp.Models
{
    public class Kliens
    {
        public int ID { get; set; }        
        public string Vezetéknév { get; set; }
        public string Keresztnév { get; set; }
        public DateTime? Szulido { get; set; }
        //
        public int SzereloID { get; set; }//foreign key
        public virtual Szerelo Szerelo { get; set; }
    }
}