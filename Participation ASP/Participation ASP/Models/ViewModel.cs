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
        /// Gets Request list based on a specific Patient
        /// </summary>
        public List<Request> PatientRequestList { get; private set; }

        /// <summary>
        /// Gets Review list based on a specific Volunteer
        /// </summary>
        public List<Review> VolunteerReviewList { get; private set; }

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
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static ViewModel ViewModelRequestList(int id)
        {
            var viewmodel = new ViewModel();
            viewmodel.PatientRequestList = viewmodel.GetPatientRequestList(id);
            return viewmodel;
        }

        public static ViewModel ViewModelReviewList(int id)
        {
            var viewmodel = new ViewModel();
            viewmodel.VolunteerReviewList = viewmodel.GetVolunteerReviewList(id);
            return viewmodel;
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
        /// Returns all requests of a certain user from the database
        /// </summary>
        /// <param name="id"> accountId </param>
        /// <returns>Returns Requests</returns>
        public List<Request> GetPatientRequestList(int id)
        {
            return DatabaseManager.GetRequests(id);
        }

        /// <summary>
        /// Returns alle request of a certain user from the database
        /// </summary>
        /// <param name="id"> accountId </param>
        /// <returns>Retinr Reviews</returns>
        public List<Review> GetVolunteerReviewList(int id)
        {
            return DatabaseManager.GetReviews(id);
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