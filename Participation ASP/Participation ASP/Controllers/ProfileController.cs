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
            if (Session["Account"] == null)
            {
                List<Availability> tempA = new List<Availability>();
                List<Skill> tempS = new List<Skill>();
                tempA.Add(new Availability("Ma", "Morgen"));
                tempA.Add(new Availability("Di", "Middag"));
                tempS.Add(new Skill("Timmeren"));
                IAccount volunteer = new Volunteer(1, "Henk", "test", "-", "Henk", 0, DateTime.Now, "0", "0", true, true, "0", false, true, true, DateTime.Now, "0", "0", true, tempA, tempS);
                Session["Account"] = volunteer;
                return View(volunteer);
            }
            else
            {
                return View((IAccount) Session["Account"]);
            }

        }

        [HttpPost]
        public ActionResult AddSkill(FormCollection collection)
        {
            IAccount account = (IAccount) Session["Account"];
            if (account is Volunteer)
            {
                Volunteer tempV = account as Volunteer;
                tempV.AddSkill(collection["skill"]);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}