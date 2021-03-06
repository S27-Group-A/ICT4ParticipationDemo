﻿namespace Participation.SharedModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Participation.InlogSysteem.Interfaces;

    public class Meeting
    {
        //private bool _volunteerAccepted = false;
        //private bool _patientAccepted = false;
        // Properties
        public IUser Volunteer { get; set; }
        public IUser Patient { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }

        // constructor
        public Meeting(IUser volunteer, IUser patient, DateTime date, string location)
        {
            this.Volunteer = volunteer;
            this.Patient = patient;
            this.Date = date;
            this.Location = location;
        }

        public Meeting(Volunteer volunteer, Patient patient, DateTime date, string location)
        {
            //this.Id = Id; --TODO Get id 
            this.Volunteer = volunteer;
            this.Patient = patient;
            this.Date = date;
            this.Location = location;
        }





        // Methods
        /*
        public bool AcceptMeeting(Patient patient)
        {
            if (patient == this.Patient)
            {
                _patientAccepted = true;
                return true;
            }
            return false;
        }
        */
        /*
        public bool AcceptMeeting(Volunteer volunteer)
        {
            if (volunteer == this.Volunteer)
            {
                _volunteerAccepted = true;
                return true;
            }
            return false;
        }
        */

        /*
        public bool CheckAccepeted()
        {
            if (_volunteerAccepted && _patientAccepted)
            {
                return true;
            }
            return false;
        }
        */
    }
}
