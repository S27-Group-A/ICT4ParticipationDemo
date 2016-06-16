// <copyright file="AccountController.cs">
// All rights reserved.
// </copyright>
// <author>S27 A</author>
namespace Participation_ASP.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using Participation_ASP.Models;
    using Participation_ASP.Exceptions;


    /// <summary>
    /// The controller for the Login-system
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
        /// <returns> RedirectToAction() </returns>
        public ActionResult Logout()
        {
            Session["Account"] = null;
            if (Session["Account"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        /// <summary>
        /// The Actionresult that creates a blank Register page for a Patient.
        /// </summary>
        /// <returns> View() </returns>
        public ActionResult RegisterPatient()
        {
            return View();
        }

        /// <summary>
        /// The Actionresult that creates a blank Register page for a volunteer.
        /// </summary>
        /// <returns> View() </returns>
        public ActionResult RegisterVolunteer()
        {
            return View();
        }

        /// <summary>
        /// ActionResult that adds a Patient to the database, and redirects the user to the Home index.
        /// </summary>
        /// <param name="patient"> The patient that needs to be added </param>
        /// <returns> RedirectToAction() </returns>
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

        /// <summary>
        /// ActionResult that adds a Volunteer to the database, and redirects the user to the Home index.
        /// </summary>
        /// <param name="volunteer"> The volunteer that needs to be added </param>
        /// <returns> RedirectToAction </returns>
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