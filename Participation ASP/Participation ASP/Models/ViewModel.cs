using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Participation_ASP.Models
{
    public class ViewModel
    {
        public List<IAccount> GetAccountList()
        {
            return DatabaseManager.GetAccounts();
        }

        public List<Request> GetRequestList()
        {
            return DatabaseManager.GetRequests();
        }

        //TODO Remove this
        public List<Response> GetResponseList()
        {
            throw new NotImplementedException("Is this function really needed? Just call GetRequestList.Responses?");
            return DatabaseManager.GetResponses();
        }
    }
}