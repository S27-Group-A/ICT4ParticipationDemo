using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Participation_ASP.Models
{
    public class ViewModel
    {
        public List<Account> AccountList { get; private set; }

        public List<Account> GetAccountList()
        {
            return DatabaseManager.GetAccounts();
        }
    }
}