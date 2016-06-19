// <copyright file="AccountController.cs">
// All rights reserved.
// </copyright>
// <author>S27 A</author>

using Participation_ASP.Exceptions;

namespace Participation_ASP.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Async;
    using Microsoft.SqlServer.Server;
    using Participation_ASP.Models;

    /// <summary>
    /// The controller for the Profile-system
    /// </summary>
    public class ProfileController : Controller
    {
        /// <summary>
        /// ActionResult that returns the index of a profile page.
        /// </summary>
        /// <returns> View(IAcount) Or RedirectToAction() </returns>
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
                IAccount temp = (IAccount) Session["Account"];
                Session["Account"] = DatabaseManager.GetAccount(temp.Email, temp.Password);
                return View((IAccount)Session["Account"]);
            }

        }

        /// <summary>
        /// Actionresult that creates a Skill-object and inserts in into the database.
        /// </summary>
        /// <param name="collection"> The data for the skill-object </param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddSkill(FormCollection collection)
        {
            IAccount account = (IAccount)Session["Account"];
            string skill = collection["skill"];

            if (account is Volunteer && skill.Length > 0)
            {
                Volunteer tempV = account as Volunteer;
                ViewModel viewModel = new ViewModel();
                Skill temp = null;
                foreach (Skill s in viewModel.SkillList)
                {
                    if (skill == s.Description)
                    {
                        temp = s;
                    }
                }
                try
                {
                    DatabaseManager.AddVolunteerSkill(tempV, temp);
                    Session["ErrorMsg"] = null;
                }
                catch (ExistingSkillException)
                {
                    Session["ErrorMsg"] = "U bezit deze vaardigheid al.";
                    return RedirectToAction("Index", "Profile");
                }
                
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddAvailabilities(FormCollection collection)
        {
            string dag = collection["dag"];
            string dagdeel = collection["dagdeel"];
            Volunteer volunteer = (Volunteer) Session["Account"];
            bool added = false;
            foreach (Availability a in volunteer.Availabilities)
            {
                if (a.Day == dag && a.TimeOfDay == dagdeel)
                {
                    added = true;
                }
            }
            if (!added)
            {
                Session["ErrorAvail"] = string.Empty;
                if (!DatabaseManager.AddAvailability(volunteer.AccountId, dag, dagdeel))
                {
                    return Content("Something went wrong");
                }
                else
                {
                    return RedirectToAction("Index", "Profile");
                }
            }
            else
            {
                Session["ErrorAvail"] = "Deze is al in gebruik.";
                return RedirectToAction("Index", "Profile");
            }
        }

        [Route("Profile/ProfileInfo/{id}")]
        public ActionResult ProfileInfo(string id)
        {
            int intId;
            if (int.TryParse(id, out intId))
            {
                IAccount account = DatabaseManager.GetAccount(intId);
                return View(account);
            }
            return RedirectToAction("Index", "Error");
        }
    }
}