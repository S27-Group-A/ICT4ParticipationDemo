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


        private void btn_BanGebruiker_Click(object sender, EventArgs e)
        {
            if (adminSystem.DeleteAcount(adminSystem.Users[lbxUserList.SelectedIndex]))
            {
                emptyProfileInformation();
            }
            else
            {
                MessageBox.Show("Kon het account niet bannen.");
            }
        }

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
        private void btn_Chat_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Form2 class
            //Chatform newchat = new Chatform();

            // Show the settings form
            //newchat.Show();
        }
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
        private void btnChangeRights_Click(object sender, EventArgs e)
        {
            DialogResult dialogresult = MessageBox.Show("Wilt u de rechten van deze gebruiker aanpassen?", "", MessageBoxButtons.YesNoCancel);
            if (dialogresult == DialogResult.Yes) { }
            if (dialogresult == DialogResult.No) { }
            if (dialogresult == DialogResult.Cancel) { }
        }
        private void btn_Profiel_Click(object sender, EventArgs e)
        {
            // open profielpagina
        }

        private void btn_Hulpvragen_Click(object sender, EventArgs e)
        {
            //open request pagina
        }

        private void btn_Ouderen_Click(object sender, EventArgs e)
        {
            //open ouderen pagina
        }

        private void btn_Vrijwilligers_Click(object sender, EventArgs e)
        {
            //open vrijwilligers pagina
        }
    }
}
