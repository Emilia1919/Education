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
    public class ManufacturerController : UrlFriendlyController<Manufacturer>
    {
        public ManufacturerController(IUrlFriendlyService<Manufacturer> _service) : base(_service) { }

        public ManufacturerController() : this(ManufacturerServiceFactory.Create()) { }

        #region Overridden virtual methods

        protected override ActionResult ReturnToList(Manufacturer obj)
        {
            return RedirectToAction("GetByShortName", new { shortname = string.Empty});
        }

        protected override ActionResult ReturnToObject(Manufacturer obj)
        {
            return RedirectToAction("GetByShortName", new { shortname = obj.ShortName });
        }

        protected override string GetShortNameSource(FormCollection collection)
        {
            return collection["Name"];
        }

        #endregion
    }
}