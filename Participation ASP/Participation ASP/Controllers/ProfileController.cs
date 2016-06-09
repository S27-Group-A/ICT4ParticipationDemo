using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Participation_ASP.Models;

namespace Participation_ASP.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            Volunteer volunteer = new Volunteer(1, "Henk", "test", "-", "Henk", 0, DateTime.Now, "0", "0", true, true, "0", false, true, true, DateTime.Now, "0", "0", true);
            return View(volunteer);
        }
    }
}