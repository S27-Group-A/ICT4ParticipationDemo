using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms.VisualStyles;
using Participation.SharedModels;

namespace Participation
{
    public class LISLogic
    {
        public bool AddUser(User user)
        {
            //TODO Add database context to add user to database

            return false;  
        }

        public User GetUser(string email)
        {
            foreach (var user in GetUsers())
            {
                if(user.Email == email)
                    return user;
            }
            //Testing
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