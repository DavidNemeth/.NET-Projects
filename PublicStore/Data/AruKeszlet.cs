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
    
    public partial class AruKeszlet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AruKeszlet()
        {
            this.ErtekesitesReszletek = new HashSet<ErtekesitesReszlet>();
        }
    
        public int AruID { get; set; }
        public int AruKategoriaID { get; set; }
        public string AruMegnevezes { get; set; }
        public int MertekegysegAzon { get; set; }
        public string Mertekegyseg { get; set; }
        public decimal EgysegAr { get; set; }
        public decimal Raktarkeszlet { get; set; }
    
        public virtual AruKategoria AruKategoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ErtekesitesReszlet> ErtekesitesReszletek { get; set; }
    }
}
