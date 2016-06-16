
﻿namespace Participation_ASP.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using Participation_ASP.Models;


    /// <summary>
    /// The controller for the Login System
    /// </summary>
    public class AccountController : Controller
    {
        /// <summary>
        /// The standard ActionResult; this redirects to an empty page.
        /// </summary>
        /// <returns> View() </returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// The ActionResult for loading a blank Register page.
        /// </summary>
        /// <returns> View() </returns>
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// The ActionResult for loading a blank Login page.
        /// </summary>
        /// <returns> View() </returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// The Actionresult for a submitted account. The data gets inserted into the database, and the user gets redirected to the Profile System.
        /// </summary>
        /// <param name="loginAccount"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Account loginAccount)
        {
            if (loginAccount.Email != string.Empty && loginAccount.Password != string.Empty)
            {
                Session["Account"] = loginAccount.LoginAccount(loginAccount);
                if (Session["Account"] != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        /// <summary>
        /// The ActionResult to log out. This redirects the user to the Homepage of the Account System.
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            Session["Account"] = null;
            if (Session["Account"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult RegisterPatient()
        {
            return View();
        }

        public ActionResult RegisterVolunteer()
        {
            return View();
        }

        public ActionResult AddPatient(Patient patient)
        {
            try
            {

                if (Session["Account"] == null)
                {
                    patient.AddPatient(patient);
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index", "Error");
            }
            catch (ExistingUserException)
            {
                //TODO Error Message 
                return RedirectToAction("Index", "Error");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }

        }

        public ActionResult AddVolunteer(Volunteer volunteer)
        {
            try
            {
                if (Session["Account"] == null)
                {
                    volunteer.AddPatient(volunteer);
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index", "Error");
            }
            catch (ExistingUserException)
            {
                //TODO Error Message
                return RedirectToAction("Index", "Error");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }


    }
}