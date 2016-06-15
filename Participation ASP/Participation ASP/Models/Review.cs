using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Participation_ASP.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        public Account Patient { get; set; }

        public int Rating { get; set; }

        public string Context { get; set; }


        public Review(int reviewId, Account patient, int rating, string context)
        {
            ReviewId = reviewId;
            Patient = patient;
            Rating = rating;
            Context = context;
        }
    }
}