using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Participation_ASP.Models
{
    public class ViewModel
    {

        public List<IAccount> AccountList { get; private set; }
        public List<Request> RequestList { get; private set; }
        public List<Meeting> MeetingList { get; private set; }

        public ViewModel()
        {
            this.AccountList = GetAccountList();
            this.RequestList = GetRequestList();
            //this.MeetingList = GetMeetingList();
        }

        public List<IAccount> GetAccountList()
        {
            return DatabaseManager.GetAccounts();
        }

        public List<Request> GetRequestList()
        {
            return DatabaseManager.GetRequests();
        }

        public List<Meeting> GetMeetingList()
        {
            return DatabaseManager.GetMeetings();
        }

        public void AddMeeting(Meeting meeting)
        {
            DatabaseManager.AddMeeting(meeting);
        }
    }
}