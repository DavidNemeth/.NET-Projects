using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalApp.ViewModels
{
    public class PatientConditionsViewModel
    {
        public int ConditionID { get; set; }
        public string ConditionName { get; set; }
        public bool Assigned { get; set; }
    }
}