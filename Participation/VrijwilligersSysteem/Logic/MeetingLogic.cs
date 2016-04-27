using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Participation.InlogSysteem.Interfaces;
using Participation.SharedModels;

namespace Participation.VrijwilligersSysteem.Logic
{
    public class MeetingLogic
    {
        public List<Volunteer> Volunteers { get; set; }
        public MeetingLogic()
        {
            Volunteers = GetAllVolunteers();
        }

        public List<Volunteer> GetAllVolunteers()
        {
            List<Volunteer> tempVolunteers = new List<Volunteer>();
            List<IUser> allUsersTemp = DatabaseManager.GetUsers();
            foreach (IUser iu in allUsersTemp)
            {
                if (iu is Volunteer)
                {
                    tempVolunteers.Add(iu as Volunteer);
                }
            }
            return tempVolunteers;
        }

        public bool AddMeeting(Volunteer volunteer, Patient patient, DateTime date, string location)
        {
            if (date >= DateTime.Today)
            {
                if (DatabaseManager.AddMeeting(volunteer, patient, date, location, 0))
                {
                    Meeting meeting = new Meeting(volunteer, patient, date, location, 0);
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            else
            {
                return false;
            }
        }
    }
}
