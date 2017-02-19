using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
namespace MVC_Filters.Filters
{
    public class CustomAuthorizationFilter : FilterAttribute, IAuthorizationFilter
    {
        public string Roles { get; set; }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.Write("On Authorization<br/>");

            //if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    if (!filterContext.HttpContext.User.IsInRole(Roles))
            //    {
            //        filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Account", action = "unauthorize", area = "" }));
            //    }
            //}
        }
    }
}