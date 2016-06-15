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
            IAccount account = Session["Account"] as Account;
            if (account != null)
            {
                if (account.IsAdmin)
                {
                    return View(new ViewModel());
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult AdminProfile(int ID)
        {
            IAccount account = Session["Account"] as Account;
            if (account != null)
            {
                if (account.IsAdmin)
                {
                    //return View(DatabaseManager.GetProfile(ID));
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult AdminRequest(int ID)
        {
            IAccount account = Session["Account"] as Account;
            if (account != null)
            {
                if (account.IsAdmin)
                {
                    //return View(DatabaseManager.GetRequest(ID));
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult AlterAdmin(int ID)
        {
            IAccount account = Session["Account"] as Account;
            if (account != null)
            {
                if (account.IsAdmin)
                {
                    //DatabaseManager.AlterAdmin(ID);
                    return RedirectToAction("AdminPanel");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        #region Delete
        public ActionResult AdminDeleteProfile(int ID)
        {
            IAccount account = Session["Account"] as Account;
            if (account != null)
            {
                if (account.IsAdmin)
                {
                    //DatabaseManager.DeleteProfile(ID);
                    return RedirectToAction("AdminPanel");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Home");
        }


        public ActionResult DeleteRequest(int ID)
        {
            IAccount account = Session["Account"] as Account;
            if (account != null)
            {
                if (account.IsAdmin)
                {
                    //DatabaseManager.DeleteRequest(ID);
                    return RedirectToAction("AdminPanel");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult DeleteReview(int ID)
        {
            IAccount account = Session["Account"] as Account;
            if (account != null)
            {
                if (account.IsAdmin)
                {
                    //DatabaseManager.DeleteReview(ID)
                    return RedirectToAction("AdminPanel");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}