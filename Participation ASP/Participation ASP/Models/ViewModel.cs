// <copyright file="notfound" company="EyeCT">
//     Participation ASP All rights reserved.
// </copyright>
// <author>S27 Group A</author>

namespace Participation_ASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class ViewModel
    {
        /// <summary>
        /// Gets account list
        /// </summary>
        public List<IAccount> AccountList { get; private set; }

        /// <summary>
        /// Gets request list
        /// </summary>
        public List<Request> RequestList { get; private set; }

        /// <summary>
        /// Gets meeting list
        /// </summary>
        public List<Meeting> MeetingList { get; private set; }

        /// <summary>
        /// Get skill list
        /// </summary>
        public List<Skill> SkillList { get; set; }

        /// <summary>
        /// Default constructor of viewmodel
        /// </summary>
        public ViewModel()
        {
            this.AccountList = GetAccountList();
            this.RequestList = GetRequestList();
            this.MeetingList = GetMeetingList();
            this.SkillList = GetSkillList();
        }

        /// <summary>
        /// Returns all the accounts from the database
        /// </summary>
        /// <returns>Returns accounts</returns>
        public List<IAccount> GetAccountList()
        {
            return DatabaseManager.GetAccounts();
        }

        /// <summary>
        /// Returns all the requests from the database
        /// </summary>
        /// <returns>Returns requests</returns>
        public List<Request> GetRequestList()
        {
            return DatabaseManager.GetRequests();
        }

        /// <summary>
        /// Returns all the meetings from the database
        /// </summary>
        /// <returns>Returns meetings</returns>
        public List<Meeting> GetMeetingList()
        {
            return DatabaseManager.GetMeetings();
        }

        /// <summary>
        /// Returns all the skills from the database
        /// </summary>
        /// <returns>Returns skills</returns>
        public List<Skill> GetSkillList()
        {
            return DatabaseManager.GetSkills();
        }

        /// <summary>
        /// Adds meeting to the database
        /// </summary>
        /// <param name="meeting">meeting to be added</param>
        public void AddMeeting(Meeting meeting)
        {
            DatabaseManager.AddMeeting(meeting);
        }
    }
}