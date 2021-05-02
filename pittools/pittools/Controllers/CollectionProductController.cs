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
    public class CollectionProductController : OrderedController<CollectionProduct>
    {
        public CollectionProductController(IOrderedService<CollectionProduct> _service) : base(_service) { }

        public CollectionProductController() : this(CollectionProductServiceFactory.Create()) { }

        #region Actions

        [Authorize(Roles = Constants.ROLES_ADMIN_CONTENT_MANAGER)]
        public ActionResult Add(int? CollectionID, int ProductID)
        {
            Product product = pittools.Service.Factory.ProductServiceFactory.Create().Get(ProductID);

            if (CollectionID.HasValue && product.CollectionProducts.Where(item => item.CollectionID == CollectionID.Value).Count() == 0)
            {
                CollectionProduct obj = new CollectionProduct();
                obj.CollectionID = CollectionID.Value;
                obj.ProductID = ProductID;
                AddValuesOnCreate(obj);

                service.Add(obj);
                service.Save();
            }

            return RedirectToAction("GetProductInManufacturer", "Product", new { manufacturer = product.Manufacturer.ShortName, product = product.ShortName });
        }

        #endregion

        #region Overridden virtual methods

        protected override ActionResult OnUp(CollectionProduct obj)
        {
            return RedirectToAction("GetCollectionInCategory", "Collection", new { category = obj.Collection.Category.ShortName, collection = obj.Collection.ShortName });
        }

        protected override ActionResult OnDown(CollectionProduct obj)
        {
            return RedirectToAction("GetCollectionInCategory", "Collection", new { category = obj.Collection.Category.ShortName, collection = obj.Collection.ShortName });
        }

        protected override ActionResult ReturnToList(CollectionProduct obj)
        {
            return RedirectToAction("GetProductInManufacturer", "Product", new { manufacturer = obj.Product.Manufacturer.ShortName, product = obj.Product.ShortName });
        }

        protected override ActionResult ReturnToObject(CollectionProduct obj)
        {
            return RedirectToAction("GetProductInManufacturer", "Product", new { manufacturer = obj.Product.Manufacturer.ShortName, product = obj.Product.ShortName });
        }

        #endregion
    }
}
