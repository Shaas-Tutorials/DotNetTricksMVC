using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Site.Security
{
    public abstract class BasePage : WebViewPage
    {
        public CustomPrincipal CurrentUser
        {
            get
            {
                return HttpContext.Current.User as CustomPrincipal;
            }
        }
    }

    public abstract class BasePage<T> : WebViewPage<T>
    {
        public CustomPrincipal CurrentUser
        {
            get
            {
                return HttpContext.Current.User as CustomPrincipal;
            }
        }
    }
}