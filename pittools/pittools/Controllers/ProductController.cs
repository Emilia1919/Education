﻿using pittools.Controllers.Abstract;
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
        // Переход на страницу товара со страницы категории
        public ActionResult GetProductInCategory(string category, string product)
        {
            Product obj = (service as IUrlFriendlyService<Product>).Get(product);
            if (obj == null) return View("NotFound");
            return View("Details", obj);
        }
        // Переход на страницу товара со страницы коллекции
        public ActionResult GetProductInCollection(string category, string collection, string product)
        {
            Product obj = (service as IUrlFriendlyService<Product>).Get(product);
            if (obj == null) return View("NotFound");
            return View("Details", obj);
        }
        // Обработка загрузки картинки
        public ActionResult UploadImage(HttpPostedFileBase imagefile, int objID)
        {
            // Получаем объкут, для которого загружаем картинку
            Product obj = service.Get(objID);
            if (obj == null) return View("NotFound");

            try
            {
                if (imagefile != null)
                {
                    // Определяем название и полный путь полноразмерной картинки и миниатюры
                    string strExtension = System.IO.Path.GetExtension(imagefile.FileName);
                    string strSaveFileName = objID + strExtension;
                    string strSaveFullPath = System.IO.Path.Combine(Server.MapPath(Url.Content("~/Content")), Constants.PRODUCT_IMAGES_FOLDER, strSaveFileName);
                    string strSaveMiniFullPath = System.IO.Path.Combine(Server.MapPath(Url.Content("~/Content")), Constants.PRODUCT_IMAGES_FOLDER, Constants.PRODUCT_IMAGES_MINI_FOLDER, strSaveFileName);

                    // Если файлы с такими названиями уже имеются, удаляем их
                    if (System.IO.File.Exists(strSaveFullPath))
                        System.IO.File.Delete(strSaveFullPath);

                    if (System.IO.File.Exists(strSaveMiniFullPath))
                        System.IO.File.Delete(strSaveMiniFullPath);

                    // Сохраняем полную картинку и миниатюру
                    imagefile.ResizeAndSave(Constants.PRODUCT_IMAGE_HEIGHT, Constants.PRODUCT_IMAGE_WIDTH, strSaveFullPath);
                    imagefile.ResizeAndSave(Constants.PRODUCT_IMAGE_MINI_HEIGHT, Constants.PRODUCT_IMAGE_MINI_WIDTH, strSaveMiniFullPath);

                    // Расширение файла записываем в базу данных в поле ImageExt
                    obj.ImageExt = strExtension;
                    service.Save();
                }
            }
            catch (Exception ex)
            {
                string strErrorMessage = ex.Message;
                if (ex.InnerException != null) strErrorMessage = string.Format("{0} --- {1}", strErrorMessage, ex.InnerException.Message);
                ViewBag.ErrorMessage = strErrorMessage;
                return View("Error");
            }

            return ReturnToObject(obj);
        }
        // Формирование списка коллекций, принадлежащих категории с id равным значению параметра CategoryID
        public ActionResult CollectionsList(int? CategoryID)
        {
            List<SelectListItem> listCollections = null;

            if (CategoryID.HasValue)
            {
                var queryCollections = pittools.Service.Factory.CategoryServiceFactory.Create().Get(CategoryID.Value).Collections.Select(item => new { ID = item.ID, Name = item.Name }).ToList();
                listCollections = queryCollections.Select(item => new SelectListItem() { Text = item.Name, Value = item.ID.ToString(), Selected = false }).ToList();
            }
            else listCollections = new List<SelectListItem>();

            return PartialView("_CollectionsList", listCollections);
        }
    }
}
