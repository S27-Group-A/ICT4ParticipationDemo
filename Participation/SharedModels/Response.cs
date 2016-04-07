using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participation.SharedModels
{
    public class Response
    {
        //properties
        public string Text { get; set; }
        public DateTime Date { get; set; }

        //constructors
        public Response(string text, DateTime date)
        {
            this.Text = text;
            this.Date = date;
        }
    }
}
