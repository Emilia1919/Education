using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace _21century
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Manufacturers",
                "manufacturers/{shortname}",
                new { controller = "Manufacturer", action = "GetShortName", shortname = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Product",
                "products/{shortname}",
                new { controller = "Product", aciton = "GetProductInManufacturer" }
                );

            routes.MapRoute(
                "ProductInManufacturer",
                "manufacturers/{manufacturer}/{product}",
                new { controller = "Product", aciton = "GetProductInManufacturer" }
                );
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
