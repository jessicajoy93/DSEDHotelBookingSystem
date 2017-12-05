//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DSEDHotelBookingSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class Booking
    {
        public int BookingID { get; set; }
        public Nullable<int> RoomIDFK { get; set; }
        public Nullable<int> GuestIDFK { get; set; }
        public Nullable<int> NumOfGuests { get; set; }
        public Nullable<System.DateTime> CheckIn { get; set; }
        public Nullable<System.DateTime> CheckOut { get; set; }
        public Nullable<int> TotalNights { get; set; }
        public Nullable<bool> LateCheckOut { get; set; }
        public Nullable<bool> Wifi { get; set; }
    
        public virtual Guest Guest { get; set; }
        public virtual Room Room { get; set; }
    }
}
