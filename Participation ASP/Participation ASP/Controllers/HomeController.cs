// <copyright file="HomeController.cs" company="Participation.com">
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
    using Participation_ASP.Exceptions;
    using Participation_ASP.Models;

    /// <summary>
    /// The controller for the Homme-system
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Actionresult that returns the Index page
        /// </summary>
        /// <returns> View() </returns>
        public ActionResult Index()
        {
            try
            {
                DatabaseManager.TestConnection();
                Session["DbErrorMsg"] = null;
                return View();
            }
            catch (DatabaseNotConnectedException e)
            {
                Session["DbErrorMsg"] = e.Message;
                return View();
            }
        }
    }
}