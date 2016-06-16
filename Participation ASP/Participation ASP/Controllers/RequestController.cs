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
        public ActionResult RespondToRequest(FormCollection collection)
        {
            string reactie = collection["Response"];
            if (reactie.Length > 0)
            {
                return Content(reactie);
            }
            return RedirectToAction("Index", "Error");
        }

        [Route("Request/RequestInfo/{id}")]
        public ActionResult RequestInfo(int id)
        {
            Request request = (Request) Session["Request" + id.ToString()];
            if (request != null)
            {
                return View(request);
            }
            return RedirectToAction("Index", "Error");
        }
    }
}