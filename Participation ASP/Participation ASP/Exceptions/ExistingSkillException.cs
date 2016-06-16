using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;

namespace Participation_ASP.Exceptions
{
    public class ExistingSkillException : Exception
    {
        public ExistingSkillException()
        {
        }

        public ExistingSkillException(string message) : base(message)
        {

        }
    }
}