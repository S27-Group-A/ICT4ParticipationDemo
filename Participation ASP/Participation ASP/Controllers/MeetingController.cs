using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Participation_ASP.Models;

namespace Participation_ASP.Controllers
{
    public class MeetingController : Controller
    {
        // GET: Meeting
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

        [HttpPost]
        public ActionResult PlanMeeting(FormCollection collection)
        {
            string volunteerEmail = collection["volunteer"];
            string location = collection["location"];
            string date = collection["date"];
            return Content(volunteerEmail + "/" + location + "/" + date);
        }
    }
}