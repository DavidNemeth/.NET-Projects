using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SzereloCegApp.Models
{
    public class Kliens
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Kérem adja meg a Kliens Vezetéknevét")]
        public string Vezetéknév { get; set; }
        [Required(ErrorMessage = "Kérem adja meg a Kliens Keresztnevét")]
        public string Keresztnév { get; set; }
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime? Szulido { get; set; }
        //

        [Display(Name ="Felvétel Ideje")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FelvetelIdeje { get; set; }
        [Display(Name ="Sürgős Javítás")]
        [Required]        
        public bool Surgos { get; set; }

        //
        public int SzereloID { get; set; }//foreign key
        public virtual Szerelo Szerelo { get; set; }
    }
}