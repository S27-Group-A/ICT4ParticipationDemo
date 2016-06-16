using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Participation_ASP.Models;

namespace Particpation_ASP_Test
{
    [TestClass]
    public class DatabaseManagerDeleteTests
    {
        [TestMethod]
        public void DeleteReview()
        {
            Assert.IsTrue(DatabaseManager.DeleteReview(1));
        }
    }
}
