using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SzereloCegApp.Models
{
    public class Szerelo
    {
        //opcionális (null error refnél)
        public Szerelo()
        {
            this.Kliensek = new HashSet<Kliens>();
        }
        public int ID { get; set; }
        public string Vezetéknév { get; set; }
        public string Keresztnév { get; set; }
        public virtual ICollection<Kliens> Kliensek { get; set; }
    }
}