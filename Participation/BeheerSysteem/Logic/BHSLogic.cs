using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Participation.SharedModels;
using Participation.InlogSysteem.Interfaces;

namespace Participation.BeheerSysteem.Logic
{
    class BHSLogic
    {

        public List<IUser> Users { get; set; }
        public List<Request> Requests { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Volunteer> Volunteers { get; set; }

        public BHSLogic()
        {
            this.Users = GetUsers();
            this.Requests = GetRequests();
            this.Reviews = GetReviews();
        }

        public void CreateNewAccount()
        {
            //nog in te vullen.
        }

        public List<IUser> GetUsers()
        {
            return DatabaseManager.GetUsers();

        }

        public List<Request> GetRequests()
        {
            return DatabaseManager.GetRequests();
        }

        public List<Review> GetReviews()
        {
            return DatabaseManager.GetReviews();
        }

        //Bans Users permanently
        public bool BanUserPermanent(IUser user)
        {
            /*
            List<IUser> tempusers = GetUsers();
            IUser u = new IUser();
            user = u;
            foreach (IUser tempuser in tempusers)
            {
                if (tempusers.ToString() == tempuser.ToString())
                {
                    u = tempuser;
                    tempuser.Ban = 2;
                    return true;
                }
            }
            return false;
            */
            throw new NotImplementedException();
        }
        // Bans users temporary
        public bool BanUserTemporary(IUser user, int bantime)
        {
            /*
            List<IUser> tempusers = GetUsers();
            User u = new IUser();
            user = u;
            foreach (User tempuser in tempusers)
            {
                if (tempusers.ToString() == tempuser.ToString())
                {
                    u = tempuser;
                    tempuser.Ban = 1;
                    tempuser.BantimeinDays = bantime;
                    return true;
                }
            }
            return false;
            */
            throw new NotImplementedException();
        }
        //Deletes an account
        public bool DeleteAcount(IUser user)
        {
            /*
            List<IUser> tempusers = GetUsers();
            User u = new IUser();
            user = u;
            foreach (IUser tempuser in tempusers)
            {
                if (tempusers.ToString() == tempuser.ToString())
                {
                    u = tempuser;
                    Users.Remove(u);
                    return true;
                }
            }
            return false;
            */
            throw new NotImplementedException();
        }
        //Deletes a Request
        public bool DeleteRequest(Request request)
        {
            /*
            List<Request> temprequests = GetRequests();
            Request r = new Request();
            request = r;
            foreach (Request temprequest in Requests)
            {
                if (temprequests.ToString() == temprequest.ToString())
                {
                    r = temprequest;
                    Requests.Remove(r);
                    return true;
                }
            }
            return false;
            */
            throw new NotImplementedException();
        }
        //Deletes a review
        public bool DeleteReview(Review review)
        {
            /*
            List<Review> tempreviews = GetReviews();
            Review r = new Review();
            review = r;
            foreach (Review tempreview in Reviews)
            {
                if (tempreviews.ToString() == tempreview.ToString())
                {
                    r = tempreview;
                    Reviews.Remove(r);
                    return true;
                }
            }
            return false;
            */
            throw new NotImplementedException();
        }

        //Changes Admin Rights <- moet worden aangepast na update van database methodes.
        public bool ChangeAdminRights(IUser user)
        {
            /*
            List<Volunteer> Volunteers = DatabaseManager.GetVolunteer();
            Volunteer V = new Volunteer();
            V = null;
            foreach (Volunteer tempvolunteer in Volunteers)
            {
                if (Volunteers.ToString() == tempvolunteer.ToString())
                {
                    V = tempvolunteer;
                    V.Adminrights = true;
                    return true;
                }
            }
            V.Adminrights = false;
            return false;
            */
            throw new NotImplementedException();
        }

    }
}
