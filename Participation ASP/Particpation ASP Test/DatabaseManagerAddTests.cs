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
        //TODO Fix this
        public void AddVolunteer()
        {
            Assert.IsTrue(
                DatabaseManager.AddAccount(new Volunteer(0, "henkje", "password", "email@mail.com", "Henk", "84984894",
                    new DateTime(), "Wilhelminastraat 15", "Uden", false, false, string.Empty, false, true, new DateTime(), string.Empty, string.Empty, false)));
        }

        [TestMethod]
        public void AddRequest()
        {
            List<Skill> skills = new List<Skill>();
            skills.Add(new Skill(1, "Goed met dieren"));
            skills.Add(new Skill(2, "Masseur"));
            VehicleType vecType = new VehicleType(-1, "Dweebcar for the dweebs.");
            Patient patient = new Patient(1, "patient", "patient", "patient@patient.nl","patientje", string.Empty, DateTime.MinValue, string.Empty, string.Empty, false, false, string.Empty, false, true, true);
            Request request = new Request(-1,"testrequest", "testlocation", 1337, DateTime.Now, new DateTime(2016, 06, 20),3, 1, skills, vecType, patient, null );
            Assert.IsTrue(request.AddRequest(request));
        }

        [TestMethod]
        public void AddReview()
        {
            Assert.IsTrue(
                DatabaseManager.AddReview(
                    new Review(0, new Request(1), 7, "Cool")
                    , 2));
        }
    }
}