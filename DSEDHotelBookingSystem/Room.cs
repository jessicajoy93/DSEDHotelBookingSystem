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
    
    public partial class Room
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Room()
        {
            this.Bookings = new HashSet<Booking>();
            this.Billings = new HashSet<Billing>();
        }
    
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public Nullable<int> SingleBeds { get; set; }
        public Nullable<int> QueenBeds { get; set; }
        public Nullable<int> Sleeps { get; set; }
        public Nullable<int> Cost { get; set; }
        public Nullable<int> RoomTypeIDFK { get; set; }
    
        public virtual RoomType RoomType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Billing> Billings { get; set; }
    }
}
