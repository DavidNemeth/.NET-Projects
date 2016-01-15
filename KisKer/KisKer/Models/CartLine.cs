using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KisKer.Models
{
    public class CartLine
    {
        public AruKeszlet Product { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:00}")]
        public decimal AruMennyiseg { get; set; }   
    }
}