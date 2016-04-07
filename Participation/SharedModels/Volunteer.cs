using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participation.SharedModels
{
    public class Volunteer : User
    {
        //properties
        private List<Review> _reviews { get; set; }
        private List<string> _perks { get; set; }
        private string _verklaringPdf { get; set; }

        //constructors
        public Volunteer(string name, string email, string despription, DateTime birthday, string profilePicture, string location, string phoneNumber, GenderEnum gender, List<string> perks)
            : base(name, email, despription, birthday, profilePicture, location, phoneNumber, gender)
        {
            _reviews = new List<Review>();
            this._perks = perks;
            _verklaringPdf = null;
        }

        //methods
        public bool InviteToChat()
        {
            return false;
        }

    }
}
