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
    public class CategoryProductController : OrderedController<CategoryProduct>
    {
        public CategoryProductController(IOrderedService<CategoryProduct> _service) : base(_service) { }

        public CategoryProductController() : this(CategoryProductServiceFactory.Create()) { }

        #region Actions

        // Обрабатываем форму добавления категории к товару
        [Authorize(Roles = Constants.ROLES_ADMIN_CONTENT_MANAGER)]
        public ActionResult Add(int? CategoryID, int ProductID)
        {
            Product product = _21century.Service.Factory.ProductServiceFactory.Create().Get(ProductID);

            if (CategoryID.HasValue && product.CategoryProducts.Where(item => item.CategoryID == CategoryID.Value).Count() == 0)
            {
                CategoryProduct obj = new CategoryProduct();
                obj.CategoryID = CategoryID.Value;
                obj.ProductID = ProductID;
                AddValuesOnCreate(obj);

                service.Add(obj);
                service.Save();
            }

            return RedirectToAction("GetProductInManufacturer", "Product", new { manufacturer = product.Manufacturer.ShortName, product = product.ShortName });
        }

        #endregion

        #region Overridden virtual methods

        // После перемещения вверх перенаправляем на страницу категории
        protected override ActionResult OnUp(CategoryProduct obj)
        {
            return RedirectToAction("GetShortName", "Category", new { shortname = obj.Category.ShortName });
        }

        // После перемещения вних перенаправляем на страницу категории
        protected override ActionResult OnDown(CategoryProduct obj)
        {
            return RedirectToAction("GetShortName", "Category", new { shortname = obj.Category.ShortName });
        }

        // Перенаправляем на страницу товара
        protected override ActionResult ReturnToList(CategoryProduct obj)
        {
            return RedirectToAction("GetProductInManufacturer", "Product", new { manufacturer = obj.Product.Manufacturer.ShortName, product = obj.Product.ShortName });
        }

        // Перенаправляем на страницу товара
        protected override ActionResult ReturnToObject(CategoryProduct obj)
        {
            return RedirectToAction("GetProductInManufacturer", "Product", new { manufacturer = obj.Product.Manufacturer.ShortName, product = obj.Product.ShortName });
        }

        #endregion
    }
}