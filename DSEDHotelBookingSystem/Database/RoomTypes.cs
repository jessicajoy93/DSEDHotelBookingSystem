using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSEDHotelBookingSystem.Database
{
    class RoomTypes
    {
        HotelEntities _context = new HotelEntities();

        public int RoomTypeID { get; set; }
        public string Room_Type { get; set; }

        public IEnumerable RoomType()
        {
            //Pass our fields across to a vairiable
            var allRoomTypes = _context.RoomTypes.OrderBy(r => r.RoomTypeID);
            return allRoomTypes.ToList();
        }

        public void InsertRoomType()
        {
            using (var context = new HotelEntities())
            {

                var rt = new RoomType();
                rt.Room_Type = Room_Type;

                context.RoomTypes.Add(rt);
                context.SaveChanges();
            }
        }

        public void UpdateRoomType()
        {
            using (var context = new HotelEntities())
            {
                var query = from rt in context.RoomTypes where rt.RoomTypeID == RoomTypeID select rt;

                var roomType = query.FirstOrDefault(); //gets the first one
                roomType.Room_Type = Room_Type;


                context.SaveChanges();
            }
        }

        public void DeleteRoomType()
        {

            // Our stanard using statement passing all the data to context

            string roomtype = Room_Type;

            if (MessageBox.Show("Do you REALLY want to delete " + roomtype + "?", "Delete Record",
                    MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                using (var context = new HotelEntities())
                {
                    // Select the row you want to delete
                    int id = RoomTypeID;
                    var roomType = (from rt in context.RoomTypes where rt.RoomTypeID == id select rt).SingleOrDefault();

                    // run remove command
                    context.RoomTypes.Remove(roomType);

                    // Save the changes
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Room Type has already been deleted or another error has occured\n\n" + e);
            }
        }
    }
}
