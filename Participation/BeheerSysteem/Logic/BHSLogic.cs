using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        //TODO Methode vervalt
        /*
        public void CreateNewAccount()
        {
            //nog in te vullen.
        }
        */

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
        public bool BanUser(IUser user)
        {
            foreach (var u in GetUsers())
            {
                if (u.Id == user.Id)
                {
                    return DatabaseManager.BanUser(user);
                }
            }
            return false;

        }

        public bool BanUser(IUser user, DateTime unbanDate)
        {
            foreach (var u in GetUsers())
            {
                if (u.Id == user.Id)
                {
                    return DatabaseManager.BanUser(user, unbanDate);
                }
            }
            return false;
        }

        //Deletes an account
        public bool DeleteAcount(IUser user)
        {
            if (user.Id != FormProvider.LoggedInUser.Id)
            {

                foreach (var u in GetUsers())
                    if (u.Id == user.Id)
                        return (DatabaseManager.RemoveUser(user));
                return false;
            }
            MessageBox.Show("Je kunt niet jezelf verwijderen!");
            return false;
        }
        //Deletes a Request
        public bool DeleteRequest(Request request)
        {
            foreach (Request req in GetRequests())
                if (req.Id == request.Id)
                    return DatabaseManager.DeleteRequest(request);
            return false;
        }
        //Deletes a review
        public bool DeleteReview(Review review)
        {

            foreach (var r in GetReviews())
                if (r.Id == review.Id)
                    return DatabaseManager.DeleteReview(review);
            return false;
        }

        //Changes Admin Rights <- moet worden aangepast na update van database methodes.
        public bool ChangeAdminRights(IUser user)
        {
            foreach (var u in GetUsers())
                if (u.Id == user.Id)
                    return DatabaseManager.ChangePermission(user);
            return false;
        }

        public IUser GetUser(IUser user)
        {
            return DatabaseManager.GetUser(user.Email);
        }
    }
}
