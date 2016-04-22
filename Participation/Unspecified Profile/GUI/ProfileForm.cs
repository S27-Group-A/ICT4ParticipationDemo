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
            FormProvider.ProfileForm.Hide();
            FormProvider.RequestsViewForm.Show();
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
            lblPhonenumber.Text = _loggedInUser.PhoneNumber;
            lblGender.Text = _loggedInUser.Gender.ToString();
            pbxProfilePicture.Image = Image.FromFile(_loggedInUser.ProfilePicture);
        }

        private void RefreshPic()
        {
            //TODO Implement
            throw new NotImplementedException("RefreshPic is nog niet geimplementeerd");
        }

        private void RefreshVogUrl()
        {
            gbxVog.Visible = true;
            Volunteer tempV = _loggedInUser as Volunteer;
            lblVogUrl.Text = tempV._verklaringPdf;
            pbVog.Image = Image.FromFile(tempV._verklaringPdf);
        }

        private void RefreshPerks()
        {

            gbxPerks.Visible = true;
            Volunteer tempV = _loggedInUser as Volunteer;
            List<string> tempListPerks = tempV.GetPerks();
            lbPerks.Items.Clear();
            foreach (string s in tempListPerks)
            {
                lbPerks.Items.Add(s);
            }
        }

        private void btnBrowseVogUrl_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files | *.jpg; *.png; *.bmp; *.pdf; *.docx ";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Volunteer tempVolunteer = _loggedInUser as Volunteer;
                    tempVolunteer.AddVerklaring(ofd.FileName);
                    RefreshVogUrl();
                }

            }
        }

        private void btnAddPerk_Click(object sender, EventArgs e)
        {
            if (tbxPerk.Text.Length > 0)
            {
                Volunteer tempV = _loggedInUser as Volunteer;
                tempV.AddPerk(tbxPerk.Text);
                RefreshPerks();
            }
        }


    }
}
