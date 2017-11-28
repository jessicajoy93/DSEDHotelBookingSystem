using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSEDHotelBookingSystem.Database
{
    class Guests
    {
        public int GuestID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
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
                g.FullName = FullName;
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

        public void UpdateGuest()
        {
            using (var context = new HotelEntities())
            {
                var query = from g in context.Guests where g.GuestID == GuestID select g;

                var guest = query.FirstOrDefault(); //gets the first one
                guest.FirstName = FirstName;
                guest.LastName = LastName;
                guest.FullName = FullName;
                guest.Address = Address;
                guest.Suburb = Suburb;
                guest.City = City;
                guest.Postcode = Postcode;
                guest.Country = Country;
                guest.Phone = Phone;
                guest.Mobile = Mobile;
                guest.Email = Email;

                context.SaveChanges();
            }
        }

        public void DeleteGuest()
        {

            // Our stanard using statement passing all the data to context

            string name = FirstName + " " + LastName;

            if (MessageBox.Show("Do you REALLY want to delete " + name + "?", "Delete Record",
                    MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                using (var context = new HotelEntities())
                {
                    // Select the row you want to delete
                    int id = GuestID;
                    var guest = (from g in context.Guests where g.GuestID == id select g).SingleOrDefault();

                    // run remove command
                    context.Guests.Remove(guest);

                    // Save the changes
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Guest has already been deleted or another error has occured\n\n" + e);
            }
        }
    }
}
