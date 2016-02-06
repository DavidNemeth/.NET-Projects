using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SzereloCegApp.Models
{
    public class Szerelo
    {
        //(null error)
        public Szerelo()
        {
            this.Ugyfelek = new HashSet<Ugyfel>();
        }     

        public int ID { get; set; }
        [Required(ErrorMessage = "Kérem adja meg a szerelő Vezetéknevét")]
        public string Vezetéknév { get; set; }
        [Required(ErrorMessage = "Kérem adja meg a szerelő Keresztnevét")]
        public string Keresztnév { get; set; }
        [Required(ErrorMessage = "Kérem adja meg a telefonszámot")]
        [Display(Name = "Telefonszám")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$", ErrorMessage = "Telefonszám nem megfelelő")]
        public string SzereloTelefon { get; set; }
        public virtual ICollection<Ugyfel> Ugyfelek { get; set; }
        public virtual ICollection<Post> Posts { get; set; }



        #region helpers
        [Display(Name ="Szerelő")]
        public string SzereloNev
        {
            get
            {
                return Vezetéknév + (" ") + Keresztnév;
            }
        }
#endregion
    }
}