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
            if (Session["Account"] == null)
                return View();
            return RedirectToAction("Index", "Home");
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
                    if (((Account)Session["Account"]).Enabled)
                    {
                        Session["BannedMsg"] = null;
                        if (Session["Account"].GetType() == typeof(Volunteer))
                        {
                            if(((Volunteer)Session["Account"]).VogConfirmation || ((Volunteer)Session["Account"]).IsAdmin)
                            {
                                Session["VogMsg"] = null;
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                Session["Account"] = null;
                                Session["VogMsg"] = "Uw Verklaring Omtrent het Gedrag is nog niet goedgekeurd";
                                return RedirectToAction("Login", "Account");
                            }
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }

                    }
                    else
                    {
                        Session["Account"] = null;
                        Session["BannedMsg"] = "U bent verbannen u heeft geen toegang meer tot de applicatie.";
                        return RedirectToAction("Login", "Account");
                    }
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
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterPatient(Patient patient)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Session["Account"] == null)
                    {
                        Session["ErrorMsg"] = null;
                        patient.AddPatient(patient);
                        return RedirectToAction("Login", "Account");
                    }

                    return RedirectToAction("Index", "Error");
                }
                catch (ExistingUserException)
                {
                    Session["ErrorMsg"] = "Gebruiker bestaat al vul a.u.b een ander e-mail adres en/of gebruikersnaam in.";
                    return RedirectToAction("RegisterPatient", "Account");
                }
                catch (Exception)
                {
                    return RedirectToAction("Index", "Error");
                }
            }

            return RedirectToAction("Index", "Error");

        }

        /// <summary>
        /// ActionResult that adds a Volunteer to the database, and redirects the user to the Home index.
        /// </summary>
        /// <param name="volunteer"> The volunteer that needs to be added </param>
        /// <returns> RedirectToAction </returns>
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterVolunteer(Volunteer volunteer)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    if (Session["Account"] == null)
                    {
                        Session["ErrorMsg"] = null;
                        volunteer.AddVolunteer(volunteer);
                        return RedirectToAction("Login", "Account");
                    }
                    return RedirectToAction("Index", "Error");
                }
                catch (ExistingUserException)
                {
                    Session["ErrorMsg"] = "Gebruiker bestaat al vul a.u.b een ander e-mail adres en/of gebruikersnaam in.";
                    return RedirectToAction("RegisterVolunteer", "Account");
                }
                catch (Exception)
                {
                    return RedirectToAction("Index", "Error");
                }

            }
            return RedirectToAction("Index", "Error");
        }
    }
}