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
        public List<string> Perks { get; set; }
        public List<Response> Responses { get; set; }

        public Request(
            string title, 
            string text, 
            List<string> perks, 
            string location, 
            DateTime date, 
            int urgency
            )
        {
            this.Title = title;
            this.Text = text;
            this.Perks = perks;
            this.Location = location;
            this.Date = date;
            this.Urgency = urgency;
            Responses = new List<Response>();

        }

        public Request(string title, string text, string location)
        {
            this.Title = title;
            this.Text = text;
            this.Location = location;
        }


        public void AddResponse(string text, DateTime date)
        {
            Responses.Add(new Response(text, date));
            Text = text;
            Date = date;
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
