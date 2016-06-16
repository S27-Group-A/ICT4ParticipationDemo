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
                    new DateTime(), "Wilhelminastraat 14", "Uden", false, false, "86d4f7", false, true, false)));
        }

        [TestMethod]
        public void AddVolunteer()
        {
            Assert.IsTrue(
                DatabaseManager.AddAccount(new Volunteer(0, "henkje", "password", "email@mail.com", "Henk", "84984894",
                    new DateTime(), "Wilhelminastraat 15", "Uden", false, false, string.Empty, false, true, new DateTime(), string.Empty, string.Empty, false)));
        }

        [TestMethod]
        public void AddRequest()
        {

        }
    }
}