//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TravelSoloApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Booking
    {
        public int Id { get; set; }
        public System.DateTime BookingDate { get; set; }
        public int TripId { get; set; }
        public string AspNetUserId { get; set; }
    
        public virtual Trip Trip { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual BookingFeedback BookingFeedback { get; set; }
    }
}
