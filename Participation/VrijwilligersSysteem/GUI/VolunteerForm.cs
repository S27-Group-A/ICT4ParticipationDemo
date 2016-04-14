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
using Participation.VrijwilligersSysteem;
using Participation.VrijwilligersSysteem.Logic;

namespace Participation.VrijwilligersSysteem.GUI
{
    public partial class VolunteerForm : Form
    {
        VolunteerSystem _volunteerSystem;
        Patient _selectedPatient;

        public VolunteerForm()
        {
            InitializeComponent();
            _volunteerSystem = new VolunteerSystem();
            _selectedPatient = null;
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
            Request _tempReq = _volunteerSystem.Requests[lbPatients.SelectedIndex];
            lblRequestTitle.Text = _tempReq.Title;
            lblName.Text = _volunteerSystem.GetPatientFromRequest(_tempReq).Name;
            lblDescription.Text = _tempReq.Text;
            lblLocation.Text = _tempReq.Location;
            lblUrgency.Text = _tempReq.Urgency.ToString();
            lblDate.Text = _tempReq.Date.ToString();
            if (_tempReq.Responses.Count > 0)
            {
                lbResponses.Items.Clear();
                foreach (Response r in _tempReq.Responses)
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
    }
}
