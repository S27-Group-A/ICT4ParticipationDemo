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

        public Request(string title, string text, string location)
        {
            this.Title = title;
            this.Text = text;
            this.Location = location;
        }

        // properties

        /// <summary>
        /// Gets or sets the title of the request
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the text or description or the request
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the location or city of the request
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the urgency of the request
        /// </summary>
        public int Urgency { get; set; }

        /// <summary>
        /// Gets or sets the date of the request
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets the perks of the request
        /// </summary>
        public List<string> Perks { get; private set; }

        /// <summary>
        /// Gets the responses of the request
        /// </summary>
        public List<Response> Responses { get; private set; }

        // methods

        /// <summary>
        /// Add a response to the list of the request
        /// </summary>
        /// <param name="The text of the response"></param>
        /// <param name="The date it got posted"></param>
        public void AddResponse(string text, Volunteer responder)
        {
            this.Responses.Add(new Response(text, DateTime.Now, responder));
        }

        /// <summary>
        /// Gives the request object in a single string
        /// </summary>
        /// <returns>Returns the string</returns>
        public override string ToString()
        {
            // TODO Optionally return perks per perk as string
            var returnString = this.Title + " " + this.Text + " " + this.Location + " " + this.Urgency + " " + this.Date.ToString() + " " + this.Perks.ToString();
            return returnString;
        }
    }
}
