using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Participation_ASP.Models;

namespace Particpation_ASP_Test
{
    [TestClass]
    public class DatabaseManagerAlterTests
    {
        [TestMethod]
        public void AlterAdmin()
        {
            Assert.IsTrue(DatabaseManager.AlterAdmin(2));
        }
    }
}
