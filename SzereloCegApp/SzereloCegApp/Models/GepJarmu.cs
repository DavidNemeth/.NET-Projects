
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SzereloCegApp.Models
{
    public class GepJarmu : IValidatableObject
    {
        public int ID { get; set; }
        [Display(Name = "Márka")]
        [Required(ErrorMessage = "A mező kitöltése kötelező")]
        public string Marka { get; set; }
        [Display(Name = "Típus")]
        [Required(ErrorMessage ="A mező kitöltése kötelező")]
        public string Tipus { get; set; }
        [Display(Name = "Rendszám")]
        [MaxLength(100)]              
        [Required(ErrorMessage ="A rendszám megadása kötelező")]
        public string Rendszam { get; set; }
        [Display(Name = "Gyártási Év")]
        [Required(ErrorMessage = "Kérem adja meg a Gépjármű pontos Gyártási Idejét")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? GyartasiEv { get; set; }
        public int UgyfelID { get; set; }
        public virtual Ugyfel Ugyfel { get; set; }
        public virtual ICollection<Diagnosztika> Diagnosztikák { get; set; }
        #region helper
        [Display(Name ="Gépjármű")]
        public string Auto
        {
            get
            {
                return Marka + (" ") + Tipus;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (GyartasiEv.GetValueOrDefault() > DateTime.Now)
            {
                yield return new ValidationResult("TimeTravel ??", new[] { "GyartasiEv" });
            }
            if (GyartasiEv.GetValueOrDefault() < DateTime.Now.AddYears(-30))
            {
                yield return new ValidationResult("30 Évnél öregebb auto javítását nem vállaljuk", new[] { "GyartasiEv" });
            }
        }
        #endregion

    }
}