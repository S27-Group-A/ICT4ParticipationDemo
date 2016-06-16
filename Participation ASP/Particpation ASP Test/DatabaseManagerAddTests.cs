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
    }
}