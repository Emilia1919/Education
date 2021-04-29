using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using pittools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace pittools
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
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "Products",
                "products/{shortname}",
                new { controller = "Product", action = "GetShortName", shortname = UrlParameter.Optional }
                );

            routes.MapRoute(
                "ProductInManufacturer",
                "manufacturers/{manufacturer}/{product}",
                new { controller = "Product", action = "GetProductInManufacturer" }
                );
        }
        public static void AddAdmin()
        {
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            // Если нет в системе роли admin, создаём её
            if (!RoleManager.RoleExists(Constants.ROLE_ADMIN))
            {
                RoleManager.Create(new IdentityRole { Name = Constants.ROLE_ADMIN });
            }

            var adminEmail = "admin@pittools.com";
            // Если нет в системе пользователя admin, создаём его
            if (UserManager.FindByName(adminEmail) == null)
            {
                UserManager.Create(
                    new ApplicationUser
                    {
                        UserName = adminEmail,
                        Email = adminEmail
                    },
                    "temp_pass");
            }

            // Если у пользователя admin нет роли admin, присваиваем ему эту роль
            string adminId = UserManager.FindByName(adminEmail).Id;
            if (!UserManager.IsInRole(adminId, Constants.ROLE_ADMIN))
            {
                UserManager.AddToRole(adminId, Constants.ROLE_ADMIN);
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AddAdmin();
        }
    }
}
