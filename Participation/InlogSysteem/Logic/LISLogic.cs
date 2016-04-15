using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms.VisualStyles;
using Participation.SharedModels;

namespace Participation
{
    public class LISLogic
    {
        public bool AddUser(Patient patient)
        {
            //TODO Add database context to add user to database

            return true;
        }

        public bool AddUser(Volunteer volunteer)
        {
            //TODO Add database context to add user to database

            return true;
        }

        public User GetUser(string email)
        {
            foreach (var user in GetUsers())
            {
                if (user.Email == email)
                    return user;
            }
            //Testing
            //TODO Dont forget to remove this later and make it a error pop-up instead
            var testUser = new User("test@testmail.com", "test");
            return testUser;
        }

        private List<User> GetUsers()
        {
            //TODO Get all users from database
            throw new NotImplementedException();
        }
    }
}
