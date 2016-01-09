using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalApp.Models
{
    public class Condition
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Kérem adja meg a diagnózist")]
        [Display(Name ="Diagnózis")]
        public string ConditionName { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}