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
        public ActionResult RespondToRequest(FormCollection collection, Request request)
        {
            string reactie = collection["ResponseText"];
            if (reactie.Length > 0)
            {
                Response newResponse = null;
                IAccount accountLoggedIn = (IAccount) Session["Account"];
                Volunteer volunteerAccount = accountLoggedIn as Volunteer;
                newResponse.AddResponse(new Response(volunteerAccount, reactie, DateTime.Now), request);
                request.AddResponse(new Response(volunteerAccount, reactie, DateTime.Now));
                return View("RequestInfo", request);
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