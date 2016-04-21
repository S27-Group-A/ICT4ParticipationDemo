using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Participation.SharedModels;

namespace Participation.SharedModels
{
    public class Patient : User
    {
        //properties
        public List<Request> Requests { get; set; }

        //constructors
        public Patient(int id, string name, string email, string description, DateTime birthday, string profilePicture,
            string location, string phoneNumber, GenderEnum gender, string password) : base(id, name, email, description,
                birthday, profilePicture, location, phoneNumber, gender, password)
        {
            Requests = new List<Request>();
        }



        //Methods
        //TODO Move this to logic layer and add id to your parameters
        public void AddRequest(string title, string text, List<string> perks, string location, DateTime date, int urgency)
        {
            Request req = new Request(title, text, perks, location, date, urgency);
            Requests.Add(req);
        }

        private void RemoveRequest()
        {

        }

        private void ChangeRequest()
        {

        }

        private void AddReview()
        {

        }

        private bool AcceptChatInvitation()
        {
            return false;
        }
    }
}
