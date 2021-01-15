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
    [Authorize(Roles = Constants.ROLE_ADMIN)]
    public class OrderStatusController : OrderedController<OrderStatus>
    {
        public OrderStatusController(IOrderedService<OrderStatus> _service) : base(_service) { }

        public OrderStatusController() : this(OrderStatusServiceFactory.Create()) { }

        protected override ActionResult ReturnToObject(OrderStatus obj)
        {
            return RedirectToAction("Index");
        }
    }
}