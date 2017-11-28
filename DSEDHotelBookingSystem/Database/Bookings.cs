using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSEDHotelBookingSystem.Database
{
    class Bookings
    {
        public int RoomID { get; set; }
        public int GuestID { get; set; }
        public int NumOfGuests { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public IEnumerable AllAvailableRooms()
        {
            using (var context = new HotelEntities())
            {
                var alldata = from ar in context.Rooms
                              where ar.RoomTypeIDFK == ar.RoomType.RoomTypeID && ar.Sleeps >= NumOfGuests
                              select new
                              {
                                  ar.RoomID,
                                  ar.RoomName,
                                  ar.RoomType.Room_Type,
                                  ar.Cost,
                                  ar.Sleeps,
                                  ar.SingleBeds,
                                  ar.QueenBeds
                              };
                return alldata.ToList();
            }
        }

        public IEnumerable BookRoom()
        {
            using (var context = new HotelEntities())
            {
                var alldata = from br in context.Bookings
                              where br.RoomIDFK == br.Room.RoomID && br.GuestIDFK == br.Guest.GuestID
                              select new
                              {
                                  br.Guest.FullName,
                                  br.Room.RoomName,
                                  br.NumOfGuests,
                                  br.CheckIn,
                                  br.CheckOut
                              };
                return alldata.ToList();
            }
        }

        public void NewBooking()
        {
            using (var context = new HotelEntities())
            {
                var b = new Booking();
                b.GuestIDFK = GuestID;
                b.RoomIDFK = RoomID;
                b.NumOfGuests = NumOfGuests;
                b.CheckIn = CheckIn;
                b.CheckOut = CheckOut;


                context.Bookings.Add(b);
                context.SaveChanges();
            }
        }

        public IEnumerable AllBookings()
        {
            using (var context = new HotelEntities())
            {
                var alldata = from b in context.Bookings
                              where b.GuestIDFK == b.Guest.GuestID && b.RoomIDFK == b.Room.RoomID
                              orderby b.RoomIDFK
                              select new
                              {
                                  b.BookingID,
                                  b.RoomIDFK,
                                  b.Room.RoomName,
                                  b.GuestIDFK,
                                  b.Guest.FullName,
                                  b.NumOfGuests,
                                  b.CheckIn,
                                  b.CheckOut
                              };
                return alldata.ToList();
            }
        }
    }
}
