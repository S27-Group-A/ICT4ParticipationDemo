using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Participation.InlogSysteem.Interfaces;

namespace Participation.SharedModels
{
    public class Review
    {
        public int Id { get; set; }
        public double Rating { get; set; }
        public string Text { get; set; }

        public IUser Patient { get; set; }

        public IUser Volunteer { get; set; }
        public Review(int Id, double Rating, string Text)
        {
            this.Id = Id;
            this.Rating = Rating;
            this.Text = Text;
        }

        public Review(double Rating, string Text)
        {
            //this.Id = Id; TODO set id
            this.Rating = Rating;
            this.Text = Text;
        }
    }
}
