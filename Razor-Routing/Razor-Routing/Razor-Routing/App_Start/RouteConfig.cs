using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Razor_Routing
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //to enable attribute routing
            routes.MapMvcAttributeRoutes();

            //home/index
            //home/index/1

            //

            routes.MapRoute(
               name: "Default2",
               url: "{controller}/{action}/{id}/{catId}"
           );

           // routes.MapRoute(
           //    name: "Default3",
           //    url: "{controller}/{action}/{id}/{deptId}"
           //);

            routes.MapRoute(
               name: "Default1",
               url: "site/{action}/{controller}"
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
