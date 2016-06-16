using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Participation_ASP.Models;

namespace Particpation_ASP_Test
{
    [TestClass]
    public class DatabaseManagerDeleteTests
    {
        [TestMethod]
        public void DeleteRequest()
        {
            DatabaseManager.DeleteRequest(2);
        }

        [TestMethod]
        public void DeleteReview()
        {
            DatabaseManager.DeleteReview(2);
        }
    }
}
