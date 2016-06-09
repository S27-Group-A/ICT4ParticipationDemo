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
            List<Availability> tempA = new List<Availability>();
            List<Skill> tempS = new List<Skill>();
            tempA.Add(new Availability("Ma", "Morgen"));
            tempA.Add(new Availability("Di", "Middag"));
            tempS.Add(new Skill("Timmeren"));
            Volunteer volunteer = new Volunteer(1, "Henk", "test", "-", "Henk", 0, DateTime.Now, "0", "0", true, true, "0", false, true, true, DateTime.Now, "0", "0", true, tempA, tempS);
            return View(volunteer);
        }

        [HttpPost]
        public ActionResult AddSkill(FormCollection collection, Account volunteer)
        {
            collection["skill"]
        }
    }
}