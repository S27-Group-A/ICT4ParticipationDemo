// <copyright file="AccountController.cs">
// All rights reserved.
// </copyright>
// <author>S27 A</author>
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
            string volunteerEmail = collection["volunteer"];
            string location = collection["location"];
            DateTime date = Convert.ToDateTime(collection["date"]);

            if (location != "" && date > DateTime.Today)
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
                meeting.AddMeeting(new Meeting((Patient) Session["Account"], volunteer, location, date, false));
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Error");
        }
    }
}