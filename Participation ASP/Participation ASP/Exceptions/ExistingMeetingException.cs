using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;

namespace Participation_ASP.Exceptions
{
    public class ExistingMeetingException : Exception
    {
        public ExistingMeetingException()
        {
        }

        public ExistingMeetingException(string message) : base(message)
        {

        }
    }
}