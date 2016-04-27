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
using Participation.VrijwilligersSysteem.Logic;

namespace Participation.VrijwilligersSysteem.GUI
{
    public partial class MeetingForm : Form
    {
        private MeetingLogic _meetingLogic;
        public MeetingForm()
        {
            InitializeComponent();
        }

        private void btnPlannen_Click(object sender, EventArgs e)
        {
            if (lbVolunteers.SelectedIndex >= 0 && tbLocation.Text.Length > 0)
            {
                _meetingLogic.AddMeeting(_meetingLogic.Volunteers[lbVolunteers.SelectedIndex],
                    InvitedPatient.PatientForInvite, dtpDate.Value, tbLocation.Text);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MeetingForm_Load(object sender, EventArgs e)
        {
            _meetingLogic = new MeetingLogic();
            MessageBox.Show(InvitedPatient.PatientForInvite.Email);
            RefreshUI();
        }

        private void RefreshUI()
        {
            List<Volunteer> tempVolunteers = _meetingLogic.Volunteers;
            lbVolunteers.Items.Clear();
            foreach (Volunteer v in tempVolunteers)
            {
                lbVolunteers.Items.Add(v.Name);
            }
        }
    }
}
