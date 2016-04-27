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
    }
}
