using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Participation.SharedModels;

namespace Participation.BeheerSysteem.Logic
{
    class AdministrationSystem
    {

        public List<User> Users { get; set; }
        bool CreateAccount = false;

        public AdministrationSystem()
        {
            this.Users = GetUsers();
        }

        public void CreateNewAccount()
        {
            //nog in te vullen.
        }

        public List<User> GetUsers()
        {
            return DatabaseManager.GetUsers();

        }

        //not finished yet.
        public void BanUser(User user)
        {
            List<User> tempusers = GetUsers();
            User u = new User();
            user = u;
            foreach (User tempuser in tempusers)
            {
                if (tempusers.ToString() == tempuser.ToString())
                {
                    u = tempuser;
                    break;
                }
            }
            //Update the user.
        }

        public void DeleteAcount(User user)
        {
            List<User> tempusers = GetUsers();
            User u = new User();
            user = u;
            foreach (User tempuser in tempusers)
            {
                if (tempusers.ToString() == tempuser.ToString())
                {
                    u = tempuser;
                    break;
                }
            }
            Users.Remove(u);
        }

        public void DetectSelecterdUser()
        {
            foreach (User tempuser in tempusers)
            {
                if (tempusers.ToString() == tempuser.ToString())
                {
                    u = tempuser;
                    break;
                }
            }
        }
    }
}
