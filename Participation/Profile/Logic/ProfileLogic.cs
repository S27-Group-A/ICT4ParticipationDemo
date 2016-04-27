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
            DatabaseManager.GetAvailability(user);
            throw new NotImplementedException();
        }
    }
}
