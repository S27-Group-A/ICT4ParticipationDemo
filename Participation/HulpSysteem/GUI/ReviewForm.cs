using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Participation.HulpSysteem.Logic;
using Participation.InlogSysteem.Interfaces;
using Participation.SharedModels;

namespace Participation.HulpSysteem.GUI
{
    public partial class ReviewForm : Form
    {
        private readonly HPSLogic _hpsLogic;
        public ReviewForm()
        {
            InitializeComponent();
            _hpsLogic = new HPSLogic();
            RefereshVolunteers();
            MessageBox.Show("Selecteer een hulpverlener waar u uw review voor wil schrijven");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                var volunteer = lbxVolunteers.SelectedItem as Volunteer;
                var patient = FormProvider.LoggedInUser as Patient;
                var review = new Review(Convert.ToDouble(cbxScore.Text), (tbxTitle.Text + "\n" +  tbxText.Text));
                if (_hpsLogic.AddReview(volunteer, patient, review))
                {
                    MessageBox.Show("Review is verzonden naar: " + volunteer.Name);
                }
                else
                {
                    MessageBox.Show("Kon het review niet verzenden naar: " + volunteer.Name);
                }
            }
        }

        private void RefereshVolunteers()
        {
            foreach (var v in _hpsLogic.GetVolunteers())
            {
                lbxVolunteers.Items.Add(v);
            }
        }

        private bool CheckFields()
        {
            if (string.IsNullOrEmpty(tbxText.Text) || string.IsNullOrEmpty(tbxTitle.Text))
            {
                MessageBox.Show("Vul een titel en/of tekst in het review vak in");
                return false;
            }
            if (lbxVolunteers.SelectedIndex < 0)
            {
                MessageBox.Show("Selecteer een hulpverlener waar u uw review voor wil schrijven");
                return false;
            }
            return true;

        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            FormProvider.ReviewForm.Hide();
            FormProvider.ProfileForm.Show();
        }

        private void btnWriteReview_Click(object sender, EventArgs e)
        {
            tbxText.Clear();
            tbxTitle.Clear();
            RefereshVolunteers();
        }
    }
}
