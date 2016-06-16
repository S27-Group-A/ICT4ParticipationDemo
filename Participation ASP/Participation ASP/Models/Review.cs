using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Participation_ASP.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        public Request Request { get; set; }

        public int Rating { get; set; }

        public string Context { get; set; }


        public Review(int reviewId, Request request, int rating, string context)
        {
            ReviewId = reviewId;
            Request = request;
            Rating = rating;
            Context = context;
        }
    }
}