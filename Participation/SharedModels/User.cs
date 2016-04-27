using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Participation.InlogSysteem.Interfaces;

namespace Participation.SharedModels
{
    public abstract class User : IUser
    {
        //Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime Birthday { get; set; }
        public string ProfilePicture { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public GenderEnum Gender { get; set; }
        public string Password { get; set; }
        public List<Meeting> Meetings { get; set; }
        public int Ban { get; set; }
        public DateTime Unban { get; set; }

        //constructors

        public User(int Id, string name, string email, string description,
    DateTime birthday, string profilePicture, string location,
    string phoneNumber, GenderEnum gender, string password)
        {
            this.Id = Id;
            Name = name;
            Email = email;
            Description = description;
            Birthday = birthday;
            ProfilePicture = profilePicture;
            Location = location;
            PhoneNumber = phoneNumber;
            Gender = gender;
            Password = password;
            Meetings = null;
            Ban = 0;
        }

        public User(string name, string email, string description,
            DateTime birthday, string profilePicture, string location,
            string phoneNumber, GenderEnum gender, string password)
        {
            //this.Id = Id; TODO set id
            Name = name;
            Email = email;
            Description = description;
            Birthday = birthday;
            ProfilePicture = profilePicture;
            Location = location;
            PhoneNumber = phoneNumber;
            Gender = gender;
            Password = password;
            Meetings = null;
            Ban = 0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

