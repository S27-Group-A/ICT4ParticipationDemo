using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
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

        public ActionResult Adminpanel()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Account account)
        {
            if (account.Email != string.Empty && account.Password != string.Empty)
            {
                Session["User"] = account.LoginAccount(account);
                if (Session["User"] != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}