// <copyright file="ChatController.cs" company="Participation.com">
//      Participation.com. All rights reserved.
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
    /// The controller for the Chat system
    /// </summary>
    public class ChatController : Controller
    {
        /// <summary>
        /// ActionResult that returns the room page.
        /// </summary>
        /// <returns> View() or RedirectToAction() </returns>
        [RequireHttps]
        public ActionResult Room()
        {
            if (Session["Account"] != null)
            {
                ViewBag.UserName = ((IAccount)Session["Account"]).Username;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}