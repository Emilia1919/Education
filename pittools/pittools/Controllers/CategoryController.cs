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
    public class CategoryController : UrlFriendlyController<Category>
    {
        public CategoryController(IUrlFriendlyService<Category> _service) : base(_service) { }

        public CategoryController() : this(CategoryServiceFactory.Create()) { }

        #region Overridden virtual methods

        protected override ActionResult ReturnToList(Category obj)
        {
            return RedirectToAction("Index", "Home");
        }

        protected override ActionResult ReturnToObject(Category obj)
        {
            return RedirectToAction("GetShortName", new { shortname = obj.ShortName });
        }

        protected override string GetShortNameSource(FormCollection collection)
        {
            return collection["Name"];
        }

        #endregion

        public ActionResult UploadCatalogImage(HttpPostedFileBase imagefile, int objID)
        {
            // Получаем объект, для которого загружаем картинку
            Category obj = service.Get(objID);
            if (obj == null) return View("NotFound");

            try
            {
                if (imagefile != null)
                {
                    // Определяем название конечного графического файла вместе с полным путём.
                    // Название файла должно быть такое же, как ID объекта. Это гарантирует уникальность названия.
                    // Расширение должно быть такое же, как расширение у исходного графического файла.
                    string strExtension = System.IO.Path.GetExtension(imagefile.FileName);
                    string strSaveFileName = objID + strExtension;
                    string strSaveFullPath = System.IO.Path.Combine(Server.MapPath(Url.Content("~/Content")), Constants.CATEGORY_MINI_IMAGES_FOLDER, strSaveFileName);

                    // Если файл с таким названием имеется, удаляем его.
                    if (System.IO.File.Exists(strSaveFullPath)) System.IO.File.Delete(strSaveFullPath);

                    // Сохраняем картинку, изменив её размеры.
                    imagefile.ResizeAndSave(Constants.CATEGORY_MINI_IMAGE_HEIGHT, Constants.CATEGORY_MINI_IMAGE_WIDTH, strSaveFullPath);

                    // Расширение файла записываем в базу данных в поле ImageExt.
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
    }
}
