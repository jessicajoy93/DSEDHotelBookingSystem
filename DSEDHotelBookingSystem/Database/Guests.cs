using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSEDHotelBookingSystem.Database
{
    class Guests
    {
        public int GuestID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

        public IEnumerable AllGuests()
        {
            using (var context = new HotelEntities())
            {
                var alldata = from g in context.Guests
                              select new
                              {
                                  g.GuestID,
                                  g.FirstName,
                                  g.LastName,
                                  g.Address,
                                  g.Suburb,
                                  g.City,
                                  g.Postcode,
                                  g.Country,
                                  g.Phone,
                                  g.Mobile,
                                  g.Email
                              };
                return alldata.ToList();
            }
        }

        public void InsertGuest()
        {
            using (var context = new HotelEntities())
            {
                var g = new Guest();
                g.FirstName = FirstName;
                g.LastName = LastName;
                g.Address = Address;
                g.Suburb = Suburb;
                g.City = City;
                g.Postcode = Postcode;
                g.Country = Country;
                g.Phone = Phone;
                g.Mobile = Mobile;
                g.Email = Email;

                context.Guests.Add(g);
                context.SaveChanges();
            }
        }
    }
}
