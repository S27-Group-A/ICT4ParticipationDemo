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
    public partial class MeetingVolunteerForm : Form
    {
        private MeetingLogic _meetingLogic;
        public MeetingVolunteerForm()
        {
            InitializeComponent();
            _meetingLogic = new MeetingLogic();
        }

        private void MeetingVolunteerForm_Load(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void RefreshUI()
        {
            _meetingLogic.GetMeetingsForVolunteer(FormProvider.LoggedInUser as Volunteer);
            lbAccepted.Items.Clear();
            lbNotAccepted.Items.Clear();
            List<Meeting> tempMeetings = FormProvider.LoggedInUser.Meetings;
            foreach (Meeting m in tempMeetings)
            {
                if (m.Status == 0)
                {
                    lbNotAccepted.Items.Add(m.Patient.Name + ", " + m.Location);
                }
                else
                {
                    lbAccepted.Items.Add(m.Patient.Name + ", " + m.Location);
                }
            }
        }
    }
}
