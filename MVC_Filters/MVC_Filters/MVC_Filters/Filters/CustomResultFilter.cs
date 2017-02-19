using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
namespace MVC_Filters.Filters
{
    public class CustomResultFilter : FilterAttribute, IResultFilter
    {
        //post
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("Post Result<br/>");
        }

        //pre
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {            
            filterContext.HttpContext.Response.Write("Pre Result<br/>");
        }
    }
}