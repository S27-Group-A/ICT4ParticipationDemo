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
        public Volunteer(string name, string email, string description,
            DateTime birthday, string profilePicure, string location,
            string phoneNumber, GenderEnum gender, string password)
            : base(name, email, description, birthday, profilePicure, location, phoneNumber, gender, password)
        {
            _reviews = new List<Review>();
            _perks = new List<string>();
            _verklaringPdf = "";
        }


        


        //methods
        public bool InviteToChat()
        {
            return false;
        }

    }
}
