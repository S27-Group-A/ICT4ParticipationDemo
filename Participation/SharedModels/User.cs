using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participation.SharedModels
{
    public class User
    {
        //Properties
        public string Name { get; set; }
        private string _email { get; set; }
        public string Description { get; set; }
        public DateTime Birthday { get; set; }
        public string ProfilePicture { get; set; }
        public string Location { get; set; }
        private string _phoneNumber { get; set; }
        public GenderEnum Gender { get; set; }
        private List<Meeting> _meetings { get; set; }

        //constructors
        public User(string name, string email, string despription, DateTime birthday, string profilePicture, string location, string phoneNumber, GenderEnum gender)
        {
            this.Name = name;
            this._email = email;
            this.Description = despription;
            this.Birthday = birthday;
            this.ProfilePicture = profilePicture;
            this.Location = location;
            this._phoneNumber = phoneNumber;
            this.Gender = gender;
            _meetings = new List<Meeting>();
        }

        //methods

        /// <summary>
        /// Profiel gegevens aanpassen
        /// </summary>
        private void EditProfile()
        {

        }
    }
}
