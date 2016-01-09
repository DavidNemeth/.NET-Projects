using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalApp.Models
{
    public class Doctor
    {
        public Doctor()
        {
            this.Patients = new HashSet<Patient>();
        }
        public int ID { get; set; }
        [Required(ErrorMessage = "Név kitöltése kötelező")]
        [Display(Name = "Keresztnév")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Név kitöltése kötelező")]
        [Display(Name = "Vezetéknév")]
        public string LastName { get; set; }
        [Display(Name = "Betegei")]
        public virtual ICollection<Patient> Patients { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Doktor Neve")]
        public string DoctorName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }
    }
}