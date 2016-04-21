using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Participation.SharedModels
{
    public class Review
    {
        public int Id { get; set; }
        public double Rating { get; set; }
        public string Text { get; set; }

        public Review(int Id, double Rating, string Text)
        {
            this.Id = Id;
            this.Rating = Rating;
            this.Text = Text;
        }
    }
}
