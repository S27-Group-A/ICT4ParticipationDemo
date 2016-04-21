using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Participation.InlogSysteem.Interfaces;

namespace Participation.SharedModels
{
    public class Response
    {
        //properties
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public Volunteer Responder { get; private set; }

        //constructors
        public Response(int Id, string text, DateTime date, Volunteer responder)
        {
            this.Id = Id;
            this.Responder = responder;
            this.Text = text;
            this.Date = date;
        }


    }
}
}
