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
    
    public partial class TBL_ClientPM
    {
        public TBL_ClientPM()
        {
            this.TBL_Project = new HashSet<TBL_Project>();
        }
    
        public int ClientPMID { get; set; }
        public Nullable<int> ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AlternateEmail { get; set; }
        public string LandlineNo { get; set; }
        public string Mobile { get; set; }
        public string SkypeID { get; set; }
        public Nullable<bool> Status { get; set; }
    
        public virtual TBL_Client TBL_Client { get; set; }
        public virtual ICollection<TBL_Project> TBL_Project { get; set; }
    }
}
