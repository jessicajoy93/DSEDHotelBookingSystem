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

        public Form1()
        {
            InitializeComponent();
            TabControlHeaderHidden();
            HideTabHeaders();
            tabHome.Visible = true;


        }

        private void TabControlHeaderHidden()
        {
            // Hides the Tab Control Headers
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            HideTabHeaders();
            tabHome.Visible = true;
        }



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
            if (MessageBox.Show("Are you sure you want to exit?", "Confirm exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        #endregion

        #region Guests
        private void btnGuests_Click(object sender, EventArgs e)
        {
            HideTabHeaders();
            tabGuest.Visible = true;
        }

        private void btnNewGuest_Click(object sender, EventArgs e)
        {
            HideTabHeaders();
            tabNewGuest.Visible = true;
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
            dgvRooms.DataSource = myRooms.SingleRooms();//alldata.ToList();

            RoomsDgvColumnHeaders();
        }
        public void DoubleRooms()
        {
            dgvRooms.DataSource = myRooms.DoubleRooms();//alldata.ToList();

            RoomsDgvColumnHeaders();
        }

        public void FamilyRooms()
        {
            dgvRooms.DataSource = myRooms.FamilyRooms();//alldata.ToList();

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
            NewRoomValues();
            myRooms.InsertRoom();
            ComboboxViewRoomsSelected();

            Reset();
        }

        private void btnEditRoom_Click(object sender, EventArgs e)
        {
            NewRoomValues();

            myRooms.UpdateRoom();

            ComboboxViewRoomsSelected();

            Reset();
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            try
            {
                NewRoomValues();
                RoomID();
                myRooms.DeleteRoom();
                ComboboxViewRoomsSelected();
                Reset();
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
            Reset();
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
            NewRoomTypeValues();
            RoomTypeDataValidation();

        }

        private void btnResetRoomType_Click(object sender, EventArgs e)
        {
            Reset();
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

                Reset();
            }
        }
        #endregion

        #region Hide Tab Headers
        private void HideTabHeaders()
        {
            tabHome.Visible = false;
            tabRooms.Visible = false;
            tabBillings.Visible = false;
            tabBookings.Visible = false;
            tabGuest.Visible = false;
            tabNewGuest.Visible = false;
            tabRoomTypes.Visible = false;
        }
        #endregion

        #region Reset
        private void Reset()
        {
            // Room
            lblRoomID.Text = "";
            txtRoomName.Text = "";
            txtRoomCost.Text = "";
            nudQueenBed.Text = "0";
            nudSingleBed.Text = "0";

            // Room Type
            lblRoomTypeID.Text = "";
            txtRoomType.Text = "";
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



        #endregion


        // Makes Combobox data work
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hotelDataSet4.RoomType' table. You can move, or remove it, as needed.
            this.roomTypeTableAdapter.Fill(this.hotelDataSet4.RoomType);

        }


    }
}
