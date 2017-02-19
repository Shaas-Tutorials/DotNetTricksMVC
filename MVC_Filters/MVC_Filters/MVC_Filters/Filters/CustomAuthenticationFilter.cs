using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using System.Web.Mvc.Filters;
namespace MVC_Filters.Filters
{
    public class CustomAuthenticationFilter : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            filterContext.HttpContext.Response.Write("On Authentication<br/>");
            //if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    filterContext.Result = new HttpUnauthorizedResult();
            //}
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            filterContext.HttpContext.Response.Write("Authentication Challenge<br/>");
            //if (filterContext.Result is HttpUnauthorizedResult)
            //{
            //    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Account", action = "login", area = "" }));
            //}
        }
    }
}