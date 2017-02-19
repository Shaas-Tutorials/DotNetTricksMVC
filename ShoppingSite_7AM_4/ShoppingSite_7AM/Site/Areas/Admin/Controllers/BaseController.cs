using Site.Filters;
using Site.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Areas.Admin.Controllers
{
    [CustomAuthenticationFilter]
    [CustomAuthorizationFilter(Roles="Admin")]
    public class BaseController : Controller
    {
        public CustomPrincipal CurrentUser
        {
            get
            {
                return HttpContext.User as CustomPrincipal;
            }
        }
    }
}