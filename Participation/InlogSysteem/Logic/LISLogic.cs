using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms.VisualStyles;
using Participation.InlogSysteem.Interfaces;
using Participation.SharedModels;

namespace Participation
{
    public class LISLogic
    {
        //INSERT Person Statement
        public bool AddUser(IUser user)
        {
            //TODO Add database context to add user to database

            return true;
        }

        //SELECT Person where string email
        public IUser GetUser(string email)
        {
            foreach (var user in GetUsers())
            {
                if (user.Email == email)
                    return user;
            }
            //Testing
            //TODO Dont forget to remove this later and make it a error pop-up instead
            var testUser = new Patient("test@testmail.com", "test");
            return testUser;
        }

        //Select Person 
        private List<IUser> GetUsers()
        {
            throw new NotImplementedException();
        } 
    }
}
