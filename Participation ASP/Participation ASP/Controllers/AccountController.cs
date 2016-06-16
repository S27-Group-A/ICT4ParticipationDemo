using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Participation_ASP.Exceptions;
using Participation_ASP.Models;

namespace Participation_ASP.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

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