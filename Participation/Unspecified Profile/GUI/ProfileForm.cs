using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Participation.InlogSysteem.Interfaces;
using Participation.SharedModels;

namespace Participation.BeheerSysteem.GUI
{
    public partial class ProfileForm : Form
    {
        private IUser _loggedInUser;

        public ProfileForm(IUser loggedInUser)
        {
            InitializeComponent();
            _loggedInUser = loggedInUser;
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            RefreshInfo();
            //TODO Implement once fileserver is in place
            //RefreshPic();
            if (_loggedInUser.GetType() == typeof(Volunteer))
            {
                RefreshVogUrl();
                RefreshPerks();
            }


        }


        private void btn_LogUit_Click(object sender, EventArgs e)
        {
            DialogResult dialogresult = MessageBox.Show("Weet U zeker dat U uit wilt loggen?", "",
                MessageBoxButtons.YesNo);
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
            throw new NotImplementedException();
        }

        private void btn_Hulpvragen_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void EditInfo_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void RefreshInfo()
        {
            lblName.Text = _loggedInUser.Name;
            lblEmail.Text = _loggedInUser.Email;
            lblBirthdate.Text = _loggedInUser.Birthday.ToString();
            lblLocation.Text = _loggedInUser.Location;
            lblGender.Text = _loggedInUser.Gender.ToString();
        }

        private void RefreshPic()
        {
            //TODO Implement
            throw new NotImplementedException("RefreshPic is nog niet geimplementeerd");
        }

        private void RefreshVogUrl()
        {
            //TODO Implement
            throw new NotImplementedException("RefreshVogUrl is nog niet geimplementeerd");
        }

        private void RefreshPerks()
        {
            //TODO Implement
            throw new NotImplementedException("RefreshPerks is nog niet geimplementeerd");
        }


    }
}
