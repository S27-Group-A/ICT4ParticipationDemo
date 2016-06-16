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
        public List<Skill> SkillList { get; set; }

        public ViewModel()
        {
            this.AccountList = GetAccountList();
            this.RequestList = GetRequestList();
            this.MeetingList = GetMeetingList();
            this.SkillList = GetSkillList();
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

        public List<Skill> GetSkillList()
        {
            return DatabaseManager.GetSkills();
        }

        public void AddMeeting(Meeting meeting)
        {
            DatabaseManager.AddMeeting(meeting);
        }
    }
}