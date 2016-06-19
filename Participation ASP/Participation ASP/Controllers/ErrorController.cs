// <copyright file="ErrorController.cs" company="Participation.com">
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

    /// <summary>
    /// The controller for the Error-system
    /// </summary>
    public class ErrorController : Controller
    {
        /// <summary>
        /// ActionResult that generates the error-handling page.
        /// </summary>
        /// <returns> View() </returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}