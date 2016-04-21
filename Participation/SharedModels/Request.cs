namespace Participation.SharedModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The class of request
    /// </summary>
    public class Request
    {
        // properties

        public string Title { get; set; }
        public string Text { get; set; }
        public string Location { get; set; }
        public int Urgency { get; set; }
        public DateTime Date { get; set; }
        public List<string> Perks { get; private set; }
        public List<Response> Responses { get; private set; }



        /// <summary>
        /// Gives the request object in a single string
        /// </summary>
        /// <returns>Returns the string</returns>

        // constructors

        public Request(string title, string text, List<string> perks, string location, DateTime date, int urgency)
        {
            this.Title = title;
            this.Text = text;
            this.Perks = perks;
            this.Location = location;
            this.Date = date;
            this.Urgency = urgency;
            this.Responses = new List<Response>();

        }

        // methods
        //TODO Shoul go into the logic layer
        /// <summary>
        /// Add a response to the list of the request
        /// </summary>
        /// <param name="The text of the response"></param>
        /// <param name="The date it got posted"></param>
        public void AddResponse(string text)
        {
            this.Responses.Add(new Response(text, DateTime.Now));
        }


        public override string ToString()
        {
            // TODO Optionally return perks per perk as string
            var returnString = this.Title + " " + this.Text + " " + this.Location + " " + this.Urgency + " " + this.Date.ToString() + " " + this.Perks.ToString();
            return returnString;
        }
    }
}
