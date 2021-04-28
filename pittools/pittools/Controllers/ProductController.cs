using pittools.Controllers.Abstract;
using pittools.Models;
using pittools.Service.Factory;
using pittools.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pittools.Controllers
{
    public class ProductController : UrlFriendlyController<Product>
    {
        public ProductController(IUrlFriendlyService<Product> _service) : base(_service) { }

        public ProductController() : this(ProductServiceFactory.Create()) { }

        // Включаем постраничный вывод
        protected override bool IsPageable { get { return true; } }

        #region Overridden virtual methods

        // На страницу списка переходим через действие GetShortName без параметров
        protected override ActionResult ReturnToList(Product obj)
        {
            return RedirectToAction("GetShortName", new { shortname = string.Empty, page = Request.QueryString["page"] });
        }

        // На страницу объекта переходим через действие GetShortName с текстовым параметром shortName
        protected override ActionResult ReturnToObject(Product obj)
        {
            return RedirectToAction("GetShortName", new { shortname = obj.ShortName, page = Request.QueryString["page"] });
        }

        // Свойство ShortName будет автогенерироваться из свойства Name
        protected override string GetShortNameSource(FormCollection collection)
        {
            return collection["Name"];
        }

        // Приводим разделитель десятичной дроби к стандартному, и удаляем пробелы
        protected override void ChangeFormCollectionValues(Product obj, FormCollection collection)
        {
            base.ChangeFormCollectionValues(obj, collection);

            collection["Price"] = collection["Price"].Replace(" ", "");
            collection["Price"] = collection["Price"].Replace(",", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);
            collection["Price"] = collection["Price"].Replace(".", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);
        }

        #endregion

        // Переход на страницу товара со страницы производителя
        public ActionResult GetProductInManufacturer(string manufacturer, string product)
        {
            Product obj = (service as IUrlFriendlyService<Product>).Get(product);
            if (obj == null) return View("NotFound");
            return View("Details", obj);
        }
    }
}
