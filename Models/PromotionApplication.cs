//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppleWatch.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PromotionApplication
    {
        public int Id { get; set; }
        public int WatchId { get; set; }
        public int PromotionId { get; set; }
        public System.DateTime FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
    
        public virtual Promotion Promotion { get; set; }
        public virtual Watch Watch { get; set; }
    }
}
