using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSEDHotelBookingSystem.Database;

namespace DSEDHotelBookingSystem
{
    public partial class Form1 : Form
    {
        ModelCalls myDatabase = new ModelCalls();
        Rooms myRooms = new Rooms();
        RoomTypes myRoomTypes = new RoomTypes();
        Guests myGuests = new Guests();
        Bookings myBookings = new Bookings();

        public Form1()
        {
            InitializeComponent();
            TabControlHeaderHidden();
            HideTabHeaders();
            tabHome.Visible = true;


        }

        #region Tab Control Header Hidden
        private void TabControlHeaderHidden()
        {
            // Hides the Tab Control Headers
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
        }
        #endregion

        #region Home
        private void btnHome_Click(object sender, EventArgs e)
        {
            HideTabHeaders();
            tabHome.Visible = true;
        }
        #endregion

        #region Exit Application

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ExitApplication();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private static void ExitApplication()
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirm exit", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        #endregion

        #region Guests
        private void btnGuest_Click(object sender, EventArgs e)
        {
            HideTabHeaders();
            tabGuest.Visible = true;

            AllGuests();
        }

        private void AllGuests()
        {
            dgvGuests.DataSource = myGuests.AllGuests();

            GuestsDgvColumnHeaders();
        }

        private void GuestsDgvColumnHeaders()
        {
            dgvGuests.Columns[0].HeaderText = "Guest ID";
            dgvGuests.Columns[1].HeaderText = "First Name";
            dgvGuests.Columns[2].HeaderText = "Last Name";

            dgvGuests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnAddGuest_Click(object sender, EventArgs e)
        {
            InsertOrUpdateGuest();
        }

        private void InsertOrUpdateGuest()
        {

            if (txtFirstName.Text != "" && txtLastName.Text != "" && txtAddress.Text != "" && txtSuburb.Text != "" && txtCity.Text != "" && txtPostcode.Text != "" && txtCountry.Text != "" && (txtPhone.Text != "" || txtMobile.Text != "") && txtEmail.Text != "")
            {
                if (lblGuestID.Text == "")
                {
                    // add a new guest
                    GuestValues();
                    myGuests.InsertGuest();
                    AllGuests();
                    ResetGuest();
                }
                else if (lblGuestID.Text != "")
                {
                    // update a guest
                    GuestID();
                    GuestValues();
                    myGuests.UpdateGuest();
                    AllGuests();
                    ResetGuest();
                }

            }
            else
            {
                MessageBox.Show("Please fill in the missing fields");
            }
        }


        private void GuestID()
        {
            myGuests.GuestID = Convert.ToInt32(lblGuestID.Text);
        }

        private void GuestValues()
        {
            myGuests.FirstName = txtFirstName.Text;
            myGuests.LastName = txtLastName.Text;
            myGuests.FullName = myGuests.FirstName + " " + myGuests.LastName;
            myGuests.Address = txtAddress.Text;
            myGuests.Suburb = txtSuburb.Text;
            myGuests.City = txtCity.Text;
            myGuests.Postcode = txtPostcode.Text;
            myGuests.Country = txtCountry.Text;
            myGuests.Phone = txtPhone.Text;
            myGuests.Mobile = txtMobile.Text;
            myGuests.Email = txtEmail.Text;
        }


        private void btnUpdateGuest_Click(object sender, EventArgs e)
        {
            InsertOrUpdateGuest();
        }

        private void btnDeleteGuest_Click(object sender, EventArgs e)
        {
            try
            {
                GuestID();
                GuestValues();
                myGuests.DeleteGuest();
                AllGuests();
                ResetGuest();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select a guest before deleting\n\n" + ex);
            }
        }

        private void btnResetGuest_Click(object sender, EventArgs e)
        {
            ResetGuest();
        }


        #endregion

        #region Billings

        private void btnBillings_Click(object sender, EventArgs e)
        {
            HideTabHeaders();
            tabBillings.Visible = true;
        }

        #endregion

        #region Bookings
        private void btnBookings_Click(object sender, EventArgs e)
        {
            HideTabHeaders();
            tabBookings.Visible = true;

            AllBookings();
            BookingsDgvColumnHeaders();
        }

        private void BookingsDgvColumnHeaders()
        {
            dgvBookings.Columns[0].HeaderText = "Booking ID";
            dgvBookings.Columns[1].HeaderText = "Room ID";
            dgvBookings.Columns[2].HeaderText = "Room Name";
            dgvBookings.Columns[3].HeaderText = "Guest ID";
            dgvBookings.Columns[4].HeaderText = "Guest Name";
            dgvBookings.Columns[5].HeaderText = "Total Guests";
            dgvBookings.Columns[6].HeaderText = "Check In";
            dgvBookings.Columns[7].HeaderText = "Check Out";


            dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void AllBookings()
        {
            dgvBookings.DataSource = myBookings.AllBookings();
        }

        private void Date()
        {
            myBookings.CheckIn = dateCheckIn.Value;
            myBookings.CheckOut = myBookings.CheckIn.AddDays(1);
            dateCheckOut.Value = myBookings.CheckOut;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            AvailableRoomsValues();
            AvailableRooms();
            btnBook.Visible = true;

        }

        public void AvailableRooms()
        {

            dgvRoomsAvailable.DataSource = myBookings.AllAvailableRooms();

            //RoomTypesDgvColumnHeaders();
        }

        private void AvailableRoomsValues()
        {
            myBookings.GuestID = (int)cbxGuestName.SelectedValue;
            myBookings.NumOfGuests = Convert.ToInt32(nudNumOfGuests.Text);

        }

        private void AvailableRoomDetails()
        {
            myBookings.RoomID = Convert.ToInt32(lblAvailableRoomID.Text);
            myBookings.CheckIn = dateCheckIn.Value;
            myBookings.CheckOut = dateCheckOut.Value;
        }

        private void dateCheckIn_ValueChanged(object sender, EventArgs e)
        {
            Date();
        }

        #endregion

        #region Rooms

        private void btnRooms_Click(object sender, EventArgs e)
        {
            HideTabHeaders();
            tabRooms.Visible = true;
            AllRooms();
            cbxViewRooms.SelectedItem = "All Rooms";
        }

        public void AllRooms()
        {
            dgvRooms.DataSource = myRooms.AllRooms();

            RoomsDgvColumnHeaders();
        }

        private void RoomsDgvColumnHeaders()
        {
            dgvRooms.Columns[0].HeaderText = "Room ID";
            dgvRooms.Columns[1].HeaderText = "Room Name";
            dgvRooms.Columns[2].HeaderText = "Single Beds";
            dgvRooms.Columns[3].HeaderText = "Queen Beds";
            dgvRooms.Columns[6].HeaderText = "Room Type";

            dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        public void SingleRooms()
        {
            dgvRooms.DataSource = myRooms.SingleRooms(); //alldata.ToList();

            RoomsDgvColumnHeaders();
        }

        public void DoubleRooms()
        {
            dgvRooms.DataSource = myRooms.DoubleRooms(); //alldata.ToList();

            RoomsDgvColumnHeaders();
        }

        public void FamilyRooms()
        {
            dgvRooms.DataSource = myRooms.FamilyRooms(); //alldata.ToList();

            RoomsDgvColumnHeaders();
        }

        #region Combobox View Rooms Selected Index Changed

        private void cbxViewRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboboxViewRoomsSelected();
        }

        private void ComboboxViewRoomsSelected()
        {
            if (cbxViewRooms.SelectedItem == "All Rooms")
            {
                AllRooms();
            }
            else if (cbxViewRooms.SelectedItem == "Single")
            {
                SingleRooms();
            }
            else if (cbxViewRooms.SelectedItem == "Double")
            {
                DoubleRooms();
            }
            else if (cbxViewRooms.SelectedItem == "Family")
            {
                FamilyRooms();
            }
        }

        #endregion

        private void btnNewRoom_Click(object sender, EventArgs e)
        {
            InsertOrUpdateRoom();
        }

        private void InsertOrUpdateRoom()
        {

            if (txtRoomName.Text != "" && (nudSingleBed.Text != "0" || nudQueenBed.Text != "0") && txtRoomCost.Text != "")
            {
                if (lblRoomID.Text == "")
                {
                    //Insert Room
                    NewRoomValues();
                    myRooms.InsertRoom();
                    ComboboxViewRoomsSelected();
                    ResetRoom();
                }
                else if (lblRoomID.Text != "")
                {
                    //Update Room
                    NewRoomValues();
                    RoomID();
                    myRooms.UpdateRoom();
                    ComboboxViewRoomsSelected();
                    ResetRoom();
                }

            }
            else
            {
                MessageBox.Show("Please fill in the missing fields");
            }
        }

        private void btnEditRoom_Click(object sender, EventArgs e)
        {
            InsertOrUpdateRoom();
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            try
            {
                NewRoomValues();
                RoomID();
                myRooms.DeleteRoom();
                ComboboxViewRoomsSelected();
                ResetRoom();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select a room before deleting\n\n" + ex);
            }

        }

        private void btnResetRoom_Click(object sender, EventArgs e)
        {
            NewRoomValues();
            ComboboxViewRoomsSelected();
            ResetRoom();
        }

        private void RoomID()
        {
            myRooms.RoomID = Convert.ToInt32(lblRoomID.Text);
        }

        private void NewRoomValues()
        {

            myRooms.RoomName = txtRoomName.Text;
            myRooms.SingleBeds = Convert.ToInt32(nudSingleBed.Text);
            myRooms.QueenBeds = Convert.ToInt32(nudQueenBed.Text);
            myRooms.Sleeps = myRooms.SingleBeds + (myRooms.QueenBeds * 2);
            myRooms.Cost = Convert.ToInt32(txtRoomCost.Text);
            myRooms.RoomType = (int)cbxRoomType.SelectedValue;
        }

        #endregion

        #region Room Types

        private void btnRoomTypes_Click(object sender, EventArgs e)
        {
            HideTabHeaders();
            tabRoomTypes.Visible = true;
            RoomType();
        }

        public void RoomType()
        {
            dgvRoomType.DataSource = myRoomTypes.RoomType();

            RoomTypesDgvColumnHeaders();
        }

        private void RoomTypesDgvColumnHeaders()
        {
            dgvRoomType.Columns[0].HeaderText = "Room Type ID";
            dgvRoomType.Columns[1].HeaderText = "Room Type";

            dgvRoomType.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void RoomTypeID()
        {
            myRoomTypes.RoomTypeID = Convert.ToInt32(lblRoomTypeID.Text);
        }

        private void NewRoomTypeValues()
        {
            myRoomTypes.Room_Type = txtRoomType.Text;
        }

        private void btnNewRoomType_Click(object sender, EventArgs e)
        {
            InsertOrUpdateRoomType();
        }

        private void InsertOrUpdateRoomType()
        {

            if (txtRoomType.Text != "")
            {
                if (lblRoomTypeID.Text == "")
                {
                    //Insert Room
                    NewRoomTypeValues();
                    RoomTypeDataValidation();
                }
                else if (lblRoomTypeID.Text != "")
                {
                    //Update Room
                    NewRoomTypeValues();
                    RoomTypeID();
                    myRoomTypes.UpdateRoomType();
                    RoomType();
                    ResetRoomType();
                }

            }
            else
            {
                MessageBox.Show("Please fill in the missing fields");
            }
        }

        private void btnResetRoomType_Click(object sender, EventArgs e)
        {
            ResetRoomType();
        }

        private void RoomTypeDataValidation()
        {
            if (txtRoomType.Text == "")
            {
                MessageBox.Show("Please enter some text first.");
            }

            else
            {
                myRoomTypes.InsertRoomType();
                RoomType();

                ResetRoomType();
            }
        }

        private void btnEditRoomType_Click(object sender, EventArgs e)
        {
            InsertOrUpdateRoomType();
        }

        private void btnDeleteRoomType_Click(object sender, EventArgs e)
        {
            try
            {
                NewRoomTypeValues();
                RoomTypeID();
                myRoomTypes.DeleteRoomType();
                RoomType();
                ResetRoomType();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select a room type before deleting\n\n" + ex);
            }
        }

        #endregion

        #region Hide Tab Headers

        private void HideTabHeaders()
        {
            tabHome.Visible = false;
            tabRooms.Visible = false;
            tabBillings.Visible = false;
            tabAvailableRooms.Visible = false;
            tabGuest.Visible = false;
            tabRoomTypes.Visible = false;
            tabBookings.Visible = false;
        }

        #endregion

        #region Reset
        private void ResetRoom()
        {
            // Room
            lblRoomID.Text = "";
            txtRoomName.Text = "";
            txtRoomCost.Text = "";
            nudQueenBed.Text = "0";
            nudSingleBed.Text = "0";
        }

        private void ResetRoomType()
        {
            // Room Type
            lblRoomTypeID.Text = "";
            txtRoomType.Text = "";
        }

        private void ResetGuest()
        {
            // Guest
            lblGuestID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAddress.Text = "";
            txtSuburb.Text = "";
            txtCity.Text = "";
            txtPostcode.Text = "";
            txtCountry.Text = "";
            txtPhone.Text = "";
            txtMobile.Text = "";
            txtEmail.Text = "";
        }

        #endregion

        #region Cell Content Clicked

        // Data Grid View - Rooms - Content Click
        private void dgvRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblRoomID.Text = dgvRooms.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtRoomName.Text = dgvRooms.Rows[e.RowIndex].Cells[1].Value.ToString();
            nudSingleBed.Text = dgvRooms.Rows[e.RowIndex].Cells[2].Value.ToString();
            nudQueenBed.Text = dgvRooms.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtRoomCost.Text = dgvRooms.Rows[e.RowIndex].Cells[5].Value.ToString();
            cbxRoomType.Text = dgvRooms.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        // Data Grid View - Room Types - Content Click
        private void dgvRoomType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblRoomTypeID.Text = dgvRoomType.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtRoomType.Text = dgvRoomType.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        // Data Grid View - Guests - Content Click
        private void dgvGuests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblGuestID.Text = dgvGuests.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtFirstName.Text = dgvGuests.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtLastName.Text = dgvGuests.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtAddress.Text = dgvGuests.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSuburb.Text = dgvGuests.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtCity.Text = dgvGuests.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtPostcode.Text = dgvGuests.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtCountry.Text = dgvGuests.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtPhone.Text = dgvGuests.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtMobile.Text = dgvGuests.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtEmail.Text = dgvGuests.Rows[e.RowIndex].Cells[10].Value.ToString();
        }

        // Available Rooms
        private void dgvRoomsAvailable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblAvailableRoomID.Text = dgvRoomsAvailable.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
        #endregion

        #region Form1 Load
        // Makes Combobox data work
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hotelDataSet7.Guests' table. You can move, or remove it, as needed.
            this.guestsTableAdapter.Fill(this.hotelDataSet7.Guests);
            // TODO: This line of code loads data into the 'hotelDataSet4.RoomType' table. You can move, or remove it, as needed.
            this.roomTypeTableAdapter.Fill(this.hotelDataSet4.RoomType);

        }



        #endregion

        private void btnBook_Click(object sender, EventArgs e)
        {
            InsertOrUpdateBooking();
        }

        private void InsertOrUpdateBooking()
        {
            if (lblAvailableRoomID.Text == "") return;
            //Insert Room
            AvailableRoomsValues();
            AvailableRoomDetails();
            myBookings.NewBooking();

            HideTabHeaders();
            tabBookings.Visible = true;

            AllBookings();

        }

        private void btnSearchBookings_Click(object sender, EventArgs e)
        {
            HideTabHeaders();
            tabAvailableRooms.Visible = true;
            Date();
        }


    }
}
