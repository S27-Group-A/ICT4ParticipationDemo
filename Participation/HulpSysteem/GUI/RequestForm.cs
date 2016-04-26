﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Participation.HulpSysteem.Logic;
using Participation.SharedModels;

namespace UI
{
    public partial class RequestForm : Form
    {
        /// <summary>
        /// Creates a new instance of HPSLogic
        /// </summary>
        private readonly HPSLogic _hpsLogic = new HPSLogic();

        public RequestForm()
        {
            InitializeComponent();
            for (var i = 0; i <= 5; i++)
            {
                urgencyLbx.Items.Add(i);
            }
            foreach (var perk in _hpsLogic.GetPerk())
            {
                perksClb.Items.Add(perk);
            }

        }

        /// <summary>
        /// Confirms on click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirmBtn_Click(object sender, EventArgs e)
        {
            var perks = new List<string>();
            foreach (var perk in perksClb.CheckedItems)
            {
                perks.Add(perk.ToString());
            }
            if (titleTbx.Text == "")
                MessageBox.Show("Vul de titel in");
            else if (descriptionTbx.Text == "")
                MessageBox.Show("Vul de beschrijving in");
            else if (locationTbx.Text == "")
                MessageBox.Show("Vul uw woonplaats in");
            else if (dateDtp.Value == DateTime.Today || dateDtp.Value < DateTime.Today || dateDtp.Value == null)
                MessageBox.Show("Vul een geldige datum in");
            else
            {
                var request = new Request(titleTbx.Text, descriptionTbx.Text, perks, locationTbx.Text, dateDtp.Value,
                    (int)urgencyLbx.SelectedItem);
                if (_hpsLogic.AddRequest(FormProvider.LoggedInUser as Patient, request))
                {
                    MessageBox.Show("Request " + request.Title + " succesvol aangemaakt");
                    FormProvider.RequestForm.Hide();
                    FormProvider.ProfileForm.Show();
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormProvider.RequestForm.Hide();
            FormProvider.ProfileForm.Show();
        }
    }
}