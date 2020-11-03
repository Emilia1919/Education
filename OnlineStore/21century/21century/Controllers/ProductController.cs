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
    public class ProductController : UrlFriendlyController<Product>
    {
        public ProductController(IUrlFriendlyService<Product> _service) : base(_service) { }
        public ProductController() : this(ProductServiceFactory.Create()) { }

        protected override bool IsPageable { get { return true; } }

        #region Overidden virtual methods

        protected override ActionResult ReturnToList(Product obj)
        {
            return RedirectToAction("GetShortName", new { shortname = string.Empty, page = Request.QueryString["page"] });
        }

        protected override ActionResult ReturnToObject(Product obj)
        {
            return RedirectToAction("GetShortName", new { shortname = obj.ShortName, page = Request.QueryString["page"] });
        }

        protected override string GetShortNameSource(FormCollection collection)
        {
            return collection["Name"];
        }
        protected override void ChangeFormCollectionValues(Product obj, FormCollection collection)
        {
            base.ChangeFormCollectionValues(obj, collection);

            collection["Price"] = collection["Price"].Replace(" ", "");
            collection["Price"] = collection["Price"].Replace(",", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);
            collection["Price"] = collection["Price"].Replace(".", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);
        }

        #endregion

        public ActionResult GetProductInManufacturer(string manufacturer, string product)
        {
            Product obj = (service as IUrlFriendlyService<Product>).Get(product);
            if (obj == null) return View("NotFound");
            return View("Details", obj);
        }
    }
}