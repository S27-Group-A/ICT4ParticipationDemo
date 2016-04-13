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
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime Birthday { get; set; }
        public string ProfilePicture { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public GenderEnum Gender { get; set; }
        public string Password { get; set; }
        public List<Meeting> meetings { get; set; }

        //constructors
        public User()
        {
        }

        public User(string name, string email, string description, DateTime birthday, string profilePicture, string location, string phoneNumber, GenderEnum gender, string password)
        {
            Name = name;
            Email = email;
            Description = description;
            Birthday = birthday;
            ProfilePicture = profilePicture;
            Location = location;
            PhoneNumber = phoneNumber;
            Gender = gender;
            Password = password;
            meetings = new List<Meeting>();
        }

        public User(string name, string email, DateTime birthday, string location, string password, string phoneNumber)
        {
            Name = name;
            Email = email;
            Birthday = birthday;
            Location = location;
            Password = password;
            PhoneNumber = phoneNumber;
            meetings = new List<Meeting>();
        }

        public User(string name, string email, DateTime birthday, string location, string password, string phoneNumber, GenderEnum gender)
        {
            Name = name;
            Email = email;
            Birthday = birthday;
            Location = location;
            Password = password;
            PhoneNumber = phoneNumber;
            Gender = gender;
            meetings = new List<Meeting>();
        }

        public User(string name, string email, DateTime birthday, string location, string password, string phoneNumber, GenderEnum gender, string profilePicture)
        {
            Name = name;
            Email = email;
            Birthday = birthday;
            Location = location;
            Password = password;
            PhoneNumber = phoneNumber;
            Gender = gender;
            ProfilePicture = profilePicture;
            meetings = new List<Meeting>();
        }


        public User(string email, string password)
        {
            Email = email;
            Password = password;
            Birthday = new DateTime();
        }

        public User(string name, string email, DateTime birthday, string location, string password)
        {
            Name = name;
            Email = email;
            Birthday = birthday;
            Location = location;
            Password = password;
            meetings = new List<Meeting>();
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
