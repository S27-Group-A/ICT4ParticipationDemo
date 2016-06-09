using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Participation_ASP.Models
{
    public class Response
    {
        public int ResponseId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public Response(int responseid, string description, DateTime date)
        {
            this.ResponseId = responseid;
            this.Description = description;
            this.Date = date;
        }

    }
}