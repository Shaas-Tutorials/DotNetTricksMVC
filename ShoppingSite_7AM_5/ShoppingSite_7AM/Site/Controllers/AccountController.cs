using BAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login");
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string url)
        {
            UserViewModel user = repo_User.ValidateUser(model);
            if (user != null)
            {
                string data = JsonConvert.SerializeObject(user);

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.Username, DateTime.Now, DateTime.Now.AddMinutes(30), true, data);
                string encTicket = FormsAuthentication.Encrypt(ticket);

                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                Response.Cookies.Add(cookie);

                if (!string.IsNullOrEmpty(url))
                {
                    Response.Redirect(url);
                }
                else if (user.Roles.Contains("Admin"))
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

        public ActionResult Unauthorize()
        {
            return View();
        }
    }
}