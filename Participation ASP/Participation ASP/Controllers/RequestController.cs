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
            if (accountInlog is Patient)
            {
                Patient patient = accountInlog as Patient;
                return View(patient);
            }
            return RedirectToAction("Index", "Error");
        }

        [HttpPost]
        public ActionResult RespondToRequest(FormCollection collection)
        {
            string reactie = collection["ResponseText"];
            if (reactie.Length > 0)
            {
                Response newResponse = new Response();
                IAccount accountLoggedIn = (IAccount) Session["Account"];
                Volunteer volunteerAccount = accountLoggedIn as Volunteer;
                newResponse.AddResponse(new Response(volunteerAccount, reactie, DateTime.Now), (Request)Session["CurrentRequest"]);
                ((Request)Session["CurrentRequest"]).AddResponse(new Response(volunteerAccount, reactie, DateTime.Now));
                return View("RequestInfo", (Request)Session["CurrentRequest"]);
            }
            return RedirectToAction("Index", "Error");
        }

        [Route("Request/RequestInfo/{id}")]
        public ActionResult RequestInfo(int id)
        {
            Request request = (Request) Session["Request" + id.ToString()];
            if (request != null)
            {
                Session["CurrentRequest"] = request;
                return View(request);
            }
            return RedirectToAction("Index", "Error");
        }
    }
}