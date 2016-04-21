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
        public Patient()
        { }

        public Patient(string name, string email, string description, DateTime birthday, string profilePicture, 
            string location, string phoneNumber, GenderEnum gender, string password) : base(name, email, description, 
                birthday, profilePicture, location, phoneNumber, gender, password)
        {
            Requests = new List<Request>();
        }

        public Patient(string email, string password) : base(email, password)
        {
            Requests = new List<Request>();
        }

        public Patient(string name, string email, DateTime birthday, string location, string password) 
            : base(name, email, birthday, location, password)
        {
            Requests = new List<Request>();
        }

        public Patient(string name, string email, DateTime birthday, string location, string password, string phoneNumber)
            : base(name, email, birthday, location, password, phoneNumber)
        {
            Requests = new List<Request>();
        }


        //Methods
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
