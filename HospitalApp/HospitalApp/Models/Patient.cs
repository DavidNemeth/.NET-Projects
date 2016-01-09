using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalApp.Models
{
    public class Patient : IValidatableObject
    {
        public int ID { get; set; }
        [Required]
        [RegularExpression("^\\d{9}$",ErrorMessage ="Taj szám pontosan 9 számjegyű")]
        [StringLength(9)]
        [Index(IsUnique = true)] //egyedi azonosító
        [Display(Name ="Taj Szám")]
        public string TB { get; set; }
        [Required(ErrorMessage ="Név kitöltése kötelező")]
        [Display(Name = "Keresztnév")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Név kitöltése kötelező")]
        [Display(Name = "Vezetéknév")]
        public string LastName { get; set; }        
        [DataType(DataType.Date)]
        [Display(Name ="Születési Idő")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime? DoB { get; set; }
        [Required(ErrorMessage ="Látogatások száma nem hagyható üresen")]
        [Display(Name = "Látogatás/Év")]
        [Range(1,50,ErrorMessage ="A látogatások száma 1 és 50 között lehetséges")]
        public byte YrVisits { get; set; }
        [Required(ErrorMessage ="Kérem válassza ki a beteg doktorát")]
        [Display(Name ="Doktor")]
        public int DoctorID { get; set; }
        [Display(Name = "Doktorok")]
        public virtual Doctor Doctor { get; set; }
        public ICollection<Condition> Conditions { get; set; }




        [ScaffoldColumn(false)]
        [Display(Name ="Beteg Neve")]
        public string PatientName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DoB.GetValueOrDefault() > DateTime.Now)
            {
                yield return new ValidationResult("Születési idő nem lehet a jövőben");
            }
        }
    }
}