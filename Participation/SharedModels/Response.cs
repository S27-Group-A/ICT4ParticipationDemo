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
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        //constructors
        public Response(int Id, string text, DateTime date)
        {
            this.Id = Id;
            this.Text = text;
            this.Date = date;
        }
    }
}
