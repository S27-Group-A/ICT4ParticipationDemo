using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Async;
using Microsoft.SqlServer.Server;
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
                //List<Availability> tempA = new List<Availability>();
                //List<Skill> tempS = new List<Skill>();
                //tempA.Add(new Availability("Ma", "Morgen"));
                //tempA.Add(new Availability("Di", "Middag"));
                //tempS.Add(new Skill("Timmeren"));
                //Volunteer volunteer = new Volunteer(1, "Henk", "test", "testmail@test.nl", "Henk", string.Empty, DateTime.Now, string.Empty, string.Empty, false, false, string.Empty, false, DateTime.Now.AddDays(300), true, false, DateTime.Now, string.Empty, string.Empty, true);
                //volunteer.Availabilities = tempA;
                //volunteer.Skills = tempS;
                //Session["Account"] = (IAccount)volunteer;
                return RedirectToAction("Index", "Error");
            }
            else
            {
                return View((IAccount)Session["Account"]);
            }

        }

        [HttpPost]
        public ActionResult AddSkill(FormCollection collection)
        {
            IAccount account = (IAccount)Session["Account"];
            string skill = collection["skill"];
            if (account is Volunteer && skill.Length > 0)
            {
                Volunteer tempV = account as Volunteer;
                tempV.AddSkill(skill);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}