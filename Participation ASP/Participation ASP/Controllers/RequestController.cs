using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Participation_ASP.Models;

namespace Participation_ASP.Controllers
{
    public class RequestController : Controller
    {
        // GET: Request
        public ActionResult Index()
        {
            IAccount accountInlog = (IAccount) Session["Account"];
            if (accountInlog is Volunteer)
            {
                Volunteer volunteer = accountInlog as Volunteer;
                return View(volunteer);
            }
            return RedirectToAction("Index", "Error");
        }

        [HttpPost]
        public ActionResult RespondToRequeset(FormCollection collection)
        {
            string reactie = collection["Response"];
            if (reactie.Length > 0)
            {
                Content(reactie);
            }
            return RedirectToAction("Index", "Error");
        }
    }
}