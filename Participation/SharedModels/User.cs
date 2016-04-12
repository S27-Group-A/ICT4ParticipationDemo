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
        public string Password { get; set; }
        private List<Meeting> _meetings { get; set; }

        //constructors
        public User(string name, string email, string description, DateTime birthday, string profilePicture, string location, string phoneNumber, GenderEnum gender, string password, List<Meeting> meetings)
        {
            Name = name;
            _email = email;
            Description = description;
            Birthday = birthday;
            ProfilePicture = profilePicture;
            Location = location;
            _phoneNumber = phoneNumber;
            Gender = gender;
            Password = password;
            _meetings = meetings;
        }

        public User(string email, string password)
        {
            _email = email;
            Password = password;
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
