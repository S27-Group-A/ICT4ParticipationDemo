using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Participation_ASP.Models
{
    public class Response
    {
        public int ResponderId { get; set; }
        public int RequestId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public Response(int responderid, int RequestId, string description, DateTime date)
        {
            this.ResponderId = responderid;
            this.RequestId = RequestId;
            this.Description = description;
            this.Date = date;
        public Account Volunteer { get; set; }

        public string Context { get; set; }

        public DateTime ResponseDate { get; set; }


        public Response(Account volunteer, string context, DateTime responseDate)
        {
            Volunteer = volunteer;
            Context = context;
            ResponseDate = responseDate;
        }
    }
}