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

            tbxProfileName.Text = adminSystem.Users[lbxUserList.SelectedIndex].Name;
            rtbProfileInformation.Text = adminSystem.Users[lbxUserList.SelectedIndex].Description;
            //pbProfilePicture.Image = adminSystem.Users[lbxUserList.SelectedIndex].ProfilePicture;
            //pbProfilePicture.Visible = true;

        }

        //Bans a user, checks if it has to be permanently or temporary. If temporary, also sends for how long user will be banned.
        private void btn_BanGebruiker_Click(object sender, EventArgs e)
        {
            if (rbtnPermanent.Checked == true)
            {
                if (adminSystem.BanUserPermanent(adminSystem.Users[lbxUserList.SelectedIndex]))
                {
                    emptyProfileInformation();
                }
                else
                {
                    MessageBox.Show("Kon het account niet bannen.");
                }
            }
            if (rbtnTemporary.Checked == true)
            {
                if (adminSystem.BanUserTemporary(adminSystem.Users[lbxUserList.SelectedIndex], Convert.ToInt32(tbxDaysUntillUnbanned)))
                {
                    emptyProfileInformation();
                }
                else
                {
                    MessageBox.Show("Kon het account niet bannen.");
                }
            }
        }

        //Deletes the request.
        private void btn_VerwijderHulpvraag_Click(object sender, EventArgs e)
        {
            if (adminSystem.DeleteRequest(adminSystem.Requests[lbxRequests.SelectedIndex]))
            {
                LoadRequestList();
                Refresh();
            }
            else
            {
                MessageBox.Show("Deze hulpvraag kon helaas niet verwijderd worden!");
            }
        }

        //Deletes Review.
        private void btn_VerwijderRecensies_Click(object sender, EventArgs e)
        {
            if (adminSystem.DeleteReview(adminSystem.Reviews[lbxReviews.SelectedIndex]))
            {
                LoadReviewList();
                Refresh();
            }
            else
            {
                MessageBox.Show("Deze hulpvraag kon helaas niet verwijderd worden!");
            }
        }
        //Deletes an account.
        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
           if(adminSystem.DeleteAcount(adminSystem.Users[lbxUserList.SelectedIndex]))
           {
               LoadUserList();
               Refresh();
           }
            else
           {
               MessageBox.Show("Kon het account niet verwijderen.");
           }
        }
        //Judge a volunteer to see if he is qualified to be a volunteer.
        private void btnJudgeVolunteer_Click(object sender, EventArgs e)
        {
            DialogResult dialogresult = MessageBox.Show("Heeft deze gebruiker een goedgekeurde VOG?", "", MessageBoxButtons.YesNoCancel);
            if (dialogresult == DialogResult.Yes)
            {
                MessageBox.Show("Deze vrijwilliger is nu goedgekeurd om te beginnen!");

            }
            if (dialogresult == DialogResult.No)
            {
                MessageBox.Show("Sorry, maar een vrijwilliger staat pas op actief als zijn VOG goedgekeurd is.");
            }
            if (dialogresult == DialogResult.Cancel)
            {
            }
        }

        //Changes the rights of a user to give him admin rights.
        private void btnChangeRights_Click(object sender, EventArgs e)
        {
            DialogResult dialogresult = MessageBox.Show("Wilt u de rechten van deze gebruiker aanpassen?", "", MessageBoxButtons.YesNoCancel);
            if (dialogresult == DialogResult.Yes) 
            {
                if (adminSystem.ChangeAdminRights(adminSystem.Users[lbxUserList.SelectedIndex]))
                {   
                    MessageBox.Show(adminSystem.Users[lbxUserList.SelectedIndex].Name + "is nu een admin!");
                    emptyProfileInformation();
                }
                else
                {
                    MessageBox.Show("Er was een error bij het aanwijzen van adminrechten voor " + adminSystem.Users[lbxUserList.SelectedIndex].Name + "! Weet U zeker dat deze gebruiker een vrijwilliger is, niet gebanned is en een VOG heeft ingeleverd?");
                }
            }
            if (dialogresult == DialogResult.No) 
            {
                MessageBox.Show("De rechten zijn niet aangepast.");
            }
            if (dialogresult == DialogResult.Cancel) { }
        }
        //Log Out.
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
        
    }
    
}
