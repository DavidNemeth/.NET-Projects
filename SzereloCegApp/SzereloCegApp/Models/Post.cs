using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SzereloCegApp.Models
{
    public class Post
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Kérem adjon meg egy rövid leírást")]
        [Display(Name = "Rövid leírás")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Töltse ki a bejegyzést")]
        [Display(Name ="Bejegyzés")]
        public string Body { get; set; }        
        [DataType(DataType.Date)]
        public DateTime PostedDate { get; set; }
        public int SzereloID { get; set; }

        public virtual Szerelo Szerelo { get; set; }
    }
}