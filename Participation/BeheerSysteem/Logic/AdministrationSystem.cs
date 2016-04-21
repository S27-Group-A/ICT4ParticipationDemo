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
        public List<Request> Requests { get; set; }
        public List<Review> Reviews { get; set; }

        public AdministrationSystem()
        {
            this.Users = GetUsers();
            this.Requests = GetRequests();
            this.Reviews = GetReviews();
        }

        public void CreateNewAccount()
        {
            //nog in te vullen.
        }

        public List<User> GetUsers()
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

        //not finished yet.
        public bool BanUser(User user)
        {
            List<User> tempusers = GetUsers();
            User u = new User();
            user = u;
            foreach (User tempuser in tempusers)
            {
                if (tempusers.ToString() == tempuser.ToString())
                {
                    u = tempuser;
                    //ban user
                    return true;
                }
            }
            return false;
        }

        public bool DeleteAcount(User user)
        {
            List<User> tempusers = GetUsers();
            User u = new User();
            user = u;
            foreach (User tempuser in tempusers)
            {
                if (tempusers.ToString() == tempuser.ToString())
                {
                    u = tempuser;
                    Users.Remove(u);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteRequest(Request request)
        {
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
        }

        public bool DeleteReview(Review review)
        {
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
        }
    }
}
