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
        private BHSLogic _BHSLogic;

        //Constructor
        public AdminSystemForm()
        {
            InitializeComponent();
            emptyProfileInformation();
            this._BHSLogic = new BHSLogic();
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
            lbxUserList.DataSource = _BHSLogic.GetUsers();
            Refresh();
        }

        //Loads the listbox and fills it with requests.
        public void LoadRequestList()
        {
            lbxRequests.DataSource = _BHSLogic.GetRequests();
        }

        //Loads the listbox and fills it with reviews.
        public void LoadReviewList()
        {
            lbxReviews.DataSource = _BHSLogic.GetReviews();
        }

        //Changes the information displayed in the Profile Information groupbox.
        private void lbx_userList_SelectedIndexChanged(object sender, EventArgs e)
        {
            emptyProfileInformation();

            tbxProfileName.Text = _BHSLogic.Users[lbxUserList.SelectedIndex].Name;
            rtbProfileInformation.Text = _BHSLogic.Users[lbxUserList.SelectedIndex].Description;
            //pbProfilePicture.Image = _BHSLogic.Users[lbxUserList.SelectedIndex].ProfilePicture;
            //pbProfilePicture.Visible = true;

        }

        //Bans a user, checks if it has to be permanently or temporary. If temporary, also sends for how long user will be banned.
        private void btn_BanGebruiker_Click(object sender, EventArgs e)
        {
            if (rbtnPermanent.Checked)
            {
                if (_BHSLogic.BanUser(_BHSLogic.Users[lbxUserList.SelectedIndex]))
                {
                    emptyProfileInformation();
                    LoadUserList();
                }
                else
                {
                    MessageBox.Show("Kon het account niet bannen.");
                }
            }
            if (rbtnTemporary.Checked)
            {
                if (_BHSLogic.BanUser(_BHSLogic.Users[lbxUserList.SelectedIndex], DateTime.Now.AddDays(Convert.ToInt32(tbxDaysUntillUnbanned.Text))))
                {
                    emptyProfileInformation();
                    LoadUserList();
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
            if (_BHSLogic.DeleteRequest(_BHSLogic.Requests[lbxRequests.SelectedIndex]))
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
            if (_BHSLogic.DeleteReview(_BHSLogic.Reviews[lbxReviews.SelectedIndex]))
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
            if (_BHSLogic.DeleteAcount(_BHSLogic.Users[lbxUserList.SelectedIndex]))
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
                if (_BHSLogic.ChangeAdminRights(_BHSLogic.Users[lbxUserList.SelectedIndex]))
                {
                    MessageBox.Show(_BHSLogic.Users[lbxUserList.SelectedIndex].Name + "is nu een admin!");
                    emptyProfileInformation();
                }
                else
                {
                    MessageBox.Show("Er was een error bij het aanwijzen van adminrechten voor " + _BHSLogic.Users[lbxUserList.SelectedIndex].Name + "! Weet U zeker dat deze gebruiker een vrijwilliger is, niet gebanned is en een VOG heeft ingeleverd?");
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
