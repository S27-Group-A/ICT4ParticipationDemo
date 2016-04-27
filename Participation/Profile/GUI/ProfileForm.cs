﻿using System.Globalization;
using Participation.Profile.Logic;

namespace Participation.BeheerSysteem.GUI
{
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
    using Participation.Profile;

    public partial class ProfileForm : Form
    {
        private IUser _loggedInUser;
        private ProfileLogic _profileLogic;

        public ProfileForm(IUser loggedInUser)
        {
            InitializeComponent();
            _loggedInUser = loggedInUser;
            _profileLogic = new ProfileLogic();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            RefreshInfo();
            //TODO Implement once fileserver is in place
            //RefreshPic();
            if (_loggedInUser.GetType() == typeof(Volunteer))
            {
                //RefreshVogUrl(); obsolete
                RefreshPerks();
                RefreshWeek();
            }



        }

        /// <summary>
        /// Button which makes you go back to login form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_LogUit_Click(object sender, EventArgs e)
        {
            DialogResult dialogresult = MessageBox.Show("Weet U zeker dat U uit wilt loggen?", "",
                MessageBoxButtons.YesNo);
            if (dialogresult == DialogResult.Yes)
            {
                MessageBox.Show("U bent nu uitgelogd.");
                FormProvider.StartMenu.Show();
                FormProvider.LoggedInUser = null;
                this.Close();

            }
            else if (dialogresult == DialogResult.No)
            {
            }
        }

        /// <summary>
        /// Non used button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Profiel_Click(object sender, EventArgs e)
        {
            RefreshInfo();
        }

        /// <summary>
        /// Sends you to form of requests
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Hulpvragen_Click(object sender, EventArgs e)
        {
            FormProvider.ProfileForm.Hide();
            FormProvider.RequestsViewForm.Show();
        }

        private void EditInfo_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Puts all the information on the screen from the logged in user
        /// </summary>
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

        /// <summary>
        /// Gets the vog url and displays it
        /// </summary>
        //private void RefreshVogUrl()
        //{
        //    gbxVog.Visible = true;
        //    Volunteer tempV = _loggedInUser as Volunteer;
        //    lblVogUrl.Text = tempV.verklaringPdf;
        //    pbVog.Image = Image.FromFile(tempV.verklaringPdf);
        //}

        /// <summary>
        /// Gets all the perks from the user and displays it
        /// </summary>
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

        /// <summary>
        /// Set an new updated vog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btnBrowseVogUrl_Click(object sender, EventArgs e)
        //{
        //    using (OpenFileDialog ofd = new OpenFileDialog())
        //    {
        //        ofd.Filter = "Image Files | *.jpg; *.png; *.bmp; *.pdf; *.docx ";
        //        if (ofd.ShowDialog() == DialogResult.OK)
        //        {
        //            Volunteer tempVolunteer = _loggedInUser as Volunteer;
        //            tempVolunteer.AddVerklaring(ofd.FileName);
        //            //RefreshVogUrl();
        //        }

        //    }
        //}

        /// <summary>
        /// Add more perks to your existing profile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPerk_Click(object sender, EventArgs e)
        {
            if (tbxPerk.Text.Length > 0)
            {
                Volunteer tempV = _loggedInUser as Volunteer;
                tempV.AddPerk(tbxPerk.Text);
                RefreshPerks();
            }
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormProvider.LoggedInUser.Ban == 0)
                {
                    FormProvider.ChatUsersForm.ShowDialog();
                }
                else if (FormProvider.LoggedInUser.Unban == null)
                {
                    MessageBox.Show("U bent gebanned van de chat");
                }
                else
                {
                    MessageBox.Show("U bent gebanned van de chat tot: " + FormProvider.LoggedInUser.Unban.ToShortDateString());
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }


        }

        private void btnSaveWeek_Click(object sender, EventArgs e)
        {

        }

        private void RefreshWeek()
        {
            gbxWeekView.Visible = true;
            var times = new List<string>();
            try
            {
                times = _profileLogic.GetAvailability(_loggedInUser);
                if (times.Count != 7) 
                    throw new ArgumentOutOfRangeException("Te veel database elementen opgehaald, aantal: " 
                        + times.Count + " verwachte aantal: 7" );
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            var splittedTimes = new List<string>();
            foreach (string t in times)
            {
                var tempTimes = t.Split('-');
                splittedTimes.AddRange(tempTimes);
            }

            var trueSplittedTimes = new List<DateTime>();
            foreach (string t in splittedTimes)
            {
                trueSplittedTimes.Add(Convert.ToDateTime(t));
            }

            #region Set times in form

            dtpStartMo.Value = trueSplittedTimes[0];
            dtpEndMo.Value = trueSplittedTimes[1];
            dtpStartTu.Value = trueSplittedTimes[2];
            dtpEndTu.Value = trueSplittedTimes[3];
            dtpStartWe.Value = trueSplittedTimes[4];
            dtpEndWe.Value = trueSplittedTimes[5];
            dtpStartTh.Value = trueSplittedTimes[6];
            dtpEndTh.Value = trueSplittedTimes[7];
            dtpStartFr.Value = trueSplittedTimes[8];
            dtpEndFr.Value = trueSplittedTimes[9];
            dtpStartSa.Value = trueSplittedTimes[10];
            dtpEndSa.Value = trueSplittedTimes[11];
            dtpStartSu.Value = trueSplittedTimes[12];
            dtpEndSu.Value = trueSplittedTimes[13];

            #endregion


        }
    }
}