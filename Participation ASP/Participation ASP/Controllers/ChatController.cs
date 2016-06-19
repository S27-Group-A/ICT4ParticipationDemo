using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Participation_ASP.Models;

namespace Participation_ASP.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        [RequireHttps]
        public ActionResult Room()
        {
            if (Session["Account"] != null)
            {
                ViewBag.UserName = ((IAccount) Session["Account"]).Username;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}