//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ErtekesitesReszlet
    {
        public int AruID { get; set; }
        public int ErtekesitesID { get; set; }
        public decimal AruMennyiseg { get; set; }
    
        public virtual AruKeszlet AruKeszlet { get; set; }
        public virtual Ertekesites Ertekesites { get; set; }
    }
}
