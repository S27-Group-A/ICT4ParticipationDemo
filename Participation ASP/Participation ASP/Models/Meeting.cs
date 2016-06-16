using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Participation_ASP.Models
{
    public class Meeting
    {
        public Patient Patient { get; set; }
        public Volunteer Volunteer { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }

        public Meeting(Patient patient, Volunteer volunteer, string location, DateTime date, bool status)
        {
            this.Patient = patient;
            this.Volunteer = volunteer;
            this.Location = location;
            this.Date = date;
            this.Status = status;
        }

        public bool AddMeeting(Meeting meeting)
        {
            return DatabaseManager.AddMeeting(meeting);
        }
    }
}