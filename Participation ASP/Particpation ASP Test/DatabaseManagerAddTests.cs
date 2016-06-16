using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Participation_ASP.Models;


namespace Particpation_ASP_Test
{
    /// <summary>
    /// WARNING: This class will add data to the database. 
    /// Please re-run the creationscript before and after or use a savepoint.
    /// </summary>
    [TestClass]
    public class DatabaseManagerAddTests
    {
        [TestMethod]
        public void AddSkill()
        {
            Assert.IsTrue(DatabaseManager.AddSkill("TestSkill"));
        }

        [TestMethod]
        public void AddAvailability()
        {
            Assert.IsTrue(DatabaseManager.AddAvailability(2, "Za", "Ochtend"));
        }

        [TestMethod]
        public void AddPatient()
        {
            Assert.IsTrue(
                DatabaseManager.AddAccount(new Patient(0, "hman", "password", "email@email.com", "Henk", "0655889977",
                    new DateTime(), "Wilhelminastraat 14", "Uden", true, true, "07ce8902", false, new DateTime(), true,
                    false, true)));
        }

        [TestMethod]
        public void AddVolunteer()
        {
            Assert.IsTrue(
                DatabaseManager.AddAccount(new Volunteer(0, "henkje", "password", "email@mail.com", "Henk", "84984894",
                    new DateTime(), "Wilhelminastraat 15", "Uden", true, true, "c829as89", false, new DateTime(), true, false, new DateTime(), string.Empty, string.Empty, false, new List<Review>())));
        }
    }
}