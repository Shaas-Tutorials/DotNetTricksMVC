using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
namespace Site.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js/lib").Include("~/Scripts/jquery-1.10.2.min.js", "~/Scripts/bootstrap.min.js", "~/Scripts/angular.js", "~/Scripts/angular-ui-router.js","~/Scripts/CryptoJS/rollups/sha512.js"));

            bundles.Add(new ScriptBundle("~/js/app").Include("~/Views/App/app.js", "~/Views/App/services/store.service.js", "~/Views/App/models/shoppingCart.js", "~/Views/App/controllers/store.controller.js"));

            bundles.Add(new StyleBundle("~/css/app").Include("~/Content/Site.css", "~/Content/bootstrap.min.css"));
        }
    }
}