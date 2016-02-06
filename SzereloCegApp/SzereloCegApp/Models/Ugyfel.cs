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
        [Display(Name ="Felvétel Dátuma")]
        [Required(ErrorMessage ="Kérem adja meg a felvétel idejét")]        
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime FelvetelIdeje { get; set; }
        [Display(Name ="Fizetve")]            
        public bool Fizetve { get; set; }
        [Required(ErrorMessage = "Kérem adja meg a telefonszámot")]
        [Display(Name = "Telefonszám")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$", ErrorMessage = "Telefonszám nem megfelelő")]
        public string UgyfelTelefon { get; set; }

        //
        public int SzereloID { get; set; }
        public virtual Szerelo Szerelo { get; set; }
        public virtual ICollection<GepJarmu> GepJarmu { get; set; }
        #region helpers

        [Display(Name ="Tulajdonos")]
        public string UgyfelNev
        {
            get
            {
                return Vezetéknév + (" ") + Keresztnév;
            }
        }
        #endregion       
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if  (Szulido.GetValueOrDefault() > DateTime.Now.AddYears(-10))
            {
                yield return new ValidationResult("Születési dátum nem megfelelő", new[] { "Szulido" });
            }
            if (Szulido.GetValueOrDefault() < DateTime.Now.AddYears(-120))
            {
                yield return new ValidationResult("Ilyen idősen már csak nem vezetnék", new[] { "Szulido" });
            }
            if (FelvetelIdeje > DateTime.Now)
            {
                yield return new ValidationResult("Kérem a mai napot adja meg felvételnek", new[] { "FelvetelIdeje" });
            }
            if (FelvetelIdeje < DateTime.Now.AddYears(-1))
            {
                yield return new ValidationResult("Korábbi évekre nem vehető fel javítás", new[] { "FelvetelIdeje" });
            }
        }
    }
}