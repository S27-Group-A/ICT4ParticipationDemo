using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Participation.SharedModels;

namespace ICT4ParticipationUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSharedModels()
        {
            #region Volunteer
            //Tests the first Volunteer constructor
            Volunteer TestVolunteer1 = new Volunteer(1, "Testname", "Test@email.com", "Test description", DateTime.Today, "Testprofilepicture", "TestLocation", "123456789", GenderEnum.Male, "Testpassword", "TestPdf", false);

            Assert.AreEqual(TestVolunteer1.Id, 1);
            Assert.AreEqual(TestVolunteer1.Name, "Testname");
            Assert.AreEqual(TestVolunteer1.Description, "Test description");
            Assert.AreEqual(TestVolunteer1.Birthday, DateTime.Today);
            Assert.AreEqual(TestVolunteer1.ProfilePicture, "Testprofilepicture");
            Assert.AreEqual(TestVolunteer1.Location, "TestLocation");
            Assert.AreEqual(TestVolunteer1.PhoneNumber, "123456789");
            Assert.AreEqual(TestVolunteer1.Gender, GenderEnum.Male);
            Assert.AreEqual(TestVolunteer1.Password, "Testpassword");
            Assert.AreEqual(TestVolunteer1.verklaringPdf, "TestPdf");
            Assert.AreEqual(TestVolunteer1.isAdmin, false);


            //Tests the second Volunteer constructor
            Volunteer TestVolunteer2 = new Volunteer("Testname", "Test@email.com", "Test description", DateTime.Today, "Testprofilepicture", "TestLocation", "123456789", GenderEnum.Male, "Testpassword", "TestPdf", false);

            Assert.AreEqual(TestVolunteer2.Id, null);
            Assert.AreEqual(TestVolunteer2.Name, "Testname");
            Assert.AreEqual(TestVolunteer2.Description, "Test description");
            Assert.AreEqual(TestVolunteer2.Birthday, DateTime.Today);
            Assert.AreEqual(TestVolunteer2.ProfilePicture, "Testprofilepicture");
            Assert.AreEqual(TestVolunteer2.Location, "TestLocation");
            Assert.AreEqual(TestVolunteer2.PhoneNumber, "123456789");
            Assert.AreEqual(TestVolunteer2.Gender, GenderEnum.Male);
            Assert.AreEqual(TestVolunteer2.Password, "Testpassword");
            Assert.AreEqual(TestVolunteer2.verklaringPdf, "TestPdf");
            Assert.AreEqual(TestVolunteer1.isAdmin, false);
            #endregion

            #region Patient
            //Tests the first Patient constructor
            Patient TestPatient1 = new Patient(1, "Testname", "Test@email.com", "Test description", DateTime.Today, "Testprofilepicture", "TestLocation", "123456789", GenderEnum.Male, "Testpassword");

            Assert.AreEqual(TestPatient1.Id, 1);
            Assert.AreEqual(TestPatient1.Name, "Testname");
            Assert.AreEqual(TestPatient1.Description, "Test description");
            Assert.AreEqual(TestPatient1.Birthday, DateTime.Today);
            Assert.AreEqual(TestPatient1.ProfilePicture, "Testprofilepicture");
            Assert.AreEqual(TestPatient1.Location, "TestLocation");
            Assert.AreEqual(TestPatient1.PhoneNumber, "123456789");
            Assert.AreEqual(TestPatient1.Gender, GenderEnum.Male);
            Assert.AreEqual(TestPatient1.Password, "Testpassword");

            //Tests the second Patient constructor
            Patient TestPatient2 = new Patient("Testname", "Test@email.com", "Test description", DateTime.Today, "Testprofilepicture", "TestLocation", "123456789", GenderEnum.Male, "Testpassword");

            Assert.AreEqual(TestPatient1.Id, null);
            Assert.AreEqual(TestPatient2.Name, "Testname");
            Assert.AreEqual(TestPatient2.Description, "Test description");
            Assert.AreEqual(TestPatient2.Birthday, DateTime.Today);
            Assert.AreEqual(TestPatient2.ProfilePicture, "Testprofilepicture");
            Assert.AreEqual(TestPatient2.Location, "TestLocation");
            Assert.AreEqual(TestPatient2.PhoneNumber, "123456789");
            Assert.AreEqual(TestPatient2.Gender, GenderEnum.Male);
            Assert.AreEqual(TestPatient2.Password, "Testpassword");
            #endregion

            #region Response
            Response TestReponse1 = new Response(1, "TestText", DateTime.Today, TestVolunteer1);

            Assert.AreEqual(TestReponse1.Id, 1);
            Assert.AreEqual(TestReponse1.Text, "TestText");
            Assert.AreEqual(TestReponse1.Date, DateTime.Today);
            Assert.AreEqual(TestReponse1.Responder, TestVolunteer1);

            Response TestResponse2 = new Response("TestText", DateTime.Today, TestVolunteer1);

            Assert.AreEqual(TestResponse2.Id, null);
            Assert.AreEqual(TestReponse1.Text, "TestText");
            Assert.AreEqual(TestReponse1.Date, DateTime.Today);
            Assert.AreEqual(TestReponse1.Responder, TestVolunteer1);
            #endregion

            #region Request
            List<string> TestPerks = new List<string>();
            Request TestRequest1 = new Request(1, "TestRequest", "TestText", TestPerks, "TestLocation", DateTime.Today, 1);

            Assert.AreEqual(TestRequest1.Id, 1);
            Assert.AreEqual(TestRequest1.Title, "TestRequest");
            Assert.AreEqual(TestRequest1.Text, "TestText");
            Assert.AreEqual(TestRequest1.Perks, TestPerks);
            Assert.AreEqual(TestRequest1.Location, "TestLocation");
            Assert.AreEqual(TestRequest1.Date, DateTime.Today);
            Assert.AreEqual(TestRequest1.Urgency, 1);

            Request TestRequest2 = new Request("TestRequest", "TestText", TestPerks, "TestLocation", DateTime.Today, 1);

            Assert.AreEqual(TestRequest1.Id, null);
            Assert.AreEqual(TestRequest2.Title, "TestRequest");
            Assert.AreEqual(TestRequest2.Text, "TestText");
            Assert.AreEqual(TestRequest2.Perks, TestPerks);
            Assert.AreEqual(TestRequest2.Location, "TestLocation");
            Assert.AreEqual(TestRequest2.Date, DateTime.Today);
            Assert.AreEqual(TestRequest2.Urgency, 1);
            #endregion

            #region Meeting
            Meeting TestMeeting1 = new Meeting(TestVolunteer1, TestPatient1, DateTime.Today, "TestLocation");

            Assert.AreEqual(TestMeeting1.Volunteer, TestVolunteer1);
            Assert.AreEqual(TestMeeting1.Patient, TestPatient1);
            Assert.AreEqual(TestMeeting1.Date, DateTime.Today);
            Assert.AreEqual(TestMeeting1.Location, "TestLocation");

            Meeting TestMeeting2 = new Meeting(TestVolunteer1, TestPatient1, DateTime.Today, "TestLocation");

            Assert.AreEqual(TestMeeting2.Volunteer, TestVolunteer1);
            Assert.AreEqual(TestMeeting2.Patient, TestPatient1);
            Assert.AreEqual(TestMeeting2.Date, DateTime.Today);
            Assert.AreEqual(TestMeeting2.Location, "TestLocation");
            #endregion
        }
    }
}
