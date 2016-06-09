using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
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
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Account loginAccount)
        {
            if (loginAccount.Email != String.Empty && loginAccount.Password != string.Empty)
            {
                Session["User"] = loginAccount.GetAccount(loginAccount);
                if (Session["User"] != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}