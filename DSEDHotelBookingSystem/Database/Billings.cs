using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSEDHotelBookingSystem.Database
{
    class Billings
    {
        HotelEntities _context = new HotelEntities();
        public IEnumerable AllBillings()
        {
            var allbookings = _context.Bookings.OrderBy(b => b.BookingID);
            return allbookings.ToList();
        }
    }
}
