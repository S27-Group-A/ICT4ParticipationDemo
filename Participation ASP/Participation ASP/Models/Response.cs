using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Participation_ASP.Models
{
    public class Response
    {
        public Account Volunteer { get; set; }

        public Request Request { get; set; }

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