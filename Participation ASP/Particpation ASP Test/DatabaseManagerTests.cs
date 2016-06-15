using System;
using System.Collections.Generic;
using System.Linq;
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

        [TestMethod]
        public void GetRequests()
        {
            List<Request> requests = DatabaseManager.GetRequests();
            Assert.IsNotNull(requests);
        }

        [TestMethod]
        public void GetSkills()
        {
            Volunteer volunteer = new Volunteer(1, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, new DateTime(), string.Empty, string.Empty, false, false, string.Empty, false, new DateTime(), true, false, new DateTime(), string.Empty, string.Empty, true);
            List<Skill> skills = DatabaseManager.GetSkills(volunteer);
            Assert.IsNotNull(skills);
        }
    }
}