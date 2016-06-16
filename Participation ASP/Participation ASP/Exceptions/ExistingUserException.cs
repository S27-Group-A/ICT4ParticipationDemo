using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Participation_ASP.Exceptions
{
    public class ExistingUserException : Exception
    {
        public ExistingUserException()
        {
        }

        public ExistingUserException(string message) : base(message)
        {

        }
    }


}