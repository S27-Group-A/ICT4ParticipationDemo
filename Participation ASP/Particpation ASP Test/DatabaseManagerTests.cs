using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Participation_ASP.Models;


namespace Particpation_ASP_Test
{
    [TestClass]
    public class DatabaseManagerTests
    {
        [TestMethod]
        public void GetAccountsTest()
        {
            var accounts = DatabaseManager.GetAccounts();
            Assert.IsNotNull(accounts);
        }
    }
}
