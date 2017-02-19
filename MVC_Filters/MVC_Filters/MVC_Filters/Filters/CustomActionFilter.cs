using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
namespace MVC_Filters.Filters
{
    public class CustomActionFilter : FilterAttribute, IActionFilter
    {
        //post
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string actionName = filterContext.ActionDescriptor.ActionName;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var user = filterContext.HttpContext.User;

            filterContext.HttpContext.Response.Write("Post Action<br/>");
        }

        //pre
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string actionName = filterContext.ActionDescriptor.ActionName;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var user = filterContext.HttpContext.User;

            filterContext.HttpContext.Response.Write("Pre Action<br/>");
        }
    }
}