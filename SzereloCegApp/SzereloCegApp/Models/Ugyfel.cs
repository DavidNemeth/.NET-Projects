using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SzereloCegApp.Models
{
    public class Ugyfel : IValidatableObject
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Kérem adja meg a Kliens Vezetéknevét")]
        public string Vezetéknév { get; set; }
        [Required(ErrorMessage = "Kérem adja meg a Kliens Keresztnevét")]
        public string Keresztnév { get; set; }
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        [Display(Name = "Születési Idő")]
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

        #region helpers
        
        [Display(Name ="Ügyfél")]
        public string UgyfelNev
        {
            get
            {
                return Vezetéknév + (" ") + Keresztnév;
            }
        }
        #endregion
        //hiba teszt
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if  (Szulido.GetValueOrDefault() > DateTime.Now)
            {
                yield return new ValidationResult("TimeTravel ??", new[] { "Szulido" });
            }
            if (Szulido.GetValueOrDefault() < DateTime.Now.AddYears(-120))
            {
                yield return new ValidationResult("Ilyen idősen már csak nem vezetnék", new[] { "Szulido" });
            }
            if (FelvetelIdeje > DateTime.Now.AddYears(1))
            {
                yield return new ValidationResult("Csak Idei javítás vállalható", new[] { "FelvetelIdeje" });
            }
            if (FelvetelIdeje < DateTime.Now.AddYears(-1))
            {
                yield return new ValidationResult("Korábbi évekre nem vehető fel javítás", new[] { "FelvetelIdeje" });
            }
        }
    }
}