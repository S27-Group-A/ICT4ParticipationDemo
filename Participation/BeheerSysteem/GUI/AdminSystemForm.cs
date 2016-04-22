using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Participation.SharedModels;
using Participation.BeheerSysteem.Logic;

namespace Participation.BeheerSysteem.GUI
{
    public partial class AdminSystemForm : Form
    {
        //Fields
        private AdministrationSystem adminSystem;

        //Constructor
        public AdminSystemForm()
        {
            InitializeComponent();
            emptyProfileInformation();
            this.adminSystem = new AdministrationSystem();
            LoadUserList();
            LoadRequestList();
            LoadReviewList();
        }

        //Empties all the textboxes in the Profile Information groupbox.
        public void emptyProfileInformation()
        {
            tbxProfileName.Text = "";
            rtbProfileInformation.Text = "";
            //pbProfilePicture.Show = false;
        }

        //Loads the listbox and fills it with users.
        public void LoadUserList()
        {
            lbxUserList.DataSource = adminSystem.Users;
            Refresh();
        }

        //Loads the listbox and fills it with requests.
        public void LoadRequestList()
        {
            lbxRequests.DataSource = DatabaseManager.GetRequests();
        }

        //Loads the listbox and fills it with reviews.
        public void LoadReviewList()
        {
            lbxReviews.DataSource = DatabaseManager.GetReviews();
        }

        //Changes the information displayed in the Profile Information groupbox.
        private void lbx_userList_SelectedIndexChanged(object sender, EventArgs e)
        {
            emptyProfileInformation();

            tbxProfileName.Text = lbxUserList.SelectedItem.name.Text;
            rtbProfileInformation.Text = lbxUserList.SelectedItem.description.Text;
            //pbProfilePicture.Image = lbx_userList.SelectedItem.ProfilePicture;
            //pbProfilePicture.Show = true;

        }


        private void btn_BanGebruiker_Click(object sender, EventArgs e)
        {
            if (rbtnPermanent.Checked == true)
            {
                lbxUserList.SelectedItem.isBanned = true;
            }
            if (rbtnTemporary.Checked == true)
            {
               //don't forget to implement trycatch
                int bandays = 0;
                bandays = Convert.ToInt32(tbxDaysUntillUnbanned.Text);
                lbxUserList.SelectedItem.isBanned = true;
                lbxUserList.SelectedItem.daysBanned = bandays;
            }
            emptyProfileInformation();
        }

        private void btn_VerwijderHulpvraag_Click(object sender, EventArgs e)
        {
            lbxRequests.SelectedItem.Remove;
        }

        private void btn_VerwijderRecensies_Click(object sender, EventArgs e)
        {
            lbxReviews.SelectedItem.Remove;
        }
        private void btn_Chat_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Form2 class
            //Chatform newchat = new Chatform();

            // Show the settings form
            //newchat.Show();
        }
        private void btn_Beheer_Click(object sender, EventArgs e)
        {
            MessageBox.Show("U bent al op de beheerderspagina!");
        }
        private void btn_LogUit_Click(object sender, EventArgs e)
        {
            DialogResult dialogresult = MessageBox.Show("Weet U zeker dat U uit wilt loggen?", "", MessageBoxButtons.YesNo);
            if (dialogresult == DialogResult.Yes)
            {
                MessageBox.Show("U bent nu uitgelogd.");
                this.Close();
            }
            else if (dialogresult == DialogResult.No)
            {
            }
        }
        private void btn_Profiel_Click(object sender, EventArgs e)
        {

        }

        private void btn_Hulpvragen_Click(object sender, EventArgs e)
        {

        }

        private void btn_Ouderen_Click(object sender, EventArgs e)
        {

        }

        private void btn_Vrijwilligers_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {

        }

        private void btnChangeRights_Click(object sender, EventArgs e)
        {

        }

        private void btnJudgeVolunteer_Click(object sender, EventArgs e)
        {

        }

    }
}
