using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Participation_ASP.Models
{
    public class Response
    {
        public Account Volunteer { get; set; }

        public string Description { get; set; }

        public DateTime ResponseDate { get; set; }

        public int ResponseId { get; set; }


        public Response(Account volunteer, string description, DateTime responseDate)
        {
            Volunteer = volunteer;
            Description = description;
            ResponseDate = responseDate;
        }

        public bool AddResponse(Response response, Request request)
        {
            return DatabaseManager.AddResponse(response, request);
        }
    }
}