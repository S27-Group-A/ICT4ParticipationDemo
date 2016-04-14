namespace Participation.SharedModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Meeting
    {
        // constructor
        public Meeting(Volunteer volunteer, Patient patient, DateTime date, string location)
        {
            this.Volunteer = volunteer;
            this.Patient = patient;
            this.Date = date;
            this.Location = location;
        }

        // Properties

        public Volunteer Volunteer { get; private set; }
        public Patient Patient { get; private set; }
        public DateTime Date { get; private set; }
        public string Location { get; private set; }

        // Methods

        public bool AcceptMeeting()
        {
            return false;
        }
    }
}
