// <copyright file="AccountController.cs">
// All rights reserved.
// </copyright>
// <author>S27 A</author>

using System.Text.RegularExpressions;
using Participation_ASP.Exceptions;

namespace Participation_ASP.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Participation_ASP.Models;

    /// <summary>
    /// The controller for the Meeting-system
    /// </summary>
    public class MeetingController : Controller
    {
        /// <summary>
        /// ActionResult that returns the Index-page of a meeting.
        /// </summary>
        /// <returns> View(patient) Or View(Volunteer) </returns>
        
        public ActionResult Index()
        {
            Session["MeetingVolunteer"] = null;
            IAccount accountLoggedIn = (IAccount)Session["Account"];
            if (accountLoggedIn != null)
            {
                if (accountLoggedIn is Patient)
                {
                    Patient patient = accountLoggedIn as Patient;
                    return View(patient);
                }
                if (accountLoggedIn is Volunteer)
                {
                    Volunteer volunteer = accountLoggedIn as Volunteer;
                    return View(volunteer);
                }
            }

            return RedirectToAction("Index", "Error");
        }

        /// <summary>
        /// ActionResult that creates a meeting-object, and inserts it into the database.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns> RedirectToAction() </returns>
        [HttpPost]
        public ActionResult PlanMeeting(FormCollection collection)
        {
            try
            {
                Session["MeetingErrorMsg"] = null;
                string volunteerEmail = collection["volunteer"];
                string location = collection["location"];
                DateTime date = new DateTime();
                if (!string.IsNullOrEmpty(collection["date"]))
                {
                    date = Convert.ToDateTime(collection["date"]);
                }

                if (!string.IsNullOrEmpty(location) && date > DateTime.Today)
                {
                    ViewModel viewModel = new ViewModel();
                    Volunteer volunteer = null;
                    foreach (IAccount a in viewModel.AccountList)
                    {
                        if (a.Email == volunteerEmail)
                        {
                            volunteer = a as Volunteer;
                        }
                    }

                    Meeting meeting = new Meeting();
                    meeting.AddMeeting(new Meeting((Patient)Session["Account"], volunteer, location, date, false));
                    return RedirectToAction("Index", "Meeting");
                }
                else if (date < DateTime.Today)
                {
                    Session["MeetingErrorMsg"] = "U kunt alleen een toekomstige datum kiezen.";
                    return RedirectToAction("Index", "Meeting");
                }
                else
                {
                    Session["MeetingErrorMsg"] = "U moet alle velden invullen om een gesprek te plannen.";
                    return RedirectToAction("Index", "Meeting");
                }

                return RedirectToAction("Index", "Error");
            }
            catch (FormatException)
            {
                Session["MeetingErrorMsg"] = "De velden waren niet correct ingevuld";
                return RedirectToAction("Index", "Meeting");
            }
            catch (ExistingMeetingException)
            {
                Session["MeetingErrorMsg"] = "U heeft al een kennismakingsgesprek met deze persoon.";
                return RedirectToAction("Index", "Meeting");
            }
        }

        [Route("Request/RequestInfo/{id}")]
        public ActionResult AcceptMeeting(string id)
        {
            string[] input = id.Split('-');
            int volunteerId = Convert.ToInt32(input[0]);
            int patientId = Convert.ToInt32(input[1]);
            ViewModel viewModel = new ViewModel();
            foreach (Meeting m in viewModel.MeetingList)
            {
                if (m.Volunteer.AccountId == volunteerId && m.Patient.AccountId == patientId)
                {
                    m.Status = true;
                    if (m.ChangeStatus(m))
                    {
                        return RedirectToAction("Index", "Meeting");
                    }
                }
            }
            return RedirectToAction("Index", "Error");
        }
    }
}