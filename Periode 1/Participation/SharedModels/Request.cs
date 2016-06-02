using System.Data;

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
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Location { get; set; }
        public int Urgency { get; set; }
        public DateTime Date { get; set; }
        public List<string> Perks { get; set; }
        public List<Response> Responses { get; private set; }

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

        // constructors
        public Request(int id, string title, string text, List<string> perks, string location, DateTime date, int urgency)
        {
            this.Id = id;
            this.Title = title;
            this.Text = text;
            this.Perks = new List<string>();
            this.Location = location;
            this.Date = date;
            this.Urgency = urgency;
            this.Responses = new List<Response>();

        }

        public Request(string title, string text, List<string> perks, string location, DateTime date, int urgency)
        {
            this.Title = title;
            this.Text = text;
            this.Perks = new List<string>();
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
            throw new InvalidConstraintException("Constructor not properly supported");
            //this.Responses.Add(new Response(text, DateTime.Now));
        }


        public override string ToString()
        {
            // TODO Optionally return Perks per perk as string
            var returnString = this.Title;
            return returnString;
        }
    }
}
