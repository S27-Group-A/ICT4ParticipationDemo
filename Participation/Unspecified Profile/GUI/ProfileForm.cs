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
    public partial class ProfileForm : Form
    {
        public ProfileForm()
        {
            InitializeComponent();
            //load userlist
            //load requests
            //load reviews
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

    }
}
