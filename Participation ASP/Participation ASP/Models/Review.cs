using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Participation_ASP.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        public Account Volunteer { get; set; }

        public Account Patient { get; set; }

        public int Rating { get; set; }

        public string Context { get; set; }


        public Review(int reviewId, Volunteer volunteer, Account patient, int rating, string context)
        {
            this.ReviewId = reviewId;
            this.Volunteer = volunteer;
            this.Patient = patient;
            this.Rating = rating;
            this.Context = context;
        }
    }
}