﻿using System;
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
        private Meeting _selectedMeeting;
        public MeetingVolunteerForm()
        {
            InitializeComponent();
            _meetingLogic = new MeetingLogic();
            _selectedMeeting = null;
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
                    lbNotAccepted.Items.Add(m.ToString());
                }
                else
                {
                    lbAccepted.Items.Add(m.ToString());
                }
            }
            if (_selectedMeeting != null)
            {
                lblDate.Text = _selectedMeeting.Date.ToString();
                lblPatientName.Text = _selectedMeeting.Patient.Name;
                lblStatus.Text = _selectedMeeting.Status.ToString();
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (lbNotAccepted.SelectedIndex >= 0)
            {
                
            }
        }

        private void lbNotAccepted_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedMeeting = GetMeetingNotAccepted();
            RefreshUI();
        }

        private Meeting GetMeetingNotAccepted()
        {
            List<Meeting> tempMeetings = FormProvider.LoggedInUser.Meetings;
            foreach (Meeting m in tempMeetings)
            {
                if (m.ToString() == lbNotAccepted.SelectedItem)
                {
                    return m;
                }
            }
            return null;
        }

        private Meeting GetMeetingAccepted()
        {
            List<Meeting> tempMeetings = FormProvider.LoggedInUser.Meetings;
            foreach (Meeting m in tempMeetings)
            {
                if (m.ToString() == lbAccepted.SelectedItem)
                {
                    return m;
                }
            }
            return null;
        }

        private void lbAccepted_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedMeeting = GetMeetingAccepted();
            RefreshUI();
        }
    }
}
