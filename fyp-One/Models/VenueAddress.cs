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
    
    public partial class VenueAddress
    {
        public int Id { get; set; }
        public string vContactName { get; set; }
        public string vStreetAddress { get; set; }
        public string vCity { get; set; }
        public string vCountry { get; set; }
        public int vZipcode { get; set; }
        public string vContactnum1 { get; set; }
        public string vContactnum2 { get; set; }
        public Nullable<decimal> vlang { get; set; }
        public Nullable<decimal> vlong { get; set; }
        public int venueInfo_id { get; set; }
    
        public virtual VenueInfo VenueInfo { get; set; }
    }
}
