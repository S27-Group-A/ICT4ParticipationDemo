namespace Participation_ASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public class Meeting
    {
        /// <summary>
        /// Get or set the patient
        /// </summary>
        public Patient Patient { get; set; }
        /// <summary>
        /// Get or sets the volunteer
        /// </summary>
        public Volunteer Volunteer { get; set; }
        /// <summary>
        /// Get or sets the location
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Gets or sets the date
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// gets or sets the status
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// De constructor waar alle properties mee worden gevuld
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="volunteer"></param>
        /// <param name="location"></param>
        /// <param name="date"></param>
        /// <param name="status"></param>
        public Meeting(Patient patient, Volunteer volunteer, string location, DateTime date, bool status)
        {
            this.Patient = patient;
            this.Volunteer = volunteer;
            this.Location = location;
            this.Date = date;
            this.Status = status;
        }

        /// <summary>
        /// Lege constructor
        /// </summary>
        public Meeting()
        {

        }

        /// <summary>
        /// Voegt een nieuwe meeting toe aan de database
        /// </summary>
        /// <param name="meeting"></param>
        /// <returns></returns>
        public bool AddMeeting(Meeting meeting)
        {
            return DatabaseManager.AddMeeting(meeting);
        }
    }
}