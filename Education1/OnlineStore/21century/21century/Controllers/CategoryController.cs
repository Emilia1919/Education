using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _21century.Models;
using _21century.Service.Interface;
using _21century.Service.Factory;
using _21century.Controllers.Abstract;

namespace _21century.Controllers
{
    public class CategoryController : UrlFriendlyController<Category>
    {
        public CategoryController(IUrlFriendlyService<Category> _service) : base(_service) { }

        public CategoryController() : this(CategoryServiceFactory.Create()) { }

        #region Overridden virtual methods

        protected override ActionResult ReturnToList(Category obj)
        {
            return RedirectToAction("Index", "Home");
        }

        protected override ActionResult ReturnToObject(Category obj)
        {
            return RedirectToAction("GetShortName", new { shortname = obj.ShortName });
        }

        protected override string GetShortNameSource(FormCollection collection)
        {
            return collection["Name"];
        }

        #endregion
    }
}