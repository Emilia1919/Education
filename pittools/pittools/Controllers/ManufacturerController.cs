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
    public class ManufacturerController : BaseController<Manufacturer>
    {
        public ManufacturerController(IBaseService<Manufacturer> _service) : base(_service) { }

        public ManufacturerController() : this(ManufacturerServiceFactory.Create()) { }
    }
}
