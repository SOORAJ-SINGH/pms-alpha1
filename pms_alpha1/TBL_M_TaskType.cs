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
    
    public partial class TBL_M_TaskType
    {
        public TBL_M_TaskType()
        {
            this.TBL_ProjectTask = new HashSet<TBL_ProjectTask>();
        }
    
        public long TaskTypeID { get; set; }
        public string TaskType { get; set; }
        public bool Status { get; set; }
    
        public virtual ICollection<TBL_ProjectTask> TBL_ProjectTask { get; set; }
    }
}
