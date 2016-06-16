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

        public string Comment { get; set; }


        public Review(int reviewId, Request request, int rating, string comment)
        {
            ReviewId = reviewId;
            Request = request;
            Rating = rating;
            Comment = comment;
        }
    }
}