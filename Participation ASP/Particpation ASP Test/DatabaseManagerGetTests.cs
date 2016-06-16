using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Participation_ASP.Models;


namespace Particpation_ASP_Test
{
    [TestClass]
    public class DatabaseManagerGetTests
    {
        [TestMethod]
        public void GetAccountsTest()
        {
            var accounts = DatabaseManager.GetAccounts();
            Assert.AreNotEqual(accounts.Count, 0);
        }


        [TestMethod]
        public void GetAccountTest()
        {
            var account = DatabaseManager.GetAccount("volunteer@volunteer.nl", "volunteer");
            Assert.IsNotNull(account);
        }

        [TestMethod]
        public void GetRequests()
        {
            List<Request> requests = DatabaseManager.GetRequests();
            Assert.AreNotEqual(requests.Count, 0);
        }

        [TestMethod]
        public void GetSkillsByVolunteer()
        {
            Volunteer volunteer = new Volunteer(2, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, new DateTime(), string.Empty, string.Empty, false, false, "7as343sd", false, true, new DateTime(), "photolink", "voglink", false);
            List<Skill> skills = DatabaseManager.GetSkills(volunteer);
            Assert.AreNotEqual(skills.Count, 0);
        }

        [TestMethod]
        public void GetAvailabilities()
        {
            Volunteer volunteer = new Volunteer(2, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, new DateTime(), string.Empty, string.Empty, false, false, "7as343sd", false, true, new DateTime(), "photolink", "voglink", false);
            List<Availability> availabilities = DatabaseManager.GetAvailabilities(volunteer);
            Assert.AreNotEqual(availabilities.Count, 0);
        }

        [TestMethod]
        public void GetSkills()
        {
            List<Skill> skills = DatabaseManager.GetSkills();
            Assert.AreNotEqual(skills.Count, 0);
        }
    }
}