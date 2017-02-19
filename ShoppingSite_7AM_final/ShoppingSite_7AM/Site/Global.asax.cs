using Newtonsoft.Json;
using Site.App_Start;
using Site.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using ViewModels;
using System.Web.Optimization;
using System.Security.Cryptography;

namespace Site
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            UnityConfig.RegisterComponents();
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            BundleTable.EnableOptimizations = true;
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            var error = Server.GetLastError();
            var cryptoEx = error as CryptographicException;
            if (cryptoEx != null)
            {
                FormsAuthentication.SignOut();               
                Server.ClearError();
            }
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {

                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                UserViewModel serializeModel = JsonConvert.DeserializeObject<UserViewModel>(authTicket.UserData);

                CustomPrincipal newUser = new CustomPrincipal(authTicket.Name);
                
                newUser.Name = serializeModel.Name;
                newUser.UserId = serializeModel.UserId;
                newUser.ContactNo = serializeModel.ContactNo;
                newUser.Roles = serializeModel.Roles;
                newUser.Email = serializeModel.Username;
                HttpContext.Current.User = newUser;
            }
        }
    }
}
