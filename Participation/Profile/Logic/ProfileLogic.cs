using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Participation.InlogSysteem.Interfaces;

namespace Participation.Profile.Logic
{
    public class ProfileLogic
    {
        public List<string> GetAvailability(IUser user)
        {
            return DatabaseManager.GetAvailability(user);
        }

        public bool SetAvailability(IUser user, List<string> times)
        {
            return DatabaseManager.SetAvailability(user, times);
        }

        public bool UpdateAvailability(IUser user, List<string> times)
        {
            return DatabaseManager.UpdateAvailability(user, times);
        }
    }
}
