using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participation.SharedModels
{
    public class Request
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Location { get; set; }
        public int Urgency { get; set; }
        public DateTime Date { get; set; }
        public List<string> Perks = new List<string>();

        public Request(
            string title, 
            string text, 
            List<string> perks, 
            string location, 
            DateTime date, 
            int urgency
            )
        {
            Title = title;
            Text = text;
            Perks = perks;
            Location = location;
            Date = date;
            Urgency = urgency;
        }

        public Request(string title, string text, string location)
        {
            Title = title;
            Text = text;
            Location = location;
        }

        public Request()
        {
        }

        public override string ToString()
        {
            //TODO Optionally return perks per perk as string
            var returnString = Title + " " + Text + " " + Location + " " + Urgency + " " + Date.ToString() + " " + Perks.ToString();
            return returnString;
        }
    }
}
