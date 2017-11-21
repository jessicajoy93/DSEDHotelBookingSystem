using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSEDHotelBookingSystem.Database
{
    class Rooms
    {
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public int SingleBeds { get; set; }
        public int QueenBeds { get; set; }
        public int Sleeps { get; set; }
        public int Cost { get; set; }
        public int RoomType { get; set; }
        public IEnumerable AllRooms()
        {
            //What ever we want our code to do we do it in here
            //Pass our fields across to a vairiable
            using (var context = new HotelEntities())
            {
                var alldata = from r in context.Rooms
                              where r.RoomTypeIDFK == r.RoomType.RoomTypeID
                              orderby r.Cost descending
                              select new
                              {
                                  r.RoomID,
                                  r.Room_Name,
                                  r.Single_Beds,
                                  r.Queen_Beds,
                                  r.Sleeps,
                                  r.Cost,
                                  r.RoomType.Room_Type
                              };

                return alldata.ToList();
            }
        }

        public IEnumerable SingleRooms()
        {
            //What ever we want our code to do we do it in here
            //Pass our fields across to a vairiable
            using (var context = new HotelEntities())
            {
                var alldata = from r in context.Rooms
                              where r.RoomTypeIDFK == r.RoomType.RoomTypeID && r.RoomType.Room_Type == "Single"
                              orderby r.Cost descending
                              select new
                              {
                                  r.RoomID,
                                  r.Room_Name,
                                  r.Single_Beds,
                                  r.Queen_Beds,
                                  r.Sleeps,
                                  r.Cost,
                                  r.RoomType.Room_Type
                              };

                return alldata.ToList();
            }
        }

        public IEnumerable DoubleRooms()
        {
            //What ever we want our code to do we do it in here
            //Pass our fields across to a vairiable
            using (var context = new HotelEntities())
            {
                var alldata = from r in context.Rooms
                              where r.RoomTypeIDFK == r.RoomType.RoomTypeID && r.RoomType.Room_Type == "Double"
                              orderby r.Cost descending
                              select new
                              {
                                  r.RoomID,
                                  r.Room_Name,
                                  r.Single_Beds,
                                  r.Queen_Beds,
                                  r.Sleeps,
                                  r.Cost,
                                  r.RoomType.Room_Type
                              };

                return alldata.ToList();
            }
        }

        public IEnumerable FamilyRooms()
        {
            //What ever we want our code to do we do it in here
            //Pass our fields across to a vairiable
            using (var context = new HotelEntities())
            {
                var alldata = from r in context.Rooms
                              where r.RoomTypeIDFK == r.RoomType.RoomTypeID && r.RoomType.Room_Type == "Family"
                              orderby r.Cost descending
                              select new
                              {
                                  r.RoomID,
                                  r.Room_Name,
                                  r.Single_Beds,
                                  r.Queen_Beds,
                                  r.Sleeps,
                                  r.Cost,
                                  r.RoomType.Room_Type
                              };

                return alldata.ToList();
            }
        }

        public void InsertRoom()
        {
            using (var context = new HotelEntities())
            {
                var r = new Room();
                r.Room_Name = RoomName;
                r.Single_Beds = SingleBeds;
                r.Queen_Beds = QueenBeds;
                r.Sleeps = Sleeps;
                r.Cost = Cost;
                r.RoomTypeIDFK = RoomType;

                context.Rooms.Add(r);
                context.SaveChanges();
            }
        }

        public void UpdateRoom()
        {
            using (var context = new HotelEntities())
            {
                var query = from r in context.Rooms where r.RoomID == this.RoomID select r;

                var room = query.FirstOrDefault(); //gets the first one
                room.Room_Name = this.RoomName;
                room.Single_Beds = this.SingleBeds;
                room.Queen_Beds = this.QueenBeds;
                room.Sleeps = this.Sleeps;
                room.Cost = this.Cost;
                room.RoomTypeIDFK = this.RoomType;

                context.SaveChanges();
            }
        }
    }
}
