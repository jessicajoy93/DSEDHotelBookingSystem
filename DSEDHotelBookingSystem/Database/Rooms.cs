using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;

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


        #region Types of Rooms
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
                                  r.RoomName,
                                  r.SingleBeds,
                                  r.QueenBeds,
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
                                  r.RoomName,
                                  r.SingleBeds,
                                  r.QueenBeds,
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
                                  r.RoomName,
                                  r.SingleBeds,
                                  r.QueenBeds,
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
                                  r.RoomName,
                                  r.SingleBeds,
                                  r.QueenBeds,
                                  r.Sleeps,
                                  r.Cost,
                                  r.RoomType.Room_Type
                              };

                return alldata.ToList();
            }
        }
        #endregion

        public void InsertRoom()
        {
            using (var context = new HotelEntities())
            {
                var r = new Room();
                r.RoomName = RoomName;
                r.SingleBeds = SingleBeds;
                r.QueenBeds = QueenBeds;
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
                var query = from r in context.Rooms where r.RoomID == RoomID select r;

                var room = query.FirstOrDefault(); //gets the first one
                room.RoomName = RoomName;
                room.SingleBeds = SingleBeds;
                room.QueenBeds = QueenBeds;
                room.Sleeps = Sleeps;
                room.Cost = Cost;
                room.RoomTypeIDFK = RoomType;

                context.SaveChanges();
            }
        }

        public void DeleteRoom()
        {

            // Our stanard using statement passing all the data to context

            string name = RoomName;

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
                    int id = RoomID;
                    var room = (from r in context.Rooms where r.RoomID == RoomID select r).SingleOrDefault();

                    // run remove command
                    context.Rooms.Remove(room);

                    // Save the changes
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Room has already been deleted or another error has occured\n\n" + e);
            }
        }
    }
}
