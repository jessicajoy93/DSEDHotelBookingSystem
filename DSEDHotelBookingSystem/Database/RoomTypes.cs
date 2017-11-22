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
        public int RoomTypeID { get; set; }
        public string Room_Type { get; set; }
        public IEnumerable RoomType()
        {
            //What ever we want our code to do we do it in here
            //Pass our fields across to a vairiable
            using (var context = new HotelEntities())
            {
                var alldata = from rt in context.RoomTypes
                              select new
                              {
                                  rt.RoomTypeID,
                                  rt.Room_Type
                              };
                return alldata.ToList();
            }
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
    }
}
