//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pms_alpha1
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_M_Language
    {
        public TBL_M_Language()
        {
            this.TBL_ProjectTask = new HashSet<TBL_ProjectTask>();
            this.TBL_ProjectTask1 = new HashSet<TBL_ProjectTask>();
            this.TBL_VendorLanguagePair = new HashSet<TBL_VendorLanguagePair>();
            this.TBL_VendorLanguagePair1 = new HashSet<TBL_VendorLanguagePair>();
        }
    
        public int LanguageID { get; set; }
        public string Language { get; set; }
        public Nullable<bool> Status { get; set; }
    
        public virtual ICollection<TBL_ProjectTask> TBL_ProjectTask { get; set; }
        public virtual ICollection<TBL_ProjectTask> TBL_ProjectTask1 { get; set; }
        public virtual ICollection<TBL_VendorLanguagePair> TBL_VendorLanguagePair { get; set; }
        public virtual ICollection<TBL_VendorLanguagePair> TBL_VendorLanguagePair1 { get; set; }
    }
}
