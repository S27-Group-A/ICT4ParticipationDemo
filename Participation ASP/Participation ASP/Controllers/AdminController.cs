// <copyright file="AccountController.cs">
// All rights reserved.
// </copyright>
// <author>S27 A</author>
namespace Participation_ASP.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Participation_ASP.Models;

    /// <summary>
    /// The controller for the Admin-system
    /// </summary>
    public class AdminController : Controller
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
        /// The ActionResult that redirects the user to the AdminPanel homepage.
        /// </summary>
        /// <returns> View(ViewModel) </returns>
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

        /// <summary>
        /// ActionResult that calls the GetAccount method from DatabaseManager, and redirects the user to the needed profile.
        /// </summary>
        /// <param name="iD"> The iD of the Account </param>
        /// <returns> RedirectToAction() </returns>
        public ActionResult AdminProfile(int iD)
        {
            IAccount account = Session["Account"] as IAccount;
            if (account != null)
            {
                if (account.IsAdmin)
                {
                    IAccount dbaccount = DatabaseManager.GetAccount(iD);
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

        /// <summary>
        /// ActionResult that shows a specific Profile belonging to a Volunteer.
        /// </summary>
        /// <returns> RedirectToAction() or View(account) </returns>
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

        /// <summary>
        /// ActionResult that shows a specific Profile belonging to a Patient.
        /// </summary>
        /// <returns> RedirectToAction() or View(account) </returns>
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

        /// <summary>
        /// ActionResult that shows a specific Request.
        /// </summary>
        /// <param name="iD"> The iD of the Account </param>
        /// <returns> RedirectToAction() or View(List<Request>) </returns>
        public ActionResult AdminRequest(int iD)
        {
            IAccount account = Session["Account"] as IAccount;
            if (account != null)
            {
                if (account.IsAdmin)
                {
                    return View(DatabaseManager.GetRequests(iD));
                }
            }

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// ActionResult that shows a specific list of reviews.
        /// </summary>
        /// <param name="iD"> The iD of the Account </param>
        /// <returns> RedirectToAction() or View(List<Review>) </returns>
        public ActionResult AdminReview(int iD)
        {
            IAccount account = Session["Account"] as IAccount;
            if (account != null)
            {
                if (account.IsAdmin)
                {
                    return View(DatabaseManager.GetReviews(iD));
                }
            }

            return RedirectToAction("Index", "Home");
        }

        #region Alter
        /// <summary>
        /// ActionResult that calls the AlterAdmin method in DatabaseManager, Giving the Account admin rights, or taking them away.
        /// </summary>
        /// <param name="iD"> The iD of the Account </param>
        /// <returns> RedirectToAction() </returns>
        public ActionResult AlterAdmin(int iD)
        {
            IAccount account = Session["Account"] as IAccount;
            if (account != null)
            {
                if (account.IsAdmin)
                {
                    DatabaseManager.AlterAdmin(iD);
                    return RedirectToAction("AdminPanel");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// ActionResult that calls the AlterProfile method in DatabaseManager, Locking the account.
        /// </summary>
        /// <param name="iD"> The iD of the Account </param>
        /// <returns> RedirectToAction() </returns>
        public ActionResult AlterEnabled(int iD)
        {
            IAccount account = Session["Account"] as IAccount;
            if (account != null)
            {
                if (account.IsAdmin)
                {
                    DatabaseManager.AlterEnabled(iD);
                    return RedirectToAction("AdminPanel");
                }
            }

            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Delete
        /// <summary>
        /// ActionResult that calls the AlterProfile method in DatabaseManager, Locking the account.
        /// </summary>
        /// <param name="id"> The iD of the Account </param>
        /// <returns> RedirectToAction() </returns>
        public ActionResult AdminDeleteProfile(int id)
        {
            IAccount account = Session["Account"] as IAccount;
            if (account != null)
            {
                if (account.IsAdmin)
                {
                    DatabaseManager.AlterEnabled(id);
                    return RedirectToAction("AdminPanel");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// ActionResult that calls the DeleteRequest method in DatabaseManager, deleting the Request and al its connections.
        /// </summary>
        /// <param name="id"> The iD of the Request </param>
        /// <returns> RedirectToAction() </returns>
        public ActionResult DeleteRequest(int id)
        {
            IAccount account = Session["Account"] as IAccount;
            if (account != null)
            {
                if (account.IsAdmin)
                {
                    DatabaseManager.DeleteRequest(id);
                    return RedirectToAction("AdminPanel");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// ActionResult that calls the DeleteReview method in DatabaseManager, deleting the Review and al its connections.
        /// </summary>
        /// <param name="iD"> The iD of the Review </param>
        /// <returns> RedirectToAction() </returns>
        public ActionResult DeleteReview(int iD)
        {
            IAccount account = Session["Account"] as IAccount;
            if (account != null)
            {
                if (account.IsAdmin)
                {
                    DatabaseManager.DeleteReview(iD);
                    return RedirectToAction("AdminPanel");
                }
            }

            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}