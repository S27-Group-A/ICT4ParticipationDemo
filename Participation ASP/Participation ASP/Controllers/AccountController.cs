namespace Participation_ASP.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using Participation_ASP.Models;

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
    }
}