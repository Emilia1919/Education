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
    public class ManufacturerController : OrderedController<Manufacturer>
    {
        public ManufacturerController(IOrderedService<Manufacturer> _service) : base(_service) { }

        public ManufacturerController() : this(ManufacturerServiceFactory.Create()) { }
    }
}
