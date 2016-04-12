using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Participation.SharedModels;

namespace Participation.SharedModels
{
    public class Patient : User
    {
        //properties
        public List<Request> requests { get; set; }

        //constructors
        public Patient(string name, string email, string description, DateTime birthday, string profilePicture, string location, string phoneNumber, GenderEnum gender, string password, List<Meeting> meetings) : base(name, email, description, birthday, profilePicture, location, phoneNumber, gender, password, meetings)
        {
            requests = new List<Request>();
        }

        public Patient(string email, string password) : base(email, password)
        {
            requests = new List<Request>();
        }


        //Methods
        private void AddRequest(string title, string text, List<string> perks, string location, DateTime date, int urgency)
        {
            Request req = new Request(title, text, perks, location, date, urgency);

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
