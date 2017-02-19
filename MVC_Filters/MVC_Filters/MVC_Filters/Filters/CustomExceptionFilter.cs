using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MVC_Filters.Filters
{
    public class CustomExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.Write("Exception Filter<br/>");

            filterContext.HttpContext.Response.Write(filterContext.Exception.Message);
            
            //remove yellow page
            filterContext.ExceptionHandled = true;
        }
    }
}