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

        public List<User> Users {get; set;}
        bool CreateAccount = false;
        
        public AdministrationSystem()
        {
            this.Users = GetUsers();
        }

        public void CreateNewAccount()
        {
            
        }

        public List<User> GetUsers()
        {
           return DatabaseManager.GetUsers();
  
        }

        public void BanUser()
        {

        }
    }
}
