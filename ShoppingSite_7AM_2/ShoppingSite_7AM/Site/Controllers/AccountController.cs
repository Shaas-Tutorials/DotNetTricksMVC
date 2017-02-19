using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace Site.Controllers
{
    public class AccountController : Controller
    {
        IUserRepository repo_User;
        public AccountController(IUserRepository _repo_User)
        {
            repo_User = _repo_User;
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            UserViewModel user = repo_User.ValidateUser(model);
            if (user != null)
            {
                if (user.Roles.Contains("Admin"))
                {
                    return RedirectToAction("Index", "Home", new { area = "admin" });
                }
                else if (user.Roles.Contains("User"))
                {
                    return RedirectToAction("Index", "Home", new { area = "user" });
                }
            }
            return View();
        }
    }
}