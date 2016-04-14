using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Participation.BeheerSysteem.GUI
{
    public partial class BeheerSysteemForm : Form
    {
        public BeheerSysteemForm()
        {
            InitializeComponent();
            //load userlist
            //load requests
            //load reviews
        }

        private void lbx_userList_SelectedIndexChanged(object sender, EventArgs e)
        {
            emptyProfileInformation();

            tbx_ProfileName.Text = lbx_userList.SelectedItem.name.Text;
            rtb_ProfileInformation.Text = lbx_userList.SelectedItem.description.Text;
            //pbProfilePicture.Image = lbx_userList.SelectedItem.ProfilePicture;
            //pbProfilePicture.Show = true;

        }

        private void btn_BanGebruiker_Click(object sender, EventArgs e)
        {
            if (rbtn_Permanent.Checked == true)
            {
                lbx_userList.SelectedItem.isBanned = true;
            }
            if (rbtn_Temporary.Checked == true)
            {
               //don't forget to implement trycatch
                int bandays = 0;
                bandays = Convert.ToInt32(tb_daysUntillUnbanned.Text);
                lbx_userList.SelectedItem.isBanned = true;
                lbx_userList.SelectedItem.daysBanned = bandays;
            }
            emptyProfileInformation();
        }

        public void emptyProfileInformation()
        {
            tbx_ProfileName.Text = "";
            rtb_ProfileInformation.Text = "";
            //pbProfilePicture.Show = false;
        }

        private void btn_VerwijderHulpvraag_Click(object sender, EventArgs e)
        {
            lbx_requests.SelectedItem.Remove;
        }

        private void btn_VerwijderRecensies_Click(object sender, EventArgs e)
        {
            lbx_Reviews.SelectedItem.Remove;
        }
        private void btn_Chat_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Form2 class
            Chatform newchat = new Chatform();

            // Show the settings form
            newchat.Show();
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

    }
}
