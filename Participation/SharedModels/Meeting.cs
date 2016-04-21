namespace Participation.SharedModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Meeting
    {
        private bool _volunteerAccepted = false;
        private bool _patientAccepted = false;

        // constructor
        public Meeting(Volunteer volunteer, Patient patient, DateTime date, string location)
        {
            this.Volunteer = volunteer;
            this.Patient = patient;
            this.Date = date;
            this.Location = location;
        }

        

        // Properties

        /// <summary>
        /// Gets the volunteer from meeting
        /// </summary>
        public Volunteer Volunteer { get; private set; }

        /// <summary>
        /// Gets the Patient from meeting
        /// </summary>
        public Patient Patient { get; private set; }

        /// <summary>
        /// Gets the date and time when the meeting is planned
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// Gets the location of the meeting
        /// </summary>
        public string Location { get; private set; }

        // Methods

        public bool AcceptMeeting(Patient patient)
        {
            if (patient == this.Patient)
            {
                _patientAccepted = true;
                return true;
            }
            return false;
        }

        public bool AcceptMeeting(Volunteer volunteer)
        {
            if (volunteer == this.Volunteer)
            {
                _volunteerAccepted = true;
                return true;
            }
            return false;
        }

        public bool CheckAccepeted()
        {
            if (_volunteerAccepted && _patientAccepted)
            {
                return true;
            }
            return false;
        }
    }
}
