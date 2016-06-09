using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Participation_ASP.Models
{
    public class Request
    {
        public int RequestId { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime TimeStamp { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Urgency { get; set; }
        public int AmountOfVolunteers { get; set; }

        public Request(int requestId, string description, string location, DateTime timeStamp, DateTime startDate,
            DateTime endDate, int urgency, int amountOfVolunteers)
        {
            this.RequestId = requestId;
            this.Description = description;
            this.Location = location;
            this.TimeStamp = timeStamp;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Urgency = urgency;
            this.AmountOfVolunteers = amountOfVolunteers;
        }
    }
}