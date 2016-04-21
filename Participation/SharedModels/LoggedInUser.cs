using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participation.SharedModels
{
    public static class LoggedInUser
    {
        public static Patient LoggedInPatient { get; set; }
        public static Volunteer LoggedInVolunteer { get; set; }
    }
}
