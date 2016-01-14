using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KisKer.Models
{
    public class CartLine
    {
        public AruKeszlet Product { get; set; }
        public int AruMennyiseg { get; set; }   
    }
}