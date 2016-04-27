using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Participation.InlogSysteem.Interfaces;
using Participation.SharedModels;
using Participation.VrijwilligersSysteem;
using Participation.VrijwilligersSysteem.Logic;
using Participation.VrijwilligersSysteem.GUI;

namespace Participation.VrijwilligersSysteem.GUI
{
    public partial class VolunteerForm : Form
    {
        VolunteerSystem _volunteerSystem;
        Request _selectedRequest;
        private IUser _loggedInUser = FormProvider.LoggedInUser;

        public VolunteerForm()
        {
            InitializeComponent();
            _volunteerSystem = new VolunteerSystem();
            _selectedRequest = null;
            lbPatients.SelectedIndex = 0;
            RefreshData();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbResponse.Text.Length > 0 && _loggedInUser is Volunteer)
            {
                _volunteerSystem.AddNewResponse(_selectedRequest, FormProvider.LoggedInUser as Volunteer, tbResponse.Text);
                GetRequestInfo();
                tbResponse.Text = "";
            }
        }

        private void VolunteerForm_Load(object sender, EventArgs e)
        {

        }

        private void RefreshData()
        {
            lbPatients.Items.Clear();
            foreach (Request r in _volunteerSystem.Requests)
            {
                lbPatients.Items.Add(r.Title);
            }           
        }

        private void GetRequestInfo()
        {
            lbResponses.Items.Clear();
            _selectedRequest = _volunteerSystem.Requests[lbPatients.SelectedIndex];
            lblRequestTitle.Text = _selectedRequest.Title;
            lblName.Text = _volunteerSystem.GetPatientFromRequest(_selectedRequest).Name;
            lblDescription.Text = _selectedRequest.Text;
            lblLocation.Text = _selectedRequest.Location;
            pictureBox1.Image = Image.FromFile(_volunteerSystem.GetPatientFromRequest(_selectedRequest).ProfilePicture);
            if (_selectedRequest.Urgency == 0)
            {
                lblUrgency.Text = "Niet belangrijk.";
            }
            else
            {
                lblUrgency.Text = "Belangrijk.";
            }
            lblDate.Text = _selectedRequest.Date.ToString();
            if (_selectedRequest.Responses.Count > 0)
            {
                lbResponses.Items.Clear();
                foreach (Response r in _selectedRequest.Responses)
                {
                    lbResponses.Items.Add(r.Text);
                }
            }
        }

        private void lbPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void lbPatients_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            GetRequestInfo();
        }

        private void btnMeeting_Click(object sender, EventArgs e)
        {

        }
    }
}
