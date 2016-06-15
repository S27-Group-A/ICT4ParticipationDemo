using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;

namespace Participation_ASP.Exceptions
{
    public class DayException : Exception
    {
        public DayException()
        {
        }

        public DayException(string message) : base(message)
        {

        }
    }
}