﻿using System;
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
        public Patient(string name, string email, string despription, DateTime birthday, string profilePicture, string location, string phoneNumber, GenderEnum gender)
            : base(name, email, despription, birthday, profilePicture, location, phoneNumber, gender)
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
