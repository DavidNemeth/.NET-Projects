using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SzereloCegApp.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Felhasználóinév Szükséges")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Jelszó Szükséges")]
        public string Password { get; set; }
    }
}