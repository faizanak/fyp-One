//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace fyp_One.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class venue_rate
    {
        public int Id { get; set; }
        public int venue_Id { get; set; }
        public int user_Id { get; set; }
        public Nullable<decimal> rate { get; set; }
    
        public virtual User User { get; set; }
        public virtual VenueInfo VenueInfo { get; set; }
    }
}
