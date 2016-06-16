using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Participation_ASP.Models;

namespace Participation_ASP.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminPanel()
        {
            IAccount account = Session["Account"] as IAccount;
            if (account != null)
            {
                if (account.IsAdmin)
                {
                    return View(new ViewModel());
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult AdminProfile(int ID)
        {
            IAccount account = Session["Account"] as IAccount;
            if (account != null)
            {
                if (account.IsAdmin)
                {
                    IAccount dbaccount = DatabaseManager.GetAccount(ID);
                    TempData["dbaccount"] = dbaccount;
                    if (dbaccount.GetType() == typeof(Volunteer))
                    {
                        return RedirectToAction("AdminProfileVolunteer");
                    }

                    if (dbaccount.GetType() == typeof(Patient))
                    {
                        return RedirectToAction("AdminProfilePatient");
                    }
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult AdminProfileVolunteer()
        {
            IAccount account = TempData["dbaccount"] as IAccount;
            if (account != null)
            {
                if (account.IsAdmin)
                {
                    return View(account);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult AdminProfilePatient()
        {
            IAccount account = TempData["dbaccount"] as IAccount;
            if (account != null)
            {
                if (account.IsAdmin)
                {
                    return View(account);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult AdminRequest(int ID)
        {
            IAccount account = Session["Account"] as IAccount;
            if (account != null)
            {
                if (account.IsAdmin)
                {
                    //return View(DatabaseManager.GetRequests(ID));
                    return View();
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult AdminReview(int ID)
        {
            IAccount account = Session["Account"] as IAccount;
            if (account != null)
            {
                if (account.IsAdmin)
                {
                    //return View(DatabaseManager.GetReviews(ID));
                    return View();
                }
            }

            return RedirectToAction("Index", "Home");
        }

        #region Alter
        public ActionResult AlterAdmin(int ID)
        {
            IAccount account = Session["Account"] as IAccount;
            if (account != null)
            {
                if (account.IsAdmin)
                {
                    //DatabaseManager.AlterAdmin(ID);
                    return RedirectToAction("AdminPanel");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult AlterEnabled(int ID)
        {
            IAccount account = Session["Account"] as IAccount;
            if (account != null)
            {
                if (account.IsAdmin)
                {
                    //DatabaseManager.AlterEnabled(ID);
                    return RedirectToAction("AdminPanel");
                }
            }

            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Delete
        public ActionResult AdminDeleteProfile(int ID)
        {
            IAccount account = Session["Account"] as IAccount;
            if (account != null)
            {
                if (account.IsAdmin)
                {
                    //DatabaseManager.DeleteProfile(ID);
                    return RedirectToAction("AdminPanel");
                }
            }

            return RedirectToAction("Index", "Home");
        }


        public ActionResult DeleteRequest(int ID)
        {
            IAccount account = Session["Account"] as IAccount;
            if (account != null)
            {
                if (account.IsAdmin)
                {
                    //DatabaseManager.DeleteRequest(ID);
                    return RedirectToAction("AdminPanel");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult DeleteReview(int ID)
        {
            IAccount account = Session["Account"] as IAccount;
            if (account != null)
            {
                if (account.IsAdmin)
                {
                    //DatabaseManager.DeleteReview(ID)
                    return RedirectToAction("AdminPanel");
                }
            }

            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}