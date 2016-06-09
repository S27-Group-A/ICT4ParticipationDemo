using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


//TODO Optionally change parent to OracleException
namespace MyFigureCollection.Exceptions
{
    public class DatabaseNotConnectedException : Exception
    {
        public DatabaseNotConnectedException()
        {
        }

        public DatabaseNotConnectedException(string message) : base(message)
        {
        }
    }
}