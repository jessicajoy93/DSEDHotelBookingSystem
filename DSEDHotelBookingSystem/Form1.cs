using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSEDHotelBookingSystem
{
    public partial class Form1 : Form
    {
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
            ExitApplication();
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

        private void btnBillings_Click(object sender, EventArgs e)
        {
            HideTabHeaders();
            tabBillings.Visible = true;
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            HideTabHeaders();
            tabBookings.Visible = true;
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            HideTabHeaders();
            tabRooms.Visible = true;
        }

        private void btnNewRoom_Click(object sender, EventArgs e)
        {
            HideTabHeaders();
            tabNewRoom.Visible = true;

        }

        private void HideTabHeaders()
        {
            tabHome.Visible = false;
            tabRooms.Visible = false;
            tabNewRoom.Visible = false;
            tabBillings.Visible = false;
            tabBookings.Visible = false;
            tabGuest.Visible = false;
            tabNewGuest.Visible = false;
        }
    }
}
