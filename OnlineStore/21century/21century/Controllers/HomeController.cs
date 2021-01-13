using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _21century.Models;
using _21century.Service.Interface;
using _21century.Service.Factory;

namespace _21century.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IUrlFriendlyService<Category> service = CategoryServiceFactory.Create();
            IEnumerable<Category> categories = service.Get();

            return View(categories);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}