using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;

namespace Participation_ASP.Exceptions
{
    public class TimeOfDayException : Exception
    {
        public TimeOfDayException()
        {
        }

        public TimeOfDayException(string message) : base(message)
        {

        }
    }
}