using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pittools.Controllers.Abstract;
using pittools.Models;
using pittools.Service.Factory;
using pittools.Service.Interface;

namespace pittools.Controllers
{
    public class ManufacturerController : UrlFriendlyController<Manufacturer>
    {
        public ManufacturerController(IUrlFriendlyService<Manufacturer> _service) : base(_service) { }

        public ManufacturerController() : this(ManufacturerServiceFactory.Create()) { }

        #region Overridden virtual methods

        // На страницу списка переходим через действие GetShortName без параметров
        protected override ActionResult ReturnToList(Manufacturer obj)
        {
            return RedirectToAction("GetShortName", new { shortname = string.Empty });
        }

        // На страницу объекта переходим через действие GetShortName с текстовым параметром shortName
        protected override ActionResult ReturnToObject(Manufacturer obj)
        {
            return RedirectToAction("GetShortName", new { shortname = obj.ShortName });
        }

        // Свойство ShortName будет автогенерироваться из свойства Name
        protected override string GetShortNameSource(FormCollection collection)
        {
            return collection["Name"];
        }

        #endregion
    }
}