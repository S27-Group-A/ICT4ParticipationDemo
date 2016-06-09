﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Participation_ASP.Models
{
    public class ViewModel
    {
        public List<Account> GetAccountList()
        {
            return DatabaseManager.GetAccounts();
        }

        public List<Request> GetRequestList()
        {
            return DatabaseManager.GetRequests();
        }

        public List<Response> GetResponseList()
        {
            return DatabaseManager.GetResponses();
        }
    }
}